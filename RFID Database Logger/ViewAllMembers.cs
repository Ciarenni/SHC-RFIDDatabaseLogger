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
    public partial class ViewAllMembers : Form
    {
        RFIDLoggerMain main;
        bool edit;
        MySqlConnection viewSQLcon;
        public ViewAllMembers(RFIDLoggerMain logger, bool edit, MySqlConnection sqlcon)
        {
            InitializeComponent();
            this.main = logger;
            this.edit = edit;
            this.viewSQLcon = sqlcon;
            int num = main.getNumMembers();
            if (num > 0)
            {
                totalHoursValue.Text = main.getTotalHours().ToString();
            }
            if (num > 1)
            {
                for (int i = 1; i < num; i++)
                {
                    membersListBox.Items.Add(main.displayMembers(i, 0));
                }
            }
            else
                MessageBox.Show("There are no members to view. Please add one and try again.", "No members");
        }

        private void okayBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void membersListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int mem;
            string memToFind = membersListBox.SelectedItem.ToString();
            if (!edit)
            {
                if (memToFind.Length > 0)
                {
                    string[] array = memToFind.Split(' ');
                    mem = main.FindMemByName(array[1] + " " + array[2]);
                    if (mem > 0)
                    {
                        MessageBox.Show(main.displayMembers(mem, 1));
                    }
                }
            }
            else
            {
                if (memToFind.Length > 0)
                {
                    string[] array = memToFind.Split(' ');
                    mem = main.FindMemByName(array[1] + " " + array[2]);
                    main.startEditThread(mem);
                }
            }
        }
    }
}
