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
            sb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", spell.ModalNextSpell);
            sb.AppendFormatLine("=================================================");

            sb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spell.Category, spell.SpellIconID, spell.ActiveIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            sb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1);

            sb.AppendLine();

            sb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, spell.School);
            sb.AppendFormatLine("DamageClass = {0} ({1})", spell.DmgClass, (SpellDmgClass)spell.DmgClass);
            sb.AppendFormatLine("PreventionType = {0} ({1})", spell.PreventionType, (SpellPreventionType)spell.PreventionType);

            if (spell.Targets != 0)
                sb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", spell.Targets, (SpellCastTargetFlags)spell.Targets);

            if (spell.TargetCreatureType != 0)
                sb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})", 
                    spell.TargetCreatureType, (CreatureTypeMask)spell.TargetCreatureType);

            if (spell.Stances != 0)
                sb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)spell.Stances);

            if (spell.StancesNot != 0)
                sb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)spell.StancesNot);

            AppendSkillLine(sb, spell.ID);

            sb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}", 
                spell.SpellLevel, spell.BaseLevel, spell.MaxLevel, spell.MaxTargetLevel);

            if (spell.EquippedItemClass != -1)
            {
                sb.AppendFormatLine("EquippedItemClass = {0} ({1})", spell.EquippedItemClass, (ItemClass)spell.EquippedItemClass);

                if (spell.EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)spell.EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", 
                                spell.EquippedItemSubClassMask, (ItemSubClassWeaponMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", 
                                spell.EquippedItemSubClassMask, (ItemSubClassArmorMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            sb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", 
                                spell.EquippedItemSubClassMask, (ItemSubClassMiscMask)spell.EquippedItemSubClassMask);
                            break;
                    }
                }

                if (spell.EquippedItemInventoryTypeMask != 0)
                    sb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})", 
                        spell.EquippedItemInventoryTypeMask, (InventoryTypeMask)spell.EquippedItemInventoryTypeMask);
            }

            sb.AppendLine();
            sb.AppendFormatLine("Category = {0}", spell.Category);
            sb.AppendFormatLine("DispelType = {0} ({1})", spell.Dispel, (DispelType)spell.Dispel);
            sb.AppendFormatLine("Mechanic = {0} ({1})", spell.Mechanic, (Mechanics)spell.Mechanic);
            sb.AppendLine(spell.Range);

            sb.AppendFormatLineIfNotNull("Speed {0:F}", spell.Speed);

            sb.SetBold();
            sb.AppendFormatLine("Attributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                     spell.Attributes, spell.AttributesEx, spell.AttributesEx2, spell.AttributesEx3, spell.AttributesEx4,
                     spell.AttributesEx5, spell.AttributesEx6, spell.AttributesExG);
            sb.SetDefaultStyle();

            sb.AppendFormatLineIfNotNull("Stackable up to {0}", spell.StackAmount);
            sb.AppendLine(spell.CastTime);

            if (spell.RecoveryTime != 0 || spell.CategoryRecoveryTime != 0 || spell.StartRecoveryCategory != 0)
            {
                sb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", spell.RecoveryTime, spell.CategoryRecoveryTime);
                sb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", spell.StartRecoveryCategory, spell.StartRecoveryTime);
            }

            sb.AppendLine(spell.Duration);

            if (spell.ManaCost != 0 || spell.ManaCostPercentage != 0)
            {
                sb.AppendFormat("Power {0}, Cost {1}", 
                    (Powers)spell.PowerType, spell.ManaCost == 0 ? spell.ManaCostPercentage.ToString() + " %" : spell.ManaCost.ToString());
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.ManaCostPerlevel);
                sb.AppendFormatIfNotNull(" + {0} Per Second", spell.ManaPerSecond);
                sb.AppendFormatIfNotNull(" + lvl * {0}", spell.ManaPerSecondPerLevel);
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

            if (spell.ProcFlags != 0)
            {
                sb.SetBold();
                sb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                spell.ProcFlags, spell.ProcChance, spell.ProcCharges);
                sb.SetDefaultStyle();
                sb.AppendFormatLine("=================================================");
                sb.AppendText(spell.ProcInfo);
            }
            else // if(spell.procCharges)
            {
                sb.AppendFormatLine("Chance = {0}, charges - {1}", spell.ProcChance, spell.ProcCharges);
            }

            AppendSpellEffectInfo(sb, spell);
        }

        static void AppendSkillLine(RichTextBox sb, uint entry)
        {
            var query = from skillLineAbility in DBC.SkillLineAbility
                        join skillLine in DBC.SkillLine
                        on skillLineAbility.Value.SkillId equals skillLine.Key
                        where skillLineAbility.Value.SpellId == entry
                        select new 
                        { 
                            skillLineAbility, 
                            skillLine 
                        };

            if (query.Count() == 0)
                return;

            var skill = query.First().skillLineAbility.Value;
            var line =  query.First().skillLine.Value;

            sb.AppendFormatLine("Skill (Id {0}) \"{1}\"", skill.SkillId, line.Name);
            sb.AppendFormat("    ReqSkillValue {0}", skill.Req_skill_value);

            sb.AppendFormat(", Forward Spell = {0}, MinMaxValue ({1}, {2})", skill.Forward_spellid, skill.Min_value, skill.Max_value);
            sb.AppendFormat(", CharacterPoints ({0}, {1})", skill.CharacterPoints[0], skill.CharacterPoints[1]);
        }

        static void AppendSpellEffectInfo(RichTextBox sb, SpellEntry spell)
        {
            sb.AppendLine("=================================================");

            for (int i = 0; i < 3; i++)
            {
                sb.SetBold();
                if ((SpellEffects)spell.Effect[i] == SpellEffects.NO_SPELL_EFFECT)
                {
                    sb.AppendFormatLine("Effect {0}: NO EFFECT", i);
                    return;
                }

                sb.AppendFormatLine("Effect {0}: {1}", i, (SpellEffects)spell.Effect[i]);
                sb.SetDefaultStyle();
                sb.AppendFormat("BasePoints = {0}", spell.EffectBasePoints[i] + 1);
                if (spell.EffectRealPointsPerLevel[i] != 0)
                    sb.AppendFormat(" + Level * {0:F}", spell.EffectRealPointsPerLevel[i]);

                // WTF ? 1 = spell.EffectBaseDice[i]
                if (1 < spell.EffectDieSides[i])
                {
                    if (spell.EffectRealPointsPerLevel[i] != 0)
                        sb.AppendFormat(" to {0} + lvl * {1:F}",
                            spell.EffectBasePoints[i] + 1 + spell.EffectDieSides[i], spell.EffectRealPointsPerLevel[i]);
                    else
                        sb.AppendFormat(" to {0}", spell.EffectBasePoints[i] + 1 + spell.EffectDieSides[i]);
                }

                sb.AppendFormatIfNotNull(" + combo * {0:F}", spell.EffectPointsPerComboPoint[i]);

                if (spell.DmgMultiplier[i] != 1.0f)
                    sb.AppendFormat(" x {0:F}", spell.DmgMultiplier[i]);

                sb.AppendFormatIfNotNull("  Multiple = {0:F}", spell.EffectMultipleValue[i]);
                sb.AppendLine();

                sb.AppendFormatLine("Targets ({0}, {1}) ({2}, {3})",
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
                            var name = s.Rank == "" ? s.SpellName : s.SpellName + " (" + s.Rank + ")";
                            if (row.SkillId > 0)
                            {
                                sb.SelectionColor = Color.Blue;
                                sb.AppendFormatLine("    + {0} - {1}",  s.ID, name);
                            }
                            else
                            {
                                sb.SelectionColor = Color.Red;
                                sb.AppendFormatLine("    - {0} - {1}",  s.ID, name);
                            }
                            sb.SelectionColor = Color.Black;
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
            if (spell.CasterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.CasterAuraSpell))
                    sb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", spell.CasterAuraSpell, DBC.Spell[spell.CasterAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", spell.CasterAuraSpell);
            }

            if (spell.TargetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.TargetAuraSpell))
                    sb.AppendFormatLine("  Target Aura Spell ({0}) {1}", spell.TargetAuraSpell, DBC.Spell[spell.TargetAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Target Aura Spell ({0}) ?????", spell.TargetAuraSpell);
            }

            if (spell.ExcludeCasterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.ExcludeCasterAuraSpell))
                    sb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", spell.ExcludeCasterAuraSpell, DBC.Spell[spell.ExcludeCasterAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", spell.ExcludeCasterAuraSpell);
            }

            if (spell.ExcludeTargetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.ExcludeTargetAuraSpell))
                    sb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", spell.ExcludeTargetAuraSpell, DBC.Spell[spell.ExcludeTargetAuraSpell].SpellName);
                else
                    sb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", spell.ExcludeTargetAuraSpell);
            }
        }
    }
}
