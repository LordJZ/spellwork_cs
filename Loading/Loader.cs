using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpellWork
{
    class Loader
    {
        private Thread m_thread;
        //private List<ReaderThread> m_readers;

        public Loader()
        {
            //m_readers = new List<ReaderThread> { null, null };
            m_thread = new Thread(new ThreadStart(this.run));
            m_thread.Start();
        }

        // Thread proc
        void run()
        {
            // First we load DBC files
            string path = @"./dbc/";

            try
            {
                DateTime starttime = DateTime.Now;
                Dictionary<uint, string> nullStringDict = null;

                Program.loadingForm.SetProgressBarSize(6);

                DBC.Spell = DBCReader.ReadDBC<SpellEntry>(path + "Spell.dbc", ref DBC._SpellStrings);
                DBC.SpellRadius = DBCReader.ReadDBC<SpellRadiusEntry>(path + "SpellRadius.dbc", ref nullStringDict);
                DBC.SpellRange = DBCReader.ReadDBC<SpellRangeEntry>(path + "SpellRange.dbc", ref DBC._SpellRangeStrings);
                DBC.SpellDuration = DBCReader.ReadDBC<SpellDurationEntry>(path + "SpellDuration.dbc", ref nullStringDict);
                DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(path + "SkillLineAbility.dbc", ref nullStringDict);
                DBC.SkillLine = DBCReader.ReadDBC<SkillLineEntry>(path + "SkillLine.dbc", ref DBC._SkillLineStrings);

                Program.loadingForm.SetLabelText("Detecting DBC locale...");
                // Currently we use entry 1 from Spell.dbc to detect DBC locale
                byte DetectedLocale = 0;
                while(DBC.Spell.LookupEntry<SpellEntry>(1).getName(DetectedLocale) == "")
                    ++DetectedLocale;
                
                Program.loadingForm.SetLabelText("Finished, took " +
                    ((float)(Time.MsDiff(starttime, DateTime.Now)) / 1000.0f).ToString() +
                    " seconds. DBC Locale: " + DetectedLocale.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Program.loadingForm._Close();
        }

        public void Close()
        {
            if (m_thread != null)
            {
                m_thread.Abort();
                m_thread = null;
            }

            /*for(int i = 0; i < m_readers.Count; ++i)
            {
                if(m_readers[i] != null)
                    m_readers[i].Close();
            }*/
        }
    }
}