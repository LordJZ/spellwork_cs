using System;
using System.Collections.Generic;

namespace SpellWork
{
    class Loader
    {
        public Loader()
        {
            DBC.Spell       = DBCReader.ReadDBC<SpellEntry>(DBC.SpellStrings);
            DBC.SpellEffect = DBCReader.ReadDBC<SpellEffectEntry>(null);

            // this is to speedup spelleffect lookups
            foreach (var value in DBC.SpellEffect)
            {
                if (DBC.SpellEffects.ContainsKey(value.Value.EffectSpellId))
                {
                    DBC.SpellEffects[value.Value.EffectSpellId].Add((int)value.Value.EffectIndex, value.Value);
                }
                else
                {
                    Dictionary<int, SpellEffectEntry> temp = new Dictionary<int, SpellEffectEntry>(3);
                    DBC.SpellEffects.Add(value.Value.EffectSpellId, temp);
                    DBC.SpellEffects[value.Value.EffectSpellId].Add((int)value.Value.EffectIndex, value.Value);
                }
            }

            DBC.SpellTargetRestrictions     = DBCReader.ReadDBC<SpellTargetRestrictionsEntry>(null);
            DBC.SpellAuraRestrictions       = DBCReader.ReadDBC<SpellAuraRestrictionsEntry>(null);
            DBC.SpellCooldowns              = DBCReader.ReadDBC<SpellCooldownsEntry>(null);
            DBC.SpellCategories             = DBCReader.ReadDBC<SpellCategoriesEntry>(null);
            DBC.SpellShapeshift             = DBCReader.ReadDBC<SpellShapeshiftEntry>(null);
            DBC.SpellAuraOptions            = DBCReader.ReadDBC<SpellAuraOptionsEntry>(null);
            DBC.SpellLevels                 = DBCReader.ReadDBC<SpellLevelsEntry>(null);
            DBC.SpellClassOptions           = DBCReader.ReadDBC<SpellClassOptionsEntry>(null);
            DBC.SpellCastingRequirements    = DBCReader.ReadDBC<SpellCastingRequirementsEntry>(null);
            DBC.SpellPower                  = DBCReader.ReadDBC<SpellPowerEntry>(null);
            DBC.SpellInterrupts             = DBCReader.ReadDBC<SpellInterruptsEntry>(null);
            DBC.SpellEquippedItems          = DBCReader.ReadDBC<SpellEquippedItemsEntry>(null);
            DBC.SpellDuration               = DBCReader.ReadDBC<SpellDurationEntry>(null);
            DBC.SkillLineAbility            = DBCReader.ReadDBC<SkillLineAbilityEntry>(null);
            DBC.SpellRadius                 = DBCReader.ReadDBC<SpellRadiusEntry>(null);
            DBC.SpellCastTimes              = DBCReader.ReadDBC<SpellCastTimesEntry>(null);

            DBC.OverrideSpellData           = DBCReader.ReadDBC<OverrideSpellDataEntry>(null);
            DBC.SkillLine                   = DBCReader.ReadDBC<SkillLineEntry>(DBC.SkillLineStrings);
            DBC.SpellRange                  = DBCReader.ReadDBC<SpellRangeEntry>(DBC.SpellRangeStrings);
            DBC.ScreenEffect                = DBCReader.ReadDBC<ScreenEffectEntry>(DBC.ScreenEffectStrings);

            DBC.Locale = DetectedLocale();
        }

        private LocalesDBC DetectedLocale()
        {
            byte locale = 0;
            while (DBC.Spell[DBC.SPELL_ENTRY_FOR_DETECT_LOCALE].GetName(locale) == string.Empty)
            {
                ++locale;

                if (locale >= DBC.MAX_DBC_LOCALE)
                    throw new Exception("Detected unknown locale index " + locale);
            }
            return (LocalesDBC)locale;
        }
    }
}
