using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpellWork
{
    static class DBCReader
    {
        public static unsafe Dictionary<uint, T> ReadDBC<T>(Dictionary<uint, string> strDict) where T : struct
        {
            Dictionary<uint, T> dict = new Dictionary<uint, T>();
            String fileName = Path.Combine(DBC.DBC_PATH, typeof(T).Name + ".dbc").Replace("Entry", String.Empty);
            
            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), Encoding.UTF8))
            {
                if (!File.Exists(fileName))
                    throw new FileNotFoundException();
                // read dbc header
                DbcHeader header = reader.ReadStruct<DbcHeader>();
                int size = Marshal.SizeOf(typeof(T));

                if (!header.IsDBC)
                    throw new Exception(fileName + " is not DBC files!");
                
                if (header.RecordSize != size)
                    throw new Exception(string.Format("Size of row in DBC file ({0}) != size of DBC struct ({1}) in DBC: {2}", header.RecordSize, size, fileName));

                // read dbc data
                for (int r = 0; r < header.RecordsCount; ++r)
                {
                    uint key = reader.ReadUInt32();
                    reader.BaseStream.Position -= 4;

                    T T_entry = reader.ReadStruct<T>();

                    dict.Add(key, T_entry);
                }

                // read dbc strings
                if (strDict != null)
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var offset = (uint)(reader.BaseStream.Position - header.StartStringPosition);
                        var str    = reader.ReadCString();
                        strDict.Add(offset, str);
                    }
                }
            }
            return dict;
        }
    }
}
