using System;
using System.Reflection;

namespace SpellWork
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Compares two values object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="T_entry"></param>
        /// <param name="field">Value Type is MemberInfo</param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CreateFilter<T>(this T T_entry, object field, object val)
        {
            object basicValue = GetValue<T>(T_entry, (MemberInfo)field);
            
            switch (basicValue.GetType().Name)
            {
                case "UInt32": return basicValue.ToUInt32() == val.ToUInt32();
                case "Int32":  return basicValue.ToInt32()  == val.ToInt32();
                case "Single": return basicValue.ToFloat()  == val.ToFloat();
                case "UInt64": return basicValue.ToUlong()  == val.ToUlong();
                case "String": return basicValue.ToString().ContainsText(val.ToString());
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
                case @"String[]":
                    {
                        foreach (uint el in (uint[])basicValue)
                        {
                            if (el.ToString().ContainsText(val.ToString()))
                                return true;
                        }
                        return false;
                    }
                // todo: more
                default: return false;
            }
        }

        private static Object GetValue<T>(T T_entry, MemberInfo field)
        {
            if (field is FieldInfo)
                return T_entry.GetType().GetField(field.Name).GetValue(T_entry);
            else if (field is PropertyInfo)
                return T_entry.GetType().GetProperty(field.Name).GetValue(T_entry, null);
            else
                return null;
        }
    }
}
