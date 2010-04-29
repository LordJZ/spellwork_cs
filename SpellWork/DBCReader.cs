using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpellWork
{
    static class DBCReader
    {
        public static unsafe Dictionary<uint, T> ReadDBC<T>(string fileName, Dictionary<uint, string> strDict) where T : struct
        {
            Dictionary<uint, T> dict = new Dictionary<uint, T>();

            if (!File.Exists(fileName))
                throw new Exception("File " + fileName + " not found");

            BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), Encoding.UTF8);

            // read dbc header
            DbcHeader header = reader.ReadStruct<DbcHeader>();
            if (!header.TrueSignature)
                throw new Exception(String.Format("Bad DBC file {0}", fileName));

            int size = Marshal.SizeOf(typeof(T));

            if (header.RecordSize != size)// TODO: необходимо как-то сообщить пользователю о том, что ДБЦ у него возможно не той версии
                throw new Exception(String.Format("\n\nSize of row in DBC file ({0}) != size of DBC struct ({1})\nDBC: {2}\n\n", header.RecordSize, size, fileName));

            BinaryReader dataReader = new BinaryReader(new MemoryStream(reader.ReadBytes(header.DataSize)), Encoding.UTF8);
            BinaryReader stringsReader = new BinaryReader(new MemoryStream(reader.ReadBytes(header.StringTableSize)), Encoding.UTF8);

            reader.Close();
            // read dbc data
            for (int r = 0; r < header.RecordsCount; ++r)
            {
                uint key = dataReader.ReadUInt32();
                dataReader.BaseStream.Position -= 4;
                
                T T_entry = dataReader.ReadStruct<T>();
                
                dict.Add(key, T_entry);
            }
            
            dataReader.Close();

            // Now we read strings
            if (strDict != null)
            {
                while (stringsReader.BaseStream.Position != stringsReader.BaseStream.Length)
                {
                    var offset = (uint)stringsReader.BaseStream.Position;
                    var str = stringsReader.ReadCString();
                    strDict.Add(offset, str);
                }
            }

            stringsReader.Close();

            return dict;
        }
    }
}
