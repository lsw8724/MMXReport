using System;
using DevExpress.XtraEditors;
using MMXReport.Properties;
using MMXReport.Dialog;
using System.Data;
using Steema.TeeChart.Styles;
using MMXReport.TsiConfig;
using System.Collections.Generic;

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
            Tchart_DayOfWeek.Series.Clear();
            if (DayOfWeekConf.Channel != null)
            {
                var datas = DBConn.LoadDayOfWeekData(DayOfWeekConf);
                Tchart_DayOfWeek.Legend.Visible = (datas.Count != 1) ? true : false;
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
            Tchart_Period.Series.Clear();
            Tchart_DayOfWeek.Hide();
            Tchart_Period.Show();
            if (PeriodConf.SelectedChannelList != null)
            {
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
            new ExcelIOManager("HantaDailyReport1.xlsx");
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
            Tchart_Trend.Series.Clear();
            if (MultiBandConf.Channel != null)
            { 
                switch (MultiBandConf.StatTermType)
                {
                    case "day":
                        foreach (var dataTable in DBConn.LoadMultiBandpassTrendData(MultiBandConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[3]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "월" + data.ItemArray[2].ToString() + "일");
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
            new ChartCapturer(Tchart_Trend.Size,tableLayoutPanel2.PointToClient(Tchart_Trend.Location));
        }

        private void BtnPreview_MultPointTrend_Click(object sender, EventArgs e)
        {
            Tchart_Trend.Series.Clear();
            if (MultiPointConf.SelectedChannelList != null)
            {
                switch (MultiPointConf.StatTermType)
                {
                    case "day":
                        foreach (var dataTable in DBConn.LoadMultiPointTrendData(MultiPointConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[3]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "월" + data.ItemArray[2].ToString() + "일");
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

        }

        private void BtnPreview_Daily_Click(object sender, EventArgs e)
        {
            DataTable table = DBConn.LoadDailyData(DailyConf);
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
            Tchart_RepairTrend.Axes.Bottom.Labels.DateTimeFormat = "yyyy년\nM월 d일";
            Tchart_RepairTrend.Series.Clear();
            colorBand1.Start = RepairConf.BeforeRepairDate.ToOADate();
            colorBand1.End = RepairConf.AfterRepairDate.ToOADate();
            RepairConf.StartDate = RepairConf.BeforeRepairDate.AddDays(-1*RepairConf.RepairOffsetDay);
            RepairConf.EndDate = RepairConf.AfterRepairDate.AddDays(RepairConf.RepairOffsetDay);
            if (RepairConf.Channel != null)
            {
                foreach (var dataTable in DBConn.LoadRepairData(RepairConf))
                {
                    FastLine fastline = new FastLine() { Title = dataTable.TableName };
                    Tchart_RepairTrend.Series.Add(fastline);
                    foreach (DataRow data in dataTable.Rows)
                        fastline.Add((DateTime)data.ItemArray[0], Convert.ToDouble(data.ItemArray[1]));
                }
            }
        }

        
    }
}