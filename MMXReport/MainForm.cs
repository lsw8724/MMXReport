using System;
using System.Linq;
using DevExpress.XtraEditors;
using MMXReport.Properties;
using MMXReport.Dialog;
using System.Data;
using Steema.TeeChart.Styles;
using MMXReport.TsiConfig;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using Steema.TeeChart;

namespace MMXReport
{
    public partial class MainForm : XtraForm
    {
        public DBConnector DBConn { get; set; }
        public CommonConfig CommonConf { get; set; }
        private MultiBandpassConfiguration MultiBandConf { get; set; }
        private MultiBandpassConfigDlg MultiBandConfigDlg { get; set; }
        private DayOfWeekConfiguration DayOfWeekConf { get; set; }
        private DayOfWeekConfigDlg DayOfWeekConfigDlg { get; set; }
        private DailyConfiguration DailyConf { get; set; }
        private DailyConfigDlg DailyConfDlg { get; set; }
        private MultiPointConfiguration MultiPointConf { get; set; }
        private MultiPointConfigDlg MultiPointConfigDlg { get; set; }
        private PeriodConfiguration PeriodConf { get; set; }
        private PeriodConfigDlg PeriodConfigDlg { get; set; }
        private RepairConfiguration RepairConf { get; set; }
        private RepairConfigDlg RepairConfigDlg { get; set; }
        public MainForm()
        {
            InitializeComponent();
            
            CreateTempPreview();
            DBConn = new DBConnector();

            CommonConf = new CommonConfig(DBConn);
            MultiBandConf = new MultiBandpassConfiguration(DBConn);
            MultiPointConf = new MultiPointConfiguration(DBConn);
            DayOfWeekConf = new DayOfWeekConfiguration(DBConn);
            PeriodConf = new PeriodConfiguration(DBConn);
            DailyConf = new DailyConfiguration(DBConn);
            RepairConf = new RepairConfiguration(DBConn);

            DailyConfDlg = new DailyConfigDlg(DailyConf) { Owner = this };
            MultiBandConfigDlg = new MultiBandpassConfigDlg(CommonConf, MultiBandConf) { Owner = this };
            MultiPointConfigDlg = new MultiPointConfigDlg(CommonConf, MultiPointConf) { Owner = this };
            DayOfWeekConfigDlg = new DayOfWeekConfigDlg(CommonConf, DayOfWeekConf) { Owner = this };
            PeriodConfigDlg = new PeriodConfigDlg(CommonConf, PeriodConf) { Owner = this };
            RepairConfigDlg = new RepairConfigDlg(CommonConf,RepairConf) { Owner = this };
        }

        private void CreateTempPreview()
        {
            string[] week = new string[5] { "금", "목", "수", "화", "월" };
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
                Tchart_DayOfWeek.Series[0].Add(rand.Next(5, 10), week[i]);
            Tchart_Trend.Series[0].FillSampleValues();
            Tchart_Period.Series[0].FillSampleValues();
            Tchart_Period.Series[1].FillSampleValues();
            Tchart_Period.Series[2].FillSampleValues();
            Tchart_RepairTrend.Series[0].FillSampleValues();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "MMX 보고서 프로그램 v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void BtnConfig_BandTrend_Click(object sender, EventArgs e)
        {
            MultiBandConfigDlg.Show();
        }

        private void BtnConfig_MultiPointTrend_Click(object sender, EventArgs e)
        {
            MultiPointConfigDlg.Show();
        }

        private void BtnPreview_DayOfWeek_Click(object sender, EventArgs e)
        {
            Tchart_DayOfWeek.Visible = true;
            if (DayOfWeekConf.Channel != null)
            {
                Tchart_DayOfWeek.Series.Clear();
                Tchart_DayOfWeek.Header.Lines = new string[] { DayOfWeekConf.Channel.BandpassArr.Where(x=>x.Active).First().DisplayName };
                var datas = DBConn.LoadDayOfWeekData(DayOfWeekConf);
                Tchart_DayOfWeek.Legend.Visible = (datas.Count != 1) ? true : false;
                Tchart_DayOfWeek.Header.Visible = (datas.Count != 1) ? false : true;
                foreach (var dataTable in datas)
                {
                    HorizBar hBar = new HorizBar() { Title = dataTable.TableName, ColorEach = (datas.Count ==1)? true:false };
                    hBar.Marks.Font.Bold = true;
                    hBar.Marks.Style = MarksStyles.Value;
                    Tchart_DayOfWeek.Series.Add(hBar);
                    foreach (DataRow data in dataTable.Rows)
                        hBar.Add(Convert.ToDouble(data.ItemArray[1]), data.ItemArray[0].ToString());
                }
            }
        }

        private void BtnPreview_Period_Click(object sender, EventArgs e)
        {
            Tchart_DayOfWeek.Hide();
            Tchart_Period.Show();
            if (PeriodConf.SelectedChannelList != null)
            {
                Tchart_Period.Series.Clear();
                Tchart_Period.Header.Lines = new string[] { PeriodConf.SelectedBandpass.DisplayName };
                foreach (DataTable table in DBConn.LoadPeriodData(PeriodConf))
                {
                    Bar barSeries = new Bar() { Title = table.TableName };
                    barSeries.Marks.Visible = false;
                    Tchart_Period.Series.Add(barSeries);
                    foreach (DataRow data in table.Rows)
                        barSeries.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString());
                }
            }
        }

        private void BtnReport_DayOfWeek_Click(object sender, EventArgs e)
        {
             BtnPreview_DayOfWeek_Click(null, null);
            if (DayOfWeekConf.Channel != null)
            {
                new ExcelIOManager("Template_CommonReport.xlsx", new ReportItem()
                {
                    DateTime = DayOfWeekConf.StartDateStr + " ~ " + DayOfWeekConf.EndDateStr,
                    Name = "요일별 비교 분석 보고서",
                    Machine = DayOfWeekConf.Channel.MachineName,
                    Ref = "Point",
                    Value = DayOfWeekConf.Channel.PointName,
                    AnalysisType = "* BarChart Analysis",
                    Img = ChartCaptur(Tchart_DayOfWeek)
                });
            }
        }

        private void BtnConfig_DayOfWeek_Click(object sender, EventArgs e)
        {
            DayOfWeekConfigDlg.Show();
        }

        private void BtnConfig_Period_Click(object sender, EventArgs e)
        {
            PeriodConfigDlg.Show();
        }

        

        private void BtnPreview_MultiBandTrend_Click(object sender, EventArgs e)
        {
            Tchart_Trend.Visible = true;
            if (MultiBandConf.Channel != null)
            {
                Tchart_Trend.Series.Clear();
                Tchart_Trend.Header.Lines = new string[] { MultiBandConf.Channel.PointName };
                switch (MultiBandConf.StatTermType)
                {
                    case "day":
                        foreach (var dataTable in DBConn.LoadMultiBandpassTrendData(MultiBandConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[3]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "." + data.ItemArray[2].ToString());
                        } break;
                    case "week":
                        foreach (var dataTable in DBConn.LoadMultiBandpassTrendData(MultiBandConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "주");
                        } break;
                    case "month":
                        foreach (var dataTable in DBConn.LoadMultiBandpassTrendData(MultiBandConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "월");
                        } break;
                }
            }
        }

        private void BtnConfig_Daily_Click(object sender, EventArgs e)
        {
            DailyConfDlg.Show();
        }

        private void BtnConfig_Repair_Click(object sender, EventArgs e)
        {
            RepairConfigDlg.Show();
        }

        private void BtnReport_MultiBand_Click(object sender, EventArgs e)
        {
            BtnPreview_MultiBandTrend_Click(null, null); 
            if (MultiBandConf.Channel != null)
            {
                new ExcelIOManager("Template_CommonReport.xlsx", new ReportItem()
                {
                    DateTime = MultiBandConf.StartDateStr + " ~ " + MultiBandConf.EndDateStr,
                    Name = "포인트별 추이 분석 보고서",
                    Machine = MultiBandConf.Channel.MachineName,
                    Ref = "Point",
                    Value = MultiBandConf.Channel.PointName,
                    AnalysisType ="* Trend Analysis",
                    Img = ChartCaptur(Tchart_Trend)
                });
            }
        }

        private void BtnPreview_MultPointTrend_Click(object sender, EventArgs e)
        {
            if (MultiPointConf.SelectedChannelList != null)
            {
                Tchart_Trend.Series.Clear();
                Tchart_Trend.Header.Lines = new string[] { MultiPointConf.SelectedBandpass.DisplayName };
                switch (MultiPointConf.StatTermType)
                {
                    case "day":
                        foreach (var dataTable in DBConn.LoadMultiPointTrendData(MultiPointConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[3]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "." + data.ItemArray[2].ToString());
                        } break;
                    case "week":
                        foreach (var dataTable in DBConn.LoadMultiPointTrendData(MultiPointConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "주");
                        } break;
                    case "month":
                        foreach (var dataTable in DBConn.LoadMultiPointTrendData(MultiPointConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "월");
                        } break;
                }
            }
        }

        private void BtnReport_MultiPointTrend_Click(object sender, EventArgs e)
        {
            BtnPreview_MultPointTrend_Click(null, null);
            if (MultiPointConf.SelectedChannelList.Count > 0)
            {
                new ExcelIOManager("Template_CommonReport.xlsx", new ReportItem()
                {
                    DateTime = MultiPointConf.StartDateStr + " ~ " + MultiPointConf.EndDateStr,
                    Name = "밴드별 추이 분석 보고서",
                    Machine = MultiPointConf.SelectedChannelList[0].MachineName,
                    Ref = "Measure",
                    Value = MultiPointConf.SelectedBandpass.DisplayName,
                    AnalysisType = "* Trend Analysis",
                    Img = ChartCaptur(Tchart_Trend)
                });
            }
        }

        private void BtnPreview_Daily_Click(object sender, EventArgs e)
        {
            Tchart_RepairTrend.Visible = false;
            Grid_DailyData.Visible = true;
            DataTable table = DBConn.LoadDailyData(DailyConf);
            //Grid_DailyData.DataSource = table;
            var overrideOrder = Enum.GetNames(typeof(VectorOverrideOrder));
            foreach (DataRow row in table.Rows) // 0 chid, 3 overrideName, 4 unit, 5 alarm
            {
                int chid = Convert.ToInt32(row.ItemArray[0]);
                DspVectorOverride[] overrides = DBConn.LoadExtraJSON(chid).VectorOverrides;
                string bandpassName = row.ItemArray[3].ToString();
                int idx = Array.IndexOf(overrideOrder, bandpassName);
                DspVectorOverride vectorOverride = overrides[idx];
                if (vectorOverride.Override && vectorOverride.OverrideName != string.Empty)
                    row.ItemArray[3] = vectorOverride.OverrideName; //값 update 안됨!
                row.ItemArray[4] = vectorOverride.OverrideUnit;
            }
        }

        private void BtnPreview_Repair_Click(object sender, EventArgs e)
        {
            Tchart_RepairTrend.Visible = true;
            Grid_DailyData.Visible = false;
            if (RepairConf.Channel != null)
            {
                Tchart_RepairTrend.Axes.Bottom.Labels.DateTimeFormat = "yyyy년\nM월 d일";
                Tchart_RepairTrend.Series.Clear();
                Tchart_RepairTrend.Header.Lines = new string[] { RepairConf.Channel.PointName};
                colorBand1.Start = RepairConf.BeforeRepairDate.ToOADate();
                colorBand1.End = RepairConf.AfterRepairDate.ToOADate();
                RepairConf.StartDate = RepairConf.BeforeRepairDate.AddDays(-1 * RepairConf.RepairOffsetDay);
                RepairConf.EndDate = RepairConf.AfterRepairDate.AddDays(RepairConf.RepairOffsetDay);
                foreach (var dataTable in DBConn.LoadRepairData(RepairConf))
                {
                    FastLine fastline = new FastLine() { Title = dataTable.TableName };
                    Tchart_RepairTrend.Series.Add(fastline);
                    foreach (DataRow data in dataTable.Rows)
                        fastline.Add((DateTime)data.ItemArray[0], Convert.ToDouble(data.ItemArray[1]));
                }
            }
        }
        private Bitmap ChartCaptur(TChart tchart)
        {
            tchart.Graphics3D.UseBuffer = false;
            Rectangle rect = new Rectangle(0, 0, tchart.Width, tchart.Height);
            Bitmap screenshot = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppArgb);

            tchart.DrawToBitmap(screenshot, rect);
            return ResizeBitmap(screenshot, 740);
        }
        private Bitmap ResizeBitmap(Bitmap sourceBMP, int width)
        {
            int height = Convert.ToInt32(sourceBMP.Height * (width / (float)sourceBMP.Width));
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
            return result;
        }
    }
}