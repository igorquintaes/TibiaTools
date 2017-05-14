using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaTools.Core.DTO
{
    public class MemberDTO
    {
        public MemberDTO()
        {
            Items = new List<ItemResultDTO>();
        }

        /// <summary>
        /// How much player spent hunting
        /// </summary>
        public int Waste { get; set; }

        /// <summary>
        /// How much total gold this player need to recive after the calc,
        /// Even if the money spent is larger than the total loot
        /// </summary>
        public int MoneyRecived { get; set; }

        /// <summary>
        /// List of itens this players need to recive to match MoneyRecived
        /// </summary>
        public List<ItemResultDTO> Items { get; set; }

        /// <summary>
        /// Part of items value, just if was not able to split some itens
        /// An example: if Player1 spent 1k and Player2 spent 2k, but they only drops a 3k item, 
        /// the item will not be splitted.
        /// In this case, the memebrs will reicive a message that item cant be splitted 
        /// and the recomendation is sell the item and each player recive the value of this variable
        /// </summary>
        public int? AditionalValue
        {
            get
            {
                if (this.MoneyRecived - (this.Items.Select(y => y.Value * y.Quantity).Sum() ?? 0) > 0)
                {
                    return this.MoneyRecived - (this.Items.Select(y => y.Value * y.Quantity).Sum() ?? 0);
                }

                return 0;
            }
        }
    }
}
