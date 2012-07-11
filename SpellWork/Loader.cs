using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            LoadDBC(out DBC.Spell);
            LoadDBC(out DBC.SpellEffect);

            // this is to speedup spelleffect lookups
            foreach (SpellEffectEntry value in DBC.SpellEffect)
            {
                if (DBC.SpellEffects.ContainsKey(value.EffectSpellId))
                {
                    DBC.SpellEffects[value.EffectSpellId].Add(value.EffectIndex, value);
                }
                else
                {
                    Dictionary<uint, SpellEffectEntry> temp = new Dictionary<uint, SpellEffectEntry>(3);
                    DBC.SpellEffects.Add(value.EffectSpellId, temp);
                    DBC.SpellEffects[value.EffectSpellId].Add(value.EffectIndex, value);
                }
            }
            LoadDBC(out DBC.SpellTargetRestrictions);
            LoadDBC(out DBC.SpellAuraRestrictions);
            LoadDBC(out DBC.SpellCooldowns);
            LoadDBC(out DBC.SpellCategories);
            LoadDBC(out DBC.SpellShapeshift);
            LoadDBC(out DBC.SpellAuraOptions);
            LoadDBC(out DBC.SpellLevels);
            LoadDBC(out DBC.SpellClassOptions);
            LoadDBC(out DBC.SpellCastingRequirements);
            LoadDBC(out DBC.SpellPower);
            LoadDBC(out DBC.SpellInterrupts);
            LoadDBC(out DBC.SpellEquippedItems);
            LoadDBC(out DBC.SpellDuration);
            LoadDBC(out DBC.SkillLineAbility);
            LoadDBC(out DBC.SpellRadius);
            LoadDBC(out DBC.SpellCastTimes);
            LoadDBC(out DBC.SpellDifficulty);
            LoadDBC(out DBC.CurrencyTypes);
            LoadDBC(out DBC.OverrideSpellData);
            LoadDBC(out DBC.SkillLine);
            LoadDBC(out DBC.SpellRange);
            LoadDBC(out DBC.SpellReagents);
            LoadDBC(out DBC.ScreenEffect);

            DBC.Locale = DetectLocale;
        }

        private LocalesDBC DetectLocale
        {
            get
            {
                /*byte locale = 0;
                while (DBC.Spell[DBC.SPELL_ENTRY_FOR_DETECT_LOCALE].SpellName == string.Empty)
                {
                    ++locale;

                    if (locale >= DBC.MAX_DBC_LOCALE)
                        throw new Exception("Detected unknown locale index " + locale);
                }
                return (LocalesDBC)locale;*/
                return LocalesDBC.ruRU;
            }
        }
    }
}
