using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace RFID_Logger
{
    public partial class Password : Form
    {
        char action;
        RFIDLoggerMain main;
        SerialPort port;

        public Password(RFIDLoggerMain main, char action, SerialPort port)
        {
            InitializeComponent();
            this.action = action;
            this.main = main;
            this.port = port;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text == "command")
            {
                if (action == 'e')
                {
                    this.Hide();
                    main.setAction(2);
                }
                else if (action == 'd')
                {
                    this.Hide();
                    main.setAction(3);
                }
            }
            else if (passwordBox.Text == "control")
            {
                if (action == 'e')
                {
                    this.Hide();
                    //ViewAllMembers viewer = new ViewAllMembers(main, true);
                    //viewer.Show();
                }
                else if (action == 'd')
                {
                    this.Hide();
                    main.setAction(3);
                }
            }
            this.Close();
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okayButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
