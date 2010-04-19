using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using MySql.Data.MySqlClient;

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

        public static String NormaliseString(this String text)
        {
            var str = String.Empty;
            
            foreach (var s in text.Split('_'))
            {
                int i = 0;
                foreach (var c in s.ToCharArray())
                {
                    str += i == 0 ? c.ToString().ToUpper() : c.ToString().ToLower();
                    i++;
                }
                str += " ";
            }

            return str.Remove(str.Length - 1);
        }

        public static void SetCheckedItemFromFlag(this CheckedListBox _name, int _value)
        {
            for (int i = 0; i < _name.Items.Count; ++i)
            {
                var pow = Math.Pow(2, i);
                var x = (int)Math.Truncate(_value / pow);
                var check = (x % 2) != 0;
                _name.SetItemChecked(i, check);
            }
        }

        public static int GetFlagsValue(this CheckedListBox _name)
        {
            int val = 0;
            for (int i = 0; i < _name.CheckedIndices.Count; i++)
                val += (int)(Math.Pow(2, _name.CheckedIndices[i]));

            return val;
        }

        public static void SetFlags(this CheckedListBox _clb, Type enums)
        {
            _clb.Items.Clear();
            foreach (var elem in Enum.GetValues(enums))
            {
                _clb.Items.Add(elem.ToString().NormaliseString());
            }
        }

        public static void SetEnumValues(this ComboBox cb, Type enums, string NoValue)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new Object[] { -1, NoValue });

            foreach (var str in Enum.GetValues(enums))
            {
                dt.Rows.Add(new Object[] { (int)str, "(" + ((int)str).ToString("000") + ") " + str });
            }

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }
    }
}
