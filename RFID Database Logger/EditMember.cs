using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFID_Logger
{
    public partial class EditMember : Form
    {
        RFIDLoggerMain main;
        string member;

        public EditMember(RFIDLoggerMain main, string member)
        {
            InitializeComponent();
            this.main = main;
            this.member = member;
            Parse();
        }

        private void Parse()
        {
            string data = "";
            int count = 0;                              //counts the number of delimiters encountered
                                                        //i used the pipe '|' as my delimiter

            for (int i = 0; i < member.Length; i++)
            {
                if (member[i] != '|')                  //if the character isnt a delimiter...
                {
                    data += member[i];                 //add it to the string
                }
                else if (member[i] == '|')             //if it is a delimiter...
                {
                    switch (count)                      //find out which one it is
                    {
                        case 0: rfidBox.Text = data;            //first delimiter: RFID tag
                            count++;                    //increase number of delimiters encountered
                            data = "";                  //reset the data string for next data
                            break;
                        case 1: tagBox.Text = data;
                            count++;
                            data = "";
                            break;
                        case 2: nameBox.Text = data;             //second delimiter: Name of member
                            count++;
                            data = "";
                            break;
                        case 3: hoursBox.Text = data;//third delimiter: hours worked
                            count++;
                            data = "";
                            break;
                        case 4:                         //fourth delimiter: whether member is clocked in or not
                            if (data.ToLower() == "false")
                                clockBox.SelectedIndex = clockBox.FindString("False");
                            else if (data.ToLower() == "true")
                                clockBox.SelectedIndex = clockBox.FindString("True");
                            count++;
                            data = "";
                            break;
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            bool cont = true;
            for (int i = 0; i < hoursBox.Text.Length; i++)
            {
                if (hoursBox.Text[i] == '.')
                    count++;
                if (!(((hoursBox.Text[i] >= '0' && hoursBox.Text[i] <= '9')
                    || hoursBox.Text[i] == '.') && count <= 1))
                {
                    okayButton.Enabled = false;
                    MessageBox.Show("Hours worked must be a positive number with only 1"+
                        "decimal point.", "Check hours");
                    cont = false;
                    break;
                }
            }

            if (cont == true)
            {
                string edit = nameBox.Text + "|"+hoursBox.Text+"|";
                if (clockBox.SelectedIndex == clockBox.FindString("True"))
                {
                    edit += "true|";
                }
                else if (clockBox.SelectedIndex == clockBox.FindString("False"))
                {
                    edit += "false|";
                }
                //main.EditMember(rfidBox.Text,edit);
                this.Close();
            }
        }
    }
}
