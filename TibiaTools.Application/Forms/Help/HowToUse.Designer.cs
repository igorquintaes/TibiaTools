using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms.Help
{
    partial class HowToUse
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
            this.labelHowToUse = new System.Windows.Forms.Label();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHowToUse
            // 
            this.labelHowToUse.AutoSize = true;
            this.labelHowToUse.Location = new System.Drawing.Point(13, 13);
            this.labelHowToUse.MaximumSize = new System.Drawing.Size(260, 0);
            this.labelHowToUse.MinimumSize = new System.Drawing.Size(260, 0);
            this.labelHowToUse.Name = "labelHowToUse";
            this.labelHowToUse.Size = new System.Drawing.Size(260, 13);
            this.labelHowToUse.TabIndex = 0;
            this.labelHowToUse.Text = Language.HowToUseReadMe;
            //
            // LinkSource
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
            this.closeBtn.Location = new System.Drawing.Point(103, 226);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = Language.Close;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // HowToUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.linkSource);
            this.Controls.Add(this.labelHowToUse);
            this.Name = "HowToUse";
            this.Text = Language.HowToUse;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHowToUse;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.LinkLabel linkSource;
    }
}