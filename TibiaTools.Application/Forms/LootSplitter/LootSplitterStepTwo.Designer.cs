using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TibiaTools.Application.Resources;
using TibiaTools.Application.Resources.Database;
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
            var resources = new SingleAssemblyResourceManager(typeof(Language));

            for (var i = 0; i < listItems.Count; i++)
            {
                var numericBoxItem = new System.Windows.Forms.NumericUpDown();
                var labelItem = new System.Windows.Forms.Label();
                var itemImage = new System.Windows.Forms.PictureBox();
                this.SuspendLayout();

                //
                // Item Image
                //
                itemImage.ImageLocation = _pathHelper.GetItemImagePath(listItems[i]);
                itemImage.SizeMode = PictureBoxSizeMode.AutoSize;
                itemImage.Location = new System.Drawing.Point(8, (i * 50) + 14);

                //
                // Numeric Up Down Item Value
                //
                numericBoxItem.Minimum = 0;
                numericBoxItem.Maximum = int.MaxValue;
                numericBoxItem.Location = new System.Drawing.Point(53, (i * 50) + 30);
                numericBoxItem.Name = listItems[i].Item.Name.Replace(" ", "");
                numericBoxItem.Size = new System.Drawing.Size(100, 20);
                numericBoxItem.TabIndex = 0;
                if (listItems[i].Value.HasValue && listItems[i].Value.Value != 0)
                    numericBoxItem.Text = listItems[i].Value.Value.ToString();

                UpdatedItemList.Add(listItems[i]);

                // 
                // label Item
                //
                labelItem.AutoSize = true;
                labelItem.Location = new System.Drawing.Point(50, (i * 50) + 14);
                labelItem.Name = i.ToString() + "in";
                labelItem.Size = new System.Drawing.Size(30, 13);
                labelItem.TabIndex = 1;
                labelItem.Text = String.Format(resources.GetString("ValueOfItem"), listItems[i].Item.Name);

                this.Controls.Add(itemImage);
                this.Controls.Add(numericBoxItem);
                this.Controls.Add(labelItem);

                this.ResumeLayout(false);
            }

            UpdatedMemberList = new List<MemberDTO>();
            var countplayers = 0;
            while (players > countplayers)
            {
                var member = new MemberDTO();
                UpdatedMemberList.Add(member);

                var numericBoxItem = new System.Windows.Forms.NumericUpDown();
                var labelPlayer = new System.Windows.Forms.Label();
                this.SuspendLayout();
                
                numericBoxItem.Minimum = 0;
                numericBoxItem.Maximum = int.MaxValue;
                numericBoxItem.Location = new System.Drawing.Point(303, (countplayers * 50) + 30);
                numericBoxItem.Name = "member" + countplayers.ToString();
                numericBoxItem.Size = new System.Drawing.Size(100, 20);
                numericBoxItem.TabIndex = 3;

                labelPlayer.AutoSize = true;
                labelPlayer.Location = new System.Drawing.Point(300, (countplayers * 50) + 14);
                labelPlayer.Name = countplayers.ToString() + "lp";
                labelPlayer.Size = new System.Drawing.Size(35, 13);
                labelPlayer.TabIndex = 2;
                labelPlayer.Text = String.Format(resources.GetString("MoneySpentPlayerNun"), (countplayers + 1).ToString());

                this.Controls.Add(numericBoxItem);
                this.Controls.Add(labelPlayer);

                this.ResumeLayout(false);
                countplayers++;
            }

            continueBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();

            var higherYSize = Math.Max(countplayers + 1, listItems.Count); //+1 button, same column
            var YScreenSize = Math.Min(higherYSize * 50 + 15, 600);

            continueBtn.Location = new System.Drawing.Point(303, (countplayers * 50) + 28);
            continueBtn.Name = "continueBtn";
            continueBtn.Size = new System.Drawing.Size(75, 23);
            continueBtn.TabIndex = 0;
            continueBtn.Text = resources.GetString("Continue");
            continueBtn.UseVisualStyleBackColor = true;
            continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            this.Controls.Add(continueBtn);

            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(460, YScreenSize);
            this.Name = "Form2";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
