namespace RFID_Logger
{
    partial class NewMember
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
            this.RFIDLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.RFIDBox = new System.Windows.Forms.TextBox();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.projLabel = new System.Windows.Forms.Label();
            this.projCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // RFIDLabel
            // 
            this.RFIDLabel.AutoSize = true;
            this.RFIDLabel.Location = new System.Drawing.Point(55, 22);
            this.RFIDLabel.Name = "RFIDLabel";
            this.RFIDLabel.Size = new System.Drawing.Size(35, 13);
            this.RFIDLabel.TabIndex = 0;
            this.RFIDLabel.Text = "RFID:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(52, 81);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(12, 139);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(78, 33);
            this.okayButton.TabIndex = 2;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(137, 139);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(78, 33);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(96, 78);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(119, 20);
            this.nameBox.TabIndex = 1;
            // 
            // RFIDBox
            // 
            this.RFIDBox.Enabled = false;
            this.RFIDBox.Location = new System.Drawing.Point(96, 19);
            this.RFIDBox.Name = "RFIDBox";
            this.RFIDBox.Size = new System.Drawing.Size(119, 20);
            this.RFIDBox.TabIndex = 7;
            // 
            // tagBox
            // 
            this.tagBox.Location = new System.Drawing.Point(96, 48);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(119, 20);
            this.tagBox.TabIndex = 0;
            this.tagBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tagBox_KeyDown);
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(51, 51);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(39, 13);
            this.tagLabel.TabIndex = 8;
            this.tagLabel.Text = "Tag #:";
            // 
            // projLabel
            // 
            this.projLabel.AutoSize = true;
            this.projLabel.Location = new System.Drawing.Point(12, 109);
            this.projLabel.Name = "projLabel";
            this.projLabel.Size = new System.Drawing.Size(80, 13);
            this.projLabel.TabIndex = 9;
            this.projLabel.Text = "Default Project:";
            // 
            // projCombo
            // 
            this.projCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projCombo.FormattingEnabled = true;
            this.projCombo.Items.AddRange(new object[] {
            "CubeSat",
            "Cansat 2012",
            "Mars Rover",
            "BalloonSat",
            "Microgravity"});
            this.projCombo.Location = new System.Drawing.Point(96, 106);
            this.projCombo.Name = "projCombo";
            this.projCombo.Size = new System.Drawing.Size(119, 21);
            this.projCombo.TabIndex = 10;
            // 
            // NewMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 180);
            this.Controls.Add(this.projCombo);
            this.Controls.Add(this.projLabel);
            this.Controls.Add(this.tagBox);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.RFIDBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.RFIDLabel);
            this.MinimumSize = new System.Drawing.Size(239, 218);
            this.Name = "NewMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewMember";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RFIDLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox RFIDBox;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Label projLabel;
        private System.Windows.Forms.ComboBox projCombo;
    }
}