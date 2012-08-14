using System;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellDurationEntry
    {
        public uint Id;
        public uint Duration;
        public uint Unknown2;
        public uint MaxDuration;

        public override string ToString()
        {
            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", Id, Duration, Unknown2, MaxDuration);
        }
    }
}
