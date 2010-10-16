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

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
    {
        public uint    ID;                                           // 0 normally counted from 0 field (but some tools start counting from 1, check this before tool use for data view!)
        public uint    SchoolMask;                                       // 1 not schoolMask from 2.x - just school type so everything linked with SpellEntry::SchoolMask must be rewrited
        public uint    Category;                                     // 2
        public uint castUI;                                       // 3 not used
        public uint    Dispel;                                       // 4
        public uint    Mechanic;                                     // 5
        public uint    Attributes;                                   // 6
        public uint    AttributesEx;                                 // 7
        public uint    AttributesEx2;                                // 8
        public uint    AttributesEx3;                                // 9
        public uint    AttributesEx4;                                // 10
        public uint    Stances;                                      // 11
        public uint    StancesNot;                                   // 12
        public uint    Targets;                                      // 13
        public uint    TargetCreatureType;                           // 14
        public uint    RequiresSpellFocus;                           // 15
        public uint    CasterAuraState;                              // 16
        public uint    TargetAuraState;                              // 17
        public uint    CastingTimeIndex;                             // 18
        public uint    RecoveryTime;                                 // 19
        public uint    CategoryRecoveryTime;                         // 20
        public uint    InterruptFlags;                               // 21
        public uint    AuraInterruptFlags;                           // 22
        public uint    ChannelInterruptFlags;                        // 23
        public uint    ProcFlags;                                    // 24
        public uint    ProcChance;                                   // 25
        public uint    ProcCharges;                                  // 26
        public uint    MaxLevel;                                     // 27
        public uint    BaseLevel;                                    // 28
        public uint    SpellLevel;                                   // 29
        public uint    DurationIndex;                                // 30
        public uint    PowerType;                                    // 31
        public uint    ManaCost;                                     // 32
        public uint    ManaCostPerlevel;                             // 33
        public uint    ManaPerSecond;                                // 34
        public uint    ManaPerSecondPerLevel;                        // 35
        public uint    RangeIndex;                                   // 36
        public float     Speed;                                        // 37
        public uint    ModalNextSpell;                               // 38 not used
        public uint    StackAmount;                                  // 39
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]    Totem;                      // 40-41
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[]     Reagent;                  // 42-49
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[]    ReagentCount;             // 50-57
        public int     EquippedItemClass;                            // 58 (value)
        public uint     EquippedItemSubClassMask;                     // 59 (mask)
        public uint     EquippedItemInventoryTypeMask;                // 60 (mask)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    Effect;                     // 61-63
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[]     EffectDieSides;             // 64-66
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectBaseDice;             // 67-69
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[]     EffectDicePerLevel;         // 70-72
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[]     EffectRealPointsPerLevel;   // 73-75
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[]     EffectBasePoints;           // 76-78 (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectMechanic;             // 79-81
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectImplicitTargetA;      // 82-84
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectImplicitTargetB;      // 85-87
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectRadiusIndex;          // 88-90 - spellradius.dbc
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectApplyAuraName;        // 91-93
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectAmplitude;            // 94-96
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[]     EffectMultipleValue;        // 97-99
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectChainTarget;          // 100-102
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectItemType;             // 103-105
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public int[]     EffectMiscValue;            // 106-108
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public uint[]    EffectTriggerSpell;         // 109-111
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[]     EffectPointsPerComboPoint;  // 112-114
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[]    SpellVisual;                                  // 115
        public uint    SpellIconID;                                  // 117
        public uint    ActiveIconID;                                 // 118
        public uint    SpellPriority;                              // 119
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[]     _SpellName;                                 // 120-127
        private uint    SpellNameFlag;                              // 128
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[]     _Rank;                                      // 129-136
        private uint    RankFlags;                                  // 137
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[]     _Description;                             // 138-145 not used
        private uint    DescriptionFlags;                           // 146     not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        private uint[]     _ToolTip;                                 // 147-154 not used
        private uint    ToolTipFlags;                               // 155     not used
        public uint    ManaCostPercentage;                           // 156
        public uint    StartRecoveryCategory;                        // 157
        public uint    StartRecoveryTime;                            // 158
        public uint    MaxTargetLevel;                               // 159
        public uint    SpellFamilyName;                              // 160
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] SpellFamilyFlags;                             // 161+162
        public uint    MaxAffectedTargets;                           // 163
        public uint    DmgClass;                                     // 164 defenseType
        public uint    PreventionType;                               // 165
        public uint    StanceBarOrder;                             // 166 not used
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_EFFECT_INDEX)]
        public float[]     DmgMultiplier;              // 167-169
        public uint    MinFactionId;                               // 170 not used, and 0 in 2.4.2
        public uint    MinReputation;                              // 171 not used, and 0 in 2.4.2
        public uint    RequiredAuraVision;                         // 172 not used

        /// <summary>
        /// Return current Spell Name
        /// </summary>
        public string SpellName
        {
            get { return DBC.SpellStrings.GetValue(_SpellName[(uint)DBC.Locale]); }
        }

        /// <summary>
        /// Return current Spell Rank
        /// </summary>
        public string Rank
        {
            get { return _Rank[(uint)DBC.Locale] != 0 ? DBC.SpellStrings[_Rank[(uint)DBC.Locale]] : ""; }
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
            get { return DBC.SpellStrings.GetValue(_Description[(uint)DBC.Locale]); }
        }

        /// <summary>
        /// Return current Spell ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return DBC.SpellStrings.GetValue(_ToolTip[(uint)DBC.Locale]); }
        }

        public string GetName(byte loc)
        {
            return DBC.SpellStrings.GetValue(_SpellName[loc]);
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
                sb.AppendFormatLine("    MinRange = {0}", range.MinRange);
                sb.AppendFormatLine("    MaxRange = {0}", range.MaxRange);

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

        public SpellSchoolMask School
        {
            get
            {
                return (SpellSchoolMask)SchoolMask;
            }
        }
    };

    public struct SkillLineEntry
    {
        public uint ID;                                            // 0        m_ID
        public int  CategoryId;                                    // 1        m_categoryID
        public uint SkillCostID;                                   // 2        m_skillCostsID
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        public uint[] _Name;                                       // 3-18     m_displayName_lang
        public uint NameFlags;                                     // 19
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        public uint[] _Description;                                // 20-35    m_description_lang
        public uint DescriptionFlags;                              // 36
        public uint SpellIcon;                                     // 37       m_spellIconID

        public string Name
        {
            get { return DBC.SkillLineStrings.GetValue(_Name[(uint)DBC.Locale]); }
        }

        public string Description
        {
            get { return DBC.SkillLineStrings.GetValue(_Description[(uint)DBC.Locale]); }
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
        /// <summary>
        /// TODO: use?
        /// </summary>
        public uint reqtrainpoints;                               // 14
    };

    public struct SpellRadiusEntry
    {
        public uint  ID;
        public float Radius;
        public int Zero;
        public float Radius2;
    };

    public struct SpellRangeEntry
    {
        public uint  ID;
        public float MinRange;
        public float MaxRange;
        public uint  Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        public uint[] _Desc1;
        public uint  Desc1Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DBC.MAX_DBC_LOCALE)]
        public uint[] _Desc2;
        public uint  Desc2Flags;

        public string Description1
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc1[(uint)DBC.Locale]); }
        }

        public string Description2
        {
            get { return DBC.SpellRangeStrings.GetValue(_Desc2[(uint)DBC.Locale]); }
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
