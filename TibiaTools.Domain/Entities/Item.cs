using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Entities.Abstractions;

namespace TibiaTools.Domain.Entities
{
    public class Item : EntityBase<int>
    {
        /// <summary>
        /// Item display name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If the item can be carry and him weight 
        /// There is a item with 0.00 oz - String of Melding, so zero value does not count
        /// </summary>
        public double? Weight { get; set; }
        
        /// <summary>
        /// Some itens does not display the quantity qhen you loot at him. 
        /// In this case, is necessary check the weight and make a division to know the item quantity
        /// Ham is an example: You see ham.
        /// </summary>
        public bool NeedWeightInCalc { get; set; }

        /// <summary>
        /// A base sell value for the item, if it is sellable in some NPC.
        /// Please, ignore troll NPCs buyers like H.L. when fill the database.
        /// </summary>
        public int? Value { get; set; }
    }
}
