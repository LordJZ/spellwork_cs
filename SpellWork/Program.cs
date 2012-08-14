using System;
using System.IO;
using System.Windows.Forms;
using SpellWork.Forms;

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

            try
            {
                DBC.DBC.Load();
                Application.Run(new FormMain());
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show(dnfe.Message, @"Missing required DBC file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, @"DBC file has wrong structure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, @"SpellWork Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
