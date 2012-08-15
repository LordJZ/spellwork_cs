using System;
using System.Windows.Forms;

namespace SpellWork.Forms
{
    public partial class FormSpellScaling : Form
    {
        public FormSpellScaling()
        {
            InitializeComponent();
        }

        private void LevelValueChanged(object sender, System.EventArgs e)
        {
            SelectedLevel = (uint)((TrackBar)sender).Value;
            _tbxLevel.Text = ((TrackBar)sender).Value.ToString();
        }

        private void LevelTextKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Escape && e.KeyChar != (char)Keys.Enter)
                e.Handled = true;
        }

        private void LevelTextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Length <= 0)
            {
                SelectedLevel = 1;
                tb.Text = "1";
                return;
            }

            var val = int.Parse(tb.Text);
            if (val > 100)
                tb.Text = "100";
            else if (val <= 0)
                tb.Text = "1";

            val = int.Parse(tb.Text);
            _tbLevel.Value = val;
            SelectedLevel = (uint)val;
        }

        public uint SelectedLevel;
    }
}
