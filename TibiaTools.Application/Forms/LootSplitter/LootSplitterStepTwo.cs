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
using TibiaTools.Core.DTO;
using TibiaTools.Core.Services.Contracts;

namespace TibiaTools.Application.Forms.LootSplitter
{
    public partial class LootSplitterStepTwo : Form
    {
        public int PlayerQuantity { get; set; }
        public IEnumerable<ItemResultDTO> ItemResult { get; set; }

        private readonly IGroupCalculatorService _groupCalculatorService;
        private readonly IFormOpener _formOpener;
        private readonly IPathHelper _pathHelper;

        public LootSplitterStepTwo(
            IGroupCalculatorService groupCalculatorService,
            IFormOpener formOpener,
            IPathHelper pathHelper)
        {
            _groupCalculatorService = groupCalculatorService;
            _formOpener = formOpener;
            _pathHelper = pathHelper;
        }

        public void InitializeForm(List<ItemResultDTO> itemResult, int playerQuantity)
        {
            InitializeComponent(itemResult, playerQuantity);
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
            this.continueBtn.Text = Language.Continue;
            this.Text = Language.LootSplitterStepTwo;
        }


        private void continueBtn_Click(object sender, EventArgs e)
        {
            var updatedItemList = GetUpdatedItemList();
            var updatedPlayerInfo = GetUpdatedMemberList();

            var resultData = _groupCalculatorService.SplitItemsToMembers(updatedItemList, updatedPlayerInfo);

            var resultForm = _formOpener.GetModelessForm<LootSplitterResult>();
            resultForm.InitializeForm(resultData);

            this.Close();
        }

        private List<ItemResultDTO> GetUpdatedItemList()
        {
            var newItemResultList = new List<ItemResultDTO>();

            foreach (var item in UpdatedItemList)
            {
                item.Value = Convert.ToInt32(((NumericUpDown)this.Controls.Find(item.Item.Name.Replace(" ", ""), true)[0]).Text);
                newItemResultList.Add(item);
            }

            return newItemResultList;
        }

        private List<MemberDTO> GetUpdatedMemberList()
        {
            var newMemberList = new List<MemberDTO>();

            var count = 0;
            foreach (var member in UpdatedMemberList)
            {
                member.Waste = Convert.ToInt32(((NumericUpDown)this.Controls.Find("member" + count, true)[0]).Text);
                newMemberList.Add(member);
                count++;
            }

            return newMemberList;
        }
    }
}
