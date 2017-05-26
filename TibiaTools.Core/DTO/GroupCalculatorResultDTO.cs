using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Domain.Enums;

namespace TibiaTools.Core.DTO
{
    public class GroupCalculatorResultDTO
    {
        public GroupCalculatorResultDTO()
        {
            Members = new List<MemberDTO>();
            ItemsUnsplited = new List<ItemResultDTO>();
        }

        public List<MemberDTO> Members { get; set; }

        public List<ItemResultDTO> ItemsUnsplited { get; set; }

        public TotalBalance TotalBalance
        {
            get
            {
                if (TotalBalanceValue > 0)
                    return TotalBalance.Profit;

                if (TotalBalanceValue < 0)
                    return TotalBalance.Waste;

                return TotalBalance.Paid;
            }
        }

        public int TotalValue
        {
            get
            {
                return Members
                    .Select(x => x.Items
                        .Select(y => y.Value * y.Quantity)
                        .Sum())
                    .Sum().Value 
                    + ItemsUnsplited
                        .Select(y => y.Quantity * y.Value)
                        .Sum().Value;
            }
        }

        public int TotalWaste
        {
            get
            {
                return Members
                    .Select(x => x.Waste)
                    .Sum();
            }
        }

        public int TotalBalanceValue
        {
            get
            {
                return (Members
                    .Select(x => x.Items
                        .Select(y => y.Value * y.Quantity).Sum())
                        .Sum()
                        + ItemsUnsplited
                            .Select(y => y.Quantity * y.Value).Sum())
                    .Value
                    - Members.Select(x => x.Waste).Sum();
            }
        }

        public int MemberBalanceValue
        {
            get
            {
                return TotalBalanceValue / Members.Count;
            }
        }
    }
}
