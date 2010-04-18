using System;

namespace SpellWork
{
    public enum LocalesDBC
    {
        enUS,
        koKR,
        frFR,
        deDE,
        zhCN,
        zhTW,
        esES,
        esMX,
        ruRU
    };

    /// <summary>
    ///
    /// </summary>
    public enum SpellFamilyNames
    {
        SPELLFAMILY_GENERIC     = 0,
        SPELLFAMILY_UNK1        = 1, // events, holidays
        // unused               = 2,
        SPELLFAMILY_MAGE        = 3,
        SPELLFAMILY_WARRIOR     = 4,
        SPELLFAMILY_WARLOCK     = 5,
        SPELLFAMILY_PRIEST      = 6,
        SPELLFAMILY_DRUID       = 7,
        SPELLFAMILY_ROGUE       = 8,
        SPELLFAMILY_HUNTER      = 9,
        SPELLFAMILY_PALADIN     = 10,
        SPELLFAMILY_SHAMAN      = 11,
        SPELLFAMILY_UNK2        = 12, // 2 spells (silence resistance)
        SPELLFAMILY_POTION      = 13,
        // unused               = 14,
        SPELLFAMILY_DEATHKNIGHT = 15,
        // unused               = 16,
        SPELLFAMILY_PET         = 17
    };

    /// <summary>
    ///
    /// </summary>
    public enum SpellSpecific
    {
        SPELL_NORMAL            = 0,
        SPELL_SEAL              = 1,
        SPELL_BLESSING          = 2,
        SPELL_AURA              = 3,
        SPELL_STING             = 4,
        SPELL_CURSE             = 5,
        SPELL_ASPECT            = 6,
        SPELL_TRACKER           = 7,
        SPELL_WARLOCK_ARMOR     = 8,
        SPELL_MAGE_ARMOR        = 9,
        SPELL_ELEMENTAL_SHIELD  = 10,
        SPELL_MAGE_POLYMORPH    = 11,
        SPELL_POSITIVE_SHOUT    = 12,
        SPELL_JUDGEMENT         = 13,
        SPELL_BATTLE_ELIXIR     = 14,
        SPELL_GUARDIAN_ELIXIR   = 15,
        SPELL_FLASK_ELIXIR      = 16,
        SPELL_PRESENCE          = 17,
        SPELL_HAND              = 18,
        SPELL_WELL_FED          = 19,
        SPELL_FOOD              = 20,
        SPELL_DRINK             = 21,
        SPELL_FOOD_AND_DRINK    = 22,
    };

    /// <summary>
    ///
    /// </summary>
    public enum SpellEffects
    {
        NO_SPELL_EFFECT                         = 0,
        SPELL_EFFECT_INSTAKILL                  = 1,
        SPELL_EFFECT_SCHOOL_DAMAGE              = 2,
        SPELL_EFFECT_DUMMY                      = 3,
        SPELL_EFFECT_PORTAL_TELEPORT            = 4,
        SPELL_EFFECT_TELEPORT_UNITS             = 5,
        SPELL_EFFECT_APPLY_AURA                 = 6,
        SPELL_EFFECT_ENVIRONMENTAL_DAMAGE       = 7,
        SPELL_EFFECT_POWER_DRAIN                = 8,
        SPELL_EFFECT_HEALTH_LEECH               = 9,
        SPELL_EFFECT_HEAL                       = 10,
        SPELL_EFFECT_BIND                       = 11,
        SPELL_EFFECT_PORTAL                     = 12,
        SPELL_EFFECT_RITUAL_BASE                = 13,
        SPELL_EFFECT_RITUAL_SPECIALIZE          = 14,
        SPELL_EFFECT_RITUAL_ACTIVATE_PORTAL     = 15,
        SPELL_EFFECT_QUEST_COMPLETE             = 16,
        SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL     = 17,
        SPELL_EFFECT_RESURRECT                  = 18,
        SPELL_EFFECT_ADD_EXTRA_ATTACKS          = 19,
        SPELL_EFFECT_DODGE                      = 20,
        SPELL_EFFECT_EVADE                      = 21,
        SPELL_EFFECT_PARRY                      = 22,
        SPELL_EFFECT_BLOCK                      = 23,
        SPELL_EFFECT_CREATE_ITEM                = 24,
        SPELL_EFFECT_WEAPON                     = 25,
        SPELL_EFFECT_DEFENSE                    = 26,
        SPELL_EFFECT_PERSISTENT_AREA_AURA       = 27,
        SPELL_EFFECT_SUMMON                     = 28,
        SPELL_EFFECT_LEAP                       = 29,
        SPELL_EFFECT_ENERGIZE                   = 30,
        SPELL_EFFECT_WEAPON_PERCENT_DAMAGE      = 31,
        SPELL_EFFECT_TRIGGER_MISSILE            = 32,
        SPELL_EFFECT_OPEN_LOCK                  = 33,
        SPELL_EFFECT_SUMMON_CHANGE_ITEM         = 34,
        SPELL_EFFECT_APPLY_AREA_AURA_PARTY      = 35,
        SPELL_EFFECT_LEARN_SPELL                = 36,
        SPELL_EFFECT_SPELL_DEFENSE              = 37,
        SPELL_EFFECT_DISPEL                     = 38,
        SPELL_EFFECT_LANGUAGE                   = 39,
        SPELL_EFFECT_DUAL_WIELD                 = 40,
        SPELL_EFFECT_JUMP                       = 41,
        SPELL_EFFECT_JUMP2                      = 42,
        SPELL_EFFECT_TELEPORT_UNITS_FACE_CASTER = 43,
        SPELL_EFFECT_SKILL_STEP                 = 44,
        SPELL_EFFECT_ADD_HONOR                  = 45,
        SPELL_EFFECT_SPAWN                      = 46,
        SPELL_EFFECT_TRADE_SKILL                = 47,
        SPELL_EFFECT_STEALTH                    = 48,
        SPELL_EFFECT_DETECT                     = 49,
        SPELL_EFFECT_TRANS_DOOR                 = 50,
        SPELL_EFFECT_FORCE_CRITICAL_HIT         = 51,
        SPELL_EFFECT_GUARANTEE_HIT              = 52,
        SPELL_EFFECT_ENCHANT_ITEM               = 53,
        SPELL_EFFECT_ENCHANT_ITEM_TEMPORARY     = 54,
        SPELL_EFFECT_TAMECREATURE               = 55,
        SPELL_EFFECT_SUMMON_PET                 = 56,
        SPELL_EFFECT_LEARN_PET_SPELL            = 57,
        SPELL_EFFECT_WEAPON_DAMAGE              = 58,
        SPELL_EFFECT_CREATE_RANDOM_ITEM         = 59,
        SPELL_EFFECT_PROFICIENCY                = 60,
        SPELL_EFFECT_SEND_EVENT                 = 61,
        SPELL_EFFECT_POWER_BURN                 = 62,
        SPELL_EFFECT_THREAT                     = 63,
        SPELL_EFFECT_TRIGGER_SPELL              = 64,
        SPELL_EFFECT_APPLY_AREA_AURA_RAID       = 65,
        SPELL_EFFECT_CREATE_MANA_GEM            = 66,
        SPELL_EFFECT_HEAL_MAX_HEALTH            = 67,
        SPELL_EFFECT_INTERRUPT_CAST             = 68,
        SPELL_EFFECT_DISTRACT                   = 69,
        SPELL_EFFECT_PULL                       = 70,
        SPELL_EFFECT_PICKPOCKET                 = 71,
        SPELL_EFFECT_ADD_FARSIGHT               = 72,
        SPELL_EFFECT_UNTRAIN_TALENTS            = 73,
        SPELL_EFFECT_APPLY_GLYPH                = 74,
        SPELL_EFFECT_HEAL_MECHANICAL            = 75,
        SPELL_EFFECT_SUMMON_OBJECT_WILD         = 76,
        SPELL_EFFECT_SCRIPT_EFFECT              = 77,
        SPELL_EFFECT_ATTACK                     = 78,
        SPELL_EFFECT_SANCTUARY                  = 79,
        SPELL_EFFECT_ADD_COMBO_POINTS           = 80,
        SPELL_EFFECT_CREATE_HOUSE               = 81,
        SPELL_EFFECT_BIND_SIGHT                 = 82,
        SPELL_EFFECT_DUEL                       = 83,
        SPELL_EFFECT_STUCK                      = 84,
        SPELL_EFFECT_SUMMON_PLAYER              = 85,
        SPELL_EFFECT_ACTIVATE_OBJECT            = 86,
        SPELL_EFFECT_WMO_DAMAGE                 = 87,
        SPELL_EFFECT_WMO_REPAIR                 = 88,
        SPELL_EFFECT_WMO_CHANGE                 = 89,
        SPELL_EFFECT_KILL_CREDIT                = 90,
        SPELL_EFFECT_THREAT_ALL                 = 91,
        SPELL_EFFECT_ENCHANT_HELD_ITEM          = 92,
        SPELL_EFFECT_SUMMON_PHANTASM            = 93,
        SPELL_EFFECT_SELF_RESURRECT             = 94,
        SPELL_EFFECT_SKINNING                   = 95,
        SPELL_EFFECT_CHARGE                     = 96,
        SPELL_EFFECT_SUMMON_ALL_TOTEMS          = 97,
        SPELL_EFFECT_KNOCK_BACK                 = 98,
        SPELL_EFFECT_DISENCHANT                 = 99,
        SPELL_EFFECT_INEBRIATE                  = 100,
        SPELL_EFFECT_FEED_PET                   = 101,
        SPELL_EFFECT_DISMISS_PET                = 102,
        SPELL_EFFECT_REPUTATION                 = 103,
        SPELL_EFFECT_SUMMON_OBJECT_SLOT1        = 104,
        SPELL_EFFECT_SUMMON_OBJECT_SLOT2        = 105,
        SPELL_EFFECT_SUMMON_OBJECT_SLOT3        = 106,
        SPELL_EFFECT_SUMMON_OBJECT_SLOT4        = 107,
        SPELL_EFFECT_DISPEL_MECHANIC            = 108,
        SPELL_EFFECT_SUMMON_DEAD_PET            = 109,
        SPELL_EFFECT_DESTROY_ALL_TOTEMS         = 110,
        SPELL_EFFECT_DURABILITY_DAMAGE          = 111,
        SPELL_EFFECT_112                        = 112,
        SPELL_EFFECT_RESURRECT_NEW              = 113,
        SPELL_EFFECT_ATTACK_ME                  = 114,
        SPELL_EFFECT_DURABILITY_DAMAGE_PCT      = 115,
        SPELL_EFFECT_SKIN_PLAYER_CORPSE         = 116,
        SPELL_EFFECT_SPIRIT_HEAL                = 117,
        SPELL_EFFECT_SKILL                      = 118,
        SPELL_EFFECT_APPLY_AREA_AURA_PET        = 119,
        SPELL_EFFECT_TELEPORT_GRAVEYARD         = 120,
        SPELL_EFFECT_NORMALIZED_WEAPON_DMG      = 121,
        SPELL_EFFECT_122                        = 122,
        SPELL_EFFECT_SEND_TAXI                  = 123,
        SPELL_EFFECT_PLAYER_PULL                = 124,
        SPELL_EFFECT_MODIFY_THREAT_PERCENT      = 125,
        SPELL_EFFECT_STEAL_BENEFICIAL_BUFF      = 126,
        SPELL_EFFECT_PROSPECTING                = 127,
        SPELL_EFFECT_APPLY_AREA_AURA_FRIEND     = 128,
        SPELL_EFFECT_APPLY_AREA_AURA_ENEMY      = 129,
        SPELL_EFFECT_REDIRECT_THREAT            = 130,
        SPELL_EFFECT_131                        = 131,
        SPELL_EFFECT_PLAY_MUSIC                 = 132,
        SPELL_EFFECT_UNLEARN_SPECIALIZATION     = 133,
        SPELL_EFFECT_KILL_CREDIT2               = 134,
        SPELL_EFFECT_CALL_PET                   = 135,
        SPELL_EFFECT_HEAL_PCT                   = 136,
        SPELL_EFFECT_ENERGIZE_PCT               = 137,
        SPELL_EFFECT_LEAP_BACK                  = 138,
        SPELL_EFFECT_CLEAR_QUEST                = 139,
        SPELL_EFFECT_FORCE_CAST                 = 140,
        SPELL_EFFECT_141                        = 141,
        SPELL_EFFECT_TRIGGER_SPELL_WITH_VALUE   = 142,
        SPELL_EFFECT_APPLY_AREA_AURA_OWNER      = 143,
        SPELL_EFFECT_144                        = 144,
        SPELL_EFFECT_145                        = 145,
        SPELL_EFFECT_ACTIVATE_RUNE              = 146,
        SPELL_EFFECT_QUEST_FAIL                 = 147,
        SPELL_EFFECT_148                        = 148,
        SPELL_EFFECT_149                        = 149,
        SPELL_EFFECT_150                        = 150,
        SPELL_EFFECT_TRIGGER_SPELL_2            = 151,
        SPELL_EFFECT_152                        = 152,
        SPELL_EFFECT_153                        = 153,
        SPELL_EFFECT_154                        = 154,
        SPELL_EFFECT_TITAN_GRIP                 = 155,
        SPELL_EFFECT_ENCHANT_ITEM_PRISMATIC     = 156,
        SPELL_EFFECT_CREATE_ITEM_2              = 157,
        SPELL_EFFECT_MILLING                    = 158,
        SPELL_EFFECT_ALLOW_RENAME_PET           = 159,
        SPELL_EFFECT_160                        = 160,
        SPELL_EFFECT_TALENT_SPEC_COUNT          = 161,
        SPELL_EFFECT_TALENT_SPEC_SELECT         = 162,
        TOTAL_SPELL_EFFECTS                     = 163
    };

    /// <summary>
    ///
    /// </summary>
    public enum AuraType
    {
        SPELL_AURA_NONE                                     = 0,
        SPELL_AURA_BIND_SIGHT                               = 1,
        SPELL_AURA_MOD_POSSESS                              = 2,
        SPELL_AURA_PERIODIC_DAMAGE                          = 3,
        SPELL_AURA_DUMMY                                    = 4,
        SPELL_AURA_MOD_CONFUSE                              = 5,
        SPELL_AURA_MOD_CHARM                                = 6,
        SPELL_AURA_MOD_FEAR                                 = 7,
        SPELL_AURA_PERIODIC_HEAL                            = 8,
        SPELL_AURA_MOD_ATTACKSPEED                          = 9,
        SPELL_AURA_MOD_THREAT                               = 10,
        SPELL_AURA_MOD_TAUNT                                = 11,
        SPELL_AURA_MOD_STUN                                 = 12,
        SPELL_AURA_MOD_DAMAGE_DONE                          = 13,
        SPELL_AURA_MOD_DAMAGE_TAKEN                         = 14,
        SPELL_AURA_DAMAGE_SHIELD                            = 15,
        SPELL_AURA_MOD_STEALTH                              = 16,
        SPELL_AURA_MOD_STEALTH_DETECT                       = 17,
        SPELL_AURA_MOD_INVISIBILITY                         = 18,
        SPELL_AURA_MOD_INVISIBILITY_DETECTION               = 19,
        SPELL_AURA_OBS_MOD_HEALTH                           = 20,       //20,21 unofficial
        SPELL_AURA_OBS_MOD_MANA                             = 21,
        SPELL_AURA_MOD_RESISTANCE                           = 22,
        SPELL_AURA_PERIODIC_TRIGGER_SPELL                   = 23,
        SPELL_AURA_PERIODIC_ENERGIZE                        = 24,
        SPELL_AURA_MOD_PACIFY                               = 25,
        SPELL_AURA_MOD_ROOT                                 = 26,
        SPELL_AURA_MOD_SILENCE                              = 27,
        SPELL_AURA_REFLECT_SPELLS                           = 28,
        SPELL_AURA_MOD_STAT                                 = 29,
        SPELL_AURA_MOD_SKILL                                = 30,
        SPELL_AURA_MOD_INCREASE_SPEED                       = 31,
        SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED               = 32,
        SPELL_AURA_MOD_DECREASE_SPEED                       = 33,
        SPELL_AURA_MOD_INCREASE_HEALTH                      = 34,
        SPELL_AURA_MOD_INCREASE_ENERGY                      = 35,
        SPELL_AURA_MOD_SHAPESHIFT                           = 36,
        SPELL_AURA_EFFECT_IMMUNITY                          = 37,
        SPELL_AURA_STATE_IMMUNITY                           = 38,
        SPELL_AURA_SCHOOL_IMMUNITY                          = 39,
        SPELL_AURA_DAMAGE_IMMUNITY                          = 40,
        SPELL_AURA_DISPEL_IMMUNITY                          = 41,
        SPELL_AURA_PROC_TRIGGER_SPELL                       = 42,
        SPELL_AURA_PROC_TRIGGER_DAMAGE                      = 43,
        SPELL_AURA_TRACK_CREATURES                          = 44,
        SPELL_AURA_TRACK_RESOURCES                          = 45,
        SPELL_AURA_46                                       = 46,       // Ignore all Gear test spells
        SPELL_AURA_MOD_PARRY_PERCENT                        = 47,
        SPELL_AURA_48                                       = 48,       // One periodic spell
        SPELL_AURA_MOD_DODGE_PERCENT                        = 49,
        SPELL_AURA_MOD_CRITICAL_HEALING_AMOUNT              = 50,
        SPELL_AURA_MOD_BLOCK_PERCENT                        = 51,
        SPELL_AURA_MOD_CRIT_PERCENT                         = 52,
        SPELL_AURA_PERIODIC_LEECH                           = 53,
        SPELL_AURA_MOD_HIT_CHANCE                           = 54,
        SPELL_AURA_MOD_SPELL_HIT_CHANCE                     = 55,
        SPELL_AURA_TRANSFORM                                = 56,
        SPELL_AURA_MOD_SPELL_CRIT_CHANCE                    = 57,
        SPELL_AURA_MOD_INCREASE_SWIM_SPEED                  = 58,
        SPELL_AURA_MOD_DAMAGE_DONE_CREATURE                 = 59,
        SPELL_AURA_MOD_PACIFY_SILENCE                       = 60,
        SPELL_AURA_MOD_SCALE                                = 61,
        SPELL_AURA_PERIODIC_HEALTH_FUNNEL                   = 62,
        SPELL_AURA_63                                       = 63,       // old SPELL_AURA_PERIODIC_MANA_FUNNEL
        SPELL_AURA_PERIODIC_MANA_LEECH                      = 64,
        SPELL_AURA_MOD_CASTING_SPEED_NOT_STACK              = 65,
        SPELL_AURA_FEIGN_DEATH                              = 66,
        SPELL_AURA_MOD_DISARM                               = 67,
        SPELL_AURA_MOD_STALKED                              = 68,
        SPELL_AURA_SCHOOL_ABSORB                            = 69,
        SPELL_AURA_EXTRA_ATTACKS                            = 70,
        SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL             = 71,
        SPELL_AURA_MOD_POWER_COST_SCHOOL_PCT                = 72,
        SPELL_AURA_MOD_POWER_COST_SCHOOL                    = 73,
        SPELL_AURA_REFLECT_SPELLS_SCHOOL                    = 74,
        SPELL_AURA_MOD_LANGUAGE                             = 75,
        SPELL_AURA_FAR_SIGHT                                = 76,
        SPELL_AURA_MECHANIC_IMMUNITY                        = 77,
        SPELL_AURA_MOUNTED                                  = 78,
        SPELL_AURA_MOD_DAMAGE_PERCENT_DONE                  = 79,
        SPELL_AURA_MOD_PERCENT_STAT                         = 80,
        SPELL_AURA_SPLIT_DAMAGE_PCT                         = 81,
        SPELL_AURA_WATER_BREATHING                          = 82,
        SPELL_AURA_MOD_BASE_RESISTANCE                      = 83,
        SPELL_AURA_MOD_REGEN                                = 84,
        SPELL_AURA_MOD_POWER_REGEN                          = 85,
        SPELL_AURA_CHANNEL_DEATH_ITEM                       = 86,
        SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN                 = 87,
        SPELL_AURA_MOD_HEALTH_REGEN_PERCENT                 = 88,
        SPELL_AURA_PERIODIC_DAMAGE_PERCENT                  = 89,
        SPELL_AURA_90                                       = 90,       // old SPELL_AURA_MOD_RESIST_CHANCE
        SPELL_AURA_MOD_DETECT_RANGE                         = 91,
        SPELL_AURA_PREVENTS_FLEEING                         = 92,
        SPELL_AURA_MOD_UNATTACKABLE                         = 93,
        SPELL_AURA_INTERRUPT_REGEN                          = 94,
        SPELL_AURA_GHOST                                    = 95,
        SPELL_AURA_SPELL_MAGNET                             = 96,
        SPELL_AURA_MANA_SHIELD                              = 97,
        SPELL_AURA_MOD_SKILL_TALENT                         = 98,
        SPELL_AURA_MOD_ATTACK_POWER                         = 99,
        SPELL_AURA_AURAS_VISIBLE                            = 100,
        SPELL_AURA_MOD_RESISTANCE_PCT                       = 101,
        SPELL_AURA_MOD_MELEE_ATTACK_POWER_VERSUS            = 102,
        SPELL_AURA_MOD_TOTAL_THREAT                         = 103,
        SPELL_AURA_WATER_WALK                               = 104,
        SPELL_AURA_FEATHER_FALL                             = 105,
        SPELL_AURA_HOVER                                    = 106,
        SPELL_AURA_ADD_FLAT_MODIFIER                        = 107,
        SPELL_AURA_ADD_PCT_MODIFIER                         = 108,
        SPELL_AURA_ADD_TARGET_TRIGGER                       = 109,
        SPELL_AURA_MOD_POWER_REGEN_PERCENT                  = 110,
        SPELL_AURA_ADD_CASTER_HIT_TRIGGER                   = 111,
        SPELL_AURA_OVERRIDE_CLASS_SCRIPTS                   = 112,
        SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN                  = 113,
        SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT              = 114,
        SPELL_AURA_MOD_HEALING                              = 115,
        SPELL_AURA_MOD_REGEN_DURING_COMBAT                  = 116,
        SPELL_AURA_MOD_MECHANIC_RESISTANCE                  = 117,
        SPELL_AURA_MOD_HEALING_PCT                          = 118,
        SPELL_AURA_119                                      = 119,        // old SPELL_AURA_SHARE_PET_TRACKING
        SPELL_AURA_UNTRACKABLE                              = 120,
        SPELL_AURA_EMPATHY                                  = 121,
        SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT                   = 122,
        SPELL_AURA_MOD_TARGET_RESISTANCE                    = 123,
        SPELL_AURA_MOD_RANGED_ATTACK_POWER                  = 124,
        SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN                   = 125,
        SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT               = 126,
        SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS       = 127,
        SPELL_AURA_MOD_POSSESS_PET                          = 128,
        SPELL_AURA_MOD_SPEED_ALWAYS                         = 129,
        SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS                 = 130,
        SPELL_AURA_MOD_RANGED_ATTACK_POWER_VERSUS           = 131,
        SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT              = 132,
        SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT              = 133,
        SPELL_AURA_MOD_MANA_REGEN_INTERRUPT                 = 134,
        SPELL_AURA_MOD_HEALING_DONE                         = 135,
        SPELL_AURA_MOD_HEALING_DONE_PERCENT                 = 136,
        SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE                = 137,
        SPELL_AURA_MOD_HASTE                                = 138,
        SPELL_AURA_FORCE_REACTION                           = 139,
        SPELL_AURA_MOD_RANGED_HASTE                         = 140,
        SPELL_AURA_MOD_RANGED_AMMO_HASTE                    = 141,
        SPELL_AURA_MOD_BASE_RESISTANCE_PCT                  = 142,
        SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE                 = 143,
        SPELL_AURA_SAFE_FALL                                = 144,
        SPELL_AURA_MOD_PET_TALENT_POINTS                    = 145,
        SPELL_AURA_ALLOW_TAME_PET_TYPE                      = 146,
        SPELL_AURA_MECHANIC_IMMUNITY_MASK                   = 147,
        SPELL_AURA_RETAIN_COMBO_POINTS                      = 148,
        SPELL_AURA_REDUCE_PUSHBACK                          = 149,                      //    Reduce Pushback
        SPELL_AURA_MOD_SHIELD_BLOCKVALUE_PCT                = 150,
        SPELL_AURA_TRACK_STEALTHED                          = 151,                      //    Track Stealthed
        SPELL_AURA_MOD_DETECTED_RANGE                       = 152,                    //    Mod Detected Range
        SPELL_AURA_SPLIT_DAMAGE_FLAT                        = 153,                     //    Split Damage Flat
        SPELL_AURA_MOD_STEALTH_LEVEL                        = 154,                     //    Stealth Level Modifier
        SPELL_AURA_MOD_WATER_BREATHING                      = 155,                   //    Mod Water Breathing
        SPELL_AURA_MOD_REPUTATION_GAIN                      = 156,                   //    Mod Reputation Gain
        SPELL_AURA_PET_DAMAGE_MULTI                         = 157,                      //    Mod Pet Damage
        SPELL_AURA_MOD_SHIELD_BLOCKVALUE                    = 158,
        SPELL_AURA_NO_PVP_CREDIT                            = 159,
        SPELL_AURA_MOD_AOE_AVOIDANCE                        = 160,
        SPELL_AURA_MOD_HEALTH_REGEN_IN_COMBAT               = 161,
        SPELL_AURA_POWER_BURN_MANA                          = 162,
        SPELL_AURA_MOD_CRIT_DAMAGE_BONUS                    = 163,
        SPELL_AURA_164                                      = 164,
        SPELL_AURA_MELEE_ATTACK_POWER_ATTACKER_BONUS        = 165,
        SPELL_AURA_MOD_ATTACK_POWER_PCT                     = 166,
        SPELL_AURA_MOD_RANGED_ATTACK_POWER_PCT              = 167,
        SPELL_AURA_MOD_DAMAGE_DONE_VERSUS                   = 168,
        SPELL_AURA_MOD_CRIT_PERCENT_VERSUS                  = 169,
        SPELL_AURA_DETECT_AMORE                             = 170,
        SPELL_AURA_MOD_SPEED_NOT_STACK                      = 171,
        SPELL_AURA_MOD_MOUNTED_SPEED_NOT_STACK              = 172,
        SPELL_AURA_173                                      = 173,     // old SPELL_AURA_ALLOW_CHAMPION_SPELLS
        SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT         = 174,     // by defeult intelect, dependent from SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT
        SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT        = 175,
        SPELL_AURA_SPIRIT_OF_REDEMPTION                     = 176,
        SPELL_AURA_AOE_CHARM                                = 177,
        SPELL_AURA_MOD_DEBUFF_RESISTANCE                    = 178,
        SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_CHANCE           = 179,
        SPELL_AURA_MOD_FLAT_SPELL_DAMAGE_VERSUS             = 180,
        SPELL_AURA_181                                      = 181,    // old SPELL_AURA_MOD_FLAT_SPELL_CRIT_DAMAGE_VERSUS - possible flat spell crit damage versus
        SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT           = 182,
        SPELL_AURA_MOD_CRITICAL_THREAT                      = 183,
        SPELL_AURA_MOD_ATTACKER_MELEE_HIT_CHANCE            = 184,
        SPELL_AURA_MOD_ATTACKER_RANGED_HIT_CHANCE           = 185,
        SPELL_AURA_MOD_ATTACKER_SPELL_HIT_CHANCE            = 186,
        SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_CHANCE           = 187,
        SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_CHANCE          = 188,
        SPELL_AURA_MOD_RATING                               = 189,
        SPELL_AURA_MOD_FACTION_REPUTATION_GAIN              = 190,
        SPELL_AURA_USE_NORMAL_MOVEMENT_SPEED                = 191,
        SPELL_AURA_HASTE_MELEE                              = 192,
        SPELL_AURA_MELEE_SLOW                               = 193,
        SPELL_AURA_MOD_IGNORE_ABSORB_SCHOOL                 = 194,
        SPELL_AURA_MOD_IGNORE_ABSORB_FOR_SPELL              = 195,
        SPELL_AURA_MOD_COOLDOWN                             = 196,                          // only 24818 Noxious Breath
        SPELL_AURA_MOD_ATTACKER_SPELL_AND_WEAPON_CRIT_CHANCE= 197,
        SPELL_AURA_198                                      = 198,                                   // old SPELL_AURA_MOD_ALL_WEAPON_SKILLS
        SPELL_AURA_MOD_INCREASES_SPELL_PCT_TO_HIT           = 199,
        SPELL_AURA_MOD_KILL_XP_PCT                          = 200,
        SPELL_AURA_FLY                                      = 201,
        SPELL_AURA_IGNORE_COMBAT_RESULT                     = 202,
        SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_DAMAGE           = 203,
        SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_DAMAGE          = 204,
        SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_DAMAGE           = 205,
        SPELL_AURA_MOD_SPEED_MOUNTED                        = 206,                     // ? used in strange spells
        SPELL_AURA_MOD_INCREASE_FLIGHT_SPEED                = 207,
        SPELL_AURA_MOD_SPEED_FLIGHT                         = 208,
        SPELL_AURA_MOD_FLIGHT_SPEED_ALWAYS                  = 209,
        SPELL_AURA_210                                      = 210,  // unused
        SPELL_AURA_MOD_FLIGHT_SPEED_NOT_STACK               = 211,
        SPELL_AURA_MOD_RANGED_ATTACK_POWER_OF_STAT_PERCENT  = 212,
        SPELL_AURA_MOD_RAGE_FROM_DAMAGE_DEALT               = 213,
        SPELL_AURA_214                                      = 214,
        SPELL_AURA_ARENA_PREPARATION                        = 215,
        SPELL_AURA_HASTE_SPELLS                             = 216,
        SPELL_AURA_217                                      = 217,
        SPELL_AURA_HASTE_RANGED                             = 218,
        SPELL_AURA_MOD_MANA_REGEN_FROM_STAT                 = 219,
        SPELL_AURA_MOD_RATING_FROM_STAT                     = 220,
        SPELL_AURA_221                                      = 221,
        SPELL_AURA_222                                      = 222,
        SPELL_AURA_223                                      = 223,
        SPELL_AURA_224                                      = 224,
        SPELL_AURA_PRAYER_OF_MENDING                        = 225,
        SPELL_AURA_PERIODIC_DUMMY                           = 226,
        SPELL_AURA_PERIODIC_TRIGGER_SPELL_WITH_VALUE        = 227,
        SPELL_AURA_DETECT_STEALTH                           = 228,
        SPELL_AURA_MOD_AOE_DAMAGE_AVOIDANCE                 = 229,
        SPELL_AURA_230                                      = 230,
        SPELL_AURA_PROC_TRIGGER_SPELL_WITH_VALUE            = 231,
        SPELL_AURA_MECHANIC_DURATION_MOD                    = 232,
        SPELL_AURA_233                                      = 233,
        SPELL_AURA_MECHANIC_DURATION_MOD_NOT_STACK          = 234,
        SPELL_AURA_MOD_DISPEL_RESIST                        = 235,
        SPELL_AURA_CONTROL_VEHICLE                          = 236,
        SPELL_AURA_MOD_SPELL_DAMAGE_OF_ATTACK_POWER         = 237,
        SPELL_AURA_MOD_SPELL_HEALING_OF_ATTACK_POWER        = 238,
        SPELL_AURA_MOD_SCALE_2                              = 239,
        SPELL_AURA_MOD_EXPERTISE                            = 240,
        SPELL_AURA_FORCE_MOVE_FORWARD                       = 241,
        SPELL_AURA_MOD_SPELL_DAMAGE_FROM_HEALING            = 242,
        SPELL_AURA_243                                      = 243,
        SPELL_AURA_COMPREHEND_LANGUAGE                      = 244,
        SPELL_AURA_MOD_DURATION_OF_MAGIC_EFFECTS            = 245,
        SPELL_AURA_MOD_DURATION_OF_EFFECTS_BY_DISPEL        = 246,
        SPELL_AURA_247                                      = 247,
        SPELL_AURA_MOD_COMBAT_RESULT_CHANCE                 = 248,
        SPELL_AURA_CONVERT_RUNE                             = 249,
        SPELL_AURA_MOD_INCREASE_HEALTH_2                    = 250,
        SPELL_AURA_MOD_ENEMY_DODGE                          = 251,
        SPELL_AURA_252                                      = 252,
        SPELL_AURA_MOD_BLOCK_CRIT_CHANCE                    = 253,
        SPELL_AURA_MOD_DISARM_SHIELD                        = 254,
        SPELL_AURA_MOD_MECHANIC_DAMAGE_TAKEN_PERCENT        = 255,
        SPELL_AURA_NO_REAGENT_USE                           = 256,
        SPELL_AURA_MOD_TARGET_RESIST_BY_SPELL_CLASS         = 257,
        SPELL_AURA_258                                      = 258,
        SPELL_AURA_259                                      = 259,
        SPELL_AURA_SCREEN_EFFECT                            = 260,
        SPELL_AURA_PHASE                                    = 261,
        SPELL_AURA_262                                      = 262,
        SPELL_AURA_ALLOW_ONLY_ABILITY                       = 263,
        SPELL_AURA_264                                      = 264,
        SPELL_AURA_265                                      = 265,
        SPELL_AURA_266                                      = 266,
        SPELL_AURA_MOD_IMMUNE_AURA_APPLY_SCHOOL             = 267,
        SPELL_AURA_MOD_ATTACK_POWER_OF_STAT_PERCENT         = 268,
        SPELL_AURA_MOD_IGNORE_DAMAGE_REDUCTION_SCHOOL       = 269,
        SPELL_AURA_MOD_IGNORE_TARGET_RESIST                 = 270,              // Possibly need swap vs 195 aura used only in 1 spell Chaos Bolt Passive
        SPELL_AURA_MOD_DAMAGE_FROM_CASTER                   = 271,
        SPELL_AURA_MAELSTROM_WEAPON                         = 272,
        SPELL_AURA_X_RAY                                    = 273,
        SPELL_AURA_274                                      = 274,
        SPELL_AURA_MOD_IGNORE_SHAPESHIFT                    = 275,
        SPELL_AURA_276                                      = 276,              // Only "Test Mod Damage % Mechanic" spell, possible mod damage done
        SPELL_AURA_MOD_MAX_AFFECTED_TARGETS                 = 277,
        SPELL_AURA_MOD_DISARM_RANGED                        = 278,
        SPELL_AURA_279                                      = 279,
        SPELL_AURA_MOD_TARGET_ARMOR_PCT                     = 280,
        SPELL_AURA_MOD_HONOR_GAIN                           = 281,
        SPELL_AURA_MOD_BASE_HEALTH_PCT                      = 282,
        SPELL_AURA_MOD_HEALING_RECEIVED                     = 283,              // Possibly only for some spell family class spells
        SPELL_AURA_284                                      = 284,
        SPELL_AURA_MOD_ATTACK_POWER_OF_ARMOR                = 285,
        SPELL_AURA_ABILITY_PERIODIC_CRIT                    = 286,
        SPELL_AURA_DEFLECT_SPELLS                           = 287,
        SPELL_AURA_288                                      = 288,
        SPELL_AURA_289                                      = 289,
        SPELL_AURA_MOD_ALL_CRIT_CHANCE                      = 290,
        SPELL_AURA_MOD_QUEST_XP_PCT                         = 291,
        SPELL_AURA_292                                      = 292,
        SPELL_AURA_293                                      = 293,
        SPELL_AURA_294                                      = 294,
        SPELL_AURA_295                                      = 295,
        SPELL_AURA_296                                      = 296,
        SPELL_AURA_297                                      = 297,
        SPELL_AURA_298                                      = 298,
        SPELL_AURA_299                                      = 299,
        SPELL_AURA_300                                      = 300,
        SPELL_AURA_301                                      = 301,
        SPELL_AURA_302                                      = 302,
        SPELL_AURA_303                                      = 303,
        SPELL_AURA_304                                      = 304,
        SPELL_AURA_MOD_MINIMUM_SPEED                        = 305,
        SPELL_AURA_306                                      = 306,
        SPELL_AURA_307                                      = 307,
        SPELL_AURA_308                                      = 308,
        SPELL_AURA_309                                      = 309,
        SPELL_AURA_310                                      = 310,
        SPELL_AURA_311                                      = 311,
        SPELL_AURA_312                                      = 312,
        SPELL_AURA_313                                      = 313,
        SPELL_AURA_314                                      = 314,
        SPELL_AURA_315                                      = 315,
        SPELL_AURA_316                                      = 316,
        TOTAL_AURAS                                         = 317
    }

    /// <summary>
    /// Target
    /// </summary>
    public enum Targets
    {
        NO_TARGET                               = 0,
        TARGET_SELF                             = 1,
        TARGET_RANDOM_ENEMY_CHAIN_IN_AREA       = 2,                 // only one spell has that, but regardless, it's a target type after all
        TARGET_RANDOM_FRIEND_CHAIN_IN_AREA      = 3,
        TARGET_PET                              = 5,
        TARGET_CHAIN_DAMAGE                     = 6,
        TARGET_AREAEFFECT_INSTANT               = 7,                 // targets around provided destination point
        TARGET_AREAEFFECT_CUSTOM                = 8,
        TARGET_INNKEEPER_COORDINATES            = 9,                 // uses in teleport to innkeeper spells
        TARGET_ALL_ENEMY_IN_AREA                = 15,
        TARGET_ALL_ENEMY_IN_AREA_INSTANT        = 16,
        TARGET_TABLE_X_Y_Z_COORDINATES          = 17,                // uses in teleport spells and some other
        TARGET_EFFECT_SELECT                    = 18,                // highly depends on the spell effect
        TARGET_ALL_PARTY_AROUND_CASTER          = 20,
        TARGET_SINGLE_FRIEND                    = 21,
        TARGET_CASTER_COORDINATES               = 22,                // used only in TargetA, target selection dependent from TargetB
        TARGET_GAMEOBJECT                       = 23,
        TARGET_IN_FRONT_OF_CASTER               = 24,
        TARGET_DUELVSPLAYER                     = 25,
        TARGET_GAMEOBJECT_ITEM                  = 26,
        TARGET_MASTER                           = 27,
        TARGET_ALL_ENEMY_IN_AREA_CHANNELED      = 28,
        TARGET_ALL_FRIENDLY_UNITS_AROUND_CASTER = 30,           // in TargetB used only with TARGET_ALL_AROUND_CASTER and in self casting range in TargetA
        TARGET_ALL_FRIENDLY_UNITS_IN_AREA       = 31,
        TARGET_MINION                           = 32,
        TARGET_ALL_PARTY                        = 33,
        TARGET_ALL_PARTY_AROUND_CASTER_2        = 34,                // used in Tranquility
        TARGET_SINGLE_PARTY                     = 35,
        TARGET_ALL_HOSTILE_UNITS_AROUND_CASTER  = 36,
        TARGET_AREAEFFECT_PARTY                 = 37,
        TARGET_SCRIPT                           = 38,
        TARGET_SELF_FISHING                     = 39,
        TARGET_FOCUS_OR_SCRIPTED_GAMEOBJECT     = 40,
        TARGET_TOTEM_EARTH                      = 41,
        TARGET_TOTEM_WATER                      = 42,
        TARGET_TOTEM_AIR                        = 43,
        TARGET_TOTEM_FIRE                       = 44,
        TARGET_CHAIN_HEAL                       = 45,
        TARGET_SCRIPT_COORDINATES               = 46,
        TARGET_DYNAMIC_OBJECT_FRONT             = 47,
        TARGET_DYNAMIC_OBJECT_BEHIND            = 48,
        TARGET_DYNAMIC_OBJECT_LEFT_SIDE         = 49,
        TARGET_DYNAMIC_OBJECT_RIGHT_SIDE        = 50,
        TARGET_AREAEFFECT_CUSTOM_2              = 52,
        TARGET_CURRENT_ENEMY_COORDINATES        = 53,                // set unit coordinates as dest, only 16 target B imlemented
        TARGET_LARGE_FRONTAL_CONE               = 54,
        TARGET_ALL_RAID_AROUND_CASTER           = 56,
        TARGET_SINGLE_FRIEND_2                  = 57,
        TARGET_NARROW_FRONTAL_CONE              = 60,
        TARGET_AREAEFFECT_PARTY_AND_CLASS       = 61,
        TARGET_DUELVSPLAYER_COORDINATES         = 63,
        TARGET_INFRONT_OF_VICTIM                = 64,
        TARGET_BEHIND_VICTIM                    = 65,                // used in teleport behind spells, caster/target dependent from spell effect
        TARGET_RIGHT_FROM_VICTIM                = 66,
        TARGET_LEFT_FROM_VICTIM                 = 67,
        TARGET_RANDOM_NEARBY_LOC                = 72,                // used in teleport onto nearby locations
        TARGET_RANDOM_CIRCUMFERENCE_POINT       = 73,
        TARGET_DYNAMIC_OBJECT_COORDINATES       = 76,
        TARGET_SINGLE_ENEMY                     = 77,
        TARGET_POINT_AT_NORTH                   = 78,                // 78-85 possible _COORDINATES at radius with pi/4 step around target in unknown order, N?
        TARGET_POINT_AT_SOUTH                   = 79,                // S?
        TARGET_POINT_AT_EAST                    = 80,                // 80/81 must be symmetric from line caster->target, E (base at 82/83, 84/85 order) ?
        TARGET_POINT_AT_WEST                    = 81,                // 80/81 must be symmetric from line caster->target, W (base at 82/83, 84/85 order) ?
        TARGET_POINT_AT_NE                      = 82,                // from spell desc: "(NE)"
        TARGET_POINT_AT_NW                      = 83,                // from spell desc: "(NW)"
        TARGET_POINT_AT_SE                      = 84,                // from spell desc: "(SE)"
        TARGET_POINT_AT_SW                      = 85,                // from spell desc: "(SW)"
        TARGET_RANDOM_NEARBY_DEST               = 86,                // "Test Nearby Dest Random" - random around selected destination
        TARGET_SELF2                            = 87,
        TARGET_DIRECTLY_FORWARD                 = 89,
        TARGET_NONCOMBAT_PET                    = 90,
        TARGET_IN_FRONT_OF_CASTER_30            = 104,
    };

    ///<summary>
    ///Spell proc event related declarations (accessed using SpellMgr functions)
    ///</summary>
    [Flags]
    public enum ProcFlags
    {
        PROC_FLAG_NONE                              = 0x00000000,

        PROC_FLAG_KILLED                            = 0x00000001,    // 00 Killed by aggressor
        PROC_FLAG_KILL                              = 0x00000002,    // 01 Kill target (in most cases need XP/Honor reward)

        PROC_FLAG_SUCCESSFUL_MELEE_HIT              = 0x00000004,    // 02 Successful melee auto attack
        PROC_FLAG_TAKEN_MELEE_HIT                   = 0x00000008,    // 03 Taken damage from melee auto attack hit

        PROC_FLAG_SUCCESSFUL_MELEE_SPELL_HIT        = 0x00000010,    // 04 Successful attack by Spell that use melee weapon
        PROC_FLAG_TAKEN_MELEE_SPELL_HIT             = 0x00000020,    // 05 Taken damage by Spell that use melee weapon

        PROC_FLAG_SUCCESSFUL_RANGED_HIT             = 0x00000040,    // 06 Successful Ranged auto attack
        PROC_FLAG_TAKEN_RANGED_HIT                  = 0x00000080,    // 07 Taken damage from ranged auto attack

        PROC_FLAG_SUCCESSFUL_RANGED_SPELL_HIT       = 0x00000100,    // 08 Successful Ranged attack by Spell that use ranged weapon
        PROC_FLAG_TAKEN_RANGED_SPELL_HIT            = 0x00000200,    // 09 Taken damage by Spell that use ranged weapon

        PROC_FLAG_SUCCESSFUL_POSITIVE_AOE_HIT       = 0x00000400,    // 10 Successful AoE (not 100% sure unused)
        PROC_FLAG_TAKEN_POSITIVE_AOE                = 0x00000800,    // 11 Taken AoE      (not 100% sure unused)

        PROC_FLAG_SUCCESSFUL_AOE_SPELL_HIT          = 0x00001000,    // 12 Successful AoE damage spell hit (not 100% sure unused)
        PROC_FLAG_TAKEN_AOE_SPELL_HIT               = 0x00002000,    // 13 Taken AoE damage spell hit      (not 100% sure unused)

        PROC_FLAG_SUCCESSFUL_POSITIVE_SPELL         = 0x00004000,    // 14 Successful cast positive spell (by default only on healing)
        PROC_FLAG_TAKEN_POSITIVE_SPELL              = 0x00008000,    // 15 Taken positive spell hit (by default only on healing)

        PROC_FLAG_SUCCESSFUL_NEGATIVE_SPELL_HIT     = 0x00010000,    // 16 Successful negative spell cast (by default only on damage)
        PROC_FLAG_TAKEN_NEGATIVE_SPELL_HIT          = 0x00020000,    // 17 Taken negative spell (by default only on damage)

        PROC_FLAG_ON_DO_PERIODIC                    = 0x00040000,    // 18 Successful do periodic (damage / healing, determined from 14-17 flags)
        PROC_FLAG_ON_TAKE_PERIODIC                  = 0x00080000,    // 19 Taken spell periodic (damage / healing, determined from 14-17 flags)

        PROC_FLAG_TAKEN_ANY_DAMAGE                  = 0x00100000,    // 20 Taken any damage
        PROC_FLAG_ON_TRAP_ACTIVATION                = 0x00200000,    // 21 On trap activation

        PROC_FLAG_TAKEN_OFFHAND_HIT                 = 0x00400000,    // 22 Taken off-hand melee attacks(not used)
        PROC_FLAG_SUCCESSFUL_OFFHAND_HIT            = 0x00800000     // 23 Successful off-hand melee attacks
    };

    [Flags]
    public enum ProcFlagsEx
    {
        PROC_EX_NONE                    = 0x0000000,                 // If none can trigger on Hit/Crit only (passive spells MUST defined by SpellFamily flag)

        PROC_EX_NORMAL_HIT              = 0x0000001,                 // If set only from normal hit (only damage spells)
        PROC_EX_CRITICAL_HIT            = 0x0000002,

        PROC_EX_MISS                    = 0x0000004,
        PROC_EX_RESIST                  = 0x0000008,

        PROC_EX_DODGE                   = 0x0000010,
        PROC_EX_PARRY                   = 0x0000020,

        PROC_EX_BLOCK                   = 0x0000040,
        PROC_EX_EVADE                   = 0x0000080,

        PROC_EX_IMMUNE                  = 0x0000100,
        PROC_EX_DEFLECT                 = 0x0000200,

        PROC_EX_ABSORB                  = 0x0000400,
        PROC_EX_REFLECT                 = 0x0000800,

        PROC_EX_INTERRUPT               = 0x0001000,                 // Melee hit result can be Interrupt (not used)
        PROC_EX_FULL_BLOCK              = 0x0002000,                 // block al attack damage

        PROC_EX_RESERVED2               = 0x0004000,
        PROC_EX_RESERVED3               = 0x0008000,

        PROC_EX_EX_TRIGGER_ALWAYS       = 0x0010000,                 // If set trigger always ( no matter another flags) used for drop charges
        PROC_EX_EX_ONE_TIME_TRIGGER     = 0x0020000                  // If set trigger always but only one time (not used)
    };

    public enum SpellSchools
    {
        PHYSICAL   = 0,
        HOLY       = 1,
        FIRE       = 2,
        NATURE     = 3,
        FROST      = 4,
        SHADOW     = 5,
        ARCANE     = 6
    };

    [Flags]
    public enum SpellSchoolMask
    {
        MASK_NONE      = 0x00,                         // not exist
        MASK_PHYSICAL  = (1 << SpellSchools.PHYSICAL), // PHYSICAL (Armor)
        MASK_HOLY      = (1 << SpellSchools.HOLY),
        MASK_FIRE      = (1 << SpellSchools.FIRE),
        MASK_NATURE    = (1 << SpellSchools.NATURE),
        MASK_FROST     = (1 << SpellSchools.FROST),
        MASK_SHADOW    = (1 << SpellSchools.SHADOW),
        MASK_ARCANE    = (1 << SpellSchools.ARCANE),

        // unions

        // 124, not include normal and holy damage
        MASK_SPELL     = (MASK_FIRE | MASK_NATURE | MASK_FROST | MASK_SHADOW | MASK_ARCANE),
        // 126
        MASK_MAGIC     = (MASK_HOLY | MASK_SPELL),
        // 127
        MASK_ALL       = (MASK_PHYSICAL | MASK_MAGIC)
    };

    public enum Mechanics
    {
        MECHANIC_NONE               = 0,
        MECHANIC_CHARM              = 1,
        MECHANIC_DISORIENTED        = 2,
        MECHANIC_DISARM             = 3,
        MECHANIC_DISTRACT           = 4,
        MECHANIC_FEAR               = 5,
        MECHANIC_GRIP               = 6,
        MECHANIC_ROOT               = 7,
        MECHANIC_PACIFY             = 8,   //0 spells use this mechanic
        MECHANIC_SILENCE            = 9,
        MECHANIC_SLEEP              = 10,
        MECHANIC_SNARE              = 11,
        MECHANIC_STUN               = 12,
        MECHANIC_FREEZE             = 13,
        MECHANIC_KNOCKOUT           = 14,
        MECHANIC_BLEED              = 15,
        MECHANIC_BANDAGE            = 16,
        MECHANIC_POLYMORPH          = 17,
        MECHANIC_BANISH             = 18,
        MECHANIC_SHIELD             = 19,
        MECHANIC_SHACKLE            = 20,
        MECHANIC_MOUNT              = 21,
        MECHANIC_INFECTED           = 22,
        MECHANIC_TURN               = 23,
        MECHANIC_HORROR             = 24,
        MECHANIC_INVULNERABILITY    = 25,
        MECHANIC_INTERRUPT          = 26,
        MECHANIC_DAZE               = 27,
        MECHANIC_DISCOVERY          = 28,
        MECHANIC_IMMUNE_SHIELD      = 29,  // Divine (Blessing) Shield/Protection and Ice Block
        MECHANIC_SAPPED             = 30,
        MECHANIC_ENRAGED            = 31
    };

    public enum SpellMissInfo
    {
        SPELL_MISS_NONE     = 0,
        SPELL_MISS_MISS     = 1,
        SPELL_MISS_RESIST   = 2,
        SPELL_MISS_DODGE    = 3,
        SPELL_MISS_PARRY    = 4,
        SPELL_MISS_BLOCK    = 5,
        SPELL_MISS_EVADE    = 6,
        SPELL_MISS_IMMUNE   = 7,
        SPELL_MISS_IMMUNE2  = 8,
        SPELL_MISS_DEFLECT  = 9,
        SPELL_MISS_ABSORB   = 10,
        SPELL_MISS_REFLECT  = 11
    };

    [Flags]
    public enum SpellHitType
    {
        SPELL_HIT_TYPE_UNK1 = 0x00001,
        SPELL_HIT_TYPE_CRIT = 0x00002,
        SPELL_HIT_TYPE_UNK3 = 0x00004,
        SPELL_HIT_TYPE_UNK4 = 0x00008,
        SPELL_HIT_TYPE_UNK5 = 0x00010,                          // replace caster?
        SPELL_HIT_TYPE_UNK6 = 0x00020
    };

    public enum SpellDmgClass
    {
        SPELL_DAMAGE_CLASS_NONE   = 0,
        SPELL_DAMAGE_CLASS_MAGIC  = 1,
        SPELL_DAMAGE_CLASS_MELEE  = 2,
        SPELL_DAMAGE_CLASS_RANGED = 3
    };

    public enum SpellPreventionType
    {
        SPELL_PREVENTION_TYPE_NONE    = 0,
        SPELL_PREVENTION_TYPE_SILENCE = 1,
        SPELL_PREVENTION_TYPE_PACIFY  = 2
    };

    public enum ShapeshiftForm
    {
        FORM_NONE               = 0x00,
        FORM_CAT                = 0x01,
        FORM_TREE               = 0x02,
        FORM_TRAVEL             = 0x03,
        FORM_AQUA               = 0x04,
        FORM_BEAR               = 0x05,
        FORM_AMBIENT            = 0x06,
        FORM_GHOUL              = 0x07,
        FORM_DIREBEAR           = 0x08,
        FORM_STEVES_GHOUL       = 0x09,
        FORM_THARONJA_SKELETON  = 0x0A,
        FORM_TEST_OF_STRENGTH   = 0x0B,
        FORM_BLB_PLAYER         = 0x0C,
        FORM_SHADOW_DANCE       = 0x0D,
        FORM_CREATUREBEAR       = 0x0E,
        FORM_CREATURECAT        = 0x0F,
        FORM_GHOSTWOLF          = 0x10,
        FORM_BATTLESTANCE       = 0x11,
        FORM_DEFENSIVESTANCE    = 0x12,
        FORM_BERSERKERSTANCE    = 0x13,
        FORM_TEST               = 0x14,
        FORM_ZOMBIE             = 0x15,
        FORM_METAMORPHOSIS      = 0x16,
        FORM_UNDEAD             = 0x19,
        FORM_FRENZY             = 0x1A,
        FORM_FLIGHT_EPIC        = 0x1B,
        FORM_SHADOW             = 0x1C,
        FORM_FLIGHT             = 0x1D,
        FORM_STEALTH            = 0x1E,
        FORM_MOONKIN            = 0x1F,
        FORM_SPIRITOFREDEMPTION = 0x20,
        MAX_FORM
    };

    public enum SpellModOp
    {
        SPELLMOD_DAMAGE                 = 0,
        SPELLMOD_DURATION               = 1,
        SPELLMOD_THREAT                 = 2,
        SPELLMOD_EFFECT1                = 3,
        SPELLMOD_CHARGES                = 4,
        SPELLMOD_RANGE                  = 5,
        SPELLMOD_RADIUS                 = 6,
        SPELLMOD_CRITICAL_CHANCE        = 7,
        SPELLMOD_ALL_EFFECTS            = 8,
        SPELLMOD_NOT_LOSE_CASTING_TIME  = 9,
        SPELLMOD_CASTING_TIME           = 10,
        SPELLMOD_COOLDOWN               = 11,
        SPELLMOD_EFFECT2                = 12,
        // spellmod 13 unused
        SPELLMOD_COST                   = 14,
        SPELLMOD_CRIT_DAMAGE_BONUS      = 15,
        SPELLMOD_RESIST_MISS_CHANCE     = 16,
        SPELLMOD_JUMP_TARGETS           = 17,
        SPELLMOD_CHANCE_OF_SUCCESS      = 18,  // Only used with SPELL_AURA_ADD_FLAT_MODIFIER and affects proc spells
        SPELLMOD_ACTIVATION_TIME        = 19,
        SPELLMOD_EFFECT_PAST_FIRST      = 20,
        SPELLMOD_CASTING_TIME_OLD       = 21,
        SPELLMOD_DOT                    = 22,
        SPELLMOD_EFFECT3                = 23,
        SPELLMOD_SPELL_BONUS_DAMAGE     = 24,
        // spellmod 25 unused
        SPELLMOD_FREQUENCY_OF_SUCCESS   = 26,  // Only used with SPELL_AURA_ADD_PCT_MODIFIER and affects used on proc spells
        SPELLMOD_MULTIPLE_VALUE         = 27,
        SPELLMOD_RESIST_DISPEL_CHANCE   = 28
    };

    public enum Powers : uint
    {
        POWER_MANA          = 0,
        POWER_RAGE          = 1,
        POWER_FOCUS         = 2,
        POWER_ENERGY        = 3,
        POWER_HAPPINESS     = 4,
        POWER_RUNE          = 5,
        POWER_RUNIC_POWER   = 6,
        POWER_HEALTH        = 0xFFFFFFFE,    // (-2 as signed value)
    };

    public class SpellEnums
    {
        #region ProcFlagDesc
        
        public const string[] ProcFlagDesc = 
        {
            //00 0x00000001 000000000000000000000001 -
            "00 Killed by aggressor that receive experience or honor",
            //01 0x00000002 000000000000000000000010 -
            "01 Kill that yields experience or honor",

            //02 0x00000004 000000000000000000000100 -
            "02 Successful melee attack",
            //03 0x00000008 000000000000000000001000 -
            "03 Taken damage from melee strike hit",

            //04 0x00000010 000000000000000000010000 -
            "04 Successful attack by Spell that use melee weapon",
            //05 0x00000020 000000000000000000100000 -
            "05 Taken damage by Spell that use melee weapon",

            //06 0x00000040 000000000000000001000000 -
            "06 Successful Ranged attack(and wand spell cast)",
            //07 0x00000080 000000000000000010000000 -
            "07 Taken damage from ranged attack",

            //08 0x00000100 000000000000000100000000 -
            "08 Successful Ranged attack by Spell that use ranged weapon",
            //09 0x00000200 000000000000001000000000 -
            "09 Taken damage by Spell that use ranged weapon",

            //10 0x00000400 000000000000010000000000 -
            "10 Successful ??? spell hit",
            //11 0x00000800 000000000000100000000000 -
            "11 Taken ??? spell hit",

            //12 0x00001000 000000000001000000000000 -
            "12 Successful ??? spell cast",
            //13 0x00002000 000000000010000000000000 -
            "13 Taken ??? spell hit",

            //14 0x00004000 000000000100000000000000 -
            "14 Successful cast positive spell",
            //15 0x00008000 000000001000000000000000 -
            "15 Taken positive spell hit",

            //16 0x00010000 000000010000000000000000 -
            "16 Successful damage from harmful spell cast (каст дамажащего спелла)",
            //17 0x00020000 000000100000000000000000 -
            "17 Taken spell damage",

            //18 0x00040000 000001000000000000000000 -
            "18 Deal periodic damage",
            //19 0x00080000 000010000000000000000000 -
            "19 Taken periodic damage",

            //20 0x00100000 000100000000000000000000 -
            "20 Taken any damage",
            //21 0x00200000 001000000000000000000000 -
            "21 On trap activation (При срабатывании ловушки)",

            //22 0x00800000 010000000000000000000000 -
            "22 Taken off-hand melee attacks",
            //23 0x00800000 100000000000000000000000 -
            "23 Successful off-hand melee attacks",

            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"
        };
        #endregion
    }
}
