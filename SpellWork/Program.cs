using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SpellWork
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                new Loader(!(args.Count() > 0 && args[0].ToLower() == "nothread"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SpellWork Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            Application.Run(new FormMain());
        }
    }
}
