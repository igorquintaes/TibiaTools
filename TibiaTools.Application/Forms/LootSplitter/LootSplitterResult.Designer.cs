using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TibiaTools.Application.Resources;
using TibiaTools.Core.DTO;

namespace TibiaTools.Application.Forms.LootSplitter
{
    partial class LootSplitterResult
    {
        private System.ComponentModel.IContainer components = null;
        private int position = 0;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(GroupCalculatorResultDTO data)
        {
            string textHeader,
                   textIndividualProfit,
                   textTotalValueObtained,
                   textTotalWaste;

            var profit = (data.Members.Select(x => x.Items.Select(y => y.Value * y.Quantity).Sum()).Sum() + data.ItemsUnsplited.Select(y => y.Quantity * y.Value).Sum()) - data.Members.Select(x => x.Waste).Sum();
            if (profit > 0)
            {
                textHeader = String.Format(Language.TotalProfit, profit.ToString());
                textIndividualProfit = String.Format(Language.IndividualProfit, (profit / data.Members.Count).ToString());
            }
            else if (profit == 0)
            {

                textHeader = Language.HuntPaid;
                textIndividualProfit = string.Empty;
            }
            else
            {
                textHeader = String.Format(Language.TotalWaste, profit.ToString());
                textIndividualProfit = String.Format(Language.IndividualWaste, (profit / data.Members.Count).ToString());
            }

            textTotalValueObtained = String.Format(Language.TotalValueObtained, (data.Members.Select(x => x.Items.Select(y => y.Value * y.Quantity).Sum()).Sum() + data.ItemsUnsplited.Select(y => y.Quantity * y.Value).Sum()).ToString());
            textTotalWaste = String.Format(Language.TotalValueSpent, data.Members.Select(x => x.Waste).Sum().ToString());
            
            var labelItem = new Label();
            this.SuspendLayout();

            labelItem.AutoSize = true;
            labelItem.Location = new Point(9, position + 14);
            position += 60;
            labelItem.Name = "Status";
            labelItem.Size = new Size(30, 13);
            labelItem.TabIndex = 1;
            labelItem.Text = textHeader +
                    "\r\n" + textIndividualProfit +
                    "\r\n" + textTotalValueObtained +
                    "\r\n" + textTotalWaste;

            this.Controls.Add(labelItem);

            foreach (var member in data.Members)
            {
                var table = new DataGridView();
                this.Controls.Add(table);

                table.ColumnCount = 3; // todo: implement image. It will incrase to 4

                table.Anchor = ((System.Windows.Forms.AnchorStyles)((((
                    System.Windows.Forms.AnchorStyles.Top
                  | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));

                table.TabIndex = 0;
                table.Name = "member" + position;
                table.Location = new Point(9, position + 20);
                table.AutoSize = false;
                position += 20;

                //table.Columns[0].Name = "Imagem";
                table.Columns[0].Name = Language.Name;
                table.Columns[1].Name = Language.Quantity;
                table.Columns[2].Name = Language.TotalValue;

                table.Columns[0].DisplayIndex = 0;
                table.Columns[1].DisplayIndex = 1;
                table.Columns[2].DisplayIndex = 2;

                foreach (var item in member.Items)
                {
                    table.Rows.Add(item.Item.Name, item.Quantity, item.Value * item.Quantity);
                }

                int height = 0;
                foreach (var r in table.Rows.Cast<DataGridViewRow>())
                    height += r.Height;

                table.Height += height;
                table.MinimumSize = new Size(400, height);
                table.MaximumSize = new Size(400, height);
                table.Size = new Size(400, height);
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                table.ScrollBars = ScrollBars.None;
                position += height;

                var lb = new Label();

                lb.AutoSize = true;
                lb.Location = new Point(9, position + 10);
                position += 25;
                lb.Name = "LabelMember" + position;
                lb.Size = new Size(30, 13);
                lb.TabIndex = 1;


                this.Controls.Add(lb);
                if (data.ItemsUnsplited != null && member.MoneyRecived - member.Items.Select(y => y.Value * y.Quantity).Sum() > 0)
                {
                    position += 40;
                    lb.Text = String.Format(Language.ItensToPlayerWastedAditional, member.Waste.ToString(), (member.MoneyRecived - member.Items.Select(y => y.Value * y.Quantity).Sum()).ToString());
                }
                else
                {
                    position += 25;
                    lb.Text = String.Format(Language.ItensToPlayerWasted, member.Waste.ToString());
                }
            }

            if (data.ItemsUnsplited != null && data.ItemsUnsplited.Any())
            {
                var lb = new Label();

                lb.AutoSize = true;
                lb.Location = new Point(9, position + 50);
                position += 50;
                lb.Name = "LabelUnsplitedItens";
                lb.Size = new Size(30, 13);
                lb.TabIndex = 1;
                lb.Text = Language.ItemsUnsplited;

                this.Controls.Add(lb);

                var table = new DataGridView();
                this.Controls.Add(table);

                table.ColumnCount = 3; // todo: add image. 

                table.Anchor = ((AnchorStyles)((((
                    AnchorStyles.Top
                  | AnchorStyles.Bottom)
                  | AnchorStyles.Left)
                  | AnchorStyles.Right)));

                table.TabIndex = 0;
                table.Name = "member" + position;
                table.Location = new Point(9, position + 20);
                table.AutoSize = false;
                position += 20;

                //table.Columns[0].Name = "Imagem";
                table.Columns[0].Name = Language.Name;
                table.Columns[1].Name = Language.Quantity;
                table.Columns[2].Name = Language.TotalValue;

                table.Columns[0].DisplayIndex = 0;
                table.Columns[1].DisplayIndex = 1;
                table.Columns[2].DisplayIndex = 2;

                foreach (var item in data.ItemsUnsplited)
                {
                    table.Rows.Add(item.Item.Name, item.Quantity, item.Value * item.Quantity);
                }

                int height = 0;
                foreach (var r in table.Rows.Cast<DataGridViewRow>())
                    height += r.Height;

                table.Height += height;
                position += height;

                table.MinimumSize = new Size(400, height);
                table.MaximumSize = new Size(400, height);
                table.Size = new Size(400, height);
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                table.ScrollBars = ScrollBars.None;
            }

            this.closeBtn = new System.Windows.Forms.Button();

            this.closeBtn.Location = new Point(335, 30);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);

            var YScreenSize = Math.Min(position + 10, 600);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = Language.LootSplitterResult;
            this.Controls.Add(closeBtn);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(500, YScreenSize);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LootSplitterResult";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button closeBtn;

        #endregion
    }
}