using System;
using System.Linq;
using System.Windows.Forms;
using SpellWork.Properties;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SpellWork
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            Text = DBC.VERSION;

            _cbSpellFamilyName.SetEnumValues<SpellFamilyNames>("SpellFamilyName");
            _cbSpellAura.SetEnumValues<AuraType>("Aura");
            _cbSpellEffect.SetEnumValues<SpellEffects>("Effect");
            _cbTarget1.SetEnumValues<Targets>("Target A");
            _cbTarget2.SetEnumValues<Targets>("Target B");

            _cbProcSpellFamilyName.SetEnumValues<SpellFamilyNames>("SpellFamilyName");
            _cbProcSpellAura.SetEnumValues<AuraType>("Aura");
            _cbProcSpellEffect.SetEnumValues<SpellEffects>("Effect");
            _cbProcTarget1.SetEnumValues<Targets>("Target A");
            _cbProcTarget2.SetEnumValues<Targets>("Target B");

            _cbProcSpellFamilyTree.SetEnumValues<SpellFamilyNames>("SpellFamilyTree");
            _cbProcFitstSpellFamily.SetEnumValues<SpellFamilyNames>("SpellFamilyName");

            _clbSchools.SetFlags<SpellSchools>();
            _clbProcFlags.SetFlags<ProcFlags>("PROC_FLAG_");
            _clbProcFlagEx.SetFlags<ProcFlagsEx>("PROC_EX_");

            _cbSqlSpellFamily.SetEnumValues<SpellFamilyNames>("SpellFamilyName");

            _status.Text = String.Format("DBC Locale: {0}", DBC.Locale);

            _cbAdvansedFilter1.SetStructFields<SpellEntry>();
            _cbAdvansedFilter2.SetStructFields<SpellEntry>();

            ConnStatus();
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
            switch (b.Name)
            {
                case "_bSearch":
                    Search(_lvSpellList, _tbSearchId);
                    break;
                case "_bProcSearch":
                    Search(_lvProcSpellList, _tbProcSeach);
                    break;
            }
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
                        where (!bFamilyNames || spell.Value.SpellFamilyName          == fFamilyNames)
                           && (!bSpellAura   || spell.Value.EffectApplyAuraName[0]   == fSpellAura
                                             || spell.Value.EffectApplyAuraName[1]   == fSpellAura
                                             || spell.Value.EffectApplyAuraName[2]   == fSpellAura)
                           && (!bSpellEffect || spell.Value.Effect[0]                == fSpellEffect
                                             || spell.Value.Effect[1]                == fSpellEffect
                                             || spell.Value.Effect[2]                == fSpellEffect)
                           && (!bTarget1     || spell.Value.EffectImplicitTargetA[0] == fTarget1
                                             || spell.Value.EffectImplicitTargetA[1] == fTarget1
                                             || spell.Value.EffectImplicitTargetA[2] == fTarget1)
                           && (!bTarget2     || spell.Value.EffectImplicitTargetB[0] == fTarget2
                                             || spell.Value.EffectImplicitTargetB[1] == fTarget2
                                             || spell.Value.EffectImplicitTargetB[2] == fTarget2)

                        select spell;

            if (query.Count() == 0)
                return;
            //_gSpellFilter.Text = "Spell Filter " + "count: " + query.Count();
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
                SpellInfo.ViewSpellInfo(_rtSpellInfo, DBC.Spell[id]);
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
            FormAboutBox ab = new FormAboutBox();
            ab.ShowDialog();
        }

        private void _tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                switch (tb.Name)
                {
                    case "_tbSearch": 
                        Search(_lvSpellList, tb); 
                        break;
                    case "_tbProcSeach":  
                        Search(_lvProcSpellList, tb); 
                        break;
                }
            }
        }

        private void Search(ListView lv, TextBox tb)
        {
            lv.Items.Clear();
            uint id = tb.Text.ToUInt32();
            var query = from spell in DBC.Spell
                        where (id == 0 || spell.Key == id) 
                           && (id != 0 || ContainText(spell.Value.SpellName, tb.Text))
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
            if (e.Node.Level > 0)
            {
                SpellEntry spell = DBC.Spell[e.Node.Name.ToUInt32()];
                SetProcAtribute(spell);
            }
        }

        private void _tsmSettings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog(this);
            ConnStatus();
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
                SetProcAtribute(DBC.Spell[id]);
            }
        }

        private void SetProcAtribute(SpellEntry spell)
        {
            SpellInfo.ViewSpellInfo(_rtbProcSpellInfo, spell);

            _cbProcSpellFamilyTree.SelectedValue = spell.SpellFamilyName;
            _clbProcFlags.SetCheckedItemFromFlag(spell.ProcFlags);
            _clbSchools.SetCheckedItemFromFlag(spell.SchoolMask);
            _cbProcFitstSpellFamily.SelectedValue = spell.SpellFamilyName;
            _tbPPM.Text = "0"; // need correct value
            _tbChance.Text = spell.ProcChance.ToString();
            _tbCooldown.Text = (spell.RecoveryTime / 1000f).ToString();
        }

        private void GetProcAttribute(SpellEntry spell)
        {
            // test
            var statusproc = String.Format("Spell ({0}) {1}. Proc Event ==> SchoolMask 0x{2:X2}, SpellFamily {3}, 0x{4:X8} {5:X8} {6:X8}, procFlag {7:X8}, PPMRate {8}",
                spell.ID, 
                spell.SpellNameRank, 
                _clbSchools.GetFlagsValue(),
                _cbProcFitstSpellFamily.ValueMember,
                spell.SpellFamilyFlags1,
                spell.SpellFamilyFlags2,
                spell.SpellFamilyFlags3,
                spell.ProcFlags,
                _tbPPM.Text.ToFloat());

            _gSpellProcEvent.Text = "Spell Proc Event       " + statusproc;
        }

        private void _clbSchools_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProcInfo.SpellProc.ID != 0)
            {
                _bWrite.Enabled = true;
                GetProcAttribute(ProcInfo.SpellProc);
            }
        }

        private void _tbSearchId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AdvancedSearch();
            }
        }

        private void _bSearch_Click_1(object sender, EventArgs e)
        {
            AdvancedSearch();
        }

        private void AdvancedSearch()
        {
            _lvSpellList.Items.Clear();

            string name = _tbSearchId.Text;
            uint id = _tbSearchId.Text.ToUInt32();
            uint ic = _tbSearchIcon.Text.ToUInt32();
            uint at = _tbSearchAttributes.Text.ToUInt32();

            var query = from spell in DBC.Spell
                        where ((id == 0 || spell.Key == id) 

                            && (ic == 0 || spell.Value.SpellIconID   == ic)

                            && (at == 0 || (spell.Value.Attributes    & at) != 0
                                        || (spell.Value.AttributesEx  & at) != 0
                                        || (spell.Value.AttributesEx2 & at) != 0
                                        || (spell.Value.AttributesEx3 & at) != 0
                                        || (spell.Value.AttributesEx4 & at) != 0
                                        || (spell.Value.AttributesEx5 & at) != 0
                                        || (spell.Value.AttributesEx6 & at) != 0
                                        || (spell.Value.AttributesExG & at) != 0))

                           && ((id != 0 || ic != 0 && at != 0) || ContainText(spell.Value.SpellName, name))

                        select spell;

            if (query.Count() == 0) return;
            //_gSpellFilter.Text = "Spell Filter " + "count: " + query.Count();

            foreach (var element in query)
            {
                _lvSpellList.Items.Add(new ListViewItem(new String[] 
                    { 
                        element.Key.ToString(), 
                        element.Value.SpellNameRank 
                    }));
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void _bWrite_Click(object sender, EventArgs e)
        {
            // spell comment
            var comment = String.Format("-- ({0}) {1}", ProcInfo.SpellProc.ID, ProcInfo.SpellProc.SpellNameRank);
            // drop query
            var drop = String.Format("DELETE FROM `spell_proc_event` WHERE `entry` IN ({0});", ProcInfo.SpellProc.ID);
            // insert query
            var insert = String.Format("INSERT INTO `spell_proc_event` VALUES ({0}, 0x{1:X2}, {2}, 0x{3:X8}, 0x{4:X8}, 0x{5:X8}, 0x{6:X8}, 0x{7:X8}, {8}, {9}, {10});",
                ProcInfo.SpellProc.ID, 
                _clbSchools.GetFlagsValue(), 
                _cbProcFitstSpellFamily.ValueMember.ToUInt32(), 
                ProcInfo.SpellProc.SpellFamilyFlags1,
                ProcInfo.SpellProc.SpellFamilyFlags2,
                ProcInfo.SpellProc.SpellFamilyFlags3,
                _clbProcFlags.GetFlagsValue(), 
                _clbProcFlagEx.GetFlagsValue(), 
                _tbPPM.Text.Replace(',', '.'),
                _tbChance.Text.Replace(',', '.'), 
                _tbCooldown.Text.Replace(',', '.'));

            _rtbSqlLog.AppendText(comment + "\r\n" + drop + "\r\n" + insert + "\r\n\r\n");
            _rtbSqlLog.ColorizeCode();
            if(MySQLConnenct.Connected)
                MySQLConnenct.Insert(drop + insert);

            ((Button)sender).Enabled = false;
        }

        private void _tbCooldown_TextChanged(object sender, EventArgs e)
        {
            if (ProcInfo.SpellProc.ID != 0)
            {
                _bWrite.Enabled = true;
                GetProcAttribute(ProcInfo.SpellProc);
            }
        }

        private void _bSelect_Click(object sender, EventArgs e)
        {
            if (!MySQLConnenct.Connected)
            {
                MessageBox.Show("Can't connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StringBuilder sb = new StringBuilder("WHERE  ");
            string compare = _cbBinaryCompare.Checked ? "&" : "=";

            if (_cbSqlSpellFamily.SelectedValue.ToInt32() != -1)
                sb.AppendFormat(" SpellFamilyName = {0} &&", _cbSqlSpellFamily.SelectedValue.ToInt32());

            sb.AppendFormatIfNotNull(" SchoolMask {1} {0} &&", _tbSqlSchool.Text.ToInt32(), compare);
            sb.AppendFormatIfNotNull(" procFlags {1} {0} &&", _tbSqlProc.Text.ToInt32(), compare);
            sb.AppendFormatIfNotNull(" procEx {1} {0} &&", _tbSqlProcEx.Text.ToInt32(), compare);
            
            var subquery = sb.ToString().Remove(sb.Length - 2, 2);
            subquery = subquery == "WHERE" ? "" : subquery;

            var query = String.Format("SELECT * FROM `spell_proc_event` {0} ORDER BY entry", subquery);

            var result = MySQLConnenct.SelectProc(query);
            _lvDataList.Items.Clear();
            _lvDataList.Items.AddRange(result.ToArray());

            // check bad spell and drop
            foreach(var str in MySQLConnenct.Dropped)
                _rtbSqlLog.AppendText(str);
        }

        private void _bSqlToBase_Click(object sender, EventArgs e)
        {
            if (MySQLConnenct.Connected)
            {
                MySQLConnenct.Insert(_rtbSqlLog.Text);
            }
            else
            {
                MessageBox.Show("Can't connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _lvDataList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProcParse(sender);
        }

        private void _lvDataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcParse(sender);
            }
        }

        private void _bSqlSave_Click(object sender, EventArgs e)
        {
            if (_rtbSqlLog.Text == String.Empty)
                return;

            SaveFileDialog _sd = new SaveFileDialog();
            _sd.Filter = "SQL files|*.sql";
            if (_sd.ShowDialog() != DialogResult.OK)
                return;

            using (StreamWriter _sw = new StreamWriter(_sd.FileName, false, Encoding.UTF8))
            {
                _sw.Write(_rtbSqlLog.Text);
            }
        }

        private void _Connected_Click(object sender, EventArgs e)
        {
            MySQLConnenct.TestConnect();

            if (MySQLConnenct.Connected)
            {
                MessageBox.Show("Connection is successfully!", "MySQL Connections!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection is failed!", "ERROR!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ConnStatus();
        }

        private void ConnStatus()
        {
            MySQLConnenct.TestConnect();

            if (MySQLConnenct.Connected)
            {
                _dbConnect.Text = "Connection is successfully";
                _dbConnect.ForeColor = Color.Green;
                // read db data
                DBC.ItemTemplate = MySQLConnenct.SelectItems();
            }
            else
            {
                _dbConnect.Text = "No DB Connected";
                _dbConnect.ForeColor = Color.Red;
            }
        }

        private void ProcParse(object sender)
        {
            try
            {
                var str = ((ListView)sender).SelectedItems[0];
                uint id = str.SubItems[0].Text.ToUInt32();
                var spell = DBC.Spell[id];
                tabControl1.SelectedIndex = 1;

                SpellInfo.ViewSpellInfo(_rtbProcSpellInfo, spell);

                _clbSchools.SetCheckedItemFromFlag(str.SubItems[2].Text.ToUInt32());
                _clbProcFlags.SetCheckedItemFromFlag(str.SubItems[7].Text.ToUInt32());
                _clbProcFlagEx.SetCheckedItemFromFlag(str.SubItems[8].Text.ToUInt32());

                _cbProcSpellFamilyTree.SelectedValue = str.SubItems[3].Text.ToUInt32();
                _cbProcFitstSpellFamily.SelectedValue = str.SubItems[3].Text.ToUInt32();

                _tbPPM.Text = str.SubItems[9].Text;
                _tbChance.Text = str.SubItems[10].Text;
                _tbCooldown.Text = str.SubItems[11].Text;

                ProcInfo.SpellProc = spell;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void _bCalcProcFlags_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "_bSqlSchool":
                    {
                        uint val = _tbSqlSchool.Text.ToUInt32();
                        FormCalculateFlags form = new FormCalculateFlags(typeof(SpellSchools), val, "");
                        form.ShowDialog(this);
                        if (form.DialogResult == DialogResult.OK)
                            _tbSqlSchool.Text = form.Flags.ToString();
                    }
                    break;
                case "_bSqlProc":
                    {
                        uint val = _tbSqlProc.Text.ToUInt32();
                        FormCalculateFlags form = new FormCalculateFlags(typeof(ProcFlags), val, "PROC_FLAG_");
                        form.ShowDialog(this);
                        if (form.DialogResult == DialogResult.OK)
                            _tbSqlProc.Text = form.Flags.ToString();
                    }
                    break;
                case "_bSqlProcEx":
                    {
                        uint val = _tbSqlProcEx.Text.ToUInt32();
                        FormCalculateFlags form = new FormCalculateFlags(typeof(ProcFlagsEx), val, "PROC_EX_");
                        form.ShowDialog(this);
                        if (form.DialogResult == DialogResult.OK)
                            _tbSqlProcEx.Text = form.Flags.ToString();
                    }
                    break;
            }
        }

        private void _bCompareSearch1_Click(object sender, EventArgs e)
        {
            FormSearch form = new FormSearch();
            form.ShowDialog(this);
            if(form.DialogResult == DialogResult.OK)
            {
                _tbCompareFilterSpell1.Text = form.Spell.ID.ToString();
            }
            form.Dispose();
        }

        private void _bCompareSearch2_Click(object sender, EventArgs e)
        {
            FormSearch form = new FormSearch();
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                _tbCompareFilterSpell2.Text = form.Spell.ID.ToString();
                //SpellCompare.Compare(_rtbCompareSpell1, _rtbCompareSpell2, 
            }
            form.Dispose();
        }

        // Чтобы панели в сплит контейнере были одинаковы при изменении размера формы, сделаем так.
        // Может можно как-то можно через привязки, но я пока незнаю как
        private void FormMain_Resize(object sender, EventArgs e)
        {
            _scCompareRoot.SplitterDistance = (((Form)sender).Size.Width / 2) - 25;
        }

        private void _tbCompareFilterSpell2_TextChanged(object sender, EventArgs e)
        {
            uint spell1 = _tbCompareFilterSpell1.Text.ToUInt32();
            uint spell2 = _tbCompareFilterSpell2.Text.ToUInt32();
            
            if (spell1 > 0 && spell2 > 0)
            {
                SpellCompare.Compare(_rtbCompareSpell1, _rtbCompareSpell2, DBC.Spell[spell1], DBC.Spell[spell2]);
            }
        }

        private void _bAdditionalSearch_Click(object sender, EventArgs e)
        {
            FormSearch form = new FormSearch();
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                _tbSearchId.Text = form.Spell.ID.ToString();
            }
            form.Dispose();
        }
        IEnumerable spell;
        object obj;
        private void _tbAdvansedFilter1Val_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                spell = DBC.SpellDuration.Values.Where(n => n.GetType().GetField("ID").GetValue(n).ToUInt32() == 5);

                obj = DBC.SpellDuration.Values.Select(n => n.GetType().GetField("ID").GetValue(n));
            }
        }
    }
}
