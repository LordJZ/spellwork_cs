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
            _cbSpellFamily.SetEnumValues<SpellFamilyNames>("SpellFamilyName");
            _cbSpellAura.SetEnumValues<AuraType>("Aura");
            _cbSpellEffect.SetEnumValues<SpellEffects>("Effect");
            _cbTarget1.SetEnumValues<Targets>("Target A");
            _cbTarget2.SetEnumValues<Targets>("Target B");
        }

        public SpellEntry Spell { get; set; }

        private void _tbIdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _spellCachedList1.Clear();

                string name = _tbIdName.Text;
                uint id = name.ToUInt32();
                uint ic = _tbIcon.Text.ToUInt32();
                uint at = _tbAttribute.Text.ToUInt32();

                _spellList1 = (from spell in DBC.Spell.Values
                            where ((id == 0 || spell.ID == id)

                                && (ic == 0 || spell.SpellIconID == ic)

                                && (at == 0 || (spell.Attributes & at)    != 0
                                            || (spell.AttributesEx & at)  != 0
                                            || (spell.AttributesEx2 & at) != 0
                                            || (spell.AttributesEx3 & at) != 0
                                            || (spell.AttributesEx4 & at) != 0
                                            || (spell.AttributesEx5 & at) != 0
                                            || (spell.AttributesEx6 & at) != 0
                                            || (spell.AttributesExG & at) != 0))

                                && ((id != 0 || ic != 0 && at != 0) || Extensions.ContainText(spell.SpellName, name))

                            select spell).ToList();
                _lvSpellList.VirtualListSize = _spellList1.Count();
                groupBox1.Text = "Spell Search " + "count: " + _spellList1.Count();
            }
        }

        private void _cbSpellFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                _spellCachedList1.Clear();

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

                _spellList1 = (from spell in DBC.Spell.Values
                            where (!bFamilyNames || spell.SpellFamilyName             == fFamilyNames)

                               && (!bSpellAura   || spell.EffectApplyAuraName[0]      == fSpellAura
                                                 || spell.EffectApplyAuraName[1]      == fSpellAura
                                                 || spell.EffectApplyAuraName[2]      == fSpellAura)

                               && (!bSpellEffect || spell.Effect[0]                   == fSpellEffect
                                                 || spell.Effect[1]                   == fSpellEffect
                                                 || spell.Effect[2]                   == fSpellEffect)

                               && (!bTarget1     || spell.EffectImplicitTargetA[0]    == fTarget1
                                                 || spell.EffectImplicitTargetA[1]    == fTarget1
                                                 || spell.EffectImplicitTargetA[2]    == fTarget1)

                               && (!bTarget2     || spell.EffectImplicitTargetB[0]    == fTarget2
                                                 || spell.EffectImplicitTargetB[1]    == fTarget2
                                                 || spell.EffectImplicitTargetB[2]    == fTarget2)

                            select spell).ToList();

                _lvSpellList.VirtualListSize = _spellList1.Count();
                groupBox2.Text = "Spell Filter " + "count: " + _spellList1.Count();
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedIndices.Count > 0)
                new SpellInfo(_rtbSpellInfo, _spellList1[_lvSpellList.SelectedIndices[0]]);
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedIndices.Count > 0)
            {
                Spell = _spellList1[_lvSpellList.SelectedIndices[0]];
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void _bCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region VIRTUAL MODE

        private List<SpellEntry> _spellList1 = new List<SpellEntry>();
        private Dictionary<int, ListViewItem> _spellCachedList1 = new Dictionary<int, ListViewItem>();

        private void _lvSpellList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = _spellCachedList1.ContainsKey(e.ItemIndex) ? _spellCachedList1[e.ItemIndex] : CreateSpellItem(e.ItemIndex);
        }

        private void _lvSpellList_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (_spellCachedList1.ContainsKey(e.StartIndex) && _spellCachedList1.ContainsKey(e.EndIndex)) return;

            for (int i = 0; i < (e.EndIndex - e.StartIndex + 1); ++i)
            {
                if (_spellCachedList1.ContainsKey(e.StartIndex + i)) continue;
                _spellCachedList1.Add(e.StartIndex + i, CreateSpellItem(e.StartIndex + i));
            }
        }

        private ListViewItem CreateSpellItem(int index)
        {
            return new ListViewItem(new[] { _spellList1[index].ID.ToString(), _spellList1[index].SpellNameRank });
        }

        #endregion
    }
}
