using System;
using System.Windows.Forms;

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
                new Loader();
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SpellWork Eroor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}