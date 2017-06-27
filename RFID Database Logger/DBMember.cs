using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RFID_Logger
{
    class DBMember
    {
        string RFID="no tag", name="no name";
        int id = 0, currentProj = -2;
        double hoursWorked=0.0;

        public DBMember(string rfid, string nme)
        {
            RFID = rfid;
            name = nme;
        }
        public DBMember(string rfid, int id, string nme, double hours, int currentProj)
        {
            RFID = rfid;
            this.id = id;
            name = nme;
            hoursWorked = hours;
            this.currentProj = currentProj;
        }
        ~DBMember()
        {
        }
        public void setRFID(string rfid)
        {
            RFID = rfid;
        }
        public string getRFID()
        {
            return RFID;
        }
        public int getID()
        {
            return id;
        }
        public void setName(string nme)
        {
            name = nme;
        }
        public string getName()
        {
            return name;
        }
        public void setHoursWorked(double hours)
        {
            hoursWorked = hours;
        }
        public double getHoursWorked()
        {
            return hoursWorked;
        }
        public string getData()
        {
            string outp = "";
            outp += RFID + "|" + Convert.ToString(id) + "|" + name + "|";
            outp += Convert.ToString(hoursWorked) + "|" +currentProj;

            return outp;
        }
        public string getData(string fancy)
        {
            string outp = "";
            outp += Convert.ToString(id) + " | " + name + "\tHours worked: ";
            outp += Convert.ToString(hoursWorked) + "\tDefault project: " + currentProj + "\n";

            return outp;
        }
    }
}
