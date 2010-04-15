using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SpellWork
{
    #region SpellEntry

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
    {
        public uint     Id;                                           // 0        m_ID
        public uint     Category;                                     // 1        m_category
        public uint     Dispel;                                       // 2        m_dispelType
        public uint     Mechanic;                                     // 3        m_mechanic
        public uint     Attributes;                                   // 4        m_attribute
        public uint     AttributesEx;                                 // 5        m_attributesEx
        public uint     AttributesEx2;                                // 6        m_attributesExB
        public uint     AttributesEx3;                                // 7        m_attributesExC
        public uint     AttributesEx4;                                // 8        m_attributesExD
        public uint     AttributesEx5;                                // 9        m_attributesExE
        public uint     AttributesEx6;                                // 10       m_attributesExF
        public uint     Unk_320_1;                                    // 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
        public uint     Stances;                                      // 12       m_shapeshiftMask
        public uint     Unk_320_2;                                    // 13       3.2.0
        public uint     StancesNot;                                   // 14       m_shapeshiftExclude
        public uint     Unk_320_3;                                    // 15       3.2.0
        public uint     Targets;                                      // 16       m_targets
        public uint     TargetCreatureType;                           // 17       m_targetCreatureType
        public uint     RequiresSpellFocus;                           // 18       m_requiresSpellFocus
        public uint     FacingCasterFlags;                            // 19       m_facingCasterFlags
        public uint     CasterAuraState;                              // 20       m_casterAuraState
        public uint     TargetAuraState;                              // 21       m_targetAuraState
        public uint     CasterAuraStateNot;                           // 22       m_excludeCasterAuraState
        public uint     TargetAuraStateNot;                           // 23       m_excludeTargetAuraState
        public uint     CasterAuraSpell;                              // 24       m_casterAuraSpell
        public uint     TargetAuraSpell;                              // 25       m_targetAuraSpell
        public uint     ExcludeCasterAuraSpell;                       // 26       m_excludeCasterAuraSpell
        public uint     ExcludeTargetAuraSpell;                       // 27       m_excludeTargetAuraSpell
        public uint     CastingTimeIndex;                             // 28       m_castingTimeIndex
        public uint     RecoveryTime;                                 // 29       m_recoveryTime
        public uint     CategoryRecoveryTime;                         // 30       m_categoryRecoveryTime
        public uint     interruptFlags;                               // 31       m_interruptFlags
        public uint     AuraInterruptFlags;                           // 32       m_auraInterruptFlags
        public uint     ChannelInterruptFlags;                        // 33       m_channelInterruptFlags
        public uint     ProcFlags;                                    // 34       m_procTypeMask
        public uint     ProcChance;                                   // 35       m_procChance
        public uint     ProcCharges;                                  // 36       m_procCharges
        public uint     MaxLevel;                                     // 37       m_maxLevel
        public uint     BaseLevel;                                    // 38       m_baseLevel
        public uint     SpellLevel;                                   // 39       m_spellLevel
        public uint     DurationIndex;                                // 40       m_durationIndex
        public uint     PowerType;                                    // 41       m_powerType
        public uint     ManaCost;                                     // 42       m_manaCost
        public uint     ManaCostPerlevel;                             // 43       m_manaCostPerLevel
        public uint     ManaPerSecond;                                // 44       m_manaPerSecond
        public uint     ManaPerSecondPerLevel;                        // 45       m_manaPerSecondPerLeve
        public uint     RangeIndex;                                   // 46       m_rangeIndex
        public float    Speed;                                        // 47       m_speed
        public uint     ModalNextSpell;                               // 48       m_modalNextSpell not used
        public uint     StackAmount;                                  // 49       m_cumulativeAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]   Totem;                                        // 50-51    m_totem
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] Reagent;                                      // 52-59    m_reagent
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] ReagentCount;                                 // 60-67    m_reagentCount
        public int      EquippedItemClass;                            // 68       m_equippedItemClass (value)
        public int      EquippedItemSubClassMask;                     // 69       m_equippedItemSubclass (mask)
        public int      EquippedItemInventoryTypeMask;                // 70       m_equippedItemInvTypes (mask)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect;                         // 71-73    m_effect
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectDieSides;                  // 74-76    m_effectDieSides
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectBaseDice;                 // 77-79    m_effectBaseDice
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectDicePerLevel;            // 80-82    m_effectDicePerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectRealPointsPerLevel;      // 83-85    m_effectRealPointsPerLevel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectBasePoints;                // 86-88    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectMechanic;                 // 89-91    m_effectMechanic
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectImplicitTargetA;          // 92-94    m_implicitTargetA
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectImplicitTargetB;          // 95-97    m_implicitTargetB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectRadiusIndex;              // 98-100   m_effectRadiusIndex - spellradius.dbc
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectApplyAuraName;            // 101-103  m_effectAura
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectAmplitude;                // 104-106  m_effectAuraPeriod
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectMultipleValue;           // 107-109  m_effectAmplitude
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectChainTarget;              // 110-112  m_effectChainTargets
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectItemType;                 // 113-115  m_effectItemType
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectMiscValue;                 // 116-118  m_effectMiscValue
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] EffectMiscValueB;                // 119-121  m_effectMiscValueB
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectTriggerSpell;             // 122-124  m_effectTriggerSpell
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] EffectPointsPerComboPoint;     // 125-127  m_effectPointsPerCombo
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskA;          // 128-130  m_effectSpellClassMaskA, effect 0
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskB;          // 131-133  m_effectSpellClassMaskB, effect 1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] EffectSpellClassMaskC;          // 134-136  m_effectSpellClassMaskC, effect 2
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellVisual;                      // 137-138  m_spellVisualID
        public uint     SpellIconID;                                  // 139      m_spellIconID
        public uint     ActiveIconID;                                 // 140      m_activeIconID
        public uint     SpellPriority;                                // 141      m_spellPriority not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] SpellName;                                    // 142-157  m_name_lang
        public uint     SpellNameFlag;                                // 158 not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Rank;                                         // 159-174  m_nameSubtext_lang
        public uint     RankFlags;                                    // 175 not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Description;                                  // 176-191  m_description_lang not used
        public uint     DescriptionFlags;                             // 192 not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] ToolTip;                                      // 193-208  m_auraDescription_lang not used
        public uint     ToolTipFlags;                                 // 209 not used
        public uint     ManaCostPercentage;                           // 210      m_manaCostPct
        public uint     StartRecoveryCategory;                        // 211      m_startRecoveryCategory
        public uint     StartRecoveryTime;                            // 212      m_startRecoveryTime
        public uint     MaxTargetLevel;                               // 213      m_maxTargetLevel
        public uint     SpellFamilyName;                              // 214      m_spellClassSet
        public uint     SpellFamilyFlags;                             // 215-216  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint     SpellFamilyFlags1;                             // 215-216  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint     SpellFamilyFlags2;                            // 217      addition to m_spellClassMask
        public uint     MaxAffectedTargets;                           // 218      m_maxTargets
        public uint     DmgClass;                                     // 219      m_defenseType
        public uint     PreventionType;                               // 220      m_preventionType
        public uint     StanceBarOrder;                               // 221      m_stanceBarOrder not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] DmgMultiplier;                                // 222-224  m_effectChainAmplitude
        public uint     MinFactionId;                                 // 225      m_minFactionID not used
        public uint     MinReputation;                                // 226      m_minReputation not used
        public uint     RequiredAuraVision;                           // 227      m_requiredAuraVision not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TotemCategory;                                // 228-229  m_requiredTotemCategoryID
        public int      AreaGroupId;                                  // 230      m_requiredAreaGroupId
        public uint     SchoolMask;                                   // 231      m_schoolMask
        public uint     RuneCostID;                                   // 232      m_runeCostID
        public uint     SpellMissileID;                               // 233      m_spellMissileID not used
        public uint     PowerDisplayId;                               // 234 PowerDisplay.dbc, new in 3.1
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Unk_320_4;                                    // 235-237  3.2.0
        public uint     SpellDescriptionVariableID;                   // 238      3.2.0
        public uint     SpellDifficultyId;                            // 239      3.3.0

        public string getName() { return DBC._SpellStrings[SpellName[DBC.Locale]]; }
        public string getRank() { return DBC._SpellStrings[Rank[DBC.Locale]]; }
        public string getDesc() { return DBC._SpellStrings[Description[DBC.Locale]]; }
        public string getTooltip() { return DBC._SpellStrings[ToolTip[DBC.Locale]]; }

        public string getName(byte loc) { return DBC._SpellStrings[SpellName[loc]]; }
    };
    #endregion

    struct SkillLineEntry
    {
        public uint Id;                                            // 0        m_ID
        public int  CategoryId;                                    // 1        m_categoryID
        public uint skillCostID;                                   // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Name;                                        // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19 string flags
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Description;                                 // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36 string flags
        public uint SpellIcon;                                     // 37       m_spellIconID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] alternateVerb;                               // 38-53    m_alternateVerb_lang
        public uint alternateVerbFlags;                            // 54 string flags
        public uint CanLink;                                       // 55       m_canLink (prof. with recipes


    };

    struct SkillLineAbilityEntry
    {
        public uint Id;                                             // 0        m_ID
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
        public uint[] characterPoints;                         // 12-13    m_characterPoints[2]
    };

    struct SpellRadiusEntry
    {
        public uint ID;
        public float Radius;
        private int Zero;
        public float Radius2;
    };

    struct SpellRangeEntry
    {
        public uint ID;
        public float MinRange;
        public float MinRangeFriendly;
        public float MaxRange;
        public float MaxRangeFriendly;
        public uint Field5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Desc1;
        public uint Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public uint[] Desc2;
        public uint Desc2Flags;

        public string getDesc1() { return DBC._SpellRangeStrings[Desc1[DBC.Locale]]; }
        public string getDesc2() { return DBC._SpellRangeStrings[Desc2[DBC.Locale]]; }
    };

    struct SpellDurationEntry
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] Duration;
    };
}
