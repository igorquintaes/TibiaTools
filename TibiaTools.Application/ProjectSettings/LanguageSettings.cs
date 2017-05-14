using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TibiaTools.Application.ProjectSettings
{
    public delegate void LanguageChangedEventHandler();

    public static class LanguageSettings
    {
        private static CultureInfo _currentCulture;
        public static CultureInfo CurrentCulture { get { return _currentCulture; } }

        public static event LanguageChangedEventHandler LanguageChanged;

        public static object[] Languages
        {
            get
            {
                return new[] {
                    new { Text = "English", Value = "en-US" },
                    new { Text = "Português", Value = "pt-BR" }
                };
            }
        }

        public static void ChangeLanguage(string culture)
        {
            if (_currentCulture != null &&
                _currentCulture.Name == culture) return;

            _currentCulture = CultureInfo.GetCultureInfo(culture);

            Thread.CurrentThread.CurrentUICulture = _currentCulture;
            Thread.CurrentThread.CurrentCulture = _currentCulture;

            LanguageChanged?.Invoke();
        }

        public static void Initialize()
        {
            ChangeLanguage(UserSettings.RecoverLanguage());
        }
    }
}
