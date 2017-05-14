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
            this.labelHowToUse.Text = "Under construction! :)";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(103, 226);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // HowToUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.labelHowToUse);
            this.Name = "HowToUse";
            this.Text = "HowToUse";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HowToUse_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHowToUse;
        private System.Windows.Forms.Button closeBtn;
    }
}