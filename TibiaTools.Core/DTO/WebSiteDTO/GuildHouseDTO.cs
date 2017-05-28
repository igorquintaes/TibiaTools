using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    [Serializable()]
    public class GuildHouseDTO
    {
        public string Name { get; set; }
        public DateTime RentDate { get; set; }
    }
}
