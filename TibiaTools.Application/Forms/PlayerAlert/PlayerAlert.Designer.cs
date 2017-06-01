using BrightIdeasSoftware;
using System.Data;
using System.Linq;
using System.Threading;

namespace TibiaTools.Application.Forms.PlayerAlert
{
    partial class PlayerAlert
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
            this.labelInsertPlayerName = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelHowItWorks = new System.Windows.Forms.Label();
            this.tablePlayers = new BrightIdeasSoftware.DataListView();
            this.colPlayerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colWorld = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPlayerVocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsOnline = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLastOnlineDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRemovePlayer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInsertPlayerName
            // 
            this.labelInsertPlayerName.AutoSize = true;
            this.labelInsertPlayerName.Location = new System.Drawing.Point(3, 11);
            this.labelInsertPlayerName.Name = "labelInsertPlayerName";
            this.labelInsertPlayerName.Size = new System.Drawing.Size(96, 13);
            this.labelInsertPlayerName.TabIndex = 0;
            this.labelInsertPlayerName.Text = "Insert Player Name";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(6, 27);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(195, 20);
            this.textBoxPlayerName.TabIndex = 1;
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(5, 54);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(197, 23);
            this.buttonAddPlayer.TabIndex = 2;
            this.buttonAddPlayer.Text = "Add Player!";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.buttonAddPlayer_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelHowItWorks);
            this.splitContainer1.Panel1.Controls.Add(this.labelInsertPlayerName);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddPlayer);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPlayerName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tablePlayers);
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
            this.labelHowItWorks.MaximumSize = new System.Drawing.Size(194, 187);
            this.labelHowItWorks.MinimumSize = new System.Drawing.Size(194, 187);
            this.labelHowItWorks.Name = "labelHowItWorks";
            this.labelHowItWorks.Padding = new System.Windows.Forms.Padding(3);
            this.labelHowItWorks.Size = new System.Drawing.Size(194, 187);
            this.labelHowItWorks.TabIndex = 4;
            this.labelHowItWorks.Text = "How it works:";
            // 
            // tablePlayers
            // 
            this.tablePlayers.AllColumns.Add(this.colPlayerName);
            this.tablePlayers.AllColumns.Add(this.colWorld);
            this.tablePlayers.AllColumns.Add(this.colPlayerVocation);
            this.tablePlayers.AllColumns.Add(this.colIsOnline);
            this.tablePlayers.AllColumns.Add(this.colLastOnlineDate);
            this.tablePlayers.AllColumns.Add(this.colRemovePlayer);
            this.tablePlayers.AllowColumnReorder = true;
            this.tablePlayers.AllowDrop = true;
            this.tablePlayers.CellEditUseWholeCell = false;
            this.tablePlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlayerName,
            this.colWorld,
            this.colPlayerVocation,
            this.colIsOnline,
            this.colLastOnlineDate,
            this.colRemovePlayer});
            this.tablePlayers.Cursor = System.Windows.Forms.Cursors.Default;
            this.tablePlayers.DataSource = null;
            this.tablePlayers.EmptyListMsg = "Empty list";
            this.tablePlayers.EmptyListMsgFont = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablePlayers.FullRowSelect = true;
            this.tablePlayers.GridLines = true;
            this.tablePlayers.GroupWithItemCountFormat = "{0}";
            this.tablePlayers.GroupWithItemCountSingularFormat = "{0}";
            this.tablePlayers.HideSelection = false;
            this.tablePlayers.Location = new System.Drawing.Point(1, 0);
            this.tablePlayers.Name = "TablePlayers";
            this.tablePlayers.RowHeight = 32;
            this.tablePlayers.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.tablePlayers.SelectedBackColor = System.Drawing.Color.CornflowerBlue;
            this.tablePlayers.SelectedForeColor = System.Drawing.Color.MidnightBlue;
            this.tablePlayers.ShowCommandMenuOnRightClick = true;
            this.tablePlayers.ShowGroups = false;
            this.tablePlayers.ShowImagesOnSubItems = true;
            this.tablePlayers.ShowItemToolTips = true;
            this.tablePlayers.Size = new System.Drawing.Size(530, 268);
            this.tablePlayers.TabIndex = 0;
            this.tablePlayers.UseCellFormatEvents = true;
            this.tablePlayers.UseCompatibleStateImageBehavior = false;
            this.tablePlayers.UseFilterIndicator = true;
            this.tablePlayers.UseFiltering = true;
            this.tablePlayers.UseHotItem = true;
            this.tablePlayers.UseTranslucentHotItem = true;
            this.tablePlayers.View = System.Windows.Forms.View.Details;
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
            // colWorld
            // 
            this.colWorld.AspectName = "World";
            this.colWorld.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colWorld.IsTileViewColumn = true;
            this.colWorld.Text = "World";
            this.colWorld.UseInitialLetterForGroup = true;
            this.colWorld.Width = 80;
            this.colWorld.WordWrap = true;
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
            // colIsOnline
            // 
            this.colIsOnline.AspectName = "IsOnline";
            this.colIsOnline.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colIsOnline.IsTileViewColumn = true;
            this.colIsOnline.Text = "Online";
            this.colIsOnline.UseInitialLetterForGroup = true;
            this.colIsOnline.Width = 50;
            this.colIsOnline.WordWrap = true;
            // 
            // colLastOnlineDate
            // 
            this.colLastOnlineDate.AspectName = "LastOnlineDate";
            this.colLastOnlineDate.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colLastOnlineDate.IsTileViewColumn = true;
            this.colLastOnlineDate.Text = "Last Login";
            this.colLastOnlineDate.UseInitialLetterForGroup = true;
            this.colLastOnlineDate.Width = 70;
            this.colLastOnlineDate.WordWrap = true;
            // 
            // colRemovePlayer
            // 
            this.colRemovePlayer.AspectName = "RemovePlayer";
            this.colRemovePlayer.ButtonPadding = new System.Drawing.Size(10, 10);
            this.colRemovePlayer.IsTileViewColumn = true;
            this.colRemovePlayer.IsButton = true;
            this.colRemovePlayer.Text = "Remove Player";
            this.colRemovePlayer.UseInitialLetterForGroup = true;
            this.colRemovePlayer.Width = 155;
            this.colRemovePlayer.WordWrap = true;
            this.tablePlayers.ButtonClick += delegate (object sender, CellClickEventArgs e) {
                _charactersToRemove.Add(_charactersOnTable.Single(x => x.Name == e.Item.SubItems[0].Text));
                e.Item.Remove();
            };
            // 
            // PlayerAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 311);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerAlert";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PlayerAlert";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelInsertPlayerName;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelHowItWorks;
        private BrightIdeasSoftware.DataListView tablePlayers;
        private BrightIdeasSoftware.OLVColumn colPlayerName;
        private BrightIdeasSoftware.OLVColumn colWorld;
        private BrightIdeasSoftware.OLVColumn colPlayerVocation;
        private BrightIdeasSoftware.OLVColumn colIsOnline;
        private BrightIdeasSoftware.OLVColumn colLastOnlineDate;
        private BrightIdeasSoftware.OLVColumn colRemovePlayer;
    }
}