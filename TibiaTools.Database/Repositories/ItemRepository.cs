using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Contracts.Repositories;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Database.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public List<Item> GetAll()
        {
            var allItems = new List<Item>();
            var database = TibiaDatabase.ResourceManager.GetObject("ItemDatabase").ToString();
            
            foreach(var line in database.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            { 
                var lineSpl = line.Split(',');
                var item = new Item();
                item.Id = Convert.ToInt32(lineSpl[0]);
                item.Name = lineSpl[1];
                item.Value = String.IsNullOrEmpty(lineSpl[2]) || lineSpl[2].ToUpper() == "NULL" ? (int?)null : Convert.ToInt32(lineSpl[2], CultureInfo.InvariantCulture);
                item.Weight = String.IsNullOrEmpty(lineSpl[3]) || lineSpl[3].ToUpper() == "NULL" ? (double?)null : Convert.ToDouble(lineSpl[3], CultureInfo.InvariantCulture);
                item.NeedWeightInCalc = item.Weight == null ? false : true;

                allItems.Add(item);
            }

            return allItems; 
        }
    }
}
