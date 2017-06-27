namespace RFID_Logger
{
    partial class EditMember
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
            this.rfidBox = new System.Windows.Forms.TextBox();
            this.rfidLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.clockLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.hoursBox = new System.Windows.Forms.TextBox();
            this.clockBox = new System.Windows.Forms.ComboBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rfidBox
            // 
            this.rfidBox.Enabled = false;
            this.rfidBox.Location = new System.Drawing.Point(111, 14);
            this.rfidBox.Name = "rfidBox";
            this.rfidBox.Size = new System.Drawing.Size(123, 20);
            this.rfidBox.TabIndex = 0;
            // 
            // rfidLabel
            // 
            this.rfidLabel.AutoSize = true;
            this.rfidLabel.Location = new System.Drawing.Point(59, 17);
            this.rfidLabel.Name = "rfidLabel";
            this.rfidLabel.Size = new System.Drawing.Size(35, 13);
            this.rfidLabel.TabIndex = 1;
            this.rfidLabel.Text = "RFID:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(56, 78);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(18, 109);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(76, 13);
            this.hoursLabel.TabIndex = 4;
            this.hoursLabel.Text = "Hours worked:";
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Location = new System.Drawing.Point(34, 148);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(60, 13);
            this.clockLabel.TabIndex = 5;
            this.clockLabel.Text = "Clocked in:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(111, 75);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(123, 20);
            this.nameBox.TabIndex = 6;
            // 
            // hoursBox
            // 
            this.hoursBox.Location = new System.Drawing.Point(111, 106);
            this.hoursBox.Name = "hoursBox";
            this.hoursBox.Size = new System.Drawing.Size(123, 20);
            this.hoursBox.TabIndex = 8;
            // 
            // clockBox
            // 
            this.clockBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clockBox.FormattingEnabled = true;
            this.clockBox.Items.AddRange(new object[] {
            "True",
            "False"});
            this.clockBox.Location = new System.Drawing.Point(111, 145);
            this.clockBox.Name = "clockBox";
            this.clockBox.Size = new System.Drawing.Size(123, 21);
            this.clockBox.TabIndex = 9;
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(26, 181);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(85, 28);
            this.okayButton.TabIndex = 10;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(149, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 28);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tagBox
            // 
            this.tagBox.Enabled = false;
            this.tagBox.Location = new System.Drawing.Point(111, 43);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(123, 20);
            this.tagBox.TabIndex = 13;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(56, 46);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(39, 13);
            this.tagLabel.TabIndex = 12;
            this.tagLabel.Text = "Tag #:";
            // 
            // EditMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 233);
            this.Controls.Add(this.tagBox);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.clockBox);
            this.Controls.Add(this.hoursBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.clockLabel);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.rfidLabel);
            this.Controls.Add(this.rfidBox);
            this.MinimumSize = new System.Drawing.Size(254, 233);
            this.Name = "EditMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rfidBox;
        private System.Windows.Forms.Label rfidLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox hoursBox;
        private System.Windows.Forms.ComboBox clockBox;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Label tagLabel;
    }
}