using System.Collections.Generic;

namespace SpellWork
{
    static class DBC
    {
        public static Dictionary<uint, SpellEntry> Spell     = new Dictionary<uint, SpellEntry>();
        public static Dictionary<uint, string> _SpellStrings = new Dictionary<uint, string>();

        public static Dictionary<uint, SpellRadiusEntry> SpellRadius = new Dictionary<uint, SpellRadiusEntry>();
        public static Dictionary<uint, SpellCastTimesEntry> SpellCastTimes = new Dictionary<uint, SpellCastTimesEntry>();

        public static Dictionary<uint, SpellRangeEntry> SpellRange = new Dictionary<uint, SpellRangeEntry>();
        public static Dictionary<uint, string> _SpellRangeStrings  = new Dictionary<uint, string>();

        public static Dictionary<uint, SpellDurationEntry> SpellDuration = new Dictionary<uint, SpellDurationEntry>();
        public static Dictionary<uint, SkillLineAbilityEntry> SkillLineAbility = new Dictionary<uint, SkillLineAbilityEntry>();

        public static Dictionary<uint, SkillLineEntry> SkillLine = new Dictionary<uint, SkillLineEntry>();
        public static Dictionary<uint, string> _SkillLineStrings = new Dictionary<uint, string>();

        public static LocalesDBC Locale;
    }
}
