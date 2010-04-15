namespace SpellWork
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tab_SpellInfo = new System.Windows.Forms.TabControl();
            this.tabPage_SpellInfo = new System.Windows.Forms.TabPage();
            this.groupbox_Search = new System.Windows.Forms.GroupBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.tb_SpellName = new System.Windows.Forms.TextBox();
            this.listview_SearchResults = new System.Windows.Forms.ListView();
            this.ColHeader_ID = new System.Windows.Forms.ColumnHeader();
            this.ColHeader_Name = new System.Windows.Forms.ColumnHeader();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tab_SpellInfo.SuspendLayout();
            this.tabPage_SpellInfo.SuspendLayout();
            this.groupbox_Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_SpellInfo
            // 
            this.tab_SpellInfo.Controls.Add(this.tabPage_SpellInfo);
            this.tab_SpellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_SpellInfo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tab_SpellInfo.Location = new System.Drawing.Point(0, 0);
            this.tab_SpellInfo.Name = "tab_SpellInfo";
            this.tab_SpellInfo.SelectedIndex = 0;
            this.tab_SpellInfo.Size = new System.Drawing.Size(849, 560);
            this.tab_SpellInfo.TabIndex = 0;
            // 
            // tabPage_SpellInfo
            // 
            this.tabPage_SpellInfo.Controls.Add(this.groupbox_Search);
            this.tabPage_SpellInfo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage_SpellInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SpellInfo.Name = "tabPage_SpellInfo";
            this.tabPage_SpellInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SpellInfo.Size = new System.Drawing.Size(841, 534);
            this.tabPage_SpellInfo.TabIndex = 0;
            this.tabPage_SpellInfo.Text = "Spell Info";
            this.tabPage_SpellInfo.UseVisualStyleBackColor = true;
            // 
            // groupbox_Search
            // 
            this.groupbox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_Search.Controls.Add(this.button_Search);
            this.groupbox_Search.Controls.Add(this.tb_SpellName);
            this.groupbox_Search.Controls.Add(this.listview_SearchResults);
            this.groupbox_Search.Location = new System.Drawing.Point(590, 3);
            this.groupbox_Search.Name = "groupbox_Search";
            this.groupbox_Search.Size = new System.Drawing.Size(243, 528);
            this.groupbox_Search.TabIndex = 1;
            this.groupbox_Search.TabStop = false;
            this.groupbox_Search.Text = "Search";
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(182, 20);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(54, 21);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // tb_SpellName
            // 
            this.tb_SpellName.Location = new System.Drawing.Point(6, 20);
            this.tb_SpellName.Name = "tb_SpellName";
            this.tb_SpellName.Size = new System.Drawing.Size(170, 21);
            this.tb_SpellName.TabIndex = 1;
            this.tooltip.SetToolTip(this.tb_SpellName, "Part of spell name or spell Id.");
            // 
            // listview_SearchResults
            // 
            this.listview_SearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listview_SearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColHeader_ID,
            this.ColHeader_Name});
            this.listview_SearchResults.FullRowSelect = true;
            this.listview_SearchResults.GridLines = true;
            this.listview_SearchResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listview_SearchResults.HideSelection = false;
            this.listview_SearchResults.Location = new System.Drawing.Point(7, 101);
            this.listview_SearchResults.MultiSelect = false;
            this.listview_SearchResults.Name = "listview_SearchResults";
            this.listview_SearchResults.Size = new System.Drawing.Size(230, 421);
            this.listview_SearchResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listview_SearchResults.TabIndex = 0;
            this.tooltip.SetToolTip(this.listview_SearchResults, "Results of search.\r\n\r\nSelect a spell from the list to view info about it.");
            this.listview_SearchResults.UseCompatibleStateImageBehavior = false;
            this.listview_SearchResults.View = System.Windows.Forms.View.Details;
            // 
            // ColHeader_ID
            // 
            this.ColHeader_ID.Text = "ID";
            this.ColHeader_ID.Width = 49;
            // 
            // ColHeader_Name
            // 
            this.ColHeader_Name.Text = "Name";
            this.ColHeader_Name.Width = 177;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(849, 560);
            this.Controls.Add(this.tab_SpellInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(857, 594);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spell Work";
            this.tab_SpellInfo.ResumeLayout(false);
            this.tabPage_SpellInfo.ResumeLayout(false);
            this.groupbox_Search.ResumeLayout(false);
            this.groupbox_Search.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_SpellInfo;
        private System.Windows.Forms.TabPage tabPage_SpellInfo;
        public System.Windows.Forms.ColumnHeader ColHeader_ID;
        public System.Windows.Forms.ColumnHeader ColHeader_Name;
        private System.Windows.Forms.ListView listview_SearchResults;
        private System.Windows.Forms.GroupBox groupbox_Search;
        private System.Windows.Forms.TextBox tb_SpellName;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Button button_Search;

    }
}