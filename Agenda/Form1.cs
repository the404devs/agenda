using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Agenda
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private bool showNotifs = true;//Bool to indicate whether the user wants us to spam them with notifications on startup
        private bool autoDelete = false;//Bool to indicate whether the user wants us to remove old events from the list without any warning
        public bool dontHide = false;//Bool to indicate whether or not the form should actually be hidden when it tries to hide.
        private bool actuallyClose = false;//Bool to indicate whether or not the form should close when the user tries to close it

        /*Method to update the list of events that appears in the form.
         * Usually occurs after an event has been added, modified, or removed*/
        public void update()
        {
            List<Event> events = new List<Event>();//New list to hold all of the events
            foreach (Panel p in this.tableLayoutPanel1.Controls)//Loop through each panel in the tablelayoutpanel
            {
                Event ev = (Event)p.Controls[0];//Get the event control inside that panel. We know it'll be the only control in the panel.
                events.Add(ev);//Add that event control to the list
            }
            sortEvents(events);//sort the list
            saveEvents();//save the events to the data file
            //Basically remove all of the controls from the tableLayoutPanel and reset everything
            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            loadEvents();//Reload all of the events into the form, now sorted all nicely.
            markOldTasks();//Call this to flag any tasks that the user mistakenly set to a date in the past, so they won't just disappear if they have the application set to auto-remove old tasks.
        }

        /*Method to load the events from the data file into the form
         * Called on startup, and once per call to update()*/
        private void loadEvents()
        {
            //Begin reading from the data file. We don't need to check if it exists, because that's literally the first thing the program does on startup
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\data.txt");
            string line = sr.ReadLine();//Get the first line of the file
            List<Event> events = new List<Event>();//Initiate a new list to hold all of the events that we load
            while (line != "" && line != null)//Continue until we reach a line that is empty
            {                 
                string[] data = line.Split('\t');//split each line into an array by tabs, since we separate each piece of info with a tab
                //add a new event control to the list with each piece of data from that line
                events.Add(new Event(data[0], data[1], data[2], data[3], data[4], Color.FromArgb(int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]))));
                line = sr.ReadLine();//Get the next line
            }
            sortEvents(events);//Sort the events, just in case. Presumably, they're already sorted, but who knows?
            foreach(Event e in events)//Loop through each of the events we just created
            {
                Panel p = new Panel();//Create a panel to hold the event
                p.BackColor = Color.Black;//Set some basic properties of the panel
                p.Width = tableLayoutPanel1.Width;
                p.Height = 120;
                p.Controls.Add(e);//Add the event to the panel
                this.tableLayoutPanel1.Controls.Add(p);//and add the panel to the tableLayoutPanel
            }
            sr.Close();//Stop reading from the file to prevent those damn IOExceptions
        }

        /*Method to save the events to the data file
         * Called on exit and once per call to update()*/
        private void saveEvents()
        {
            string everything = "";//New string object to hold... you guessed it...
            foreach (Panel p in this.tableLayoutPanel1.Controls){//Loop through each panel in the tableLayoutPanel
                Event e = (Event) p.Controls[0];//Retrieve the first control in that panel and save it as an Event object. Might sound sketch, but the only control in those panels will be an Event control, trust me.
                Color col = e.color;//apparently using e.color directly in the next line could cause runtime errors
                //Create a string with each piece of data the event has, separated by tabs. This will be a line in the data file
                string eventData = e.title + "\t" + e.date + "\t" + e.description + "\t" + e.time + "\t" + e.unixTime + "\t" + col.R + "\t" + col.G + "\t" + col.B + "\r\n";
                everything += eventData;//add that line to the big string
            }
            //Begin writing to the data file
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\data.txt",false);
            sw.WriteLine(everything);//Write everything to the file
            sw.Close();//Close the file
        }

        /*Method to sort the events in chronological order.
         * Called once per call to update() and once per call to loadEvents(), so technically twice per call to update()
         Requires a list of Event controls as a parameter*/
        private void sortEvents(List<Event> events)
        {
            //Some classic bubble sorting, which you can never stop me from using
            for (int x = 0; x < events.Count-1; x++)
            {
                for (int y = 0; y < events.Count-1; y++)
                {
                    if (events[y].unixTime > events[y+1].unixTime)//We compare based on the unix time of each event
                    {
                        Event temp = events[y + 1];
                        events[y + 1] = events[y];
                        events[y] = temp;
                    }
                }
            }
        }

        /*Method to bring the form into view. 
         * Called when the user selects "Show Agenda" in the menu*/
        private void reveal()
        {
            this.Show();//Show the form
            this.WindowState = FormWindowState.Normal;//Make it normal. (Basically means make it normal-sized)
            this.TopMost = true;//Temporarily make it the top-most form
            this.Focus();//Give it focus
            this.BringToFront();//Stick it in front of everything else
            this.TopMost = false;//Don't need it to be top-most anymore, now that we're done.
        }

        /*Method to show notifications of today's tasks
         * Called on startup, if the user has specified to do so and whenever "Show Today's Tasks" is selected in the menu.*/
        private void today()
        {
            int b = 0;//Counter var
            int lines = 0;//To keep track of how many lines we've created, because each notification can only show 4 lines of text.
            string[] briefings = new string[20];//Array to hold notification text for max. 20 notifications
            /*Each notification can hold 4 lines of text, meaning we can show reminders for 4 tasks ber notification.
             * We've set that limit of 20 notifications, because even that is a bit excessive to show the user at startup.
             * This means we can show, at most, reminders for 80 tasks. I feel this is a pretty safe limit, 
             * because what kind of nutjob would schedule mroe than 80 different things on the same day?*/
            
            foreach (Panel p in this.tableLayoutPanel1.Controls)//Loop through each panel in the tableLayoutPanel
            {                
                Event e = (Event)p.Controls[0];//Retrieve the event control in that panel
                //if(e.date == DateTime.Now.Date.ToLongDateString())//Check if that event's date is today's date
                if (e.unixTime == ((int)DateTime.Now.Date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds))//Check if the event's date is today
                {
                    if (e.time != "")//If a time is specified...
                    {
                        briefings[b] += e.title + " at: " + e.time + "\r\n";//Create a line that states the event's name and time
                    }
                    else//If no time is specified...
                    {
                        briefings[b] += e.title + ": All day\r\n";//Create a line that states the event and "all day"
                    }
                    lines++;//Increment our line counter
                    if (lines == 4)//If we've reached our maximum 4 lines of text...
                    {
                        lines = 0;//Reset the counter
                        b++;//Move to the next slot out of the 20
                    }
                }
                else if (e.unixTime < ((int)DateTime.Now.Date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)) {//Check if the task was set for a date in the past:
                    briefings[b] += e.title + ": Late!\r\n";//uh oh
                    lines++;
                    if(lines==4)
                    {
                        lines = 0;
                        b++;
                    }
                }
            }
            if (briefings[0] == null)//if the first slot of the notifications is empty...
            {
                this.notifyIcon1.BalloonTipText = "No tasks for today!";//They've got nothing going on today.
                this.notifyIcon1.BalloonTipTitle = "Today's Tasks";//Standard title on the notification
                this.notifyIcon1.ShowBalloonTip(1000);//Should appear for minimum 1 second
            }
            else//otherwise we do have tasks to show
            {
                foreach (String brief in briefings)//Loop through each slot in the array of notifications
                {
                    if (brief != null && brief != "")//Make sure the slot has something in it before we try and display it 
                    {
                        this.notifyIcon1.BalloonTipText = brief;//Set the notification text to the text found in that slot
                        this.notifyIcon1.BalloonTipTitle = "Today's Tasks";//Standard notification title
                        this.notifyIcon1.ShowBalloonTip(1000);//Should appear for max. 1 second
                    }
                }
            }            
        }

        /*Method to remove old tasks from the to-do list
         * Called on startup, if the user has specified they wish for old tasks to be removed automatically*/
        private void removeOldTasks()
        {
            foreach(Panel p in this.tableLayoutPanel1.Controls)//Loop through each panel in the tableLayoutPanel
            {
                Event e = (Event)p.Controls[0];//Get the event from that panel
                //By comparing the unix time of that event to the unix time at the start of today, we can determine if that event was set for a day before today
                if (e.unixTime < ((int)DateTime.Now.Date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds))
                {
                    this.tableLayoutPanel1.Controls.Remove(p);//Delete that panel, if the event was scheduled in the past
                }
            }
        }

        /*Method to mark old tasks as an alternative to auto-deleting them
         * Called on startup, if the user has specified they do not wish for old tasks to be removed automatically*/
        private void markOldTasks()
        {
            foreach (Panel p in this.tableLayoutPanel1.Controls)//Loop through each panel in the tableLayoutPanel
            {
                Event e = (Event)p.Controls[0];//Get the event residing in that panel
                //By comparing the unix time of that event to the unix time at the start of today, we can determine if that event was set for a day before today
                if (e.unixTime < ((int)DateTime.Now.Date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds))
                {
                    e.lblMark.Visible = true;//Each Event control has an invisible label with a big red '!' that we will now make visible if this event was scheduled sometime in the past.
                }
            }
        }

        /*Event code for when the form first loads.*/
        private void MainView_Load(object sender, EventArgs e)
        {
            //First things first, check if a data file already exists.
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\data.txt"))
            {                
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\data.txt").Close();  
                //If one doesn't exist, we create one.
            }                
            loadEvents();//Retrieve all of the saved events from the data file
            notifyIcon1.Visible = true;//Show the icon in the taskbar

            //Similarly, we now check if there's a preference file saved...
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt").Close();
                //...and we make one if there isn't...
            }
            else
            {
                //.. but if there is we read the contents of the file
                StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt");
                string notifPref = sr.ReadLine();//Get their preference for showing the "Today's tasks" popup
                this.showNotifs = bool.Parse(notifPref.Substring(15));//Parse it to a bool value
                string delPref = sr.ReadLine();//Get the preference for auto-deleting old stuff
                this.autoDelete = bool.Parse(delPref.Substring(12));//Parse it too a bool value
                sr.Close();//Stop reading from the file
            }

            if (this.autoDelete)//If they've told us to delete old events...
                removeOldTasks();//...do it...
            else
                markOldTasks();//...or else just flag them as old

            if (this.showNotifs)//If they've told us to show the notification on startup...
                today();//..do it
        }

        /*Event code for when the form is resized*/
        private void MainView_Resize(object sender, EventArgs e)
        {
            //If the form was minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();//hide the form. This means it won't show a big icon in the taskbar
                notifyIcon1.Visible = true;//show the little icon on the bottom-right
            }
        }

        /*Event code for when the form is no longer active (ie the user clicks outside the form)*/
        private void MainView_Deactivate(object sender, EventArgs e)
        {
            if (!this.dontHide)//Unless we're not supposed to hide the window right now,
            {
                this.WindowState = FormWindowState.Minimized;//minimize the window
                this.Hide();//hide it
                this.notifyIcon1.Visible = true;//show the taskbar icon
            }            
        }

        /*Event code for when the form is about to close*/
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.actuallyClose)//Unless we actually want the application to close,
            {
                e.Cancel = true;//quietly cancel this event
                MainView_Deactivate(sender, e);//call the deactivate event instead
            }
        }

        /*Event code for when the form is truly closed*/
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveEvents();//Save the events as they currently appear
            this.notifyIcon1.Visible = false;//get rid of the taskbar icon
        }

        /*Event code for when the "New Event" button is pressed*/
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.dontHide = true;//Set this to true, or else the main form would disappear once they interact with the new event popup, which would in turn take away the popup too.
            EventCreate ec = new EventCreate();//New instance of the EventCreate form
            ec.datePick.Value = DateTime.Today;//Set the date-picker's value to today's date
            if (ec.ShowDialog() == DialogResult.OK)//Once the form closes successfully
            {
                string evtName = ec.txtName.Text;//Retrieve all of the information inputted in the form
                string evtDesc = ec.txtDesc.Text;
                string evtDate = ec.datePick.Value.Date.ToLongDateString();
                string evtTime = ec.TimePick.Value.TimeOfDay.ToString();
                Color evtColor = ec.btnColor.BackColor;
                //Calculate the unix time of the event
                int evtUnix = ((int)ec.datePick.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds) + ec.TimePick.Value.Hour * 3600 + ec.TimePick.Value.Minute * 60 + ec.TimePick.Value.Second;
                if (!ec.TimePick.Checked)//If the time-picker was unchecked, they dont want to specify a time
                {
                    evtTime = "";//set the time to an empty string
                }
                Panel newPanel = new Panel();//Create a new panel to stuff everything into
                newPanel.BackColor = Color.Black;//Set the properties of the panel
                newPanel.Width = tableLayoutPanel1.Width;
                newPanel.Height = 120;
                //Add a new event control to the panel, with all the information we retrieved from the EventCreate form
                newPanel.Controls.Add(new Event(evtName, evtDate, evtDesc, evtTime, evtUnix.ToString(), evtColor));
                this.tableLayoutPanel1.Controls.Add(newPanel);//Add that new panel to our table layout thing
                update();//Update the view
            }
            this.dontHide = false;//Now that all that is done, the form can self-hide like normal now.
        }

        /*Event code for when the "Preferences" button is pressed.*/
        private void btnPref_Click(object sender, EventArgs e)
        {
            this.dontHide = true;//Set this to true, or else the main form would disappear once they interact with the new event popup, which would in turn take away the popup too.//Set this to true, or else the main form would disappear once they interact with the new event popup, which would in turn take away the popup too.
            Settings s = new Settings();//new instance of the Settings form
            s.chkNotif.Checked = this.showNotifs;//Set the two checkboxes in the form to match the current preferences.
            s.chkDelete.Checked = this.autoDelete;
            if (s.ShowDialog() == DialogResult.OK)//Once the form closes successfully...
            {
                MessageBox.Show("Your preferences were saved successfully.");//Messagebox to tell them everything went better than expected
                this.showNotifs = s.chkNotif.Checked;//Retrieve the new state of each checkbox after they've finished
                this.autoDelete = s.chkDelete.Checked;
                //Failsafe check to make sure a preference file exists
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt"))
                {
                    File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt").Close();
                }
                //Save their preferences neatly formatted in the preference file, then close the file.
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\pref.txt");
                sw.WriteLine("Notifications: " + this.showNotifs.ToString() + "\nAutoDelete: " + this.autoDelete.ToString());
                sw.Close();
            }
            this.dontHide = false;//Can now let the form hide itself like normal
        }

        /*Event code for after the taskbar icon is clicked*/
        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//Quick check to see if it was the left button
            {                
                //Get the ShowContextMenu event of the notfiyicon, and then invoke it.
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
                //This action takes place by default when the icon is right-clicked, we just do this so the same thing happens when left-clicked too.
            }
        }

        /*Event code for when the "Open Agenda" menu option is clicked.*/
        private void openAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reveal();//Show the form.
        }        

        /*Event code for when the "Show Today's Tasks" menu option is clicked*/
        private void showTodaysTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            today();//Simply show today's tasks. What did you expect?
        }  

        /*Event code for when the "Quit" menu option is clicked*/
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dontHide = true;//Don't hide the form while we try to close it. That would make things tricky, like a victim hiding from a killer, and we don't want that.
            this.actuallyClose = true;//Yes, we are 100% sure we actually want the form to close now.
            Application.Exit();//bye bye
        }
    }
}
