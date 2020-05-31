using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda
{
    public partial class EventCreate : Form
    {
        public EventCreate()
        {
            InitializeComponent();
        }

        /*Event code for when the "Done" button is clicked*/
        private void btnDone_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")//If the textbox where the user inputs the name of the task is empty...
            {
                label2.Text = "Task name is required!";//Change the text from "Task Name:" to "Task name is required!"
                label2.ForeColor = Color.Red;//Turn the text red to really drive home our point
                return;//Stop executing the method
            }
            btnOK.PerformClick();//Otherwise, everything is a-ok, so click our top-secret invisible hidden button that will close this form with a DialogResult.OK           
        }

        /*Event code for when the colour button is clicked*/
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog()==DialogResult.OK)//Once a color has been chosen through the dialog that pops up on click,
            {
                btnColor.BackColor = this.colorDialog1.Color;//Make that color the background color of the button
            }
        }
    }
}
