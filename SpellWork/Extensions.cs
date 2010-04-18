using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SpellWork
{
    public static class Extensions
    {
        /// <summary>
        /// Reads the NULL-terminated string from the current stream.
        /// </summary>
        /// <param name="reader">Stream to read from.</param>
        /// <returns>Resulting string.</returns>
        public static string ReadCString(this BinaryReader reader)
        {
            byte num;

            var temp = new List<byte>();

            while ((num = reader.ReadByte()) != 0)
                temp.Add(num);

            return Encoding.UTF8.GetString(temp.ToArray());
        }

        /// <summary>
        /// Reads the struct from the current stream.
        /// </summary>
        /// <typeparam name="T">Struct type.</typeparam>
        /// <param name="reader">Stream to read from.</param>
        /// <returns>Resulting struct.</returns>
        public static unsafe T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            var rawData = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            T returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T LookupEntry<T>(this Dictionary<uint, T> dict, uint id) where T : struct
        {
            T _struct = new T();
            try
            {
                dict.TryGetValue(id, out _struct);
            }
            catch (Exception)
            {
                return default(T);
            }

            return _struct;
        }

        // Append Line
        public static StringBuilder AppendLineIfNotNull(this StringBuilder builder, string line)
        {
            if (!String.IsNullOrEmpty(line))
                return builder.AppendLine(line);

            return builder;
        }

        // Append Format
        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, string arg)
        {
            if (!String.IsNullOrEmpty(arg))
            {
                return builder.AppendFormat(format, arg);
            }

            return builder;
        }
        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, uint arg)
        {
            if (arg != 0)
            {
                return builder.AppendFormat(format, arg);
            }

            return builder;
        }
        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, int arg)
        {
            if (arg != 0)
            {
                return builder.AppendFormat(format, arg);
            }

            return builder;
        }
        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, float arg)
        {
            if (arg != 0.0f)
            {
                return builder.AppendFormat(format, arg);
            }

            return builder;
        }

        // Append Format Line
        public static StringBuilder AppendFormatLine(this StringBuilder builder, string format, params object[] arg0)
        {
            return builder.AppendFormat(format, arg0).AppendLine();
        }
        public static StringBuilder AppendFormatLineIfNotNull(this StringBuilder builder, string format, string arg)
        {
            if (!String.IsNullOrEmpty(arg))
            {
                return builder.AppendFormat(format, arg).AppendLine();
            }

            return builder;
        }

        public static StringBuilder AppendFormatLineIfNotNull(this StringBuilder builder, string format, int arg)
        {
            if (arg != 0)
            {
                return builder.AppendFormat(format, arg).AppendLine();
            }

            return builder;
        }
        public static StringBuilder AppendFormatLineIfNotNull(this StringBuilder builder, string format, uint arg)
        {
            if (arg != 0)
            {
                return builder.AppendFormat(format, arg).AppendLine();
            }

            return builder;
        }

        public static StringBuilder AppendFormatLineIfNotNull(this StringBuilder builder, string format, float arg)
        {
            if (arg != 0.0f)
            {
                return builder.AppendFormat(format, arg).AppendLine();
            }

            return builder;
        }

        // Empty
        public static bool IsEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }
        public static string IfNotEmpty(this uint val, string _return)
        {
            return val == 0 ? String.Empty : (_return + val.ToString());
        }

        public static uint ToUInt32(this Object val)
        {
            if (val == null)
                return 0;

            uint num;
            uint.TryParse(val.ToString(), out num);
            return num;
        }
        public static int ToInt32(this Object val)
        {
            if (val == null) 
                return 0;

            int num;
            int.TryParse(val.ToString(), out num);
            return num;
        }

        // Time methods
        public static Int32 MsDiff(DateTime time1, DateTime time2)
        {
            return (Int32)(time2 - time1).TotalMilliseconds;
        }

        public static UInt32 UnixTime()
        {
            return (UInt32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
