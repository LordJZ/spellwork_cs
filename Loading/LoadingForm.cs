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
    public partial class LoadingForm : Form
    {
        private bool SelfStop;

        public LoadingForm()
        {
            SelfStop = false;
            InitializeComponent();
        }

        // Thread-safe functions
        private delegate void del_Label_String(Label ctrl, string value);
        public void SetLabelText(string text)
        {
            Action<Label, string> f = (x, s) => x.Text = s;

            if (lb_t0.InvokeRequired)
                lb_t0.Invoke(new del_Label_String(f), new object[] { lb_t0, text });
            else
                f(lb_t0, text);
        }

        private delegate void del_ProgressBar_Int(ProgressBar ctrl, int value);
        public void SetProgressBarSize(int size)
        {
            Action<ProgressBar, int> f = (x, i) =>
            {
                x.Maximum = i;
                x.Step = 1;
                x.Value = 0;
            };

            if (pb_t0.InvokeRequired)
                pb_t0.Invoke(new del_ProgressBar_Int(f), new object[] { pb_t0, size });
            else
                f(pb_t0, size);
        }

        private delegate void del_ProgressBar(ProgressBar ctrl);
        public void ProgressBarStep()
        {
            Action<ProgressBar> f = (x) => x.PerformStep();

            if (pb_t0.InvokeRequired)
                pb_t0.Invoke(new del_ProgressBar(f), new object[] { pb_t0 });
            else
                f(pb_t0);
        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!SelfStop)
                Program.StopEvent = true;
        }

        public delegate void del_Form(LoadingForm form);
        public void _Close()
        {
            Action<LoadingForm> f = (x) =>
            {
                x.SelfStop = true;
                x.Close();
            };
            if (this.InvokeRequired)
                this.Invoke(new del_Form(f), new object[] { this });
            else
                f(this);
        }
    }
}
