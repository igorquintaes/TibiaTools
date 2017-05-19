using BrightIdeasSoftware;
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
                var groupBoxPlayer = new GroupBox();
                groupBoxPlayer.SuspendLayout();

                var table = new DataListView();
                ((System.ComponentModel.ISupportInitialize)(table)).BeginInit();

                var colImage = new OLVColumn();
                var colName = new OLVColumn();
                var colQuantity = new OLVColumn();
                var colValue = new OLVColumn();
                var imgRender = new ImageRenderer();

                // 
                // groupBoxPlayer
                // 
                groupBoxPlayer.Anchor = 
                   (((AnchorStyles.Top 
                    | AnchorStyles.Bottom)
                    | AnchorStyles.Left)
                    | AnchorStyles.Right);

                groupBoxPlayer.Location = new Point(9, position + 20);
                groupBoxPlayer.Name = "groupBoxPlayer";
                groupBoxPlayer.Size = new Size(117, 44);
                groupBoxPlayer.TabIndex = 20;
                groupBoxPlayer.TabStop = false;
                groupBoxPlayer.Text = String.Format(Language.ItensToPlayerWasted, member.Waste.ToString());
                groupBoxPlayer.Controls.Add(table);

                //
                // Table
                //
                table.AllColumns.Add(colImage);
                table.AllColumns.Add(colName);
                table.AllColumns.Add(colQuantity);
                table.AllColumns.Add(colValue);
                table.AllowColumnReorder = true;
                table.AllowDrop = true;
                table.Anchor = 
                    (((AnchorStyles.Top 
                     | AnchorStyles.Bottom)
                     | AnchorStyles.Left)
                     | AnchorStyles.Right);
                table.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
                table.CellEditUseWholeCell = false;
                table.Columns.AddRange(new ColumnHeader[]
                {
                    colImage,
                    colName,
                    colQuantity,
                    colValue
                });
                table.Cursor = Cursors.Default;

                table.DataSource = null;
                table.EmptyListMsg = Language.EmptyPlayerItemList;
                // todo: search for a better font lol
                table.EmptyListMsgFont = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                table.FullRowSelect = true;
                table.GridLines = true;
                table.GroupWithItemCountFormat = Language.XItems;
                table.GroupWithItemCountSingularFormat = Language.OneItem;
                table.HideSelection = false;
                table.SelectedBackColor = Color.CornflowerBlue;
                table.SelectedForeColor = Color.MidnightBlue;
                table.LargeImageList = this.imageListLarge;
                table.Location = new System.Drawing.Point(6, 19);
                table.Name = "olvData";
                table.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
                table.ShowCommandMenuOnRightClick = true;
                table.ShowGroups = false;
                table.ShowImagesOnSubItems = true;
                table.ShowItemToolTips = true;
                table.Size = new System.Drawing.Size(677, 259);
                table.SmallImageList = this.imageListSmall;
                table.TabIndex = 0;
                table.UseCellFormatEvents = true;
                table.UseCompatibleStateImageBehavior = false;
                table.UseFilterIndicator = true;
                table.UseFiltering = true;
                table.UseHotItem = true;
                table.UseTranslucentHotItem = true;
                table.View = System.Windows.Forms.View.Details;
                // 
                // olvColumn1
                // 

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