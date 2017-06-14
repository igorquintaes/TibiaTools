using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TibiaTools.Domain.Entities.Abstractions;
using TibiaTools.Domain.Enums;

namespace TibiaTools.Domain.Entities
{

    public class TibiaBoss : EntityBase<int>
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int RespawnNumber { get; set; }
        public int LastSeen { get; set; }
        public int ExpectedIn { get; set; }
        public BossType Type { get; set; }
        public BossChance Chance { get; set; }
    }
}
