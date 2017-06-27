namespace RFID_Logger
{
    partial class PortName
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
            this.okayButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.comCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(184, 4);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(75, 23);
            this.okayButton.TabIndex = 1;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 9);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(60, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port Name:";
            // 
            // comCombo
            // 
            this.comCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCombo.FormattingEnabled = true;
            this.comCombo.Location = new System.Drawing.Point(78, 6);
            this.comCombo.Name = "comCombo";
            this.comCombo.Size = new System.Drawing.Size(100, 21);
            this.comCombo.TabIndex = 2;
            // 
            // PortName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 32);
            this.Controls.Add(this.comCombo);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.okayButton);
            this.MinimumSize = new System.Drawing.Size(279, 70);
            this.Name = "PortName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortName";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortName_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.ComboBox comCombo;
    }
}