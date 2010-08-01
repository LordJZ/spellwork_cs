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

            if (!File.Exists(DBC.DBC_PATH + "Spell.dbc")            ||
                !File.Exists(DBC.DBC_PATH + "SpellRadius.dbc")      ||
                !File.Exists(DBC.DBC_PATH + "SpellRange.dbc")       ||
                !File.Exists(DBC.DBC_PATH + "SpellDuration.dbc")    ||
                !File.Exists(DBC.DBC_PATH + "SkillLineAbility.dbc") ||
                !File.Exists(DBC.DBC_PATH + "SkillLine.dbc")        ||
                !File.Exists(DBC.DBC_PATH + "SpellCastTimes.dbc")   ||
                !File.Exists(DBC.DBC_PATH + "ScreenEffect.dbc")     ||
                !File.Exists(DBC.DBC_PATH + "OverrideSpellData.dbc"))
            {
                MessageBox.Show(String.Format("Files not found:\r\n" 
                    + "{0}Spell.dbc\r\n"
                    + "{0}SpellRadius.dbc\r\n"
                    + "{0}SpellRange.dbc\r\n"
                    + "{0}SpellDuration.dbc\r\n"
                    + "{0}SkillLineAbility.dbc\r\n"
                    + "{0}SkillLine.dbc\r\n"
                    + "{0}SpellCastTimes.dbc\r\n"
                    + "{0}ScreenEffect.dbc\r\n"
                    + "{0}OverrideSpellData.dbc\r\n",
                    DBC.DBC_PATH),
                "SpellWork ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
           
            new Loader(!(args.Count() > 0 && args[0].ToLower() == "nothread"));

            Application.Run(new FormMain());
        }
    }
}
