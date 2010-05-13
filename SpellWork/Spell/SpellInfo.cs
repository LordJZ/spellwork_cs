using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace SpellWork
{
    class SpellInfo
    {
        public SpellInfo(RichTextBox sb, SpellEntry spell)
        {
            ProcInfo.SpellProc = spell;

            sb.Clear();
            sb.SetBold();
            sb.AppendFormatLine("ID - {0} {1}", spell.ID, spell.SpellNameRank);
            sb.SetDefaultStyle();

            sb.AppendFormatLine("=================================================");
            sb.AppendFormatLineIfNotNull("Description: {0}", spell.Description);
            sb.AppendFormatLineIfNotNull("ToolTip: {0}", spell.ToolTip);
            sb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", spell.ModalNextSpell);
            if(spell.Description != string.Empty && spell.ToolTip != string.Empty && spell.ModalNextSpell != 0)
                sb.AppendFormatLine("=================================================");

            sb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spell.Category, spell.SpellIconID, spell.ActiveIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            sb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags3, spell.SpellFamilyFlags2, spell.SpellFamilyFlags1);

            sb.AppendLine();

            sb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, spell.School);
            sb.AppendFormatLine("DamageClass = {0} ({1})", spell.DmgClass, (SpellDmgClass)spell.DmgClass);
            sb.AppendFormatLine("PreventionType = {0} ({1})", spell.PreventionType, (SpellPreventionType)spell.PreventionType);

            if (spell.Attributes != 0 || spell.AttributesEx != 0 || spell.AttributesEx2 != 0 || spell.AttributesEx3 != 0 
                || spell.AttributesEx4 != 0 || spell.AttributesEx5 != 0 || spell.AttributesEx6 != 0 || spell.AttributesExG != 0)
                sb.AppendLine("=================================================");

            if (spell.Attributes != 0)
                sb.AppendFormatLine("Attributes: 0x{0:X8} ({1})", spell.Attributes, (SpellAtribute)spell.Attributes);
            if (spell.AttributesEx != 0)
                sb.AppendFormatLine("AttributesEx1: 0x{0:X8} ({1})", spell.AttributesEx, (SpellAtributeEx)spell.AttributesEx);
            if (spell.AttributesEx2 != 0)
                sb.AppendFormatLine("AttributesEx2: 0x{0:X8} ({1})", spell.AttributesEx2, (SpellAtributeEx2)spell.AttributesEx2);
            if (spell.AttributesEx3 != 0)
                sb.AppendFormatLine("AttributesEx3: 0x{0:X8} ({1})", spell.AttributesEx3, (SpellAtributeEx3)spell.AttributesEx3);
            if (spell.AttributesEx4 != 0)
                sb.AppendFormatLine("AttributesEx4: 0x{0:X8} ({1})", spell.AttributesEx4, (SpellAtributeEx4)spell.AttributesEx4);
            if (spell.AttributesEx5 != 0)
                sb.AppendFormatLine("AttributesEx5: 0x{0:X8} ({1})", spell.AttributesEx5, (SpellAtributeEx5)spell.AttributesEx5);
            if (spell.AttributesEx6 != 0)
                sb.AppendFormatLine("AttributesEx6: 0x{0:X8} ({1})", spell.AttributesEx6, (SpellAtributeEx6)spell.AttributesEx6);
            if (spell.AttributesExG != 0)
                sb.AppendFormatLine("AttributesExG: 0x{0:X8} ({1})", spell.AttributesExG, (SpellAtributeExG)spell.AttributesExG);
            
            sb.AppendLine("=================================================");
            
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
            else
            {
                sb.AppendFormatLine("Chance = {0}, charges - {1}", spell.ProcChance, spell.ProcCharges);
            }

            AppendSpellEffectInfo(sb, spell);
            AppendItemInfo(sb, spell);
        }

        private void AppendSkillLine(RichTextBox sb, uint entry)
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

        private void AppendSpellEffectInfo(RichTextBox sb, SpellEntry spell)
        {
            sb.AppendLine("=================================================");

            for (int i = 0; i < 3; i++)
            {
                sb.SetBold();
                if ((SpellEffects)spell.Effect[i] == SpellEffects.NO_SPELL_EFFECT)
                {
                    sb.AppendFormatLine("Effect {0}:  NO EFFECT", i);
                    return;
                }

                sb.AppendFormatLine("Effect {0}: Id {1} ({2})", i, spell.Effect[i], (SpellEffects)spell.Effect[i]);
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

                sb.AppendText(AuraModTypeName(spell, i));

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

                    var query = from Spell in DBC.Spell.Values
                                where Spell.SpellFamilyName == spell.SpellFamilyName
                                && (   (Spell.SpellFamilyFlags1 & ClassMask[0]) != 0
                                    || (Spell.SpellFamilyFlags2 & ClassMask[1]) != 0
                                    || (Spell.SpellFamilyFlags3 & ClassMask[2]) != 0)
                                join sk in DBC.SkillLineAbility on Spell.ID equals sk.Value.SpellId into temp
                                from Skill in temp.DefaultIfEmpty()
                                select new
                                {
                                    SpellID   = Spell.ID,
                                    SpellName = Spell.SpellNameRank,
                                    SkillId   = Skill.Value.SkillId
                                };

                    foreach (var row in query)
                    {
                        if (row.SkillId > 0)
                        {
                            sb.SelectionColor = Color.Blue;
                            sb.AppendFormatLine("\t+ {0} - {1}",  row.SpellID, row.SpellName);
                        }
                        else
                        {
                            sb.SelectionColor = Color.Red;
                            sb.AppendFormatLine("\t- {0} - {1}", row.SpellID, row.SpellName);
                        }
                        sb.SelectionColor = Color.Black;
                    }
                }

                sb.AppendFormatLineIfNotNull("{0}", spell.GetRadius(i));
                
                // append trigger spell
                var tsId = spell.EffectTriggerSpell[i];
                if (tsId != 0)
                {
                    if (DBC.Spell.ContainsKey(tsId))
                    {
                        SpellEntry trigger = DBC.Spell[tsId];
                        sb.SetStyle(Color.Blue, FontStyle.Bold);
                        sb.AppendFormatLine("   Trigger spell ({0}) {1}. Chance = {2}", tsId, trigger.SpellNameRank, spell.ProcChance);
                        sb.SetStyle(FontStyle.Italic);
                        sb.AppendFormatLineIfNotNull("   Description: {0}", trigger.Description);
                        sb.SetStyle(FontStyle.Italic);
                        sb.AppendFormatLineIfNotNull("   ToolTip: {0}", trigger.ToolTip);
                        sb.SetDefaultStyle();
                        if (trigger.ProcFlags != 0)
                        {
                            sb.AppendFormatLine("Charges - {0}", trigger.ProcCharges);
                            sb.AppendLine("=================================================");
                            sb.AppendLine(trigger.ProcInfo);
                            sb.AppendLine("=================================================");
                        }
                    }
                    else
                    {
                        sb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", tsId, spell.ProcChance);
                    }
                }

                sb.AppendFormatLineIfNotNull("EffectChainTarget = {0}", spell.EffectChainTarget[i]);
                sb.AppendFormatLineIfNotNull("EffectItemType = {0}", spell.EffectItemType[i]);

                if((Mechanics)spell.EffectMechanic[i] != Mechanics.MECHANIC_NONE)
                    sb.AppendFormatLine("Effect Mechanic = {0} ({1})", spell.EffectMechanic[i], (Mechanics)spell.EffectMechanic[i]);

                sb.AppendLine();
            }
        }

        private void AppendSpellAura(RichTextBox sb, SpellEntry spell)
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

        private string AuraModTypeName(SpellEntry spell, int index)
        {
            AuraType aura    = (AuraType)spell.EffectApplyAuraName[index];
            int mod          = spell.EffectMiscValue[index];
            StringBuilder sb = new StringBuilder();

            if (spell.EffectApplyAuraName[index] == 0)
            {
                sb.AppendFormatLineIfNotNull("EffectMiscValueA = {0}", spell.EffectMiscValue[index]);
                sb.AppendFormatLineIfNotNull("EffectMiscValueB = {0}", spell.EffectMiscValueB[index]);
                sb.AppendFormatLineIfNotNull("EffectAmplitude = {0}",  spell.EffectAmplitude[index]);
                
                return sb.ToString();
            }

            sb.AppendFormat("Aura Id {0:D} ({0})", aura);
            sb.AppendFormat(", value = {0}", spell.EffectBasePoints[index] + 1);
            sb.AppendFormat(", misc = {0} (", mod);
          
            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_STAT:   sb.Append((UnitMods)mod); break;
                case AuraType.SPELL_AURA_MOD_RATING: sb.Append((CombatRating)mod); break;
                case AuraType.SPELL_AURA_ADD_FLAT_MODIFIER:
                case AuraType.SPELL_AURA_ADD_PCT_MODIFIER: sb.Append((SpellModOp)mod); break;
                
                // todo: more case
                default: sb.Append(mod); break;
            }

            sb.AppendFormat("), miscB = {0}", spell.EffectMiscValueB[index]);
            sb.AppendFormatLine(", periodic = {0}", spell.EffectAmplitude[index]);

            return sb.ToString();
        }

        private void AppendItemInfo(RichTextBox sb, SpellEntry spell)
        {
            if (!MySQLConnenct.Connected)
                return;
            
            var items = from   i in DBC.ItemTemplate
                        where  i.SpellID1 == spell.ID
                            || i.SpellID2 == spell.ID
                            || i.SpellID3 == spell.ID
                            || i.SpellID4 == spell.ID
                            || i.SpellID5 == spell.ID
                        select i;

            if (items.Count() == 0)
                return;

            sb.AppendLine("=================================================");
            sb.SetStyle(Color.Blue, FontStyle.Bold);
            sb.AppendLine("Items used this spell:");
            sb.SetDefaultStyle();
            foreach (var item in items)
            {
                var name = item.LocalesName == string.Empty ? item.Name : item.LocalesName;
                var desc = item.LocalesDescription == string.Empty ? item.Description : item.LocalesDescription;
                desc = desc == string.Empty ? string.Empty : string.Format("({0})", desc);

                sb.AppendFormatLine(@"   {0} - {1} {2} ", item.Entry, name, desc);
            }
        }
    }
}
