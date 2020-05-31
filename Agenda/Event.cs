using System.Windows.Forms;
using System;
using System.Drawing;

namespace Agenda
{
    public partial class Event : UserControl
    {
        public string title = "";//To hold the name of the event (eg. Dentist Appointment)
        public string date = "";// To hold the date of the event in long form (eg. September 7, 2000)
        public string time = "";//To hold the time of the event (eg. 1:13 PM, or 13:13, depending on whether the system uses 24-hour time or not)
        public string description = "";//To hold the description of the task (eg. Don't forget to floss!)
        public int unixTime = 0;//To hold the time of the event in unix time format, to make comparisons easier
        public Color color = new Color();//To hold the colour the title of the event should be displayed in

        /*Default constuctor for Event, requiring a name, date, description, time, time in unix time format all as Strings, as well as a color object*/
        public Event(string eventName, string eventDate, string eventDesc, string eventTime, string unixStr, Color eventColor)
        {
            InitializeComponent();
            lblName.Text = title = eventName;//Set the title var and the title label to the given title
            lblDate.Text = date = eventDate;//Set the date var and the date label to the given date
            lblDesc.Text = description = eventDesc;//Set the description var and the description label to the given description
            lblTime.Text = time = eventTime;//Set the time var and the time label to the given time
            lblName.ForeColor = color = eventColor;//Set the color var and the title label's color to the given color
            unixTime = Convert.ToInt32(unixStr);//Set the unix time to the provided string parsed to a 32-bit signed int
        }

        /*Event code for when the "Mark Done" button is clicked*/
        private void btnDismiss_Click(object sender, System.EventArgs e)
        {
            this.Parent.Parent.Controls.Remove(this.Parent);
            //Remove the Event's containing panel from the tableLayoutPanel
        }

        /*Event code for when the "Edit Task" button is clicked*/
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            MainView mv = (MainView)this.FindForm();//Find the form that this Event control resides on, cast it to a MainView object because we know that's what it will be.
            mv.dontHide = true;//Don't want the form to hide itself while we are editing the event, because that is what it wants to do

            EventCreate ec = new EventCreate();//We reuse the same form as we use when creating a new event, because there is no reason not to.
            ec.Text = "Edit Task";//We simply change the title from "New Task" to "Edit Task" to avoid confusion
            ec.label1.Text = "Edit Task...";
            ec.txtName.Text = this.title;//Put the event's existing title, description, and color into the EventCreate form
            ec.txtDesc.Text = this.description;
            ec.btnColor.BackColor = this.color;
            
            if(this.time != "")//So long as the event has a specified time
            {
                //Set the date and time pickers to the event's date + the event's time
                ec.datePick.Value = DateTime.Parse(this.date).Add(DateTime.Parse(this.time).TimeOfDay);
                ec.TimePick.Value = DateTime.Parse(this.date).Add(DateTime.Parse(this.time).TimeOfDay);
            }
            else//Otherwise no time is specified for this event
            {
                ec.datePick.Value = DateTime.Parse(this.date);//Set the date picker to the event's date              
                ec.TimePick.Checked = false;//Uncheck the timepicker
                ec.TimePick.Value = new DateTime(2000, 09, 07, 0, 0, 0);//Easter egg             
            }
            
            if (ec.ShowDialog() == DialogResult.OK)//Once the form closes successfully...
            {
                lblName.Text = this.title = ec.txtName.Text;//Update the event's title, description, date, color, unix time, etc
                lblDesc.Text = this.description = ec.txtDesc.Text;
                lblDate.Text = this.date = ec.datePick.Value.Date.ToLongDateString();
                lblName.ForeColor = this.color = ec.btnColor.BackColor;
                this.unixTime = ((int)ec.datePick.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds) + ec.TimePick.Value.Hour * 3600 + ec.TimePick.Value.Minute * 60 + ec.TimePick.Value.Second;
                if (!ec.TimePick.Checked)//If the timepicker was unchecked,
                {
                    lblTime.Text = this.time = "";//no time for this event
                }
                else//otherwise
                {
                    lblTime.Text = this.time = ec.TimePick.Value.TimeOfDay.ToString();//set the time as normal
                }                
                mv.update();//Update the events in the form. This means sort them, save them, etc
                mv.dontHide = false;//Form can resume auto-hiding like normal               
            }
        }

        /*Event code for when the use hovers their mouse over the '!'*/
        private void lblMark_MouseEnter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();//New tooltip object
            tt.InitialDelay = 0;//no delay on this son of a bitch
            tt.ShowAlways = true;//always show it
            tt.SetToolTip(lblMark, "Have you finished this task yet?\nClick \'Mark Done\' to dismiss this task.");//Set the tooltip's content, and bind it to the label
        }
    }
}
