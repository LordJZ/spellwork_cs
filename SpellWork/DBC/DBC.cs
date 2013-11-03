using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DBFilesClient.NET;
using SpellWork.Database;
using SpellWork.DBC.Structures;
using SpellWork.Spell;

namespace SpellWork.DBC
{
    public static class DBC
    {
        public const string Version = "SpellWork 4.3.4 (15595)";
        public const string DbcPath = @"dbc";
        public const uint MaxLevel  = 85;

        public const int MaxDbcLocale                 = 16;
        public const int MaxReagentCount              = 8;
        public const int MaxEffectIndex               = 3;
        public const int SpellEntryForDetectLocale    = 1;

        public static DBCStorage<AreaGroupEntry> AreaGroup = new DBCStorage<AreaGroupEntry>();
        public static DBCStorage<AreaTableEntry> AreaTable = new DBCStorage<AreaTableEntry>();
        public static DBCStorage<gtSpellScalingEntry> gtSpellScaling = new DBCStorage<gtSpellScalingEntry>();
        public static DBCStorage<OverrideSpellDataEntry> OverrideSpellData = new DBCStorage<OverrideSpellDataEntry>();
        public static DBCStorage<ScreenEffectEntry> ScreenEffect = new DBCStorage<ScreenEffectEntry>();
        public static DBCStorage<SkillLineAbilityEntry> SkillLineAbility = new DBCStorage<SkillLineAbilityEntry>();
        public static DBCStorage<SkillLineEntry> SkillLine = new DBCStorage<SkillLineEntry>();
        public static DBCStorage<SpellEntry> Spell = new DBCStorage<SpellEntry>();
        public static DBCStorage<SpellAuraOptionsEntry> SpellAuraOptions = new DBCStorage<SpellAuraOptionsEntry>();
        public static DBCStorage<SpellAuraRestrictionsEntry> SpellAuraRestrictions = new DBCStorage<SpellAuraRestrictionsEntry>();
        public static DBCStorage<SpellCastingRequirementsEntry> SpellCastingRequirements = new DBCStorage<SpellCastingRequirementsEntry>();
        public static DBCStorage<SpellCastTimesEntry> SpellCastTimes = new DBCStorage<SpellCastTimesEntry>();
        public static DBCStorage<SpellCategoriesEntry> SpellCategories = new DBCStorage<SpellCategoriesEntry>();
        public static DBCStorage<SpellClassOptionsEntry> SpellClassOptions = new DBCStorage<SpellClassOptionsEntry>();
        public static DBCStorage<SpellCooldownsEntry> SpellCooldowns = new DBCStorage<SpellCooldownsEntry>();
        public static DBCStorage<SpellDescriptionVariablesEntry> SpellDescriptionVariables = new DBCStorage<SpellDescriptionVariablesEntry>();
        public static DBCStorage<SpellDifficultyEntry> SpellDifficulty = new DBCStorage<SpellDifficultyEntry>();
        public static DBCStorage<SpellDurationEntry> SpellDuration = new DBCStorage<SpellDurationEntry>();
        public static DBCStorage<SpellEffectEntry> SpellEffect = new DBCStorage<SpellEffectEntry>();
        public static DBCStorage<SpellEquippedItemsEntry> SpellEquippedItems = new DBCStorage<SpellEquippedItemsEntry>();
        public static DBCStorage<SpellInterruptsEntry> SpellInterrupts = new DBCStorage<SpellInterruptsEntry>();
        public static DBCStorage<SpellLevelsEntry> SpellLevels = new DBCStorage<SpellLevelsEntry>();
        public static DBCStorage<SpellMissileEntry> SpellMissile = new DBCStorage<SpellMissileEntry>();
        public static DBCStorage<SpellMissileMotionEntry> SpellMissileMotion = new DBCStorage<SpellMissileMotionEntry>();
        public static DBCStorage<SpellPowerEntry> SpellPower = new DBCStorage<SpellPowerEntry>();
        public static DBCStorage<SpellRadiusEntry> SpellRadius = new DBCStorage<SpellRadiusEntry>();
        public static DBCStorage<SpellRangeEntry> SpellRange = new DBCStorage<SpellRangeEntry>();
        public static DBCStorage<SpellReagentsEntry> SpellReagents = new DBCStorage<SpellReagentsEntry>();
        public static DBCStorage<SpellRuneCostEntry> SpellRuneCost = new DBCStorage<SpellRuneCostEntry>();
        public static DBCStorage<SpellScalingEntry> SpellScaling = new DBCStorage<SpellScalingEntry>();
        public static DBCStorage<SpellShapeshiftEntry> SpellShapeshift = new DBCStorage<SpellShapeshiftEntry>();
        public static DBCStorage<SpellTargetRestrictionsEntry> SpellTargetRestrictions = new DBCStorage<SpellTargetRestrictionsEntry>();
        public static DBCStorage<SpellTotemsEntry> SpellTotems = new DBCStorage<SpellTotemsEntry>();
        public static DBCStorage<SpellVisualEntry> SpellVisual = new DBCStorage<SpellVisualEntry>();

        public static DB2Storage<ItemEntry> Item = new DB2Storage<ItemEntry>();

        [DataStoreFileName("Item-sparse")]
        public static DB2Storage<ItemSparseEntry> ItemSparse = new DB2Storage<ItemSparseEntry>();

        public static Dictionary<uint, SpellInfoHelper> SpellInfoStore = new Dictionary<uint, SpellInfoHelper>();

        public static void Load()
        {
            foreach (var dbc in typeof(DBC).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (!dbc.FieldType.IsGenericType)
                    continue;

                string extension;
                if (dbc.FieldType.GetGenericTypeDefinition() == typeof(DBCStorage<>))
                    extension = "dbc";
                else if (dbc.FieldType.GetGenericTypeDefinition() == typeof(DB2Storage<>))
                    extension = "db2";
                else
                    continue;

                string name = dbc.Name;
                
                DataStoreFileNameAttribute[] attributes = dbc.GetCustomAttributes(typeof(DataStoreFileNameAttribute), false) as DataStoreFileNameAttribute[];
                if (attributes.Length == 1)
                    name = attributes[0].FileName;

                try
                {
                    using (var strm = new FileStream(String.Format("{0}\\{1}.{2}", DbcPath, name, extension), FileMode.Open))
                        dbc.FieldType.GetMethod("Load", new Type[] { typeof(FileStream) }).Invoke(dbc.GetValue(null), new object[] { strm });
                }
                catch (DirectoryNotFoundException)
                {
                    throw new DirectoryNotFoundException(String.Format("Could not open {0}.dbc!", dbc.Name));
                }
                catch (TargetInvocationException tie)
                {
                    if (tie.InnerException is ArgumentException)
                        throw new ArgumentException(String.Format("Failed to load {0}.dbc: {1}", dbc.Name, tie.InnerException.Message));

                    throw;
                }
            }

            foreach (var dbcInfo in Spell.Records)
                SpellInfoStore.Add(dbcInfo.Id, new SpellInfoHelper(dbcInfo));

            foreach (var effect in SpellEffect.Records)
            {
                if (!SpellInfoStore.ContainsKey(effect.SpellId))
                    continue;

                SpellInfoStore[effect.SpellId].Effects[effect.Index] = effect;
                var scaling = SpellInfoStore[effect.SpellId].Scaling;
                if (scaling != null)
                {
                    effect.ScalingMultiplier = scaling.Multiplier[effect.Index];
                    effect.RandomPointsScalingMultiplier = scaling.RandomPointsMultiplier[effect.Index];
                    effect.ComboPointsScalingMultiplier = scaling.OtherMultiplier[effect.Index];
                }
            }

            foreach (var item in ItemSparse)
            {
                ItemTemplate.Add(new Item
                {
                    Entry = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    SpellId = new[] 
                    {
                        item.SpellId[0],
                        item.SpellId[1],
                        item.SpellId[2],
                        item.SpellId[3],
                        item.SpellId[4]
                    }
                });
            }
        }

        // DB
        public static List<Item> ItemTemplate = new List<Item>();

        public static uint SelectedLevel = MaxLevel;
    }
}
