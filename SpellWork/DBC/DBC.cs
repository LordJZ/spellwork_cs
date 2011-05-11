using System.Collections.Generic;
using SpellWork.Spell;

namespace SpellWork.DBC
{
    public static class DBC
    {
        public const string Version = "SpellWork 3.3.5a (12340)";
        public const string DbcPath = @"dbc";

        public const int MaxDbcLocale                 = 16;
        public const int MaxReagentCount              = 8;
        public const int MaxEffectIndex               = 3;
        public const int SpellEntryForDetectLocale    = 1;

        public static Dictionary<uint, OverrideSpellDataEntry>      OverrideSpellData;
        public static Dictionary<uint, ScreenEffectEntry>           ScreenEffect;
        public static Dictionary<uint, SkillLineAbilityEntry>       SkillLineAbility;
        public static Dictionary<uint, SkillLineEntry>              SkillLine;
        public static Dictionary<uint, SpellEntry>                  Spell;
        public static Dictionary<uint, SpellCastTimesEntry>         SpellCastTimes;
        public static Dictionary<uint, SpellDifficultyEntry>        SpellDifficulty;
        public static Dictionary<uint, SpellDurationEntry>          SpellDuration;
        public static Dictionary<uint, SpellRadiusEntry>            SpellRadius;
        public static Dictionary<uint, SpellRangeEntry>             SpellRange;

        public static Dictionary<uint, string> SpellStrings            = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SkillLineStrings        = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SpellRangeStrings       = new Dictionary<uint, string>();
        public static Dictionary<uint, string> ScreenEffectStrings     = new Dictionary<uint, string>();

        // DB
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
