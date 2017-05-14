using TibiaTools.Application.Resources;

namespace TibiaTools.Application.Forms.Options
{
    partial class Saved
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.savedSuccefull = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(56, 68);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = global::TibiaTools.Application.Resources.Language.Close;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // savedSuccefull
            // 
            this.savedSuccefull.AutoSize = true;
            this.savedSuccefull.Location = new System.Drawing.Point(12, 9);
            this.savedSuccefull.MaximumSize = new System.Drawing.Size(175, 0);
            this.savedSuccefull.Name = "savedSuccefull";
            this.savedSuccefull.Size = new System.Drawing.Size(150, 26);
            this.savedSuccefull.TabIndex = 1;
            this.savedSuccefull.Text = "Your configuration was saved succefull!";
            // 
            // Saved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 100);
            this.Controls.Add(this.savedSuccefull);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Saved";
            this.Text = "Saved";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Saved_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label savedSuccefull;
    }
}