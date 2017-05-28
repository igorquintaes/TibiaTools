using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TibiaTools.Domain.Enums
{
    public enum Vocation
    {
        None = 0,
        Sorcerer = 1,
        Druid = 2,
        Knight = 3,
        Paladin = 4,
        MasterSorcerer = 5,
        ElderDruid = 6,
        EliteKnight = 7,
        RoyalPaladin = 8
    }

    public static class VocationExtension
    {
        public static string GetVocationName(this Vocation vocation)
        {
            return Regex.Replace(vocation.ToString(), "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}
