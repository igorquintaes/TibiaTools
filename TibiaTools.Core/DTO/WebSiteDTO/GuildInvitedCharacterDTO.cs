using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    public class GuildInvitedCharacterDTO
    {
        public CharacterDTO Character { get; set; }
        public DateTime InvitationDate { get; set; }
    }
}
