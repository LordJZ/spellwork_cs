namespace SpellWork.Forms
{
    sealed partial class FormCalculateFlags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculateFlags));
            this._bNo = new System.Windows.Forms.Button();
            this._bOk = new System.Windows.Forms.Button();
            this._clbCalcFlags = new System.Windows.Forms.CheckedListBox();
            this._lFlagValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _bNo
            // 
            this._bNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._bNo.Location = new System.Drawing.Point(12, 270);
            this._bNo.Name = "_bNo";
            this._bNo.Size = new System.Drawing.Size(75, 23);
            this._bNo.TabIndex = 1;
            this._bNo.Text = "Cancel";
            this._bNo.UseVisualStyleBackColor = true;
            this._bNo.Click += new System.EventHandler(this.BNoClick);
            // 
            // _bOk
            // 
            this._bOk.Location = new System.Drawing.Point(201, 270);
            this._bOk.Name = "_bOk";
            this._bOk.Size = new System.Drawing.Size(75, 23);
            this._bOk.TabIndex = 2;
            this._bOk.Text = "OK";
            this._bOk.UseVisualStyleBackColor = true;
            this._bOk.Click += new System.EventHandler(this.BOkClick);
            // 
            // _clbCalcFlags
            // 
            this._clbCalcFlags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._clbCalcFlags.CheckOnClick = true;
            this._clbCalcFlags.FormattingEnabled = true;
            this._clbCalcFlags.Location = new System.Drawing.Point(0, 1);
            this._clbCalcFlags.Name = "_clbCalcFlags";
            this._clbCalcFlags.Size = new System.Drawing.Size(291, 259);
            this._clbCalcFlags.TabIndex = 0;
            this._clbCalcFlags.SelectedValueChanged += new System.EventHandler(this.ClbCalcFlagsSelectedValueChanged);
            // 
            // _lFlagValue
            // 
            this._lFlagValue.AutoSize = true;
            this._lFlagValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lFlagValue.ForeColor = System.Drawing.Color.Blue;
            this._lFlagValue.Location = new System.Drawing.Point(93, 275);
            this._lFlagValue.Name = "_lFlagValue";
            this._lFlagValue.Size = new System.Drawing.Size(54, 13);
            this._lFlagValue.TabIndex = 3;
            this._lFlagValue.Text = "Value: 0";
            // 
            // FormCalculateFlags
            // 
            this.AcceptButton = this._bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._bNo;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this._lFlagValue);
            this.Controls.Add(this._clbCalcFlags);
            this.Controls.Add(this._bOk);
            this.Controls.Add(this._bNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculateFlags";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormCalculateFlags";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _clbCalcFlags;
        private System.Windows.Forms.Button _bNo;
        private System.Windows.Forms.Button _bOk;
        private System.Windows.Forms.Label _lFlagValue;
    }
}