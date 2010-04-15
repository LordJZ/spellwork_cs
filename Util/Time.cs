using System;

namespace SpellWork
{
    static class Time
    {
        /// <summary>
        ///  A function to calculate time diff
        /// </summary>
        /// <returns>Milliseconds between two timestamps</returns>
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