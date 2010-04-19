using System;
using System.Linq;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            _cbSpellFamilyName.SetEnumValues(typeof(SpellFamilyNames), "SpellFamilyName", "SPELLFAMILY_");
            _cbSpellAura.SetEnumValues(typeof(AuraType), "Aura", "SPELL_AURA_");
            _cbSpellEffect.SetEnumValues(typeof(SpellEffects), "Effect", "SPELL_EFFECT_");
            _cbTarget1.SetEnumValues(typeof(Targets), "Target A", "TARGET_");
            _cbTarget2.SetEnumValues(typeof(Targets), "Target B", "TARGET_");

            _cbProcSpellFamilyName.SetEnumValues(typeof(SpellFamilyNames), "SpellFamilyName");
            _cbProcSpellAura.SetEnumValues(typeof(AuraType), "Aura");
            _cbProcSpellEffect.SetEnumValues(typeof(SpellEffects), "Effect");
            _cbProcTarget1.SetEnumValues(typeof(Targets), "Target A");
            _cbProcTarget2.SetEnumValues(typeof(Targets), "Target B");

            _cbProcSpellFamilyTree.SetEnumValues(typeof(SpellFamilyNames), "SpellFamilyTree");
            _cbProcFitstSpellFamily.SetEnumValues(typeof(SpellFamilyNames), "SpellFamilyName");

            _clbSchools.SetFlags(typeof(SpellSchools));
            _clbProcFlags.SetFlags(typeof(ProcFlags), "PROC_FLAG_");
            _clbProcFlagEx.SetFlags(typeof(ProcFlagsEx), "PROC_EX_");

            _status.Text = String.Format("DBC Locale: {0}", DBC.Locale);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 128;
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
                lv.Items.Add(new ListViewItem(new String[] 
                { 
                    element.Key.ToString(), 
                    element.Value.SpellNameRank
                }));
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var id = lv.SelectedItems[0].SubItems[0].Text.ToUInt32();
                SpellInfo.View(_rtSpellInfo, id);
            }
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
            ProcInfo.BuildFamilyTree(_tvFamilyTree, spellfamily);
        }

        private void _cbProcFlag_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = ((CheckBox)sender).Checked ? 240 : 128;
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
                lv.Items.Add(new ListViewItem(new String[] 
                { 
                    element.Key.ToString(), 
                    element.Value.SpellNameRank 
                }));
            }
        }

        private void _tvFamilyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = ((TreeView)sender).SelectedNode;
            if (node.Level > 0)
                SpellInfo.View(_rtbProcSpellInfo, node.Name.ToUInt32());
        }

        private void _tsmSettings_Click(object sender, EventArgs e)
        {
            SettingsForm frm = new SettingsForm();
            frm.ShowDialog(this);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbProcFlag.Visible = _bWrite.Visible = ((TabControl)sender).SelectedIndex == 1;
        }

        private void _lvProcSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
                var id = lv.SelectedItems[0].SubItems[0].Text.ToUInt32();
                SpellInfo.View(_rtbProcSpellInfo, id);

                var result = (from s in DBC.Spell where s.Key == id select s.Value.SpellFamilyName).First();
                _cbProcSpellFamilyTree.SelectedValue = result;

                var spell = DBC.Spell[id];
                _clbProcFlags.SetCheckedItemFromFlag(spell.ProcFlags);
                _clbProcFlagEx.SetCheckedItemFromFlag(spell.ProcFlags); // необходимо указать поле
                _clbSchools.SetCheckedItemFromFlag(spell.SchoolMask);
                _cbProcFitstSpellFamily.SelectedValue = spell.SpellFamilyName;
                //_tbPPM.Text = spell.;   // необходимо указать поле
                _tbChance.Text = spell.ProcChance.ToString();
                _tbCooldown.Text = (spell.RecoveryTime/1000f).ToString();
            }
        }
    }
}
