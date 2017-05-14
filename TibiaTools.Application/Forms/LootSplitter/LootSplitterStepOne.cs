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
using TibiaTools.Core.Services;
using TibiaTools.Core.Services.Contracts;

namespace TibiaTools.Application.Forms.LootSplitter
{
    public partial class LootSplitterStepOne : Form
    {
        private readonly IGroupCalculatorService _groupCalculatorService;
        private readonly IFormOpener _formOpener;
        
        public LootSplitterStepOne(
            IGroupCalculatorService groupCalculatorService,
            IFormOpener formOpener)
        {
            _groupCalculatorService = groupCalculatorService;
            _formOpener = formOpener;

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
            this.cancelBtn.Text = Language.Cancel;
            this.continueBtn.Text = Language.Continue;
            this.labelPlayerQuantity.Text = Language.InsertPlayerQuantity;
            this.labelInsertLootText.Text = Language.InsertPlayerLoot;
            this.Text = Language.LootSplitterStepOne;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            var playerQuantity = Convert.ToInt32(boxPlayerQuantity.Value);
            if (playerQuantity < boxPlayerQuantity.Minimum || 
                playerQuantity > boxPlayerQuantity.Maximum)
            {
                return;
                // todo: show error
            }

            var itemResult = _groupCalculatorService.ResolveItemList(textAreaLoot.Text);
            if (itemResult == null || !itemResult.Any())
            {
                return;
                // todo: show error
            }

            var formStepTwo = _formOpener.GetModelessForm<LootSplitterStepTwo>();
            formStepTwo.InitializeForm(itemResult.ToList(), playerQuantity);

            this.Close();
        }
    }
}
