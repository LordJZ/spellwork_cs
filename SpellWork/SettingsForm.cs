using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpellWork.Properties;

namespace SpellWork
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void _cbUseDBConnect_CheckedChanged(object sender, EventArgs e)
        {
            _gbDbSetting.Enabled = ((CheckBox)sender).Checked;
        }

        private void _bTestConnect_Click(object sender, EventArgs e)
        {
            //
        }

        private void _bSaveSettings_Click(object sender, EventArgs e)
        {
            //
            Settings.Default.Save();
            this.Close();
        }
    }
}
