namespace TibiaTools.Application.Forms.PlayersDeaths
{
    partial class LastPlayersDeaths
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.labelSelectWorld = new System.Windows.Forms.Label();
            this.comboBoxWorlds = new System.Windows.Forms.ComboBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelHowItWorks = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableDeath = new BrightIdeasSoftware.DataListView();
            this.colPlayerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPlayerVocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPlayerDeathDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPlayerDeathMessage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDeath)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectWorld
            // 
            this.labelSelectWorld.AutoSize = true;
            this.labelSelectWorld.Location = new System.Drawing.Point(3, 11);
            this.labelSelectWorld.Name = "labelSelectWorld";
            this.labelSelectWorld.Size = new System.Drawing.Size(115, 13);
            this.labelSelectWorld.TabIndex = 0;
            this.labelSelectWorld.Text = "Select the game World";
            // 
            // comboBoxWorlds
            // 
            this.comboBoxWorlds.DisplayMember = "Value";
            this.comboBoxWorlds.FormattingEnabled = true;
            this.comboBoxWorlds.Location = new System.Drawing.Point(6, 27);
            this.comboBoxWorlds.Name = "comboBoxWorlds";
            this.comboBoxWorlds.Size = new System.Drawing.Size(195, 21);
            this.comboBoxWorlds.TabIndex = 1;
            this.comboBoxWorlds.ValueMember = "Value";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(5, 54);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(197, 23);
            this.ButtonSearch.TabIndex = 2;
            this.ButtonSearch.Text = "Search!";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelHowItWorks);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar);
            this.splitContainer1.Panel1.Controls.Add(this.labelSelectWorld);
            this.splitContainer1.Panel1.Controls.Add(this.ButtonSearch);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxWorlds);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableDeath);
            this.splitContainer1.Size = new System.Drawing.Size(740, 271);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 3;
            // 
            // labelHowItWorks
            // 
            this.labelHowItWorks.AutoSize = true;
            this.labelHowItWorks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelHowItWorks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHowItWorks.Location = new System.Drawing.Point(6, 80);
            this.labelHowItWorks.MaximumSize = new System.Drawing.Size(194, 160);
            this.labelHowItWorks.MinimumSize = new System.Drawing.Size(194, 160);
            this.labelHowItWorks.Name = "labelHowItWorks";
            this.labelHowItWorks.Padding = new System.Windows.Forms.Padding(3);
            this.labelHowItWorks.Size = new System.Drawing.Size(194, 160);
            this.labelHowItWorks.TabIndex = 4;
            this.labelHowItWorks.Text = "How it works:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 245);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(197, 23);
            this.progressBar.TabIndex = 3;
            // 
            // tableDeath
            // 
            this.tableDeath.AllColumns.Add(this.colPlayerName);
            this.tableDeath.AllColumns.Add(this.colPlayerVocation);
            this.tableDeath.AllColumns.Add(this.colPlayerDeathDate);
            this.tableDeath.AllColumns.Add(this.colPlayerDeathMessage);
            this.tableDeath.AllowColumnReorder = true;
            this.tableDeath.AllowDrop = true;
            this.tableDeath.CellEditUseWholeCell = false;
            this.tableDeath.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlayerName,
            this.colPlayerVocation,
            this.colPlayerDeathDate,
            this.colPlayerDeathMessage});
            this.tableDeath.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableDeath.DataSource = null;
            this.tableDeath.EmptyListMsg = "Select a game world and start";
            this.tableDeath.EmptyListMsgFont = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableDeath.FullRowSelect = true;
            this.tableDeath.GridLines = true;
            this.tableDeath.GroupWithItemCountFormat = "{0}";
            this.tableDeath.GroupWithItemCountSingularFormat = "{0}";
            this.tableDeath.HideSelection = false;
            this.tableDeath.Location = new System.Drawing.Point(1, 0);
            this.tableDeath.Name = "tableDeath";
            this.tableDeath.RowHeight = 32;
            this.tableDeath.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.tableDeath.SelectedBackColor = System.Drawing.Color.CornflowerBlue;
            this.tableDeath.SelectedForeColor = System.Drawing.Color.MidnightBlue;
            this.tableDeath.ShowCommandMenuOnRightClick = true;
            this.tableDeath.ShowGroups = false;
            this.tableDeath.ShowImagesOnSubItems = true;
            this.tableDeath.ShowItemToolTips = true;
            this.tableDeath.Size = new System.Drawing.Size(530, 268);
            this.tableDeath.TabIndex = 0;
            this.tableDeath.UseCellFormatEvents = true;
            this.tableDeath.UseCompatibleStateImageBehavior = false;
            this.tableDeath.UseFilterIndicator = true;
            this.tableDeath.UseFiltering = true;
            this.tableDeath.UseHotItem = true;
            this.tableDeath.UseTranslucentHotItem = true;
            this.tableDeath.View = System.Windows.Forms.View.Details;
            // 
            // colPlayerName
            // 
            this.colPlayerName.AspectName = "Player";
            this.colPlayerName.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colPlayerName.IsTileViewColumn = true;
            this.colPlayerName.Text = "Player";
            this.colPlayerName.UseInitialLetterForGroup = true;
            this.colPlayerName.Width = 120;
            this.colPlayerName.WordWrap = true;
            // 
            // colPlayerVocation
            // 
            this.colPlayerVocation.AspectName = "Voc";
            this.colPlayerVocation.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colPlayerVocation.IsTileViewColumn = true;
            this.colPlayerVocation.Text = "Voc";
            this.colPlayerVocation.UseInitialLetterForGroup = true;
            this.colPlayerVocation.Width = 50;
            this.colPlayerVocation.WordWrap = true;
            // 
            // colPlayerDeathDate
            // 
            this.colPlayerDeathDate.AspectName = "Date";
            this.colPlayerDeathDate.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colPlayerDeathDate.IsTileViewColumn = true;
            this.colPlayerDeathDate.Text = "Date";
            this.colPlayerDeathDate.UseInitialLetterForGroup = true;
            this.colPlayerDeathDate.Width = 70;
            this.colPlayerDeathDate.WordWrap = true;
            // 
            // colPlayerDeathMessage
            // 
            this.colPlayerDeathMessage.AspectName = "Message";
            this.colPlayerDeathMessage.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colPlayerDeathMessage.IsTileViewColumn = true;
            this.colPlayerDeathMessage.Text = "Message";
            this.colPlayerDeathMessage.UseInitialLetterForGroup = true;
            this.colPlayerDeathMessage.Width = 285;
            this.colPlayerDeathMessage.WordWrap = true;
            // 
            // LastPlayersDeaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 311);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LastPlayersDeaths";
            this.Text = "PlayersDeaths";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableDeath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSelectWorld;
        private System.Windows.Forms.ComboBox comboBoxWorlds;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelHowItWorks;
        private System.Windows.Forms.ProgressBar progressBar;
        private BrightIdeasSoftware.DataListView tableDeath;
        private BrightIdeasSoftware.OLVColumn colPlayerName;
        private BrightIdeasSoftware.OLVColumn colPlayerVocation;
        private BrightIdeasSoftware.OLVColumn colPlayerDeathDate;
        private BrightIdeasSoftware.OLVColumn colPlayerDeathMessage;
    }
}