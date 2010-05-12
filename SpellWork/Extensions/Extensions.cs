using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

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
            {
                temp.Add(num);
            }

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

        public static StringBuilder AppendFormatIfNotNull(this StringBuilder builder, string format, params object[] arg)
        {
            if (arg[0].ToUInt32() != 0)
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

        public static float ToFloat(this Object val)
        {
            if (val == null)
                return 0.0f;

            float num;
            float.TryParse(val.ToString().Replace(',', '.'), out num);
            return num;
        }

        public static ulong ToUlong(this Object val)
        {
            if (val == null)
                return 0U;

            ulong num;
            ulong.TryParse(val.ToString(), out num);
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

        public static String NormaliseString(this String text, String remove)
        {
            var str = String.Empty;
            if (remove != String.Empty)
            {
                text = text.Replace(remove, String.Empty);
            }

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

        public static void SetCheckedItemFromFlag(this CheckedListBox _name, uint _value)
        {
            for (int i = 0; i < _name.Items.Count; ++i)
            {
                double pow = Math.Pow(2, i);
                int x = (int)Math.Truncate(_value / pow);
                bool check = (x % 2) != 0;
                _name.SetItemChecked(i, check);
            }
        }

        public static uint GetFlagsValue(this CheckedListBox _name)
        {
            uint val = 0;
            for (int i = 0; i < _name.CheckedIndices.Count; i++)
            {
                val += (uint)(Math.Pow(2, _name.CheckedIndices[i]));
            }

            return val;
        }

        public static void SetFlags<T>(this CheckedListBox _clb) where T : struct
        {
            _clb.Items.Clear();

            foreach (var elem in Enum.GetValues(typeof(T)))
            {
                _clb.Items.Add(elem.ToString().NormaliseString(String.Empty));
            }
        }

        public static void SetFlags<T>(this CheckedListBox _clb, String remove) where T : struct
        {
            _clb.Items.Clear();

            foreach (var elem in Enum.GetValues(typeof(T)))
            {
                _clb.Items.Add(elem.ToString().NormaliseString(remove));
            }
        }

        public static void SetFlags(this CheckedListBox _clb, Type type, String remove)
        {
            _clb.Items.Clear();

            foreach (var elem in Enum.GetValues(type))
            {
                _clb.Items.Add(elem.ToString().NormaliseString(remove));
            }
        }

        public static void SetEnumValues<T>(this ComboBox cb, string NoValue) where T : struct
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new Object[] { -1, NoValue });

            foreach (var str in Enum.GetValues(typeof(T)))
            {
                dt.Rows.Add(new Object[] { (int)str, "(" + ((int)str).ToString("000") + ") " + str });
            }

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }

        public static void SetEnumValues<T>(this ComboBox cb, string NoValue, string remove) where T : struct
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new Object[] { -1, NoValue });

            foreach (var str in Enum.GetValues(typeof(T)))
            {
                dt.Rows.Add(new Object[] 
                { 
                    (int)str, 
                    "(" + ((int)str).ToString("000") + ") " + str.ToString().NormaliseString(remove) 
                });
            }

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }

        public static void SetStructFields<T>(this ComboBox cb) where T : struct
        {
            cb.Items.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            var type = typeof(T).GetMembers();
            int i = 0;
            foreach (var str in type)
            {
                if (str is FieldInfo)
                {
                    dt.Rows.Add(new object[] 
                    { 
                        str.Name, 
                        String.Format("({0:000}) {1}", i, str.Name) 
                    });
                    i++;
                }
            }

            cb.DataSource    = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember   = "ID";
        }

        /// <summary>
        /// Compares the text on the partial occurrence of a string and ignore case
        /// </summary>
        /// <param name="text">The original text, which will search entry</param>
        /// <param name="compareText">String which will be matched with the original text</param>
        /// <returns>Boolean(true or false)</returns>
        public static bool ContainText(this string text, string compareText)
        {
            return (text.ToUpper().IndexOf(compareText.ToUpper(), StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        /// <summary>
        /// Compares the text on the partial occurrence of a string and ignore case
        /// </summary>
        /// <param name="text">The original text, which will search entry</param>
        /// <param name="compareText">Array strings which will be matched with the original text</param>
        /// <returns>Boolean(true or false)</returns>
        public static bool ContainText(this string text, string[] compareText)
        {
            foreach (string str in compareText)
            {
                if ((text.ToUpper().IndexOf(str.ToUpper(), StringComparison.CurrentCultureIgnoreCase) != -1))
                    return true;
            }
            return false;
        }
    }
}
