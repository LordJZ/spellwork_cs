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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static StringBuilder AppendFormatLine(this StringBuilder builder, string format, params object[] arg0)
        {
            return builder.AppendFormat(format, arg0).AppendLine();
        }

        public static StringBuilder AppendFormatIsNull(this StringBuilder builder, string format, params object[] arg0)
        {
            if(arg0.Length > 0)
            {
                if (arg0[0].ToInt32() != 0)
                {
                    return builder.AppendFormat(format, arg0);
                }
            }

            return builder.Append(String.Empty);
        }

        public static StringBuilder AppendFormatLineIsNull(this StringBuilder builder, string format, params object[] arg0)
        {
            if (arg0.Length > 0)
            {
                if (arg0[0].ToInt32() != 0)
                {
                    return builder.AppendFormat(format, arg0).AppendLine();
                }
            }

            return builder.Append(String.Empty);
        }

        public static StringBuilder AppendFormatLineIsNull(this StringBuilder builder, string format, bool IsString, params object[] arg0)
        {
            if (arg0.Length > 0)
            {
                if (arg0[0].ToString() != "")
                {
                    return builder.AppendFormat(format, arg0).AppendLine();
                }
            }

            return builder.Append(String.Empty);
        }
        /// <summary>
        ///  A function to calculate time diff
        /// </summary>
        /// <returns>Milliseconds between two timestamps</returns>
        public static Int32 MsDiff(DateTime time1, DateTime time2)
        {
            return (Int32)(time2 - time1).TotalMilliseconds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UInt32 UnixTime()
        {
            return (UInt32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String IsEmpty(this String str)
        {
            if(String.IsNullOrEmpty(str))
                return String.Empty;
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static String IsEmpty(this String str, String desc)
        {
            if (String.IsNullOrEmpty(str))
                return String.Empty;
            return desc + str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static String IsEmptyLine(this String str, String desc)
        {
            if (String.IsNullOrEmpty(str))
                return String.Empty;
            return desc + str + Environment.NewLine;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static String IsEmpty(this UInt32 num, String desc)
        {
            if (num > 0)
                return desc + num;

            return String.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static uint ToUInt32(this Object val)
        {
            if (val == null)
                return 0;

            uint num;
            uint.TryParse(val.ToString(), out num);
            return num;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInt32(this Object val)
        {
            if (val == null) 
                return 0;

            int num;
            int.TryParse(val.ToString(), out num);
            return num;
        }
    }
}
