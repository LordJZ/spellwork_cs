using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpellWork
{
    class Loader
    {
        static Dictionary<uint, string> nullStringDict = null;

        public Loader(bool thread)
        {
            DBC.Spell = DBCReader.ReadDBC<SpellEntry>(DBC._SpellStrings);
            
            if (thread)
                new Thread(RunOther).Start();
            else
                RunOther();
            
            DBC.Locale = DetectedLocale;
        }

        private void RunOther()
        {
            DBC.SpellRadius      = DBCReader.ReadDBC<SpellRadiusEntry>(nullStringDict);
            DBC.SpellRange       = DBCReader.ReadDBC<SpellRangeEntry>(DBC._SpellRangeStrings);
            DBC.SpellDuration    = DBCReader.ReadDBC<SpellDurationEntry>(nullStringDict);
            DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(nullStringDict);
            DBC.SkillLine        = DBCReader.ReadDBC<SkillLineEntry>(DBC._SkillLineStrings);
            DBC.SpellCastTimes   = DBCReader.ReadDBC<SpellCastTimesEntry>(nullStringDict);
        }

        private LocalesDBC DetectedLocale
        {
            get
            {
                byte locale = 0;
                while (DBC.Spell[1].GetName(locale) == String.Empty)
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
