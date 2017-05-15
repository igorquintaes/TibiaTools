using System;
using System.Collections.Generic;
using TibiaTools.Application.Resources;
using TibiaTools.Core.DTO;

namespace TibiaTools.Application.Forms.LootSplitter
{
    partial class LootSplitterStepTwo
    {
        private List<ItemResultDTO> UpdatedItemList;
        private List<MemberDTO> UpdatedMemberList;

        private System.Windows.Forms.Button continueBtn;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(List<ItemResultDTO> listItems, int players)
        {
            UpdatedItemList = new List<ItemResultDTO>();

            for (var i = 0; i < listItems.Count; i++)
            {
                var textBoxItem = new System.Windows.Forms.TextBox();
                var labelItem = new System.Windows.Forms.Label();
                this.SuspendLayout();

                // todo: add item image

                textBoxItem.Location = new System.Drawing.Point(12, (i * 50) + 30);
                textBoxItem.Name = listItems[i].Item.Name.Replace(" ", "");
                textBoxItem.Size = new System.Drawing.Size(100, 20);
                textBoxItem.TabIndex = 0;
                if (listItems[i].Value.HasValue && listItems[i].Value.Value != 0)
                    textBoxItem.Text = listItems[i].Value.Value.ToString();

                UpdatedItemList.Add(listItems[i]);

                labelItem.AutoSize = true;
                labelItem.Location = new System.Drawing.Point(9, (i * 50) + 14);
                labelItem.Name = i.ToString() + "in";
                labelItem.Size = new System.Drawing.Size(30, 13);
                labelItem.TabIndex = 1;
                labelItem.Text = String.Format(Language.ValueOfItem, listItems[i].Item.Name);

                this.Controls.Add(textBoxItem);
                this.Controls.Add(labelItem);

                this.ResumeLayout(false);
            }

            UpdatedMemberList = new List<MemberDTO>();
            var countplayers = 0;
            while (players > countplayers)
            {
                var member = new MemberDTO();
                UpdatedMemberList.Add(member);

                var textBoxPlayer = new System.Windows.Forms.TextBox();
                var labelPlayer = new System.Windows.Forms.Label();
                this.SuspendLayout();

                textBoxPlayer.Location = new System.Drawing.Point(253, (countplayers * 50) + 30);
                textBoxPlayer.Name = "member" + countplayers.ToString();
                textBoxPlayer.Size = new System.Drawing.Size(100, 20);
                textBoxPlayer.TabIndex = 3;

                labelPlayer.AutoSize = true;
                labelPlayer.Location = new System.Drawing.Point(250, (countplayers * 50) + 14);
                labelPlayer.Name = countplayers.ToString() + "lp";
                labelPlayer.Size = new System.Drawing.Size(35, 13);
                labelPlayer.TabIndex = 2;
                labelPlayer.Text = String.Format(Language.MoneySpentPlayerNun, (countplayers + 1).ToString());

                this.Controls.Add(textBoxPlayer);
                this.Controls.Add(labelPlayer);

                this.ResumeLayout(false);
                countplayers++;
            }

            continueBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();

            var higherYSize = Math.Max(countplayers + 1, listItems.Count); //+1 button, same column
            var YScreenSize = Math.Min(higherYSize * 50 + 15, 600);

            continueBtn.Location = new System.Drawing.Point(253, (countplayers * 50) + 28);
            continueBtn.Name = "continueBtn";
            continueBtn.Size = new System.Drawing.Size(75, 23);
            continueBtn.TabIndex = 0;
            continueBtn.Text = Language.Continue;
            continueBtn.UseVisualStyleBackColor = true;
            continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            this.Controls.Add(continueBtn);

            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(410, YScreenSize);
            this.Name = "Form2";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
