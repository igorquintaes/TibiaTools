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
using TibiaTools.Application.Helpers.Contracts;
using TibiaTools.Application.ProjectSettings;
using TibiaTools.Application.Resources;
using TibiaTools.Application.Resources.Database;
using TibiaTools.Core.DTO;

namespace TibiaTools.Application.Forms.LootSplitter
{
    public partial class LootSplitterResult : Form
    {
        private readonly IPathHelper _pathHelper;

        public LootSplitterResult(IPathHelper pathHelper)
        {
            _pathHelper = pathHelper;
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
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            this.closeBtn.Text = resources.GetString("Close");
            this.Text = resources.GetString("LootSplitterResult");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
