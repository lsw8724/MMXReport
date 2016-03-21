namespace MMXReport.Dialog
{
    partial class RepairConfigDlg
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
            this.DateEdit_Before = new DevExpress.XtraEditors.DateEdit();
            this.DateEdit_After = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Numeric_RepairOffset = new System.Windows.Forms.NumericUpDown();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Gr_Machine = new DevExpress.XtraEditors.GroupControl();
            this.MimicNodeTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Radio_Avg = new System.Windows.Forms.RadioButton();
            this.Radio_Min = new System.Windows.Forms.RadioButton();
            this.Radio_Max = new System.Windows.Forms.RadioButton();
            this.Gr_Bandpass = new DevExpress.XtraEditors.GroupControl();
            this.CheckEdit_All = new DevExpress.XtraEditors.CheckEdit();
            this.CheckList_Bandpass = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_Before.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_Before.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_After.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_After.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_RepairOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Machine)).BeginInit();
            this.Gr_Machine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MimicNodeTree)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Bandpass)).BeginInit();
            this.Gr_Bandpass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_All.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckList_Bandpass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // DateEdit_Before
            // 
            this.DateEdit_Before.EditValue = null;
            this.DateEdit_Before.Location = new System.Drawing.Point(57, 25);
            this.DateEdit_Before.Name = "DateEdit_Before";
            this.DateEdit_Before.Properties.AllowMouseWheel = false;
            this.DateEdit_Before.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEdit_Before.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateEdit_Before.Size = new System.Drawing.Size(100, 20);
            this.DateEdit_Before.TabIndex = 0;
            this.DateEdit_Before.EditValueChanged += new System.EventHandler(this.StartDateEdit_EditValueChanged);
            // 
            // DateEdit_After
            // 
            this.DateEdit_After.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateEdit_After.EditValue = null;
            this.DateEdit_After.Location = new System.Drawing.Point(57, 50);
            this.DateEdit_After.Name = "DateEdit_After";
            this.DateEdit_After.Properties.AllowMouseWheel = false;
            this.DateEdit_After.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEdit_After.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateEdit_After.Size = new System.Drawing.Size(100, 20);
            this.DateEdit_After.TabIndex = 1;
            this.DateEdit_After.EditValueChanged += new System.EventHandler(this.EndDateEdit_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.Numeric_RepairOffset);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.DateEdit_Before);
            this.groupControl1.Controls.Add(this.DateEdit_After);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(6, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(263, 81);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "수리 기간";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(240, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(12, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "일";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(177, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "±";
            // 
            // Numeric_RepairOffset
            // 
            this.Numeric_RepairOffset.Location = new System.Drawing.Point(191, 37);
            this.Numeric_RepairOffset.Name = "Numeric_RepairOffset";
            this.Numeric_RepairOffset.Size = new System.Drawing.Size(45, 22);
            this.Numeric_RepairOffset.TabIndex = 5;
            this.Numeric_RepairOffset.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.Numeric_RepairOffset.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Numeric_RepairOffset.ValueChanged += new System.EventHandler(this.Numeric_RepairOffset_ValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "수리후";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "수리전";
            // 
            // Gr_Machine
            // 
            this.Gr_Machine.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Gr_Machine.AppearanceCaption.Options.UseFont = true;
            this.Gr_Machine.Controls.Add(this.MimicNodeTree);
            this.Gr_Machine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gr_Machine.Location = new System.Drawing.Point(6, 155);
            this.Gr_Machine.Name = "Gr_Machine";
            this.Gr_Machine.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Gr_Machine.Size = new System.Drawing.Size(263, 295);
            this.Gr_Machine.TabIndex = 8;
            this.Gr_Machine.Text = "설비 목록";
            // 
            // MimicNodeTree
            // 
            this.MimicNodeTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.MimicNodeTree.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.MimicNodeTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MimicNodeTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.MimicNodeTree.Appearance.FocusedCell.Options.UseFont = true;
            this.MimicNodeTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.MimicNodeTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.MimicNodeTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MimicNodeTree.Location = new System.Drawing.Point(12, 27);
            this.MimicNodeTree.Name = "MimicNodeTree";
            this.MimicNodeTree.OptionsBehavior.AllowExpandOnDblClick = false;
            this.MimicNodeTree.OptionsBehavior.Editable = false;
            this.MimicNodeTree.OptionsBehavior.ShowToolTips = false;
            this.MimicNodeTree.OptionsView.ShowColumns = false;
            this.MimicNodeTree.OptionsView.ShowHorzLines = false;
            this.MimicNodeTree.OptionsView.ShowIndicator = false;
            this.MimicNodeTree.OptionsView.ShowVertLines = false;
            this.MimicNodeTree.Size = new System.Drawing.Size(239, 261);
            this.MimicNodeTree.TabIndex = 2;
            this.MimicNodeTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.MimicNodeTree_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.treeListColumn1.AppearanceCell.Options.UseForeColor = true;
            this.treeListColumn1.Caption = "Name";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowMove = false;
            this.treeListColumn1.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn1.OptionsColumn.AllowSize = false;
            this.treeListColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Gr_Machine, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Gr_Bandpass, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 453);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.Radio_Avg);
            this.groupControl2.Controls.Add(this.Radio_Min);
            this.groupControl2.Controls.Add(this.Radio_Max);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(6, 90);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(263, 59);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "측정값";
            // 
            // Radio_Avg
            // 
            this.Radio_Avg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Radio_Avg.AutoSize = true;
            this.Radio_Avg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Radio_Avg.Location = new System.Drawing.Point(203, 26);
            this.Radio_Avg.Name = "Radio_Avg";
            this.Radio_Avg.Size = new System.Drawing.Size(49, 18);
            this.Radio_Avg.TabIndex = 2;
            this.Radio_Avg.Text = "Avg";
            this.Radio_Avg.UseVisualStyleBackColor = true;
            this.Radio_Avg.CheckedChanged += new System.EventHandler(this.Radio_Avg_CheckedChanged_1);
            // 
            // Radio_Min
            // 
            this.Radio_Min.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Radio_Min.AutoSize = true;
            this.Radio_Min.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Radio_Min.Location = new System.Drawing.Point(110, 26);
            this.Radio_Min.Name = "Radio_Min";
            this.Radio_Min.Size = new System.Drawing.Size(47, 18);
            this.Radio_Min.TabIndex = 1;
            this.Radio_Min.Text = "Min";
            this.Radio_Min.UseVisualStyleBackColor = true;
            this.Radio_Min.CheckedChanged += new System.EventHandler(this.Radio_Min_CheckedChanged_1);
            // 
            // Radio_Max
            // 
            this.Radio_Max.AutoSize = true;
            this.Radio_Max.Checked = true;
            this.Radio_Max.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Radio_Max.Location = new System.Drawing.Point(12, 26);
            this.Radio_Max.Name = "Radio_Max";
            this.Radio_Max.Size = new System.Drawing.Size(50, 18);
            this.Radio_Max.TabIndex = 0;
            this.Radio_Max.TabStop = true;
            this.Radio_Max.Text = "Max";
            this.Radio_Max.UseVisualStyleBackColor = true;
            this.Radio_Max.CheckedChanged += new System.EventHandler(this.Radio_Max_CheckedChanged_1);
            // 
            // Gr_Bandpass
            // 
            this.Gr_Bandpass.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Gr_Bandpass.AppearanceCaption.Options.UseFont = true;
            this.Gr_Bandpass.Controls.Add(this.CheckEdit_All);
            this.Gr_Bandpass.Controls.Add(this.CheckList_Bandpass);
            this.Gr_Bandpass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gr_Bandpass.Location = new System.Drawing.Point(275, 155);
            this.Gr_Bandpass.Name = "Gr_Bandpass";
            this.Gr_Bandpass.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Gr_Bandpass.Size = new System.Drawing.Size(263, 295);
            this.Gr_Bandpass.TabIndex = 9;
            this.Gr_Bandpass.Text = "밴드패스";
            // 
            // CheckEdit_All
            // 
            this.CheckEdit_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckEdit_All.Location = new System.Drawing.Point(10, 269);
            this.CheckEdit_All.Name = "CheckEdit_All";
            this.CheckEdit_All.Properties.Caption = "일괄 체크";
            this.CheckEdit_All.Size = new System.Drawing.Size(75, 19);
            this.CheckEdit_All.TabIndex = 1;
            this.CheckEdit_All.CheckedChanged += new System.EventHandler(this.CheckEdit_All_CheckedChanged);
            // 
            // CheckList_Bandpass
            // 
            this.CheckList_Bandpass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckList_Bandpass.Location = new System.Drawing.Point(12, 27);
            this.CheckList_Bandpass.MainView = this.gridView1;
            this.CheckList_Bandpass.Name = "CheckList_Bandpass";
            this.CheckList_Bandpass.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.CheckList_Bandpass.Size = new System.Drawing.Size(239, 261);
            this.CheckList_Bandpass.TabIndex = 0;
            this.CheckList_Bandpass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.CheckList_Bandpass;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Active";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "Active";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowShowHide = false;
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn1.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 20;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "DisplayName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 219;
            // 
            // RepairConfigDlg
            // 
            this.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 476);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "RepairConfigDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "보전활동 보고서 필터";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_Before.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_Before.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_After.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEdit_After.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Numeric_RepairOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Machine)).EndInit();
            this.Gr_Machine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MimicNodeTree)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Bandpass)).EndInit();
            this.Gr_Bandpass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckEdit_All.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckList_Bandpass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.DateEdit DateEdit_Before;
        public DevExpress.XtraEditors.DateEdit DateEdit_After;
        protected DevExpress.XtraEditors.GroupControl groupControl1;
        protected DevExpress.XtraEditors.GroupControl Gr_Machine;
        protected DevExpress.XtraEditors.GroupControl Gr_Bandpass;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraTreeList.TreeList MimicNodeTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        protected System.Windows.Forms.RadioButton Radio_Avg;
        protected System.Windows.Forms.RadioButton Radio_Min;
        protected System.Windows.Forms.RadioButton Radio_Max;
        private DevExpress.XtraGrid.GridControl CheckList_Bandpass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.CheckEdit CheckEdit_All;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.NumericUpDown Numeric_RepairOffset;
    }
}