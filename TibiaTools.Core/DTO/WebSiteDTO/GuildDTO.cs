using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    [Serializable()]
    public class GuildDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Founded { get; set; }
        public GuildHouseDTO GuildHouse { get; set; }
        public string ImgUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsOpenedForApplications { get; set; }

        private List<GuildMembershipDTO> _members;
        public ICollection<GuildMembershipDTO> Members
        {
            get
            {
                return _members ?? (_members = new List<GuildMembershipDTO>());
            }
        }

        private List<GuildInvitedCharacterDTO> _invitedCharacters;
        public ICollection<GuildInvitedCharacterDTO> InvitedCharacters
        {
            get
            {
                return _invitedCharacters ?? (_invitedCharacters = new List<GuildInvitedCharacterDTO>());

            }
        }
    }
}
