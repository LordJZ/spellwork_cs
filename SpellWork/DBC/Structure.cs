using System;
using System.Runtime.InteropServices;
using System.Text;
using DBFilesClient.NET;

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

    [StructLayout(LayoutKind.Sequential)]
    public class SpellEntry
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
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 2)]
        public uint[] Totem;                                      // 50-51    m_totem
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 8)]
        public int[] Reagent;                                     // 52-59    m_reagent
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 8)]
        public uint[] ReagentCount;                               // 60-67    m_reagentCount
        public int EquippedItemClass;                             // 68       m_equippedItemClass (value)
        public int EquippedItemSubClassMask;                      // 69       m_equippedItemSubclass (mask)
        public int EquippedItemInventoryTypeMask;                 // 70       m_equippedItemInvTypes (mask)
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] Effect;                     				  // 71-73    m_effect
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectDieSides;                              // 74-76    m_effectDieSides
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectRealPointsPerLevel;                  // 77-79    m_effectRealPointsPerLevel
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectBasePoints;                            // 80-82    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectMechanic;                             // 83-85    m_effectMechanic
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectImplicitTargetA;                      // 86-88    m_implicitTargetA
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectImplicitTargetB;                      // 89-91    m_implicitTargetB
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectRadiusIndex;                          // 92-94    m_effectRadiusIndex - spellradius.dbc
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectApplyAuraName;                        // 95-97    m_effectAura
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectAmplitude;                            // 98-100   m_effectAuraPeriod
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectMultipleValue;                       // 101-103  m_effectAmplitude
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectChainTarget;                          // 104-106  m_effectChainTargets
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectItemType;                             // 107-109  m_effectItemType
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectMiscValue;                             // 110-112  m_effectMiscValue
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public int[] EffectMiscValueB;                            // 113-115  m_effectMiscValueB
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectTriggerSpell;                         // 116-118  m_effectTriggerSpell
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public float[] EffectPointsPerComboPoint;                 // 119-121  m_effectPointsPerCombo
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectSpellClassMaskA;                      // 122-124  m_effectSpellClassMaskA, effect 0
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectSpellClassMaskB;                      // 125-127  m_effectSpellClassMaskB, effect 1
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_EFFECT_INDEX)]
        public uint[] EffectSpellClassMaskC;                      // 128-130  m_effectSpellClassMaskC, effect 2
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 2)]
        public uint[] SpellVisual;                                // 131-132  m_spellVisualID
        public uint SpellIconID;                                  // 133      m_spellIconID
        public uint ActiveIconID;                                 // 134      m_activeIconID
        public uint SpellPriority;                                // 135      m_spellPriority not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_DBC_LOCALE)]
        public string[] _SpellName;                              // 136-151  m_name_lang
        public uint SpellNameFlag;                                // 152      not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_DBC_LOCALE)]
        public string[] _Rank;                                   // 153-168  m_nameSubtext_lang
        public uint RankFlags;                                    // 169      not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_DBC_LOCALE)]
        public string[] _Description;                            // 170-185  m_description_lang not used
        public uint DescriptionFlags;                             // 186      not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_DBC_LOCALE)]
        public string[] _ToolTip;                                // 187-202  m_auraDescription_lang not used
        public uint ToolTipFlags;                                 // 203      not used
        public uint ManaCostPercentage;                           // 204      m_manaCostPct
        public uint StartRecoveryCategory;                        // 205      m_startRecoveryCategory
        public uint StartRecoveryTime;                            // 206      m_startRecoveryTime
        public uint MaxTargetLevel;                               // 207      m_maxTargetLevel
        public uint SpellFamilyName;                              // 208      m_spellClassSet
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[] SpellFamilyFlags;                           // 209-211  m_spellClassMask NOTE: size is 12 bytes!!!
        public uint MaxAffectedTargets;                           // 212      m_maxTargets
        public uint DmgClass;                                     // 213      m_defenseType
        public uint PreventionType;                               // 214      m_preventionType
        public uint StanceBarOrder;                               // 215      m_stanceBarOrder not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public float[] DmgMultiplier;              				  // 216-218  m_effectChainAmplitude
        public uint MinFactionId;                                 // 219      m_minFactionID not used
        public uint MinReputation;                                // 220      m_minReputation not used
        public uint RequiredAuraVision;                           // 221      m_requiredAuraVision not used
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 2)]
        public uint[] TotemCategory;                              // 222-223  m_requiredTotemCategoryID
        public int  AreaGroupId;                                  // 224      m_requiredAreaGroupId
        public uint SchoolMask;                                   // 225      m_schoolMask
        public uint RuneCostID;                                   // 226      m_runeCostID
        public uint SpellMissileID;                               // 227      m_spellMissileID not used
        public uint PowerDisplayId;                               // 228      PowerDisplay.dbc, new in 3.1
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public float[] EffectCoeffs;                              // 229-231  3.2.0
        public uint SpellDescriptionVariableID;                   // 232      3.2.0
        public uint SpellDifficultyId;                            // 233      3.3.0                           // 239      3.3.0

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get { return _SpellName[(uint)DBC.Locale] ?? string.Empty; }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get { return _Rank[(uint)DBC.Locale] ?? string.Empty; }
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
            get { return _Description[(uint)DBC.Locale] ?? string.Empty; }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return _ToolTip[(uint)DBC.Locale] ?? string.Empty; }
        }

        public string GetName(byte loc)
        {
            return _SpellName[loc] ?? string.Empty;
        }

        public string ProcInfo
        {
            get
            {
                int i = 0;
                StringBuilder sb = new StringBuilder();
                uint proc = ProcFlags;
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
            uint rIndex = EffectRadiusIndex[index];
            if (rIndex != 0)
            {
                if (DBC.SpellRadius.ContainsKey(rIndex))
                    return String.Format("Radius (Id {0}) {1:F}", rIndex, DBC.SpellRadius[rIndex].Radius);
                else
                    return String.Format("Radius (Id {0}) Not found", rIndex);
            }
            return String.Empty;
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
    };

    public class SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int  CategoryId;                                    // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 16)]
        public string[] _Name;                                       // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 16)]
        public string[] _Description;                                // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36
        public uint SpellIcon;                                     // 37       m_spellIconID
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 16)]
        public string[] _AlternateVerb;                              // 38-53    m_alternateVerb_lang
        public uint AlternateVerbFlags;                            // 54
        public uint CanLink;                                       // 55       m_canLink (prof. with recipes

        public string Name
        {
            get { return _Name[(uint)DBC.Locale] ?? string.Empty; }
        }

        public string Description
        {
            get { return _Description[(uint)DBC.Locale] ?? string.Empty; }
        }

        public string AlternateVerb
        {
            get { return _AlternateVerb[(uint)DBC.Locale] ?? string.Empty; }
        }
    };

    public class SkillLineAbilityEntry
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
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 2)]
        public uint[] CharacterPoints;                              // 12-13    m_characterPoints[2]
    };

    public class SpellRadiusEntry
    {
        public uint  ID;
        public float Radius;
        public int   Zero;
        public float Radius2;
    };

    public class SpellRangeEntry
    {
        public uint  ID;
        public float MinRange;
        public float MinRangeFriendly;
        public float MaxRange;
        public float MaxRangeFriendly;
        public uint  Field5;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 16)]
        public string[] _Desc1;
        public uint  Desc1Flags;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 16)]
        public string[] _Desc2;
        public uint  Desc2Flags;

        public string Description1
        {
            get { return _Desc1[(uint)DBC.Locale] ?? string.Empty; }
        }

        public string Description2
        {
            get { return _Desc2[(uint)DBC.Locale] ?? string.Empty; }
        }
    };

    public class SpellDurationEntry
    {
        public uint ID;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public int[] Duration;

        public override string ToString()
        {
            return String.Format("Duration: ID ({0})  {1}, {2}, {3}", ID, Duration[0], Duration[1], Duration[2]);
        }
    };

    public class SpellCastTimesEntry
    {
        public uint  ID;
        public int   CastTime;   
        public float CastTimePerLevel;
        public int   MinCastTime;
    };

    public class SpellDifficultyEntry
    {
        public uint Id;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 4)]
        public int[] Spells;
    };

    public class ScreenEffectEntry
    {
        public uint Id;
        public string _Name;
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
            get { return _Name; }
        }
    };

    public class OverrideSpellDataEntry
    {
        public uint Id;
        // Value 10 also used in SpellInfo.AuraModTypeName
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 10)]
        public uint[] Spells;
        public uint unk;
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

    public class AreaGroupEntry
    {
        public uint AreaGroupId;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 6)]
        public uint[] AreaId;
        public uint NextGroup;
    };

    public class AreaTableEntry
    {
        public uint Id;
        public uint MapId;
        public uint ZoneId;
        public uint ExploreFlag;
        public uint Flags;
        public uint SoundPreferences;
        public uint SoundPreferencesUnderwater;
        public uint SoundAmbience;
        public uint ZoneMusic;
        public uint ZoneIntroMusicTable;
        public int Level;
        [StoragePresence(StoragePresenceOption.Include, ArraySize = DBC.MAX_DBC_LOCALE)]
        public string[] NamePtr;
        public uint StringFlags;
        public uint FactionFlags;
        public uint LiquidType1;
        public uint LiquidType2;
        public uint LiquidType3;
        public uint LiquidType4;
        public float MinElevation;
        public float AmbientMultiplier;
        public uint Light;

        public string Name
        {
            get { return NamePtr[(uint)DBC.Locale] ?? string.Empty; }
        }
    };

    public class SpellRuneCostEntry
    {
        public uint  ID;                                             // 0        m_ID
        [StoragePresence(StoragePresenceOption.Include, ArraySize = 3)]
        public uint[]  RuneCost  ;                                   // 1-3      0=blood, 1=unholy, 2=frost ,3=death
        public uint  runePowerGain;                                  // 4        m_runicPower
    };
}
