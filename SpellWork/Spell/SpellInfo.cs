using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace SpellWork
{
    class SpellInfo
    {
        private RichTextBox  rtb;
        private SpellEntry spell;

        private const string _line = "=================================================";

        public SpellInfo(RichTextBox rtb, SpellEntry spell)
        {
            this.rtb = rtb;
            this.spell = spell;
            
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
            rtb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", spell.ModalNextSpell);
            if (spell.Description != string.Empty && spell.ToolTip != string.Empty && spell.ModalNextSpell != 0)
                rtb.AppendFormatLine(_line);

            rtb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3},{4})",
                spell.Category, spell.SpellIconID, spell.ActiveIconID, spell.SpellVisual[0], spell.SpellVisual[1]);

            rtb.AppendFormatLine("Family {0}, flag 0x{1:X8} {2:X8} {3:X8}",
                (SpellFamilyNames)spell.SpellFamilyName, spell.SpellFamilyFlags[2], spell.SpellFamilyFlags[1], spell.SpellFamilyFlags[0]);

            rtb.AppendLine();

            rtb.AppendFormatLine("SpellSchoolMask = {0} ({1})", spell.SchoolMask, spell.School);
            rtb.AppendFormatLine("DamageClass = {0} ({1})", spell.DmgClass, (SpellDmgClass)spell.DmgClass);
            rtb.AppendFormatLine("PreventionType = {0} ({1})", spell.PreventionType, (SpellPreventionType)spell.PreventionType);

            if (spell.Attributes != 0 || spell.AttributesEx != 0 || spell.AttributesEx2 != 0 || spell.AttributesEx3 != 0
                || spell.AttributesEx4 != 0 || spell.AttributesEx5 != 0 || spell.AttributesEx6 != 0 || spell.AttributesEx7 != 0)
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
            if (spell.AttributesEx7 != 0)
                rtb.AppendFormatLine("AttributesEx7: 0x{0:X8} ({1})", spell.AttributesEx7, (SpellAtributeEx7)spell.AttributesEx7);

            rtb.AppendLine(_line);

            if (spell.Targets != 0)
                rtb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", spell.Targets, (SpellCastTargetFlags)spell.Targets);

            if (spell.TargetCreatureType != 0)
                rtb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})",
                    spell.TargetCreatureType, (CreatureTypeMask)spell.TargetCreatureType);

            if (spell.Stances != 0)
                rtb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)spell.Stances);

            if (spell.StancesNot != 0)
                rtb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)spell.StancesNot);

            AppendSkillLine();

            // reagents
            {
                bool printedHeader = false;
                for (int i = 0; i < spell.Reagent.Length; ++i)
                {
                    if (spell.Reagent[i] == 0)
                        continue;

                    if (!printedHeader)
                    {
                        rtb.AppendLine();
                        rtb.Append("Reagents:");
                        printedHeader = true;
                    }

                    rtb.AppendFormat("  {0}x{1}", spell.Reagent[i], spell.ReagentCount[i]);
                }

                if (printedHeader)
                    rtb.AppendLine();
            }

            rtb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, maxTarget {3}",
                spell.SpellLevel, spell.BaseLevel, spell.MaxLevel, spell.MaxTargetLevel);

            if (spell.EquippedItemClass != -1)
            {
                rtb.AppendFormatLine("EquippedItemClass = {0} ({1})", spell.EquippedItemClass, (ItemClass)spell.EquippedItemClass);

                if (spell.EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)spell.EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spell.EquippedItemSubClassMask, (ItemSubClassWeaponMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spell.EquippedItemSubClassMask, (ItemSubClassArmorMask)spell.EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})",
                                spell.EquippedItemSubClassMask, (ItemSubClassMiscMask)spell.EquippedItemSubClassMask);
                            break;
                    }
                }

                if (spell.EquippedItemInventoryTypeMask != 0)
                    rtb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})",
                        spell.EquippedItemInventoryTypeMask, (InventoryTypeMask)spell.EquippedItemInventoryTypeMask);
            }

            rtb.AppendLine();
            rtb.AppendFormatLine("Category = {0}", spell.Category);
            rtb.AppendFormatLine("DispelType = {0} ({1})", spell.Dispel, (DispelType)spell.Dispel);
            rtb.AppendFormatLine("Mechanic = {0} ({1})", spell.Mechanic, (Mechanics)spell.Mechanic);

            rtb.AppendLine(spell.Range);

            rtb.AppendFormatLineIfNotNull("Speed {0:F}", spell.Speed);
            rtb.AppendFormatLineIfNotNull("Stackable up to {0}", spell.StackAmount);

            rtb.AppendLine(spell.CastTime);

            rtb.AppendLine(spell.SpellDifficulty);

            if (spell.RecoveryTime != 0 || spell.CategoryRecoveryTime != 0 || spell.StartRecoveryCategory != 0)
            {
                rtb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", spell.RecoveryTime, spell.CategoryRecoveryTime);
                rtb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", spell.StartRecoveryCategory, spell.StartRecoveryTime);
            }

            rtb.AppendLine(spell.Duration);

            if (spell.ManaCost != 0 || spell.ManaCostPercentage != 0)
            {
                rtb.AppendFormat("Power {0}, Cost {1}",
                    (Powers)spell.PowerType, spell.ManaCost == 0 ? spell.ManaCostPercentage.ToString() + " %" : spell.ManaCost.ToString());
                rtb.AppendFormatIfNotNull(" + lvl * {0}", spell.ManaCostPerlevel);
                rtb.AppendFormatIfNotNull(" + {0} Per Second", spell.ManaPerSecond);
                rtb.AppendFormatIfNotNull(" + lvl * {0}", spell.ManaPerSecondPerLevel);
                rtb.AppendLine();
            }
            
            
            if (spell.RuneCostID!=0 && DBC.SpellRuneCostTable.ContainsKey(spell.RuneCostID))
            { 
                 SpellRuneCostEntry R=DBC.SpellRuneCostTable[spell.RuneCostID];
               
                 bool append=true;
                 for (uint i=0;i<R.RuneCost.Length;i++)
                 {
                    if (R.RuneCost[i]!=0)
                    { 
                      if (append)
                        {
                          rtb.AppendLine(_line);
                          rtb.Append("Rune cost: ");
                        }
                      rtb.AppendFormat("{0}x{1} ",(RuneType)i,  R.RuneCost[i]);
                      append=false;
                      }
                 }
                 
				 if (!append)
                   rtb.AppendLine();
 				 
                 rtb.AppendFormatLineIfNotNull("Rune power gain ={0}",R.runePowerGain);
                 if (!append)
                   rtb.AppendLine(_line);
            }

            rtb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8}, ChannelIF 0x{2:X8}",
                spell.InterruptFlags, spell.AuraInterruptFlags, spell.ChannelInterruptFlags);

            if (spell.CasterAuraState != 0)
                rtb.AppendFormatLine("CasterAuraState = {0} ({1})", spell.CasterAuraState, (AuraState)spell.CasterAuraState);

            if (spell.TargetAuraState != 0)
                rtb.AppendFormatLine("TargetAuraState = {0} ({1})", spell.TargetAuraState, (AuraState)spell.TargetAuraState);

            if (spell.CasterAuraStateNot != 0)
                rtb.AppendFormatLine("CasterAuraStateNot = {0} ({1})", spell.CasterAuraStateNot, (AuraState)spell.CasterAuraStateNot);

            if (spell.TargetAuraStateNot != 0)
                rtb.AppendFormatLine("TargetAuraStateNot = {0} ({1})", spell.TargetAuraStateNot, (AuraState)spell.TargetAuraStateNot);

            AppendSpellAura();

            AppendAreaInfo();

            rtb.AppendFormatLineIfNotNull("Requires Spell Focus {0}", spell.RequiresSpellFocus);

            if (spell.ProcFlags != 0)
            {
                rtb.SetBold();
                rtb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                spell.ProcFlags, spell.ProcChance, spell.ProcCharges);
                rtb.SetDefaultStyle();
                rtb.AppendFormatLine(_line);
                rtb.AppendText(spell.ProcInfo);
            }
            else
            {
                rtb.AppendFormatLine("Chance = {0}, charges - {1}", spell.ProcChance, spell.ProcCharges);
            }

            AppendSpellEffectInfo();
            AppendItemInfo();
        }

        private void AppendAreaInfo()
        {
            if (spell.AreaGroupId <= 0)
                return;

            var areaGroupId = (uint)spell.AreaGroupId;
            if (!DBC.AreaGroup.ContainsKey(areaGroupId))
            {
                rtb.AppendFormatLine("Cannot find area group id {0} in AreaGroup.dbc!", spell.AreaGroupId);
                return;
            }

            rtb.AppendLine();
            rtb.SetBold();
            rtb.AppendLine("Allowed areas:");
            while (DBC.AreaGroup.ContainsKey(areaGroupId))
            {
                var groupEntry = DBC.AreaGroup[areaGroupId];
                for (var i = 0; i < 6; ++i)
                {
                    var areaId = groupEntry.AreaId[i];
                    if (DBC.AreaTable.ContainsKey(areaId))
                    {
                        var areaEntry = DBC.AreaTable[areaId];
                        rtb.AppendFormatLine("{0} - {1} (Map: {2})", areaId, areaEntry.Name, areaEntry.MapId);
                    }
                }


                if (groupEntry.NextGroup == 0)
                    break;

                // Try search in next group
                areaGroupId = groupEntry.NextGroup;
            }

            rtb.AppendLine();
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
            var line =  query.First().skillLine.Value;

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
                rtb.SetBold();
                if ((SpellEffects)spell.Effect[EFFECT_INDEX] == SpellEffects.NO_SPELL_EFFECT)
                {
                    rtb.AppendFormatLine("Effect {0}:  NO EFFECT", EFFECT_INDEX);
                    rtb.AppendLine();
                    continue;
                }

                rtb.AppendFormatLine("Effect {0}: Id {1} ({2})", EFFECT_INDEX, spell.Effect[EFFECT_INDEX], (SpellEffects)spell.Effect[EFFECT_INDEX]);
                rtb.SetDefaultStyle();
                rtb.AppendFormat("BasePoints = {0}", spell.EffectBasePoints[EFFECT_INDEX] + 1);
                
                if (spell.EffectRealPointsPerLevel[EFFECT_INDEX] != 0)
                    rtb.AppendFormat(" + Level * {0:F}", spell.EffectRealPointsPerLevel[EFFECT_INDEX]);

                // WTF ? 1 = spell.EffectBaseDice[i]
                if (1 < spell.EffectDieSides[EFFECT_INDEX])
                {
                    if (spell.EffectRealPointsPerLevel[EFFECT_INDEX] != 0)
                        rtb.AppendFormat(" to {0} + lvl * {1:F}",
                            spell.EffectBasePoints[EFFECT_INDEX] + 1 + spell.EffectDieSides[EFFECT_INDEX], spell.EffectRealPointsPerLevel[EFFECT_INDEX]);
                    else
                        rtb.AppendFormat(" to {0}", spell.EffectBasePoints[EFFECT_INDEX] + 1 + spell.EffectDieSides[EFFECT_INDEX]);
                }

                rtb.AppendFormatIfNotNull(" + combo * {0:F}", spell.EffectPointsPerComboPoint[EFFECT_INDEX]);

                if (spell.DmgMultiplier[EFFECT_INDEX] != 1.0f)
                    rtb.AppendFormat(" x {0:F}", spell.DmgMultiplier[EFFECT_INDEX]);

                rtb.AppendFormatIfNotNull("  Multiple = {0:F}", spell.EffectMultipleValue[EFFECT_INDEX]);
                rtb.AppendLine();

                rtb.AppendFormatLine("Targets ({0}, {1}) ({2}, {3})",
                    spell.EffectImplicitTargetA[EFFECT_INDEX], spell.EffectImplicitTargetB[EFFECT_INDEX],
                    (Targets)spell.EffectImplicitTargetA[EFFECT_INDEX], (Targets)spell.EffectImplicitTargetB[EFFECT_INDEX]);

                AuraModTypeName(EFFECT_INDEX);

                uint[] ClassMask = new uint[3];
               
                switch (EFFECT_INDEX)
                {
                    case 0: ClassMask = spell.EffectSpellClassMaskA; break;
                    case 1: ClassMask = spell.EffectSpellClassMaskB; break;
                    case 2: ClassMask = spell.EffectSpellClassMaskC; break;
                }

                if (ClassMask[0] != 0 || ClassMask[1] != 0 || ClassMask[2] != 0)
                {
                    rtb.AppendFormatLine("SpellClassMask = {0:X8} {1:X8} {2:X8}", ClassMask[2], ClassMask[1], ClassMask[0]);

                    var query = from Spell in DBC.Spell.Values
                                where Spell.SpellFamilyName == spell.SpellFamilyName && Spell.SpellFamilyFlags.ContainsElement(ClassMask)
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
                            rtb.SelectionColor = Color.Blue;
                            rtb.AppendFormatLine("\t+ {0} - {1}",  row.SpellID, row.SpellName);
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
                uint trigger = spell.EffectTriggerSpell[EFFECT_INDEX];
                if (trigger != 0)
                {
                    if (DBC.Spell.ContainsKey(trigger))
                    {
                        SpellEntry triggerSpell = DBC.Spell[trigger];
                        rtb.SetStyle(Color.Blue, FontStyle.Bold);
                        rtb.AppendFormatLine("   Trigger spell ({0}) {1}. Chance = {2}", trigger, triggerSpell.SpellNameRank, spell.ProcChance);
                        rtb.AppendFormatLineIfNotNull("   Description: {0}", triggerSpell.Description);
                        rtb.AppendFormatLineIfNotNull("   ToolTip: {0}", triggerSpell.ToolTip);
                        rtb.SetDefaultStyle();
                        if (triggerSpell.ProcFlags != 0)
                        {
                            rtb.AppendFormatLine("Charges - {0}", triggerSpell.ProcCharges);
                            rtb.AppendLine(_line);
                            rtb.AppendLine(triggerSpell.ProcInfo);
                            rtb.AppendLine(_line);
                        }
                    }
                    else
                    {
                        rtb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", trigger, spell.ProcChance);
                    }
                }

                rtb.AppendFormatLineIfNotNull("EffectChainTarget = {0}", spell.EffectChainTarget[EFFECT_INDEX]);
                rtb.AppendFormatLineIfNotNull("EffectItemType = {0}", spell.EffectItemType[EFFECT_INDEX]);

                if((Mechanics)spell.EffectMechanic[EFFECT_INDEX] != Mechanics.MECHANIC_NONE)
                    rtb.AppendFormatLine("Effect Mechanic = {0} ({1})", spell.EffectMechanic[EFFECT_INDEX], (Mechanics)spell.EffectMechanic[EFFECT_INDEX]);

                rtb.AppendLine();
            }
        }

        private void AppendSpellAura()
        {
            if (spell.CasterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.CasterAuraSpell))
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", spell.CasterAuraSpell, DBC.Spell[spell.CasterAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", spell.CasterAuraSpell);
            }

            if (spell.TargetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.TargetAuraSpell))
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) {1}", spell.TargetAuraSpell, DBC.Spell[spell.TargetAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) ?????", spell.TargetAuraSpell);
            }

            if (spell.ExcludeCasterAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.ExcludeCasterAuraSpell))
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", spell.ExcludeCasterAuraSpell, DBC.Spell[spell.ExcludeCasterAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", spell.ExcludeCasterAuraSpell);
            }

            if (spell.ExcludeTargetAuraSpell != 0)
            {
                if(DBC.Spell.ContainsKey(spell.ExcludeTargetAuraSpell))
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", spell.ExcludeTargetAuraSpell, DBC.Spell[spell.ExcludeTargetAuraSpell].SpellName);
                else
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", spell.ExcludeTargetAuraSpell);
            }
        }

        private void AuraModTypeName(int index)
        {
            AuraType aura    = (AuraType)spell.EffectApplyAuraName[index];
            int misc          = spell.EffectMiscValue[index];

            if (spell.EffectApplyAuraName[index] == 0)
            {
                rtb.AppendFormatLineIfNotNull("EffectMiscValueA = {0}", spell.EffectMiscValue[index]);
                rtb.AppendFormatLineIfNotNull("EffectMiscValueB = {0}", spell.EffectMiscValueB[index]);
                rtb.AppendFormatLineIfNotNull("EffectAmplitude = {0}",  spell.EffectAmplitude[index]);
                
                return;
            }

            rtb.AppendFormat("Aura Id {0:D} ({0})", aura);
            rtb.AppendFormat(", value = {0}", spell.EffectBasePoints[index] + 1);
            rtb.AppendFormat(", misc = {0} (", misc);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_STAT:
                case AuraType.SPELL_AURA_MOD_PERCENT_STAT:
                case AuraType.SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE:
                case AuraType.SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_MANA_REGEN_FROM_STAT:
                case AuraType.SPELL_AURA_MOD_ATTACK_POWER_OF_STAT_PERCENT:
                    rtb.Append((UnitMods)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_RATING:
                case AuraType.SPELL_AURA_MOD_RATING_FROM_STAT:
                    rtb.Append((CombatRating)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE:
                case AuraType.SPELL_AURA_MOD_DAMAGE_TAKEN:
                case AuraType.SPELL_AURA_MOD_DAMAGE_PERCENT_DONE:
                case AuraType.SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN:
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_SHARE_DAMAGE_PCT:
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_ATTACK_POWER:
                case AuraType.SPELL_AURA_MOD_AOE_DAMAGE_AVOIDANCE:
                case AuraType.SPELL_AURA_SPLIT_DAMAGE_PCT:
                case AuraType.SPELL_AURA_DAMAGE_IMMUNITY:

                case AuraType.SPELL_AURA_MOD_CRIT_DAMAGE_BONUS:
                case AuraType.SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_DAMAGE:
                case AuraType.SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_DAMAGE:
                case AuraType.SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_DAMAGE:


                case AuraType.SPELL_AURA_MOD_HEALING:
                case AuraType.SPELL_AURA_MOD_HEALING_PCT:
                case AuraType.SPELL_AURA_MOD_HEALING_DONE:
                case AuraType.SPELL_AURA_MOD_HEALING_DONE_PERCENT:
                case AuraType.SPELL_AURA_MOD_DAMAGE_FROM_CASTER:
                case AuraType.SPELL_AURA_MOD_HEALING_RECEIVED:
                case AuraType.SPELL_AURA_MOD_PERIODIC_HEAL:
                case AuraType.SPELL_AURA_MOD_SPELL_HEALING_OF_ATTACK_POWER:

                case AuraType.SPELL_AURA_MOD_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_BASE_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_PCT:
                case AuraType.SPELL_AURA_MOD_TARGET_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT:

                case AuraType.SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_CHANCE:
                case AuraType.SPELL_AURA_MOD_ATTACKER_SPELL_HIT_CHANCE:
                case AuraType.SPELL_AURA_MOD_INCREASES_SPELL_PCT_TO_HIT:

                case AuraType.SPELL_AURA_SCHOOL_IMMUNITY:
                case AuraType.SPELL_AURA_SCHOOL_ABSORB:
                case AuraType.SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL:
                case AuraType.SPELL_AURA_MOD_POWER_COST_SCHOOL_PCT:
                case AuraType.SPELL_AURA_MOD_POWER_COST_SCHOOL:
                case AuraType.SPELL_AURA_REFLECT_SPELLS_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IGNORE_ABSORB_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IMMUNE_AURA_APPLY_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IGNORE_DAMAGE_REDUCTION_SCHOOL:
                case AuraType.SPELL_AURA_MOD_IGNORE_ABSORB_FOR_SPELL:

                case AuraType.SPELL_AURA_MOD_THREAT:
                case AuraType.SPELL_AURA_MOD_CRITICAL_THREAT:

                case AuraType.SPELL_AURA_REDUCE_PUSHBACK:
                case AuraType.SPELL_AURA_MOD_PET_AOE_DAMAGE_AVOIDANCE:
                case AuraType.SPELL_AURA_HASTE_SPELLS:
                case AuraType.SPELL_AURA_MANA_SHIELD:
                case AuraType.SPELL_AURA_MOD_CRITICAL_HEALING_AMOUNT:

                    rtb.Append((SpellSchoolMask)misc);
                    break;
                case AuraType.SPELL_AURA_ADD_FLAT_MODIFIER:
                case AuraType.SPELL_AURA_ADD_PCT_MODIFIER:
                    rtb.Append((SpellModOp)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_POWER_REGEN:
                case AuraType.SPELL_AURA_MOD_POWER_REGEN_PERCENT:
                case AuraType.SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT:
                case AuraType.SPELL_AURA_MOD_INCREASE_ENERGY:
                case AuraType.SPELL_AURA_PERIODIC_ENERGIZE:
                    rtb.Append((Powers)misc);
                    break;

                case AuraType.SPELL_AURA_MECHANIC_IMMUNITY:
                case AuraType.SPELL_AURA_MOD_MECHANIC_RESISTANCE:
                case AuraType.SPELL_AURA_MECHANIC_DURATION_MOD:
                case AuraType.SPELL_AURA_MECHANIC_DURATION_MOD_NOT_STACK:
                case AuraType.SPELL_AURA_MOD_MECHANIC_DAMAGE_TAKEN_PERCENT:

                    rtb.Append((Mechanics)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_MELEE_ATTACK_POWER_VERSUS:
                case AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER_VERSUS:
                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE_VERSUS:
                case AuraType.SPELL_AURA_MOD_CRIT_PERCENT_VERSUS:
                case AuraType.SPELL_AURA_MOD_FLAT_SPELL_DAMAGE_VERSUS:
                case AuraType.SPELL_AURA_MOD_DAMAGE_DONE_CREATURE:
                    rtb.Append((CreatureTypeMask)misc);
                    break;

                case AuraType.SPELL_AURA_TRACK_CREATURES:
                    rtb.Append((CreatureTypeMask)((int)(1 << (misc - 1))));
                    break;

                case AuraType.SPELL_AURA_DISPEL_IMMUNITY:
                case AuraType.SPELL_AURA_MOD_DEBUFF_RESISTANCE:
                case AuraType.SPELL_AURA_MOD_DURATION_OF_MAGIC_EFFECTS:
                case AuraType.SPELL_AURA_MOD_DURATION_OF_EFFECTS_BY_DISPEL:
                    rtb.Append((DispelType)misc);
                    break;

                case AuraType.SPELL_AURA_TRACK_RESOURCES:
                    rtb.Append((LockType)misc);
                    break;

                case AuraType.SPELL_AURA_MOD_SHAPESHIFT:
                    rtb.Append((ShapeshiftFormMask)(1 << (misc-1)));
                    break;

                case AuraType.SPELL_AURA_EFFECT_IMMUNITY:
                    rtb.Append((SpellEffects)misc);
                    break;

                case AuraType.SPELL_AURA_CONVERT_RUNE:
                    rtb.Append((RuneType)misc);
                    break;

                // todo: more case
                default:
                    rtb.Append(misc);
                    break;
            }

            int miscB = spell.EffectMiscValueB[index];
            rtb.AppendFormat("), miscB = {0}", miscB);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT:
                case AuraType.SPELL_AURA_MOD_RATING_FROM_STAT:
                    rtb.AppendFormat("({0})", (UnitMods)miscB);
                    break;
                case AuraType.SPELL_AURA_CONVERT_RUNE:
                    rtb.AppendFormat("({0})", (RuneType)miscB);
                    break;
            }

            rtb.AppendFormatLine(", periodic = {0}", spell.EffectAmplitude[index]);

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
            
            var items = from   item in DBC.ItemTemplate
                        where  item.SpellID.ContainsElement(spell.ID)
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
