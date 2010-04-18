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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(DBCReader.DBC_PATH + "Spell.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SpellRadius.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SpellRange.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SpellDuration.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SkillLineAbility.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SkillLine.dbc") ||
                !File.Exists(DBCReader.DBC_PATH + "SpellCastTimes.dbc"))
            {
                MessageBox.Show(String.Format("Files not found:\r\n" 
                    + "{0}Spell.dbc\r\n"
                    + "{0}SpellRadius.dbc\r\n"
                    + "{0}SpellRange.dbc\r\n"
                    + "{0}SpellDuration.dbc\r\n"
                    + "{0}SkillLineAbility.dbc\r\n"
                    + "{0}SkillLine.dbc\r\n"
                    + "{0}SpellCastTimes.dbc\r\n",
                    DBCReader.DBC_PATH),
                "SpellWork ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            DBCReader.Run();
            Application.Run(new MainForm());
        }
    }
}
