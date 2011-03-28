using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpellWork
{
    class Loader
    {
        public Loader()
        {
            DBC.OverrideSpellData   = DBCReader.ReadDBC<OverrideSpellDataEntry>(null);
            DBC.ScreenEffect        = DBCReader.ReadDBC<ScreenEffectEntry>(DBC.ScreenEffectStrings);
            DBC.SkillLine           = DBCReader.ReadDBC<SkillLineEntry>(DBC.SkillLineStrings);
            DBC.SkillLineAbility    = DBCReader.ReadDBC<SkillLineAbilityEntry>(null);
            DBC.Spell               = DBCReader.ReadDBC<SpellEntry>(DBC.SpellStrings);
            DBC.SpellCastTimes      = DBCReader.ReadDBC<SpellCastTimesEntry>(null);
            DBC.SpellDifficulty     = DBCReader.ReadDBC<SpellDifficultyEntry>(null);
            DBC.SpellDuration       = DBCReader.ReadDBC<SpellDurationEntry>(null);
            DBC.SpellRadius         = DBCReader.ReadDBC<SpellRadiusEntry>(null);
            DBC.SpellRange          = DBCReader.ReadDBC<SpellRangeEntry>(DBC.SpellRangeStrings);


            DBC.Locale = DetectedLocale;
        }

        private LocalesDBC DetectedLocale
        {
            get
            {
                byte locale = 0;
                while (DBC.Spell[DBC.SPELL_ENTRY_FOR_DETECT_LOCALE].GetName(locale) == String.Empty)
                {
                    ++locale;

                    if (locale >= DBC.MAX_DBC_LOCALE)
                        throw new Exception("Detected unknown locale index " + locale);
                }
                return (LocalesDBC)locale;
            }
        }
    }
}
