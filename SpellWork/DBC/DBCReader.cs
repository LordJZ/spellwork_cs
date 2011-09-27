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
            var dict = new Dictionary<uint, T>();
            string fileName = Path.Combine(DBC.DBC_PATH, typeof(T).Name + ".dbc").Replace("Entry", String.Empty);

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs, Encoding.UTF8))
            {
                if (!File.Exists(fileName))
                    throw new FileNotFoundException("One of DBC files not found.", fileName);

                // read dbc header
                var header = reader.ReadStruct<DbcHeader>();
                int size = Marshal.SizeOf(typeof(T));

                if (!header.IsDBC)
                    throw new Exception(fileName + " is not DBC file!");
                
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
