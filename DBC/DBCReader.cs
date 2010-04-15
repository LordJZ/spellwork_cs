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

            // Sanity check
            if (reader.BaseStream.Length < 20 || reader.ReadUInt32() != 0x43424457)
                throw new Exception(String.Format("Bad DBC file {0}", fileName));

            int recordsCount = reader.ReadInt32();
            int fieldsCount = reader.ReadInt32();
            int recordSize = reader.ReadInt32();
            int stringTableSize = reader.ReadInt32();

            int size = Marshal.SizeOf(typeof(T));

            if (recordSize != size)
                throw new Exception(String.Format("\n\nSize of row in DBC file ({0}) != size of DBC struct ({1})\nDBC: {2}\n\n", recordSize, size, fileName));

            GenericReader dataReader = new GenericReader(new MemoryStream(reader.ReadBytes(recordsCount * recordSize)), Encoding.UTF8);
            GenericReader stringsReader = new GenericReader(new MemoryStream(reader.ReadBytes(stringTableSize)), Encoding.UTF8);

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
    }

    class GenericReader : BinaryReader
    {
        public GenericReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public GenericReader(String fname, Encoding encoding) : base(new FileStream(fname, FileMode.Open, FileAccess.Read), encoding) { }

        public String ReadStringDbc(Int32 offset)
        {
            this.BaseStream.Position = offset;

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
