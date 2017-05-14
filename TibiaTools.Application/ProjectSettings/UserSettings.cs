using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaTools.Application.Properties;

namespace TibiaTools.Application.ProjectSettings
{
    static class UserSettings
    {
        static readonly string[] supportedCultures = new string[] { "en-US", "pt-BR", };
        static readonly string defaultCulture = "en-US";
        
        internal static void RememberLanguage(string language)
        {
            if (String.IsNullOrEmpty(language) || CultureInfo.GetCultureInfo(language) == null || !supportedCultures.Contains(language))
                Settings.Default.Language = defaultCulture;
            else
                Settings.Default.Language = CultureInfo.GetCultureInfo(language).Name;

            Settings.Default.Save();
        }

        internal static string RecoverLanguage()
        {
            return String.IsNullOrEmpty(Settings.Default.Language)
                ? defaultCulture
                : Settings.Default.Language;
        }
    }
}
