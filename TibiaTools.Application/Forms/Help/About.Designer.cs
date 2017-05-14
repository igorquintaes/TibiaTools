using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms.Help
{
    partial class About
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
            this.sourceCodeIn = new System.Windows.Forms.Label();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceCodeIn
            // 
            this.sourceCodeIn.AutoSize = true;
            this.sourceCodeIn.Location = new System.Drawing.Point(12, 9);
            this.sourceCodeIn.MaximumSize = new System.Drawing.Size(250, 0);
            this.sourceCodeIn.Name = "sourceCodeIn";
            this.sourceCodeIn.Size = new System.Drawing.Size(223, 26);
            this.sourceCodeIn.TabIndex = 1;
            this.sourceCodeIn.Text = "Tibia Tools is an Open Source project. All the application and source code can be" +
    " find in:";
            this.sourceCodeIn.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkSource
            // 
            this.linkSource.AutoSize = true;
            this.linkSource.Location = new System.Drawing.Point(15, 59);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(214, 17);
            this.linkSource.TabIndex = 2;
            this.linkSource.TabStop = true;
            this.linkSource.Text = "https://github.com/igorquintaes/TibiaTools";
            this.linkSource.UseCompatibleTextRendering = true;
            this.linkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSource_LinkClicked);
            this.linkSource.Links.Add(0, this.linkSource.Text.Length, this.linkSource.Text);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(109, 91);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = global::TibiaTools.Application.Resources.Language.Close;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 126);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.linkSource);
            this.Controls.Add(this.sourceCodeIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label sourceCodeIn;
        private System.Windows.Forms.LinkLabel linkSource;
        private System.Windows.Forms.Button closeBtn;
    }
}