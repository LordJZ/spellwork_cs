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
        public uint Stances;                                      // 12       m_shapeshiftMask
        public uint unk_320_2;                                    // 13       3.2.0
        public uint StancesNot;                                   // 14       m_shapeshiftExclude
        public uint unk_320_3;                                    // 15       3.2.0
        public uint Targets;                                      // 16       m_targets
        public uint TargetCreatureType;                           // 17       m_targetCreatureType
        public uint RequiresSpellFocus;                           // 18       m_requiresSpellFocus
        public uint FacingCasterFlags;                            // 19       m_facingCasterFlags
        public uint CasterAuraState;                              // 20       m_casterAuraState
        public uint TargetAuraState;                              // 21       m_targetAuraState
        public uint CasterAuraStateNot;                           // 22       m_excludeCasterAuraState
        public uint TargetAuraStateNot;                           // 23       m_excludeTargetAuraState
        public uint casterAuraSpell;                              // 24       m_casterAuraSpell
        public uint targetAuraSpell;                              // 25       m_targetAuraSpell
        public uint excludeCasterAuraSpell;                       // 26       m_excludeCasterAuraSpell
        public uint excludeTargetAuraSpell;                       // 27       m_excludeTargetAuraSpell
        public uint CastingTimeIndex;                             // 28       m_castingTimeIndex
        public uint RecoveryTime;                                 // 29       m_recoveryTime
        public uint CategoryRecoveryTime;                         // 30       m_categoryRecoveryTime
        public uint InterruptFlags;                               // 31       m_interruptFlags
        public uint AuraInterruptFlags;                           // 32       m_auraInterruptFlags
        public uint ChannelInterruptFlags;                        // 33       m_channelInterruptFlags
        public uint procFlags;                                    // 34       m_procTypeMask
        public uint procChance;                                   // 35       m_procChance
        public uint procCharges;                                  // 36       m_procCharges
        public uint maxLevel;                                     // 37       m_maxLevel
        public uint baseLevel;                                    // 38       m_baseLevel
        public uint spellLevel;                                   // 39       m_spellLevel
        public uint DurationIndex;                                // 40       m_durationIndex
        public uint powerType;                                    // 41       m_powerType
        public uint manaCost;                                     // 42       m_manaCost
        public uint manaCostPerlevel;                             // 43       m_manaCostPerLevel
        public uint manaPerSecond;                                // 44       m_manaPerSecond
        public uint manaPerSecondPerLevel;                        // 45       m_manaPerSecondPerLeve
        public uint rangeIndex;                                   // 46       m_rangeIndex
        public float speed;                                       // 47       m_speed
        public uint modalNextSpell;                               // 48       m_modalNextSpell not used
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
        public uint activeIconID;                                 // 134      m_activeIconID
        public uint spellPriority;                                // 135      m_spellPriority not used
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
        public int AreaGroupId;                                   // 224      m_requiredAreaGroupId
        public uint SchoolMask;                                   // 225      m_schoolMask
        public uint runeCostID;                                   // 226      m_runeCostID
        public uint spellMissileID;                               // 227      m_spellMissileID not used
        public uint PowerDisplayId;                               // 228      PowerDisplay.dbc, new in 3.1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] unk_320_4;                                 // 229-231  3.2.0
        public uint spellDescriptionVariableID;                   // 232      3.2.0
        public uint SpellDifficultyId;                            // 233      3.3.0                           // 239      3.3.0
        /// <summary>
        /// Return curent Spell Name
        /// </summary>
        public string SpellName
        {
            get
            {
                string s;
                uint offset = _SpellName[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
            }
        }
        /// <summary>
        /// Return curent Spell Rank
        /// </summary>
        public string Rank
        {
            get
            {
                string s;
                uint offset = _Rank[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SpellStrings[_Rank[DBC.Locale]]; 
            }
        }
        /// <summary>
        /// Return curent Spell Description
        /// </summary>
        public string Descriprion
        {
            get
            {
                string s;
                uint offset = _Description[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SpellStrings[_Description[DBC.Locale]]; 
            }
        }
        /// <summary>
        /// Return curent Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get
            {
                string s;
                uint offset = _ToolTip[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SpellStrings[_ToolTip[DBC.Locale]]; 
            }
        }

        public string GetName(byte loc)
        {
            string s;
            uint offset = _SpellName[loc];
            DBC._SpellStrings.TryGetValue(offset, out s);
            return s;
            //return DBC._SpellStrings[_SpellName[loc]]; 
        }
    };

    struct SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int CategoryId;                                     // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Name;                                      // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Description;                               // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36
        public uint SpellIcon;                                     // 37       m_spellIconID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _AlternateVerb;                             // 38-53    m_alternateVerb_lang
        public uint AlternateVerbFlags;                            // 54
        public uint CanLink;                                       // 55       m_canLink (prof. with recipes

        public string Name
        {
            get
            {
                string s;
                uint offset = _Name[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SkillLineStrings[_Name[DBC.Locale]]; 
            }
        }

        public string Description
        {
            get
            {
                string s;
                uint offset = _Description[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SkillLineStrings[_Description[DBC.Locale]]; 
            }
        }

        public string AlternateVerb
        {
            get
            {
                string s;
                uint offset = _AlternateVerb[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SkillLineStrings[_AlternateVerb[DBC.Locale]]; 
            }
        }
    };

    struct SkillLineAbilityEntry
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
        public uint[] characterPoints;                              // 12-13    m_characterPoints[2]
    };

    struct SpellRadiusEntry
    {
        public uint ID;
        public float Radius;
        public int Zero;
        public float Radius2;
    };

    struct SpellRangeEntry
    {
        public uint  ID;
        public float MinRange;
        public float MinRangeFriendly;
        public float MaxRange;
        public float MaxRangeFriendly;
        public uint  Field5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Desc1;
        public uint Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private uint[] _Desc2;
        public uint Desc2Flags;

        public string Description1
        {
            get
            {
                string s;
                uint offset = _Desc1[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SpellRangeStrings[_Desc1[DBC.Locale]]; 
            }
        }

        public string Description2
        {
            get
            {
                string s;
                uint offset = _Desc1[DBC.Locale];
                DBC._SpellStrings.TryGetValue(offset, out s);
                return s;
                //return DBC._SpellRangeStrings[_Desc2[DBC.Locale]]; 
            }
        }
    };

    struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Duration;
    };
}