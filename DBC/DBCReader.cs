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

            GenericReader reader = new GenericReader(fileName, Encoding.UTF8);

            // Sanity checks
            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                throw new Exception(String.Format("Bad DBC file {0}", fileName));

            int recordsCount = reader.ReadInt32();
            int fieldsCount = reader.ReadInt32();
            int recordSize = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            int sz = Marshal.SizeOf(typeof(T));
            if(fieldsCount*4 != sz)
                throw new Exception(String.Format("\n\nSize of row in DBC file ({0}) != size of DBC struct ({1})\nDBC: {2}\n\n", fieldsCount*4, sz, fileName));

            GenericReader dataReader = new GenericReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            GenericReader stringsReader = new GenericReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);

            reader.Close();

            for (int r = 0; r < recordsCount; ++r)
            {
                uint key = dataReader.ReadUInt32();
                dataReader.BaseStream.Position -= 4;

                /* OLD SYSTEM

                List<byte> row = new List<byte>();

                int cur_idx = -1;
                int str_idx = 0;
                while (++cur_idx < fmt.Length)
                {
                    str_idx = fmt.IndexOf("s", cur_idx);

                    if (str_idx == -1)
                        str_idx = fmt.Length - cur_idx;
                    else
                        str_idx -= cur_idx;

                    if (str_idx == 0)
                    {
                        row.AddRange(Encoding.UTF8.GetBytes(stringsReader.ReadStringDbc(dataReader.ReadInt32())));
                    }
                    else
                    {
                        row.AddRange(dataReader.ReadBytes(str_idx*4));
                        cur_idx += str_idx-1;
                    }
                }*/


                byte[] rawData = dataReader.ReadBytes(sz);
                //System.Windows.Forms.MessageBox.Show(String.Format("rawData size {0}, struct size {1}", row.Count, sz));

                GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
                T T_entry = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                handle.Free();

                //System.Windows.Forms.MessageBox.Show(String.Format("adding key {0}", key));
                dict.Add(key, T_entry);
            }

            dataReader.Close();

            // Now we read  strings
            if (strDict != null)
            {
                char nullChar = char.MinValue;
                char[] data = stringsReader.ReadChars((int)stringsReader.BaseStream.Length);
                string str = "";
                uint idx = 1;
                for (uint i = 0; i < data.Length; ++i)
                {
                    if(data[i] == nullChar)
                    {
                        if(i > 0)
                        {
                            strDict.Add(idx, str);
                            str = "";
                            idx = i + 1;
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
        /*public DBCReader(string fileName, ref Dictionary<int, DbcData> dict, String[][] shem)
        {
            GenericReader reader = new GenericReader(fileName, Encoding.UTF8);

            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                return;

            int recordsCount    = reader.ReadInt32();
            int fieldsCount     = reader.ReadInt32();
            int recordSize      = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            Program.loadingForm.SetProgressBarSize(0, recordsCount);

            GenericReader dataReader = new GenericReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            GenericReader stringsReader = new GenericReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);
            
            reader.Close();

            //IDictionary<int, DbcData> dict = new Dictionary<int, SpellEntry>();
            //if (entry == DBCFileEntries.SPELL)
            {
                dict.Add(0, new DbcData());
                // DBC.Spell = Convert.ChangeType(dict, Dictionary<int, SpellEntry>);
            }


            /*byte[][] m_rows = new byte[recordsCount][];

            for (int i = 0; i < recordsCount; i++)
                m_rows[i] = dataReader.ReadBytes(recordSize);

            foreach (var field in shem)
                 dbcTable.Columns.Add(field[1].ToString());

            for (int i = 0; i < recordsCount; ++i)
            {
                GenericReader rowsReader = new GenericReader(new MemoryStream(m_rows[i]), Encoding.UTF8);
                DataRow rows = dbcTable.NewRow();

                foreach (var field in shem)
                {
                    switch (field[0])
                    {
                        case "ulong":  rows[field[1]] = rowsReader.ReadUInt64();
                            break;
                        case "int":    rows[field[1]] = rowsReader.ReadInt32();
                            break;
                        case "uint":   rows[field[1]] = rowsReader.ReadUInt32();
                            break;
                        case "float":  rows[field[1]] = Regex.Replace(rowsReader.ReadSingle().ToString(), @",", @".");
                            break;
                        case "string": rows[field[1]] = stringsReader.ReadStringDbc(rowsReader.ReadInt32());
                            break;
                        case "struct": rows[field[1]] = BinaryReaderExtensions.ReadStruct<SpellEntry>(rowsReader);
                            break;
                        default:
                            break;
                    }
                }
                dbcTable.Rows.Add(rows);
                rowsReader.Close();

                Program.loadingForm.ProgressBarStep(lThreadId);
            }
            dataReader.Close();
            stringsReader.Close();
        }*/
    }

    class GenericReader : BinaryReader
    {
        public GenericReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public GenericReader(String fname, Encoding encoding) : base(new FileStream(fname, FileMode.Open, FileAccess.Read), encoding) { }

        public String ReadStringDbc(Int32 offset)
        {
            //Byte num;
            //List<Byte> temp = new List<Byte>();
            this.BaseStream.Position = offset;

            /*while ((num = this.ReadByte()) != 0)
                temp.Add(num);

            return Encoding.UTF8.GetString(temp.ToArray());*/
            return this.ReadCString();
        }
    }

    public static class BinaryReaderExtensions
    {
        /// <summary>  Reads the packed guid from the current stream and 
        /// advances the current position of the stream by packed guid size.
        /// </summary>
        public static ulong ReadPackedGuid(this BinaryReader reader)
        {
            byte mask = reader.ReadByte();

            if (mask == 0)
            {
                return 0;
            }

            ulong res = 0;

            int i = 0;
            while (i < 8)
            {
                if ((mask & 1 << i) != 0)
                {
                    res += (ulong)reader.ReadByte() << (i * 8);
                }
                i++;
            }

            return res;
        }

        /// <summary> Reads the NULL terminated string from 
        /// the current stream and advances the current position of the stream by string length + 1.
        /// <seealso cref="BinaryReader.ReadString"/>
        /// </summary>
        public static string ReadCString(this BinaryReader reader)
        {
            return reader.ReadCString(Encoding.UTF8);
        }

        /// <summary> Reads the NULL terminated string from 
        /// the current stream and advances the current position of the stream by string length + 1.
        /// <seealso cref="BinaryReader.ReadString"/>
        /// </summary>
        public static string ReadCString(this BinaryReader reader, Encoding encoding)
        {
            var bytes = new List<byte>();
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                bytes.Add(b);
            }
            return encoding.GetString(bytes.ToArray());
        }

        /// <summary> Reads struct from the current stream and advances the 
        /// current position if the stream by SizeOf(T) bytes.
        /// </summary>
        public static T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            byte[] rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            var returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }
    }
}
