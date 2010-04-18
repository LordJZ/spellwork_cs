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
            SpellEntry spell = DBC.Spell[spellId];
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
                             Skill.Value.SkillId
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
                ? String.Format("+({0}) {1} ({2}) (Sk{3}) ({4})", spell.ID, spell.SpellName, spell.Rank, elem.SkillId, GetSchool(spell))
                : String.Format("-({0}) {1} ({2}) ({3})",      spell.ID, spell.SpellName, spell.Rank, GetSchool(spell));

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

                    if ((spell.SpellFamilyFlags1 & mask_1) != 0 ||
                        (spell.SpellFamilyFlags2 & mask_1) != 0 ||
                        (spell.SpellFamilyFlags3 & mask_3) != 0)
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
                return String.Empty;

            var q = query.First().Value;
            return String.Format("Duration: (Id {0}) {1}, {2}, {3}\r\n", q.ID, q.Duration[0], q.Duration[1], q.Duration[2]);
        }

        static String GetRange(uint index)
        {
            if (index == 0)
                return String.Empty;

            var query = from rande in DBC.SpellRange where rande.Key == index select rande;

            if (query.Count() == 0)
                return String.Empty;

            var q = query.First();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\"",                  q.Key, q.Value.Description1);
            sb.AppendFormatLine("    MinRange = {0}, MinRangeFriendly = {1}",     q.Value.MinRange, q.Value.MinRangeFriendly);
            sb.AppendFormatLine("    MaxRange = {0}, MaxRangeFriendly = {1}",     q.Value.MaxRange, q.Value.MaxRangeFriendly);
            
            return sb.ToString();
        }

        static String GetCastTime(SpellEntry spell)
        {
            if (spell.CastingTimeIndex == 0) 
                return String.Empty;

            var query = from t in DBC.SpellCastTimes where t.Key == spell.CastingTimeIndex select t.Value;

            if(query.Count() == 0)
            {
                return String.Format("CastingTime (Id {0}) = ????\r\n", spell.CastingTimeIndex);
            }
            else
            {
                return String.Format("CastingTime (Id {0}) = {1:F}\r\n", spell.CastingTimeIndex,
                    query.First().CastTime / 1000.0f);
            }
        }

        static String GetSkillLine(uint entry)
        {
            var query =
               from skillLineAbility in DBC.SkillLineAbility
               join skillLine in DBC.SkillLine
               on skillLineAbility.Value.SkillId equals skillLine.Key
               where skillLineAbility.Value.SpellId == entry
               select new { skillLineAbility, skillLine };

            if (query.Count() == 0)
                return String.Empty;

            var skill = query.First().skillLineAbility.Value;
            var line =  query.First().skillLine.Value;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormatLine("Skill (Id {0}) \"{1}\"", skill.SkillId, line.Name);
            sb.AppendFormat    ("    ReqSkillValue {0}", skill.Req_skill_value);

            sb.AppendFormat(", Forward Spell = {0}, MinMaxValue ({1}, {2})", skill.Forward_spellid, skill.Min_value, skill.Max_value);
            sb.AppendFormat(", CharacterPoints ({0}, {1})", skill.characterPoints[0], skill.characterPoints[1]);

            return sb.ToString();
        }

        static string GetSchool(SpellEntry spell)
        {
            List<string> mask = new List<string>();
            foreach (var a in Enum.GetValues(typeof(SpellSchools)))
            {
                //MessageBox.Show(Enum.GetName(typeof(SpellSchools), a));
                if ((spell.SchoolMask & (1 << (int)a)) != 0)
                    mask.Add(Enum.GetName(typeof(SpellSchools), a));
            }
            return String.Join("|", mask.ToArray());
        }

        static String GetProcInfo(SpellEntry spell)
        {
            int i = 0;
            string str = "";
            var proc = spell.procFlags;
            while (proc != 0)
            {
                if ((proc & 1) != 0)
                    str += String.Format("  {0}\r\n", SpellEnums.ProcFlagDesc[i]);
                i++;
                proc >>= 1;
            }
            return str;
        }

        static String GetFormInfo(ulong val, string name)
        {
            if (val == 0)
                return String.Empty;

            int i = 1;
            while (val != 0)
            {
                if ((val & 1) != 0)
                    name += String.Format("{0} ", (ShapeshiftForm)i);
                i++;
                val >>= 1;
            }
            return name;
        }

        static String GetItemInfo(SpellEntry spell)
        {
            // Получить из базы данных ()
            // SELECT `entry`, `name` FROM `item_template` WHERE `spellid_1` = {0} OR `spellid_2` = {1} OR `spellid_3` = {2}
            //      OR `spellid_4` = {3} OR `spellid_5` = {4}
            return "";
        }

        static String GetAuraModTypeName(uint id, int mod)
        {
            if (id == 107 || id == 108 || mod < 29)
                return "" + (SpellModOp)mod;
            return "" + mod;
        }

        static String GetRadius(SpellEntry spell, int index)
        {
            if (spell.EffectRadiusIndex[index] != 0)
            {
                var query = from r in DBC.SpellRadius where r.Key == spell.EffectRadiusIndex[index] select r.Value.Radius;


                if (query.Count() > 0)
                    return String.Format("Radius (Id {0}) {0:F}\r\n", spell.EffectRadiusIndex[index], query.First());
                else
                    return String.Format("Radius (Id {0}) Not found\r\n", spell.EffectRadiusIndex[index]);
            }
            return "";
        }

        static String GetTriggerSpell(SpellEntry spell, int index)
        {
            StringBuilder sb = new StringBuilder();
            if (spell.EffectTriggerSpell[index] != 0)
            {
                var query = from tr in DBC.Spell where spell.ID == spell.EffectTriggerSpell[index] select tr;

                if (query.Count() > 0)
                {
                    var trigger = query.First().Value;
                    sb.AppendFormatLine("Trigger spell ({0}) {1}. Chance = {2}", spell.EffectTriggerSpell[index],
                        trigger.SpellName, spell.procChance);

                    if (trigger.Description != "")
                        sb.AppendLine(trigger.Description);
                    if (trigger.ToolTip != "")
                        sb.AppendLine(trigger.ToolTip);

                    if (trigger.procFlags != 0)
                    {
                        sb.AppendFormat("Charges - {0}  =======================================\r\n", trigger.procCharges);
                        sb.Append(GetProcInfo(trigger));
                        sb.AppendFormat("=================================================\r\n");
                    }
                }
                else
                {
                    sb.AppendFormat("Trigger spell ({0}) Not found, Chance = {0}\r\n",
                        spell.EffectTriggerSpell[index], spell.procChance);
                }
            }

            return sb.ToString();
        }

        static String GetSpellEffectInfo(SpellEntry spell)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine();
            sb.AppendLine("______________________________________________________________________________");

            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine();

                if ((SpellEffects)spell.Effect[i] == SpellEffects.NO_SPELL_EFFECT)
                {
                    sb.AppendFormatLine("Effect {0}: NO EFFECT", i);
                    return sb.ToString();
                }

                sb.AppendFormatLine("Effect {0}: {1}", i, (SpellEffects)spell.Effect[i]);

                sb.AppendFormat("BasePoints = {0}", spell.EffectBasePoints[i] + 1);
                if (spell.EffectRealPointsPerLevel[i] != 0)
                    sb.AppendFormat(" + Level * {0:F}", spell.EffectRealPointsPerLevel[i]);

                // WTF ?
                if (/*spell.EffectBaseDice[i]*/1 < spell.EffectDieSides[i])
                {
                    if (spell.EffectRealPointsPerLevel[i] != 0)
                        sb.AppendFormat(" to {0} + lvl * {1:F}",
                            spell.EffectBasePoints[i] + /*spell.EffectBaseDice[i]*/ 1 + spell.EffectDieSides[i], spell.EffectRealPointsPerLevel[i]);
                    else
                        sb.AppendFormat(" to {0}", spell.EffectBasePoints[i] +/*+ spell.EffectBaseDice[i]*/ 1 + spell.EffectDieSides[i]);
                }

                sb.AppendFormatIfNotNull(" + combo * {0:F}",    spell.EffectPointsPerComboPoint[i]);

                if (spell.DmgMultiplier[i] != 1.0f)
                    sb.AppendFormat(" x {0:F}", spell.DmgMultiplier[i]);

                sb.AppendFormatIfNotNull("  Multiple = {0:F}",  spell.EffectMultipleValue[i]);
                sb.AppendLine();

                sb.AppendFormatLine("Targets ({0},{1}) ({2},{3}),",
                    spell.EffectImplicitTargetA[i], spell.EffectImplicitTargetB[i],
                    (Targets)spell.EffectImplicitTargetA[i], (Targets)spell.EffectImplicitTargetB[i]);

                if (spell.EffectApplyAuraName[i] != 0)
                {
                    sb.AppendFormatLine("\r\nAura {0}, value = {1}, misc = {2}, miscB = {3}, periodic = {4}",
                        (AuraType)spell.EffectApplyAuraName[i],
                        spell.EffectBasePoints[i] + 1, GetAuraModTypeName(spell.EffectApplyAuraName[i], spell.EffectMiscValue[i]),
                        spell.EffectMiscValueB[i], spell.EffectAmplitude[i]);
                }
                else
                {
                    sb.AppendFormatLineIfNotNull("EffectMiscValueA = {0}",  spell.EffectMiscValue[i]);
                    sb.AppendFormatLineIfNotNull("EffectMiscValueB = {0}", spell.EffectMiscValueB[i]);
                    sb.AppendFormatLineIfNotNull("EffectAmplitude = {0}",  spell.EffectAmplitude[i]);
                }

                uint[] ClassMask = new uint[3];
                switch (i)
                {
                    case 0: ClassMask[0] = spell.EffectSpellClassMaskA[i]; break;
                    case 1: ClassMask[1] = spell.EffectSpellClassMaskB[i]; break;
                    case 2: ClassMask[2] = spell.EffectSpellClassMaskC[i]; break;
                }

                if (ClassMask[0] != 0 || ClassMask[1] != 0 || ClassMask[2] != 0)
                {
                    sb.AppendFormatLine("SpellClassMask = {0:X8} {1:X8} {2:X8}", ClassMask[2], ClassMask[1], ClassMask[0]);

                    uint mask_0 = ClassMask[0];
                    uint mask_1 = ClassMask[1];
                    uint mask_2 = ClassMask[2];

                    var query = from Spell in DBC.Spell
                                where Spell.Value.SpellFamilyName == spell.SpellFamilyName
                                join sk in DBC.SkillLineAbility on Spell.Key equals sk.Value.SpellId into temp
                                from Skill in temp.DefaultIfEmpty()
                                select new
                                {
                                    Spell,
                                    SkillId = (Skill.Value.SkillId)
                                };

                    foreach (var row in query)
                    {
                        var s = row.Spell.Value;
                        if ((s.SpellFamilyFlags1 & mask_0) != 0 ||
                            (s.SpellFamilyFlags2 & mask_1) != 0 ||
                            (s.SpellFamilyFlags3 & mask_2) != 0)
                        {
                            var exist = (row.SkillId > 0) ? "+" : "-";
                            var name = s.Rank == "" ? s.SpellName : s.SpellName + " (" + s.Rank + ")";
                            sb.AppendFormatLine("    {0} {1} - {2}", exist, s.ID, name);
                        }
                    }
                }

                sb.Append(GetRadius(spell, i));
                sb.Append(GetTriggerSpell(spell, i));

                sb.AppendFormatLineIfNotNull("EffectChainTarget = {0}", spell.EffectChainTarget[i]);
                sb.AppendFormatLineIfNotNull("EffectItemType = {0}",    spell.EffectItemType[i]);
                if((Mechanics)spell.EffectMechanic[i] != Mechanics.MECHANIC_NONE)
                    sb.AppendFormatLine("Effect Mechanic = {0} ({1})", spell.EffectMechanic[i], (Mechanics)spell.EffectMechanic[i]);
            }
            return sb.ToString();
        }

        static String GetSpellAura(SpellEntry spell)
        {
            // Для того чтобы не нагружать поцессор лишним запросом,просто сделаем проверку на входной параметр,
            // если он не != 0, тогда ищем, иначе нет смысла
            StringBuilder sb = new StringBuilder();
            if (spell.casterAuraSpell != 0)
            {
                var query = from ss in DBC.Spell where ss.Key == spell.casterAuraSpell select ss;
                if (query.Count() > 0)
                {
                    var s = query.First().Value;
                    if (s.ID > 0)
                        sb.AppendFormat("  Caster Aura Spell ({0}) {1}\r\n", spell.casterAuraSpell, s.SpellName);
                    else
                        sb.AppendFormat("  Caster Aura Spell ({0}) ?????\r\n", spell.casterAuraSpell);
                }
            }

            if (spell.targetAuraSpell != 0)
            {
                var query2 = from ss in DBC.Spell where ss.Key == spell.targetAuraSpell select ss;
                if (query2.Count() > 0)
                {
                    var s = query2.First().Value;
                    sb.AppendFormat("  Target Aura Spell ({0}) {1}\r\n", spell.targetAuraSpell, s.SpellName);
                }
            }

            if (spell.excludeCasterAuraSpell != 0)
            {
                var query3 = from ss in DBC.Spell where ss.Key == spell.excludeCasterAuraSpell select ss;
                if (query3.Count() > 0)
                {
                    var s = query3.First().Value;
                    if (s.ID != 0)
                        sb.AppendFormat("  Ex Caster Aura Spell ({0}) {1}\r\n", spell.excludeCasterAuraSpell, s.SpellName);
                    else
                        sb.AppendFormat("  Ex Caster Aura Spell ({0})\r\n", spell.excludeCasterAuraSpell);
                }
            }

            if (spell.excludeTargetAuraSpell != 0)
            {
                var query4 = from asp in DBC.Spell where asp.Key == spell.excludeTargetAuraSpell select asp;
                if (query4.Count() > 0)
                    sb.AppendFormat("  Ex Target Aura Spell ({0}) {1}\r\n", spell.excludeTargetAuraSpell,
                        query4.First().Value.SpellName);
                else
                    sb.AppendFormat("  Ex Target Aura Spell ({0})\r\n", spell.excludeTargetAuraSpell);
            }

            return sb.ToString();
        }

        static String GenerateSpellDesc(SpellEntry spell)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormatLine("ID - {0} {1} ({2})", spell.ID, spell.SpellName, spell.Rank);

            sb.AppendFormatLineIfNotNull("=================================================\r\nDescription: {0}", spell.Description);
            sb.AppendFormatLineIfNotNull("ToolTip: {0}", spell.ToolTip);
            sb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", spell.modalNextSpell);
            sb.AppendFormatLine("=================================================");

            sb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spell.Category, spell.SpellIconID, spell.activeIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            sb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1);

            sb.AppendLine();
            sb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, GetSchool(spell));
            sb.AppendFormatLine("DamageClass = {0} ({1})", spell.DmgClass, (SpellDmgClass)spell.DmgClass);
            sb.AppendFormatLine("PreventionType = {0} ({1})", spell.PreventionType, (SpellPreventionType)spell.PreventionType);
            sb.AppendLine();

            if (spell.Targets != 0 || spell.TargetCreatureType != 0)
                sb.AppendFormatLine("Targets = 0x{0:X8}, Creature Type = 0x{1:X8}", spell.Targets, spell.TargetCreatureType);

            if (spell.Stances != 0 || spell.StancesNot != 0)
            {
                sb.Append(GetFormInfo(spell.Stances, "Stances: "));
                sb.Append(GetFormInfo(spell.StancesNot, "Not Stances: "));
                sb.AppendLine();
            }

            sb.AppendLine(GetSkillLine(spell.ID));
            sb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}",
                spell.spellLevel, spell.baseLevel, spell.maxLevel, spell.MaxTargetLevel);

            if (spell.EquippedItemClass != -1)
            {
                sb.AppendFormat("EquippedItemClass {0}", spell.EquippedItemClass);
                sb.AppendFormatLineIfNotNull("    SubСlass mask 0x{0:X8}", spell.EquippedItemSubClassMask);
                sb.AppendFormatLineIfNotNull("    InventoryType mask 0x{0:X8}", spell.EquippedItemInventoryTypeMask);
            }

            sb.AppendLine();
            sb.AppendFormatLine("Category = {0}", spell.Category);
            sb.AppendFormatLine("DispelType = {0}",   spell.Dispel);
            sb.AppendFormatLine("Mechanic = {0} ({1})", spell.Mechanic, (Mechanics)spell.Mechanic);
            sb.AppendLine(GetRange(spell.rangeIndex));

            sb.AppendFormatLineIfNotNull("Speed {0:F}", spell.speed);

            sb.AppendFormatLine("Attributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                     spell.Attributes, spell.AttributesEx, spell.AttributesEx2, spell.AttributesEx3, spell.AttributesEx4,
                     spell.AttributesEx5, spell.AttributesEx6, spell.AttributesExG);

            sb.AppendFormatLineIfNotNull("Stackable up to {0}", spell.StackAmount);
            sb.Append(GetCastTime(spell));

            if (spell.RecoveryTime != 0 || spell.CategoryRecoveryTime != 0 || spell.StartRecoveryCategory != 0)
            {
                sb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", spell.RecoveryTime, spell.CategoryRecoveryTime);
                sb.AppendFormatLine("    StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", spell.StartRecoveryCategory, spell.StartRecoveryTime);
            }

            sb.AppendLine(GetDuration(spell.DurationIndex));

            if (spell.manaCost != 0 || spell.ManaCostPercentage != 0)
            {
                sb.AppendFormat("Power {0}, Cost {1}", (Powers)spell.powerType, spell.manaCost);
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.manaCostPerlevel);
                sb.AppendFormatIfNotNull(" + Per Second {0}", spell.manaPerSecond);
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.manaPerSecondPerLevel);
                sb.AppendFormatIfNotNull(" + PCT {0}", spell.ManaCostPercentage);

                sb.Append(Environment.NewLine);
            }
            sb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}",
                spell.InterruptFlags, spell.AuraInterruptFlags, spell.ChannelInterruptFlags);

            if (spell.CasterAuraState != 0 || spell.TargetAuraState != 0)
                sb.AppendFormatLine("CasterAuraState 0x{0:X8}, TargetAuraState 0x{1:X8}", spell.CasterAuraState, spell.TargetAuraState);
            if (spell.CasterAuraStateNot != 0 || spell.TargetAuraStateNot != 0)
                sb.AppendFormatLine("CasterAuraStateNot 0x{0:X8}, TargetAuraStateNot 0x{1:X8}", spell.CasterAuraStateNot, spell.TargetAuraStateNot);

            sb.Append(GetSpellAura(spell));
            sb.AppendFormatLineIfNotNull("Requires Spell Focus {0}", spell.RequiresSpellFocus);

            if (spell.procFlags != 0)
            {
                sb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                spell.procFlags, spell.procChance, spell.procCharges);
                sb.AppendFormatLine("=================================================");
                sb.Append(GetProcInfo(spell));
                sb.AppendFormatLine("=================================================");
            }
            else // if(spell.procCharges)
            {
                sb.AppendFormatLine("Chance = {0}, charges - {1}", spell.procChance, spell.procCharges);
            }
            sb.Append(GetSpellEffectInfo(spell));

            sb.Append(GetItemInfo(spell));

            return sb.ToString();
        }
    }
}
