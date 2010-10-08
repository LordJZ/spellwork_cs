using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace SpellWork
{
    class SpellInfo
    {
        private RichTextBox rtb;
        private SpellEntry spell;
        private SpellClassOptionsEntry classOptions;
        private SpellTargetRestrictionsEntry targetRestrictions;
        private SpellShapeshiftEntry spellShapeshift;
        private SpellCategoriesEntry spellCategories;
        private SpellLevelsEntry spellLevels;
        private SpellEquippedItemsEntry spellEquippedItems;
        private SpellAuraOptionsEntry spellAuraOptions;
        private SpellCooldownsEntry spellCooldowns;
        private SpellAuraRestrictionsEntry spellAuraRestrictions;
        private SpellCastingRequirementsEntry spellCastingRequirements;
        private SpellInterruptsEntry spellInterrupts;
        private SpellPowerEntry spellPower;

        private string _line = "=================================================";

        public SpellInfo(RichTextBox rtb, SpellEntry spell)
        {
            this.rtb = rtb;
            this.spell = spell;

            // cache dbc data to avoid multiple searching
            this.classOptions = spell.SpellClassOptions;
            this.targetRestrictions = spell.SpellTargetRestrictions;
            this.spellShapeshift = spell.SpellShapeshift;
            this.spellCategories = spell.SpellCategories;
            this.spellLevels = spell.SpellLevels;
            this.spellEquippedItems = spell.SpellEquippedItems;
            this.spellAuraOptions = spell.SpellAuraOptions;
            this.spellCooldowns = spell.SpellCooldowns;
            this.spellAuraRestrictions = spell.SpellAuraRestrictions;
            this.spellCastingRequirements = spell.SpellCastingRequirements;
            this.spellInterrupts = spell.SpellInterrupts;
            this.spellPower = spell.SpellPower;

            ProcInfo.SpellProc = spell;

            ViewSpellInfo();
        }

        private void ViewSpellInfo()
        {
            rtb.Clear();
            rtb.SetBold();
            rtb.AppendFormatLine("ID - {0} {1}", spell.ID, spell.SpellNameRank);
            rtb.SetDefaultStyle();

            rtb.AppendFormatLine(_line);
            rtb.AppendFormatLineIfNotNull("Description: {0}", spell.Description);
            rtb.AppendFormatLineIfNotNull("ToolTip: {0}", spell.ToolTip);
            rtb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", classOptions.ModalNextSpell);
            if (spell.Description != string.Empty && spell.ToolTip != string.Empty && classOptions.ModalNextSpell != 0)
                rtb.AppendFormatLine(_line);

            rtb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spellCategories.Category, spell.SpellIconID, spell.ActiveIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            if (classOptions.SpellFamilyFlags != null)
                rtb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                    (SpellFamilyNames)classOptions.SpellFamilyName, classOptions.SpellFamilyFlags[2], classOptions.SpellFamilyFlags[1], classOptions.SpellFamilyFlags[0]);
            else
                rtb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                    (SpellFamilyNames)classOptions.SpellFamilyName, 0, 0, 0);

            rtb.AppendLine();

            rtb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, spell.School);
            rtb.AppendFormatLine("DamageClass = {0} ({1})", spellCategories.DmgClass, (SpellDmgClass)spellCategories.DmgClass);
            rtb.AppendFormatLine("PreventionType = {0} ({1})", spellCategories.PreventionType, (SpellPreventionType)spellCategories.PreventionType);

            if (spell.Attributes != 0 || spell.AttributesEx != 0 || spell.AttributesEx2 != 0 || spell.AttributesEx3 != 0
                || spell.AttributesEx4 != 0 || spell.AttributesEx5 != 0 || spell.AttributesEx6 != 0 || spell.AttributesExG != 0)
                rtb.AppendLine(_line);

            if (spell.Attributes != 0)
                rtb.AppendFormatLine("Attributes: 0x{0:X8} ({1})", spell.Attributes, (SpellAtribute)spell.Attributes);
            if (spell.AttributesEx != 0)
                rtb.AppendFormatLine("AttributesEx1: 0x{0:X8} ({1})", spell.AttributesEx, (SpellAtributeEx)spell.AttributesEx);
            if (spell.AttributesEx2 != 0)
                rtb.AppendFormatLine("AttributesEx2: 0x{0:X8} ({1})", spell.AttributesEx2, (SpellAtributeEx2)spell.AttributesEx2);
            if (spell.AttributesEx3 != 0)
                rtb.AppendFormatLine("AttributesEx3: 0x{0:X8} ({1})", spell.AttributesEx3, (SpellAtributeEx3)spell.AttributesEx3);
            if (spell.AttributesEx4 != 0)
                rtb.AppendFormatLine("AttributesEx4: 0x{0:X8} ({1})", spell.AttributesEx4, (SpellAtributeEx4)spell.AttributesEx4);
            if (spell.AttributesEx5 != 0)
                rtb.AppendFormatLine("AttributesEx5: 0x{0:X8} ({1})", spell.AttributesEx5, (SpellAtributeEx5)spell.AttributesEx5);
            if (spell.AttributesEx6 != 0)
                rtb.AppendFormatLine("AttributesEx6: 0x{0:X8} ({1})", spell.AttributesEx6, (SpellAtributeEx6)spell.AttributesEx6);
            if (spell.AttributesExG != 0)
                rtb.AppendFormatLine("AttributesExG: 0x{0:X8} ({1})", spell.AttributesExG, (SpellAtributeExG)spell.AttributesExG);

            rtb.AppendLine(_line);

            if (targetRestrictions.Targets != 0)
                rtb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", targetRestrictions.Targets, (SpellCastTargetFlags)targetRestrictions.Targets);

            if (targetRestrictions.TargetCreatureType != 0)
                rtb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})",
                    targetRestrictions.TargetCreatureType, (CreatureTypeMask)targetRestrictions.TargetCreatureType);

            if (spellShapeshift.Stances != 0)
                rtb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)spellShapeshift.Stances);

            if (spellShapeshift.StancesNot != 0)
                rtb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)spellShapeshift.StancesNot);

            AppendSkillLine();

            rtb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}",
                spellLevels.SpellLevel, spellLevels.BaseLevel, spellLevels.MaxLevel, targetRestrictions.MaxTargetLevel);

            if (spellEquippedItems.EquippedItemClass != -1)
            {
                rtb.AppendFormatLine("EquippedItemClass = {0} ({1})", spellEquippedItems.EquippedItemClass, (ItemClass)spellEquippedItems.EquippedItemClass);

                if (spellEquippedItems.EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)spellEquippedItems.EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spellEquippedItems.EquippedItemSubClassMask, (ItemSubClassWeaponMask)spellEquippedItems.EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spellEquippedItems.EquippedItemSubClassMask, (ItemSubClassArmorMask)spellEquippedItems.EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spellEquippedItems.EquippedItemSubClassMask, (ItemSubClassMiscMask)spellEquippedItems.EquippedItemSubClassMask);
                            break;
                    }
                }

                if (spellEquippedItems.EquippedItemInventoryTypeMask != 0)
                    rtb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})",
                        spellEquippedItems.EquippedItemInventoryTypeMask, (InventoryTypeMask)spellEquippedItems.EquippedItemInventoryTypeMask);
            }

            rtb.AppendLine();
            rtb.AppendFormatLine("Category = {0}", spellCategories.Category);
            rtb.AppendFormatLine("DispelType = {0} ({1})", spellCategories.Dispel, (DispelType)spellCategories.Dispel);
            rtb.AppendFormatLine("Mechanic = {0} ({1})", spellCategories.Mechanic, (Mechanics)spellCategories.Mechanic);

            rtb.AppendLine(spell.Range);

            rtb.AppendFormatLineIfNotNull("Speed {0:F}", spell.Speed);
            rtb.AppendFormatLineIfNotNull("Stackable up to {0}", spellAuraOptions.StackAmount);

            rtb.AppendLine(spell.CastTime);

            if (spellCooldowns.RecoveryTime != 0 || spellCooldowns.CategoryRecoveryTime != 0 || spellCategories.StartRecoveryCategory != 0)
            {
                rtb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", spellCooldowns.RecoveryTime, spellCooldowns.CategoryRecoveryTime);
                rtb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", spellCategories.StartRecoveryCategory, spellCooldowns.StartRecoveryTime);
            }

            rtb.AppendLine(spell.Duration);

            if (spellPower.ManaCost != 0 || spellPower.ManaCostPercentage != 0)
            {
                rtb.AppendFormat("Power {0}, Cost {1}",
                    (Powers)spell.PowerType, spellPower.ManaCost == 0 ? spellPower.ManaCostPercentage.ToString() + " %" : spellPower.ManaCost.ToString());
                rtb.AppendFormatIfNotNull(" + lvl * {0}", spellPower.ManaCostPerlevel);
                rtb.AppendFormatIfNotNull(" + {0} Per Second", spellPower.ManaPerSecond);
                //rtb.AppendFormatIfNotNull(" + lvl * {0}", spellPower.ManaPerSecondPerLevel);
                rtb.AppendLine();
            }

            rtb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}",
                spellInterrupts.InterruptFlags, spellInterrupts.AuraInterruptFlags, spellInterrupts.ChannelInterruptFlags);

            if (spellAuraRestrictions.CasterAuraState != 0)
                rtb.AppendFormatLine("CasterAuraState = {0} ({1})", spellAuraRestrictions.CasterAuraState, (AuraState)spellAuraRestrictions.CasterAuraState);

            if (spellAuraRestrictions.TargetAuraState != 0)
                rtb.AppendFormatLine("TargetAuraState = {0} ({1})", spellAuraRestrictions.TargetAuraState, (AuraState)spellAuraRestrictions.TargetAuraState);

            if (spellAuraRestrictions.CasterAuraStateNot != 0)
                rtb.AppendFormatLine("CasterAuraStateNot = {0} ({1})", spellAuraRestrictions.CasterAuraStateNot, (AuraState)spellAuraRestrictions.CasterAuraStateNot);

            if (spellAuraRestrictions.TargetAuraStateNot != 0)
                rtb.AppendFormatLine("TargetAuraStateNot = {0} ({1})", spellAuraRestrictions.TargetAuraStateNot, (AuraState)spellAuraRestrictions.TargetAuraStateNot);

            AppendSpellAura();

            rtb.AppendFormatLineIfNotNull("Requires Spell Focus {0}", spellCastingRequirements.RequiresSpellFocus);

            if (spellAuraOptions.ProcFlags != 0)
            {
                rtb.SetBold();
                rtb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                spellAuraOptions.ProcFlags, spellAuraOptions.ProcChance, spellAuraOptions.ProcCharges);
                rtb.SetDefaultStyle();
                rtb.AppendFormatLine(_line);
                rtb.AppendText(spell.ProcInfo);
            }
            else
            {
                rtb.AppendFormatLine("Chance = {0}, charges - {1}", spellAuraOptions.ProcChance, spellAuraOptions.ProcCharges);
            }

            AppendSpellEffectInfo();
            AppendItemInfo();
        }

        private void AppendSkillLine()
        {
            var query = from skillLineAbility in DBC.SkillLineAbility
                        join skillLine in DBC.SkillLine
                        on skillLineAbility.Value.SkillId equals skillLine.Key
                        where skillLineAbility.Value.SpellId == spell.ID
                        select new
                        {
                            skillLineAbility,
                            skillLine
                        };

            if (query.Count() == 0)
                return;

            var skill = query.First().skillLineAbility.Value;
            var line = query.First().skillLine.Value;

            rtb.AppendFormatLine("Skill (Id {0}) \"{1}\"", skill.SkillId, line.Name);
            rtb.AppendFormat("    ReqSkillValue {0}", skill.Req_skill_value);

            rtb.AppendFormat(", Forward Spell = {0}, MinMaxValue ({1}, {2})", skill.Forward_spellid, skill.Min_value, skill.Max_value);
            rtb.AppendFormat(", CharacterPoints ({0}, {1})", skill.CharacterPoints[0], skill.CharacterPoints[1]);
        }

        private void AppendSpellEffectInfo()
        {
            rtb.AppendLine(_line);

            for (int EFFECT_INDEX = 0; EFFECT_INDEX < DBC.MAX_EFFECT_INDEX; EFFECT_INDEX++)
            {
                if (!spell.HasEffectAtIndex(EFFECT_INDEX))
                    continue;

                SpellEffectEntry effect = spell.GetEffect(EFFECT_INDEX);

                rtb.SetBold();
                if ((SpellEffects)effect.Effect == SpellEffects.NO_SPELL_EFFECT)
                {
                    rtb.AppendFormatLine("Effect {0}:  NO EFFECT", EFFECT_INDEX);
                    rtb.AppendLine();
                    continue;
                }

                rtb.AppendFormatLine("Effect {0}: Id {1} ({2})", EFFECT_INDEX, effect.Effect, (SpellEffects)effect.Effect);
                rtb.SetDefaultStyle();
                rtb.AppendFormat("BasePoints = {0}", effect.EffectBasePoints + 1);

                if (effect.EffectRealPointsPerLevel != 0)
                    rtb.AppendFormat(" + Level * {0:F}", effect.EffectRealPointsPerLevel);

                // WTF ? 1 = spell.EffectBaseDice[i]
                if (1 < effect.EffectDieSides)
                {
                    if (effect.EffectRealPointsPerLevel != 0)
                        rtb.AppendFormat(" to {0} + lvl * {1:F}",
                            effect.EffectBasePoints + 1 + effect.EffectDieSides, effect.EffectRealPointsPerLevel);
                    else
                        rtb.AppendFormat(" to {0}", effect.EffectBasePoints + 1 + effect.EffectDieSides);
                }

                rtb.AppendFormatIfNotNull(" + combo * {0:F}", effect.EffectPointsPerComboPoint);

                if (effect.DmgMultiplier != 1.0f)
                    rtb.AppendFormat(" x {0:F}", effect.DmgMultiplier);

                rtb.AppendFormatIfNotNull("  Multiple = {0:F}", effect.EffectMultipleValue);
                rtb.AppendLine();

                rtb.AppendFormatLine("Targets ({0}, {1}) ({2}, {3})",
                    effect.EffectImplicitTargetA, effect.EffectImplicitTargetB,
                    (Targets)effect.EffectImplicitTargetA, (Targets)effect.EffectImplicitTargetB);

                AuraModTypeName(EFFECT_INDEX);

                uint[] ClassMask = new uint[3];

                ClassMask = effect.EffectSpellClassMaskA;

                //switch (EFFECT_INDEX)
                //{
                //    case 0: ClassMask = spell.EffectSpellClassMaskA; break;
                //    case 1: ClassMask = spell.EffectSpellClassMaskB; break;
                //    case 2: ClassMask = spell.EffectSpellClassMaskC; break;
                //}

                if (ClassMask[0] != 0 || ClassMask[1] != 0 || ClassMask[2] != 0)
                {
                    rtb.AppendFormatLine("SpellClassMask = {0:X8} {1:X8} {2:X8}", ClassMask[2], ClassMask[1], ClassMask[0]);

                    var query = from Spell in DBC.Spell.Values
                                where Spell.SpellClassOptions.Match(classOptions, ClassMask)
                                join sk in DBC.SkillLineAbility on Spell.ID equals sk.Value.SpellId into temp
                                from Skill in temp.DefaultIfEmpty()
                                select new
                                {
                                    SpellID = Spell.ID,
                                    SpellName = Spell.SpellNameRank,
                                    SkillId = Skill.Value.SkillId
                                };

                    foreach (var row in query)
                    {
                        if (row.SkillId > 0)
                        {
                            rtb.SelectionColor = Color.Blue;
                            rtb.AppendFormatLine("\t+ {0} - {1}", row.SpellID, row.SpellName);
                        }
                        else
                        {
                            rtb.SelectionColor = Color.Red;
                            rtb.AppendFormatLine("\t- {0} - {1}", row.SpellID, row.SpellName);
                        }
                        rtb.SelectionColor = Color.Black;
                    }
                }

                rtb.AppendFormatLineIfNotNull("{0}", spell.GetRadius(EFFECT_INDEX));

                // append trigger spell
                uint trigger = spell.GetEffect(EFFECT_INDEX).EffectTriggerSpell;
                if (trigger != 0)
                {
                    if (DBC.Spell.ContainsKey(trigger))
                    {
                        SpellEntry triggerSpell = DBC.Spell[trigger];
                        rtb.SetStyle(Color.Blue, FontStyle.Bold);
                        rtb.AppendFormatLine("   Trigger spell ({0}) {1}. Chance = {2}", trigger, triggerSpell.SpellNameRank, spellAuraOptions.ProcChance);
                        rtb.AppendFormatLineIfNotNull("   Description: {0}", triggerSpell.Description);
                        rtb.AppendFormatLineIfNotNull("   ToolTip: {0}", triggerSpell.ToolTip);
                        rtb.SetDefaultStyle();
                        var triggerAuraOptions = triggerSpell.SpellAuraOptions;
                        if (triggerAuraOptions.ProcFlags != 0)
                        {
                            rtb.AppendFormatLine("Charges - {0}", triggerAuraOptions.ProcCharges);
                            rtb.AppendLine(_line);
                            rtb.AppendLine(triggerSpell.ProcInfo);
                            rtb.AppendLine(_line);
                        }
                    }
                    else
                    {
                        rtb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", trigger, spellAuraOptions.ProcChance);
                    }
                }

                rtb.AppendFormatLineIfNotNull("EffectChainTarget = {0}", effect.EffectChainTarget);
                rtb.AppendFormatLineIfNotNull("EffectItemType = {0}", effect.EffectItemType);

                if ((Mechanics)effect.EffectMechanic != Mechanics.MECHANIC_NONE)
                    rtb.AppendFormatLine("Effect Mechanic = {0} ({1})", effect.EffectMechanic, (Mechanics)effect.EffectMechanic);

                rtb.AppendLine();
            }
        }

        private void AppendSpellAura()
        {
            if (spellAuraRestrictions.CasterAuraSpell != 0)
            {
                if (DBC.Spell.ContainsKey(spellAuraRestrictions.CasterAuraSpell))
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", spellAuraRestrictions.CasterAuraSpell, DBC.Spell[spellAuraRestrictions.CasterAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", spellAuraRestrictions.CasterAuraSpell);
            }

            if (spellAuraRestrictions.TargetAuraSpell != 0)
            {
                if (DBC.Spell.ContainsKey(spellAuraRestrictions.TargetAuraSpell))
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) {1}", spellAuraRestrictions.TargetAuraSpell, DBC.Spell[spellAuraRestrictions.TargetAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) ?????", spellAuraRestrictions.TargetAuraSpell);
            }

            if (spellAuraRestrictions.ExcludeCasterAuraSpell != 0)
            {
                if (DBC.Spell.ContainsKey(spellAuraRestrictions.ExcludeCasterAuraSpell))
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", spellAuraRestrictions.ExcludeCasterAuraSpell, DBC.Spell[spellAuraRestrictions.ExcludeCasterAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", spellAuraRestrictions.ExcludeCasterAuraSpell);
            }

            if (spellAuraRestrictions.ExcludeTargetAuraSpell != 0)
            {
                if (DBC.Spell.ContainsKey(spellAuraRestrictions.ExcludeTargetAuraSpell))
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", spellAuraRestrictions.ExcludeTargetAuraSpell, DBC.Spell[spellAuraRestrictions.ExcludeTargetAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", spellAuraRestrictions.ExcludeTargetAuraSpell);
            }
        }

        private void AuraModTypeName(int index)
        {
            SpellEffectEntry effect = spell.GetEffect(index);
            AuraType aura = (AuraType)effect.EffectApplyAuraName;
            int misc = effect.EffectMiscValue;

            if (effect.EffectApplyAuraName == 0)
            {
                rtb.AppendFormatLineIfNotNull("EffectMiscValueA = {0}", effect.EffectMiscValue);
                rtb.AppendFormatLineIfNotNull("EffectMiscValueB = {0}", effect.EffectMiscValueB);
                rtb.AppendFormatLineIfNotNull("EffectAmplitude = {0}", effect.EffectAmplitude);

                return;
            }

            rtb.AppendFormat("Aura Id {0:D} ({0})", aura);
            rtb.AppendFormat(", value = {0}", effect.EffectBasePoints + 1);
            rtb.AppendFormat(", misc = {0} (", misc);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_STAT:
                    rtb.Append((UnitMods)misc);
                    break;
                case AuraType.SPELL_AURA_MOD_RATING:
                    rtb.Append((CombatRating)misc);
                    break;
                case AuraType.SPELL_AURA_ADD_FLAT_MODIFIER:
                case AuraType.SPELL_AURA_ADD_PCT_MODIFIER:
                    rtb.Append((SpellModOp)misc);
                    break;
                // todo: more case
                default:
                    rtb.Append(misc);
                    break;
            }

            rtb.AppendFormat("), miscB = {0}", effect.EffectMiscValueB);
            rtb.AppendFormatLine(", periodic = {0}", effect.EffectAmplitude);

            switch (aura)
            {
                case AuraType.SPELL_AURA_OVERRIDE_SPELLS:
                    if (!DBC.OverrideSpellData.ContainsKey((uint)misc))
                    {
                        rtb.SetStyle(Color.Red, FontStyle.Bold);
                        rtb.AppendFormatLine("Cannot find key {0} in OverrideSpellData.dbc", (uint)misc);
                    }
                    else
                    {
                        rtb.AppendLine();
                        rtb.SetStyle(Color.DarkRed, FontStyle.Bold);
                        rtb.AppendLine("Overriding Spells:");
                        OverrideSpellDataEntry Override = DBC.OverrideSpellData[(uint)misc];
                        for (int i = 0; i < 10; ++i)
                        {
                            if (Override.Spells[i] == 0)
                                continue;

                            rtb.SetStyle(Color.DarkBlue, FontStyle.Regular);
                            rtb.AppendFormatLine("\t - #{0} ({1}) {2}", i + 1, Override.Spells[i],
                                DBC.Spell.ContainsKey(Override.Spells[i]) ? DBC.Spell[Override.Spells[i]].SpellName : "?????");
                        }
                        rtb.AppendLine();
                    }
                    break;
                case AuraType.SPELL_AURA_SCREEN_EFFECT:
                    rtb.SetStyle(Color.DarkBlue, FontStyle.Bold);
                    rtb.AppendFormatLine("ScreenEffect: {0}",
                        DBC.ScreenEffect.ContainsKey((uint)misc) ? DBC.ScreenEffect[(uint)misc].Name : "?????");
                    break;
                default:
                    break;
            }
        }

        private void AppendItemInfo()
        {
            if (!MySQLConnect.Connected)
                return;

            var items = from item in DBC.ItemTemplate
                        where item.SpellID.ContainsElement(spell.ID)
                        select item;

            if (items.Count() == 0)
                return;

            rtb.AppendLine(_line);
            rtb.SetStyle(Color.Blue, FontStyle.Bold);
            rtb.AppendLine("Items used this spell:");
            rtb.SetDefaultStyle();

            foreach (Item item in items)
            {
                string name = item.LocalesName == string.Empty ? item.Name : item.LocalesName;
                string desc = item.LocalesDescription == string.Empty ? item.Description : item.LocalesDescription;

                desc = desc == string.Empty ? string.Empty : string.Format("({0})", desc);

                rtb.AppendFormatLine(@"   {0} - {1} {2} ", item.Entry, name, desc);
            }
        }
    }
}
