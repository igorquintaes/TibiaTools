using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.Helpers.Contracts;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms.Options
{
    public partial class Configuration : Form
    {
        private readonly IFormOpener _formOpener;

        public Configuration(IFormOpener formOpener)
        {
            _formOpener = formOpener;

            InitializeComponent();
            LoadTexts();
            ManageLanguageList();
            ManageEvents();
        }

        private void LoadTexts()
        {
            this.language.Text = Language.LanguageStr;
            this.saveConfiguration.Text = Language.Save;
            this.cancelButton.Text = Language.Cancel;
            this.Text = Language.Settings;
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var language = (languageBox.SelectedItem as dynamic).Value.ToString();
            UserSettings.RememberLanguage(language);
            LanguageSettings.ChangeLanguage(language);

            _formOpener.ShowModelessForm<Saved>();
            this.Close();
        }

        private void ManageLanguageList()
        {

            this.languageBox.DataSource = LanguageSettings.Languages;
            this.languageBox.SelectedIndex = 0;

            for (var i = 0; i < LanguageSettings.Languages.Count(); i++)
            {
                if (LanguageSettings.CurrentCulture.Name == (LanguageSettings.Languages[i] as dynamic).Value.ToString())
                {
                    this.languageBox.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
