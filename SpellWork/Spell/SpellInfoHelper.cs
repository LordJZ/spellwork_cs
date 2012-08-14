using System;
using System.Linq;
using System.Text;
using SpellWork.DBC.Structures;
using SpellWork.Extensions;

namespace SpellWork.Spell
{
    public sealed class SpellInfoHelper
    {
        public uint ID;                                           // 0        m_ID
        public uint Category;                                     // 1        m_category
        public uint Dispel;                                       // 2        m_dispelType
        public uint Mechanic;                                     // 3        m_mechanic
        public uint Attributes;                                   // 4        m_attribute
        public uint AttributesEx;                                 // 5        m_attributesEx
        public uint AttributesEx2;                                // 6        m_attributesExB
        public uint AttributesEx3;                                // 7        m_attributesExC
        public uint AttributesEx4;                                // 8        m_attributesExD
        public uint AttributesEx5;                                // 9        m_attributesExE
        public uint AttributesEx6;                                // 10       m_attributesExF
        public uint AttributesEx7;                                // 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
        public uint AttributesEx8;
        public uint AttributesEx9;
        public uint AttributesEx10;
        public ulong Stances;                                     // 12-13    m_shapeshiftMask
        public ulong StancesNot;                                  // 14-15    m_shapeshiftExclude
        public uint Targets;                                      // 16       m_targets
        public uint TargetCreatureType;                           // 17       m_targetCreatureType
        public uint RequiresSpellFocus;                           // 18       m_requiresSpellFocus
        public uint FacingCasterFlags;                            // 19       m_facingCasterFlags
        public uint CasterAuraState;                              // 20       m_casterAuraState
        public uint TargetAuraState;                              // 21       m_targetAuraState
        public uint CasterAuraStateNot;                           // 22       m_excludeCasterAuraState
        public uint TargetAuraStateNot;                           // 23       m_excludeTargetAuraState
        public uint CasterAuraSpell;                              // 24       m_casterAuraSpell
        public uint TargetAuraSpell;                              // 25       m_targetAuraSpell
        public uint ExcludeCasterAuraSpell;                       // 26       m_excludeCasterAuraSpell
        public uint ExcludeTargetAuraSpell;                       // 27       m_excludeTargetAuraSpell
        public uint CastingTimeIndex;                             // 28       m_castingTimeIndex
        public uint RecoveryTime;                                 // 29       m_recoveryTime
        public uint CategoryRecoveryTime;                         // 30       m_categoryRecoveryTime
        public uint InterruptFlags;                               // 31       m_interruptFlags
        public uint AuraInterruptFlags;                           // 32       m_auraInterruptFlags
        public uint ChannelInterruptFlags;                        // 33       m_channelInterruptFlags
        public uint ProcFlags;                                    // 34       m_procTypeMask
        public uint ProcChance;                                   // 35       m_procChance
        public uint ProcCharges;                                  // 36       m_procCharges
        public uint MaxLevel;                                     // 37       m_maxLevel
        public uint BaseLevel;                                    // 38       m_baseLevel
        public uint SpellLevel;                                   // 39       m_spellLevel
        public uint DurationIndex;                                // 40       m_durationIndex
        public uint PowerType;                                    // 41       m_powerType
        public uint ManaCost;                                     // 42       m_manaCost
        public uint ManaCostPerlevel;                             // 43       m_manaCostPerLevel
        public uint ManaPerSecond;                                // 44       m_manaPerSecond
        public uint RangeIndex;                                   // 46       m_rangeIndex
        public float Speed;                                       // 47       m_speed
        public uint ModalNextSpell;                               // 48       m_modalNextSpell not used
        public uint StackAmount;                                  // 49       m_cumulativeAura
        public uint[] Totem;                                      // 50-51    m_totem
        public uint[] Reagent;                                    // 52-59    m_reagent
        public uint[] ReagentCount;                               // 60-67    m_reagentCount
        public uint EquippedItemClass;                             // 68       m_equippedItemClass (value)
        public uint EquippedItemSubClassMask;                      // 69       m_equippedItemSubclass (mask)
        public uint EquippedItemInventoryTypeMask;                 // 70       m_equippedItemInvTypes (mask)
        public uint[] SpellVisual;                                // 131-132  m_spellVisualID
        public uint SpellIconID;                                  // 133      m_spellIconID
        public uint ActiveIconID;                                 // 134      m_activeIconID
        public string SpellName;                                // 136-151  m_name_lang
        public string Rank;                                     // 153-168  m_nameSubtext_lang
        public string Description;                              // 170-185  m_description_lang not used
        public string ToolTip;                                  // 187-202  m_auraDescription_lang not used
        public uint ManaCostPercentage;                           // 204      m_manaCostPct
        public uint StartRecoveryCategory;                        // 205      m_startRecoveryCategory
        public uint StartRecoveryTime;                            // 206      m_startRecoveryTime
        public uint MaxTargetLevel;                               // 207      m_maxTargetLevel
        public uint SpellFamilyName;                              // 208      m_spellClassSet
        public uint[] SpellFamilyFlags;                           // 209-211  m_spellClassMask
        public uint MaxAffectedTargets;                           // 212      m_maxTargets
        public uint DmgClass;                                     // 213      m_defenseType
        public uint PreventionType;                               // 214      m_preventionType
        public int StanceBarOrder;                                // 215      m_stanceBarOrder not used
        public uint MinFactionId;                                 // 219      m_minFactionID not used
        public uint MinReputation;                                // 220      m_minReputation not used
        public uint RequiredAuraVision;                           // 221      m_requiredAuraVision not used
        public uint[] TotemCategory;                              // 222-223  m_requiredTotemCategoryID
        public int AreaGroupId;                                  // 224      m_requiredAreaGroupId
        public uint SchoolMask;                                   // 225      m_schoolMask
        public uint RuneCostID;                                   // 226      m_runeCostID
        public uint SpellMissileID;                               // 227      m_spellMissileID not used
        public uint PowerDisplayId;                               // 228      PowerDisplay.dbc, new in 3.1
        public uint SpellDescriptionVariableID;                   // 232      3.2.0
        public uint SpellDifficultyId;                            // 233      3.3.0                           // 239      3.3.0

        public string CastTime
        {
            get
            {
                if (CastingTimeIndex == 0)
                    return String.Empty;

                return !DBC.DBC.SpellCastTimes.ContainsKey(CastingTimeIndex)
                           ? String.Format("CastingTime (Id {0}) = ????", CastingTimeIndex)
                           : String.Format("CastingTime (Id {0}) = {1:F}", CastingTimeIndex,
                                           DBC.DBC.SpellCastTimes[CastingTimeIndex].CastTime / 1000.0f);
            }
        }

        public string Duration
        {
            get { return DBC.DBC.SpellDuration.ContainsKey(DurationIndex) ? DBC.DBC.SpellDuration[DurationIndex].ToString() : String.Empty; }
        }

        public SpellEffectEntry[] Effects
        {
            get { return DBC.DBC.SpellEffect.Records.Where(e => e.SpellId == ID).OrderBy(eff => eff.Index).ToArray(); }
        }

        public string ProcInfo
        {
            get
            {
                var i = 0;
                var sb = new StringBuilder();
                var proc = ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        sb.AppendFormatLine("  {0}", SpellEnums.ProcFlagDesc[i]);
                    ++i;
                    proc >>= 1;
                }

                return sb.ToString();
            }
        }

        public string Range
        {
            get
            {
                if (RangeIndex == 0 || !DBC.DBC.SpellRange.ContainsKey(RangeIndex))
                    return String.Empty;

                var range = DBC.DBC.SpellRange[RangeIndex];
                var sb = new StringBuilder();
                sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", range.Id, range.Name);
                sb.AppendFormatLine("    MinRangeNegative = {0}, MinRangePositive = {1}", range.MinRangeNegative, range.MinRangePositive);
                sb.AppendFormatLine("    MaxRangeNegative = {0}, MaxRangePositive = {1}", range.MaxRangeNegative, range.MaxRangePositive);

                return sb.ToString();
            }
        }

        public SpellSchoolMask School
        {
            get { return (SpellSchoolMask)SchoolMask; }
        }

        public string SpellNameRank
        {
            get { return String.IsNullOrEmpty(Rank) ? SpellName : String.Format("{0} ({1})", SpellName, Rank); }
        }

        public SpellInfoHelper(SpellEntry dbcData)
        {
            ID = dbcData.Id;
            Attributes = dbcData.Attributes;
            AttributesEx = dbcData.AttributesEx;
            AttributesEx2 = dbcData.AttributesEx2;
            AttributesEx3 = dbcData.AttributesEx3;
            AttributesEx4 = dbcData.AttributesEx4;
            AttributesEx5 = dbcData.AttributesEx5;
            AttributesEx6 = dbcData.AttributesEx6;
            AttributesEx7 = dbcData.AttributesEx7;
            AttributesEx8 = dbcData.AttributesEx8;
            CastingTimeIndex = dbcData.CastingTimeIndex;
            DurationIndex = dbcData.DurationIndex;
            PowerType = dbcData.PowerType;
            RangeIndex = dbcData.RangeIndex;
            Speed = dbcData.Speed;
            SpellVisual = (uint[])dbcData.SpellVisual.Clone();
            SpellIconID = dbcData.SpellIconID;
            ActiveIconID = dbcData.ActiveIconID;
            SpellName = dbcData.SpellName;
            Rank = dbcData.Rank;
            Description = dbcData.Description;
            ToolTip = dbcData.ToolTip;
            SchoolMask = dbcData.SchoolMask;
            RuneCostID = dbcData.RuneCostID;
            SpellMissileID = dbcData.SpellMissileID;

            // SpellCategories.dbc
            var cat = dbcData.Category;
            if (cat != null)
            {
                Category = cat.Category;
                Dispel = cat.Dispel;
                Mechanic = cat.Mechanic;
                StartRecoveryCategory = cat.StartRecoveryCategory;
                DmgClass = cat.DmgClass;
                PreventionType = cat.PreventionType;
            }

            // SpellShapeshift.dbc
            var shapeshift = dbcData.Shapeshift;
            if (shapeshift != null)
            {
                Stances = shapeshift.Stances;
                StancesNot = shapeshift.StancesNot;
                StanceBarOrder = shapeshift.StanceBarOrder;
            }

            // SpellTargetRestrictions.dbc
            var targetRestrictions = dbcData.TargetRestrictions;
            if (targetRestrictions != null)
            {
                Targets = targetRestrictions.Targets;
                TargetCreatureType = targetRestrictions.TargetCreatureType;
                MaxAffectedTargets = targetRestrictions.MaxAffectedTargets;
                MaxTargetLevel = targetRestrictions.MaxTargetLevel;
            }

            // SpellCastingRequirements.dbc
            var castingRequirements = dbcData.CastingRequirements;
            if (castingRequirements != null)
            {
                RequiresSpellFocus = castingRequirements.RequiresSpellFocus;
                FacingCasterFlags = castingRequirements.FacingCasterFlags;
                MinFactionId = castingRequirements.MinFactionId;
                MinReputation = castingRequirements.MinReputation;
                RequiredAuraVision = castingRequirements.RequiredAuraVision;
                AreaGroupId = castingRequirements.AreaGroupId;
            }

            // SpellAuraRestrictions.dbc
            var auraRestrictions = dbcData.AuraRestrictions;
            if (auraRestrictions != null)
            {
                CasterAuraState = auraRestrictions.CasterAuraState;
                TargetAuraState = auraRestrictions.TargetAuraState;
                CasterAuraStateNot = auraRestrictions.CasterAuraStateNot;
                TargetAuraStateNot = auraRestrictions.TargetAuraStateNot;
                CasterAuraSpell = auraRestrictions.CasterAuraSpell;
                TargetAuraSpell = auraRestrictions.TargetAuraSpell;
                ExcludeCasterAuraSpell = auraRestrictions.ExcludeCasterAuraSpell;
                ExcludeTargetAuraSpell = auraRestrictions.ExcludeTargetAuraSpell;
            }

            // SpellCooldowns.dbc
            var cooldowns = dbcData.Cooldowns;
            if (cooldowns != null)
            {
                RecoveryTime = cooldowns.RecoveryTime;
                CategoryRecoveryTime = cooldowns.CategoryRecoveryTime;
                StartRecoveryTime = cooldowns.StartRecoveryTime;
            }

            // SpellInterrupts.dbc
            var interrupts = dbcData.Interrupts;
            if (interrupts != null)
            {
                InterruptFlags = interrupts.InterruptFlags;
                AuraInterruptFlags = interrupts.AuraInterruptFlags;
                ChannelInterruptFlags = interrupts.ChannelInterruptFlags;
            }

            // SpellAuraOptions.dbc
            var options = dbcData.AuraOptions;
            if (options != null)
            {
                ProcFlags = options.ProcFlags;
                ProcChance = options.ProcChance;
                ProcCharges = options.ProcCharges;
                StackAmount = options.StackAmount;
            }

            // SpellLevels.dbc
            var levels = dbcData.Levels;
            if (levels != null)
            {
                MaxLevel = levels.MaxLevel;
                BaseLevel = levels.BaseLevel;
                SpellLevel = levels.SpellLevel;
            }

            // SpellPower.dbc
            var power = dbcData.Power;
            if (power != null)
            {
                ManaCost = power.ManaCost;
                ManaCostPerlevel = power.ManaCostPerlevel;
                ManaPerSecond = power.ManaPerSecond;
                ManaCostPercentage = power.ManaCostPercentage;
                PowerDisplayId = power.PowerDisplayId;
            }

            // SpellClassOptions.dbc
            var classOptions = dbcData.ClassOptions;
            if (classOptions != null)
            {
                ModalNextSpell = classOptions.ModalNextSpell;
                Description = String.IsNullOrEmpty(Description) ? classOptions.Description : Description;
                SpellFamilyName = classOptions.SpellFamilyName;
                SpellFamilyFlags = (uint[])classOptions.SpellFamilyFlags.Clone();
            }
            else
                SpellFamilyFlags = new uint[3];

            // SpellTotems.dbc
            var totems = dbcData.Totems;
            if (totems != null)
            {
                Totem = (uint[])totems.Totem.Clone();
                TotemCategory = (uint[])totems.TotemCategory.Clone();
            }
            else
            {
                Totem = new uint[2];
                TotemCategory = new uint[2];
            }

            // SpellReagents.dbc
            var reagents = dbcData.Reagents;
            if (reagents != null)
            {
                Reagent = (uint[])reagents.ItemId.Clone();
                ReagentCount = (uint[])reagents.Count.Clone();
            }
            else
            {
                Reagent = new uint[8];
                ReagentCount = new uint[8];
            }

            // SpellEquippedItems.dbc
            var equippedItems = dbcData.EquippedItems;
            if (equippedItems != null)
            {
                EquippedItemClass = equippedItems.EquippedItemClass;
                EquippedItemSubClassMask = equippedItems.EquippedItemSubClassMask;
                EquippedItemInventoryTypeMask = equippedItems.EquippedItemInventoryTypeMask;
            }
        }

        public bool HasEffect(SpellEffects effect)
        {
            return Effects.Where(eff => eff.Type == (uint)effect).Count() > 0;
        }

        public bool HasAura(AuraType aura)
        {
            return Effects.Where(eff => eff.ApplyAuraName == (uint)aura).Count() > 0;
        }

        public bool HasTargetA(Targets target)
        {
            return Effects.Where(eff => eff.ImplicitTargetA == (uint)target).Count() > 0;
        }

        public bool HasTargetB(Targets target)
        {
            return Effects.Where(eff => eff.ImplicitTargetB == (uint)target).Count() > 0;
        }
    }
}
