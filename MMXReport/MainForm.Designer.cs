namespace MMXReport
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
            this.SmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.Gr_Report = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.Tchart_RepairTrend = new Steema.TeeChart.TChart();
            this.fastLine2 = new Steema.TeeChart.Styles.FastLine();
            this.colorBand1 = new Steema.TeeChart.Tools.ColorBand();
            this.annotation1 = new Steema.TeeChart.Tools.Annotation();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.BtnPreview_Repair = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPreview_Daily = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_Repair = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_Repair = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_Daily = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_Daily = new DevExpress.XtraEditors.SimpleButton();
            this.Gr_Compare = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.Tchart_DayOfWeek = new Steema.TeeChart.TChart();
            this.horizBar2 = new Steema.TeeChart.Styles.HorizBar();
            this.Tchart_Period = new Steema.TeeChart.TChart();
            this.bar1 = new Steema.TeeChart.Styles.Bar();
            this.bar2 = new Steema.TeeChart.Styles.Bar();
            this.bar3 = new Steema.TeeChart.Styles.Bar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BtnPreview_Period = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPreview_DayOfWeek = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_Period = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_Period = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_DayOfWeek = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_DayOfWeek = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.BtnPreview_BandpassTrend = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPreview_PointTrend = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_BandpassTrend = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_BandpassTrend = new DevExpress.XtraEditors.SimpleButton();
            this.BtnConfig_PointTrend = new DevExpress.XtraEditors.SimpleButton();
            this.BtnReport_PointTrend = new DevExpress.XtraEditors.SimpleButton();
            this.Tchart_Trend = new Steema.TeeChart.TChart();
            this.fastLine1 = new Steema.TeeChart.Styles.FastLine();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Gr_Variation = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Report)).BeginInit();
            this.Gr_Report.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Compare)).BeginInit();
            this.Gr_Compare.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Variation)).BeginInit();
            this.Gr_Variation.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmallImageList
            // 
            this.SmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImageList.ImageStream")));
            this.SmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImageList.Images.SetKeyName(0, "Preview-2-icon.png");
            this.SmallImageList.Images.SetKeyName(1, "settings.png");
            this.SmallImageList.Images.SetKeyName(2, "bar_chart-512.png");
            this.SmallImageList.Images.SetKeyName(3, "ChartTable.png");
            this.SmallImageList.Images.SetKeyName(4, "bar-chart-icon.png");
            this.SmallImageList.Images.SetKeyName(5, "icon-line.png");
            this.SmallImageList.Images.SetKeyName(6, "Report.png");
            // 
            // Gr_Report
            // 
            this.Gr_Report.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 50F);
            this.Gr_Report.AppearanceCaption.Options.UseFont = true;
            this.Gr_Report.AppearanceCaption.Options.UseTextOptions = true;
            this.Gr_Report.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Gr_Report.CaptionImage = ((System.Drawing.Image)(resources.GetObject("Gr_Report.CaptionImage")));
            this.Gr_Report.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText;
            this.Gr_Report.CaptionImagePadding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Gr_Report.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.Gr_Report.Controls.Add(this.tableLayoutPanel4);
            this.Gr_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gr_Report.Location = new System.Drawing.Point(3, 443);
            this.Gr_Report.Name = "Gr_Report";
            this.Gr_Report.Size = new System.Drawing.Size(847, 214);
            this.Gr_Report.TabIndex = 17;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupControl4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupControl3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(89, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(756, 210);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.Tchart_RepairTrend);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(279, 16);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(471, 178);
            this.groupControl4.TabIndex = 4;
            this.groupControl4.Text = "groupControl4";
            // 
            // Tchart_RepairTrend
            // 
            // 
            // 
            // 
            this.Tchart_RepairTrend.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_RepairTrend.Axes.Bottom.Increment = 1D;
            // 
            // 
            // 
            this.Tchart_RepairTrend.Axes.Bottom.Labels.DateTimeFormat = "yyyy년 M월 d일";
            this.Tchart_RepairTrend.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tchart_RepairTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.Tchart_RepairTrend.Header.Visible = false;
            // 
            // 
            // 
            this.Tchart_RepairTrend.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            this.Tchart_RepairTrend.Location = new System.Drawing.Point(2, 2);
            this.Tchart_RepairTrend.Name = "Tchart_RepairTrend";
            // 
            // 
            // 
            this.Tchart_RepairTrend.Panel.MarginBottom = 8D;
            // 
            // 
            // 
            this.Tchart_RepairTrend.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.Tchart_RepairTrend.Series.Add(this.fastLine2);
            this.Tchart_RepairTrend.Size = new System.Drawing.Size(467, 174);
            this.Tchart_RepairTrend.TabIndex = 0;
            this.Tchart_RepairTrend.Tools.Add(this.colorBand1);
            this.Tchart_RepairTrend.Tools.Add(this.annotation1);
            // 
            // 
            // 
            this.Tchart_RepairTrend.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            // 
            // fastLine2
            // 
            this.fastLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.fastLine2.ColorEach = false;
            // 
            // 
            // 
            this.fastLine2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            // 
            // 
            // 
            this.fastLine2.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.fastLine2.Title = "Direct";
            this.fastLine2.TreatNulls = Steema.TeeChart.Styles.TreatNullsStyle.Ignore;
            // 
            // 
            // 
            this.fastLine2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine2.YValues.DataMember = "Y";
            // 
            // colorBand1
            // 
            this.colorBand1.Axis = this.Tchart_RepairTrend.Axes.Bottom;
            // 
            // 
            // 
            this.colorBand1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(56)))), ((int)(((byte)(111)))), ((int)(((byte)(252)))));
            // 
            // 
            // 
            this.colorBand1.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.colorBand1.End = 20D;
            // 
            // 
            // 
            this.colorBand1.EndLinePen.Visible = false;
            // 
            // 
            // 
            this.colorBand1.Pen.Visible = false;
            this.colorBand1.ResizeEnd = false;
            this.colorBand1.ResizeStart = false;
            this.colorBand1.Start = 5D;
            // 
            // 
            // 
            this.colorBand1.StartLinePen.Visible = false;
            // 
            // annotation1
            // 
            this.annotation1.Active = false;
            this.annotation1.AutoSize = true;
            // 
            // 
            // 
            this.annotation1.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.annotation1.Callout.ArrowHeadDirection = Steema.TeeChart.Styles.ArrowHeadDirection.FromPoint;
            this.annotation1.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.annotation1.Callout.Brush.Color = System.Drawing.Color.Black;
            this.annotation1.Callout.Distance = 0;
            this.annotation1.Callout.Draw3D = false;
            this.annotation1.Callout.SizeDouble = 0D;
            this.annotation1.Callout.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels;
            this.annotation1.Callout.XPosition = 0;
            this.annotation1.Callout.YPosition = 0;
            this.annotation1.Callout.ZPosition = 0;
            this.annotation1.Cursor = System.Windows.Forms.Cursors.Default;
            this.annotation1.Left = 50;
            this.annotation1.Position = Steema.TeeChart.Tools.AnnotationPositions.RightBottom;
            this.annotation1.PositionUnits = Steema.TeeChart.PositionUnits.Percent;
            // 
            // 
            // 
            this.annotation1.Shape.Bottom = 60;
            this.annotation1.Shape.CustomPosition = true;
            // 
            // 
            // 
            this.annotation1.Shape.Font.Bold = true;
            // 
            // 
            // 
            this.annotation1.Shape.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(106)))));
            this.annotation1.Shape.Font.Name = "휴먼둥근헤드라인";
            // 
            // 
            // 
            // 
            // 
            // 
            this.annotation1.Shape.Font.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.annotation1.Shape.Font.Shadow.Visible = true;
            this.annotation1.Shape.Font.Size = 15;
            this.annotation1.Shape.Font.SizeFloat = 15F;
            this.annotation1.Shape.Left = 50;
            this.annotation1.Shape.Lines = new string[] {
        "수리기간"};
            this.annotation1.Shape.Right = 60;
            // 
            // 
            // 
            this.annotation1.Shape.Shadow.Visible = false;
            this.annotation1.Shape.Top = 50;
            this.annotation1.Shape.Transparent = true;
            this.annotation1.Text = "수리기간";
            this.annotation1.Top = 50;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.BtnPreview_Repair);
            this.groupControl3.Controls.Add(this.BtnPreview_Daily);
            this.groupControl3.Controls.Add(this.BtnConfig_Repair);
            this.groupControl3.Controls.Add(this.BtnReport_Repair);
            this.groupControl3.Controls.Add(this.BtnConfig_Daily);
            this.groupControl3.Controls.Add(this.BtnReport_Daily);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(6, 16);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(264, 178);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "groupControl3";
            // 
            // BtnPreview_Repair
            // 
            this.BtnPreview_Repair.AllowFocus = false;
            this.BtnPreview_Repair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_Repair.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_Repair.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_Repair.Appearance.Options.UseFont = true;
            this.BtnPreview_Repair.Appearance.Options.UseForeColor = true;
            this.BtnPreview_Repair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_Repair.ImageIndex = 0;
            this.BtnPreview_Repair.ImageList = this.SmallImageList;
            this.BtnPreview_Repair.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_Repair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_Repair.Location = new System.Drawing.Point(194, 106);
            this.BtnPreview_Repair.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_Repair.Name = "BtnPreview_Repair";
            this.BtnPreview_Repair.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_Repair.TabIndex = 15;
            this.BtnPreview_Repair.Text = "Preview";
            this.BtnPreview_Repair.Click += new System.EventHandler(this.BtnPreview_Repair_Click);
            // 
            // BtnPreview_Daily
            // 
            this.BtnPreview_Daily.AllowFocus = false;
            this.BtnPreview_Daily.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_Daily.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_Daily.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_Daily.Appearance.Options.UseFont = true;
            this.BtnPreview_Daily.Appearance.Options.UseForeColor = true;
            this.BtnPreview_Daily.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_Daily.ImageIndex = 0;
            this.BtnPreview_Daily.ImageList = this.SmallImageList;
            this.BtnPreview_Daily.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_Daily.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_Daily.Location = new System.Drawing.Point(194, 20);
            this.BtnPreview_Daily.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_Daily.Name = "BtnPreview_Daily";
            this.BtnPreview_Daily.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_Daily.TabIndex = 14;
            this.BtnPreview_Daily.Text = "Preview";
            this.BtnPreview_Daily.Click += new System.EventHandler(this.BtnPreview_Daily_Click);
            // 
            // BtnConfig_Repair
            // 
            this.BtnConfig_Repair.AllowFocus = false;
            this.BtnConfig_Repair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_Repair.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_Repair.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_Repair.Appearance.Options.UseFont = true;
            this.BtnConfig_Repair.Appearance.Options.UseForeColor = true;
            this.BtnConfig_Repair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_Repair.ImageIndex = 1;
            this.BtnConfig_Repair.ImageList = this.SmallImageList;
            this.BtnConfig_Repair.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_Repair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_Repair.Location = new System.Drawing.Point(137, 106);
            this.BtnConfig_Repair.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_Repair.Name = "BtnConfig_Repair";
            this.BtnConfig_Repair.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_Repair.TabIndex = 13;
            this.BtnConfig_Repair.Text = "설정";
            this.BtnConfig_Repair.Click += new System.EventHandler(this.BtnConfig_Repair_Click);
            // 
            // BtnReport_Repair
            // 
            this.BtnReport_Repair.AllowFocus = false;
            this.BtnReport_Repair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_Repair.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_Repair.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_Repair.Appearance.Options.UseFont = true;
            this.BtnReport_Repair.Appearance.Options.UseForeColor = true;
            this.BtnReport_Repair.ImageIndex = 6;
            this.BtnReport_Repair.ImageList = this.SmallImageList;
            this.BtnReport_Repair.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_Repair.Location = new System.Drawing.Point(7, 106);
            this.BtnReport_Repair.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnReport_Repair.Name = "BtnReport_Repair";
            this.BtnReport_Repair.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_Repair.TabIndex = 12;
            this.BtnReport_Repair.Text = "보전활동";
            // 
            // BtnConfig_Daily
            // 
            this.BtnConfig_Daily.AllowFocus = false;
            this.BtnConfig_Daily.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_Daily.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_Daily.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_Daily.Appearance.Options.UseFont = true;
            this.BtnConfig_Daily.Appearance.Options.UseForeColor = true;
            this.BtnConfig_Daily.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_Daily.ImageIndex = 1;
            this.BtnConfig_Daily.ImageList = this.SmallImageList;
            this.BtnConfig_Daily.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_Daily.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_Daily.Location = new System.Drawing.Point(137, 20);
            this.BtnConfig_Daily.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_Daily.Name = "BtnConfig_Daily";
            this.BtnConfig_Daily.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_Daily.TabIndex = 10;
            this.BtnConfig_Daily.Text = "설정";
            this.BtnConfig_Daily.Click += new System.EventHandler(this.BtnConfig_Daily_Click);
            // 
            // BtnReport_Daily
            // 
            this.BtnReport_Daily.AllowFocus = false;
            this.BtnReport_Daily.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_Daily.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_Daily.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_Daily.Appearance.Options.UseFont = true;
            this.BtnReport_Daily.Appearance.Options.UseForeColor = true;
            this.BtnReport_Daily.ImageIndex = 3;
            this.BtnReport_Daily.ImageList = this.SmallImageList;
            this.BtnReport_Daily.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_Daily.Location = new System.Drawing.Point(7, 20);
            this.BtnReport_Daily.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnReport_Daily.Name = "BtnReport_Daily";
            this.BtnReport_Daily.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_Daily.TabIndex = 6;
            this.BtnReport_Daily.Text = "일간";
            // 
            // Gr_Compare
            // 
            this.Gr_Compare.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 50F);
            this.Gr_Compare.AppearanceCaption.Options.UseFont = true;
            this.Gr_Compare.AppearanceCaption.Options.UseTextOptions = true;
            this.Gr_Compare.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Gr_Compare.CaptionImage = ((System.Drawing.Image)(resources.GetObject("Gr_Compare.CaptionImage")));
            this.Gr_Compare.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText;
            this.Gr_Compare.CaptionImagePadding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Gr_Compare.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.Gr_Compare.Controls.Add(this.tableLayoutPanel3);
            this.Gr_Compare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gr_Compare.Location = new System.Drawing.Point(3, 223);
            this.Gr_Compare.Name = "Gr_Compare";
            this.Gr_Compare.Size = new System.Drawing.Size(847, 214);
            this.Gr_Compare.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupControl9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(89, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(756, 210);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // groupControl9
            // 
            this.groupControl9.Controls.Add(this.Tchart_DayOfWeek);
            this.groupControl9.Controls.Add(this.Tchart_Period);
            this.groupControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl9.Location = new System.Drawing.Point(279, 16);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.ShowCaption = false;
            this.groupControl9.Size = new System.Drawing.Size(471, 178);
            this.groupControl9.TabIndex = 16;
            this.groupControl9.Text = "groupControl9";
            // 
            // Tchart_DayOfWeek
            // 
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Axes.Bottom.MaximumOffset = 78;
            this.Tchart_DayOfWeek.Axes.Bottom.MinimumOffset = 1;
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Axes.Right.MinimumOffset = 1;
            this.Tchart_DayOfWeek.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tchart_DayOfWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Header.Visible = false;
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            this.Tchart_DayOfWeek.Location = new System.Drawing.Point(2, 2);
            this.Tchart_DayOfWeek.Name = "Tchart_DayOfWeek";
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.Tchart_DayOfWeek.Series.Add(this.horizBar2);
            this.Tchart_DayOfWeek.Size = new System.Drawing.Size(467, 174);
            this.Tchart_DayOfWeek.TabIndex = 1;
            // 
            // 
            // 
            this.Tchart_DayOfWeek.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            // 
            // horizBar2
            // 
            // 
            // 
            // 
            this.horizBar2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.horizBar2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.horizBar2.ColorEach = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.horizBar2.Marks.Brush.Visible = false;
            // 
            // 
            // 
            this.horizBar2.Marks.Font.Bold = true;
            this.horizBar2.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.horizBar2.Marks.Transparent = true;
            // 
            // 
            // 
            this.horizBar2.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.horizBar2.Title = "Bandpass";
            // 
            // 
            // 
            this.horizBar2.XValues.DataMember = "X";
            // 
            // 
            // 
            this.horizBar2.YValues.DataMember = "막대";
            this.horizBar2.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // Tchart_Period
            // 
            // 
            // 
            // 
            this.Tchart_Period.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Period.Axes.Left.MaximumOffset = 10;
            this.Tchart_Period.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tchart_Period.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.Tchart_Period.Header.Visible = false;
            // 
            // 
            // 
            this.Tchart_Period.Legend.Alignment = Steema.TeeChart.LegendAlignments.Top;
            this.Tchart_Period.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            // 
            // 
            // 
            this.Tchart_Period.Legend.Shadow.Visible = false;
            this.Tchart_Period.Location = new System.Drawing.Point(2, 2);
            this.Tchart_Period.Name = "Tchart_Period";
            // 
            // 
            // 
            this.Tchart_Period.Panel.MarginBottom = 8D;
            // 
            // 
            // 
            this.Tchart_Period.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.Tchart_Period.Series.Add(this.bar1);
            this.Tchart_Period.Series.Add(this.bar2);
            this.Tchart_Period.Series.Add(this.bar3);
            this.Tchart_Period.Size = new System.Drawing.Size(467, 174);
            this.Tchart_Period.TabIndex = 1;
            this.Tchart_Period.Visible = false;
            // 
            // 
            // 
            this.Tchart_Period.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            // 
            // bar1
            // 
            // 
            // 
            // 
            this.bar1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.bar1.Brush.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar1.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bar1.Brush.Gradient.Sigma = true;
            this.bar1.Brush.Gradient.SigmaFocus = 0.447F;
            this.bar1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bar1.ColorEach = false;
            // 
            // 
            // 
            this.bar1.Marks.Visible = false;
            // 
            // 
            // 
            this.bar1.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.bar1.SeriesData = resources.GetString("bar1.SeriesData");
            this.bar1.Title = "DL(FEM)";
            // 
            // 
            // 
            this.bar1.XValues.DataMember = "X";
            this.bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.bar1.YValues.DataMember = "막대";
            // 
            // bar2
            // 
            // 
            // 
            // 
            this.bar2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.bar2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.bar2.ColorEach = false;
            // 
            // 
            // 
            this.bar2.Marks.Visible = false;
            // 
            // 
            // 
            this.bar2.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.bar2.SeriesData = resources.GetString("bar2.SeriesData");
            this.bar2.Title = "DL(FCM)";
            // 
            // 
            // 
            this.bar2.XValues.DataMember = "X";
            this.bar2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.bar2.YValues.DataMember = "막대";
            // 
            // bar3
            // 
            // 
            // 
            // 
            this.bar3.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.bar3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.bar3.ColorEach = false;
            // 
            // 
            // 
            this.bar3.Marks.Visible = false;
            // 
            // 
            // 
            this.bar3.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(46)))), ((int)(((byte)(12)))));
            this.bar3.SeriesData = resources.GetString("bar3.SeriesData");
            this.bar3.Title = "DL(RCM)";
            // 
            // 
            // 
            this.bar3.XValues.DataMember = "X";
            this.bar3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.bar3.YValues.DataMember = "막대";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.BtnPreview_Period);
            this.groupControl1.Controls.Add(this.BtnPreview_DayOfWeek);
            this.groupControl1.Controls.Add(this.BtnConfig_Period);
            this.groupControl1.Controls.Add(this.BtnReport_Period);
            this.groupControl1.Controls.Add(this.BtnConfig_DayOfWeek);
            this.groupControl1.Controls.Add(this.BtnReport_DayOfWeek);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(6, 16);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(264, 178);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "groupControl1";
            // 
            // BtnPreview_Period
            // 
            this.BtnPreview_Period.AllowFocus = false;
            this.BtnPreview_Period.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_Period.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_Period.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_Period.Appearance.Options.UseFont = true;
            this.BtnPreview_Period.Appearance.Options.UseForeColor = true;
            this.BtnPreview_Period.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_Period.ImageIndex = 0;
            this.BtnPreview_Period.ImageList = this.SmallImageList;
            this.BtnPreview_Period.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_Period.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_Period.Location = new System.Drawing.Point(194, 103);
            this.BtnPreview_Period.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_Period.Name = "BtnPreview_Period";
            this.BtnPreview_Period.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_Period.TabIndex = 15;
            this.BtnPreview_Period.Text = "Preview";
            this.BtnPreview_Period.Click += new System.EventHandler(this.BtnPreview_Period_Click);
            // 
            // BtnPreview_DayOfWeek
            // 
            this.BtnPreview_DayOfWeek.AllowFocus = false;
            this.BtnPreview_DayOfWeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_DayOfWeek.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_DayOfWeek.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_DayOfWeek.Appearance.Options.UseFont = true;
            this.BtnPreview_DayOfWeek.Appearance.Options.UseForeColor = true;
            this.BtnPreview_DayOfWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_DayOfWeek.ImageIndex = 0;
            this.BtnPreview_DayOfWeek.ImageList = this.SmallImageList;
            this.BtnPreview_DayOfWeek.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_DayOfWeek.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_DayOfWeek.Location = new System.Drawing.Point(194, 17);
            this.BtnPreview_DayOfWeek.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_DayOfWeek.Name = "BtnPreview_DayOfWeek";
            this.BtnPreview_DayOfWeek.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_DayOfWeek.TabIndex = 14;
            this.BtnPreview_DayOfWeek.Text = "Preview";
            this.BtnPreview_DayOfWeek.Click += new System.EventHandler(this.BtnPreview_DayOfWeek_Click);
            // 
            // BtnConfig_Period
            // 
            this.BtnConfig_Period.AllowFocus = false;
            this.BtnConfig_Period.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_Period.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_Period.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_Period.Appearance.Options.UseFont = true;
            this.BtnConfig_Period.Appearance.Options.UseForeColor = true;
            this.BtnConfig_Period.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_Period.ImageIndex = 1;
            this.BtnConfig_Period.ImageList = this.SmallImageList;
            this.BtnConfig_Period.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_Period.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_Period.Location = new System.Drawing.Point(137, 103);
            this.BtnConfig_Period.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_Period.Name = "BtnConfig_Period";
            this.BtnConfig_Period.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_Period.TabIndex = 13;
            this.BtnConfig_Period.Text = "설정";
            this.BtnConfig_Period.Click += new System.EventHandler(this.BtnConfig_Period_Click);
            // 
            // BtnReport_Period
            // 
            this.BtnReport_Period.AllowFocus = false;
            this.BtnReport_Period.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_Period.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_Period.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_Period.Appearance.Options.UseFont = true;
            this.BtnReport_Period.Appearance.Options.UseForeColor = true;
            this.BtnReport_Period.ImageIndex = 4;
            this.BtnReport_Period.ImageList = this.SmallImageList;
            this.BtnReport_Period.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_Period.Location = new System.Drawing.Point(7, 103);
            this.BtnReport_Period.Name = "BtnReport_Period";
            this.BtnReport_Period.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_Period.TabIndex = 12;
            this.BtnReport_Period.Text = "기간 비교";
            // 
            // BtnConfig_DayOfWeek
            // 
            this.BtnConfig_DayOfWeek.AllowFocus = false;
            this.BtnConfig_DayOfWeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_DayOfWeek.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_DayOfWeek.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_DayOfWeek.Appearance.Options.UseFont = true;
            this.BtnConfig_DayOfWeek.Appearance.Options.UseForeColor = true;
            this.BtnConfig_DayOfWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_DayOfWeek.ImageIndex = 1;
            this.BtnConfig_DayOfWeek.ImageList = this.SmallImageList;
            this.BtnConfig_DayOfWeek.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_DayOfWeek.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_DayOfWeek.Location = new System.Drawing.Point(137, 17);
            this.BtnConfig_DayOfWeek.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_DayOfWeek.Name = "BtnConfig_DayOfWeek";
            this.BtnConfig_DayOfWeek.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_DayOfWeek.TabIndex = 10;
            this.BtnConfig_DayOfWeek.Text = "설정";
            this.BtnConfig_DayOfWeek.Click += new System.EventHandler(this.BtnConfig_DayOfWeek_Click);
            // 
            // BtnReport_DayOfWeek
            // 
            this.BtnReport_DayOfWeek.AllowFocus = false;
            this.BtnReport_DayOfWeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_DayOfWeek.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_DayOfWeek.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_DayOfWeek.Appearance.Options.UseFont = true;
            this.BtnReport_DayOfWeek.Appearance.Options.UseForeColor = true;
            this.BtnReport_DayOfWeek.ImageIndex = 2;
            this.BtnReport_DayOfWeek.ImageList = this.SmallImageList;
            this.BtnReport_DayOfWeek.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_DayOfWeek.Location = new System.Drawing.Point(7, 17);
            this.BtnReport_DayOfWeek.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnReport_DayOfWeek.Name = "BtnReport_DayOfWeek";
            this.BtnReport_DayOfWeek.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_DayOfWeek.TabIndex = 6;
            this.BtnReport_DayOfWeek.Text = "요일 비교";
            this.BtnReport_DayOfWeek.Click += new System.EventHandler(this.BtnReport_DayOfWeek_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupControl2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Tchart_Trend, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(89, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(756, 190);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.BtnPreview_BandpassTrend);
            this.groupControl2.Controls.Add(this.BtnPreview_PointTrend);
            this.groupControl2.Controls.Add(this.BtnConfig_BandpassTrend);
            this.groupControl2.Controls.Add(this.BtnReport_BandpassTrend);
            this.groupControl2.Controls.Add(this.BtnConfig_PointTrend);
            this.groupControl2.Controls.Add(this.BtnReport_PointTrend);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(6, 8);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(264, 174);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "groupControl2";
            // 
            // BtnPreview_BandpassTrend
            // 
            this.BtnPreview_BandpassTrend.AllowFocus = false;
            this.BtnPreview_BandpassTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnPreview_BandpassTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnPreview_BandpassTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_BandpassTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_BandpassTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_BandpassTrend.Appearance.Options.UseFont = true;
            this.BtnPreview_BandpassTrend.Appearance.Options.UseForeColor = true;
            this.BtnPreview_BandpassTrend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_BandpassTrend.ImageIndex = 0;
            this.BtnPreview_BandpassTrend.ImageList = this.SmallImageList;
            this.BtnPreview_BandpassTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_BandpassTrend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_BandpassTrend.Location = new System.Drawing.Point(192, 101);
            this.BtnPreview_BandpassTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_BandpassTrend.Name = "BtnPreview_BandpassTrend";
            this.BtnPreview_BandpassTrend.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_BandpassTrend.TabIndex = 15;
            this.BtnPreview_BandpassTrend.Text = "Preview";
            this.BtnPreview_BandpassTrend.Click += new System.EventHandler(this.BtnPreview_MultPointTrend_Click);
            // 
            // BtnPreview_PointTrend
            // 
            this.BtnPreview_PointTrend.AllowFocus = false;
            this.BtnPreview_PointTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnPreview_PointTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnPreview_PointTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnPreview_PointTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnPreview_PointTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnPreview_PointTrend.Appearance.Options.UseFont = true;
            this.BtnPreview_PointTrend.Appearance.Options.UseForeColor = true;
            this.BtnPreview_PointTrend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPreview_PointTrend.ImageIndex = 0;
            this.BtnPreview_PointTrend.ImageList = this.SmallImageList;
            this.BtnPreview_PointTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnPreview_PointTrend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnPreview_PointTrend.Location = new System.Drawing.Point(192, 15);
            this.BtnPreview_PointTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnPreview_PointTrend.Name = "BtnPreview_PointTrend";
            this.BtnPreview_PointTrend.Size = new System.Drawing.Size(67, 58);
            this.BtnPreview_PointTrend.TabIndex = 14;
            this.BtnPreview_PointTrend.Text = "Preview";
            this.BtnPreview_PointTrend.Click += new System.EventHandler(this.BtnPreview_MultiBandTrend_Click);
            // 
            // BtnConfig_BandpassTrend
            // 
            this.BtnConfig_BandpassTrend.AllowFocus = false;
            this.BtnConfig_BandpassTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnConfig_BandpassTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnConfig_BandpassTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_BandpassTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_BandpassTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_BandpassTrend.Appearance.Options.UseFont = true;
            this.BtnConfig_BandpassTrend.Appearance.Options.UseForeColor = true;
            this.BtnConfig_BandpassTrend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_BandpassTrend.ImageIndex = 1;
            this.BtnConfig_BandpassTrend.ImageList = this.SmallImageList;
            this.BtnConfig_BandpassTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_BandpassTrend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_BandpassTrend.Location = new System.Drawing.Point(135, 101);
            this.BtnConfig_BandpassTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_BandpassTrend.Name = "BtnConfig_BandpassTrend";
            this.BtnConfig_BandpassTrend.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_BandpassTrend.TabIndex = 13;
            this.BtnConfig_BandpassTrend.Text = "설정";
            this.BtnConfig_BandpassTrend.Click += new System.EventHandler(this.BtnConfig_MultiPointTrend_Click);
            // 
            // BtnReport_BandpassTrend
            // 
            this.BtnReport_BandpassTrend.AllowFocus = false;
            this.BtnReport_BandpassTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnReport_BandpassTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnReport_BandpassTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_BandpassTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_BandpassTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_BandpassTrend.Appearance.Options.UseFont = true;
            this.BtnReport_BandpassTrend.Appearance.Options.UseForeColor = true;
            this.BtnReport_BandpassTrend.ImageIndex = 5;
            this.BtnReport_BandpassTrend.ImageList = this.SmallImageList;
            this.BtnReport_BandpassTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_BandpassTrend.Location = new System.Drawing.Point(5, 101);
            this.BtnReport_BandpassTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnReport_BandpassTrend.Name = "BtnReport_BandpassTrend";
            this.BtnReport_BandpassTrend.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_BandpassTrend.TabIndex = 12;
            this.BtnReport_BandpassTrend.Text = "밴드별 추이";
            this.BtnReport_BandpassTrend.Click += new System.EventHandler(this.BtnReport_MultiPointTrend_Click);
            // 
            // BtnConfig_PointTrend
            // 
            this.BtnConfig_PointTrend.AllowFocus = false;
            this.BtnConfig_PointTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnConfig_PointTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnConfig_PointTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnConfig_PointTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnConfig_PointTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnConfig_PointTrend.Appearance.Options.UseFont = true;
            this.BtnConfig_PointTrend.Appearance.Options.UseForeColor = true;
            this.BtnConfig_PointTrend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnConfig_PointTrend.ImageIndex = 1;
            this.BtnConfig_PointTrend.ImageList = this.SmallImageList;
            this.BtnConfig_PointTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnConfig_PointTrend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnConfig_PointTrend.Location = new System.Drawing.Point(135, 15);
            this.BtnConfig_PointTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnConfig_PointTrend.Name = "BtnConfig_PointTrend";
            this.BtnConfig_PointTrend.Size = new System.Drawing.Size(54, 58);
            this.BtnConfig_PointTrend.TabIndex = 10;
            this.BtnConfig_PointTrend.Text = "설정";
            this.BtnConfig_PointTrend.Click += new System.EventHandler(this.BtnConfig_BandTrend_Click);
            // 
            // BtnReport_PointTrend
            // 
            this.BtnReport_PointTrend.AllowFocus = false;
            this.BtnReport_PointTrend.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False;
            this.BtnReport_PointTrend.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.BtnReport_PointTrend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReport_PointTrend.Appearance.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold);
            this.BtnReport_PointTrend.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnReport_PointTrend.Appearance.Options.UseFont = true;
            this.BtnReport_PointTrend.Appearance.Options.UseForeColor = true;
            this.BtnReport_PointTrend.ImageIndex = 5;
            this.BtnReport_PointTrend.ImageList = this.SmallImageList;
            this.BtnReport_PointTrend.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.BtnReport_PointTrend.Location = new System.Drawing.Point(5, 15);
            this.BtnReport_PointTrend.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.BtnReport_PointTrend.Name = "BtnReport_PointTrend";
            this.BtnReport_PointTrend.Size = new System.Drawing.Size(133, 58);
            this.BtnReport_PointTrend.TabIndex = 6;
            this.BtnReport_PointTrend.Text = "포인트별 추이";
            this.BtnReport_PointTrend.Click += new System.EventHandler(this.BtnReport_MultiBand_Click);
            // 
            // Tchart_Trend
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Aspect.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.Tchart_Trend.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Bottom.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Tchart_Trend.Axes.Bottom.Increment = 1D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Bottom.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Bottom.Title.Font.Name = "Arial";
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Depth.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Depth.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Depth.Title.Font.Name = "Arial";
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.DepthTop.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.DepthTop.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.DepthTop.Title.Font.Name = "Arial";
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Left.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Left.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Left.Title.Font.Name = "Arial";
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Right.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Right.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Right.Title.Font.Name = "Arial";
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Top.AxisPen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Tchart_Trend.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.Labels.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.Ticks.Length = 2;
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Axes.Top.TicksInner.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Axes.Top.Title.Font.Name = "Arial";
            this.Tchart_Trend.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tchart_Trend.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Header.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Header.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Header.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Header.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Header.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Header.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.Tchart_Trend.Header.Font.Name = "Arial";
            // 
            // 
            // 
            this.Tchart_Trend.Header.Pen.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Header.Shadow.Height = 0;
            this.Tchart_Trend.Header.Shadow.Width = 0;
            this.Tchart_Trend.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Legend.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Legend.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Legend.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Legend.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Legend.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.Tchart_Trend.Legend.Font.Name = "Arial";
            this.Tchart_Trend.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            // 
            // 
            // 
            this.Tchart_Trend.Legend.Shadow.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Legend.Symbol.Width = 15;
            this.Tchart_Trend.Location = new System.Drawing.Point(279, 8);
            this.Tchart_Trend.Name = "Tchart_Trend";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Panel.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Panel.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Panel.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Panel.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tchart_Trend.Panel.Brush.Gradient.UseMiddle = false;
            this.Tchart_Trend.Panel.Brush.Gradient.Visible = false;
            this.Tchart_Trend.Panel.MarginBottom = 8D;
            // 
            // 
            // 
            this.Tchart_Trend.Panel.Shadow.Height = 0;
            this.Tchart_Trend.Panel.Shadow.Width = 0;
            // 
            // 
            // 
            this.Tchart_Trend.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.Tchart_Trend.Series.Add(this.fastLine1);
            this.Tchart_Trend.Size = new System.Drawing.Size(471, 174);
            this.Tchart_Trend.TabIndex = 1;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Back.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Back.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Back.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Walls.Back.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Walls.Back.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tchart_Trend.Walls.Back.Brush.Gradient.Visible = false;
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Back.Pen.Visible = false;
            this.Tchart_Trend.Walls.Back.Transparent = true;
            this.Tchart_Trend.Walls.Back.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Bottom.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Bottom.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Bottom.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Walls.Bottom.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Walls.Bottom.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tchart_Trend.Walls.Bottom.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Left.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Left.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Left.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Walls.Left.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Walls.Left.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tchart_Trend.Walls.Left.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.Tchart_Trend.Walls.Right.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Right.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Tchart_Trend.Walls.Right.Brush.Gradient.SigmaFocus = 0F;
            this.Tchart_Trend.Walls.Right.Brush.Gradient.SigmaScale = 0F;
            this.Tchart_Trend.Walls.Right.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.Tchart_Trend.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            // 
            // fastLine1
            // 
            this.fastLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.fastLine1.ColorEach = false;
            // 
            // 
            // 
            this.fastLine1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.fastLine1.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.fastLine1.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fastLine1.Marks.Brush.Gradient.SigmaFocus = 0F;
            this.fastLine1.Marks.Brush.Gradient.SigmaScale = 0F;
            this.fastLine1.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.fastLine1.Marks.Font.Name = "Arial";
            this.fastLine1.SeriesData = resources.GetString("fastLine1.SeriesData");
            this.fastLine1.Title = "Vrms";
            this.fastLine1.TreatNulls = Steema.TeeChart.Styles.TreatNullsStyle.Ignore;
            // 
            // 
            // 
            this.fastLine1.XValues.DataMember = "X";
            this.fastLine1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.fastLine1.YValues.DataMember = "Y";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Gr_Variation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Gr_Compare, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Gr_Report, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 660);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Gr_Variation
            // 
            this.Gr_Variation.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 50F);
            this.Gr_Variation.AppearanceCaption.Options.UseFont = true;
            this.Gr_Variation.AppearanceCaption.Options.UseTextOptions = true;
            this.Gr_Variation.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Gr_Variation.CaptionImage = ((System.Drawing.Image)(resources.GetObject("Gr_Variation.CaptionImage")));
            this.Gr_Variation.CaptionImageLocation = DevExpress.Utils.GroupElementLocation.BeforeText;
            this.Gr_Variation.CaptionImagePadding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Gr_Variation.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.Gr_Variation.Controls.Add(this.tableLayoutPanel2);
            this.Gr_Variation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gr_Variation.Location = new System.Drawing.Point(3, 3);
            this.Gr_Variation.Name = "Gr_Variation";
            this.Gr_Variation.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Gr_Variation.Size = new System.Drawing.Size(847, 214);
            this.Gr_Variation.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 660);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMX 보고서 프로그램 v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Report)).EndInit();
            this.Gr_Report.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Compare)).EndInit();
            this.Gr_Compare.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gr_Variation)).EndInit();
            this.Gr_Variation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList SmallImageList;
        private DevExpress.XtraEditors.GroupControl Gr_Report;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_Repair;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_Daily;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_Repair;
        private DevExpress.XtraEditors.SimpleButton BtnReport_Repair;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_Daily;
        private DevExpress.XtraEditors.SimpleButton BtnReport_Daily;
        private DevExpress.XtraEditors.GroupControl Gr_Compare;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.GroupControl groupControl9;
        private Steema.TeeChart.TChart Tchart_DayOfWeek;
        private Steema.TeeChart.TChart Tchart_Period;
        private Steema.TeeChart.Styles.Bar bar1;
        private Steema.TeeChart.Styles.Bar bar2;
        private Steema.TeeChart.Styles.Bar bar3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_Period;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_DayOfWeek;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_Period;
        private DevExpress.XtraEditors.SimpleButton BtnReport_Period;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_DayOfWeek;
        private DevExpress.XtraEditors.SimpleButton BtnReport_DayOfWeek;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_BandpassTrend;
        private DevExpress.XtraEditors.SimpleButton BtnPreview_PointTrend;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_BandpassTrend;
        private DevExpress.XtraEditors.SimpleButton BtnReport_BandpassTrend;
        private DevExpress.XtraEditors.SimpleButton BtnConfig_PointTrend;
        private DevExpress.XtraEditors.SimpleButton BtnReport_PointTrend;
        private Steema.TeeChart.TChart Tchart_Trend;
        private Steema.TeeChart.Styles.FastLine fastLine1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl Gr_Variation;
        private Steema.TeeChart.Styles.HorizBar horizBar2;
        private Steema.TeeChart.TChart Tchart_RepairTrend;
        private Steema.TeeChart.Styles.FastLine fastLine2;
        private Steema.TeeChart.Tools.ColorBand colorBand1;
        private Steema.TeeChart.Tools.Annotation annotation1;


    }
}
