using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.Forms.Help;
using TibiaTools.Application.Forms.LootSplitter;
using TibiaTools.Application.Forms.Options;
using TibiaTools.Application.Forms.PlayersDeaths;
using TibiaTools.Application.Helpers.Contracts;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms
{
    public partial class Main : Form
    {
        private readonly IFormOpener _formOpener;

        public Main(IFormOpener formOpener)
        {
            _formOpener = formOpener;

            LanguageSettings.Initialize();

            InitializeComponent();
            LoadTexts();
            ManageEvents();
        }

        private void LoadTexts()
        {
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.helpToolStripMenuItem.Text = resources.GetString("Help");
            this.aboutToolStripMenuItem.Text = resources.GetString("About");
            this.howToUseToolStripMenuItem.Text = resources.GetString("HowToUse");
            this.optionsToolStripMenuItem.Text = resources.GetString("Options");
            this.labelChooseOption.Text = resources.GetString("ChooseOneBellowTools");
            this.buttonLootSplitter.Text = resources.GetString("ButtonLootSplitter");
            this.buttonPlayersDeaths.Text = resources.GetString("ButtonLastPlayersDeath");
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void lootSplitterBtn_Click(object sender, EventArgs e)
        {
             _formOpener.ShowModelessForm<LootSplitterStepOne>();
        }

        private void lastDeathsBtn_Click(object sender, EventArgs e)
        {
            _formOpener.ShowModelessForm<LastPlayersDeaths>();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formOpener.ShowModelessForm<Configuration>();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formOpener.ShowModelessForm<About>();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formOpener.ShowModelessForm<HowToUse>();
        }
    }
}
