﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using SchoolAccountant.Forms;
using SchoolAccountant.Helpers;
using SchoolAccountant.Models;

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

            Application.Run(new Login());
        }
    }
}
