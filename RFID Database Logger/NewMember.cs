using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RFID_Logger
{
    public partial class NewMember : Form
    {
        RFIDLoggerMain main;
        MySqlConnection newMemCon;
        MySqlCommand newMemComm;
        MySqlDataReader newMemReader;

        public NewMember(string rfid, RFIDLoggerMain main, MySqlConnection mySQLcon)
        {
            this.main = main;
            newMemCon = mySQLcon;
            InitializeComponent();
            RFIDBox.Text = rfid;
            
            if (main.openDB())
            {
                projCombo.Items.Clear();
                newMemComm = newMemCon.CreateCommand();
                newMemComm.CommandText = "select project_name from projects where active_project=1 order by project_id;";
                newMemReader = newMemComm.ExecuteReader();
                while (newMemReader.Read())
                {
                    projCombo.Items.Add(newMemReader.GetValue(0));
                }
                newMemReader.Close();
                main.closeDB();
            }
            projCombo.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            int tag;
            bool num;
            int proj = -2;
            if (tagBox.Text.Trim().Length > 0 && nameBox.Text.Trim().Length > 0)
            {
                num=Int32.TryParse(tagBox.Text.Trim(), out tag);
                if (num)
                {
                    if (main.openDB())
                    {
                        newMemComm.CommandText = "select project_id from projects where project_name=\'" + projCombo.SelectedItem.ToString().Trim() + "\';";
                        newMemReader = newMemComm.ExecuteReader();
                        //going to have to close the connection here so it can be reopened in main
                        if (newMemReader.Read())
                        {
                            proj = (int)newMemReader.GetValue(0);
                        }
                        newMemReader.Close();
                    }
                    main.closeDB();
                    main.AddMember(RFIDBox.Text, Convert.ToInt32(tagBox.Text.Trim()), nameBox.Text.Trim(), proj);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please be sure the Tag# is an actual integer.", "Tag# not a number");
                }
            }
            else
            {
                MessageBox.Show("Please be sure all fields have data in them.", "Empty fields");
            }
        }

        private void tagBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okayButton_Click(sender, e);
            }
        }

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okayButton_Click(sender, e);
            }
        }
    }
}
