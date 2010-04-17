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
            rtb.AppendText(GenerateSpellDesc(spell));
        }

        public static void BuildFamilyTree(TreeView familyTree, SpellFamilyNames spellfamily)
        {
            familyTree.Nodes.Clear();
            var spells = from Spell in DBC.Spell
                         where Spell.Value.SpellFamilyName == (uint)spellfamily
                         join sk in DBC.SkillLineAbility on Spell.Key equals sk.Value.SpellId into temp
                         from Skill in temp.DefaultIfEmpty()
                         select new 
                         { 
                             Spell, 
                             SkillId = (Skill.Value.SkillId)
                         };

            for (int i = 0; i < 96; i++)
            {
                uint mask_0 = 0, mask_1 = 0, mask_2 = 0;

                if (i < 32)
                    mask_0 = 1U << i;
                else if (i < 64)
                    mask_1 = 1U << (i - 32);
                else
                    mask_2 = 1U << (i - 64);

                TreeNode node = new TreeNode();
                node.Text = String.Format("0x{0:X8} {1:X8} {2:X8}", mask_2, mask_1, mask_0);
 
                familyTree.Nodes.Add(node);
            }

            foreach (var elem in spells)
            {
                var spell = elem.Spell.Value;
                string name = elem.SkillId != 0
                ? String.Format("+({0}) {1} ({2})_({3}, {4})", 
                    spell.ID, spell.SpellName, spell.Rank, elem.SkillId, (SpellSchools)spell.SchoolMask)
                : String.Format("-({0}) {1} ({2})_({3})", spell.ID, spell.SpellName, spell.Rank, (SpellSchools)spell.SchoolMask);

                int i = 0;
                foreach(TreeNode node in familyTree.Nodes) 
                {
                    uint mask_1 = 0, mask_2 = 0, mask_3 = 0;

                    if (i < 32)
                        mask_1 = 1U << i;
                    else if (i < 64)
                        mask_2 = 1U << (i - 32);
                    else
                        mask_3 = 1U << (i - 64);

                    if ((spell.SpellFamilyFlags1 & mask_1) != 0
                        || (spell.SpellFamilyFlags2 & mask_1) != 0
                        || (spell.SpellFamilyFlags3 & mask_3) != 0)
                    {
                        TreeNode child = new TreeNode();
                        child = node.Nodes.Add(name);
                        child.Name = spell.ID.ToString();
                    }
                    i++;
                }
            }
        }
        
        static String GetDuration(uint DurationIndex)
        {
            var query = from duration in DBC.SpellDuration where duration.Key == DurationIndex select duration;
            
            if (query.Count() == 0)
                return "";

            var q = query.First().Value;
            return String.Format("Duration: ID {0}  {1}, {2}, {3}\r\n", q.ID, q.Duration[0], q.Duration[1], q.Duration[2]);
        }

        static String GetRange(uint RangeIndex)
        {
            var query = from rande in DBC.SpellRange where rande.Key == RangeIndex select rande;

            if (query.Count() == 0)
                return "";
            
            var q = query.First();
            return String.Format("SpellRange: ID - {0} {1} (unk = {2}) MinRange = {3}, MinRangeFriendly = {4}, MaxRange = {5}, MaxRangeFriendly = {6}\r\n",
                q.Key, q.Value.Description1, q.Value.Description2, q.Value.Field5, q.Value.MinRange,
                q.Value.MinRangeFriendly, q.Value.MaxRange, q.Value.MaxRangeFriendly);
        }

        static String GetSkillLineAbility(uint entry)
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

        static String GetSpellAura(SpellEntry spell)
        {
            var str = "";
            // Для того чтобы не нагружать поцессор лишним запросом,просто сделаем проверку на входной параметр,
            // если он не != 0, тогда ищем, иначе нет смысла
            if (spell.casterAuraSpell != 0)
            {
                var query = from ss in DBC.Spell where ss.Key == spell.casterAuraSpell select ss;
                if (query.Count() > 0)
                {
                    var s = query.First().Value;
                    if (s.ID > 0)
                        str += String.Format("  Caster Aura Spell ({0}) {1}\r\n", spell.casterAuraSpell, s.SpellName);
                    else
                        str += String.Format("  Caster Aura Spell ({0}) ?????\r\n", spell.casterAuraSpell);
                }
            }

            if (spell.targetAuraSpell != 0)
            {
                var query2 = from ss in DBC.Spell where ss.Key == spell.targetAuraSpell select ss;
                if (query2.Count() > 0)
                {
                    var s = query2.First().Value;
                    str += String.Format("  Target Aura Spell ({0}) {1}\r\n", spell.targetAuraSpell, s.SpellName);
                }
            }

            if (spell.excludeCasterAuraSpell != 0)
            {
                var query3 = from ss in DBC.Spell where ss.Key == spell.excludeCasterAuraSpell select ss;
                if (query3.Count() > 0)
                {
                    var s = query3.First().Value;
                    if (s.ID != 0)
                        str += String.Format("  Ex Caster Aura Spell ({0}) {1}\r\n", spell.excludeCasterAuraSpell, s.SpellName);
                    else
                        str += String.Format("  Ex Caster Aura Spell ({0})\r\n", spell.excludeCasterAuraSpell);
                }
            }

            if (spell.excludeTargetAuraSpell != 0)
            {
                var query4 = from asp in DBC.Spell where asp.Key == spell.excludeTargetAuraSpell select asp;
                if (query4.Count() > 0)
                    str += String.Format("  Ex Target Aura Spell ({0}) {1}\r\n", spell.excludeTargetAuraSpell,
                        query4.First().Value.SpellName);
                else
                    str += String.Format("  Ex Target Aura Spell ({0})\r\n", spell.excludeTargetAuraSpell);
            }

            return str;
        }

        static String GenerateSpellDesc(SpellEntry spell)
        {
            var str = "";

            str += String.Format("ID - {0} {1} ({2})\r\n", spell.ID, spell.SpellName, spell.Rank);

            if (spell.Descriprion != null)
                str += String.Format("=================================================\r\n{0}\r\n", spell.Descriprion);
            if (spell.ToolTip != null)
                str += String.Format("ToolTip: {0}\r\n", spell.ToolTip);
            if (spell.modalNextSpell != 0)
                str += String.Format("Modal Next Spell: %d\r\n", spell.modalNextSpell);
            str += String.Format("=================================================\r\n");

            str += String.Format("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual_0 = {3}, SpellVisual_1 = {4}\r\n",
                spell.Category, spell.SpellIconID, spell.activeIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            str += String.Format("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}\r\n",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1);

            str += String.Format("SpellSchoolMask = {0}, DamageClass = {1}, PreventionType = {2}\r\n", (SpellSchoolMask)spell.SchoolMask,
                (SpellDmgClass)spell.DmgClass, (SpellPreventionType)spell.PreventionType);

            if (spell.Targets != 0 || spell.TargetCreatureType != 0)
                str += String.Format("Targets 0x%08X, Creature Type 0x%08X\r\n", spell.Targets, spell.TargetCreatureType);

            //if (spell.Stances!=0) str+=addFormInfo(str,spell.Stances);

            //if (spell.StancesNot) str=addFormInfo(str,spell.StancesNot);

            //if (SkillLine)
            //{
            // const SkillLineEntry *line = sSkillLineStore.LookupEntry(SkillLine->skillId);
            // str+=String.Format("Skill (%d)",SkillLine->skillId);
            // if (line) str+=String.Format(" %s",line->name);
            // if (SkillLine->req_skill_value>1) str+=String.Format(", Req skill value %d",SkillLine->req_skill_value);
            // if (SkillLine->forward_spellid) str+=String.Format(", Forward spell %d",SkillLine->forward_spellid);
            // if (SkillLine->min_value) str+=String.Format(", Min Value %d",SkillLine->min_value);
            // if (SkillLine->max_value) str+=String.Format(", Max Value %d",SkillLine->max_value);
            // if (SkillLine->characterPoints[0]) str+=String.Format(", Req characterPoints_0 %d",SkillLine->characterPoints[0]);
            // if (SkillLine->characterPoints[1]) str+=String.Format(", Req characterPoints_1 %d",SkillLine->characterPoints[1]);
            // str+=String.Format("\r\n");
            //}

            if (spell.spellLevel != 0)
                str += String.Format("Spell level = {0}", spell.spellLevel);
            if (spell.baseLevel != 0)
                str += String.Format(", base {0}", spell.baseLevel);
            if (spell.maxLevel != 0)
                str += String.Format(", max {0}", spell.maxLevel);
            if (spell.MaxTargetLevel != 0)
                str += String.Format(", maxTargetLevel {0}", spell.MaxTargetLevel);

            str += "\r\n";

            if (spell.EquippedItemClass != -1)
                str += String.Format("EquippedItemClass {0}", spell.EquippedItemClass);
            if (spell.EquippedItemSubClassMask != 0)
                str += String.Format(" Sub class mask 0x{0:X8}", spell.EquippedItemSubClassMask);
            if (spell.EquippedItemInventoryTypeMask != 0)
                str += String.Format(" Inventory mask 0x{0:X8}", spell.EquippedItemInventoryTypeMask);

            if (spell.Category != 0)
                str += String.Format("Category - {0}\r\n", spell.Category);
            if (spell.Dispel != 0)
                str += String.Format("Dispel - {0}\r\n", spell.Dispel);
            if (spell.Mechanic != 0)
                str += String.Format("Mechanic - {0} - {1}\r\n", spell.Mechanic, (Mechanics)spell.Mechanic);
            
            //if (range && (range.minRange || range.maxRange))
            //    str += String.Format("Range {0:F} - {1:F} yards\r\n", range.minRange, range.maxRange);

            if (spell.speed != 0)
                str += String.Format("Speed {0:F}\r\n", spell.speed);

            str += String.Format("Attributes 0x{0:X8},  Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}\r\n",
                     spell.Attributes, spell.AttributesEx, spell.AttributesEx2, spell.AttributesEx3, spell.AttributesEx4,
                     spell.AttributesEx5, spell.AttributesEx6, spell.AttributesExG);

            if (spell.StackAmount != 0)
                str += String.Format("Stackable up to {0}\r\n", spell.StackAmount);

            //if (castTime)
            //{
            //    if (castTime->CastTime)
            //        str+=String.Format("CastingTime = %02.2f\r\n", float(castTime->CastTime/1000.0f));
            //}
            //else          str+=String.Format("CastingTime({0}) = ????\r\n",spell.CastingTimeIndex);

            if (spell.RecoveryTime!=0 || spell.CategoryRecoveryTime!=0 || spell.StartRecoveryCategory!=0)
            {
                str += String.Format("Recovery time {0}, Category Recovery time {1}, ", spell.RecoveryTime / 1000, spell.CategoryRecoveryTime / 1000);
                str += String.Format("Start Recovery Category = {0}, Start Recovery Time = {1:F}\r\n", spell.StartRecoveryCategory, spell.StartRecoveryTime / 1000.0f);
            }

            str += GetDuration(spell.DurationIndex);

            if (spell.manaCost!=0 || spell.ManaCostPercentage!=0)
            {
                str += String.Format("Power {0}, Cost {1}", (Powers)spell.powerType, spell.manaCost);

                if (spell.manaCostPerlevel != 0)
                    str += String.Format(" + lvl*{0}", spell.manaCostPerlevel);
                if (spell.manaPerSecond != 0)
                    str += String.Format(" + Per Second {0}", spell.manaPerSecond);
                if (spell.manaPerSecondPerLevel != 0)
                    str += String.Format(" + lvl*{0}", spell.manaPerSecondPerLevel);
                if (spell.ManaCostPercentage != 0)
                    str += String.Format(" + PCT {0}", spell.ManaCostPercentage);
                
                str+=String.Format(" \r\n");
            }
            str += String.Format("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}\r\n",
                spell.InterruptFlags, spell.AuraInterruptFlags, spell.ChannelInterruptFlags);

            if (spell.CasterAuraState != 0 || spell.TargetAuraState != 0)
                str += String.Format("CasterAuraState 0x{0:X8}, TargetAuraState 0x{1:X8}\r\n", spell.CasterAuraState, spell.TargetAuraState);
            if (spell.CasterAuraStateNot != 0 || spell.TargetAuraStateNot != 0)
                str += String.Format("CasterAuraStateNot 0x{0:X8}, TargetAuraStateNot 0x{1:X8}\r\n", spell.CasterAuraStateNot, spell.TargetAuraStateNot);

            str += GetSpellAura(spell);

            if (spell.RequiresSpellFocus!=0)
                str+=String.Format("Requires Spell Focus {0}\r\n", spell.RequiresSpellFocus);

            if (spell.procFlags!=0)
            {
                str+=String.Format("Proc flag 0x{0:X8}, chance = {1}, charges - {2}\r\n", 
                spell.procFlags, spell.procChance, spell.procCharges);
             //str+=String.Format("=================================================\r\n");
             //str = addProcInfo(str, spell.procFlags);
             //str+=String.Format("=================================================\r\n");
            }
            else // if(spell.procCharges)
            {
                str+=String.Format("Chance = {0}, charges - {1}\r\n", spell.procChance, spell.procCharges);
            }
            //str = addEffectInfo(str,spell,0);
            //str = addEffectInfo(str,spell,1);
            //str = addEffectInfo(str,spell,2);

            //str = addItemsInfo(str, spell);
            return str;
        }
    
        
    }
}
