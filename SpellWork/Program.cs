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
                MessageBox.Show("Files not found:\r\n" 
                    + DBCReader.DBC_PATH + "Spell.dbc\r\n"
                    + DBCReader.DBC_PATH + "SpellRadius.dbc\r\n" 
                    + DBCReader.DBC_PATH + "SpellRange.dbc\r\n"
                    + DBCReader.DBC_PATH + "SpellDuration.dbc\r\n"
                    + DBCReader.DBC_PATH + "SkillLineAbility.dbc\r\n"
                    + DBCReader.DBC_PATH + "SkillLine.dbc\r\n" 
                    + DBCReader.DBC_PATH + "SpellCastTimes.dbc\r\n",
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
