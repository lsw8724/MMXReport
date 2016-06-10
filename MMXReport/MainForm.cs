﻿using System;
using System.Linq;
using DevExpress.XtraEditors;
using MMXReport.Properties;
using MMXReport.Dialog;
using System.Data;
using Steema.TeeChart.Styles;
using System.ComponentModel;
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
        private ExcelIOManager ExcelManager { get; set; }
        public MainForm()
        {
            InitializeComponent();

            #region MultiLang
            BtnReport_BandpassTrend.Text = MultiLang.TrendOfMeasure;
            BtnReport_PointTrend.Text = MultiLang.TrendOfPoint;
            BtnReport_DayOfWeek.Text = MultiLang.WeeklyCompare;
            BtnReport_Period.Text = MultiLang.PeriodCompare;
            BtnReport_Daily.Text = MultiLang.Daily;
            BtnReport_Repair.Text = MultiLang.RepairTask;

            BtnConfig_BandpassTrend.Text = MultiLang.Configuration;
            BtnConfig_PointTrend.Text = MultiLang.Configuration;
            BtnConfig_DayOfWeek.Text = MultiLang.Configuration;
            BtnConfig_Period.Text = MultiLang.Configuration;
            BtnConfig_Daily.Text = MultiLang.Configuration;
            BtnConfig_Repair.Text = MultiLang.Configuration;

            BtnPreview_BandpassTrend.Text = MultiLang.Preview;
            BtnPreview_PointTrend.Text = MultiLang.Preview;
            BtnPreview_DayOfWeek.Text = MultiLang.Preview;
            BtnPreview_Period.Text = MultiLang.Preview;
            BtnPreview_Daily.Text = MultiLang.Preview;
            BtnPreview_Repair.Text = MultiLang.Preview;
            #endregion

            LogGenerator.CreateLogFile();
            CreatePreviewSample();
            DBConn = new DBConnector();
            ExcelManager = new ExcelIOManager();
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

        private void CreatePreviewSample()
        {
            string[] week = new string[5] { "Fri", "Thu", "Wed", "Tue", "Mon" };
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
                Tchart_DayOfWeek.Series[0].Add(rand.Next(5, 10), week[i]);
            Tchart_Trend.Series[0].FillSampleValues();
            Tchart_Period.Series[0].FillSampleValues(4);
            Tchart_Period.Series[1].FillSampleValues(4);
            Tchart_Period.Series[2].FillSampleValues(4);
            BindingList<DailyReportItem> items = new BindingList<DailyReportItem>();
            items.Add(new DailyReportItem());
            items.Add(new DailyReportItem());
            Grid_DailyData.DataSource = items;
            Tchart_RepairTrend.Series[0].FillSampleValues();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = Settings.Default.ProjectSite +" "+ MultiLang.ProgramName +" v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void BtnConfig_BandTrend_Click(object sender, EventArgs e)
        {
            MultiBandConfigDlg.Show();
        }

        private void BtnConfig_MultiPointTrend_Click(object sender, EventArgs e)
        {
            MultiPointConfigDlg.Show();
        }

        private void BtnConfig_DayOfWeek_Click(object sender, EventArgs e)
        {
            DayOfWeekConfigDlg.Show();
        }

        private void BtnConfig_Period_Click(object sender, EventArgs e)
        {
            PeriodConfigDlg.Show();
        }

        private void BtnConfig_Daily_Click(object sender, EventArgs e)
        {
            DailyConfDlg.Show();
        }

        private void BtnConfig_Repair_Click(object sender, EventArgs e)
        {
            RepairConfigDlg.Show();
        }

        private void BtnPreview_DayOfWeek_Click(object sender, EventArgs e)
        {
            Tchart_DayOfWeek.Show();
            Tchart_Period.Hide();
            if (DayOfWeekConf.Channel != null && DayOfWeekConf.Channel.BandpassArr.Where(x => x.Active).Count() > 0)
            {
                Tchart_DayOfWeek.Axes.Bottom.AutomaticMaximum = DayOfWeekConf.AutoScale;
                if(!DayOfWeekConf.AutoScale) 
                    Tchart_DayOfWeek.Axes.Bottom.Maximum = DayOfWeekConf.MaxScale;
                Tchart_DayOfWeek.Series.Clear();
                Tchart_DayOfWeek.Header.Lines = new string[] { DayOfWeekConf.Channel.BandpassArr.Where(x => x.Active).First().OverrideInfo.OverrideName };
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
            if (PeriodConf.CommonBandpassList.Count > 0)
            {
                Tchart_Period.Series.Clear();
                Tchart_Period.Axes.Left.AutomaticMaximum = PeriodConf.AutoScale;
                if (!PeriodConf.AutoScale)
                    Tchart_Period.Axes.Left.Maximum = PeriodConf.MaxScale;
                Tchart_Period.Header.Lines = new string[] { PeriodConf.SelectedBandpass.OverrideInfo.OverrideName };
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

        private void BtnPreview_MultiBandTrend_Click(object sender, EventArgs e)
        {
            if (MultiBandConf.Channel != null)
            {
                Tchart_Trend.Series.Clear();
                Tchart_Trend.Axes.Left.AutomaticMaximum = MultiBandConf.AutoScale;
                if (!MultiBandConf.AutoScale)
                    Tchart_Trend.Axes.Left.Maximum = MultiBandConf.MaxScale;
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
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "Week");
                        } break;
                    case "month":
                        foreach (var dataTable in DBConn.LoadMultiBandpassTrendData(MultiBandConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "Month");
                        } break;
                }
            }
        }       

        private void BtnPreview_MultPointTrend_Click(object sender, EventArgs e)
        {
            if (MultiPointConf.CommonBandpassList.Count > 0)
            {
                Tchart_Trend.Series.Clear();
                Tchart_Trend.Axes.Left.AutomaticMaximum = MultiPointConf.AutoScale;
                if (!MultiPointConf.AutoScale)
                    Tchart_Trend.Axes.Left.Maximum = MultiPointConf.MaxScale;
                Tchart_Trend.Header.Lines = new string[] { MultiPointConf.SelectedBandpass.OverrideInfo.OverrideName };
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
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "Week");
                        } break;
                    case "month":
                        foreach (var dataTable in DBConn.LoadMultiPointTrendData(MultiPointConf))
                        {
                            FastLine fastline = new FastLine() { Title = dataTable.TableName };
                            Tchart_Trend.Series.Add(fastline);
                            foreach (DataRow data in dataTable.Rows)
                                fastline.Add(Convert.ToDouble(data.ItemArray[2]), data.ItemArray[0].ToString() + "\n" + data.ItemArray[1].ToString() + "Month");
                        } break;
                }
            }
        }

        private void BtnPreview_Daily_Click(object sender, EventArgs e)
        {
            Tchart_RepairTrend.Hide();
            Grid_DailyData.Show();
        }

        private void BtnPreview_Repair_Click(object sender, EventArgs e)
        {
            Tchart_RepairTrend.Show();
            Grid_DailyData.Hide();
            if (RepairConf.Channel != null)
            {
                Tchart_RepairTrend.Axes.Bottom.Labels.DateTimeFormat = "yyyy\nM.d";
                Tchart_RepairTrend.Series.Clear();
                Tchart_RepairTrend.Axes.Left.AutomaticMaximum = RepairConf.AutoScale;
                if (!RepairConf.AutoScale)
                    Tchart_RepairTrend.Axes.Left.Maximum = RepairConf.MaxScale;
                Tchart_RepairTrend.Header.Lines = new string[] { RepairConf.Channel.PointName };
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

        private void BtnReport_DayOfWeek_Click(object sender, EventArgs e)
        {
            BtnPreview_DayOfWeek_Click(null, null);
            if (DayOfWeekConf.Channel != null)
            {
                ExcelManager.CreateExcel("Template_CommonReport.xlsx", new CommonReportItems()
                {
                    DateTime = DayOfWeekConf.StartDateStr + " ~ " + DayOfWeekConf.EndDateStr,
                    Name = "요일별 비교 분석 보고서",
                    Machine = DayOfWeekConf.Channel.MachineName,
                    Line = DayOfWeekConf.Channel.LineName,
                    Ref = "Point",
                    Value = DayOfWeekConf.Channel.PointName,
                    AnalysisType = "* BarChart Analysis",
                    Img = ChartCaptur(Tchart_DayOfWeek, 740)
                });
            }
        }

        private void BtnReport_MultiBand_Click(object sender, EventArgs e)
        {
            BtnPreview_MultiBandTrend_Click(null, null);
            if (MultiBandConf.Channel != null)
            {
                ExcelManager.CreateExcel("Template_CommonReport.xlsx", new CommonReportItems()
                {
                    DateTime = MultiBandConf.StartDateStr + " ~ " + MultiBandConf.EndDateStr,
                    Name = "포인트별 추이 분석 보고서",
                    Machine = MultiBandConf.Channel.MachineName,
                    Line = MultiBandConf.Channel.LineName,
                    Ref = "Point",
                    Value = MultiBandConf.Channel.PointName,
                    AnalysisType = "* Trend Analysis",
                    Img = ChartCaptur(Tchart_Trend, 740)
                });
            }
        }
        private void BtnReport_MultiPointTrend_Click(object sender, EventArgs e)
        {
            BtnPreview_MultPointTrend_Click(null, null);
            if (MultiPointConf.CommonBandpassList.Count > 0)
            {
                ExcelManager.CreateExcel("Template_CommonReport.xlsx", new CommonReportItems()
                {
                    DateTime = MultiPointConf.StartDateStr + " ~ " + MultiPointConf.EndDateStr,
                    Name = "밴드별 추이 분석 보고서",
                    Machine = MultiPointConf.SelectedChannelList[0].MachineName,
                    Line = MultiPointConf.SelectedChannelList[0].LineName,
                    Ref = "Measure",
                    Value = MultiPointConf.SelectedBandpass.OverrideInfo.OverrideName,
                    AnalysisType = "* Trend Analysis",
                    Img = ChartCaptur(Tchart_Trend, 740)
                });
            }
        }

        private void BtnReport_Period_Click(object sender, EventArgs e)
        {
            BtnPreview_Period_Click(null, null);
            if (PeriodConf.CommonBandpassList.Count > 0)
            {
                ExcelManager.CreateExcel("Template_CommonReport.xlsx", new CommonReportItems()
                {
                    DateTime = PeriodConf.StartDate.ToString("yyyy년도"),
                    Name = "유사설비/분기별 비교 분석 보고서",
                    Machine = PeriodConf.SelectedChannelList[0].MachineName,
                    Line = PeriodConf.SelectedChannelList[0].LineName,
                    Ref = "Measure",
                    Value = PeriodConf.SelectedBandpass.OverrideInfo.OverrideName,
                    AnalysisType = "* BarChart Analysis",
                    Img = ChartCaptur(Tchart_Period, 740)
                });
            }
        } 

        private void BtnReport_Repair_Click(object sender, EventArgs e)
        {
            BtnPreview_Repair_Click(null, null);

            TChart_Time.Axes.Left.AutomaticMaximum = RepairConf.AutoScale_Time;
            if (!RepairConf.AutoScale_Time)
                TChart_Time.Axes.Left.Maximum = RepairConf.MaxScale_Time;

            TChart_Spectrum.Axes.Left.AutomaticMaximum = RepairConf.AutoScale_FFT;
            if (!RepairConf.AutoScale_FFT)
                TChart_Spectrum.Axes.Left.Maximum = RepairConf.MaxScale_FFT;

            TChart_Time.Series[0].Clear();
            TChart_Spectrum.Series[0].Clear();

            int timeWidth = 347;
            int fftWidth = 393;
            int height = 165;
            FFTConvertor convertor = new FFTConvertor();
            Bitmap time_beforeImg = ChartCaptur(TChart_Time, timeWidth, height); ;
            Bitmap time_afterImg = ChartCaptur(TChart_Time, timeWidth, height); ;
            Bitmap fft_beforeImg = ChartCaptur(TChart_Spectrum, fftWidth, height); ;
            Bitmap fft_afterImg = ChartCaptur(TChart_Spectrum, fftWidth, height); ;
            WaveData[] datas = DBConn.LoadWaveDatas(RepairConf);

            if (datas[0] != null)
            {
               
                int dataCount = datas[0].AsyncData.Length;
                for (int i = 0; i < dataCount; i++)
                    TChart_Time.Series[0].Add(i * datas[0].Duration / (double)dataCount, datas[0].AsyncData[i]);
                time_beforeImg = ChartCaptur(TChart_Time, timeWidth, height);

                SpectrumData spectrumData = convertor.CalcSpectrumData(datas[0]);
                for (int i = 0; i < spectrumData.XValues.Length; i++)
                    TChart_Spectrum.Series[0].Add(spectrumData.XValues[i], spectrumData.YValues[i]);
                fft_beforeImg = ChartCaptur(TChart_Spectrum, fftWidth, height);
            }

            if (datas[1] != null)
            {
                int dataCount = datas[1].AsyncData.Length;
                for (int i = 0; i < dataCount; i++)
                    TChart_Time.Series[0].Add(i * datas[1].Duration / (double)dataCount, datas[1].AsyncData[i]);
                time_afterImg = ChartCaptur(TChart_Time, timeWidth, height);

                SpectrumData spectrumData = convertor.CalcSpectrumData(datas[1]);
                for (int i = 0; i < spectrumData.XValues.Length; i++)
                    TChart_Spectrum.Series[0].Add(spectrumData.XValues[i], spectrumData.YValues[i]);
                fft_afterImg = ChartCaptur(TChart_Spectrum, fftWidth, height);
            }
            if (RepairConf.Channel != null)
            {
                ExcelManager.CreateExcel("Template_Maintenance.xlsx", new CommonReportItems()
                {
                    DateTime = RepairConf.StartDateStr + " ~ " + RepairConf.EndDateStr,
                    Name = "보전활동 보고서",
                    Machine = RepairConf.Channel.MachineName,
                    Line = RepairConf.Channel.LineName,
                    Value = RepairConf.Channel.PointName,
                    Img = ChartCaptur(Tchart_RepairTrend, 740),
                    Img_BeforTime = time_beforeImg,
                    Img_BeforFFT = fft_beforeImg,
                    Img_AfterTime = time_afterImg,
                    Img_AfterFFT = fft_afterImg
                });
            }
        }

        private void BtnReport_Daily_Click(object sender, EventArgs e)
        {
            BtnPreview_Daily_Click(null,null);
            DataTable table = DBConn.LoadDailyData(DailyConf);
            List<DailyReportItem> items = new List<DailyReportItem>();
            foreach (DataRow row in table.Rows)
            {
                DailyReportItem item = new DailyReportItem(row);
                if(item.Function != null)
                    items.Add(item);
            }
            ExcelManager.CreateExcel("Template_DailyReport.xlsx", new CommonReportItems()
            {
                DateTime = "Date : "+DailyConf.StartDateStr,
                Name = "CMS Daily Report",
                DailyDatas = items
            });
        }

        private Bitmap ChartCaptur(TChart tchart, int width, int height = -1)
        {
            tchart.Graphics3D.UseBuffer = false;
            Rectangle rect = new Rectangle(0, 0, tchart.Width, tchart.Height);
            Bitmap screenshot = new Bitmap(rect.Width, rect.Height, PixelFormat.Format64bppArgb);

            tchart.DrawToBitmap(screenshot, rect);
            return ResizeBitmap(screenshot, width, height);
        }

        private Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            int h = 0;
            if (height == -1)
                h = Convert.ToInt32(sourceBMP.Height * (width / (float)sourceBMP.Width));
            else
                h= height;
            Bitmap result = new Bitmap(width, h);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, h);
            return result;
        }

        

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                string status = (sender as DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "Status").ToString();
                switch (status)
                {
                    case "Good": e.Appearance.BackColor = Color.LightGreen; break;
                    case "Caution": e.Appearance.BackColor = Color.Pink; break;
                    case "Repair": e.Appearance.BackColor = Color.Orange; break;
                    case "Stop": e.Appearance.BackColor = Color.Red; break;
                }
            }
        }
    }
}