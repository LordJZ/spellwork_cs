namespace SpellWork.Database
{
    public struct SpellProcEventEntry
    {
        public uint Id;
        public string SpellName;
        public byte SchoolMask;
        public ushort SpellFamilyName;
        public uint[] SpellFamilyMask;
        public uint ProcFlags;
        public uint ProcEx;
        public float PpmRate;
        public float CustomChance;
        public uint Cooldown;

        public string[] ToArray()
        {
            return new[]
            {
                Id.ToString(),
                SpellName,
                SchoolMask.ToString(),
                SpellFamilyName.ToString(),
                SpellFamilyMask[0].ToString(),
                SpellFamilyMask[1].ToString(),
                SpellFamilyMask[2].ToString(),
                ProcFlags.ToString(),
                ProcEx.ToString(),
                PpmRate.ToString(),
                CustomChance.ToString(),
                Cooldown.ToString()
            };
        }
    }

    public struct Item
    {
        public uint Entry;
        public string Name;
        public string Description;
        public string LocalesName;
        public string LocalesDescription;
        public int[] SpellId;
    }
}
