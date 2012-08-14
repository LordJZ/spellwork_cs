using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellScalingEntry
    {
        public uint Id;
        public int MinCastTime;
        public int MaxCastTime;
        public uint MaxCastTimeLevel;   // player level at which cast time reaches max value
        public int PlayerClass;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public float[] Multiplier;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public float[] RandomPointsMultiplier;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public float[] OtherMultiplier;
        public float CoefBase;
        public uint CoefLevelBase;
    }
}
