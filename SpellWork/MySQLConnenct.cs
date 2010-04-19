using System;
using SpellWork.Properties;

namespace SpellWork
{
    public static class MySQLConnenct
    {
        static String ConnectionString
        {
            get 
            {
                return String.Format("Server={0};Port={1};Uid={2};Pwd={3};Connection Timeout=10", 
                    Settings.Default.Host, Settings.Default.Port, Settings.Default.User, Settings.Default.Pass, Settings.Default.Db_mangos);
            }
        }
    }
}
