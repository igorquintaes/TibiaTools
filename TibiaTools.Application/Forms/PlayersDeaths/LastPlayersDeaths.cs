using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Core.Services.Contracts;

namespace TibiaTools.Application.Forms.PlayersDeaths
{
    public partial class LastPlayersDeaths : Form
    {
        private readonly IWebSiteRequestService _requestService;

        public LastPlayersDeaths(IWebSiteRequestService requestService)
        {
            _requestService = requestService;

            InitializeComponent();
            LoadTexts();
            ManageEvents();
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.labelHowItWorks.Text = resources.GetString("HowItWorks");
            this.labelSelectWorld.Text = resources.GetString("SelectWorld");
            this.tableDeath.EmptyListMsg = resources.GetString("SelectWorldAndStart");
            this.ButtonSearch.Text = resources.GetString("Search");
            this.Text = resources.GetString("LastPlayersDeaths");
        }
    }
}
