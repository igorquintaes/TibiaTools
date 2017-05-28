using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TibiaTools.Domain.Enums;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    [Serializable()]
    public class CharacterDTO
    {
        private List<AchievementDTO> _achievements { get; set; }
        public ICollection<AchievementDTO> Achievements { get { return (_achievements ?? (_achievements = new List<AchievementDTO>())); } }

        private List<CharacterDTO> _characters { get; set; }
        public ICollection<CharacterDTO> Characters { get { return (_characters ?? (_characters = new List<CharacterDTO>())); } }

        private List<CharacterDeathDTO> _deaths { get; set; }
        public ICollection<CharacterDeathDTO> Deaths { get { return (_deaths ?? (_deaths = new List<CharacterDeathDTO>())); } }

        public AccountStatus AccountStatus { get; set; }
        public int AchievementPoints { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public GuildMembershipDTO GuildMembership { get; set; }
        public DateTime LastLogin { get; set; }
        public int Level { get; set; }
        public string LoyalityTitle { get; set; }
        public CharacterDTO MarriedTo { get; set; }
        public string Name { get; set; }
        public string Residence { get; set; }
        public Sex Sex { get; set; }
        public Vocation Vocation { get; set; }
        public string World { get; set; }
        public bool IsOnline { get; set; }

        public CharacterDTO()
        {
            _achievements = new List<AchievementDTO>();
            _characters = new List<CharacterDTO>();
            _deaths = new List<CharacterDeathDTO>();
        }

        internal void AddAchievement(AchievementDTO achievement)
        {
            if (achievement == null) throw new ArgumentNullException("achievement");

            _achievements.Add(achievement);
        }
        internal void AddAchievement(List<AchievementDTO> achievements)
        {
            if (achievements == null || achievements.Any(x => x == null))
                throw new ArgumentNullException("achievements");

            _achievements.AddRange(achievements);
        }

        internal void AddDeath(CharacterDeathDTO death)
        {
            if (death == null)
                throw new ArgumentNullException("death");

            _deaths.Add(death);
        }
        internal void AddDeath(List<CharacterDeathDTO> deaths)
        {
            if (deaths == null || deaths.Any(x => x == null))
                throw new ArgumentNullException("deaths");

            _deaths.AddRange(deaths);
        }
    }
}
