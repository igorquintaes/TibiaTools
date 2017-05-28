using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    [Serializable()]
    public class GuildRankingDTO
    {
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
