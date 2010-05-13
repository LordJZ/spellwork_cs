using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellWork
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Compares two values object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="T_entry"></param>
        /// <param name="field"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CreateFilter<T>(this T T_entry, string field, object val)
        {
            object basicValue = T_entry.GetType().GetField(field).GetValue(T_entry);
            
            switch (basicValue.GetType().Name)
            {
                case "UInt32": return basicValue.ToUInt32() == val.ToUInt32();
                case "Int32":  return basicValue.ToInt32()  == val.ToInt32();
                case "Single": return basicValue.ToFloat()  == val.ToFloat();
                case "UInt64": return basicValue.ToUlong()  == val.ToUlong();
                case @"UInt32[]":
                    {
                        foreach (uint el in (uint[])basicValue)
                        {
                            if (el.ToUInt32() == val.ToUInt32())
                                return true;
                        }
                        return false;
                    }
                case @"Int32[]":
                    {
                        foreach (int el in (int[])basicValue)
                        {
                            if (el.ToInt32() == val.ToInt32())
                                return true;
                        }
                        return false;
                    }
                case @"Single[]":
                case @"Float[]":
                    {
                        foreach (float el in (float[])basicValue)
                        {
                            if (el.ToFloat() == val.ToFloat())
                                return true;
                        }
                        return false;
                    }
                case @"UInt64[]":
                    {
                        foreach (ulong el in (ulong[])basicValue)
                        {
                            if (el.ToUlong() == val.ToUlong())
                                return true;
                        }
                        return false;
                    }
                // todo: more
                default: return false;
            }
        }
    }
}
