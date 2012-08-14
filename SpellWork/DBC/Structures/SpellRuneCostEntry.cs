using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellRuneCostEntry
    {
        public uint Id;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[] RuneCost;
        public uint RunicPowerGain;
    }
}
