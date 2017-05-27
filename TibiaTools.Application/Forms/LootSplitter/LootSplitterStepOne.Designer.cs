namespace TibiaTools.Application.Forms.LootSplitter
{
    partial class LootSplitterStepOne
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
            this.labelInsertLootText = new System.Windows.Forms.Label();
            this.textAreaLoot = new System.Windows.Forms.TextBox();
            this.labelPlayerQuantity = new System.Windows.Forms.Label();
            this.continueBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.boxPlayerQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.boxPlayerQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInsertLootText
            // 
            this.labelInsertLootText.AutoSize = true;
            this.labelInsertLootText.Location = new System.Drawing.Point(9, 30);
            this.labelInsertLootText.Name = "labelInsertLootText";
            this.labelInsertLootText.Size = new System.Drawing.Size(200, 13);
            this.labelInsertLootText.TabIndex = 0;
            this.labelInsertLootText.Text = "Paste in text area bellow all the hunt loot:";
            // 
            // textAreaLoot
            // 
            this.textAreaLoot.Location = new System.Drawing.Point(12, 46);
            this.textAreaLoot.Multiline = true;
            this.textAreaLoot.Name = "textAreaLoot";
            this.textAreaLoot.Size = new System.Drawing.Size(277, 152);
            this.textAreaLoot.TabIndex = 1;
            // 
            // labelPlayerQuantity
            // 
            this.labelPlayerQuantity.AutoSize = true;
            this.labelPlayerQuantity.Location = new System.Drawing.Point(312, 30);
            this.labelPlayerQuantity.Name = "labelPlayerQuantity";
            this.labelPlayerQuantity.Size = new System.Drawing.Size(127, 13);
            this.labelPlayerQuantity.TabIndex = 2;
            this.labelPlayerQuantity.Text = "Insert the players quantity";
            // 
            // continueBtn
            // 
            this.continueBtn.Location = new System.Drawing.Point(315, 73);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(75, 23);
            this.continueBtn.TabIndex = 4;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(396, 73);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // boxPlayerQuantity
            // 
            this.boxPlayerQuantity.Location = new System.Drawing.Point(315, 46);
            this.boxPlayerQuantity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.boxPlayerQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.boxPlayerQuantity.Name = "boxPlayerQuantity";
            this.boxPlayerQuantity.Size = new System.Drawing.Size(156, 20);
            this.boxPlayerQuantity.TabIndex = 6;
            this.boxPlayerQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LootSplitterStepOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 210);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Controls.Add(this.boxPlayerQuantity);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.labelPlayerQuantity);
            this.Controls.Add(this.textAreaLoot);
            this.Controls.Add(this.labelInsertLootText);
            this.Name = "LootSplitterStepOne";
            this.Text = "LootSplitterStepOne";
            ((System.ComponentModel.ISupportInitialize)(this.boxPlayerQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInsertLootText;
        private System.Windows.Forms.TextBox textAreaLoot;
        private System.Windows.Forms.Label labelPlayerQuantity;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.NumericUpDown boxPlayerQuantity;
    }
}