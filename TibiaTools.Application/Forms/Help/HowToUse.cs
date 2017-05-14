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
        private static HowToUse _instance;

        public HowToUse()
        {
            InitializeComponent();
            LoadTexts();
            ManageEvents();
        }

        public static HowToUse GetInstance()
        {
            if (_instance == null) _instance = new HowToUse();
            return _instance;
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            this.closeBtn.Text = Language.Close;
            this.Text = Language.HowToUse;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HowToUse_FormClosing(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }
}
