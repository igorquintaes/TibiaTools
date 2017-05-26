using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    public class GuildMembershipDTO
    {
        public CharacterDTO Character { get; set; }
        public GuildDTO Guild { get; set; }
        public bool IsOnline { get; set; }
        public DateTime JoinedDate { get; set; }
        public GuildRankingDTO Ranking { get; set; }
    }
}
