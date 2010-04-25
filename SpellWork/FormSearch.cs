using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            // load items to control's
            _cbSpellFamily.SetEnumValues(typeof(SpellFamilyNames), "SpellFamilyName");
            _cbSpellAura.SetEnumValues(typeof(AuraType), "Aura");
            _cbSpellEffect.SetEnumValues(typeof(SpellEffects), "Effect");
            _cbTarget1.SetEnumValues(typeof(Targets), "Target A");
            _cbTarget2.SetEnumValues(typeof(Targets), "Target B");
        }

        public SpellEntry Spell { get; set; }

        private void _tbIdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _lvSpellList.Items.Clear();

                string name = _tbIdName.Text;
                uint id = name.ToUInt32();
                uint ic = _tbIcon.Text.ToUInt32();
                uint at = _tbAttribute.Text.ToUInt32();

                var query = from spell in DBC.Spell
                            where ((id == 0 || spell.Key == id)

                                && (ic == 0 || spell.Value.SpellIconID == ic)

                                && (at == 0 || (spell.Value.Attributes & at)    != 0
                                            || (spell.Value.AttributesEx & at)  != 0
                                            || (spell.Value.AttributesEx2 & at) != 0
                                            || (spell.Value.AttributesEx3 & at) != 0
                                            || (spell.Value.AttributesEx4 & at) != 0
                                            || (spell.Value.AttributesEx5 & at) != 0
                                            || (spell.Value.AttributesEx6 & at) != 0
                                            || (spell.Value.AttributesExG & at) != 0))

                                && ((id != 0 || ic != 0 && at != 0) || Extensions.ContainText(spell.Value.SpellName, name))

                            select spell;

                if (query.Count() == 0) return;
                groupBox1.Text = "Spell Search " + "count: " + query.Count();

                foreach (var element in query)
                {
                    _lvSpellList.Items.Add(new ListViewItem(new String[] 
                    { 
                        element.Key.ToString(), 
                        element.Value.SpellNameRank 
                    }));
                }
            }
        }

        private void _cbSpellFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                _lvSpellList.Items.Clear();

                var bFamilyNames = _cbSpellFamily.SelectedIndex != 0;
                var fFamilyNames = _cbSpellFamily.SelectedValue.ToInt32();

                var bSpellAura = _cbSpellAura.SelectedIndex != 0;
                var fSpellAura = _cbSpellAura.SelectedValue.ToInt32();

                var bSpellEffect = _cbSpellEffect.SelectedIndex != 0;
                var fSpellEffect = _cbSpellEffect.SelectedValue.ToInt32();

                var bTarget1 = _cbTarget1.SelectedIndex != 0;
                var fTarget1 = _cbTarget1.SelectedValue.ToInt32();

                var bTarget2 = _cbTarget2.SelectedIndex != 0;
                var fTarget2 = _cbTarget2.SelectedValue.ToInt32();

                var query = from spell in DBC.Spell
                            where (!bFamilyNames || spell.Value.SpellFamilyName             == fFamilyNames)
                               && (!bSpellAura   || spell.Value.EffectApplyAuraName[0]      == fSpellAura
                                                 || spell.Value.EffectApplyAuraName[1]      == fSpellAura
                                                 || spell.Value.EffectApplyAuraName[2]      == fSpellAura)
                               && (!bSpellEffect || spell.Value.Effect[0]                   == fSpellEffect
                                                 || spell.Value.Effect[1]                   == fSpellEffect
                                                 || spell.Value.Effect[2]                   == fSpellEffect)
                               && (!bTarget1     || spell.Value.EffectImplicitTargetA[0]    == fTarget1
                                                 || spell.Value.EffectImplicitTargetA[1]    == fTarget1
                                                 || spell.Value.EffectImplicitTargetA[2]    == fTarget1)
                               && (!bTarget2     || spell.Value.EffectImplicitTargetB[0]    == fTarget2
                                                 || spell.Value.EffectImplicitTargetB[1]    == fTarget2
                                                 || spell.Value.EffectImplicitTargetB[2]    == fTarget2)

                            select spell;

                if (query.Count() == 0)
                    return;
                groupBox2.Text = "Spell Filter " + "count: " + query.Count();
                foreach (var element in query)
                {
                    _lvSpellList.Items.Add(new ListViewItem(new String[] 
                { 
                    element.Key.ToString(), 
                    element.Value.SpellNameRank
                }));
                }
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var id = lv.SelectedItems[0].SubItems[0].Text.ToUInt32();
                SpellInfo.ViewSpellInfo(_rtbSpellInfo, DBC.Spell[id]);
            }
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedItems.Count > 0)
            {
                uint index = _lvSpellList.SelectedItems[0].SubItems[0].Text.ToUInt32();
                Spell = DBC.Spell[index];
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void _bCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
