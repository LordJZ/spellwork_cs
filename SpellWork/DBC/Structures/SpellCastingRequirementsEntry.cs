namespace SpellWork.DBC.Structures
{
    public sealed class SpellCastingRequirementsEntry
    {
        public uint Id;
        public uint FacingCasterFlags;
        public uint MinFactionId;
        public uint MinReputation;
        public int AreaGroupId;
        public uint RequiredAuraVision;
        public uint RequiresSpellFocus;
    }
}
