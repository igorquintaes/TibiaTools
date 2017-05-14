using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Core.DTO;

namespace TibiaTools.Core.Services.Contracts
{
    public interface IGroupCalculatorService
    {
        /// <summary>
        /// Returns an IEnumerable of itens after check a text with all loot information.
        /// We expect a look item message as text, not monster drop messages.
        /// This way, is needed less messages and there is no worry if you drop log clean or be full.
        /// </summary>
        /// <param name="textInput">Text with all look messages</param>
        /// <returns>List of items of what system could recognize</returns>
        IEnumerable<ItemResultDTO> ResolveItemList(string textInput);

        /// <summary>
        /// Check if the input is valid as player quantity.
        /// It only can be numbers and non-negative values.
        /// </summary>
        /// <param name="textQuantity">User imput about players quantity</param>
        /// <returns>Players quantity as int. 0 will be returned if the input is not valid</returns>
        int ObtainPlayersQuantity(string textQuantity);

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
        GroupCalculatorResultDTO SplitItemsToMembers(List<ItemResultDTO> itemsResult, List<MemberDTO> members);
    }
}
