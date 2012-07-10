using System.Collections.Generic;
using DBFilesClient.NET;

namespace SpellWork
{
    public static class DBC
    {
        public const string VERSION  = "SpellWork 3.3.5a (12340)";
        public const string DBC_PATH = @"dbc";

        public const int MAX_DBC_LOCALE                 = 16;
        public const int MAX_EFFECT_INDEX               = 3;
        public const int SPELL_ENTRY_FOR_DETECT_LOCALE  = 1;

        public static DBCStorage<SpellEntry>                  Spell;
        public static DBCStorage<SpellRadiusEntry>            SpellRadius;
        public static DBCStorage<SpellCastTimesEntry>         SpellCastTimes;
        public static DBCStorage<SpellDifficultyEntry>        SpellDifficulty;
        public static DBCStorage<SpellRangeEntry>             SpellRange;
        public static DBCStorage<SpellDurationEntry>          SpellDuration;
        public static DBCStorage<SkillLineAbilityEntry>       SkillLineAbility;
        public static DBCStorage<SkillLineEntry>              SkillLine;
        public static DBCStorage<ScreenEffectEntry>           ScreenEffect;
        public static DBCStorage<OverrideSpellDataEntry>      OverrideSpellData;
        public static DBCStorage<AreaGroupEntry>              AreaGroup;
        public static DBCStorage<AreaTableEntry>              AreaTable;
        public static DBCStorage<SpellRuneCostEntry>          SpellRuneCost;

        // DB 
        public static List<Item> ItemTemplate = new List<Item>();

        // Locale
        public static LocalesDBC Locale { get; set; }
    }
}
