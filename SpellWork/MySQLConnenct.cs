using System;
using SpellWork.Properties;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SpellWork
{
    public static class MySQLConnenct
    {
        static MySqlConnection  _conn;
        static MySqlCommand     _command;

        static String ConnectionString
        {
            get 
            {
                return String.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};Connection Timeout=10", 
                    Settings.Default.Host, 
                    Settings.Default.Port, 
                    Settings.Default.User, 
                    Settings.Default.Pass, 
                    Settings.Default.Db_mangos);
            }
        }

        static String GetSpellName(Object id)
        {
            try
            {
                return DBC.Spell[id.ToUInt32()].SpellNameRank;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static List<ListViewItem> SelectProc(string query)
        {
            List<ListViewItem> list = new List<ListViewItem>();
            _conn    = new MySqlConnection(ConnectionString);
            _command = new MySqlCommand(query, _conn);
            _conn.Open();

            var reader = _command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new ListViewItem(new[]
                {
                    reader[0].ToString(),                   // Entry 
                    GetSpellName(reader[0]),     // Name
                    reader[1].ToString(),                   // School Mask
                    reader[2].ToString(),                   // Spell Family Name
                    reader[3].ToString(),                   // Spell Family Mask 0
                    reader[4].ToString(),                   // Spell Family Mask 1
                    reader[5].ToString(),                   // Spell Family Mask 2
                    reader[6].ToString(),                   // Proc Flags
                    reader[7].ToString(),                   // Proc Ex
                    reader[8].ToString(),                   // PPM Rate
                    reader[9].ToString(),                   // Chance
                    reader[10].ToString()                   // Cooldown
                }));
            }
            reader.Close();
            _conn.Close();

            return list;
        }

        public static void Insert(string query)
        {
            _conn = new MySqlConnection(ConnectionString);
            _command = new MySqlCommand(query, _conn);
            _conn.Open();
            _command.ExecuteNonQuery();
            _command.Connection.Close();
        }
    }
}
