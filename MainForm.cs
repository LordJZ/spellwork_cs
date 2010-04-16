using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SpellWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            Loads();
        }

        private void Loads()
        {
            SetEnumValues(_cbSpellFamilyNames, typeof(SpellFamilyNames));
            SetEnumValues(_cbSpellAura, typeof(AuraType));
            SetEnumValues(_cbSpellEffect, typeof(SpellEffects));
            SetEnumValues(_cbTarget1, typeof(Targets));
            SetEnumValues(_cbTarget2, typeof(Targets));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 52;
        }

        private void SetEnumValues(ComboBox cb, Type enums)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new Object[] { -1, "No filter" });

            foreach (var str in Enum.GetValues(enums))
            {
                dt.Rows.Add(new Object[] { (int)str, "(" + ((int)str).ToString("000") + ")" + str });
            }

            cb.DataSource = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember = "ID";
        }

        private bool ContainText(String text, String str)
        {
            return (text.ToUpper().IndexOf(str.ToUpper(), StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        private void _bSearch_Click(object sender, EventArgs e)
        {
            _lvSpellList.Items.Clear();

            var query =
                from spell in DBC.Spell
                where (spell.Key.ToString() == _tbSearch.Text)
                  || ContainText(spell.Value.SpellName, _tbSearch.Text)
                select spell;

            if (query.Count() == 0) return;

            foreach (var element in query)
            {
                var id = element.Key.ToString();
                var name = element.Value.SpellName;
                var rank = element.Value.Rank;

                _lvSpellList.Items.Add(new ListViewItem(new String[] { id, name + " (" + rank + ")" }));
            }
        }

        private void _cbSpellFamilyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                // todo: more ex
                DataView("");
            }
        }

        private void DataView(string index)
        {
            _lvSpellList.Items.Clear();

            var bFamilyNames = _cbSpellFamilyNames.SelectedIndex != 0;
            var fFamilyNames = int.Parse(_cbSpellFamilyNames.SelectedValue.ToString());

            var bSpellAura = _cbSpellAura.SelectedIndex != 0;
            var fSpellAura = int.Parse(_cbSpellAura.SelectedValue.ToString());

            var bSpellEffect = _cbSpellEffect.SelectedIndex != 0;
            var fSpellEffect = int.Parse(_cbSpellEffect.SelectedValue.ToString());

            var bTarget1 = _cbTarget1.SelectedIndex != 0;
            var fTarget1 = int.Parse(_cbTarget1.SelectedValue.ToString());

            var bTarget2 = _cbTarget2.SelectedIndex != 0;
            var fTarget2 = int.Parse(_cbTarget2.SelectedValue.ToString());

            var query = from spell in DBC.Spell
                        where (!bFamilyNames || spell.Value.SpellFamilyName == fFamilyNames)
                           && (!bSpellAura || spell.Value.EffectApplyAuraName[0] == fSpellAura
                                             || spell.Value.EffectApplyAuraName[1] == fSpellAura
                                             || spell.Value.EffectApplyAuraName[2] == fSpellAura)
                           && (!bSpellEffect || spell.Value.Effect[0] == fSpellEffect
                                             || spell.Value.Effect[1] == fSpellEffect
                                             || spell.Value.Effect[2] == fSpellEffect)
                           && (!bTarget1 || spell.Value.EffectImplicitTargetA[0] == fTarget1
                                             || spell.Value.EffectImplicitTargetA[1] == fTarget1
                                             || spell.Value.EffectImplicitTargetA[2] == fTarget1)
                           && (!bTarget2 || spell.Value.EffectImplicitTargetB[0] == fTarget2
                                             || spell.Value.EffectImplicitTargetB[1] == fTarget2
                                             || spell.Value.EffectImplicitTargetB[2] == fTarget2)

                        select spell;

            if (query.Count() == 0) 
                return;

            foreach (var element in query)
            {
                var id = element.Key.ToString();
                var name = element.Value.SpellName;
                var rank = element.Value.Rank;

                _lvSpellList.Items.Add(new ListViewItem(new String[] { id, name + " (" + rank + ")" }));
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedItems.Count > 0)
            {
                SpellInfo.View(_rtSpellInfo, uint.Parse(((ListView)sender).SelectedItems[0].SubItems[0].Text));
            }
        }

        private void _bProc_Click(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 70;
            //splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
        }

        private void _bSpellInfo_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            _bProc.Visible = _bSpellInfo.Visible = tabControl1.SelectedIndex == 1;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tvFamilyMask.Nodes.Clear();

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
                // test
                if (i < 64)
                {
                    node.Nodes.Add("2222222222222");
                    node.Nodes.Add("3333333333333");
                }

                _tvFamilyMask.Nodes.Add(node);
            }
        }

        private void _cbProcFlag_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = ((CheckBox)sender).Checked ? 160 : 52;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void _tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _tsmAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}
