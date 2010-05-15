using System;
using SpellWork.Properties;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SpellWork
{
    public static class MySQLConnenct
    {
        private static MySqlConnection _conn;
        private static MySqlCommand _command;

        public static bool Connected { get; private set; }

        public static List<string> Dropped = new List<string>();

        private static String ConnectionString
        {
            get 
            {
                return String.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};character set=utf8;Connection Timeout=10", 
                    Settings.Default.Host, 
                    Settings.Default.Port, 
                    Settings.Default.User, 
                    Settings.Default.Pass, 
                    Settings.Default.Db_mangos);
            }
        }

        private static String GetSpellName(Object id)
        {
            try
            {
                return DBC.Spell[id.ToUInt32()].SpellNameRank;
            }
            catch
            {
                Dropped.Add(String.Format("DELETE FROM `spell_proc_event` WHERE `entry` IN ({0});\r\n", id.ToUInt32()));
                return String.Empty;
            }
        }

        public static List<ListViewItem> SelectProc(string query)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            using (_conn = new MySqlConnection(ConnectionString))
            {
                _command = new MySqlCommand(query, _conn);
                _conn.Open();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ListViewItem(new[]
                        {
                            reader[0].ToString(),       // 0  Entry 
                            GetSpellName(reader[0]),    // 1  Name
                            reader[1].ToString(),       // 2  School Mask
                            reader[2].ToString(),       // 3  Spell Family Name
                            reader[3].ToString(),       // 4  Spell Family Mask 0
                            reader[4].ToString(),       // 5  Spell Family Mask 1
                            reader[5].ToString(),       // 6  Spell Family Mask 2
                            reader[6].ToString(),       // 7  Proc Flags
                            reader[7].ToString(),       // 8  Proc Ex
                            reader[8].ToString(),       // 9  PPM Rate
                            reader[9].ToString(),       // 10 Chance
                            reader[10].ToString()       // 11 Cooldown
                        }));
                    }
                }
            }

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

        public static List<Item> SelectItems()
        {
            List<Item> items = DBC.ItemTemplate;
            // In order to reduce the search time, we make the first selection of all items that have spellid
            var query = String.Format(
                "SELECT t.entry, t.name, t.description, l.name_loc{0}, l.description_loc{0}, " +
                "t.spellid_1, t.spellid_2, t.spellid_3, t.spellid_4, t.spellid_5 " +
                "FROM `item_template` t LEFT JOIN `locales_item` l ON t.entry = l.entry " +
                "WHERE (t.spellid_1 <> 0 || t.spellid_2 <> 0 || t.spellid_3 <> 0 || t.spellid_4 <> 0 || t.spellid_5 <> 0);",
                (int)DBC.Locale == 0 ? 1 : (int)DBC.Locale /* it's huck TODO: replase code*/);

            using (_conn = new MySqlConnection(ConnectionString))
            {
                _command = new MySqlCommand(query, _conn);
                _conn.Open();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Entry               = reader[0].ToUInt32(),
                            Name                = reader[1].ToString(),
                            Description         = reader[2].ToString(),
                            LocalesName         = reader[3].ToString(),
                            LocalesDescription  = reader[4].ToString(),
                            SpellID1            = reader[5].ToUInt32(),
                            SpellID2            = reader[6].ToUInt32(),
                            SpellID3            = reader[7].ToUInt32(),
                            SpellID4            = reader[8].ToUInt32(),
                            SpellID5            = reader[9].ToUInt32(),
                        });
                    }
                }
             }
            return items;
        }

        public static void TestConnect()
        {
            if (!Settings.Default.UseDbConnect)
            {
                Connected = false;
                return;
            }

            try
            {
                _conn = new MySqlConnection(ConnectionString);
                _conn.Open();
                _conn.Close();
                Connected = true;
            }
            catch
            {
                Connected = false;
            }
        }
    }
}
