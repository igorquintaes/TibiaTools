using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Application.Resources.Database;
using TibiaTools.Core.DTO;

namespace TibiaTools.Application.Forms.LootSplitter
{
    public partial class LootSplitterResult : Form
    {
        public LootSplitterResult()
        {
            // load and update _default image;
            if (String.IsNullOrEmpty(defaultImgPath))
            {
                var defaultImg = Images._default;
                defaultImgPath = Path.Combine(Path.GetTempPath(), "_default.png");

                if (File.Exists(defaultImgPath))
                    File.Delete(defaultImgPath);

                defaultImg.Save(defaultImgPath);
            }
        }

        public void InitializeForm(GroupCalculatorResultDTO resultData)
        {
            InitializeComponent(resultData);
            LoadTexts();
            ManageEvents();

            this.Show();
            this.BringToFront();
        }

        private void ManageEvents()
        {
            LanguageSettings.LanguageChanged += new LanguageChangedEventHandler(LoadTexts);
        }

        private void LoadTexts()
        {
            this.closeBtn.Text = Language.Close;
            this.Text = Language.LootSplitterResult;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
