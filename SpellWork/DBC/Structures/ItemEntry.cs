using DBFilesClient.NET;

namespace SpellWork.DBC.Structures
{
    public sealed class ItemEntry
    {
        public uint Id;
        public uint Class;
        public uint SubClass;
        public int SoundOverrideSubclass;
        public int Material;
        public uint DisplayId;
        public uint InventoryType;
        public uint Sheath;
    }
}
