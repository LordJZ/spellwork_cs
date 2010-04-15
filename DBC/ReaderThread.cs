using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using SpellWork;

namespace SpellWork
{
    /*struct DBC_FileInfo
    {
        public DBC_FileInfo(string _name, DBCFileEntries _idx, String[][] _struct)
        {
            name = _name;
            fileIndex = _idx;
            structure = _struct;
        }

        public string name;
        public DBCFileEntries fileIndex;
        public String[][] structure;
    }
    class ReaderThread
    {
        private Thread m_thread;
        private int m_threadId;
        private string m_path;
        private List<DBC_FileInfo> m_dbcs;
        public bool Complete { get; set; }

        public ReaderThread(int lThreadId, string path, List<DBC_FileInfo> dbcs)
        {
            m_path = path;
            m_thread = new Thread(new ThreadStart(this.run));
            m_dbcs = dbcs;
            m_threadId = lThreadId;

            m_thread.Start();
        }

        // Thread proc
        void run()
        {
            DateTime starttime = DateTime.Now;
            foreach (DBC_FileInfo dbc in m_dbcs)
            {
                Program.loadingForm.SetLabelText(m_threadId, "Loading " + dbc.name);
                DataTable table = new DataTable();
                DBCReader r = new DBCReader(m_path + dbc.name, table, dbc.structure, m_threadId);
                DBC.SetData(dbc.fileIndex, table);
            }
            Program.loadingForm.SetLabelText(m_threadId, "Finished, took " + ((float)(Time.MsDiff(starttime, DateTime.Now))/1000.0f).ToString() + " seconds");
            Complete = true;
        }

        public void Close()
        {
            if (m_thread != null)
            {
                m_thread.Abort();
                m_thread = null;
            }
        }
    }*/
}