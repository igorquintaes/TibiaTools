using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Entities;

namespace TibiaTools.Core.DTO
{
    public class ItemResultDTO
    {
        public ItemResultDTO(Item item)
        {
            Item = item;
            Value = item.Value;
        }

        /// <summary>
        /// Item result
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// Item unit value, based on user alteration
        /// todo: check if there is necessity of the value be nullable
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Quantity of this kind of item
        /// </summary>
        public int Quantity { get; set; }
    }
}
