using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms.Help
{
    public partial class HowToUse : Form
    {
        public HowToUse()
        {
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
            this.closeBtn.Text = Language.Close;
            this.labelHowToUse.Text = Language.HowToUseReadMe;
            this.Text = Language.HowToUse;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var target = e.Link.LinkData as string;
            System.Diagnostics.Process.Start(target);
        }
    }
}
