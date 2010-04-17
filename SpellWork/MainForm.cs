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
            SetEnumValues(_cbSpellFamilyName, typeof(SpellFamilyNames));
            SetEnumValues(_cbSpellAura, typeof(AuraType));
            SetEnumValues(_cbSpellEffect, typeof(SpellEffects));
            SetEnumValues(_cbTarget1, typeof(Targets));
            SetEnumValues(_cbTarget2, typeof(Targets));

            SetEnumValues(_cbProcSpellFamilyName, typeof(SpellFamilyNames));
            SetEnumValues(_cbProcSpellAura, typeof(AuraType));
            SetEnumValues(_cbProcSpellEffect, typeof(SpellEffects));
            SetEnumValues(_cbProcTarget1, typeof(Targets));
            SetEnumValues(_cbProcTarget2, typeof(Targets));

            SetEnumValues(_cbProcSpellFamilyTree, typeof(SpellFamilyNames));
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
                dt.Rows.Add(new Object[] { (int)str, "(" + ((int)str).ToString("000") + ") " + str });
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
            var b = (Button)sender;
            if (b.Name == "_bSearch")
                Search(_lvSpellList, _tbSearch);
            else if (b.Name == "_bProcSearch")
                Search(_lvProcSpellList, _tbProcSeach);
        }

        private void _cbSpellFamilyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
            {
                ListView lv = tabControl1.SelectedIndex == 0 ? _lvSpellList : _lvProcSpellList;
                GetList(lv);
            }
        }

        private void GetList(ListView lv)
        {
            lv.Items.Clear();
            var firstPage = tabControl1.SelectedIndex == 0;

            var SpellFamilyName = firstPage ? _cbSpellFamilyName : _cbProcSpellFamilyName;
            var bFamilyNames = SpellFamilyName.SelectedIndex != 0;
            var fFamilyNames = SpellFamilyName.SelectedValue.ToInt32();

            var SpellAura = firstPage ? _cbSpellAura : _cbProcSpellAura;
            var bSpellAura = SpellAura.SelectedIndex != 0;
            var fSpellAura = SpellAura.SelectedValue.ToInt32();

            var SpellEffect = firstPage ? _cbSpellEffect : _cbProcSpellEffect;
            var bSpellEffect = SpellEffect.SelectedIndex != 0;
            var fSpellEffect = SpellEffect.SelectedValue.ToInt32();

            var Target1 = firstPage ? _cbTarget1 : _cbProcTarget1;
            var bTarget1 = Target1.SelectedIndex != 0;
            var fTarget1 = Target1.SelectedValue.ToInt32();

            var Target2 = firstPage ? _cbTarget2 : _cbProcTarget2;
            var bTarget2 = Target2.SelectedIndex != 0;
            var fTarget2 = Target2.SelectedValue.ToInt32();

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
                var rank = element.Value.Rank != "" ? " ("+element.Value.Rank +")" : "";

                lv.Items.Add(new ListViewItem(new String[] { id, name + rank}));
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var rtb = lv.Name == "_lvSpellList" ? _rtSpellInfo : _rtbProcSpellInfo;
                var id = lv.SelectedItems[0].SubItems[0].Text.ToUInt32();
                SpellInfo.View(rtb, id);
                if (lv.Name == "_lvProcSpellList")
                {
                    var result = (from s in DBC.Spell where s.Key == id select s.Value.SpellFamilyName).First();
                    _cbProcSpellFamilyTree.SelectedValue = result;
                }
            }
        }

        private void _bProc_Click(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 70;
        }

        private void _bSpellInfo_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sen = ((ComboBox)sender);
            if ((int)sen.SelectedIndex == 0)
                return;
            _tvFamilyTree.Nodes.Clear();
            var spellfamily = (SpellFamilyNames)int.Parse(sen.SelectedValue.ToString());
            SpellInfo.BuildFamilyTree(_tvFamilyTree, spellfamily);
        }

        private void _cbProcFlag_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = ((CheckBox)sender).Checked ? 160 : 52;
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

        private void _tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (tb.Name == "_tbSearch")
                    Search(_lvSpellList, tb);
                else if (tb.Name == "_tbProcSeach")
                    Search(_lvProcSpellList, tb);
            }
        }

        private void Search(ListView lv, TextBox tb)
        {
            lv.Items.Clear();

            var query =
                from spell in DBC.Spell
                where (spell.Key.ToString() == tb.Text)
                  || ContainText(spell.Value.SpellName, tb.Text)
                select spell;

            if (query.Count() == 0) return;

            foreach (var element in query)
            {
                var id = element.Key.ToString();
                var name = element.Value.SpellName;
                var rank = element.Value.Rank != "" ? " (" + element.Value.Rank + ")" : "";

                lv.Items.Add(new ListViewItem(new String[] { id, name + rank }));
            }
        }

        private void _tvFamilyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = ((TreeView)sender).SelectedNode;
            if (node.Level > 0)
                SpellInfo.View(_rtbProcSpellInfo, node.Name.ToUInt32());
        }
    }
}
