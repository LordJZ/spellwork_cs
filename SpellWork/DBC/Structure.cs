using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SpellWork
{
    public struct DbcHeader
    {
        public int Signature;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;
        
        public bool IsDBC
        {
            get { return Signature == 0x43424457; }
        }
        
        public long DataSize
        {
            get { return (long)(RecordsCount * RecordSize); }
        }

        public long StartStringPosition
        {
            get { return DataSize + (long)Marshal.SizeOf(typeof(DbcHeader)); }
        }
    };

    public struct CurrencyTypesEntry
    {
        public uint Id;
        public uint Category;
        public uint _Name;
        public uint _Icon;
        public uint Unk0;
        public uint Unk1_Archaeology;
        public uint Unk2_Archaeology;
        public uint TotalCap;
        public uint WeekCap;
        public uint Unk3;
        public uint _Desc;

        public string Name { get { return DBC.CurrencyTypesStrings.GetValue(_Name); } }
        public string Icon { get { return DBC.CurrencyTypesStrings.GetValue(_Icon); } }
        public string Desc { get { return DBC.CurrencyTypesStrings.GetValue(_Desc); } }
    };

    // SpellAuraOptions.dbc
    public struct SpellAuraOptionsEntry
    {
        public uint    Id;                                        // 0        m_ID
        public uint StackAmount;                                  // 51       m_cumulativeAura
        public uint ProcChance;                                   // 38       m_procChance
        public uint ProcCharges;                                  // 39       m_procCharges
        public uint ProcFlags;                                    // 37       m_procTypeMask
    };

    // SpellAuraRestrictions.dbc
    public struct SpellAuraRestrictionsEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint CasterAuraState;                              // 21       m_casterAuraState
        public uint TargetAuraState;                              // 22       m_targetAuraState
        public uint CasterAuraStateNot;                           // 23       m_excludeCasterAuraState
        public uint TargetAuraStateNot;                           // 24       m_excludeTargetAuraState
        public uint CasterAuraSpell;                              // 25       m_casterAuraSpell
        public uint TargetAuraSpell;                              // 26       m_targetAuraSpell
        public uint ExcludeCasterAuraSpell;                       // 27       m_excludeCasterAuraSpell
        public uint ExcludeTargetAuraSpell;                       // 28       m_excludeTargetAuraSpell
    };

    // SpellCastingRequirements.dbc
    public struct SpellCastingRequirementsEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint FacingCasterFlags;                            // 20       m_facingCasterFlags
        public uint MinFactionId;                                 // 159      m_minFactionID not used
        public uint MinReputation;                                // 160      m_minReputation not used
        public int AreaGroupId;                                   // 164      m_requiredAreaGroupId
        public uint RequiredAuraVision;                           // 161      m_requiredAuraVision not used
        public uint RequiresSpellFocus;                           // 19       m_requiresSpellFocus
    };

    // SpellCategories.dbc
    public struct SpellCategoriesEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint Category;                                     // 1        m_category
        public uint DmgClass;                                     // 153      m_defenseType
        public uint Dispel;                                       // 2        m_dispelType
        public uint Mechanic;                                     // 3        m_mechanic
        public uint PreventionType;                               // 154      m_preventionType
        public uint StartRecoveryCategory;                        // 145      m_startRecoveryCategory
    };

    // SpellClassOptions.dbc
    public struct SpellClassOptionsEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint ModalNextSpell;                               // 50       m_modalNextSpell not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] SpellFamilyFlags;                           // 149-150  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint SpellFamilyName;                              // 148      m_spellClassSet
        public uint Description;                                  // 6 4.0.0
    };

    // SpellCooldowns.dbc
    public struct SpellCooldownsEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint CategoryRecoveryTime;                         // 31       m_categoryRecoveryTime
        public uint RecoveryTime;                                 // 30       m_recoveryTime
        public uint StartRecoveryTime;                            // 146      m_startRecoveryTime
    };

    // SpellEffect.dbc
    public struct SpellEffectEntry
    {
        public uint Id;                                           // 0        m_ID
        public uint Effect;                                       // 73-75    m_effect
        public float EffectMultipleValue;                         // 106-108  m_effectAmplitude
        public uint EffectApplyAuraName;                          // 100-102  m_effectAura
        public uint EffectAmplitude;                              // 103-105  m_effectAuraPeriod
        public int EffectBasePoints;                              // 82-84    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        public float Unk_320_4;                                   // 169-171  3.2.0
        public float DmgMultiplier;                               // 156-158  m_effectChainAmplitude
        public uint EffectChainTarget;                            // 109-111  m_effectChainTargets
        public int EffectDieSides;                                // 76-78    m_effectDieSides
        public uint EffectItemType;                               // 112-114  m_effectItemType
        public uint EffectMechanic;                               // 85-87    m_effectMechanic
        public int EffectMiscValue;                               // 115-117  m_effectMiscValue
        public int EffectMiscValueB;                              // 118-120  m_effectMiscValueB
        public float EffectPointsPerComboPoint;                   // 124-126  m_effectPointsPerCombo
        public uint EffectRadiusIndex;                            // 94-96    m_effectRadiusIndex - spellradius.dbc
        public uint EffectRadiusMaxIndex;                         // 97-99    4.0.0
        public float EffectRealPointsPerLevel;                    // 79-81    m_effectRealPointsPerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskA;                      // 127-129  m_effectSpellClassMaskA, effect 0
        public uint EffectTriggerSpell;                           // 121-123  m_effectTriggerSpell
        public uint EffectImplicitTargetA;                        // 88-90    m_implicitTargetA
        public uint EffectImplicitTargetB;                        // 91-93    m_implicitTargetB
        public uint EffectSpellId;                                // new 4.0.0
        public uint EffectIndex;                                  // new 4.0.0
    };

    // SpellEquippedItems.dbc
    public struct SpellEquippedItemsEntry
    {
        public uint     Id;                                          // 0        m_ID
        public int     EquippedItemClass;                            // 70       m_equippedItemClass (value)
        public int     EquippedItemInventoryTypeMask;                // 72       m_equippedItemInvTypes (mask)
        public int     EquippedItemSubClassMask;                     // 71       m_equippedItemSubclass (mask)
    };

    // SpellInterrupts.dbc
    public struct SpellInterruptsEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     AuraInterruptFlags;                           // 33       m_auraInterruptFlags
        public uint     Unk1;                                         // 34       4.0.0
        public uint     ChannelInterruptFlags;                        // 35       m_channelInterruptFlags
        public uint     Unk2;                                         // 36       4.0.0
        public uint     InterruptFlags;                               // 32       m_interruptFlags
    };

    // SpellLevels.dbc
    public struct SpellLevelsEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     BaseLevel;                                    // 41       m_baseLevel
        public uint     MaxLevel;                                     // 40       m_maxLevel
        public uint     SpellLevel;                                   // 42       m_spellLevel
    };

    // SpellPower.dbc
    public struct SpellPowerEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     ManaCost;                                     // 45       m_manaCost
        public uint     ManaCostPerlevel;                             // 46       m_manaCostPerLevel
        public uint     ManaCostPercentage;                           // 144      m_manaCostPct
        public uint     ManaPerSecond;                                // 47       m_manaPerSecond
        public uint   PowerDisplayId;                                 // 168      PowerDisplay.dbc, new in 3.1
        public uint   Unk1;                                           // 6        4.0.0
    };

    // SpellReagents.dbc
    public struct SpellReagentsEntry
    {
        public uint     Id;                                           // 0        m_ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[]      Reagent;                                    // 54-61    m_reagent
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[]     ReagentCount;                               // 62-69    m_reagentCount
    };

    // SpellScaling.dbc
    public struct SpellScalingEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     unk1;                                         // 1
        public uint     unk2;                                         // 2
        public uint     unk3;                                         // 3
        public uint     unk4;                                         // 4        class?
        public float     unk5;                                        // 5
        public float     unk6;                                        // 6
        public float     unk7;                                        // 7
        public float     unk8;                                        // 8
        public float     unk9;                                        // 9
        public float     unk10;                                       // 10       all zeros
        public float     unk11;                                       // 11
        public float     unk12;                                       // 12       all zeros
        public float     unk13;                                       // 13       all zeros
        public float     unk14;                                       // 14
        public uint     unk15;                                        // 15
    };

    // SpellShapeshift.dbc
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct SpellShapeshiftEntry
    {
        [FieldOffset(0x00)]
        public uint     Id;                                           // 0        m_ID
        [FieldOffset(0x04)]
        public ulong    Stances;                                      // 13       m_shapeshiftMask
        [FieldOffset(0x0C)]
        public ulong    StancesNot;                                   // 15       m_shapeshiftExclude
        [FieldOffset(0x14)]
        public uint     StanceBarOrder;                               // 155      m_stanceBarOrder not used
    };

    // SpellTargetRestrictions.dbc
    public struct SpellTargetRestrictionsEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     MaxAffectedTargets;                           // 152      m_maxTargets
        public uint     MaxTargetLevel;                               // 147      m_maxTargetLevel
        public uint     TargetCreatureType;                           // 18       m_targetCreatureType
        public uint     Targets;                                      // 17       m_targets
    };

    // SpellTotems.dbc
    public struct SpellTotemsEntry
    {
        public uint     Id;                                           // 0        m_ID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]     TotemCategory;                              // 162-163  m_requiredTotemCategoryID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]     Totem;                                      // 52-53    m_totem
    };

    // Spell.dbc
    public struct SpellEntry
    {
        public uint    ID;                                           // 0        m_ID
        public uint    Attributes;                                   // 1        m_attribute
        public uint    AttributesEx;                                 // 2        m_attributesEx
        public uint    AttributesEx2;                                // 3        m_attributesExB
        public uint    AttributesEx3;                                // 4        m_attributesExC
        public uint    AttributesEx4;                                // 5        m_attributesExD
        public uint    AttributesEx5;                                // 6        m_attributesExE
        public uint    AttributesEx6;                                // 7        m_attributesExF
        public uint AttributesExG;                                   // 8        3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
        public uint SomeFlags;                                       // 9        4.0.0
        public uint Unk_400_1;                                       // 10       4.0.0
        public uint    CastingTimeIndex;                             // 11       m_castingTimeIndex
        public uint    DurationIndex;                                // 12       m_durationIndex
        public uint    PowerType;                                    // 13       m_powerType
        public uint    RangeIndex;                                   // 14       m_rangeIndex
        public float     Speed;                                      // 15       m_speed
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]    SpellVisual;                                // 16-17    m_spellVisualID
        public uint    SpellIconID;                                  // 18       m_spellIconID
        public uint    ActiveIconID;                                 // 19       m_activeIconID
        public uint _SpellName;                                      // 20       m_name_lang
        public uint _Rank;                                           // 21       m_nameSubtext_lang
        public uint _Description;                                    // 22       m_description_lang not used
        public uint _ToolTip;                                        // 23       m_auraDescription_lang not used
        public uint    SchoolMask;                                   // 24       m_schoolMask
        public uint    RuneCostID;                                   // 25       m_runeCostID
        public uint    SpellMissileID;                               // 26       m_spellMissileID not used
        public uint  SpellDescriptionVariableID;                     // 27       3.2.0
        public uint  SpellDifficultyId;                              // 28       m_spellDifficultyID - id from SpellDifficulty.dbc
        public float Unk_f1;                                         // 29
        public uint SpellScalingId;                                  // 30       SpellScaling.dbc
        public uint SpellAuraOptionsId;                              // 31       SpellAuraOptions.dbc
        public uint SpellAuraRestrictionsId;                         // 32       SpellAuraRestrictions.dbc
        public uint SpellCastingRequirementsId;                      // 33       SpellCastingRequirements.dbc
        public uint SpellCategoriesId;                               // 34       SpellCategories.dbc
        public uint SpellClassOptionsId;                             // 35       SpellClassOptions.dbc
        public uint SpellCooldownsId;                                // 36       SpellCooldowns.dbc
        public uint UnkIndex7;                                       // 37       all zeros...
        public uint SpellEquippedItemsId;                            // 38       SpellEquippedItems.dbc
        public uint SpellInterruptsId;                               // 39       SpellInterrupts.dbc
        public uint SpellLevelsId;                                   // 40       SpellLevels.dbc
        public uint SpellPowerId;                                    // 41       SpellPower.dbc
        public uint SpellReagentsId;                                 // 42       SpellReagents.dbc
        public uint SpellShapeshiftId;                               // 43       SpellShapeshift.dbc
        public uint SpellTargetRestrictionsId;                       // 44       SpellTargetRestrictions.dbc
        public uint SpellTotemsId;                                   // 45       SpellTotems.dbc
        public uint ResearchProject;                                 // 46       ResearchProject.dbc

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get { return DBC.SpellStrings.GetValue(_SpellName); }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get { return _Rank != 0 ? DBC.SpellStrings[_Rank] : ""; }
        }

        public string SpellNameRank
        {
            get { return Rank.IsEmpty() ? SpellName : String.Format("{0} ({1})", SpellName, Rank); }
        }

        /// <summary>
        /// Return current Spell Description
        /// </summary>
        public string Description
        {
            get { return DBC.SpellStrings.GetValue(_Description); }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return DBC.SpellStrings.GetValue(_ToolTip); }
        }

        public string GetName(byte loc)
        {
            return DBC.SpellStrings.GetValue(_SpellName);
        }

        public string ProcInfo
        {
            get
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
                uint proc = SpellAuraOptions.ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        sb.AppendFormatLine("  {0}", SpellEnums.ProcFlagDesc[i]);
                    i++;
                    proc >>= 1;
                }
                return sb.ToString();
            }
        }

        public string Duration
        {
            get { return DBC.SpellDuration.ContainsKey(DurationIndex) ? DBC.SpellDuration[DurationIndex].ToString() : String.Empty; }
        }

        public string Range
        {
            get
            {
                if (RangeIndex == 0 || !DBC.SpellRange.ContainsKey(RangeIndex))
                    return String.Empty;

                SpellRangeEntry range = DBC.SpellRange[RangeIndex];
                StringBuilder sb = new StringBuilder();
                sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", range.ID, range.Description1);
                sb.AppendFormatLine("    MinRange = {0}, MinRangeFriendly = {1}", range.MinRange, range.MinRangeFriendly);
                sb.AppendFormatLine("    MaxRange = {0}, MaxRangeFriendly = {1}", range.MaxRange, range.MaxRangeFriendly);

                return sb.ToString();
            }
        }

        public string GetRadius(int index)
        {
            uint rIndex = GetEffect(index).EffectRadiusIndex;
            if (rIndex != 0)
            {
                if (DBC.SpellRadius.ContainsKey(rIndex))
                    return String.Format("Radius (Id {0}) {1:F}", rIndex, DBC.SpellRadius[rIndex].Radius);
                else
                    return String.Format("Radius (Id {0}) Not found", rIndex);
            }
            return String.Empty;
        }

        public bool HasEffectAtIndex(int index)
        {
            try
            {
                var value = DBC.SpellEffects[ID][index];
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool HasSpellEffect(int effect)
        {
            try
            {
                var value = DBC.SpellEffects[ID];
                foreach (var eff in value)
                {
                    if (eff.Value.Effect == effect)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool HasSpellAura(int aura)
        {
            try
            {
                var value = DBC.SpellEffects[ID];
                foreach (var eff in value)
                {
                    if (eff.Value.EffectApplyAuraName == aura)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool HasSpellTargetA(int target)
        {
            try
            {
                var value = DBC.SpellEffects[ID];
                foreach (var eff in value)
                {
                    if (eff.Value.EffectImplicitTargetA == target)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool HasSpellTargetB(int target)
        {
            try
            {
                var value = DBC.SpellEffects[ID];
                foreach (var eff in value)
                {
                    if (eff.Value.EffectImplicitTargetB == target)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public SpellEffectEntry GetEffect(int index)
        {
            try
            {
                return DBC.SpellEffects[ID][index];
            }
            catch
            {
                return default(SpellEffectEntry);
            }
        }

        public string CastTime
        {
            get
            {
                if (CastingTimeIndex == 0)
                    return String.Empty;

                if (!DBC.SpellCastTimes.ContainsKey(CastingTimeIndex))
                    return String.Format("CastingTime (Id {0}) = ????", CastingTimeIndex);
                else
                    return String.Format("CastingTime (Id {0}) = {1:F}",
                        CastingTimeIndex, DBC.SpellCastTimes[CastingTimeIndex].CastTime / 1000.0f);
            }
        }

        public string SpellDifficulty
        {
            get
            {
                if (SpellDifficultyId == 0)
                    return string.Empty;

                StringBuilder builder = new StringBuilder("Spell Difficulty Id: " + SpellDifficultyId);

                SpellDifficultyEntry entry;
                if (DBC.SpellDifficulty.TryGetValue(SpellDifficultyId, out entry))
                {
                    builder.AppendLine();

                    for (int i = 0; i < entry.Spells.Length; ++i)
                    {
                        int spellId = entry.Spells[i];

                        builder.AppendFormat("    {0}) {1} - ", i, spellId);

                        SpellEntry spell;
                        if (DBC.Spell.TryGetValue((uint)spellId, out spell))
                            builder.AppendLine(spell.SpellNameRank);
                        else
                            builder.AppendLine("(Not Found in Spell.dbc)");
                    }
                }
                else
                    builder.AppendLine(" (Not Found in SpellDifficulty.dbc)");

                return builder.ToString();
            }
        }

        public SpellSchoolMask School
        {
            get
            {
                return (SpellSchoolMask)SchoolMask;
            }
        }

        public SpellTargetRestrictionsEntry SpellTargetRestrictions
        {
            get
            {
                try
                {
                    return DBC.SpellTargetRestrictions[SpellTargetRestrictionsId];
                }
                catch
                {
                    return default(SpellTargetRestrictionsEntry);
                }
            }
        }

        public SpellAuraRestrictionsEntry SpellAuraRestrictions
        {
            get
            {
                try
                {
                    return DBC.SpellAuraRestrictions[SpellAuraRestrictionsId];
                }
                catch
                {
                    return default(SpellAuraRestrictionsEntry);
                }
            }
        }

        public SpellCooldownsEntry SpellCooldowns
        {
            get
            {
                try
                {
                    return DBC.SpellCooldowns[SpellCooldownsId];
                }
                catch
                {
                    return default(SpellCooldownsEntry);
                }
            }
        }

        public SpellCategoriesEntry SpellCategories
        {
            get
            {
                try
                {
                    return DBC.SpellCategories[SpellCategoriesId];
                }
                catch
                {
                    return default(SpellCategoriesEntry);
                }
            }
        }

        public SpellShapeshiftEntry SpellShapeshift
        {
            get
            {
                try
                {
                    return DBC.SpellShapeshift[SpellShapeshiftId];
                }
                catch
                {
                    return default(SpellShapeshiftEntry);
                }
            }
        }

        public SpellAuraOptionsEntry SpellAuraOptions
        {
            get
            {
                try
                {
                    return DBC.SpellAuraOptions[SpellAuraOptionsId];
                }
                catch
                {
                    return default(SpellAuraOptionsEntry);
                }
            }
        }

        public SpellLevelsEntry SpellLevels
        {
            get
            {
                try
                {
                    return DBC.SpellLevels[SpellLevelsId];
                }
                catch
                {
                    return default(SpellLevelsEntry);
                }
            }
        }

        public SpellClassOptionsEntry SpellClassOptions
        {
            get
            {
                try
                {
                    return DBC.SpellClassOptions[SpellClassOptionsId];
                }
                catch
                {
                    return default(SpellClassOptionsEntry);
                }
            }
        }

        public SpellCastingRequirementsEntry SpellCastingRequirements
        {
            get
            {
                try
                {
                    return DBC.SpellCastingRequirements[SpellCastingRequirementsId];
                }
                catch
                {
                    return default(SpellCastingRequirementsEntry);
                }
            }
        }

        public SpellPowerEntry SpellPower
        {
            get
            {
                try
                {
                    return DBC.SpellPower[SpellPowerId];
                }
                catch
                {
                    return default(SpellPowerEntry);
                }
            }
        }

        public SpellInterruptsEntry SpellInterrupts
        {
            get
            {
                try
                {
                    return DBC.SpellInterrupts[SpellInterruptsId];
                }
                catch
                {
                    return default(SpellInterruptsEntry);
                }
            }
        }

        public SpellEquippedItemsEntry SpellEquippedItems
        {
            get
            {
                try
                {
                    return DBC.SpellEquippedItems[SpellEquippedItemsId];
                }
                catch
                {
                    return default(SpellEquippedItemsEntry);
                }
            }
        }

        public string Reagents
        {
            get
            {
                if (SpellReagentsId == 0)
                    return string.Empty;

                SpellReagentsEntry reagents;
                if (!DBC.SpellReagents.TryGetValue(SpellReagentsId, out reagents))
                    return "Reagents: Not Found Id " + SpellReagentsId;

                StringBuilder builder = new StringBuilder();

                bool printedHeader = false;
                for (int i = 0; i < reagents.Reagent.Length; ++i)
                {
                    if (reagents.Reagent[i] == 0)
                        continue;

                    if (!printedHeader)
                    {
                        builder.AppendLine();
                        builder.Append("Reagents:");
                        printedHeader = true;
                    }

                    builder.AppendFormat("  {0}x{1}", reagents.Reagent[i], reagents.ReagentCount[i]);
                }

                if (printedHeader)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                }

                return builder.ToString();
            }
        }
    };

    public struct SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int  CategoryId;                                    // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        public uint _Name;                                         // 3-18     m_displayName_lang
        public uint _Description;                                  // 20-35    m_description_lang
        public uint SpellIcon;                                     // 37       m_spellIconID
        public uint _AlternateVerb;                                // 38-53    m_alternateVerb_lang
        public uint CanLink;                                       // 55       m_canLink (prof. with recipes

        public string Name
        {
            get { return DBC.SkillLineStrings.GetValue(_Name); }
        }

        public string Description
        {
            get { return DBC.SkillLineStrings.GetValue(_Description); }
        }

        public string AlternateVerb
        {
            get { return DBC.SkillLineStrings.GetValue(_AlternateVerb); }
        }
    };

    public struct SkillLineAbilityEntry
    {
        public uint ID;                                             // 0        m_ID
        public uint SkillId;                                        // 1        m_skillLine
        public uint SpellId;                                        // 2        m_spell
        public uint Racemask;                                       // 3        m_raceMask
        public uint Classmask;                                      // 4        m_classMask
        public uint RacemaskNot;                                    // 5        m_excludeRace
        public uint ClassmaskNot;                                   // 6        m_excludeClass
        public uint Req_skill_value;                                // 7        m_minSkillLineRank
        public uint Forward_spellid;                                // 8        m_supercededBySpell
        public uint LearnOnGetSkill;                                // 9        m_acquireMethod
        public uint Max_value;                                      // 10       m_trivialSkillLineRankHigh
        public uint Min_value;                                      // 11       m_trivialSkillLineRankLow
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] CharacterPoints;                              // 12-13    m_characterPoints[2]
    };

    public struct SpellRadiusEntry
    {
        public uint  ID;
        public float Radius;
        public int   Zero;
        public float Radius2;
    };

    public struct SpellRangeEntry
    {
        public uint  ID;
        public float MinRange;
        public float MinRangeFriendly;
        public float MaxRange;
        public float MaxRangeFriendly;
        public uint  Field5;
        public uint _Desc1;
        public uint _Desc2;

        public string Description1
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc1); }
        }

        public string Description2
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc2); }
        }
    };

    public struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Duration;

        public override string ToString()
        {
            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", ID, Duration[0], Duration[1], Duration[2]);
        }
    };

    public struct SpellCastTimesEntry
    {
        public uint  ID;
        public int   CastTime;   
        public float CastTimePerLevel;
        public int   MinCastTime;
    };

    public struct SpellDifficultyEntry
    {
        public uint Id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] Spells;
    };

    public struct ScreenEffectEntry
    {
        public uint Id;
        public uint _Name;
        public uint Unk0;
        public float Unk1;
        public uint Unk2;
        public uint Unk3;           // % of smth?
        public uint Unk4;           // all 0
        public int Unk5;
        public uint Unk6;
        public uint Unk7;

        public string Name
        {
            get { return DBC.ScreenEffectStrings.GetValue(_Name); }
        }
    };

    public struct OverrideSpellDataEntry
    {
        public uint Id;
        // Value 10 also used in SpellInfo.AuraModTypeName
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Spells;
        public uint unk;
        public uint AltBarStringIndex; // string
    };

    //=============== DateBase =================\\

    public struct SpellProcEventEntry
    {
        public uint     ID;
        public string   SpellName;
        public uint     SchoolMask;
        public uint     SpellFamilyName;
        public uint[,]  SpellFamilyMask;
        public uint     ProcFlags;
        public uint     ProcEx;
        public float    PpmRate;
        public float    CustomChance;
        public uint     Cooldown;

        public string[] ToArray()
        {  
            return new[]
            {
                ID.ToString(), 
                SpellName, 
                SchoolMask.ToString(), 
                SpellFamilyName.ToString(), 
                SpellFamilyMask[0,0].ToString(), 
                SpellFamilyMask[0,1].ToString(), 
                SpellFamilyMask[0,2].ToString(), 
                SpellFamilyMask[1,0].ToString(), 
                SpellFamilyMask[1,1].ToString(), 
                SpellFamilyMask[1,2].ToString(),
                SpellFamilyMask[2,0].ToString(), 
                SpellFamilyMask[2,1].ToString(), 
                SpellFamilyMask[2,2].ToString(),
                ProcFlags.ToString(), 
                ProcEx.ToString(), 
                PpmRate.ToString(), 
                CustomChance.ToString(), 
                Cooldown.ToString()
            };
        }
    };

    public struct SpellChain
    {
        public int ID;
        public int PrevSpell;
        public int FirstSpell;
        public int Rank;
        public int ReqSpell;
    };

    public struct Item
    {
        public uint     Entry;
        public string   Name;
        public string   Description;
        public string   LocalesName;
        public string   LocalesDescription;
        public uint[]   SpellID;
    };
}
