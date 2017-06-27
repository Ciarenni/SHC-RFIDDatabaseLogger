/* remove members being read from file?
 *      try and pull member data from database. on failure, pull from file
 *      update the file in case the database cannot be contacted
 * remove edit, delete, view actions - they will be obsolete and will cause data inconsistency
 *      instead, update the member file with information from the database
 *      need some kind of flag that means the file and database are inconsistent
 *      chances are, it will be the file with the most recent data
 * turn this more into a database front-end rather than a standalone program
 *      offer ways to edit members, delete members (moves them to the past_members table), etc.
 *      
 * this is going to be a fairly massive overhaul... :/
 * 
 * complete - i suppose the first task is to populate the database
 *      need a program to parse the log file and insert the data into the database
 * after that, work on pulling the information from the database and updating the local member file
 *      update clocked_in list first, followed by member file
 *      if a DB connection cannot be created, set a flag and start saving the log to a separate file
 *          so it will not be overwritten in the update query. use flag to unhide a lab alerting me to
 *          swipes made without a DB connection. flag can be set by checking for the offline file
 * then, work on updating the database and local member file when someone swipes their tag
 * then, work on polling every so often to make sure the program is synced with the database
 * after that, implement a way for tags to be passed along (member leaves, new member gets a tag)
 *      should be pretty much done before it is started because of the local member file being
 *      updated every time the database is accessed
 * finally, add in ways to edit the database information using the program
 *      the database front-end part
 *      
 * after it works, look into having fewer delegates, now that i understand them better
 * sort functions into maybe DBconnection and local connection classes
 * 
 * NOTES: add a last swipe time to the internal DBmembers list? could lead to dirty data if the DB connection goes out
 * multiple DB connections for each operation maybe? one for updating the list, one for swipes, etc?
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MySql.Data.MySqlClient;

namespace RFID_Logger
{
    public partial class RFIDLoggerMain : Form
    {
        SerialPort port = new SerialPort();
        Thread updateThread;
        List<Member> members = new List<Member>();//holds all the members
        List<DBMember> DBmembers = new List<DBMember>();
        int memSize = 0;//number of members
        double Totalhours = 0;
        DateTime actHappened;
        enum ACTION { clocking, viewing, editing, deleting };
        delegate void SetClockedInListCallback(string name);

        ACTION action = ACTION.clocking;

        string location;
        
        const string TotalHoursRFID = "000000000000";

        MySqlConnection mySQLcon;
        MySqlCommand mySQLcomm;
        MySqlDataReader mySQLreader;
        bool nonDefault = false;
        System.Timers.Timer projTimer, updateTimer;
        delegate void updateFormCallback(string name, int which);
        const int CLOCKLISTIN = 0, CLOCKLISTOUT = 1, PROJCOMBO = 2, CLEARCLOCKLIST = 3;
        string projSelected = "Default";
        
        public RFIDLoggerMain()
        {
            InitializeComponent();
            updateThread = new Thread(update);
            location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            location = location.Substring(6);
            mySQLcon = new MySqlConnection("");//removed connection string since this is in a public repo
            mySQLcomm = mySQLcon.CreateCommand();

            rfidButton.Enabled = false;
            deleteAMemberToolStripMenuItem.Enabled = false;
            PortName pname = new PortName(this);

            pname.ShowDialog();

            if (!(Directory.Exists(location+"\\RFID files")))
            {
                Directory.CreateDirectory(location+"\\RFID files");
            }
            updateTimer = new System.Timers.Timer(5000);
            updateTimer.Elapsed += new ElapsedEventHandler(update);
            projTimer = new System.Timers.Timer(5000);
            projTimer.Elapsed += new ElapsedEventHandler(resetNonDefault);

            if (openDB())
            {
                projCombo.Items.Add("Default");
                mySQLcomm = mySQLcon.CreateCommand();
                mySQLcomm.CommandText = "select project_name from projects where active_project=1 order by project_id;";
                mySQLreader = mySQLcomm.ExecuteReader();
                while (mySQLreader.Read())
                {
                    projCombo.Items.Add(mySQLreader.GetValue(0));
                }
                mySQLreader.Close();
                queryDB();
                mySQLcon.Close();
            }
            else
            {
                projCombo.Items.Add("Default");
                projCombo.Items.Add("CubeSat");
                projCombo.Items.Add("Cansat 2012");
                projCombo.Items.Add("Mars Rover 2012");
                projCombo.Items.Add("BalloonSat");
                projCombo.Items.Add("Microgravity 2012");
                /*if (File.Exists(location + "\\RFID files\\Members.txt"))
                {
                    FileInfo f = new FileInfo(location + "\\RFID files\\Members.txt");   //sets file pointer
                    StreamReader read = f.OpenText();           //opens file for reading
                    while (!read.EndOfStream)                    //reads until end of file
                    {
                        string input = read.ReadLine();         //read in line by line

                        if (input.Length > 6)                   //so it doesnt try and read the \n char at the very
                        //end of the file and throw an error. leave at 6
                        {
                            string output = "";
                            char key = input[0];                //get the encryption key
                            for (int i = 1; i < input.Length; i++)
                            {
                                output += (char)(input[i] ^ key);//decrypt it, store as string
                            }
                            parseStrtoMember(output);           //turn the string into a Member object
                        }
                    }
                    read.Close();                               //close the file
                }
                if (memSize == 0)
                {
                    //create a fake member that holds the total hours of all past members
                    members.Add(new Member(TotalHoursRFID, 0, "totalHours", 0, false, DateTime.Now));
                    memSize++;
                    StoreAllMembers();
                }
                for (int i = 0; i < memSize; i++)
                {
                    if (members[i].getClockedIn() == true)
                        clockedInList.Items.Add(members[i].getName());
                }
                int j = FindMember(TotalHoursRFID, 1); ;
                Totalhours = members[j].getHoursWorked();*/
            }
            projCombo.SelectedIndex = 0;
            update();
            updateThread.Start();
        }

        public bool openDB()
        {
            try
            {

                mySQLcon.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Unable to connect to the database. Now working from local files.");
                return false;
            }
            return true;
        }

        public void closeDB()
        {
            if (mySQLcon.State != ConnectionState.Closed)
            {
                mySQLcon.Close();
            }
        }

        private void queryDB()
        {
            mySQLcomm.CommandText = "select * from members order by rfid_number;";
            mySQLreader = mySQLcomm.ExecuteReader();

            while (mySQLreader.Read())
            {
                DBmembers.Add(new DBMember(mySQLreader.GetValue(0).ToString(), (int)mySQLreader.GetValue(1), mySQLreader.GetValue(2).ToString(), (double)mySQLreader.GetValue(3), (int)mySQLreader.GetValue(4)));
                memSize++;
            }
        }

        //turns the string passed to it into a Member object
        private void parseStrtoMember(string toParse)
        {
            string rfid="", nme = "", data="";          //data holds the info that will be turned into Member's data
            int id = 0, curProj = -2;
            double hours = 0.0;
            
            int count = 0;                              //counts the number of delimiters encountered
                                                        //i used the pipe '|' as my delimiter

            for (int i = 0; i < toParse.Length; i++)
            {
                if (toParse[i] != '|')                  //if the character isnt a delimiter...
                {
                    data += toParse[i];                 //add it to the string
                }
                else if (toParse[i] == '|')             //if it is a delimiter...
                {
                    switch (count)                      //find out which one it is
                    {
                        case 0: 
                            rfid = data;            //first delimiter: RFID tag
                            count++;                    //increase number of delimiters encountered
                            data = "";                  //reset the data string for next data
                            break;
                        case 1: 
                            id = Convert.ToInt32(data);
                            count++;
                            data = "";
                            break;
                        case 2: nme = data;             //second delimiter: Name of member
                            count++;
                            data = "";
                            break;
                        case 3: hours = Convert.ToDouble(data);//third delimiter: hours worked
                            count++;
                            data = "";
                            break;
                        case 4: curProj = Convert.ToInt32(data);
                            count++;
                            data = "";
                            break;
                    }
                }
            }
            DBmembers.Add(new DBMember(rfid, id, nme, hours, curProj));//add the member to the list
            memSize++;                                  //increase the number of members
        }

        //Sorts the members using QuickSort
        //Parameters: the left and right of the list. Should always be 0 and memSize-1
        //do not hard code those in as it will break the recursion
        private void SortMembers(int left, int right)
        {//woo hoo QuickSort!
            int i = left, j = right;
            DBMember temp;
            int pivot = DBmembers[(left + right) / 2].getID();

            //partition
            while (i <= j)
            {
                while(DBmembers[i].getID().CompareTo(pivot) < 0)
                    i++;
                while(DBmembers[j].getID().CompareTo(pivot) > 0)
                    j--;
                if (i <= j)
                {
                    temp = DBmembers[i];
                    DBmembers[i] = DBmembers[j];
                    DBmembers[j] = temp;
                    i++;
                    j--;
                }
            }

            //recursion
            if (left < j)
                SortMembers(left, j);
            if (i < right)
                SortMembers(i, right);
        }

        private void rfidButton_Click(object sender, EventArgs e)
        {          
            setAction(Convert.ToInt32(ACTION.clocking));
        }

        private int FindMember(string rfid, int from)//from should be 0 only if coming from handleSwipe
        {
            for (int i = 0; i < memSize; i++)
            {
                if (rfid == DBmembers[i].getRFID())
                {
                    return i;
                }
            }
            if (from == 0)
            {
                AddMember(rfid);
                return -1;
            }

            return -2;
        }

        public int FindMemByName(string name)
        {
            for (int i = 0; i < memSize; i++)
            {
                if (members[i].getName() == name)
                    return i;
            }
            return -1;
        }

        private void AddMember(string rfid)
        {
            NewMember addMem = new NewMember(rfid, this, mySQLcon);
            addMem.ShowDialog();
        }

        public void AddMember(string rfid, int id, string name, int defaultProj)
        {//rework so it adds to the database
            //DB connection should still be open
            if (openDB())
            {
                mySQLcomm.CommandText = "insert into members values (\"" + rfid + "\"," + id.ToString() + ",\"" + name + "\",0.0," + defaultProj.ToString() + ");";
                mySQLcomm.ExecuteNonQuery();
                mySQLcon.Close();
            }
            else
            {
                DBmembers.Add(new DBMember(rfid, id, name, 0.0, defaultProj));
                memSize++;
                MessageBox.Show("New member added. Please swipe again if you wish to clock in.", "New Member added");
                SortMembers(0, memSize - 1);
                StoreAllMembers();
            }
        }

        private void handleSwipe(string tag, string project)
        {
            double hours;
            
            if (openDB())
            {// TODO fix this so the internal list is updated as well
                
                mySQLcomm.CommandText = "select rfid_tag from clocked_in where rfid_tag=\"" + tag + "\";";
                mySQLreader = mySQLcomm.ExecuteReader();
                if (mySQLreader.Read())
                {//member was clocked in, so clock them out
                    mySQLreader.Close();
                    mySQLcomm.CommandText = "insert into swipe_log(rfid_tag,swipe_time,clocking_in,worked_on_project) values (\"" + tag + "\",\"" + DateTime.Now.ToString("s") + "\",false,(select project_credited from clocked_in where rfid_tag=\"" + tag + "\"));";
                    mySQLcomm.ExecuteNonQuery();

                    mySQLcomm.CommandText = "select swipe_time from clocked_in where rfid_tag=\"" + tag + "\";";
                    mySQLreader = mySQLcomm.ExecuteReader();
                    if (mySQLreader.Read())
                    {
                        DateTime swipeTime = (DateTime)mySQLreader.GetValue(0);
                        TimeSpan difference = DateTime.Now - swipeTime;
                        mySQLreader.Close();
                        //update project hours
                        mySQLcomm.CommandText = "select project_hours from projects where project_id=(select project_credited from clocked_in where rfid_tag=\"" + tag + "\");";
                        mySQLreader = mySQLcomm.ExecuteReader();
                        if(mySQLreader.Read())
                        {
                            hours=(double)mySQLreader.GetValue(0);
                            hours += Math.Round(difference.TotalHours, 2);
                            mySQLreader.Close();
                            mySQLcomm.CommandText = "update projects set project_hours=" + hours.ToString() +
                                " where project_id=(select project_credited from clocked_in where rfid_tag=\"" + tag + "\");";
                            mySQLcomm.ExecuteNonQuery();
                        }
                        //update personal hours
                        mySQLcomm.CommandText = "select hours_worked,name from members where rfid_tag=\"" + tag + "\";";
                        mySQLreader = mySQLcomm.ExecuteReader();
                        if(mySQLreader.Read())
                        {
                            hours=(double)mySQLreader.GetValue(0);
                            updateForm(mySQLreader.GetValue(1).ToString(), CLOCKLISTOUT);
                            hours += Math.Round(difference.TotalHours, 2);
                            mySQLreader.Close();
                            mySQLcomm.CommandText = "update members set hours_worked=" + hours.ToString() + " where rfid_tag=\"" + tag + "\";";
                            mySQLcomm.ExecuteNonQuery();
                            
                        }
                    }
                    mySQLcomm.CommandText = "delete from clocked_in where rfid_tag=\"" + tag + "\";";
                    mySQLcomm.ExecuteNonQuery();
                    mySQLreader.Close();
                    mySQLcon.Close();
                }
                else
                {//member is clocking in
                    if (project == "Default")
                    {
                        mySQLreader.Close();
                        mySQLcomm.CommandText = "insert into swipe_log(rfid_tag,swipe_time,clocking_in,worked_on_project) values (\"" + tag + "\",\"" + DateTime.Now.ToString("s") + "\",false,(select default_project_id from members where rfid_tag=\"" + tag + "\"));";
                        mySQLcomm.ExecuteNonQuery();
                        mySQLcomm.CommandText = "insert into clocked_in values (\"" + tag + "\",\"" + DateTime.Now.ToString("s") + "\",(select default_project_id from members where rfid_tag=\"" + tag + "\"));";
                        mySQLcomm.ExecuteNonQuery();
                        //have drop-down box of projects that defaults to an option "default" after every swipe and will reset to default after X seconds, say 10
                    }
                    else
                    {
                        mySQLreader.Close();
                        mySQLcomm.CommandText = "insert into swipe_log(rfid_tag,swipe_time,clocking_in,worked_on_project) values (\"" + tag + "\",\"" + DateTime.Now.ToString("s") + "\",false,(select project_id from projects where project_name=\"" + project + "\"));";
                        mySQLcomm.ExecuteNonQuery();
                        mySQLcomm.CommandText = "insert into clocked_in values (\"" + tag + "\",\"" + DateTime.Now.ToString("s") + "\",(select project_id from projects where project_name=\"" + project + "\"));";
                        mySQLcomm.ExecuteNonQuery();
                    }
                    mySQLcomm.CommandText = "select name from members where rfid_tag=\"" + tag + "\";";
                    mySQLreader = mySQLcomm.ExecuteReader();
                    if (mySQLreader.Read())
                    {
                        updateForm(mySQLreader.GetValue(0).ToString(), CLOCKLISTIN);
                    }
                    mySQLreader.Close();
                    mySQLcon.Close();
                }
            }
            else
            {
                /*if (members[i].getClockedIn() == true)
                {
                    members[i].setClockedIn(false);

                    DateTime time = members[i].getLastSwiped();
                    TimeSpan oldHours = new TimeSpan(time.Ticks);
                    time = DateTime.Now;
                    TimeSpan newHours = new TimeSpan(time.Ticks);
                    double difference = Math.Round((newHours.TotalSeconds - oldHours.TotalSeconds)/3600.0, 2);

                    members[i].setHoursWorked(members[i].getHoursWorked() + difference);
                    members[i].setLastSwiped(DateTime.Now);
                    this.removeClockedInMember(members[i].getName());
                    //manageClockedInList(false, members[i].getName());
                    //clockedInList.Items.Remove(members[i].getName());
                }
                else
                {
                    members[i].setClockedIn(true);
                    members[i].setLastSwiped(DateTime.Now);
                    this.addClockedInMember(members[i].getName());
                    //manageClockedInList(true, members[i].getName());
                    //clockedInList.Items.Add(members[i].getName());
                }

            
                FileInfo f = new FileInfo(location + "\\RFID files\\RFID_Logger.log");
                StreamWriter logger = f.AppendText();
                string output = members[i].getRFID() + "\t" + members[i].getName() + " \t";
                if (members[i].getClockedIn() == true)
                    output += "clocking in\t" + Convert.ToString(DateTime.Now) + "\n";
                else if (members[i].getClockedIn() == false)
                    output += "clocking out\t" + Convert.ToString(DateTime.Now) + "\n";
                logger.Write(output);
                logger.Close();

                f = new FileInfo(location + "\\RFID files\\" + members[i].getRFID() + ".log");
                logger = f.AppendText();
                output = members[i].getRFID() + "\t" + members[i].getName() + " \t";
                if (members[i].getClockedIn() == true)
                    output += "clocking in\t" + Convert.ToString(DateTime.Now) + "\n";
                else if (members[i].getClockedIn() == false)
                    output += "clocking out\t" + Convert.ToString(DateTime.Now) + "\n";
                logger.Write(output);
                logger.Close();

                StoreAllMembers();*/
            }
            resetNonDefault();
        }

        private void addClockedInMember(string name)
        {
            if (this.clockedInList.InvokeRequired)
            {
                SetClockedInListCallback d = new SetClockedInListCallback(addClockedInMember);
                this.Invoke(d, new object[] { name });
            }
            else
            {
                this.clockedInList.Items.Add(name);
            }
        }

        private void removeClockedInMember(string name)
        {
            if (this.clockedInList.InvokeRequired)
            {
                SetClockedInListCallback d = new SetClockedInListCallback(removeClockedInMember);
                this.Invoke(d, new object[] { name });
            }
            else
            {
                this.clockedInList.Items.Remove(name);
            }
        }

        private void StoreAllMembers()
        {
            /*
            if (File.Exists(location + "\\RFID files\\Members.txt"))
                File.Delete(location + "\\RFID files\\Members.txt");
            int j = FindMember(TotalHoursRFID, 1);
            members[j].setHoursWorked(Totalhours);

            for (int i = 0; i < memSize; i++)
            {
                StoreMember(members[i].getData() + "|");
            }*/
        }

        private void StoreMember(string member)
        {
            Random rand = new Random();
            char key = (char)rand.Next(255);

            string output = "";
            bool okay = true;
            output += key;

            for (int i = 0; i < member.Length; i++)
            {
                if ((char)(member[i] ^ key) == '\n'
                    || (char)(member[i] ^ key) == '\r')     //make sure it doesn't make a \n or \r by accident
                {
                    okay = false;
                    break;
                }
                output += (char)(member[i] ^ key);
            }
            if (okay == true)
            {
                output += "\n";
                FileInfo f = new FileInfo(location + "\\RFID files\\Members.txt");
                StreamWriter logger = f.AppendText();
                logger.Write(output);
                logger.Close();
            }
            else
                StoreMember(member);
        }

        private void viewAllMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllMembers viewer = new ViewAllMembers(this, false, mySQLcon);
            viewer.Show();
        }

        private void deleteAMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Needs to be updated to work with this new version and the database.", "Obsolete function");
            //Password passwrd = new Password(this, 'd', port);
            //passwrd.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string output = "Someone remind Justin to update this help for this new version.";
            MessageBox.Show(output, "Help");
        }

        private void clockedInList_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.E && e.Control && e.Alt && !e.Shift)
            {
                Password passwrd = new Password(this, 'e', port);
                passwrd.ShowDialog();
            }*/
            if (e.KeyCode == Keys.Enter)
            {
                rfidButton_Click(sender, e);
            }
        }

        private void clockedInGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rfidButton_Click(sender, e);
            }
        }
        private void clockedInLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rfidButton_Click(sender, e);
            }
        }

        /*public string ClockedIn(string rfid)
        {
            int mem = FindMember(rfid, 1);
            if (mem == -2)
            {
                MessageBox.Show("Something went wrong looking for the member.", "Opps");
                return "-1";
            }
            else if (mem == -1)
            {
                MessageBox.Show("This tag is not tied to a member yet.\n" +
                    "Press the \"Read\" button and swipe the tag again to add a member.", "Not a member");
                return "-1";
            }
            else if(mem >= 0)
            {
                if (clockedInList.Items.Contains(members[mem].getName()))
                    return "true";
                else
                    return "false";
            }
            return "-1";
        }*/

        /*public void EditMember(string rfid, string edit)
        {
            int mem = FindMember(rfid, 1);
            string data = "";
            int count = 0;                              //counts the number of delimiters encountered
            //i used the pipe '|' as my delimiter

            if (mem >= 0)
            {
                for (int i = 0; i < edit.Length; i++)
                {
                    if (edit[i] != '|')                  //if the character isnt a delimiter...
                    {
                        data += edit[i];                 //add it to the string
                    }
                    else if (edit[i] == '|')             //if it is a delimiter...
                    {
                        switch (count)                      //find out which one it is
                        {
                            case 0: members[mem].setName(data);
                                count++;
                                data = "";
                                break;
                            case 1: members[mem].setHoursWorked(Math.Round(Convert.ToDouble(data), 2));
                                count++;
                                data = "";
                                break;
                            case 2:
                                if (data.ToLower() == "false")
                                    members[mem].setClockedIn(false);
                                else if (data.ToLower() == "true")
                                {
                                    members[mem].setClockedIn(true);
                                    if (!(clockedInList.Items.Contains(members[mem].getName())))
                                    {
                                        clockedInList.Items.Add(members[mem].getName());
                                        members[mem].setLastSwiped(DateTime.Now);
                                    }
                                }
                                count++;
                                data = "";
                                break;
                        }
                    }
                }

                StoreAllMembers();
            }
        }*/

        /*public void DeleteMember(int i)
        {
            FileInfo f1 = new FileInfo(location + "\\RFID files\\PastMembers.log");
            StreamWriter logger = f1.AppendText();
            FileInfo f2 = new FileInfo(location + "\\RFID files\\" + members[i].getRFID() + ".log");
            StreamReader reader = f2.OpenText();
            logger.WriteLine("*** Log of previous member: " + members[i].getName() + " ***");
            while (!(reader.EndOfStream))
            {
                logger.Write(reader.ReadLine());
            }
            reader.Close();
            logger.WriteLine("*** Total hours worked by previous member: " + members[i].getHoursWorked() + " ***");
            logger.WriteLine("*** End of previous member log ***");
            logger.Close();
            File.Delete(location + "\\RFID files\\" + members[i].getRFID() + ".log");
            Totalhours += members[i].getHoursWorked();

            members.Remove(members[i]);
            memSize--;
            StoreAllMembers();
        }*/

        public int getNumMembers()
        {
            return memSize;
        }

        public double getTotalHours()
        {
            double sum = Totalhours;
            for (int i = 1; i < memSize; i++)
            {
                sum += members[i].getHoursWorked();
            }
            return sum;
        }

        public string displayMembers(int mem, int value)
        {
            if (value == 0)
            {
                if (members[mem].getClockedIn())
                    return members[mem].getID() + " " + members[mem].getName() + " Clocked in: Yes";
                else
                    return members[mem].getID() + " " + members[mem].getName() + " Clocked in: No";
            }
            else
                return members[mem].getData("fancy");
        }

        public void ForceAllOut()
        {
            string name = "";
            for (int i = 0; i < clockedInList.Items.Count; i++)
            {
                if (openDB())
                {
                    clockedInList.SelectedIndex = 0;
                    name = clockedInList.SelectedItem.ToString();
                    mySQLcomm.CommandText = "select rfid_tag from members where name=\"" + name + "\";";
                    mySQLcomm.ExecuteReader();
                    if (mySQLreader.Read())
                    {
                        name = mySQLreader.GetValue(0).ToString();
                    }
                    mySQLreader.Close();
                    mySQLcon.Close();
                    handleSwipe(name,projSelected);
                }   
            }
        }

        private void addAMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tell Justin to update this as well for the new version.");
        }

        public void setPort(string portname)
        {
            port.BaudRate = 9600;
            port.PortName = portname;
            rfidButton.Enabled = true;
            deleteAMemberToolStripMenuItem.Enabled = true;
            port.DataReceived += new SerialDataReceivedEventHandler(readSwipe);
            port.Open();
        }

        public void setAction(int act)
        {
            switch (act)
            {
                case 0: action = ACTION.clocking;
                    this.Text = "RFID Logger";
                    break;
                case 1: action = ACTION.viewing;
                    this.Text = "RFID Logger - Viewing...";
                    break;
                case 2: action = ACTION.editing;
                    this.Text = "RFID Logger - Editing...";
                    break;
                case 3: action = ACTION.deleting;
                    this.Text = "RFID Logger - Deleting...";
                    break;
            }
            actHappened = DateTime.Now;
        }

        private string readingThread()
        {
            string memRFID = port.ReadLine();
            return memRFID;
        }

        private void readSwipe(object sender, SerialDataReceivedEventArgs e)
        {
            
            string memRFID;

            //Task<string> readThread = Task.Factory.StartNew<string>(() => readingThread()); //this line is causing the crash
            //memRFID = readThread.Result;
            memRFID = port.ReadLine();

            port.DiscardInBuffer();
            port.Close();
            Match pattern = Regex.Match(memRFID, @"\w\w\w\w\w\w\w\w\w\w\w\w");
            if (pattern.Success)
            {
                memRFID = pattern.Value;
                if (openDB())
                {
                    mySQLcomm.CommandText = "select rfid_tag from members where rfid_tag=\"" + memRFID + "\";";
                    mySQLreader = mySQLcomm.ExecuteReader();
                    if (mySQLreader.Read())
                    {
                        mySQLreader.Close();
                        mySQLcon.Close();
                        handleSwipe(memRFID,projSelected);
                    }
                    else
                    {
                        mySQLreader.Close();
                        mySQLcon.Close();
                        AddMember(memRFID);
                    }
                }
                /*
                int mem = FindMember(memRFID, 0);

                if (mem == -2)
                {
                    MessageBox.Show("Something went wrong looking for the member.", "Opps");
                    setAction(Convert.ToInt32(ACTION.clocking));
                }
                else if (mem == -1)
                {
                    if (action == ACTION.viewing)
                    {
                        MessageBox.Show("This tag is not tied to a member yet.\n" +
                        "Press the \"Read\" button and swipe the tag again to add a member.", "Not a member");
                    }
                    else if (action == ACTION.deleting)
                    {
                        MessageBox.Show("There is no one in the club with that tag.", "No member");
                    }
                    setAction(Convert.ToInt32(ACTION.clocking));
                }
                else if (mem >= 0)
                {
                    switch (action)
                    {
                        case ACTION.clocking: handleSwipe(mem);
                            break;
                        case ACTION.viewing: MessageBox.Show(members[mem].getData(), "Member data");
                            setAction(Convert.ToInt32(ACTION.clocking));
                            break;
                        /*case ACTION.editing: Thread editThread = new Thread(() => editingThread(mem));
                            editThread.Start();
                            setAction(Convert.ToInt32(ACTION.clocking));
                            break;
                        case ACTION.deleting: Thread delThread = new Thread(() => deletingThread(mem));
                            delThread.Start();
                            setAction(Convert.ToInt32(ACTION.clocking));
                            break;
                    }
                }*/
            }
            port.Open();
        }

        private void update()
        {
            updateTimer.Start();
        }

        private void update(object source, ElapsedEventArgs e)
        {
            if (openDB())
            {
                updateForm("", CLEARCLOCKLIST);
                mySQLcomm.CommandText = "select name from members m, clocked_in c where m.rfid_tag=c.rfid_tag;";
                mySQLreader = mySQLcomm.ExecuteReader();
                while (mySQLreader.Read())
                {
                    updateForm(mySQLreader.GetValue(0).ToString(), CLOCKLISTIN);
                }
                mySQLreader.Close();
                mySQLcon.Close();
            }
            /*port.Open();
            
            while (true)
            {
                if (DateTime.Now.Second > actHappened.Second + 4)
                    setAction(Convert.ToInt32(ACTION.clocking));//set action back to reading after 5 seconds
                if (port.IsOpen)
                {
                    if (port.BytesToRead > 0)
                    {
                        
                    }
                }
            }*/
        }

        private void editingThread(int mem)
        {
            /*if (members[mem].getClockedIn())
                handleSwipe(mem);

            EditMember edit = new EditMember(this, members[mem].getData());
            edit.ShowDialog();*/
        }

        public void startEditThread(int mem)
        {
            /*Thread editThread = new Thread(() => editingThread(mem));
            editThread.Start();
            setAction(Convert.ToInt32(ACTION.clocking));*/
        }

        private void deletingThread(int mem)
        {
            /*if (members[mem].getClockedIn())
                handleSwipe(mem);

            if (MessageBox.Show("Are you sure you want to delete this member?\n" + members[mem].getName(), "Delete a member",
                                    MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                DeleteMember(mem);
            }*/
        }

        private void clockOutBtn_Click(object sender, EventArgs e)
        {
            ForceAllOut();
        }

        private void RFIDLoggerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port.IsOpen)
            {
                port.DiscardInBuffer();
                port.Close();
            }
            updateThread.Abort();
            if(mySQLcon.State != ConnectionState.Closed)
                mySQLcon.Close();
        }

        private void clockedInList_DoubleClick(object sender, EventArgs e)
        {
            string name = clockedInList.SelectedItem.ToString();
            //get tag from DB using name here
            if (openDB())
            {
                mySQLcomm.CommandText = "select rfid_tag from members where name=\"" + name + "\";";
                mySQLreader = mySQLcomm.ExecuteReader();
                if (mySQLreader.Read())
                {
                    name = mySQLreader.GetValue(0).ToString();
                }
                mySQLreader.Close();
                mySQLcon.Close();
                handleSwipe(name,projSelected);//this is actually the rfid tag, not the member's name
            }
            //if(name.Length > 0)
            //    handleSwipe(FindMemByName(name));
        }

        private void resetNonDefault(object source, ElapsedEventArgs e)
        {
            projTimer.Stop();
            projSelected = "Default";
            nonDefault = false;
            updateForm("", PROJCOMBO);
        }

        private void resetNonDefault()
        {
            projTimer.Stop();
            projSelected = "Default";
            nonDefault = false;
            updateForm("", PROJCOMBO);
        }

        private void updateForm(string name, int which)
        {
            if (which == CLOCKLISTIN)
            {
                if (this.clockedInList.InvokeRequired)
                {
                    updateFormCallback d = new updateFormCallback(updateForm);
                    this.Invoke(d, new object[] { name, which });
                }
                else
                {
                    this.clockedInList.Items.Add(name);
                }
            }
            else if (which == CLOCKLISTOUT)
            {
                if (this.clockedInList.InvokeRequired)
                {
                    updateFormCallback d = new updateFormCallback(updateForm);
                    this.Invoke(d, new object[] { name, which });
                }
                else
                {
                    this.clockedInList.Items.Remove(name);
                }
            }
            else if (which == PROJCOMBO)
            {
                if (this.projCombo.InvokeRequired)
                {
                    updateFormCallback d = new updateFormCallback(updateForm);
                    this.Invoke(d, new object[] { name, which });
                }
                else
                {
                    this.projCombo.SelectedIndex = 0;
                }
            }
            else if (which == CLEARCLOCKLIST)
            {
                if (this.clockedInList.InvokeRequired)
                {
                    updateFormCallback d = new updateFormCallback(updateForm);
                    this.Invoke(d, new object[] { name, which });
                }
                else
                {
                    this.clockedInList.Items.Clear();
                }
            }
        }

        private void projCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            projTimer.Enabled = false;
            projTimer.Enabled = true;
            projSelected = projCombo.SelectedItem.ToString();
            projTimer.Start();
        }
    }
}
