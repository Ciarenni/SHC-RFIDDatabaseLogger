namespace RFID_Logger
{
    partial class ViewAllMembers
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
            this.membersListBox = new System.Windows.Forms.ListBox();
            this.okayBtn = new System.Windows.Forms.Button();
            this.totalHoursLabel = new System.Windows.Forms.Label();
            this.totalHoursValue = new System.Windows.Forms.Label();
            this.directions1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // membersListBox
            // 
            this.membersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.membersListBox.FormattingEnabled = true;
            this.membersListBox.Location = new System.Drawing.Point(12, 30);
            this.membersListBox.Name = "membersListBox";
            this.membersListBox.Size = new System.Drawing.Size(238, 290);
            this.membersListBox.TabIndex = 0;
            this.membersListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.membersListBox_MouseDoubleClick);
            // 
            // okayBtn
            // 
            this.okayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.okayBtn.Location = new System.Drawing.Point(12, 348);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(238, 28);
            this.okayBtn.TabIndex = 1;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            this.okayBtn.Click += new System.EventHandler(this.okayBtn_Click);
            // 
            // totalHoursLabel
            // 
            this.totalHoursLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalHoursLabel.AutoSize = true;
            this.totalHoursLabel.Location = new System.Drawing.Point(12, 328);
            this.totalHoursLabel.Name = "totalHoursLabel";
            this.totalHoursLabel.Size = new System.Drawing.Size(65, 13);
            this.totalHoursLabel.TabIndex = 2;
            this.totalHoursLabel.Text = "Total Hours:";
            // 
            // totalHoursValue
            // 
            this.totalHoursValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalHoursValue.AutoSize = true;
            this.totalHoursValue.Location = new System.Drawing.Point(83, 328);
            this.totalHoursValue.Name = "totalHoursValue";
            this.totalHoursValue.Size = new System.Drawing.Size(0, 13);
            this.totalHoursValue.TabIndex = 3;
            // 
            // directions1Label
            // 
            this.directions1Label.AutoSize = true;
            this.directions1Label.Location = new System.Drawing.Point(9, 9);
            this.directions1Label.Name = "directions1Label";
            this.directions1Label.Size = new System.Drawing.Size(251, 13);
            this.directions1Label.TabIndex = 4;
            this.directions1Label.Text = "To view a specific member, double click their name.";
            // 
            // ViewAllMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 388);
            this.Controls.Add(this.directions1Label);
            this.Controls.Add(this.totalHoursValue);
            this.Controls.Add(this.totalHoursLabel);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.membersListBox);
            this.MaximumSize = new System.Drawing.Size(400, 800);
            this.MinimumSize = new System.Drawing.Size(278, 386);
            this.Name = "ViewAllMembers";
            this.Text = "ViewAllMembers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox membersListBox;
        private System.Windows.Forms.Button okayBtn;
        private System.Windows.Forms.Label totalHoursLabel;
        private System.Windows.Forms.Label totalHoursValue;
        private System.Windows.Forms.Label directions1Label;
    }
}