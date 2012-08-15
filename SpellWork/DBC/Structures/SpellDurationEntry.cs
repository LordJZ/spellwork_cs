using System;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellDurationEntry
    {
        public uint Id;
        public int Duration;
        public int Unknown2;
        public int MaxDuration;

        public override string ToString()
        {
            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", Id, Duration, Unknown2, MaxDuration);
        }
    }
}
