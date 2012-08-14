using System.Linq;
using DBFilesClient.NET;
using System.Text;

namespace SpellWork.DBC.Structures
{
    public sealed class SpellEntry
    {
        public uint Id;
        public uint Attributes;
        public uint AttributesEx;
        public uint AttributesEx2;
        public uint AttributesEx3;
        public uint AttributesEx4;
        public uint AttributesEx5;
        public uint AttributesEx6;
        public uint AttributesEx7;
        public uint AttributesEx8;
        public uint Unknown1;
        public uint Unknown2;
        public uint CastingTimeIndex;
        public uint DurationIndex;
        public uint PowerType;
        public uint RangeIndex;
        public float Speed;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 2)]
        public uint[] SpellVisual;
        public uint SpellIconID;
        public uint ActiveIconID;
        public string SpellName;
        public string Rank;
        public string Description;
        public string ToolTip;
        public uint SchoolMask;
        public uint RuneCostID;
        public uint SpellMissileID;
        public uint SpellDescriptionVariableID;
        public uint SpellDifficultyId;
        public float Unknown3;
        public uint SpellScalingId;
        public uint SpellAuraOptionsId;
        public uint SpellAuraRestrictionsId;
        public uint SpellCastingRequirementsId;
        public uint SpellCategoriesId;
        public uint SpellClassOptionsId;
        public uint SpellCooldownsId;
        public uint Unknown4;
        public uint SpellEquippedItemsId;
        public uint SpellInterruptsId;
        public uint SpellLevelsId;
        public uint SpellPowerId;
        public uint SpellReagentsId;
        public uint SpellShapeshiftId;
        public uint SpellTargetRestrictionsId;
        public uint SpellTotemsId;
        public uint ResearchProject;

        public SpellAuraOptionsEntry AuraOptions
        {
            get { return SpellAuraOptionsId != 0 && DBC.SpellAuraOptions.ContainsKey(SpellAuraOptionsId) ? DBC.SpellAuraOptions[SpellAuraOptionsId] : null; }
        }

        public SpellAuraRestrictionsEntry AuraRestrictions
        {
            get { return SpellAuraRestrictionsId != 0 && DBC.SpellAuraRestrictions.ContainsKey(SpellAuraRestrictionsId) ? DBC.SpellAuraRestrictions[SpellAuraRestrictionsId] : null; }
        }

        public SpellCastingRequirementsEntry CastingRequirements
        {
            get { return SpellCastingRequirementsId != 0 && DBC.SpellCastingRequirements.ContainsKey(SpellCastingRequirementsId) ? DBC.SpellCastingRequirements[SpellCastingRequirementsId] : null; }
        }

        public SpellCategoriesEntry Category
        {
            get { return SpellCategoriesId != 0 && DBC.SpellCategories.ContainsKey(SpellCategoriesId) ? DBC.SpellCategories[SpellCategoriesId] : null; }
        }

        public SpellClassOptionsEntry ClassOptions
        {
            get { return SpellClassOptionsId != 0 && DBC.SpellClassOptions.ContainsKey(SpellClassOptionsId) ? DBC.SpellClassOptions[SpellClassOptionsId] : null; }
        }

        public SpellCooldownsEntry Cooldowns
        {
            get { return SpellCooldownsId != 0 && DBC.SpellCooldowns.ContainsKey(SpellCooldownsId) ? DBC.SpellCooldowns[SpellCooldownsId] : null; }
        }

        public SpellEquippedItemsEntry EquippedItems
        {
            get { return SpellEquippedItemsId != 0 && DBC.SpellEquippedItems.ContainsKey(SpellEquippedItemsId) ? DBC.SpellEquippedItems[SpellEquippedItemsId] : null; }
        }

        public SpellInterruptsEntry Interrupts
        {
            get { return SpellInterruptsId != 0 && DBC.SpellInterrupts.ContainsKey(SpellInterruptsId) ? DBC.SpellInterrupts[SpellInterruptsId] : null; }
        }

        public SpellLevelsEntry Levels
        {
            get { return SpellLevelsId != 0 && DBC.SpellLevels.ContainsKey(SpellLevelsId) ? DBC.SpellLevels[SpellLevelsId] : null; }
        }

        public SpellPowerEntry Power
        {
            get { return SpellPowerId != 0 && DBC.SpellPower.ContainsKey(SpellPowerId) ? DBC.SpellPower[SpellPowerId] : null; }
        }

        public SpellReagentsEntry Reagents
        {
            get { return SpellReagentsId != 0 && DBC.SpellReagents.ContainsKey(SpellReagentsId) ? DBC.SpellReagents[SpellReagentsId] : null; }
        }

        public SpellShapeshiftEntry Shapeshift
        {
            get { return SpellShapeshiftId != 0 && DBC.SpellShapeshift.ContainsKey(SpellShapeshiftId) ? DBC.SpellShapeshift[SpellShapeshiftId] : null; }
        }

        public SpellTargetRestrictionsEntry TargetRestrictions
        {
            get { return SpellTargetRestrictionsId != 0 && DBC.SpellTargetRestrictions.ContainsKey(SpellTargetRestrictionsId) ? DBC.SpellTargetRestrictions[SpellTargetRestrictionsId] : null; }
        }

        public SpellTotemsEntry Totems
        {
            get { return SpellTotemsId != 0 && DBC.SpellTotems.ContainsKey(SpellTotemsId) ? DBC.SpellTotems[SpellTotemsId] : null; }
        }
    }
}
