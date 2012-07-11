using System.Collections.Generic;
using DBFilesClient.NET;

namespace SpellWork
{
    public static class DBC
    {
        public const string VERSION  = "SpellWork 4.0.6 (13623)";
        public const string DBC_PATH = "dbc";

        public const int MAX_DBC_LOCALE                 = 16;
        public const int MAX_EFFECT_INDEX               = 3;
        public const int SPELL_ENTRY_FOR_DETECT_LOCALE  = 1;

        public static DBCStorage<CurrencyTypesEntry>          CurrencyTypes;
        public static DBCStorage<SpellEntry> Spell;
        public static DBCStorage<SpellEffectEntry> SpellEffect;
        public static DBCStorage<SpellTargetRestrictionsEntry> SpellTargetRestrictions;
        public static DBCStorage<SpellAuraRestrictionsEntry> SpellAuraRestrictions;
        public static DBCStorage<SpellCooldownsEntry> SpellCooldowns;
        public static DBCStorage<SpellCategoriesEntry> SpellCategories;
        public static DBCStorage<SpellShapeshiftEntry> SpellShapeshift;
        public static DBCStorage<SpellAuraOptionsEntry> SpellAuraOptions;
        public static DBCStorage<SpellLevelsEntry> SpellLevels;
        public static DBCStorage<SpellClassOptionsEntry> SpellClassOptions;
        public static DBCStorage<SpellCastingRequirementsEntry> SpellCastingRequirements;
        public static DBCStorage<SpellPowerEntry> SpellPower;
        public static DBCStorage<SpellInterruptsEntry> SpellInterrupts;
        public static DBCStorage<SpellEquippedItemsEntry> SpellEquippedItems;
        public static DBCStorage<SpellRadiusEntry> SpellRadius;
        public static DBCStorage<SpellCastTimesEntry> SpellCastTimes;
        public static DBCStorage<SpellDifficultyEntry> SpellDifficulty;
        public static DBCStorage<SpellRangeEntry> SpellRange;
        public static DBCStorage<SpellReagentsEntry> SpellReagents;
        public static DBCStorage<SpellDurationEntry> SpellDuration;
        public static DBCStorage<SkillLineAbilityEntry> SkillLineAbility;
        public static DBCStorage<SkillLineEntry> SkillLine;
        public static DBCStorage<ScreenEffectEntry> ScreenEffect;
        public static DBCStorage<OverrideSpellDataEntry> OverrideSpellData;

        public static Dictionary<uint, Dictionary<uint, SpellEffectEntry>> SpellEffects = new Dictionary<uint, Dictionary<uint, SpellEffectEntry>>();

        // DB 
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
