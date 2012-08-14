using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellDifficultyEntry
    {
        public uint Id;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 4)]
        public uint[] SpellId;
    }
}
