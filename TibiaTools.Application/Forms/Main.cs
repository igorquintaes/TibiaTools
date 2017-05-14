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
using TibiaTools.Application.Forms.Options;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            LanguageSettings.Initialize();

            InitializeComponent();
            LoadTexts();
            ManageEvents();
        }

        private void LoadTexts()
        {
            this.helpToolStripMenuItem.Text = Language.Help;
            this.aboutToolStripMenuItem.Text = Language.About;
            this.howToUseToolStripMenuItem.Text = Language.HowToUse;
            this.optionsToolStripMenuItem.Text = Language.Options;
            this.labelChooseOption.Text = Language.ChooseOneBellowTools;
            this.buttonLootSplitter.Text = Language.ButtonLootSplitter;
            this.buttonPlayersDeaths.Text = Language.ButtonLastPlayersDeath;
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Configuration.GetInstance();
            if (!form.Visible)
                form.Show();
            else
                form.BringToFront();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = About.GetInstance();
            if (!form.Visible)
                form.Show();
            else
                form.BringToFront();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = HowToUse.GetInstance();
            if (!form.Visible)
                form.Show();
            else
                form.BringToFront();
        }
    }
}
