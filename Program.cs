using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpellWork
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
            DBCReader.Run();
            Application.Run(new MainForm());
        }
    }
}
