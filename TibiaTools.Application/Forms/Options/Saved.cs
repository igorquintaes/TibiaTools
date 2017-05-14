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

namespace TibiaTools.Application.Forms.Options
{
    public partial class Saved : Form
    {
        public static Saved _instance;

        public Saved()
        {
            InitializeComponent();
            LoadTexts();
            ManageEvents();
        }
        public static Saved GetInstance()
        {
            if (_instance == null) _instance = new Saved();
            return _instance;
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            this.closeBtn.Text = Language.Close;
            this.Text = Language.Saved;
            this.savedSuccefull.Text = Language.SuccefullSavedConfig;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Saved_FormClosing(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }
}
