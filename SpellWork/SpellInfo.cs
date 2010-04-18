using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SpellWork
{
    class SpellInfo
    {
        public static void View(RichTextBox sb, uint spellId)
        {
            sb.Clear();
            var spell = DBC.Spell[spellId];
            sb.SetBold();
            sb.AppendFormatLine("ID - {0} {1} ({2})", spell.ID, spell.SpellName, spell.Rank);
            sb.SetDefaultStyle();

            sb.AppendFormatLine("=================================================");
            sb.AppendFormatLineIfNotNull("Description: {0}", spell.Description);
            sb.AppendFormatLineIfNotNull("ToolTip: {0}", spell.ToolTip);
            sb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", spell.modalNextSpell);
            sb.AppendFormatLine("=================================================");

            sb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spell.Category, spell.SpellIconID, spell.activeIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            sb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1);

            sb.AppendLine();
            sb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, spell.School);
            sb.AppendFormatLine("DamageClass = {0} ({1})", spell.DmgClass, (SpellDmgClass)spell.DmgClass);
            sb.AppendFormatLine("PreventionType = {0} ({1})", spell.PreventionType, (SpellPreventionType)spell.PreventionType);

            if (spell.Targets != 0)
                sb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", spell.Targets, (SpellCastTargetFlags)spell.Targets);

            if (spell.TargetCreatureType != 0)
                sb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})", spell.TargetCreatureType, (CreatureTypeMask)spell.TargetCreatureType);

            if (spell.Stances != 0)
                sb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)spell.Stances);

            if (spell.StancesNot != 0)
                sb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)spell.StancesNot);

            AppendSkillLine(sb, spell.ID);

            sb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}",
                spell.spellLevel, spell.baseLevel, spell.maxLevel, spell.MaxTargetLevel);

            if (spell.EquippedItemClass != -1)
            {
                sb.AppendFormatLine("EquippedItemClass = {0} ({1})", spell.EquippedItemClass, (ItemClass)spell.EquippedItemClass);

                if (spell.EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)spell.EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", spell.EquippedItemSubClassMask, (ItemSubClassWeaponMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", spell.EquippedItemSubClassMask, (ItemSubClassArmorMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", spell.EquippedItemSubClassMask, (ItemSubClassMiscMask)spell.EquippedItemSubClassMask);
                            break;
                    }
                }

                if (spell.EquippedItemInventoryTypeMask != 0)
                    sb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})", spell.EquippedItemInventoryTypeMask, (InventoryTypeMask)spell.EquippedItemInventoryTypeMask);
            }

            sb.AppendLine();
            sb.AppendFormatLine("Category = {0}", spell.Category);
            sb.AppendFormatLine("DispelType = {0} ({1})", spell.Dispel, (DispelType)spell.Dispel);
            sb.AppendFormatLine("Mechanic = {0} ({1})", spell.Mechanic, (Mechanics)spell.Mechanic);
            sb.AppendLine(spell.Range);

            sb.AppendFormatLineIfNotNull("Speed {0:F}", spell.speed);

            sb.AppendFormatLine("Attributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                     spell.Attributes, spell.AttributesEx, spell.AttributesEx2, spell.AttributesEx3, spell.AttributesEx4,
                     spell.AttributesEx5, spell.AttributesEx6, spell.AttributesExG);

            sb.AppendFormatLineIfNotNull("Stackable up to {0}", spell.StackAmount);
            sb.AppendLine(spell.CastTime);

            if (spell.RecoveryTime != 0 || spell.CategoryRecoveryTime != 0 || spell.StartRecoveryCategory != 0)
            {
                sb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", spell.RecoveryTime, spell.CategoryRecoveryTime);
                sb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", spell.StartRecoveryCategory, spell.StartRecoveryTime);
            }

            sb.AppendLine(spell.Duration);

            if (spell.manaCost != 0 || spell.ManaCostPercentage != 0)
            {
                sb.AppendFormat("Power {0}, Cost {1}", (Powers)spell.powerType, spell.manaCost == 0 ? spell.ManaCostPercentage.ToString() + " %" : spell.manaCost.ToString());
                //sb.AppendFormatIfNotNull(" + {0}", spell.manaCost);
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.manaCostPerlevel);
                sb.AppendFormatIfNotNull(" + {0} Per Second", spell.manaPerSecond);
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.manaPerSecondPerLevel);
                //sb.AppendFormatIfNotNull(" + {0} %", spell.ManaCostPercentage);
                sb.AppendLine();
            }

            sb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}",
                spell.InterruptFlags, spell.AuraInterruptFlags, spell.ChannelInterruptFlags);

            if (spell.CasterAuraState != 0)
                sb.AppendFormatLine("CasterAuraState = {0} ({1})", spell.CasterAuraState, (AuraState)spell.CasterAuraState);

            if (spell.TargetAuraState != 0)
                sb.AppendFormatLine("TargetAuraState = {0} ({1})", spell.TargetAuraState, (AuraState)spell.TargetAuraState);

            if (spell.CasterAuraStateNot != 0)
                sb.AppendFormatLine("CasterAuraStateNot = {0} ({1})", spell.CasterAuraStateNot, (AuraState)spell.CasterAuraStateNot);

            if (spell.TargetAuraStateNot != 0)
                sb.AppendFormatLine("TargetAuraStateNot = {0} ({1})", spell.TargetAuraStateNot, (AuraState)spell.TargetAuraStateNot);

            AppendSpellAura(sb, spell);

            sb.AppendFormatLineIfNotNull("Requires Spell Focus {0}", spell.RequiresSpellFocus);

            if (spell.procFlags != 0)
            {
                sb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                spell.procFlags, spell.procChance, spell.procCharges);
                sb.AppendFormatLine("=================================================");
                sb.AppendText(spell.ProcInfo);
                sb.AppendFormatLine("=================================================");
            }
            else // if(spell.procCharges)
            {
                sb.AppendFormatLine("Chance = {0}, charges - {1}", spell.procChance, spell.procCharges);
            }

            AppendSpellEffectInfo(sb, spell);

            AppendItemInfo(sb, spell);
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
                ? String.Format("+({0}) {1} ({2}) (Sk{3}) ({4})", spell.ID, spell.SpellName, spell.Rank, elem.SkillId, spell.School)
                : String.Format("-({0}) {1} ({2}) ({3})",      spell.ID, spell.SpellName, spell.Rank, spell.School);

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

        static void AppendSkillLine(RichTextBox sb, uint entry)
        {
            var query =
               from skillLineAbility in DBC.SkillLineAbility
               join skillLine in DBC.SkillLine
               on skillLineAbility.Value.SkillId equals skillLine.Key
               where skillLineAbility.Value.SpellId == entry
               select new { skillLineAbility, skillLine };

            if (query.Count() == 0)
                return;

            var skill = query.First().skillLineAbility.Value;
            var line =  query.First().skillLine.Value;

            sb.AppendFormatLine("Skill (Id {0}) \"{1}\"", skill.SkillId, line.Name);
            sb.AppendFormat("    ReqSkillValue {0}", skill.Req_skill_value);

            sb.AppendFormat(", Forward Spell = {0}, MinMaxValue ({1}, {2})", skill.Forward_spellid, skill.Min_value, skill.Max_value);
            sb.AppendFormat(", CharacterPoints ({0}, {1})", skill.characterPoints[0], skill.characterPoints[1]);
        }

        static void AppendItemInfo(RichTextBox sb, SpellEntry spell)
        {
            // Получить из базы данных ()
            // SELECT `entry`, `name` FROM `item_template` WHERE `spellid_1` = {0} OR `spellid_2` = {1} OR `spellid_3` = {2}
            //      OR `spellid_4` = {3} OR `spellid_5` = {4}
            return;
        }

        static void AppendSpellEffectInfo(RichTextBox sb, SpellEntry spell)
        {
            sb.AppendLine("_________________________________________________");

            for (int i = 0; i < 3; i++)
            {
                if ((SpellEffects)spell.Effect[i] == SpellEffects.NO_SPELL_EFFECT)
                {
                    sb.AppendFormatLine("Effect {0}: NO EFFECT", i);
                    return;
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

                sb.AppendFormatIfNotNull(" + combo * {0:F}", spell.EffectPointsPerComboPoint[i]);

                if (spell.DmgMultiplier[i] != 1.0f)
                    sb.AppendFormat(" x {0:F}", spell.DmgMultiplier[i]);

                sb.AppendFormatIfNotNull("  Multiple = {0:F}", spell.EffectMultipleValue[i]);
                sb.AppendLine();

                sb.AppendFormatLine("Targets ({0},{1}) ({2},{3})",
                    spell.EffectImplicitTargetA[i], spell.EffectImplicitTargetB[i],
                    (Targets)spell.EffectImplicitTargetA[i], (Targets)spell.EffectImplicitTargetB[i]);

                if (spell.EffectApplyAuraName[i] != 0)
                {
                    sb.AppendFormatLine("Aura {0}, value = {1}, misc = {2}, miscB = {3}, periodic = {4}",
                        (AuraType)spell.EffectApplyAuraName[i],
                        spell.EffectBasePoints[i] + 1, spell.GetAuraModTypeName(i),
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
                            //var exist = (row.SkillId > 0) ? "+" : "-";
                            var name = s.Rank == "" ? s.SpellName : s.SpellName + " (" + s.Rank + ")";
                            if (row.SkillId > 0)
                            {
                                sb.SelectionColor = Color.Blue;
                                sb.AppendFormatLine("    + {0} - {1}",  s.ID, name);
                                sb.SelectionColor = Color.Black;
                            }
                            else
                            {
                                sb.SelectionColor = Color.Red;
                                sb.AppendFormatLine("    - {0} - {1}",  s.ID, name);
                                sb.SelectionColor = Color.Black;
                            }
                        }
                    }
                }

                sb.AppendFormatLineIfNotNull("{0}", spell.GetRadius(i));
                sb.AppendFormatLineIfNotNull("{0}", spell.GetTriggerSpellInfo(i));

                sb.AppendFormatLineIfNotNull("EffectChainTarget = {0}", spell.EffectChainTarget[i]);
                sb.AppendFormatLineIfNotNull("EffectItemType = {0}", spell.EffectItemType[i]);

                if((Mechanics)spell.EffectMechanic[i] != Mechanics.MECHANIC_NONE)
                    sb.AppendFormatLine("Effect Mechanic = {0} ({1})", spell.EffectMechanic[i], (Mechanics)spell.EffectMechanic[i]);

                sb.AppendLine();
            }
        }

        static void AppendSpellAura(RichTextBox sb, SpellEntry spell)
        {
            if (spell.casterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.casterAuraSpell))
                    sb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", spell.casterAuraSpell, DBC.Spell[spell.casterAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", spell.casterAuraSpell);
            }

            if (spell.targetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.targetAuraSpell))
                    sb.AppendFormatLine("  Target Aura Spell ({0}) {1}", spell.targetAuraSpell, DBC.Spell[spell.targetAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Target Aura Spell ({0}) ?????", spell.targetAuraSpell);
            }

            if (spell.excludeCasterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.excludeCasterAuraSpell))
                    sb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", spell.excludeCasterAuraSpell, DBC.Spell[spell.excludeCasterAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", spell.excludeCasterAuraSpell);
            }

            if (spell.excludeTargetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.excludeTargetAuraSpell))
                    sb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", spell.excludeTargetAuraSpell, DBC.Spell[spell.excludeTargetAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", spell.excludeTargetAuraSpell);
            }
        }
    }
}
