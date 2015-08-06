using System;
using System.Windows.Forms;
using SchoolAccountant.Forms;

namespace SchoolAccountant
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
           
            // todo: remove the "femi", change to login
            Application.Run(new DashBoard("Femi"));
        }
    }
}
