using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Database.Repositories
{
    public class ItemRepository
    {
        public List<Item> GetAll()
        {
            var allItems = new List<Item>();
            var path = Environment.CurrentDirectory + "\\ItemDatabase.csv";

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                var lineSpl = line.Split(',');
                var item = new Item();
                item.Id = Convert.ToInt32(lineSpl[0]);
                item.Name = lineSpl[1];
                item.Value = String.IsNullOrEmpty(lineSpl[2]) || lineSpl[2].ToUpper() == "NULL" ? (int?)null : Convert.ToInt32(lineSpl[2], CultureInfo.InvariantCulture);
                item.Weight = String.IsNullOrEmpty(lineSpl[3]) || lineSpl[3].ToUpper() == "NULL" ? (double?)null : Convert.ToDouble(lineSpl[3], CultureInfo.InvariantCulture);
                item.NeedWeightInCalc = String.IsNullOrEmpty(lineSpl[3]) || lineSpl[3].ToUpper() == "NULL" ? false : true;

                allItems.Add(item);
            }

            file.Close();

            return allItems; 
        }
    }
}
