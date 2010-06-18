using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpellWork
{
    class Loader
    {
        public Loader(bool thread)
        {
            DBC.Spell = DBCReader.ReadDBC<SpellEntry>(DBC.SpellStrings);
            
            if (thread)
                new Thread(RunOther).Start();
            else
                RunOther();
            
            DBC.Locale = DetectedLocale;
        }

        private void RunOther()
        {
            DBC.SkillLine        = DBCReader.ReadDBC<SkillLineEntry>(DBC.SkillLineStrings);
            DBC.SpellRange       = DBCReader.ReadDBC<SpellRangeEntry>(DBC.SpellRangeStrings);
            DBC.ScreenEffect     = DBCReader.ReadDBC<ScreenEffectEntry>(DBC.ScreenEffectStrings);
            
            DBC.SpellDuration    = DBCReader.ReadDBC<SpellDurationEntry>(null);
            DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(null);
            DBC.SpellRadius      = DBCReader.ReadDBC<SpellRadiusEntry>(null);
            DBC.SpellCastTimes   = DBCReader.ReadDBC<SpellCastTimesEntry>(null);

            DBC.OverrideSpellData = DBCReader.ReadDBC<OverrideSpellDataEntry>(null);
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
                        throw new SpellWorkException("Detected unknown locale index {0}", locale);
                }
                return (LocalesDBC)locale;
            }
        }
    }
}
