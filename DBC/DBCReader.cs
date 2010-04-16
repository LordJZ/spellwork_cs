using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SpellWork
{
    static class DBCReader
    {
        public static unsafe Dictionary<uint,T> ReadDBC<T>(string fileName, ref Dictionary<uint, string> strDict) where T : struct
        {
            Program.loadingForm.SetLabelText("Loading " + fileName);

            Dictionary<uint, T> dict = new Dictionary<uint, T>();

            if (!File.Exists(fileName))
                throw new Exception("File " + fileName + " not found");

            BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), Encoding.UTF8);

            // Sanity check
            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                throw new Exception(String.Format("Bad DBC file {0}", fileName));

            int recordsCount    = reader.ReadInt32();
            int fieldsCount     = reader.ReadInt32();
            int recordSize      = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            int size = Marshal.SizeOf(typeof(T));

            if (recordSize != size)
                throw new Exception(String.Format("\n\nSize of row in DBC file ({0}) != size of DBC struct ({1})\nDBC: {2}\n\n", recordSize, size, fileName));

            BinaryReader dataReader = new BinaryReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            BinaryReader stringsReader = new BinaryReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);

            reader.Close();

            for (int r = 0; r < recordsCount; ++r)
            {
                uint key = dataReader.ReadUInt32();
                dataReader.BaseStream.Position -= 4;

                byte[] rawData = dataReader.ReadBytes(size);

                GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
                T T_entry = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();

                dict.Add(key, T_entry);
            }

            dataReader.Close();

            // Now we read strings
            if (strDict != null)
            {
                char nullChar = char.MinValue;
                char[] data = stringsReader.ReadChars((int)stringsReader.BaseStream.Length);
                string str = "";
                uint idx = 1;
                for (uint i = 0; i < data.Length; ++i)
                {
                    if (data[i] == nullChar)
                    {
                        if (i > 0)
                        {
                            strDict.Add(idx, str);
                            str = "";
                            idx = i++;
                        }
                    }
                    else
                    {
                        str += data[i];
                    }
                }
            }

            stringsReader.Close();

            Program.loadingForm.ProgressBarStep();

            return dict;
        }
    }
}
