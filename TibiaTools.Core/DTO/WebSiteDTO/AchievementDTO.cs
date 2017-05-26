using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TibiaTools.Core.DTO.WebSiteDTO
{
    public class AchievementDTO
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public bool IsSecret { get; set; }
    }
}
