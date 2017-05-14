namespace TibiaTools.Application.Forms.Options
{
    partial class Configuration
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
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.language = new System.Windows.Forms.Label();
            this.saveConfiguration = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languageBox
            // 
            this.languageBox.DisplayMember = "Text";
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Location = new System.Drawing.Point(12, 38);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(156, 21);
            this.languageBox.TabIndex = 0;
            this.languageBox.ValueMember = "Value";
            // 
            // language
            // 
            this.language.AutoSize = true;
            this.language.Location = new System.Drawing.Point(9, 22);
            this.language.Name = "language";
            this.language.Size = new System.Drawing.Size(58, 13);
            this.language.TabIndex = 1;
            this.language.Text = "Language:";
            this.language.Click += new System.EventHandler(this.label1_Click);
            // 
            // saveConfiguration
            // 
            this.saveConfiguration.Location = new System.Drawing.Point(93, 75);
            this.saveConfiguration.Name = "saveConfiguration";
            this.saveConfiguration.Size = new System.Drawing.Size(75, 23);
            this.saveConfiguration.TabIndex = 4;
            this.saveConfiguration.Text = global::TibiaTools.Application.Resources.Language.Save;
            this.saveConfiguration.UseVisualStyleBackColor = true;
            this.saveConfiguration.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 75);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = global::TibiaTools.Application.Resources.Language.Cancel;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 107);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveConfiguration);
            this.Controls.Add(this.language);
            this.Controls.Add(this.languageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.Label language;
        private System.Windows.Forms.Button saveConfiguration;
        private System.Windows.Forms.Button cancelButton;
    }
}