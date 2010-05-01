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

        public static void Run()
        {
            DBC.Spell = DBCReader.ReadDBC<SpellEntry>(DBC._SpellStrings);

            new Thread(RunOther).Start();
            
            // Currently we use entry 1 from Spell.dbc to detect DBC locale
            byte DetectedLocale = 0;
            while (DBC.Spell[1].GetName(DetectedLocale) == "")
            {
                ++DetectedLocale;
                if (DetectedLocale >= DBC.MAX_DBC_LOCALE)
                    throw new SpellWorkException("Detected unknown locale index {0}", DetectedLocale);
            }

            DBC.Locale = (LocalesDBC)DetectedLocale;
        }

        static void RunOther()
        {
            DBC.SpellRadius      = DBCReader.ReadDBC<SpellRadiusEntry>(nullStringDict);
            DBC.SpellRange       = DBCReader.ReadDBC<SpellRangeEntry>(DBC._SpellRangeStrings);
            DBC.SpellDuration    = DBCReader.ReadDBC<SpellDurationEntry>(nullStringDict);
            DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(nullStringDict);
            DBC.SkillLine        = DBCReader.ReadDBC<SkillLineEntry>(DBC._SkillLineStrings);
            DBC.SpellCastTimes   = DBCReader.ReadDBC<SpellCastTimesEntry>(nullStringDict);
        }
    }
}
