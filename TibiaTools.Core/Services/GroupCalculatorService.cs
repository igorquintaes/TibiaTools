using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TibiaTools.Core.Constants;
using TibiaTools.Core.DTO;
using TibiaTools.Core.Services.Contracts;
using TibiaTools.Domain.Contracts.Repositories;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Core.Services
{
    public class GroupCalculatorService : IGroupCalculatorService
    {
        /// <summary>
        /// Items database. Work into memory because read and compare informations ton of times
        /// Damn text comparation and exclusive cases
        /// </summary>
        private static List<Item> _tibiaItems { get; set; }

        /// <summary>
        /// Repository were we are able to obtain the data
        /// It was developed alone the service to not depends aways the same kind of resource
        /// </summary>
        private IItemRepository _itemRepository { get; set; }

        public GroupCalculatorService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;

            if (_tibiaItems == null || !_tibiaItems.Any())
            {
                _tibiaItems = _itemRepository.GetAll()
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Check if the input is valid as player quantity.
        /// It only can be numbers and non-negative values.
        /// </summary>
        /// <param name="textQuantity">User imput about players quantity</param>
        /// <returns>Players quantity as int. 0 will be returned if the input is not valid</returns>
        public int ObtainPlayersQuantity(string textQuantity)
        {
            var value = 0;
            if (!Int32.TryParse(textQuantity, out value) ||
                value > GroupCalculatorConstants.MaxMemberQuantity ||
                value <= 0)
            {
                return 0;
            }

            return value;
        }

        /// <summary>
        /// Based on a text that contains all items looks, 
        /// The code try to understand and returns all items 
        /// With their respect values and quantities
        /// </summary>
        /// <param name="textInput">Tibia item look text</param>
        /// <returns>List of ItemResult, that contains all data necessary to split and to user know</returns>
        public IEnumerable<ItemResultDTO> ResolveItemList(string textInput)
        {
            if (String.IsNullOrEmpty(textInput))
            {
                return null;
            }

            var split = textInput.Split(
                new[] { "You see a ", "You see an ", "You see ", "Using one of ", "oz." },
                StringSplitOptions.RemoveEmptyEntries);

            var result = new List<ItemResultDTO>();

            foreach (var item in split)
            {
                var itemName = ItemNameFormatToSearch(item, _tibiaItems);
                if (String.IsNullOrEmpty(itemName))
                    continue;
                
                var itemFound = GetItemFromDatabase(itemName, _tibiaItems);
                if (itemFound == null)
                    continue;

                var itemResult = GetItemResult(itemFound, item);

                // Add a new item result
                if (result.All(x => x.Item.Name != itemFound.Name))
                {
                    result.Add(itemResult);
                }
                // Update a item quantity
                else
                {
                    result.First(x => x.Item.Name == itemFound.Name).Quantity += itemResult.Quantity;
                }
            }

            // if it does not find any item, returns null
            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Based a list of items result and a list of members (with each member spent money)
        /// Split all items to each member in a way to each member reicive the same profit or exp
        /// 
        /// Example 1: memberA wasted 5k in supplies, memberB wasted 2k in supplies, total value loot was 10k
        /// In this case, the loot value needs to pay each member and, after split only the profit.
        /// memberA will reicive 5k + 1.5k profit, while memberB will reicive 2k + 1.5k profit
        /// 
        /// Example 2: memberA wasted 5k in supplies, memberB wasted 2k in supplies, total value loot was 5k only
        /// In this case, the loot value is lower that supplies wasted, so the split need to balance the waste
        /// memberA will reicive 4k (total waste = 1k), while memberB will reicive 1k (total waste = 1k)
        /// 
        /// Example 3: memberA wasted 5k in supplies, memberB wasted 2k in supplies, total value loot was 1k only
        /// In this case, the loot value is VERY FUCKING low and impossible to balance the waste. 
        /// So the member who wasted more in supplies will reicive the loot just to pay the most expansive waste
        /// memberA will reicive 1k (total waste = 4k), while memberB will reicive nothing (total waste = 2k)
        /// </summary>
        /// <param name="itemsResult">Item list with value and quantity updated</param>
        /// <param name="members">List of members and updated wasted value</param>
        /// <returns>aAn object with a list of items that each member will reicive</returns>
        public GroupCalculatorResultDTO SplitItemsToMembers(List<ItemResultDTO> itemsResult, List<MemberDTO> members)
        {
            var model = new GroupCalculatorResultDTO
            {
                Members = new List<MemberDTO>(members),
                ItemsUnsplited = new List<ItemResultDTO>()
            };

            // Money data
            var totalGold = itemsResult.Select(x => x.Value != null ? x.Value.Value * x.Quantity : 0).Sum();
            var totalWaste = model.Members.Select(x => x.Waste).Sum();
            var totalProfit = totalGold - totalWaste;

            itemsResult = itemsResult.OrderByDescending(x => x.Value).ToList();

            // How much each member needs to reicive
            model.Members.ForEach(x =>
            {
                x.Items = new List<ItemResultDTO>();
                x.MoneyRecived = totalProfit > 0
                                    ? totalProfit / model.Members.Count + x.Waste
                                    : x.Waste - (totalWaste - totalGold) / model.Members.Count;
            });

            // Split items by values
            foreach (var member in model.Members)
            {
                // Each member recive item till gold limit (totalMemberGold) is reached
                foreach (var itemResult in itemsResult)
                {
                    var value = itemResult.Value.HasValue ? itemResult.Value.Value : 0;
                    var goldWithNewItem = value + member.Items.Select(x => x.Value != null ? x.Value.Value * x.Quantity : 0).Sum();

                    if (goldWithNewItem > member.MoneyRecived) continue;

                    var quantityList = new List<int> { 1, 2, 5, 10, 20, itemResult.Quantity };
                    var quantityCount = quantityList.Count - 1; // -1 because "quantityCount is an list index

                    do
                    {
                        // This split list using quantityList was designed this way to improve split performance
                        if (Convert.ToInt32(itemResult.Quantity / quantityList[quantityCount]) > 0 &&
                            Convert.ToInt32(itemResult.Quantity / quantityList[quantityCount]) *
                            itemResult.Value +
                            member.Items.Select(x => x.Value != null ? x.Value.Value * x.Quantity : 0).Sum()
                            <= member.MoneyRecived)
                        {
                            if (member.Items.All(x => x.Item.Name != itemResult.Item.Name))
                                member.Items.Add(new ItemResultDTO(itemResult.Item)
                                {
                                    Quantity = Convert.ToInt32(itemResult.Quantity / quantityList[quantityCount]),
                                    Value = itemResult.Value
                                });
                            else
                                member.Items.First(x => x.Item.Name == itemResult.Item.Name).Quantity
                                    += Convert.ToInt32(itemResult.Quantity / quantityList[quantityCount]);

                            itemResult.Quantity
                                -= Convert.ToInt32(itemResult.Quantity / quantityList[quantityCount]);
                        }
                        else
                        {
                            quantityCount--;
                        }
                    } while (itemResult.Quantity > 0 &&
                             quantityCount >= 0 &&
                             itemResult.Value + member.Items.Select(x => x.Value * x.Quantity).Sum() <= member.MoneyRecived);
                }

                // Remove used items where the quantity was totally used
                itemsResult.RemoveAll(x => x.Quantity == 0);
            }

            // Items impossible to split.
            if (itemsResult.Count > 0)
                model.ItemsUnsplited = itemsResult;

            return model;
        }

        #region Helpers

        /// <summary>
        /// All the logic that allows the item name displayed on look be found on database.
        /// It is necessary in case of equiped rings, plural words, and other specific cases
        /// </summary>
        /// <param name="unformatedItemName">string name that supposed to contaisn a item name, but can contains to random characters</param>
        /// <param name="tibiaItems">item database</param>
        /// <returns>formated tibia item name</returns>
        private static string ItemNameFormatToSearch(string unformatedItemName, List<Item> tibiaItems)
        {
            // Select only letters and space character. 
            // Does not continue if string does not have at least 3 characters lentgh
            var onlyLettersItem = Regex.Match(unformatedItemName, @"(?i)[a-z ']+").Value.Trim();
            if (onlyLettersItem.Length < 3)
            {
                return String.Empty;
            }

            // Rules for rings
            if (!tibiaItems.Any(x => x.Name.ToLower() == onlyLettersItem.ToLower()))
            {
                if (onlyLettersItem.Length > 14 &&
                    onlyLettersItem.Substring(onlyLettersItem.Length - 14) == " that is brand")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 14, 14);
                }
                else if (onlyLettersItem.Length > 19 &&
                            onlyLettersItem.Substring(onlyLettersItem.Length - 19) == " that will expire in")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 19, 19);
                }
            }

            // Rules for plural words only at the end of the string
            if (!tibiaItems.Any(x => x.Name.ToLower() == onlyLettersItem.ToLower()))
            {
                if (onlyLettersItem.Substring(onlyLettersItem.Length - 3) == "ies")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 3, 3);
                }
                else if (onlyLettersItem.Substring(onlyLettersItem.Length - 3) == "ves")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 3, 3);
                }
                else if (onlyLettersItem.Substring(onlyLettersItem.Length - 2) == "es")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 2, 2);
                }
                else if (onlyLettersItem.Substring(onlyLettersItem.Length - 1) == "s")
                {
                    onlyLettersItem = onlyLettersItem.Remove(onlyLettersItem.Length - 1, 1);
                }
            }

            // Rules for words that ends with char "E" in middle of the name
            if (!tibiaItems.Any(x => x.Name.ToLower() == onlyLettersItem.ToLower()))
            {
                var provisoryItemName = onlyLettersItem;
                provisoryItemName = provisoryItemName.Replace("es ", "e ");

                // if find, the provisoty name becomes the official
                if (tibiaItems.Any(x => x.Name.ToLower().Contains(provisoryItemName.ToLower())))
                {
                    onlyLettersItem = provisoryItemName;
                }
            }

            // Tratamento de item em plural para início de palavra
            if (!tibiaItems.Any(x => x.Name.ToLower() == onlyLettersItem.ToLower()))
            {
                onlyLettersItem = onlyLettersItem.Replace("ies ", "y ");
                onlyLettersItem = onlyLettersItem.Replace("ves ", "f ");
                onlyLettersItem = onlyLettersItem.Replace("es ", " ");
                onlyLettersItem = onlyLettersItem.Replace("s ", " ");
            }

            return onlyLettersItem;
        }

        /// <summary>
        /// After changing itemName to be able to find it in the database,
        /// Do the search by the exact name or if a iten in the database contains the string itemName
        /// </summary>
        /// <param name="itemName">formated tibia item name</param>
        /// <param name="tibiaItems">item database</param>
        /// <returns>An item object based the param itemName. Returns null if didn't find any item</returns>
        private static Item GetItemFromDatabase(string itemName, List<Item> tibiaItems)
        {            
            // When the magic happens.
            // LOL! todo: make it more readable
            return tibiaItems.Any(x => x.Name.ToLower().Trim() == itemName.ToLower().Trim())
                    ? tibiaItems.OrderBy(x => x.Name).FirstOrDefault(
                        x => x.Name.ToLower().Trim() == itemName.ToLower().Trim())
                    : tibiaItems.OrderByDescending(x => x.Name).Any(
                        x => x.Name.ToLower().Trim().StartsWith(itemName.ToLower().Trim()))
                            ? tibiaItems.OrderByDescending(x => x.Name).FirstOrDefault(
                                x => x.Name.ToLower().Trim().StartsWith(itemName.ToLower().Trim()))
                            : tibiaItems.OrderBy(x => x.Name).FirstOrDefault(
                                x => x.Name.ToLower().Trim().Contains(itemName.ToLower().Trim()));
        }

        /// <summary>
        /// Returns an ItemResult and calculates the exact quantity of itens stacked 
        /// The logic looks the unformated item name and check if the quantity is displayed
        /// If not, do a operation using item weight and base item weight (weight of only one item)
        /// </summary>
        /// <param name="item">The item entity</param>
        /// <param name="unformatedItemName">Item string before to be formatted. It allow us to obtain the quantity</param>
        /// <returns>Item result with the specified quantity and value</returns>
        private static ItemResultDTO GetItemResult(Item item, string unformatedItemName)
        {
            var itemResult = new ItemResultDTO(item);

            // Items that does NOT need to check the weight to calculate
            if (!item.NeedWeightInCalc)
            {
                try
                {
                    itemResult.Quantity = Convert.ToInt32(Regex.Match(unformatedItemName.Substring(0, 5), @"[0-9]+").Value.Trim());
                }
                catch
                {
                    itemResult.Quantity = 1;
                }
            }
            // Items that NEED to check the weight to calculate
            else
            {
                var totalWeight = Convert.ToDouble(Regex.Match(unformatedItemName, @"[0-9].+").Value.TrimEnd(), CultureInfo.InvariantCulture);
                var weightPerItem = item.Weight.HasValue ? item.Weight.Value : totalWeight;

                itemResult.Quantity = Convert.ToInt32(totalWeight / weightPerItem);
            }

            return itemResult;
        }

        #endregion
    }
}
