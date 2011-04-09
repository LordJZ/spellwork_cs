using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace SpellWork
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            splitContainer3.SplitterDistance = 128;
            
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

            _cbAdvancedFilter1.SetStructFields<SpellEntry>();
            _cbAdvancedFilter2.SetStructFields<SpellEntry>();

            _cbAdvancedFilter1CompareType.SetEnumValuesDirect<CompareType>(true);
            _cbAdvancedFilter2CompareType.SetEnumValuesDirect<CompareType>(true);

            ConnStatus();
        }

        #region FORM

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About_Click(object sender, EventArgs e)
        {
            FormAboutBox ab = new FormAboutBox();
            ab.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbProcFlag.Visible = _bWrite.Visible = ((TabControl)sender).SelectedIndex == 1;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog(this);
            ConnStatus();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            try
            {
                // Чтобы панели в сплит контейнере были одинаковы при изменении размера формы, сделаем так.
                // Может можно как-то можно через привязки, но я пока незнаю как
                _scCompareRoot.SplitterDistance = (((Form)sender).Size.Width / 2) - 25;
                _chName.Width = (((Form)sender).Size.Width - 140);
            }
            catch { }
        }

        private void ConnStatus()
        {
            MySQLConnect.TestConnect();

            if (MySQLConnect.Connected)
            {
                _dbConnect.Text = "Connection is successfully";
                _dbConnect.ForeColor = Color.Green;
                // read db data
                DBC.ItemTemplate = MySQLConnect.SelectItems();
            }
            else
            {
                _dbConnect.Text = "No DB Connected";
                _dbConnect.ForeColor = Color.Red;
            }
        }

        private void _Connected_Click(object sender, EventArgs e)
        {
            MySQLConnect.TestConnect();

            if (MySQLConnect.Connected)
                MessageBox.Show("Connection is successfully!", "MySQL Connections!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Connection is failed!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ConnStatus();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        #endregion

        #region SPELL INFO PAGE

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvSpellList.SelectedIndices.Count > 0)
                new SpellInfo(_rtSpellInfo, _spellList[_lvSpellList.SelectedIndices[0]]);
        }

        private void _tbSearchId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AdvancedSearch();
        }

        private void _bSearch_Click(object sender, EventArgs e)
        {
            AdvancedSearch();
        }

        private void _cbSpellFamilyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 0)
                AdvansedFilter();
        }

        private void _tbAdvansedFilterVal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AdvansedFilter();
        }

        private void AdvancedSearch()
        {
            string name = _tbSearchId.Text;
            uint id = name.ToUInt32();
            uint ic = _tbSearchIcon.Text.ToUInt32();
            uint at = _tbSearchAttributes.Text.ToUInt32();

            _spellList = (from spell in DBC.Spell.Values
                          
                          where ((id == 0 || spell.ID          == id)

                              && (ic == 0 || spell.SpellIconID == ic)

                              && (at == 0 || (spell.Attributes    & at) != 0
                                          || (spell.AttributesEx  & at) != 0
                                          || (spell.AttributesEx2 & at) != 0
                                          || (spell.AttributesEx3 & at) != 0
                                          || (spell.AttributesEx4 & at) != 0
                                          || (spell.AttributesEx5 & at) != 0
                                          || (spell.AttributesEx6 & at) != 0
                                          || (spell.AttributesExG & at) != 0))

                             && ((id != 0 || ic != 0 && at != 0) || spell.SpellName.ContainsText(name))
                          
                          select spell).ToList();

            _lvSpellList.VirtualListSize = _spellList.Count();
            if (_lvSpellList.SelectedIndices.Count > 0)
                _lvSpellList.Items[_lvSpellList.SelectedIndices[0]].Selected = false;
        }

        private void AdvansedFilter()
        {
            var bFamilyNames = _cbSpellFamilyName.SelectedIndex != 0;
            var fFamilyNames = _cbSpellFamilyName.SelectedValue.ToInt32();

            var bSpellAura = _cbSpellAura.SelectedIndex != 0;
            var fSpellAura = _cbSpellAura.SelectedValue.ToInt32();

            var bSpellEffect = _cbSpellEffect.SelectedIndex != 0;
            var fSpellEffect = _cbSpellEffect.SelectedValue.ToInt32();

            var bTarget1 = _cbTarget1.SelectedIndex != 0;
            var fTarget1 = _cbTarget1.SelectedValue.ToInt32();

            var bTarget2 = _cbTarget2.SelectedIndex != 0;
            var fTarget2 = _cbTarget2.SelectedValue.ToInt32();

            // additional filtert
            var advVal1 = _tbAdvancedFilter1Val.Text;
            var advVal2 = _tbAdvancedFilter2Val.Text;

            var field1 = (MemberInfo)_cbAdvancedFilter1.SelectedValue;
            var field2 = (MemberInfo)_cbAdvancedFilter2.SelectedValue;

            bool use1val = advVal1 != string.Empty;
            bool use2val = advVal2 != string.Empty;

            CompareType field1ct = (CompareType)_cbAdvancedFilter1CompareType.SelectedIndex;
            CompareType field2ct = (CompareType)_cbAdvancedFilter2CompareType.SelectedIndex;

            _spellList = (from spell in DBC.Spell.Values
                           
                          where ( !bFamilyNames || spell.SpellFamilyName == fFamilyNames)
                              && (!bSpellEffect || spell.Effect.ContainsElement((uint)fSpellEffect))
                              && (!bSpellAura   || spell.EffectApplyAuraName.ContainsElement((uint)fSpellAura))
                              && (!bTarget1     || spell.EffectImplicitTargetA.ContainsElement((uint)fTarget1))
                              && (!bTarget2     || spell.EffectImplicitTargetB.ContainsElement((uint)fTarget2))
                              && (!use1val      || spell.CreateFilter(field1, advVal1, field1ct))
                              && (!use2val      || spell.CreateFilter(field2, advVal2, field2ct))
                           
                          select spell).ToList();

            _lvSpellList.VirtualListSize = _spellList.Count();
            if (_lvSpellList.SelectedIndices.Count > 0)
                _lvSpellList.Items[_lvSpellList.SelectedIndices[0]].Selected = false;

        }

        #endregion

        #region SPELL PROC INFO PAGE

        private void _cbProcSpellFamilyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex > 0)
                ProcFilter();
        }

        private void _bSpellInfo_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void _cbProcFlag_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = ((CheckBox)sender).Checked ? 240 : 128;
        }

        private void _tvFamilyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
                SetProcAtribute(DBC.Spell[e.Node.Name.ToUInt32()]);
        }

        private void _lvProcSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lv = (ListView)sender;
            if (lv.SelectedIndices.Count > 0)
            {
                SetProcAtribute(_spellProcList[lv.SelectedIndices[0]]);
                _lvProcAdditionalInfo.Items.Clear();
            }
        }

        private void _lvProcAdditionalInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lvProcAdditionalInfo.SelectedIndices.Count > 0)
                SetProcAtribute(DBC.Spell[_lvProcAdditionalInfo.SelectedItems[0].SubItems[0].Text.ToUInt32()]);
        }
        
        private void _clbSchools_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProcInfo.SpellProc.ID != 0)
            {
                _bWrite.Enabled = true;
                GetProcAttribute(ProcInfo.SpellProc);
            }
        }

        private void _tbCooldown_TextChanged(object sender, EventArgs e)
        {
            if (ProcInfo.SpellProc.ID != 0)
            {
                _bWrite.Enabled = true;
                GetProcAttribute(ProcInfo.SpellProc);
            }
        }

        private void _bProcSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void _tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void _tvFamilyTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)((ComboBox)sender).SelectedIndex == 0)
                return;
            _tvFamilyTree.Nodes.Clear();
            SpellFamilyNames spellfamily = (SpellFamilyNames)(((ComboBox)sender).SelectedValue.ToInt32());

            new ProcInfo(_tvFamilyTree, spellfamily);
        }

        private void SetProcAtribute(SpellEntry spell)
        {
            new SpellInfo(_rtbProcSpellInfo, spell);

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
            uint[] SpellFamilyFlags = _tvFamilyTree.GetMask();
            var statusproc = String.Format("Spell ({0}) {1}. Proc Event ==> SchoolMask 0x{2:X2}, SpellFamily {3}, 0x{4:X8} {5:X8} {6:X8}, procFlag 0x{7:X8}, procEx 0x{8:X8}, PPMRate {9}",
                spell.ID,
                spell.SpellNameRank,
                _clbSchools.GetFlagsValue(),
                _cbProcFitstSpellFamily.ValueMember,
                SpellFamilyFlags[0],
                SpellFamilyFlags[1],
                SpellFamilyFlags[2],
                _clbProcFlags.GetFlagsValue(),
                _clbProcFlagEx.GetFlagsValue(),
                _tbPPM.Text.ToFloat());

            _gSpellProcEvent.Text = "Spell Proc Event    " + statusproc;
        }

        private void Search()
        {
            uint id = _tbProcSeach.Text.ToUInt32();
            
            _spellProcList = (from spell in DBC.Spell.Values
                           where (id == 0 || spell.ID == id)
                              && (id != 0 || spell.SpellName.ContainsText(_tbProcSeach.Text))
                           select spell).ToList();
            
            _lvProcSpellList.VirtualListSize = _spellProcList.Count;
            if (_lvProcSpellList.SelectedIndices.Count > 0)
                _lvProcSpellList.Items[_lvProcSpellList.SelectedIndices[0]].Selected = false;
        }

        private void ProcFilter()
        {
            var bFamilyNames = _cbProcSpellFamilyName.SelectedIndex != 0;
            var fFamilyNames = _cbProcSpellFamilyName.SelectedValue.ToInt32();

            var bSpellAura = _cbProcSpellAura.SelectedIndex != 0;
            var fSpellAura = _cbProcSpellAura.SelectedValue.ToInt32();

            var bSpellEffect = _cbProcSpellEffect.SelectedIndex != 0;
            var fSpellEffect = _cbProcSpellEffect.SelectedValue.ToInt32();

            var bTarget1 = _cbProcTarget1.SelectedIndex != 0;
            var fTarget1 = _cbProcTarget1.SelectedValue.ToInt32();

            var bTarget2 = _cbProcTarget2.SelectedIndex != 0;
            var fTarget2 = _cbProcTarget2.SelectedValue.ToInt32();

            _spellProcList = (from spell in DBC.Spell.Values

                              where (!bFamilyNames || spell.SpellFamilyName == fFamilyNames)
                                 && (!bSpellEffect || spell.Effect.ContainsElement((uint)fSpellEffect))
                                 && (!bSpellAura   || spell.EffectApplyAuraName.Contains((uint)fSpellAura))
                                 && (!bTarget1     || spell.EffectImplicitTargetA.ContainsElement((uint)fTarget1))
                                 && (!bTarget2     || spell.EffectImplicitTargetB.ContainsElement((uint)fTarget2))
                              
                              select spell).ToList();

            _lvProcSpellList.VirtualListSize = _spellProcList.Count();
            if (_lvProcSpellList.SelectedIndices.Count > 0)
                _lvProcSpellList.Items[_lvProcSpellList.SelectedIndices[0]].Selected = false;
        }
       
        private void FamilyTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!ProcInfo.Update) return;

            _bWrite.Enabled = true;
            _lvProcAdditionalInfo.Items.Clear();

            uint[] mask = ((TreeView)sender).GetMask();

            var query = from Spell in DBC.Spell.Values
                        where Spell.SpellFamilyName == ProcInfo.SpellProc.SpellFamilyName
                        && Spell.SpellFamilyFlags.ContainsElement(mask)
                        join sk in DBC.SkillLineAbility on Spell.ID equals sk.Value.SpellId into temp1
                        from Skill in temp1.DefaultIfEmpty()
                        //join skl in DBC.SkillLine on Skill.Value.SkillId equals skl.Value.ID into temp2
                        //from SkillLine in temp2.DefaultIfEmpty()
                        orderby Skill.Key descending
                        select new
                        {
                            SpellID = Spell.ID,
                            SpellName = Spell.SpellNameRank + " " + Spell.Description,
                            SkillId = Skill.Value.SkillId
                        };

            foreach (var str in query)
            {
                ListViewItem lvi = new ListViewItem(new string[] { str.SpellID.ToString(), str.SpellName });
                lvi.ImageKey = str.SkillId != 0 ? "plus.ico" : "munus.ico";
                _lvProcAdditionalInfo.Items.Add(lvi);
            }

            GetProcAttribute(ProcInfo.SpellProc);
        }

        #endregion

        #region COMPARE PAGE

        private void CompareFilterSpell_TextChanged(object sender, EventArgs e)
        {
            uint spell1 = _tbCompareFilterSpell1.Text.ToUInt32();
            uint spell2 = _tbCompareFilterSpell2.Text.ToUInt32();

            if (DBC.Spell.ContainsKey(spell1) && DBC.Spell.ContainsKey(spell2))
                new SpellCompare(_rtbCompareSpell1, _rtbCompareSpell2, DBC.Spell[spell1], DBC.Spell[spell2]);

        }

        private void CompareSearch1_Click(object sender, EventArgs e)
        {
            FormSearch form = new FormSearch();
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
                _tbCompareFilterSpell1.Text = form.Spell.ID.ToString();
            form.Dispose();
        }

        private void CompareSearch2_Click(object sender, EventArgs e)
        {
            FormSearch form = new FormSearch();
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
                _tbCompareFilterSpell2.Text = form.Spell.ID.ToString();
            form.Dispose();
        }

        #endregion

        #region SQL PAGE

        private void Sql_DataList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProcParse(sender);
        }

        private void Sql_DataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ProcParse(sender);
        }

        private void SqlToBase_Click(object sender, EventArgs e)
        {
            if (MySQLConnect.Connected)
                MySQLConnect.Insert(_rtbSqlLog.Text);
            else
                MessageBox.Show("Can't connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SqlSave_Click(object sender, EventArgs e)
        {
            if (_rtbSqlLog.Text != String.Empty)
            {
                SaveFileDialog _sd = new SaveFileDialog();
                _sd.Filter = "SQL files|*.sql";
                if (_sd.ShowDialog() == DialogResult.OK)
                    using (StreamWriter _sw = new StreamWriter(_sd.FileName, false, Encoding.UTF8))
                        _sw.Write(_rtbSqlLog.Text);
            }
        }

        private void CalcProcFlags_Click(object sender, EventArgs e)
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

        private void Select_Click(object sender, EventArgs e)
        {
            if (!MySQLConnect.Connected)
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

            String subquery = sb.ToString().Remove(sb.Length - 2, 2);
            subquery = subquery == "WHERE" ? "" : subquery;

            String query = String.Format("SELECT * FROM `spell_proc_event` {0} ORDER BY entry", subquery);
            MySQLConnect.SelectProc(query);

            _lvDataList.VirtualListSize = MySQLConnect.SpellProcEvent.Count;
            if (_lvDataList.SelectedIndices.Count > 0)
                _lvDataList.Items[_lvDataList.SelectedIndices[0]].Selected = false;

            // check bad spell and drop
            foreach (String str in MySQLConnect.Dropped)
                _rtbSqlLog.AppendText(str);
        }

        private void Write_Click(object sender, EventArgs e)
        {
            uint[] SpellFamilyFlags = _tvFamilyTree.GetMask();
            // spell comment
            var comment = String.Format("-- ({0}) {1}", ProcInfo.SpellProc.ID, ProcInfo.SpellProc.SpellNameRank);
            // drop query
            var drop = String.Format("DELETE FROM `spell_proc_event` WHERE `entry` IN ({0});", ProcInfo.SpellProc.ID);
            // insert query
            var insert = String.Format("INSERT INTO `spell_proc_event` VALUES ({0}, 0x{1:X2}, 0x{2:X2}, 0x{3:X8}, 0x{4:X8}, 0x{5:X8}, 0x{6:X8}, 0x{7:X8}, 0x{8:X8}, 0x{9:X8}, 0x{10:X8}, 0x{11:X8}, 0x{12:X8}, 0x{13:X8}, {14}, {15}, {16});",
                ProcInfo.SpellProc.ID,
                _clbSchools.GetFlagsValue(),
                _cbProcFitstSpellFamily.SelectedValue.ToUInt32(),
                SpellFamilyFlags[0],
                SpellFamilyFlags[1],
                SpellFamilyFlags[2],
                0,0,0,0,0,0,// пока что так, пока не пойму как...
                _clbProcFlags.GetFlagsValue(),
                _clbProcFlagEx.GetFlagsValue(),
                _tbPPM.Text.Replace(',', '.'),
                _tbChance.Text.Replace(',', '.'),
                _tbCooldown.Text.Replace(',', '.'));

            _rtbSqlLog.AppendText(comment + "\r\n" + drop + "\r\n" + insert + "\r\n\r\n");
            _rtbSqlLog.ColorizeCode();
            if (MySQLConnect.Connected)
                MySQLConnect.Insert(drop + insert);

            ((Button)sender).Enabled = false;
        }
        
        private void ProcParse(object sender)
        {
            SpellProcEventEntry proc = MySQLConnect.SpellProcEvent[((ListView)sender).SelectedIndices[0]];
            SpellEntry spell = DBC.Spell[proc.ID];
            ProcInfo.SpellProc = spell;

            new SpellInfo(_rtbProcSpellInfo, spell);

            _clbSchools.SetCheckedItemFromFlag(proc.SchoolMask);
            _clbProcFlags.SetCheckedItemFromFlag(proc.ProcFlags);
            _clbProcFlagEx.SetCheckedItemFromFlag(proc.ProcEx);

            _cbProcSpellFamilyTree.SelectedValue = proc.SpellFamilyName;
            _cbProcFitstSpellFamily.SelectedValue = proc.SpellFamilyName;

            _tbPPM.Text = proc.PpmRate.ToString();
            _tbChance.Text = proc.CustomChance.ToString();
            _tbCooldown.Text = proc.Cooldown.ToString();

            _tvFamilyTree.SetMask(proc.SpellFamilyMask);
            
            tabControl1.SelectedIndex = 1;
        }

        #endregion

        #region VIRTUAL MODE

        private List<SpellEntry> _spellList = new List<SpellEntry>();
 
        private void _lvSpellList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(new[] { _spellList[e.ItemIndex].ID.ToString(), _spellList[e.ItemIndex].SpellNameRank });
        }

        private List<SpellEntry> _spellProcList = new List<SpellEntry>();

        private void _lvProcSpellList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(new[] { _spellProcList[e.ItemIndex].ID.ToString(), _spellProcList[e.ItemIndex].SpellNameRank });
        }

        private void _lvSqlData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(MySQLConnect.SpellProcEvent[e.ItemIndex].ToArray());
        }

        #endregion
    }
}
