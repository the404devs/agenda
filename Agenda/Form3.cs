using System;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        /*Event code for when the "About" button is clicked*/
        private void btnAbout_Click(object sender, EventArgs e)
        {
            //Tell them a little bit about the program, who made it, how awesome he is, etc, etc
            MessageBox.Show("Agenda: Version 1.0.2\n10/22/18\nOwen Goodwin\nthe404.ml");
        }
    }
}
