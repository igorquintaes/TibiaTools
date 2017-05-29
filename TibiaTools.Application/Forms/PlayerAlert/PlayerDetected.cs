using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TibiaTools.Application.Objects;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Core.DTO.WebSiteDTO;

namespace TibiaTools.Application.Forms.PlayerAlert
{
    public partial class PlayerDetected : Form
    {
        public PlayerDetected()
        {
        }

        public void InitializeForm(CharacterDTO character)
        {
            InitializeComponent();
            LoadTexts();
            ManageEvents();

            CreatePlayerDetectedAlert(character);
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));
            
            this.closeBtn.Text = resources.GetString("Close");
            this.Text = resources.GetString("PlayerAlert");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreatePlayerDetectedAlert(CharacterDTO character)
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            if (character.IsOnline)
            {
                this.playerDetectedLabel.Text = String.Format(
                    resources.GetString("PlayerDetectedOnline"),
                    character.Name);
            }
            else
            {
                this.playerDetectedLabel.Text = String.Format(
                    resources.GetString("PlayerDetectedOffline"),
                    character.Name);
            }
            
            this.Show();
            FlashWindow.Flash(this);
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
