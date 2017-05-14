using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaTools.Core.DTO
{
    public class GroupCalculatorResultDTO
    {
        public List<MemberDTO> Members { get; set; }

        public List<ItemResultDTO> ItemsUnsplited { get; set; }
    }
}
