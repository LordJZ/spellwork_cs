using System.Collections.Generic;

namespace SpellWork
{
    public static class DBC
    {
        public const string VERSION  = "SpellWork 4.0.6 (13623)";
        public const string DBC_PATH = "dbc";

        public const int MAX_DBC_LOCALE                 = 16;
        public const int MAX_EFFECT_INDEX               = 3;
        public const int SPELL_ENTRY_FOR_DETECT_LOCALE  = 1;

        public static Dictionary<uint, SpellEntry>                  Spell;
        public static Dictionary<uint, SpellEffectEntry>            SpellEffect;
        public static Dictionary<uint, SpellTargetRestrictionsEntry> SpellTargetRestrictions;
        public static Dictionary<uint, SpellAuraRestrictionsEntry>  SpellAuraRestrictions;
        public static Dictionary<uint, SpellCooldownsEntry>         SpellCooldowns;
        public static Dictionary<uint, SpellCategoriesEntry>        SpellCategories;
        public static Dictionary<uint, SpellShapeshiftEntry>        SpellShapeshift;
        public static Dictionary<uint, SpellAuraOptionsEntry>       SpellAuraOptions;
        public static Dictionary<uint, SpellLevelsEntry>            SpellLevels;
        public static Dictionary<uint, SpellClassOptionsEntry>      SpellClassOptions;
        public static Dictionary<uint, SpellCastingRequirementsEntry> SpellCastingRequirements;
        public static Dictionary<uint, SpellPowerEntry>             SpellPower;
        public static Dictionary<uint, SpellInterruptsEntry>        SpellInterrupts;
        public static Dictionary<uint, SpellEquippedItemsEntry>     SpellEquippedItems;
        public static Dictionary<uint, SpellRadiusEntry>            SpellRadius;
        public static Dictionary<uint, SpellCastTimesEntry>         SpellCastTimes;
        public static Dictionary<uint, SpellDifficultyEntry>        SpellDifficulty;
        public static Dictionary<uint, SpellRangeEntry>             SpellRange;
        public static Dictionary<uint, SpellDurationEntry>          SpellDuration;
        public static Dictionary<uint, SkillLineAbilityEntry>       SkillLineAbility;
        public static Dictionary<uint, SkillLineEntry>              SkillLine;
        public static Dictionary<uint, ScreenEffectEntry>           ScreenEffect;
        public static Dictionary<uint, OverrideSpellDataEntry>      OverrideSpellData;

        public static Dictionary<uint, string> SpellStrings            = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SkillLineStrings        = new Dictionary<uint, string>();
        public static Dictionary<uint, string> SpellRangeStrings       = new Dictionary<uint, string>();
        public static Dictionary<uint, string> ScreenEffectStrings     = new Dictionary<uint, string>();

        public static Dictionary<uint, Dictionary<int, SpellEffectEntry>> SpellEffects = new Dictionary<uint, Dictionary<int, SpellEffectEntry>>();

        // DB 
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
