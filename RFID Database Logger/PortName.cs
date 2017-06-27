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
    public partial class PortName : Form
    {
        RFIDLoggerMain main;
        bool exit = true;
        public PortName(RFIDLoggerMain main)
        {
            InitializeComponent();
            this.main = main;
            comCombo.Items.AddRange(SerialPort.GetPortNames());

            if (SerialPort.GetPortNames().Length > 1)
                comCombo.SelectedIndex = 1;
            else if (SerialPort.GetPortNames().Length > 0)
                comCombo.SelectedIndex = 0;
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            string name = comCombo.SelectedItem.ToString();
            exit = false;
            if (name.Length > 0)
            {
                main.setPort(name);
                this.Close();
            }
        }

        private void portBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okayButton_Click(sender, e);
            }
        }

        private void PortName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                Application.Exit();
            }
        }
    }
}
