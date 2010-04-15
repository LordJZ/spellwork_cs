using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpellWork
{
    static class Program
    {
        public static Loader loader;
        public static LoadingForm loadingForm;
        public static MainForm mainForm;
        public static bool StopEvent;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loadingForm = new LoadingForm();
            
            // We need 'loadingForm' to be set
            loader = new Loader();

            Application.Run(loadingForm);

            // 'loader' must complete it's work to this time
            // but user can manually close the window
            // or something bad can happen
            if (loader != null)
            {
                loader.Close();
                loader = null;
            }

            if (StopEvent)
                return;

            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
