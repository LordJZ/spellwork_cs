using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SpellWork
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
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
        public uint AttributesExG;                                // 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
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
        public uint ManaPerSecondPerLevel;                        // 45       m_manaPerSecondPerLevel
        public uint RangeIndex;                                   // 46       m_rangeIndex
        public float Speed;                                       // 47       m_speed
        public uint ModalNextSpell;                               // 48       m_modalNextSpell not used
        public uint StackAmount;                                  // 49       m_cumulativeAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Totem;                                      // 50-51    m_totem
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] Reagent;                                     // 52-59    m_reagent
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] ReagentCount;                               // 60-67    m_reagentCount
        public int EquippedItemClass;                             // 68       m_equippedItemClass (value)
        public int EquippedItemSubClassMask;                      // 69       m_equippedItemSubclass (mask)
        public int EquippedItemInventoryTypeMask;                 // 70       m_equippedItemInvTypes (mask)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect;                     				  // 71-73    m_effect
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectDieSides;                              // 74-76    m_effectDieSides
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectRealPointsPerLevel;                  // 77-79    m_effectRealPointsPerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectBasePoints;                            // 80-82    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectMechanic;                             // 83-85    m_effectMechanic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectImplicitTargetA;                      // 86-88    m_implicitTargetA
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectImplicitTargetB;                      // 89-91    m_implicitTargetB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectRadiusIndex;                          // 92-94    m_effectRadiusIndex - spellradius.dbc
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectApplyAuraName;                        // 95-97    m_effectAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectAmplitude;                            // 98-100   m_effectAuraPeriod
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectMultipleValue;                       // 101-103  m_effectAmplitude
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectChainTarget;                          // 104-106  m_effectChainTargets
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectItemType;                             // 107-109  m_effectItemType
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectMiscValue;                             // 110-112  m_effectMiscValue
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectMiscValueB;                            // 113-115  m_effectMiscValueB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectTriggerSpell;                         // 116-118  m_effectTriggerSpell
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectPointsPerComboPoint;                 // 119-121  m_effectPointsPerCombo
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskA;                      // 122-124  m_effectSpellClassMaskA, effect 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskB;                      // 125-127  m_effectSpellClassMaskB, effect 1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskC;                      // 128-130  m_effectSpellClassMaskC, effect 2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellVisual;                                // 131-132  m_spellVisualID
        public uint SpellIconID;                                  // 133      m_spellIconID
        public uint ActiveIconID;                                 // 134      m_activeIconID
        public uint SpellPriority;                                // 135      m_spellPriority not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _SpellName;                                // 136-151  m_name_lang
        public uint SpellNameFlag;                                // 152      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Rank;                                     // 153-168  m_nameSubtext_lang
        public uint RankFlags;                                    // 169      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Description;                              // 170-185  m_description_lang not used
        public uint DescriptionFlags;                             // 186      not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _ToolTip;                                  // 187-202  m_auraDescription_lang not used
        public uint ToolTipFlags;                                 // 203      not used
        public uint ManaCostPercentage;                           // 204      m_manaCostPct
        public uint StartRecoveryCategory;                        // 205      m_startRecoveryCategory
        public uint StartRecoveryTime;                            // 206      m_startRecoveryTime
        public uint MaxTargetLevel;                               // 207      m_maxTargetLevel
        public uint SpellFamilyName;                              // 208      m_spellClassSet
        public uint SpellFamilyFlags1;                            // 209-210  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint SpellFamilyFlags2;
        public uint SpellFamilyFlags3;                            // 211      addition to m_spellClassMask
        public uint MaxAffectedTargets;                           // 212      m_maxTargets
        public uint DmgClass;                                     // 213      m_defenseType
        public uint PreventionType;                               // 214      m_preventionType
        public uint StanceBarOrder;                               // 215      m_stanceBarOrder not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] DmgMultiplier;              				  // 216-218  m_effectChainAmplitude
        public uint MinFactionId;                                 // 219      m_minFactionID not used
        public uint MinReputation;                                // 220      m_minReputation not used
        public uint RequiredAuraVision;                           // 221      m_requiredAuraVision not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TotemCategory;                              // 222-223  m_requiredTotemCategoryID
        public int  AreaGroupId;                                  // 224      m_requiredAreaGroupId
        public uint SchoolMask;                                   // 225      m_schoolMask
        public uint RuneCostID;                                   // 226      m_runeCostID
        public uint SpellMissileID;                               // 227      m_spellMissileID not used
        public uint PowerDisplayId;                               // 228      PowerDisplay.dbc, new in 3.1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Unk_320_4;                                 // 229-231  3.2.0
        public uint SpellDescriptionVariableID;                   // 232      3.2.0
        public uint SpellDifficultyId;                            // 233      3.3.0                           // 239      3.3.0

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get
            {
                string s;
                uint offset = _SpellName[(uint)DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get
            {
                string s;
                uint offset = _Rank[(uint)DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        public string SpellNameRank
        {
            get
            {
                string n, r;

                uint offsetname = _SpellName[(uint)DBC.Locale];
                uint offsetrank = _Rank[(uint)DBC.Locale];

                DBC._SpellStrings.TryGetValue(offsetname, out n);
                DBC._SpellStrings.TryGetValue(offsetrank, out r);
                
                return r == String.Empty ? n : n + " (" + r + ")";
            }
        }

        /// <summary>
        /// Return current Spell Description
        /// </summary>
        public string Description
        {
            get
            {
                string s;
                uint offset = _Description[(uint)DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get
            {
                string s;
                uint offset = _ToolTip[(uint)DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        public string GetName(byte loc)
        {
            string s;
            uint offset = _SpellName[loc];
            DBC._SpellStrings.TryGetValue(offset, out s);
            return s;
        }

        public string ProcInfo
        {
            get
            {
                int i = 0;
                string str = String.Empty;
                var proc = ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        str += String.Format("  {0}{1}", SpellEnums.ProcFlagDesc[i], Environment.NewLine);
                    i++;
                    proc >>= 1;
                }
                return str;
            }
        }

        public string Duration
        {
            get
            {
                if (DBC.SpellDuration.ContainsKey(DurationIndex))
                {
                    var q = DBC.SpellDuration[DurationIndex];
                    return String.Format("Duration: ID {0}  {1}, {2}, {3}", q.ID, q.Duration[0], q.Duration[1], q.Duration[2]);
                }
                return String.Empty;
            }
        }

        public string Range
        {
            get
            {
                if (RangeIndex == 0 || !DBC.SpellRange.ContainsKey(RangeIndex))
                    return String.Empty;

                var q = DBC.SpellRange[RangeIndex];
                StringBuilder sb = new StringBuilder();
                sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", q.ID, q.Description1);
                sb.AppendFormatLine("    MinRange = {0}, MinRangeFriendly = {1}", q.MinRange, q.MinRangeFriendly);
                sb.AppendFormatLine("    MaxRange = {0}, MaxRangeFriendly = {1}", q.MaxRange, q.MaxRangeFriendly);

                return sb.ToString();
            }
        }

        public string GetRadius(int index)
        {
            var rIndex = EffectRadiusIndex[index];
            if (rIndex != 0)
            {
                if (DBC.SpellRadius.ContainsKey(rIndex))
                    return String.Format("Radius (Id {0}) {0:F}", rIndex, DBC.SpellRadius[rIndex].Radius);
                else
                    return String.Format("Radius (Id {0}) Not found", rIndex);
            }
            return String.Empty;
        }

        public string GetAuraModTypeName(int index)
        {
            var id = EffectApplyAuraName[index];
            var mod = EffectMiscValue[index];
            if (id == 107 || id == 108 || mod < 29)
                return ((SpellModOp)mod).ToString();
            return mod.ToString();
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
                    return String.Format("CastingTime (Id {0}) = {1:F}", CastingTimeIndex, DBC.SpellCastTimes[CastingTimeIndex].CastTime / 1000.0f);
            }
        }

        public SpellSchoolMask School
        {
            get
            {
                return (SpellSchoolMask)SchoolMask;
            }
        }

        public string GetTriggerSpellInfo(int index)
        {
            StringBuilder sb = new StringBuilder();
            var tsId = EffectTriggerSpell[index];
            if (tsId != 0)
            {
                if (DBC.Spell.ContainsKey(tsId))
                {
                    var trigger = DBC.Spell[tsId];
                    sb.AppendFormatLine("Trigger spell ({0}) {1}. Chance = {2}", tsId, trigger.SpellNameRank, ProcChance);

                    sb.AppendFormatLineIfNotNull("Description: {0}", trigger.Description);
                    sb.AppendFormatLineIfNotNull("ToolTip: {0}", trigger.ToolTip);

                    if (trigger.ProcFlags != 0)
                    {
                        sb.AppendFormatLine("Charges - {0}", trigger.ProcCharges);
                        sb.AppendLine("=================================================");
                        sb.Append(trigger.ProcInfo);
                        sb.AppendLine("=================================================");
                    }
                }
                else
                {
                    sb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", tsId, ProcChance);
                }
            }

            return sb.ToString();
        }
    };

    public struct SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int  CategoryId;                                     // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Name;                                       // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Description;                                // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36
        public uint SpellIcon;                                     // 37       m_spellIconID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _AlternateVerb;                              // 38-53    m_alternateVerb_lang
        public uint AlternateVerbFlags;                            // 54
        public uint CanLink;                                       // 55       m_canLink (prof. with recipes

        public string Name
        {
            get
            {
                string s;
                uint offset = _Name[(uint)DBC.Locale];
                DBC._SkillLineStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        public string Description
        {
            get
            {
                string s;
                uint offset = _Description[(uint)DBC.Locale];
                DBC._SkillLineStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        public string AlternateVerb
        {
            get
            {
                string s;
                uint offset = _AlternateVerb[(uint)DBC.Locale];
                DBC._SkillLineStrings.TryGetValue(offset, out s);
                return s;
            }
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
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Desc1;
        public uint  Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] _Desc2;
        public uint  Desc2Flags;

        public string Description1
        {
            get
            {
                string s;
                uint offset = _Desc1[(uint)DBC.Locale];
                DBC._SpellRangeStrings.TryGetValue(offset, out s);
                return s;
            }
        }

        public string Description2
        {
            get
            {
                string s;
                uint offset = _Desc2[(uint)DBC.Locale];
                DBC._SpellRangeStrings.TryGetValue(offset, out s);
                return s;
            }
        }
    };

    public struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Duration;
    };

    public struct SpellCastTimesEntry
    {
        public uint  ID;
        public int   CastTime;   
        public float CastTimePerLevel;
        public int   MinCastTime;
    };

    //=============== DateBase =================\\

    public struct SpellProcEvent
    {
        public uint     ID;
        public ushort   SchoolMask;
        public uint     SpellFamilyName;
        public uint     SpellFamilyMask0;
        public uint     SpellFamilyMask1;
        public uint     SpellFamilyMask2;
        public uint     ProcFlags;
        public uint     ProcEx;
        public float    PpmRate;
        public float    CustomChance;
        public uint     Cooldown;
    };

    public struct SpellChain
    {
        public int ID;
        public int PrevSpell;
        public int FirstSpell;
        public int Rank;
        public int ReqSpell;
    };
}
