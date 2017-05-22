using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
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
            const int boxTableSeparator = 50;

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

                var tableWidth = 0;
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
                     ((AnchorStyles.Top
                     | AnchorStyles.Left)
                     | AnchorStyles.Right);
                groupBoxPlayer.Location = new Point(9, position + 20);
                groupBoxPlayer.Name = "groupBoxPlayer";
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
                    ((AnchorStyles.Top 
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
                table.Location = new Point(24, position + boxTableSeparator);
                table.Name = "olvData" + position;
                table.RowHeight = 32;
                table.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
                table.ShowCommandMenuOnRightClick = true;
                table.ShowGroups = false;
                table.ShowImagesOnSubItems = true;
                table.ShowItemToolTips = true;
                table.TabIndex = 0;
                table.UseCellFormatEvents = true;
                table.UseCompatibleStateImageBehavior = false;
                table.UseFilterIndicator = true;
                table.UseFiltering = true;
                table.UseHotItem = true;
                table.UseTranslucentHotItem = true;
                table.View = View.Details;
                // 
                // colImage
                // 
                colImage.AspectName = "colImage";
                colImage.ButtonPadding = new Size(10, 10);
                colImage.IsTileViewColumn = true;
                colImage.Text = String.Empty;
                colImage.UseInitialLetterForGroup = true;
                colImage.Width = 32;
                colImage.WordWrap = false;
                colImage.IsEditable = false;
                colImage.Searchable = false;
                colImage.Sortable = false;
                colImage.UseFiltering = false;
                colImage.Groupable = false;
                colImage.Renderer = imgRender;
                tableWidth += 32;
                //
                // colName
                //
                colName.AspectName = "colName";
                colName.ButtonPadding = new Size(10, 10);
                colName.IsTileViewColumn = true;
                colName.Text = Language.Name;
                colName.Width = 230;
                colName.IsEditable = false;
                tableWidth += 230;
                //
                // colQuantity
                //
                colQuantity.AspectName = "colQuantity";
                colQuantity.ButtonPadding = new Size(10, 10);
                colQuantity.IsTileViewColumn = true;
                colQuantity.Text = Language.Quantity;
                colQuantity.Width = 70;
                colQuantity.IsEditable = false;
                tableWidth += 70;
                //
                // colValue
                //
                colValue.AspectName = "colValue";
                colValue.ButtonPadding = new Size(10, 10);
                colValue.IsTileViewColumn = true;
                colValue.Text = Language.Value;
                colValue.Width = 80;
                colValue.IsEditable = false;
                tableWidth += 80;
                //
                // Fill member table
                //
                var memberDataTable = DataTableByMember(member);
                if (data.ItemsUnsplited != null && member.MoneyRecived - member.Items.Select(y => y.Value * y.Quantity).Sum() > 0)
                {
                    var value = member.MoneyRecived - member.Items.Select(y => y.Value * y.Quantity).Sum();

                    memberDataTable.Rows.Add(
                        ".\\data\\Images\\default.png",
                        Language.AditionalValueByUnsplitedItems,
                        1,
                        value);
                }
                table.DataSource = memberDataTable;
                //
                // Finally
                //
                var tableHeight = memberDataTable.Rows.Count > 0
                    ? ((memberDataTable.Rows.Count + 1) * 32) + 10
                    : 64 + 10;
                var groupBoxheight = tableHeight + 50;
                position += groupBoxheight + 10;

                groupBoxPlayer.Size = new Size(400 + boxTableSeparator, groupBoxheight);
                table.Size = new Size(tableWidth + 10, tableHeight);
                this.Controls.Add(groupBoxPlayer);
                this.Controls.Add(table);
                groupBoxPlayer.ResumeLayout(false);
                groupBoxPlayer.PerformLayout();
                groupBoxPlayer.SendToBack();
                ((System.ComponentModel.ISupportInitialize)(table)).EndInit();
            }
            //
            // Unsplited Items
            //
            if (data.ItemsUnsplited != null && data.ItemsUnsplited.Any())
            {

                var groupBoxPlayer = new GroupBox();
                groupBoxPlayer.SuspendLayout();

                var tableWidth = 0;
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
                     ((AnchorStyles.Top
                     | AnchorStyles.Left)
                     | AnchorStyles.Right);
                groupBoxPlayer.Location = new Point(9, position + 20);
                groupBoxPlayer.Name = "groupBoxPlayer";
                groupBoxPlayer.TabIndex = 20;
                groupBoxPlayer.TabStop = false;
                groupBoxPlayer.Text = Language.ItemsUnsplited;
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
                    ((AnchorStyles.Top
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
                table.Location = new Point(24, position + boxTableSeparator);
                table.Name = "olvData" + position;
                table.RowHeight = 32;
                table.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
                table.ShowCommandMenuOnRightClick = true;
                table.ShowGroups = false;
                table.ShowImagesOnSubItems = true;
                table.ShowItemToolTips = true;
                table.TabIndex = 0;
                table.UseCellFormatEvents = true;
                table.UseCompatibleStateImageBehavior = false;
                table.UseFilterIndicator = true;
                table.UseFiltering = true;
                table.UseHotItem = true;
                table.UseTranslucentHotItem = true;
                table.View = View.Details;
                // 
                // colImage
                // 
                colImage.AspectName = "colImage";
                colImage.ButtonPadding = new Size(10, 10);
                colImage.IsTileViewColumn = true;
                colImage.Text = String.Empty;
                colImage.UseInitialLetterForGroup = true;
                colImage.Width = 32;
                colImage.WordWrap = false;
                colImage.IsEditable = false;
                colImage.Searchable = false;
                colImage.Sortable = false;
                colImage.UseFiltering = false;
                colImage.Groupable = false;
                colImage.Renderer = imgRender;
                tableWidth += 32;
                //
                // colName
                //
                colName.AspectName = "colName";
                colName.ButtonPadding = new Size(10, 10);
                colName.IsTileViewColumn = true;
                colName.Text = Language.Name;
                colName.Width = 230;
                colName.IsEditable = false;
                tableWidth += 230;
                //
                // colQuantity
                //
                colQuantity.AspectName = "colQuantity";
                colQuantity.ButtonPadding = new Size(10, 10);
                colQuantity.IsTileViewColumn = true;
                colQuantity.Text = Language.Quantity;
                colQuantity.Width = 70;
                colQuantity.IsEditable = false;
                tableWidth += 70;
                //
                // colValue
                //
                colValue.AspectName = "colValue";
                colValue.ButtonPadding = new Size(10, 10);
                colValue.IsTileViewColumn = true;
                colValue.Text = Language.Value;
                colValue.Width = 80;
                colValue.IsEditable = false;
                tableWidth += 80;
                //
                // Fill member table
                //
                var memberDataTable = DataTableByUnsplitted(data.ItemsUnsplited);
                table.DataSource = memberDataTable;
                //
                // Finally
                //
                var tableHeight = memberDataTable.Rows.Count > 0
                    ? ((memberDataTable.Rows.Count + 1) * 32) + 10
                    : 64 + 10;
                var groupBoxheight = tableHeight + 50;
                position += groupBoxheight + 10;

                groupBoxPlayer.Size = new Size(400 + boxTableSeparator, groupBoxheight);
                table.Size = new Size(tableWidth + 10, tableHeight);
                this.Controls.Add(groupBoxPlayer);
                this.Controls.Add(table);
                groupBoxPlayer.ResumeLayout(false);
                groupBoxPlayer.PerformLayout();
                groupBoxPlayer.SendToBack();
                ((System.ComponentModel.ISupportInitialize)(table)).EndInit();
            }
            //
            // Close Btn
            //
            this.closeBtn = new Button();
            this.closeBtn.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.closeBtn.Location = new Point(385, 30);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            //
            // Window
            //
            var YScreenSize = Math.Min(position + 10, 600);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = Language.LootSplitterResult;
            this.Controls.Add(closeBtn);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(470, YScreenSize);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LootSplitterResult";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button closeBtn;

        #endregion

        private static DataTable DataTableByMember(MemberDTO member)
        {
            var table = new DataTable("member");
            table.Columns.Add("colImage");
            table.Columns.Add("colName");
            table.Columns.Add("colQuantity");
            table.Columns.Add("colValue");

            foreach (var item in member.Items)
            {
                table.Rows.Add(
                    ".\\data\\Images\\default.png",
                    item.Item.Name,
                    item.Quantity,
                    item.Value * item.Quantity);
            }

            return table;
        }

        private static DataTable DataTableByUnsplitted(IEnumerable<ItemResultDTO> items)
        {
            var table = new DataTable("unsplitted");
            table.Columns.Add("colImage");
            table.Columns.Add("colName");
            table.Columns.Add("colQuantity");
            table.Columns.Add("colValue");

            foreach (var item in items)
            {
                table.Rows.Add(
                    ".\\data\\Images\\default.png",
                    item.Item.Name,
                    item.Quantity,
                    item.Value * item.Quantity);
            }

            return table;
        }
    }
}