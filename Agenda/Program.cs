using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Agenda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Check if there is a ".agenda" directory in the user's AppData folder and create one if there isn't
            //This directory is where we store the user's tasks and preferences.
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.agenda\\");
            }

            //Get the key on the registry where entries are stored for applications to run at startup
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); 
            //Add a value for Agenda, with the path to the exe. Now Agenda will always open when the user starts their computer.
            rk.SetValue(Application.ProductName, Application.ExecutablePath);      

            Application.Run(new MainView());//Run the MainView form
        }
    }
}
