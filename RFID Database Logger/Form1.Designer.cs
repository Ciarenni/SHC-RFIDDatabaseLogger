namespace RFID_Logger
{
    partial class RFIDLoggerMain
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
            this.rfidButton = new System.Windows.Forms.Button();
            this.clockedInList = new System.Windows.Forms.ListBox();
            this.clockedInLabel = new System.Windows.Forms.Label();
            this.swipeGroup = new System.Windows.Forms.GroupBox();
            this.projLabel = new System.Windows.Forms.Label();
            this.projCombo = new System.Windows.Forms.ComboBox();
            this.clockedInGroup = new System.Windows.Forms.GroupBox();
            this.hoursWorkedGroup = new System.Windows.Forms.GroupBox();
            this.clockOutBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.membersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.swipeGroup.SuspendLayout();
            this.clockedInGroup.SuspendLayout();
            this.hoursWorkedGroup.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rfidButton
            // 
            this.rfidButton.Location = new System.Drawing.Point(313, 14);
            this.rfidButton.Name = "rfidButton";
            this.rfidButton.Size = new System.Drawing.Size(127, 25);
            this.rfidButton.TabIndex = 0;
            this.rfidButton.Text = "Read";
            this.rfidButton.UseVisualStyleBackColor = true;
            this.rfidButton.Click += new System.EventHandler(this.rfidButton_Click);
            // 
            // clockedInList
            // 
            this.clockedInList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clockedInList.FormattingEnabled = true;
            this.clockedInList.Location = new System.Drawing.Point(101, 24);
            this.clockedInList.Name = "clockedInList";
            this.clockedInList.Size = new System.Drawing.Size(168, 173);
            this.clockedInList.TabIndex = 3;
            this.clockedInList.DoubleClick += new System.EventHandler(this.clockedInList_DoubleClick);
            this.clockedInList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clockedInList_KeyDown);
            // 
            // clockedInLabel
            // 
            this.clockedInLabel.AutoSize = true;
            this.clockedInLabel.Location = new System.Drawing.Point(20, 70);
            this.clockedInLabel.Name = "clockedInLabel";
            this.clockedInLabel.Size = new System.Drawing.Size(60, 13);
            this.clockedInLabel.TabIndex = 4;
            this.clockedInLabel.Text = "Clocked in:";
            // 
            // swipeGroup
            // 
            this.swipeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.swipeGroup.Controls.Add(this.projLabel);
            this.swipeGroup.Controls.Add(this.projCombo);
            this.swipeGroup.Controls.Add(this.rfidButton);
            this.swipeGroup.Location = new System.Drawing.Point(4, 22);
            this.swipeGroup.Name = "swipeGroup";
            this.swipeGroup.Size = new System.Drawing.Size(276, 45);
            this.swipeGroup.TabIndex = 5;
            this.swipeGroup.TabStop = false;
            // 
            // projLabel
            // 
            this.projLabel.AutoSize = true;
            this.projLabel.Location = new System.Drawing.Point(9, 20);
            this.projLabel.Name = "projLabel";
            this.projLabel.Size = new System.Drawing.Size(43, 13);
            this.projLabel.TabIndex = 2;
            this.projLabel.Text = "Project:";
            // 
            // projCombo
            // 
            this.projCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projCombo.FormattingEnabled = true;
            this.projCombo.Location = new System.Drawing.Point(58, 17);
            this.projCombo.Name = "projCombo";
            this.projCombo.Size = new System.Drawing.Size(211, 21);
            this.projCombo.TabIndex = 1;
            this.projCombo.SelectionChangeCommitted += new System.EventHandler(this.projCombo_SelectionChangeCommitted);
            // 
            // clockedInGroup
            // 
            this.clockedInGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clockedInGroup.Controls.Add(this.clockedInLabel);
            this.clockedInGroup.Controls.Add(this.clockedInList);
            this.clockedInGroup.Location = new System.Drawing.Point(4, 67);
            this.clockedInGroup.Name = "clockedInGroup";
            this.clockedInGroup.Size = new System.Drawing.Size(276, 208);
            this.clockedInGroup.TabIndex = 6;
            this.clockedInGroup.TabStop = false;
            // 
            // hoursWorkedGroup
            // 
            this.hoursWorkedGroup.Controls.Add(this.clockOutBtn);
            this.hoursWorkedGroup.Location = new System.Drawing.Point(4, 329);
            this.hoursWorkedGroup.Name = "hoursWorkedGroup";
            this.hoursWorkedGroup.Size = new System.Drawing.Size(275, 43);
            this.hoursWorkedGroup.TabIndex = 8;
            this.hoursWorkedGroup.TabStop = false;
            // 
            // clockOutBtn
            // 
            this.clockOutBtn.Location = new System.Drawing.Point(6, 11);
            this.clockOutBtn.Name = "clockOutBtn";
            this.clockOutBtn.Size = new System.Drawing.Size(263, 26);
            this.clockOutBtn.TabIndex = 0;
            this.clockOutBtn.Text = "Clock Everyone Out";
            this.clockOutBtn.UseVisualStyleBackColor = true;
            this.clockOutBtn.Click += new System.EventHandler(this.clockOutBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.membersToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(285, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // membersToolStripMenuItem
            // 
            this.membersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAMemberToolStripMenuItem,
            this.viewAllMembersToolStripMenuItem,
            this.deleteAMemberToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.membersToolStripMenuItem.Name = "membersToolStripMenuItem";
            this.membersToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.membersToolStripMenuItem.Text = "&File";
            // 
            // addAMemberToolStripMenuItem
            // 
            this.addAMemberToolStripMenuItem.Name = "addAMemberToolStripMenuItem";
            this.addAMemberToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addAMemberToolStripMenuItem.Text = "Add a Member";
            this.addAMemberToolStripMenuItem.Click += new System.EventHandler(this.addAMemberToolStripMenuItem_Click);
            // 
            // viewAllMembersToolStripMenuItem
            // 
            this.viewAllMembersToolStripMenuItem.Name = "viewAllMembersToolStripMenuItem";
            this.viewAllMembersToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.viewAllMembersToolStripMenuItem.Text = "&View All Members";
            this.viewAllMembersToolStripMenuItem.Click += new System.EventHandler(this.viewAllMembersToolStripMenuItem_Click);
            // 
            // deleteAMemberToolStripMenuItem
            // 
            this.deleteAMemberToolStripMenuItem.Name = "deleteAMemberToolStripMenuItem";
            this.deleteAMemberToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteAMemberToolStripMenuItem.Text = "&Delete a Member";
            this.deleteAMemberToolStripMenuItem.Click += new System.EventHandler(this.deleteAMemberToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem1.Text = "&Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // RFIDLoggerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 279);
            this.Controls.Add(this.hoursWorkedGroup);
            this.Controls.Add(this.clockedInGroup);
            this.Controls.Add(this.swipeGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(301, 317);
            this.Name = "RFIDLoggerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFID Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RFIDLoggerMain_FormClosing);
            this.swipeGroup.ResumeLayout(false);
            this.swipeGroup.PerformLayout();
            this.clockedInGroup.ResumeLayout(false);
            this.clockedInGroup.PerformLayout();
            this.hoursWorkedGroup.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rfidButton;
        private System.Windows.Forms.ListBox clockedInList;
        private System.Windows.Forms.Label clockedInLabel;
        private System.Windows.Forms.GroupBox swipeGroup;
        private System.Windows.Forms.GroupBox clockedInGroup;
        private System.Windows.Forms.GroupBox hoursWorkedGroup;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem membersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addAMemberToolStripMenuItem;
        private System.Windows.Forms.Button clockOutBtn;
        private System.Windows.Forms.Label projLabel;
        private System.Windows.Forms.ComboBox projCombo;
    }
}

