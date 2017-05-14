namespace TibiaTools.Application.Forms
{
    partial class Main
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelChooseOption = new System.Windows.Forms.Label();
            this.buttonLootSplitter = new System.Windows.Forms.Button();
            this.buttonPlayersDeaths = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial Black", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(11, 50);
            this.labelTitle.MaximumSize = new System.Drawing.Size(260, 0);
            this.labelTitle.MinimumSize = new System.Drawing.Size(260, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(260, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Tibia Tools";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelChooseOption
            // 
            this.labelChooseOption.AutoSize = true;
            this.labelChooseOption.Location = new System.Drawing.Point(12, 97);
            this.labelChooseOption.MaximumSize = new System.Drawing.Size(260, 0);
            this.labelChooseOption.MinimumSize = new System.Drawing.Size(260, 0);
            this.labelChooseOption.Name = "labelChooseOption";
            this.labelChooseOption.Size = new System.Drawing.Size(260, 13);
            this.labelChooseOption.TabIndex = 1;
            this.labelChooseOption.Text = "Choose one of bellow tools:";
            this.labelChooseOption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonLootSplitter
            // 
            this.buttonLootSplitter.Location = new System.Drawing.Point(11, 113);
            this.buttonLootSplitter.Name = "buttonLootSplitter";
            this.buttonLootSplitter.Size = new System.Drawing.Size(261, 45);
            this.buttonLootSplitter.TabIndex = 2;
            this.buttonLootSplitter.Text = "Loot Counter and Splitter";
            this.buttonLootSplitter.UseVisualStyleBackColor = true;
            this.buttonLootSplitter.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPlayersDeaths
            // 
            this.buttonPlayersDeaths.Location = new System.Drawing.Point(11, 164);
            this.buttonPlayersDeaths.Name = "buttonPlayersDeaths";
            this.buttonPlayersDeaths.Size = new System.Drawing.Size(261, 45);
            this.buttonPlayersDeaths.TabIndex = 3;
            this.buttonPlayersDeaths.Text = "Last Players Deaths (soon!)";
            this.buttonPlayersDeaths.UseVisualStyleBackColor = true;
            this.buttonPlayersDeaths.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 220);
            this.Controls.Add(this.buttonPlayersDeaths);
            this.Controls.Add(this.buttonLootSplitter);
            this.Controls.Add(this.labelChooseOption);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelChooseOption;
        private System.Windows.Forms.Button buttonLootSplitter;
        private System.Windows.Forms.Button buttonPlayersDeaths;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}