using System;
using System.IO;
using DBFilesClient.NET;

namespace SpellWork
{
    class Loader
    {
        void LoadDBC<T>(out DBCStorage<T> dbc) where T : class, new()
        {
            var name = typeof(T).Name;
            name = name.Substring(0, name.Length - "Entry".Length);

            var tmp = new DBCStorage<T>();
            var bytes = File.ReadAllBytes(Path.Combine(DBC.DBC_PATH, name + ".dbc"));
            using (var ms = new MemoryStream(bytes))
                tmp.Load(ms);
            dbc = tmp;
        }

        public Loader()
        {
            LoadDBC(out DBC.AreaGroup);
            LoadDBC(out DBC.AreaTable);
            LoadDBC(out DBC.Spell);
            LoadDBC(out DBC.SkillLine);
            LoadDBC(out DBC.SpellRange);
            LoadDBC(out DBC.ScreenEffect);

            LoadDBC(out DBC.SpellDuration);
            LoadDBC(out DBC.SkillLineAbility);
            LoadDBC(out DBC.SpellRadius);
            LoadDBC(out DBC.SpellCastTimes);
            LoadDBC(out DBC.SpellDifficulty);

            LoadDBC(out DBC.OverrideSpellData);
            LoadDBC(out DBC.SpellRuneCost);

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
