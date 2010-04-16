using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SpellWork
{
    class SpellInfo
    {
        public static void View(RichTextBox rtb, uint spellId)
        {
            rtb.Clear();
            var spell = (from s in DBC.Spell where s.Key == spellId select s.Value).First();

            rtb.AppendText(
                String.Format("Spell Name: {0} ({1})\r\nDescription: {2}\r\nTool Tip: {3}", spell.SpellName, spell.Rank, spell.Descriprion, spell.ToolTip));
            rtb.AppendText("\r\n========================================================================\r\n");
            rtb.AppendText(
                String.Format("Attributes 0x{0:X8},  Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                     spell.Attributes, spell.AttributesEx, spell.AttributesEx2, spell.AttributesEx3, spell.AttributesEx4,
                     spell.AttributesEx5, spell.AttributesEx6, spell.AttributesExG));
            rtb.AppendText(String.Format("\r\nProcFlags: 0x{0:X8}, ProcChance: {1:X8}, ProcCharges: {2:X8}", spell.procFlags, spell.procChance, spell.procCharges));
            rtb.AppendText(String.Format("\r\nSpellFamilyFlags: 0x{0:X8} {1:X8} {2:X8}", spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1));
            rtb.AppendText(ViewFlags(spell));
            rtb.AppendText(String.Format("{0} {1} {2} {3}\r\n",spell.PreventionType, spell.excludeCasterAuraSpell, spell.EquippedItemClass, spell.procChance));

            rtb.AppendText(SelectDuration(spell.DurationIndex));
            rtb.AppendText(SelectRange(spell.rangeIndex));

            rtb.AppendText(SelectSkillLineAbility(spell.ID));
        }

        static String ViewFlags(SpellEntry spell)
        {
            int COUNT = 3;

            var info = "\r\nSpellFamilyNames: " + (SpellFamilyNames)spell.SpellFamilyName;
            info += "\r\nSpellSchoolMask: " + (SpellSchoolMask)spell.SchoolMask;

            var mechnics = (Mechanics)spell.Mechanic;
            info += (mechnics == Mechanics.MECHANIC_NONE) ? "" 
                : String.Format("\r\nMechanics: {0}", mechnics);

            var DmgClass = (SpellDmgClass)spell.DmgClass;
            info += (DmgClass == SpellDmgClass.SPELL_DAMAGE_CLASS_NONE) ? "" 
                : String.Format("\r\nDamage Class: {0}", DmgClass);

            var PreventionType = (SpellPreventionType)spell.PreventionType;
            info += (PreventionType == SpellPreventionType.SPELL_PREVENTION_TYPE_NONE) ? "" 
                : String.Format("\r\nPrevention Type: {0}", PreventionType);

            for (int i = 0; i < COUNT; i++)
            {
                var spellAura = (AuraType)spell.EffectApplyAuraName[i];
                info += (spellAura == AuraType.SPELL_AURA_NONE) ? "" : String.Format("\r\nEffectApplyAuraName_{0}: {1}", i, spellAura);
            }

            for (int i = 0; i < COUNT; i++)
            {
                var effekt = (SpellEffects)spell.Effect[i];
                info += (effekt == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffect_{0}: {1}", i, effekt);
            }

            for (int i = 0; i < COUNT; i++)
            {
                var targetA = (SpellEffects)spell.EffectImplicitTargetA[i];
                info += (targetA == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffectImplicitTargetA_{0}: {1}", i, targetA);
            }

            for (int i = 0; i < COUNT; i++)
            {
                var targetB = (SpellEffects)spell.EffectImplicitTargetB[i];
                info += (targetB == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffectImplicitTargetB_{0}: {1}", i, targetB);
            }

            return (info == "") ? "" : info + "\r\n========================================================================\r\n";
        }

        static String SelectDuration(uint DurationIndex)
        {
            var query = from duration in DBC.SpellDuration where duration.Key == DurationIndex select duration;
            
            if (query.Count() == 0)
                return "";

            var q = query.First();
            return String.Format("Duration: ID {0}  {1}, {2}, {3}\r\n", q.Key, q.Value.Duration[0], q.Value.Duration[1], q.Value.Duration[2]);
        }

        static String SelectRange(uint RangeIndex)
        {
            var query = from rande in DBC.SpellRange where rande.Key == RangeIndex select rande;

            if (query.Count() == 0)
                return "";
            
            var q = query.First();
            return String.Format("SpellRange: ID - {0} {1} (unk = {2}) MinRange = {3}, MinRangeFriendly = {4}, MaxRange = {5}, MaxRangeFriendly = {6}\r\n",
                q.Key, q.Value.Description1, q.Value.Description2, q.Value.Field5, q.Value.MinRange,
                q.Value.MinRangeFriendly, q.Value.MaxRange, q.Value.MaxRangeFriendly);
        }

        static String SelectSkillLineAbility(uint entry)
        {
            var query =
               from skillLineAbility in DBC.SkillLineAbility
               join skillLine in DBC.SkillLine
               on skillLineAbility.Value.SkillId equals skillLine.Key
               where skillLineAbility.Value.SpellId == entry
               select new { skillLineAbility, skillLine };

            if (query.Count() == 0)
                return "";
            var str = "Skill Line Ability: ";
            foreach (var q in query)
            {
                str += String.Format("\r\n\t- ID: {0}, Name: {1}", q.skillLine.Value.ID, q.skillLine.Value.Name);
            }

            return str;
        }
    }
}
