using System.Collections.Generic;

namespace SpellWork
{
    static class DBC
    {
        public const string VERSION = "SpellWork 3.3.3a (11723)";
        public const int MAX_DBC_LOCALE = 16;
        public const string DBC_PATH = @"dbc\";

        public static Dictionary<uint, SpellEntry>            Spell;
        public static Dictionary<uint, SpellRadiusEntry>      SpellRadius;
        public static Dictionary<uint, SpellCastTimesEntry>   SpellCastTimes;
        public static Dictionary<uint, SpellRangeEntry>       SpellRange;
        public static Dictionary<uint, SpellDurationEntry>    SpellDuration;
        public static Dictionary<uint, SkillLineAbilityEntry> SkillLineAbility;
        public static Dictionary<uint, SkillLineEntry>        SkillLine;

        public static Dictionary<uint, string> _SpellStrings      = new Dictionary<uint, string>();
        public static Dictionary<uint, string> _SkillLineStrings  = new Dictionary<uint, string>();
        public static Dictionary<uint, string> _SpellRangeStrings = new Dictionary<uint, string>();

        // DB 
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale;
    }
}
