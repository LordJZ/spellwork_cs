using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellWork
{
    class Loader
    {
        public static void Run()
        {
            Dictionary<uint, string> nullStringDict = null;

            DBC.Spell            = DBCReader.ReadDBC<SpellEntry>(DBC.DBC_PATH + "Spell.dbc", DBC._SpellStrings);
            DBC.SpellRadius      = DBCReader.ReadDBC<SpellRadiusEntry>(DBC.DBC_PATH + "SpellRadius.dbc", nullStringDict);
            DBC.SpellRange       = DBCReader.ReadDBC<SpellRangeEntry>(DBC.DBC_PATH + "SpellRange.dbc", DBC._SpellRangeStrings);
            DBC.SpellDuration    = DBCReader.ReadDBC<SpellDurationEntry>(DBC.DBC_PATH + "SpellDuration.dbc", nullStringDict);
            DBC.SkillLineAbility = DBCReader.ReadDBC<SkillLineAbilityEntry>(DBC.DBC_PATH + "SkillLineAbility.dbc", nullStringDict);
            DBC.SkillLine        = DBCReader.ReadDBC<SkillLineEntry>(DBC.DBC_PATH + "SkillLine.dbc", DBC._SkillLineStrings);
            DBC.SpellCastTimes   = DBCReader.ReadDBC<SpellCastTimesEntry>(DBC.DBC_PATH + "SpellCastTimes.dbc", nullStringDict);

            // Currently we use entry 1 from Spell.dbc to detect DBC locale
            byte DetectedLocale = 0;
            while (DBC.Spell[1].GetName(DetectedLocale) == "")
            {
                if (DetectedLocale >= DBC.MAX_DBC_LOCALE)// TODO: необходимо как-то сообщить пользователю о том, что ДБЦ у него неправильные
                    throw new Exception("Detected unknown locale index " + DetectedLocale);
                ++DetectedLocale;
            }

            DBC.Locale = (LocalesDBC)DetectedLocale;
        }
    }
}
