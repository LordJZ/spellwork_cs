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
        SPELL_EFFECT_BREAK_PLAYER_TARGETING     = 93,
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
        SPELL_EFFECT_CHARGE2                    = 149,
        SPELL_EFFECT_150                        = 150,
        SPELL_EFFECT_TRIGGER_SPELL_2            = 151,
        SPELL_EFFECT_152                        = 152,
        SPELL_EFFECT_CREATE_PET                 = 153,
        SPELL_EFFECT_TEACH_TAXI_NODE            = 154,
        SPELL_EFFECT_TITAN_GRIP                 = 155,
        SPELL_EFFECT_ENCHANT_ITEM_PRISMATIC     = 156,
        SPELL_EFFECT_CREATE_ITEM_2              = 157,
        SPELL_EFFECT_MILLING                    = 158,
        SPELL_EFFECT_ALLOW_RENAME_PET           = 159,
        SPELL_EFFECT_160                        = 160,
        SPELL_EFFECT_TALENT_SPEC_COUNT          = 161,
        SPELL_EFFECT_TALENT_SPEC_SELECT         = 162,
        SPELL_EFFECT_163                        = 163,
        SPELL_EFFECT_CANCEL_AURA                = 164,

        TOTAL_SPELL_EFFECTS
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
        SPELL_AURA_MOD_FACTION_TEMPLATE                     = 243,
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
        SPELL_AURA_LINKED_AURA                              = 284,
        SPELL_AURA_MOD_ATTACK_POWER_OF_ARMOR                = 285,
        SPELL_AURA_ABILITY_PERIODIC_CRIT                    = 286,
        SPELL_AURA_DEFLECT_SPELLS                           = 287,
        SPELL_AURA_288                                      = 288,              // Deterrence
        SPELL_AURA_289                                      = 289,              // unused
        SPELL_AURA_MOD_ALL_CRIT_CHANCE                      = 290,
        SPELL_AURA_MOD_QUEST_XP_PCT                         = 291,
        SPELL_AURA_OPEN_STABLE                              = 292,
        SPELL_AURA_OVERRIDE_SPELLS                          = 293,
        SPELL_AURA_STOP_MANA_REGEN                          = 294,
        SPELL_AURA_295                                      = 295,              // unused
        SPELL_AURA_296                                      = 296,              // Emulates vehicle?
        SPELL_AURA_ROOT_NO_FALL                             = 297,
        SPELL_AURA_STUN_NO_FALL                             = 298,
        SPELL_AURA_299                                      = 299,              // unused
        SPELL_AURA_SHARE_DAMAGE_PCT                         = 300,
        SPELL_AURA_HEAL_ABSORB                              = 301,
        SPELL_AURA_302                                      = 302,              // unused
        SPELL_AURA_MOD_DAMAGE_DONE_TO_AURA_STATE_PCT        = 303,
        SPELL_AURA_304                                      = 304,
        SPELL_AURA_MOD_MINIMUM_SPEED                        = 305,
        SPELL_AURA_306                                      = 306,
        SPELL_AURA_HEAL_ABSORB_2                            = 307,
        SPELL_AURA_308                                      = 308,
        SPELL_AURA_309                                      = 309,
        SPELL_AURA_MOD_AOE_DAMAGE                           = 310,
        SPELL_AURA_311                                      = 311,              // unused
        SPELL_AURA_312                                      = 312,              // unused
        SPELL_AURA_313                                      = 313,              // unused
        SPELL_AURA_314                                      = 314,              // Confused
        SPELL_AURA_UNDERWATER_WALKING                       = 315,
        SPELL_AURA_HASTE_AFFECT_DOT_TICK                    = 316,
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
        TARGET_4                                = 4,
        TARGET_PET                              = 5,
        TARGET_CHAIN_DAMAGE                     = 6,
        TARGET_AREAEFFECT_INSTANT               = 7,                 // targets around provided destination point
        TARGET_AREAEFFECT_CUSTOM                = 8,
        TARGET_INNKEEPER_COORDINATES            = 9,                 // uses in teleport to innkeeper spells
        TARGET_10                               = 10,
        TARGET_11                               = 11,
        TARGET_12                               = 12,
        TARGET_13                               = 13,
        TARGET_14                               = 14,
        TARGET_ALL_ENEMY_IN_AREA                = 15,
        TARGET_ALL_ENEMY_IN_AREA_INSTANT        = 16,
        TARGET_TABLE_X_Y_Z_COORDINATES          = 17,                // uses in teleport spells and some other
        TARGET_EFFECT_SELECT                    = 18,                // highly depends on the spell effect
        TARGET_19                               = 19,
        TARGET_ALL_PARTY_AROUND_CASTER          = 20,
        TARGET_SINGLE_FRIEND                    = 21,
        TARGET_CASTER_COORDINATES               = 22,                // used only in TargetA, target selection dependent from TargetB
        TARGET_GAMEOBJECT                       = 23,
        TARGET_IN_FRONT_OF_CASTER               = 24,
        TARGET_DUELVSPLAYER                     = 25,
        TARGET_GAMEOBJECT_ITEM                  = 26,
        TARGET_MASTER                           = 27,
        TARGET_ALL_ENEMY_IN_AREA_CHANNELED      = 28,
        TARGET_29                               = 29,
        TARGET_ALL_FRIENDLY_UNITS_AROUND_CASTER = 30,                // in TargetB used only with TARGET_ALL_AROUND_CASTER and in self casting range in TargetA
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
        TARGET_51                               = 51,
        TARGET_AREAEFFECT_CUSTOM_2              = 52,
        TARGET_CURRENT_ENEMY_COORDINATES        = 53,                // set unit coordinates as dest, only 16 target B imlemented
        TARGET_LARGE_FRONTAL_CONE               = 54,
        TARGET_55                               = 55,
        TARGET_ALL_RAID_AROUND_CASTER           = 56,
        TARGET_SINGLE_FRIEND_2                  = 57,
        TARGET_58                               = 58,
        TARGET_59                               = 59,
        TARGET_NARROW_FRONTAL_CONE              = 60,
        TARGET_AREAEFFECT_PARTY_AND_CLASS       = 61,
        TARGET_62                               = 62,
        TARGET_DUELVSPLAYER_COORDINATES         = 63,
        TARGET_INFRONT_OF_VICTIM                = 64,
        TARGET_BEHIND_VICTIM                    = 65,                // used in teleport behind spells, caster/target dependent from spell effect
        TARGET_RIGHT_FROM_VICTIM                = 66,
        TARGET_LEFT_FROM_VICTIM                 = 67,
        TARGET_68                               = 68,
        TARGET_69                               = 69,
        TARGET_70                               = 70,
        TARGET_71                               = 71,
        TARGET_RANDOM_NEARBY_LOC                = 72,                // used in teleport onto nearby locations
        TARGET_RANDOM_CIRCUMFERENCE_POINT       = 73,
        TARGET_74                               = 74,
        TARGET_75                               = 75,
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
        TARGET_88                               = 88,
        TARGET_DIRECTLY_FORWARD                 = 89,
        TARGET_NONCOMBAT_PET                    = 90,
        TARGET_91                               = 91,
        TARGET_92                               = 92,
        TARGET_93                               = 93,
        TARGET_94                               = 94,
        TARGET_95                               = 95,
        TARGET_96                               = 96,
        TARGET_97                               = 97,
        TARGET_98                               = 98,
        TARGET_99                               = 99,
        TARGET_100                              = 100,
        TARGET_101                              = 101,
        TARGET_102                              = 102,
        TARGET_103                              = 103,
        TARGET_IN_FRONT_OF_CASTER_30            = 104,
        TARGET_105                              = 105,
        TARGET_106                              = 106,
        TARGET_107                              = 107,
        TARGET_108                              = 108,
        TARGET_109                              = 109,
        TARGET_110                              = 110,
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

    [Flags]
    public enum ShapeshiftFormMask
    {
        FORM_ALL                = -1,
        FORM_NONE               = 0,
        FORM_CAT                = 1 << 0x00,    // 1
        FORM_TREE               = 1 << 0x01,    // 2
        FORM_TRAVEL             = 1 << 0x02,    // 3
        FORM_AQUA               = 1 << 0x03,    // 4
        FORM_BEAR               = 1 << 0x04,    // 5
        FORM_AMBIENT            = 1 << 0x05,    // 6
        FORM_GHOUL              = 1 << 0x06,    // 7
        FORM_DIREBEAR           = 1 << 0x07,    // 8
        FORM_STEVES_GHOUL       = 1 << 0x08,    // 9
        FORM_THARONJA_SKELETON  = 1 << 0x09,    // 10
        FORM_TEST_OF_STRENGTH   = 1 << 0x0A,    // 11
        FORM_BLB_PLAYER         = 1 << 0x0B,    // 12
        FORM_SHADOW_DANCE       = 1 << 0x0C,    // 13
        FORM_CREATUREBEAR       = 1 << 0x0D,    // 14
        FORM_CREATURECAT        = 1 << 0x0E,    // 15
        FORM_GHOSTWOLF          = 1 << 0x0F,    // 16
        FORM_BATTLESTANCE       = 1 << 0x10,    // 17
        FORM_DEFENSIVESTANCE    = 1 << 0x11,    // 18
        FORM_BERSERKERSTANCE    = 1 << 0x12,    // 19
        FORM_TEST               = 1 << 0x13,    // 20
        FORM_ZOMBIE             = 1 << 0x14,    // 21
        FORM_METAMORPHOSIS      = 1 << 0x15,    // 22
        FORM_UNK1               = 1 << 0x16,    // 23
        FORM_UNK2               = 1 << 0x17,    // 24
        FORM_UNDEAD             = 1 << 0x18,    // 25
        FORM_FRENZY             = 1 << 0x19,    // 26
        FORM_FLIGHT_EPIC        = 1 << 0x1A,    // 27
        FORM_SHADOW             = 1 << 0x1B,    // 28
        FORM_FLIGHT             = 1 << 0x1C,    // 29
        FORM_STEALTH            = 1 << 0x1D,    // 30
        FORM_MOONKIN            = 1 << 0x1E,    // 31
        FORM_SPIRITOFREDEMPTION = 1 << 0x1F,    // 32
    };

    public enum DispelType
    {
        DISPEL_NONE         = 0,
        DISPEL_MAGIC        = 1,
        DISPEL_CURSE        = 2,
        DISPEL_DISEASE      = 3,
        DISPEL_POISON       = 4,
        DISPEL_STEALTH      = 5,
        DISPEL_INVISIBILITY = 6,
        DISPEL_ALL          = 7,
        DISPEL_SPE_NPC_ONLY = 8,
        DISPEL_ENRAGE       = 9,
        DISPEL_ZG_TICKET    = 10,
        DESPEL_OLD_UNUSED   = 11
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

    [Flags]
    public enum SpellCastTargetFlags
    {
        TARGET_FLAG_SELF            = 0x00000000,
        TARGET_FLAG_UNUSED1         = 0x00000001,               // not used in any spells as of 3.0.3 (can be set dynamically)
        TARGET_FLAG_UNIT            = 0x00000002,               // pguid
        TARGET_FLAG_UNUSED2         = 0x00000004,               // not used in any spells as of 3.0.3 (can be set dynamically)
        TARGET_FLAG_UNUSED3         = 0x00000008,               // not used in any spells as of 3.0.3 (can be set dynamically)
        TARGET_FLAG_ITEM            = 0x00000010,               // pguid
        TARGET_FLAG_SOURCE_LOCATION = 0x00000020,               // 3 float
        TARGET_FLAG_DEST_LOCATION   = 0x00000040,               // 3 float
        TARGET_FLAG_OBJECT_UNK      = 0x00000080,               // used in 7 spells only
        TARGET_FLAG_UNIT_UNK        = 0x00000100,               // looks like self target (480 spells)
        TARGET_FLAG_PVP_CORPSE      = 0x00000200,               // pguid
        TARGET_FLAG_UNIT_CORPSE     = 0x00000400,               // 10 spells (gathering professions)
        TARGET_FLAG_OBJECT          = 0x00000800,               // pguid, 2 spells
        TARGET_FLAG_TRADE_ITEM      = 0x00001000,               // pguid, 0 spells
        TARGET_FLAG_STRING          = 0x00002000,               // string, 0 spells
        TARGET_FLAG_UNK1            = 0x00004000,               // 199 spells, opening object/lock
        TARGET_FLAG_CORPSE          = 0x00008000,               // pguid, resurrection spells
        TARGET_FLAG_UNK2            = 0x00010000,               // pguid, not used in any spells as of 3.0.3 (can be set dynamically)
        TARGET_FLAG_GLYPH           = 0x00020000,               // used in glyph spells
        TARGET_FLAG_UNK3            = 0x00040000,               // 
        TARGET_FLAG_UNK4            = 0x00080000                // uint32, loop { vec3, guid -> if guid == 0 break }
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

    public enum AuraState
    {   // (C) used in caster aura state     (T) used in target aura state
        // (c) used in caster aura state-not (t) used in target aura state-not
        AURA_STATE_NONE                     = 0,
        AURA_STATE_DEFENSE                  = 1,            // C   |
        AURA_STATE_HEALTHLESS_20_PERCENT    = 2,            // CcT |
        AURA_STATE_BERSERKING               = 3,            // C T |
        AURA_STATE_FROZEN                   = 4,            //  c t| frozen target
        AURA_STATE_JUDGEMENT                = 5,            // C   |
        AURA_STATE_UNKNOWN6                 = 6,            //     | not used
        AURA_STATE_HUNTER_PARRY             = 7,            // C   |
        //AURA_STATE_ROGUE_ATTACK_FROM_STEALTH    = 7,      // C   | FIX ME: not implemented yet!
        //AURA_STATE_UNKNOWN7                     = 7,      //  c  | random/focused bursts spells (?)
        AURA_STATE_UNKNOWN8                 = 8,            //     | not used
        AURA_STATE_UNKNOWN9                 = 9,            //     | not used
        AURA_STATE_WARRIOR_VICTORY_RUSH     = 10,           // C   | warrior victory rush
        AURA_STATE_UNKNOWN11                = 11,           //    t|
        AURA_STATE_FAERIE_FIRE              = 12,           //  c t| prevent invisibility
        AURA_STATE_HEALTHLESS_35_PERCENT    = 13,           // C T |
        AURA_STATE_CONFLAGRATE              = 14,           //   T | per-caster
        AURA_STATE_SWIFTMEND                = 15,           //   T |
        AURA_STATE_DEADLY_POISON            = 16,           //   T |
        AURA_STATE_ENRAGE                   = 17,           // C   |
        AURA_STATE_UNKNOWN18                = 18,           // C  t|
        AURA_STATE_UNKNOWN19                = 19,           //     | not used
        AURA_STATE_UNKNOWN20                = 20,           //  c  | only (45317 Suicide)
        AURA_STATE_UNKNOWN21                = 21,           //     | not used
        AURA_STATE_UNKNOWN22                = 22,           // C  t| not implemented yet (Requires Evasive Charges to use)
        AURA_STATE_HEALTH_ABOVE_75_PERCENT  = 23            // C   |
    };

    [Flags]
    enum InventoryTypeMask
    {
        ALL             = -1,
        NON_EQUIP       = 1 << 0,
        HEAD            = 1 << 1,
        NECK            = 1 << 2,
        SHOULDERS       = 1 << 3,
        BODY            = 1 << 4,
        CHEST           = 1 << 5,
        WAIST           = 1 << 6,
        LEGS            = 1 << 7,
        FEET            = 1 << 8,
        WRISTS          = 1 << 9,
        HANDS           = 1 << 10,
        FINGER          = 1 << 11,
        TRINKET         = 1 << 12,
        WEAPON          = 1 << 13,
        SHIELD          = 1 << 14,
        RANGED          = 1 << 15,
        CLOAK           = 1 << 16,
        WEAPON_2H       = 1 << 17,
        BAG             = 1 << 18,
        TABARD          = 1 << 19,
        ROBE            = 1 << 20,
        WEAPONMAINHAND  = 1 << 21,
        WEAPONOFFHAND   = 1 << 22,
        HOLDABLE        = 1 << 23,
        AMMO            = 1 << 24,
        THROWN          = 1 << 25,
        RANGEDRIGHT     = 1 << 26,
        QUIVER          = 1 << 27,
        RELIC           = 1 << 28,
    };

    public enum ItemClass
    {
        CONSUMABLE  = 0,
        CONTAINER   = 1,
        WEAPON      = 2,
        GEM         = 3,
        ARMOR       = 4,
        REAGENT     = 5,
        PROJECTILE  = 6,
        TRADE_GOODS = 7,
        GENERIC     = 8,
        RECIPE      = 9,
        MONEY       = 10,
        QUIVER      = 11,
        QUEST       = 12,
        KEY         = 13,
        PERMANENT   = 14,
        MISC        = 15,
        GLYPH       = 16,
        MAX
    };

    [Flags]
    public enum ItemSubClassWeaponMask
    {
        ALL             = -1,
        AXE             = 1 << 0,
        AXE2            = 1 << 1,
        BOW             = 1 << 2,
        GUN             = 1 << 3,
        MACE            = 1 << 4,
        MACE2           = 1 << 5,
        POLEARM         = 1 << 6,
        SWORD           = 1 << 7,
        SWORD2          = 1 << 8,
        obsolete        = 1 << 9,
        STAFF           = 1 << 10,
        EXOTIC          = 1 << 11,
        EXOTIC2         = 1 << 12,
        FIST            = 1 << 13,
        MISC            = 1 << 14,
        DAGGER          = 1 << 15,
        THROWN          = 1 << 16,
        SPEAR           = 1 << 17,
        CROSSBOW        = 1 << 18,
        WAND            = 1 << 19,
        FISHING_POLE    = 1 << 20
    };

    [Flags]
    public enum ItemSubClassArmorMask
    {
        ALL     = -1,
        MISC    = 1 << 0,
        CLOTH   = 1 << 1,
        LEATHER = 1 << 2,
        MAIL    = 1 << 3,
        PLATE   = 1 << 4,
        BUCKLER = 1 << 5,
        SHIELD  = 1 << 6,
        LIBRAM  = 1 << 7,
        IDOL    = 1 << 8,
        TOTEM   = 1 << 9,
        SIGIL   = 1 << 10
    };

    [Flags]
    public enum ItemSubClassMiscMask
    {
        ALL     = -1,
        JUNK    = 1 << 0,
        REAGENT = 1 << 1,
        PET     = 1 << 2,
        HOLIDAY = 1 << 3,
        OTHER   = 1 << 4,
        MOUNT   = 1 << 5,
    }

    [Flags]
    public enum CreatureTypeMask
    {
        ALL             = -1,
        NONE            = 0,
        BEAST           = 1 << 0,
        DRAGONKIN       = 1 << 1,
        DEMON           = 1 << 2,
        ELEMENTAL       = 1 << 3,
        GIANT           = 1 << 4,
        UNDEAD          = 1 << 5,
        HUMANOID        = 1 << 6,
        CRITTER         = 1 << 7,
        MECHANICAL      = 1 << 8,
        NOT_SPECIFIED   = 1 << 9,
        TOTEM           = 1 << 10,
        NON_COMBAT_PET  = 1 << 11,
        GAS_CLOUD       = 1 << 12
    };
    
    [Flags]
    public enum SpellAtribute 
    {
        SPELL_ATTR_ALL                            =        -1,
        SPELL_ATTR_NONE                           =      0x00,  
        SPELL_ATTR_UNK0                           = 1 << 0x00,            // 0
        SPELL_ATTR_RANGED                         = 1 << 0x01,            // 1 All ranged abilites have this flag
        SPELL_ATTR_ON_NEXT_SWING_1                = 1 << 0x02,            // 2 on next swing
        SPELL_ATTR_UNK3                           = 1 << 0x03,            // 3 not set in 3.0.3
        SPELL_ATTR_UNK4                           = 1 << 0x04,            // 4 isAbility
        SPELL_ATTR_TRADESPELL                     = 1 << 0x05,            // 5 trade spells, will be added by client to a sublist of profession spell
        SPELL_ATTR_PASSIVE                        = 1 << 0x06,            // 6 Passive spell
        SPELL_ATTR_UNK7                           = 1 << 0x07,            // 7 can't be linked in chat?
        SPELL_ATTR_UNK8                           = 1 << 0x08,            // 8 hide created item in tooltip (for effect=24)
        SPELL_ATTR_UNK9                           = 1 << 0x09,            // 9
        SPELL_ATTR_ON_NEXT_SWING_2                = 1 << 0x0A,            // 10 on next swing 2
        SPELL_ATTR_UNK11                          = 1 << 0x0B,            // 11
        SPELL_ATTR_DAYTIME_ONLY                   = 1 << 0x0C,            // 12 only useable at daytime, not set in 2.4.2
        SPELL_ATTR_NIGHT_ONLY                     = 1 << 0x0D,            // 13 only useable at night, not set in 2.4.2
        SPELL_ATTR_INDOORS_ONLY                   = 1 << 0x0E,            // 14 only useable indoors, not set in 2.4.2
        SPELL_ATTR_OUTDOORS_ONLY                  = 1 << 0x0F,            // 15 Only useable outdoors.
        SPELL_ATTR_NOT_SHAPESHIFT                 = 1 << 0x10,            // 16 Not while shapeshifted
        SPELL_ATTR_ONLY_STEALTHED                 = 1 << 0x11,            // 17 Must be in stealth
        SPELL_ATTR_UNK18                          = 1 << 0x12,            // 18
        SPELL_ATTR_LEVEL_DAMAGE_CALCULATION       = 1 << 0x13,            // 19 spelldamage depends on caster level
        SPELL_ATTR_STOP_ATTACK_TARGET             = 1 << 0x14,            // 20 Stop attack after use this spell (and not begin attack if use)
        SPELL_ATTR_IMPOSSIBLE_DODGE_PARRY_BLOCK   = 1 << 0x15,            // 21 Cannot be dodged/parried/blocked
        SPELL_ATTR_UNK22                          = 1 << 0x16,            // 22
        SPELL_ATTR_UNK23                          = 1 << 0x17,            // 23 castable while dead?
        SPELL_ATTR_CASTABLE_WHILE_MOUNTED         = 1 << 0x18,            // 24 castable while mounted
        SPELL_ATTR_DISABLED_WHILE_ACTIVE          = 1 << 0x19,            // 25 Activate and start cooldown after aura fade or remove summoned creature or go
        SPELL_ATTR_UNK26                          = 1 << 0x1A,            // 26
        SPELL_ATTR_CASTABLE_WHILE_SITTING         = 1 << 0x1B,            // 27 castable while sitting
        SPELL_ATTR_CANT_USED_IN_COMBAT            = 1 << 0x1C,            // 28 Cannot be used in combat
        SPELL_ATTR_UNAFFECTED_BY_INVULNERABILITY  = 1 << 0x1D,            // 29 unaffected by invulnerability (hmm possible not...)
        SPELL_ATTR_UNK30                          = 1 << 0x1E,            // 30 breakable by damage?
        SPELL_ATTR_CANT_CANCEL                    = 1 << 0x1F,            // 31 positive aura can't be canceled
    };

    [Flags]
    public enum SpellAtributeEx
    {
        SPELL_ATTR_EX_ALL                         =        -1,
        SPELL_ATTR_EX_NONE                        =      0x00,
        SPELL_ATTR_EX_UNK0                        = 1 << 0x00,            // 0
        SPELL_ATTR_EX_DRAIN_ALL_POWER             = 1 << 0x01,            // 1 use all power (Only paladin Lay of Hands and Bunyanize)
        SPELL_ATTR_EX_CHANNELED_1                 = 1 << 0x02,            // 2 channeled 1
        SPELL_ATTR_EX_UNK3                        = 1 << 0x03,            // 3
        SPELL_ATTR_EX_UNK4                        = 1 << 0x04,            // 4
        SPELL_ATTR_EX_NOT_BREAK_STEALTH           = 1 << 0x05,            // 5 Not break stealth
        SPELL_ATTR_EX_CHANNELED_2                 = 1 << 0x06,            // 6 channeled 2
        SPELL_ATTR_EX_NEGATIVE                    = 1 << 0x07,            // 7
        SPELL_ATTR_EX_NOT_IN_COMBAT_TARGET        = 1 << 0x08,            // 8 Spell req target not to be in combat state
        SPELL_ATTR_EX_UNK9                        = 1 << 0x09,            // 9
        SPELL_ATTR_EX_NO_INITIAL_AGGRO            = 1 << 0x0A,            // 10 no generates threat on cast 100%
        SPELL_ATTR_EX_UNK11                       = 1 << 0x0B,            // 11
        SPELL_ATTR_EX_UNK12                       = 1 << 0x0C,            // 12
        SPELL_ATTR_EX_UNK13                       = 1 << 0x0D,            // 13
        SPELL_ATTR_EX_UNK14                       = 1 << 0x0E,            // 14
        SPELL_ATTR_EX_DISPEL_AURAS_ON_IMMUNITY    = 1 << 0x0F,            // 15 remove auras on immunity
        SPELL_ATTR_EX_UNAFFECTED_BY_SCHOOL_IMMUNE = 1 << 0x10,            // 16 unaffected by school immunity
        SPELL_ATTR_EX_UNK17                       = 1 << 0x11,            // 17
        SPELL_ATTR_EX_UNK18                       = 1 << 0x12,            // 18
        SPELL_ATTR_EX_UNK19                       = 1 << 0x13,            // 19
        SPELL_ATTR_EX_REQ_COMBO_POINTS1           = 1 << 0x14,            // 20 Req combo points on target
        SPELL_ATTR_EX_UNK21                       = 1 << 0x15,            // 21
        SPELL_ATTR_EX_REQ_COMBO_POINTS2           = 1 << 0x16,            // 22 Req combo points on target
        SPELL_ATTR_EX_UNK23                       = 1 << 0x17,            // 23
        SPELL_ATTR_EX_UNK24                       = 1 << 0x18,            // 24 Req fishing pole??
        SPELL_ATTR_EX_UNK25                       = 1 << 0x19,            // 25
        SPELL_ATTR_EX_UNK26                       = 1 << 0x1A,            // 26
        SPELL_ATTR_EX_UNK27                       = 1 << 0x1B,            // 27
        SPELL_ATTR_EX_UNK28                       = 1 << 0x1C,            // 28
        SPELL_ATTR_EX_UNK29                       = 1 << 0x1D,            // 29
        SPELL_ATTR_EX_UNK30                       = 1 << 0x1E,            // 30 overpower
        SPELL_ATTR_EX_UNK31                       = 1 << 0x1F,            // 31
    };

    [Flags]
    public enum SpellAtributeEx2
    {
        SPELL_ATTR_EX2_ALL                        =        -1,
        SPELL_ATTR_EX2_NONE                       =      0x00,
        SPELL_ATTR_EX2_UNK0                       = 1 << 0x00,            // 0
        SPELL_ATTR_EX2_UNK1                       = 1 << 0x01,            // 1
        SPELL_ATTR_EX2_CANT_REFLECTED             = 1 << 0x02,            // 2 ? used for detect can or not spell reflected // do not need LOS (e.g. 18220 since 3.3.3)
        SPELL_ATTR_EX2_UNK3                       = 1 << 0x03,            // 3 auto targeting? (e.g. fishing skill enhancement items since 3.3.3)
        SPELL_ATTR_EX2_UNK4                       = 1 << 0x04,            // 4
        SPELL_ATTR_EX2_AUTOREPEAT_FLAG            = 1 << 0x05,            // 5
        SPELL_ATTR_EX2_UNK6                       = 1 << 0x06,            // 6 only usable on tabbed by yourself
        SPELL_ATTR_EX2_UNK7                       = 1 << 0x07,            // 7
        SPELL_ATTR_EX2_UNK8                       = 1 << 0x08,            // 8 not set in 3.0.3
        SPELL_ATTR_EX2_UNK9                       = 1 << 0x09,            // 9
        SPELL_ATTR_EX2_UNK10                      = 1 << 0x0A,            // 10
        SPELL_ATTR_EX2_HEALTH_FUNNEL              = 1 << 0x0B,            // 11
        SPELL_ATTR_EX2_UNK12                      = 1 << 0x0C,            // 12
        SPELL_ATTR_EX2_UNK13                      = 1 << 0x0D,            // 13
        SPELL_ATTR_EX2_UNK14                      = 1 << 0x0E,            // 14
        SPELL_ATTR_EX2_UNK15                      = 1 << 0x0F,            // 15 not set in 3.0.3
        SPELL_ATTR_EX2_UNK16                      = 1 << 0x10,            // 16
        SPELL_ATTR_EX2_UNK17                      = 1 << 0x11,            // 17 suspend weapon timer instead of resetting it, (?Hunters Shot and Stings only have this flag?)
        SPELL_ATTR_EX2_UNK18                      = 1 << 0x12,            // 18 Only Revive pet - possible req dead pet
        SPELL_ATTR_EX2_NOT_NEED_SHAPESHIFT        = 1 << 0x13,            // 19 does not necessarly need shapeshift
        SPELL_ATTR_EX2_UNK20                      = 1 << 0x14,            // 20
        SPELL_ATTR_EX2_DAMAGE_REDUCED_SHIELD      = 1 << 0x15,            // 21 for ice blocks, pala immunity buffs, priest absorb shields, but used also for other spells -> not sure!
        SPELL_ATTR_EX2_UNK22                      = 1 << 0x16,            // 22
        SPELL_ATTR_EX2_UNK23                      = 1 << 0x17,            // 23 Only mage Arcane Concentration have this flag
        SPELL_ATTR_EX2_UNK24                      = 1 << 0x18,            // 24
        SPELL_ATTR_EX2_UNK25                      = 1 << 0x19,            // 25
        SPELL_ATTR_EX2_UNK26                      = 1 << 0x1A,            // 26 unaffected by school immunity
        SPELL_ATTR_EX2_UNK27                      = 1 << 0x1B,            // 27
        SPELL_ATTR_EX2_UNK28                      = 1 << 0x1C,            // 28 no breaks stealth if it fails??
        SPELL_ATTR_EX2_CANT_CRIT                  = 1 << 0x1D,            // 29 Spell can't crit
        SPELL_ATTR_EX2_UNK30                      = 1 << 0x1E,            // 30
        SPELL_ATTR_EX2_FOOD_BUFF                  = 1 << 0x1F,            // 31 Food or Drink Buff (like Well Fed)
    };

    [Flags]
    public enum SpellAtributeEx3
    {
        SPELL_ATTR_EX3_ALL                        =        -1,
        SPELL_ATTR_EX3_NONE                       =      0x00,
        SPELL_ATTR_EX3_UNK0                       = 1 << 0x00,            // 0
        SPELL_ATTR_EX3_UNK1                       = 1 << 0x01,            // 1
        SPELL_ATTR_EX3_UNK2                       = 1 << 0x02,            // 2
        SPELL_ATTR_EX3_UNK3                       = 1 << 0x03,            // 3
        SPELL_ATTR_EX3_UNK4                       = 1 << 0x04,            // 4 Druid Rebirth only this spell have this flag
        SPELL_ATTR_EX3_UNK5                       = 1 << 0x05,            // 5
        SPELL_ATTR_EX3_UNK6                       = 1 << 0x06,            // 6
        SPELL_ATTR_EX3_UNK7                       = 1 << 0x07,            // 7 create a separate (de)buff stack for each caster
        SPELL_ATTR_EX3_UNK8                       = 1 << 0x08,            // 8
        SPELL_ATTR_EX3_UNK9                       = 1 << 0x09,            // 9
        SPELL_ATTR_EX3_MAIN_HAND                  = 1 << 0x0A,            // 10 Main hand weapon required
        SPELL_ATTR_EX3_BATTLEGROUND               = 1 << 0x0B,            // 11 Can casted only on battleground
        SPELL_ATTR_EX3_CAST_ON_DEAD               = 1 << 0x0C,            // 12 target is a dead player (not every spell has this flag)
        SPELL_ATTR_EX3_UNK13                      = 1 << 0x0D,            // 13
        SPELL_ATTR_EX3_UNK14                      = 1 << 0x0E,            // 14 "Honorless Target" only this spells have this flag
        SPELL_ATTR_EX3_UNK15                      = 1 << 0x0F,            // 15 Auto Shoot, Shoot, Throw,  - this is autoshot flag
        SPELL_ATTR_EX3_UNK16                      = 1 << 0x10,            // 16 no triggers effects that trigger on casting a spell??
        SPELL_ATTR_EX3_UNK17                      = 1 << 0x11,            // 17 no triggers effects that trigger on casting a spell??
        SPELL_ATTR_EX3_UNK18                      = 1 << 0x12,            // 18
        SPELL_ATTR_EX3_UNK19                      = 1 << 0x13,            // 19
        SPELL_ATTR_EX3_DEATH_PERSISTENT           = 1 << 0x14,            // 20 Death persistent spells
        SPELL_ATTR_EX3_UNK21                      = 1 << 0x15,            // 21
        SPELL_ATTR_EX3_REQ_WAND                   = 1 << 0x16,            // 22 Req wand
        SPELL_ATTR_EX3_UNK23                      = 1 << 0x17,            // 23
        SPELL_ATTR_EX3_REQ_OFFHAND                = 1 << 0x18,            // 24 Req offhand weapon
        SPELL_ATTR_EX3_UNK25                      = 1 << 0x19,            // 25 no cause spell pushback ?
        SPELL_ATTR_EX3_UNK26                      = 1 << 0x1A,            // 26
        SPELL_ATTR_EX3_UNK27                      = 1 << 0x1B,            // 27
        SPELL_ATTR_EX3_UNK28                      = 1 << 0x1C,            // 28
        SPELL_ATTR_EX3_UNK29                      = 1 << 0x1D,            // 29
        SPELL_ATTR_EX3_UNK30                      = 1 << 0x1E,            // 30
        SPELL_ATTR_EX3_UNK31                      = 1 << 0x1F,            // 31
    };

    [Flags]
    public enum SpellAtributeEx4
    {
        SPELL_ATTR_EX4_ALL                        =        -1,
        SPELL_ATTR_EX4_NONE                       =      0x00,
        SPELL_ATTR_EX4_UNK0                       = 1 << 0x00,            // 0
        SPELL_ATTR_EX4_UNK1                       = 1 << 0x01,            // 1 proc on finishing move?
        SPELL_ATTR_EX4_UNK2                       = 1 << 0x02,            // 2
        SPELL_ATTR_EX4_UNK3                       = 1 << 0x03,            // 3
        SPELL_ATTR_EX4_UNK4                       = 1 << 0x04,            // 4 This will no longer cause guards to attack on use??
        SPELL_ATTR_EX4_UNK5                       = 1 << 0x05,            // 5
        SPELL_ATTR_EX4_NOT_STEALABLE              = 1 << 0x06,            // 6 although such auras might be dispellable, they cannot be stolen
        SPELL_ATTR_EX4_UNK7                       = 1 << 0x07,            // 7
        SPELL_ATTR_EX4_STACK_DOT_MODIFIER         = 1 << 0x08,            // 8 no effect on non DoTs?
        SPELL_ATTR_EX4_UNK9                       = 1 << 0x09,            // 9
        SPELL_ATTR_EX4_SPELL_VS_EXTEND_COST       = 1 << 0x0A,            // 10 Rogue Shiv have this flag
        SPELL_ATTR_EX4_UNK11                      = 1 << 0x0B,            // 11
        SPELL_ATTR_EX4_UNK12                      = 1 << 0x0C,            // 12
        SPELL_ATTR_EX4_UNK13                      = 1 << 0x0D,            // 13
        SPELL_ATTR_EX4_UNK14                      = 1 << 0x0E,            // 14
        SPELL_ATTR_EX4_UNK15                      = 1 << 0x0F,            // 15
        SPELL_ATTR_EX4_NOT_USABLE_IN_ARENA        = 1 << 0x10,            // 16 not usable in arena
        SPELL_ATTR_EX4_USABLE_IN_ARENA            = 1 << 0x11,            // 17 usable in arena
        SPELL_ATTR_EX4_UNK18                      = 1 << 0x12,            // 18
        SPELL_ATTR_EX4_UNK19                      = 1 << 0x13,            // 19
        SPELL_ATTR_EX4_UNK20                      = 1 << 0x14,            // 20 do not give "more powerful spell" error message
        SPELL_ATTR_EX4_UNK21                      = 1 << 0x15,            // 21
        SPELL_ATTR_EX4_UNK22                      = 1 << 0x16,            // 22
        SPELL_ATTR_EX4_UNK23                      = 1 << 0x17,            // 23
        SPELL_ATTR_EX4_UNK24                      = 1 << 0x18,            // 24
        SPELL_ATTR_EX4_UNK25                      = 1 << 0x19,            // 25 pet scaling auras
        SPELL_ATTR_EX4_CAST_ONLY_IN_OUTLAND       = 1 << 0x1A,            // 26 Can only be used in Outland.
        SPELL_ATTR_EX4_UNK27                      = 1 << 0x1B,            // 27
        SPELL_ATTR_EX4_UNK28                      = 1 << 0x1C,            // 28
        SPELL_ATTR_EX4_UNK29                      = 1 << 0x1D,            // 29
        SPELL_ATTR_EX4_UNK30                      = 1 << 0x1E,            // 30
        SPELL_ATTR_EX4_UNK31                      = 1 << 0x1F,            // 31
    };

    [Flags]
    public enum SpellAtributeEx5
    {
        SPELL_ATTR_EX5_ALL                        =        -1,
        SPELL_ATTR_EX5_NONE                       =      0x00,
        SPELL_ATTR_EX5_UNK0                       = 1 << 0x00,            // 0
        SPELL_ATTR_EX5_NO_REAGENT_WHILE_PREP      = 1 << 0x01,            // 1 not need reagents if UNIT_FLAG_PREPARATION
        SPELL_ATTR_EX5_UNK2                       = 1 << 0x02,            // 2 removed at enter arena (e.g. 31850 since 3.3.3)
        SPELL_ATTR_EX5_USABLE_WHILE_STUNNED       = 1 << 0x03,            // 3 usable while stunned
        SPELL_ATTR_EX5_UNK4                       = 1 << 0x04,            // 4
        SPELL_ATTR_EX5_SINGLE_TARGET_SPELL        = 1 << 0x05,            // 5 Only one target can be apply at a time
        SPELL_ATTR_EX5_UNK6                       = 1 << 0x06,            // 6
        SPELL_ATTR_EX5_UNK7                       = 1 << 0x07,            // 7
        SPELL_ATTR_EX5_UNK8                       = 1 << 0x08,            // 8
        SPELL_ATTR_EX5_START_PERIODIC_AT_APPLY    = 1 << 0x09,            // 9  begin periodic tick at aura apply
        SPELL_ATTR_EX5_UNK10                      = 1 << 0x0A,            // 10
        SPELL_ATTR_EX5_UNK11                      = 1 << 0x0B,            // 11
        SPELL_ATTR_EX5_UNK12                      = 1 << 0x0C,            // 12
        SPELL_ATTR_EX5_UNK13                      = 1 << 0x0D,            // 13 haste affects duration (e.g. 8050 since 3.3.3)
        SPELL_ATTR_EX5_UNK14                      = 1 << 0x0E,            // 14
        SPELL_ATTR_EX5_UNK15                      = 1 << 0x0F,            // 15
        SPELL_ATTR_EX5_UNK16                      = 1 << 0x10,            // 16
        SPELL_ATTR_EX5_USABLE_WHILE_FEARED        = 1 << 0x11,            // 17 usable while feared
        SPELL_ATTR_EX5_USABLE_WHILE_CONFUSED      = 1 << 0x12,            // 18 usable while confused
        SPELL_ATTR_EX5_UNK19                      = 1 << 0x13,            // 19
        SPELL_ATTR_EX5_UNK20                      = 1 << 0x14,            // 20
        SPELL_ATTR_EX5_UNK21                      = 1 << 0x15,            // 21
        SPELL_ATTR_EX5_UNK22                      = 1 << 0x16,            // 22
        SPELL_ATTR_EX5_UNK23                      = 1 << 0x17,            // 23
        SPELL_ATTR_EX5_UNK24                      = 1 << 0x18,            // 24
        SPELL_ATTR_EX5_UNK25                      = 1 << 0x19,            // 25
        SPELL_ATTR_EX5_UNK26                      = 1 << 0x1A,            // 26
        SPELL_ATTR_EX5_UNK27                      = 1 << 0x1B,            // 27
        SPELL_ATTR_EX5_UNK28                      = 1 << 0x1C,            // 28
        SPELL_ATTR_EX5_UNK29                      = 1 << 0x1D,            // 29
        SPELL_ATTR_EX5_UNK30                      = 1 << 0x1E,            // 30
        SPELL_ATTR_EX5_UNK31                      = 1 << 0x1F,            // 31 Forces all nearby enemies to focus attacks caster
    };

    [Flags]
    public enum SpellAtributeEx6
    {
        SPELL_ATTR_EX6_ALL                        =        -1,
        SPELL_ATTR_EX6_NONE                       =      0x00,
        SPELL_ATTR_EX6_UNK0                       = 1 << 0x00,            // 0 Only Move spell have this flag
        SPELL_ATTR_EX6_ONLY_IN_ARENA              = 1 << 0x01,            // 1 only usable in arena, not used in 3.2.0a and early
        SPELL_ATTR_EX6_UNK2                       = 1 << 0x02,            // 2
        SPELL_ATTR_EX6_UNK3                       = 1 << 0x03,            // 3
        SPELL_ATTR_EX6_UNK4                       = 1 << 0x04,            // 4
        SPELL_ATTR_EX6_UNK5                       = 1 << 0x05,            // 5
        SPELL_ATTR_EX6_UNK6                       = 1 << 0x06,            // 6
        SPELL_ATTR_EX6_UNK7                       = 1 << 0x07,            // 7
        SPELL_ATTR_EX6_UNK8                       = 1 << 0x08,            // 8
        SPELL_ATTR_EX6_UNK9                       = 1 << 0x09,            // 9
        SPELL_ATTR_EX6_UNK10                      = 1 << 0x0A,            // 10
        SPELL_ATTR_EX6_NOT_IN_RAID_INSTANCE       = 1 << 0x0B,            // 11 not usable in raid instance
        SPELL_ATTR_EX6_UNK12                      = 1 << 0x0C,            // 12
        SPELL_ATTR_EX6_UNK13                      = 1 << 0x0D,            // 13
        SPELL_ATTR_EX6_UNK14                      = 1 << 0x0E,            // 14
        SPELL_ATTR_EX6_UNK15                      = 1 << 0x0F,            // 15 not set in 3.0.3
        SPELL_ATTR_EX6_UNK16                      = 1 << 0x10,            // 16
        SPELL_ATTR_EX6_UNK17                      = 1 << 0x11,            // 17
        SPELL_ATTR_EX6_UNK18                      = 1 << 0x12,            // 18
        SPELL_ATTR_EX6_UNK19                      = 1 << 0x13,            // 19
        SPELL_ATTR_EX6_UNK20                      = 1 << 0x14,            // 20
        SPELL_ATTR_EX6_UNK21                      = 1 << 0x15,            // 21
        SPELL_ATTR_EX6_UNK22                      = 1 << 0x16,            // 22
        SPELL_ATTR_EX6_UNK23                      = 1 << 0x17,            // 23 not set in 3.0.3
        SPELL_ATTR_EX6_UNK24                      = 1 << 0x18,            // 24 not set in 3.0.3
        SPELL_ATTR_EX6_UNK25                      = 1 << 0x19,            // 25 not set in 3.0.3
        SPELL_ATTR_EX6_UNK26                      = 1 << 0x1A,            // 26 not set in 3.0.3
        SPELL_ATTR_EX6_UNK27                      = 1 << 0x1B,            // 27 not set in 3.0.3
        SPELL_ATTR_EX6_UNK28                      = 1 << 0x1C,            // 28 not set in 3.0.3
        SPELL_ATTR_EX6_NO_DMG_PERCENT_MODS        = 1 << 0x1D,            // 29 do not apply damage percent mods (usually in cases where it has already been applied)
        SPELL_ATTR_EX6_UNK30                      = 1 << 0x1E,            // 30 not set in 3.0.3
        SPELL_ATTR_EX6_UNK31                      = 1 << 0x1F,            // 31 not set in 3.0.3
    };
    
    [Flags]
    public enum SpellAtributeExG
    {
        SPELL_ATTR_EXG_ALL                        =        -1,
        SPELL_ATTR_EXG_NONE                       =      0x00,
        SPELL_ATTR_EXG_UNK0                       = 1 << 0x00,            // 0 
        SPELL_ATTR_EXG_UNK1                       = 1 << 0x01,            // 1 
        SPELL_ATTR_EXG_UNK2                       = 1 << 0x02,            // 2
        SPELL_ATTR_EXG_UNK3                       = 1 << 0x03,            // 3
        SPELL_ATTR_EXG_UNK4                       = 1 << 0x04,            // 4
        SPELL_ATTR_EXG_UNK5                       = 1 << 0x05,            // 5
        SPELL_ATTR_EXG_UNK6                       = 1 << 0x06,            // 6
        SPELL_ATTR_EXG_UNK7                       = 1 << 0x07,            // 7
        SPELL_ATTR_EXG_UNK8                       = 1 << 0x08,            // 8
        SPELL_ATTR_EXG_UNK9                       = 1 << 0x09,            // 9
        SPELL_ATTR_EXG_UNK10                      = 1 << 0x0A,            // 10
        SPELL_ATTR_EXG_UNK11                      = 1 << 0x0B,            // 11 
        SPELL_ATTR_EXG_UNK12                      = 1 << 0x0C,            // 12
        SPELL_ATTR_EXG_UNK13                      = 1 << 0x0D,            // 13
        SPELL_ATTR_EXG_UNK14                      = 1 << 0x0E,            // 14
        SPELL_ATTR_EXG_UNK15                      = 1 << 0x0F,            // 15 
        SPELL_ATTR_EXG_UNK16                      = 1 << 0x10,            // 16
        SPELL_ATTR_EXG_UNK17                      = 1 << 0x11,            // 17
        SPELL_ATTR_EXG_UNK18                      = 1 << 0x12,            // 18
        SPELL_ATTR_EXG_UNK19                      = 1 << 0x13,            // 19
        SPELL_ATTR_EXG_UNK20                      = 1 << 0x14,            // 20
        SPELL_ATTR_EXG_UNK21                      = 1 << 0x15,            // 21
        SPELL_ATTR_EXG_UNK22                      = 1 << 0x16,            // 22
        SPELL_ATTR_EXG_UNK23                      = 1 << 0x17,            // 23 
        SPELL_ATTR_EXG_UNK24                      = 1 << 0x18,            // 24 
        SPELL_ATTR_EXG_UNK25                      = 1 << 0x19,            // 25 
        SPELL_ATTR_EXG_UNK26                      = 1 << 0x1A,            // 26 
        SPELL_ATTR_EXG_UNK27                      = 1 << 0x1B,            // 27
        SPELL_ATTR_EXG_UNK28                      = 1 << 0x1C,            // 28
        SPELL_ATTR_EXG_UNK29                      = 1 << 0x1D,            // 29
        SPELL_ATTR_EXG_UNK30                      = 1 << 0x1E,            // 30
        SPELL_ATTR_EXG_UNK31                      = 1 << 0x1F,            // 31
    };

    [Flags]
    public enum CombatRating
    {
        CR_WEAPON_SKILL             =      0x00,
        CR_DEFENSE_SKILL            = 1 << 0x00,
        CR_DODGE                    = 1 << 0x01,
        CR_PARRY                    = 1 << 0x02,
        CR_BLOCK                    = 1 << 0x03,
        CR_HIT_MELEE                = 1 << 0x04,
        CR_HIT_RANGED               = 1 << 0x05,
        CR_HIT_SPELL                = 1 << 0x06,
        CR_CRIT_MELEE               = 1 << 0x07,
        CR_CRIT_RANGED              = 1 << 0x08,
        CR_CRIT_SPELL               = 1 << 0x09,
        CR_HIT_TAKEN_MELEE          = 1 << 0x0A,
        CR_HIT_TAKEN_RANGED         = 1 << 0x0B,
        CR_HIT_TAKEN_SPELL          = 1 << 0x0C,
        CR_CRIT_TAKEN_MELEE         = 1 << 0x0D,
        CR_CRIT_TAKEN_RANGED        = 1 << 0x0E,
        CR_CRIT_TAKEN_SPELL         = 1 << 0x0F,
        CR_HASTE_MELEE              = 1 << 0x10,
        CR_HASTE_RANGED             = 1 << 0x11,
        CR_HASTE_SPELL              = 1 << 0x12,
        CR_WEAPON_SKILL_MAINHAND    = 1 << 0x13,
        CR_WEAPON_SKILL_OFFHAND     = 1 << 0x14,
        CR_WEAPON_SKILL_RANGED      = 1 << 0x15,
        CR_EXPERTISE                = 1 << 0x16,
        CR_ARMOR_PENETRATION        = 1 << 0x17,
    };

    public enum UnitMods
    {
        UNIT_MOD_STAT_STRENGTH          = 0,                  // UNIT_MOD_STAT_STRENGTH..UNIT_MOD_STAT_SPIRIT must be in existed order, it's accessed by index values of Stats enum.
        UNIT_MOD_STAT_AGILITY           = 1,
        UNIT_MOD_STAT_STAMINA           = 2,
        UNIT_MOD_STAT_INTELLECT         = 3,
        UNIT_MOD_STAT_SPIRIT            = 4,
        UNIT_MOD_HEALTH                 = 5,
        UNIT_MOD_MANA                   = 6,                  // UNIT_MOD_MANA..UNIT_MOD_RUNIC_POWER must be in existed order, it's accessed by index values of Powers enum.
        UNIT_MOD_RAGE                   = 7,
        UNIT_MOD_FOCUS                  = 8,
        UNIT_MOD_ENERGY                 = 9,
        UNIT_MOD_HAPPINESS              = 10,
        UNIT_MOD_RUNE                   = 11,
        UNIT_MOD_RUNIC_POWER            = 12,
        UNIT_MOD_ARMOR                  = 13,                 // UNIT_MOD_ARMOR..UNIT_MOD_RESISTANCE_ARCANE must be in existed order, it's accessed by index values of SpellSchools enum.
        UNIT_MOD_RESISTANCE_HOLY        = 14,
        UNIT_MOD_RESISTANCE_FIRE        = 15,
        UNIT_MOD_RESISTANCE_NATURE      = 16,
        UNIT_MOD_RESISTANCE_FROST       = 17,
        UNIT_MOD_RESISTANCE_SHADOW      = 18,
        UNIT_MOD_RESISTANCE_ARCANE      = 19,
        UNIT_MOD_ATTACK_POWER           = 20,
        UNIT_MOD_ATTACK_POWER_RANGED    = 21,
        UNIT_MOD_DAMAGE_MAINHAND        = 22,
        UNIT_MOD_DAMAGE_OFFHAND         = 23,
        UNIT_MOD_DAMAGE_RANGED          = 24,
        UNIT_MOD_END                    = 25,
        // synonyms
        UNIT_MOD_STAT_START             = UNIT_MOD_STAT_STRENGTH,
        UNIT_MOD_STAT_END               = UNIT_MOD_STAT_SPIRIT       + 1,
        UNIT_MOD_RESISTANCE_START       = UNIT_MOD_ARMOR,
        UNIT_MOD_RESISTANCE_END         = UNIT_MOD_RESISTANCE_ARCANE + 1,
        UNIT_MOD_POWER_START            = UNIT_MOD_MANA,
        UNIT_MOD_POWER_END              = UNIT_MOD_RUNIC_POWER       + 1,
    };

    public class SpellEnums
    {
        #region ProcFlagDesc

        public static readonly string[] ProcFlagDesc = 
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
