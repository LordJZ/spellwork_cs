namespace SpellWork
{
    partial class LoadingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.lb_t0 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_t0 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_t0
            // 
            this.lb_t0.AutoSize = true;
            this.lb_t0.Location = new System.Drawing.Point(92, 47);
            this.lb_t0.Name = "lb_t0";
            this.lb_t0.Size = new System.Drawing.Size(124, 16);
            this.lb_t0.TabIndex = 5;
            this.lb_t0.Text = "Loading ELEMENT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Progress:";
            // 
            // pb_t0
            // 
            this.pb_t0.Location = new System.Drawing.Point(12, 64);
            this.pb_t0.Name = "pb_t0";
            this.pb_t0.Size = new System.Drawing.Size(370, 27);
            this.pb_t0.Step = 1;
            this.pb_t0.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "SpellWork is loading, please wait.";
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(394, 101);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_t0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pb_t0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpellWork";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_t0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pb_t0;
        private System.Windows.Forms.Label label2;
    }
}

