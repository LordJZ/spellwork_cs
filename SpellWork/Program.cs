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
            var path = @"dbc\"; 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(path + "Spell.dbc") ||
                !File.Exists(path + "SpellRadius.dbc") ||
                !File.Exists(path + "SpellRange.dbc") ||
                !File.Exists(path + "SpellDuration.dbc") ||
                !File.Exists(path + "SkillLineAbility.dbc") ||
                !File.Exists(path + "SkillLine.dbc") ||
                !File.Exists(path + "SpellCastTimes.dbc"))
            {
                MessageBox.Show("Files not found:\r\n" + path + "Spell.dbc\r\n" + path + "SpellRadius.dbc\r\n" + path + "SpellRange.dbc\r\n"
                + path + "SpellDuration.dbc\r\n" +
                "" + path + "SkillLineAbility.dbc\r\n" + path + "SkillLine.dbc\r\n" + path + "SpellCastTimes.dbc\r\n",
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
