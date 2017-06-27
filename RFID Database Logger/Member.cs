using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RFID_Logger
{
    class Member
    {
        string RFID="no tag", name="no name";
        int id = 0;
        double hoursWorked=0.0;
        bool clockedIn=false;
        DateTime lastSwiped=DateTime.MinValue;

        public Member(string rfid, string nme)
        {
            RFID = rfid;
            name = nme;
        }
        public Member(string rfid, int id, string nme, double hours, bool clock, DateTime swiped)
        {
            RFID = rfid;
            this.id = id;
            name = nme;
            hoursWorked = hours;
            clockedIn = clock;
            lastSwiped = swiped;
        }
        ~Member()
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
        public void setClockedIn(bool clock)
        {
            clockedIn = clock;
        }
        public bool getClockedIn()
        {
            return clockedIn;
        }
        public void setLastSwiped(DateTime swiped)
        {
            lastSwiped = swiped;
        }
        public DateTime getLastSwiped()
        {
            return lastSwiped;
        }
        public string getData()
        {
            string outp = "";
            outp += RFID + "|" + Convert.ToString(id) + "|" + name + "|";
            outp += Convert.ToString(hoursWorked) + "|";
            outp += Convert.ToString(clockedIn) + "|";
            outp += Convert.ToString(lastSwiped);

            return outp;
        }
        public string getData(string fancy)
        {
            string outp = "";
            outp += Convert.ToString(id) + " | " + name + "\tHours worked: ";
            outp += Convert.ToString(hoursWorked) + "\tClocked in: ";
            outp += Convert.ToString(clockedIn) + "\n\tLast time swiped: ";
            outp += Convert.ToString(lastSwiped)+"\n";

            return outp;
        }
    }
}
