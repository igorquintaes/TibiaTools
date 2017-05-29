namespace TibiaTools.Application.Forms.PlayerAlert
{
    partial class PlayerDetected
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
            this.playerDetectedLabel = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerDetectedLabel
            // 
            this.playerDetectedLabel.AutoSize = true;
            this.playerDetectedLabel.Location = new System.Drawing.Point(12, 9);
            this.playerDetectedLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.playerDetectedLabel.Name = "playerDetectedLabel";
            this.playerDetectedLabel.Size = new System.Drawing.Size(194, 13);
            this.playerDetectedLabel.TabIndex = 1;
            this.playerDetectedLabel.Text = "The player BlaBlaBla is Online or offline.";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(109, 91);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = global::TibiaTools.Application.Resources.Language.Close;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // PlayerDetected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 126);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.playerDetectedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerDetected";
            this.Text = "PlayerAlert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label playerDetectedLabel;
        private System.Windows.Forms.Button closeBtn;
    }
}