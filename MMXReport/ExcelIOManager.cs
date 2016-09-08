using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;

namespace MMXReport
{
    public class SheetItems
    {
        public string DateTime;
        public string Name;
        public string Ref;
        public string Value;
        public string Machine;
        public string AnalysisType;
        public string Line;
        //public string Alarm;
        public Bitmap Img;
        public Bitmap Img_BeforTime;
        public Bitmap Img_AfterTime;
        public Bitmap Img_BeforFFT;
        public Bitmap Img_AfterFFT;
        public DailyReportItem[] DailyDatas;
    }
    public class ExcelIOManager
    {
        public void CreateExcel(string templateFileName, string savePath, SheetItems items)
        {
            Excel.Application excel = null;
            Excel.Workbook workbook = null;

            try
            {
                excel = new Excel.Application();
                workbook = excel.Workbooks.Open( System.Windows.Forms.Application.StartupPath + "\\ReportTemplate\\"+ templateFileName);
                
                LogGenerator.AppendLog("Excel Generate "+items.Name, LogType.Common, this);
                GenerateReport(workbook, items);
                workbook.SaveAs(savePath);
                
            }
            catch (Exception ex)
            {
                LogGenerator.AppendLog(ex.StackTrace, LogType.Exception, this);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook.Close(false);
                ReleaseObject(ref workbook);
                excel.Quit();
                ReleaseObject(ref excel);
            }
        }

        private void GenerateReport(Excel.Workbook workbook, SheetItems items)
        {
            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            var cell_dateTime = worksheet.Cells.Find("$DateTime");
            if (cell_dateTime != null) cell_dateTime.Value = items.DateTime;

            var cell_name = worksheet.Cells.Find("$Name");
            if (cell_name != null) cell_name.Value = items.Name;

            var cell_line = worksheet.Cells.Find("$Line");
            if (cell_line != null) cell_line.Value = items.Line;

            var cell_machine = worksheet.Cells.Find("$Machine");
            if (cell_machine != null) cell_machine.Value = items.Machine;

            var cell_point = worksheet.Cells.Find("$Ref");
            if (cell_point != null) cell_point.Value = items.Ref;

            var cell_measure = worksheet.Cells.Find("$Value");
            if (cell_measure != null) cell_measure.Value = items.Value;

            var cell_Analysis = worksheet.Cells.Find("$AnalysisType");
            if (cell_Analysis != null) cell_Analysis.Value = items.AnalysisType;

            var cell_PlotImg = worksheet.Cells.Find("$PlotImage");
            if (cell_PlotImg != null)
            {
                Clipboard.SetDataObject(items.Img, true);
                worksheet.Paste(cell_PlotImg, false);
                cell_PlotImg.Value = "";
            }

            var cell_bfTime = worksheet.Cells.Find("$BeforeTime");
            if (cell_bfTime != null)
            {
                Clipboard.SetDataObject(items.Img_BeforTime, true);
                worksheet.Paste(cell_bfTime, false);
                cell_bfTime.Value = "";
            }

            var cell_bfFFT = worksheet.Cells.Find("$BeforeFFT");
            if (cell_bfFFT != null)
            {
                Clipboard.SetDataObject(items.Img_BeforFFT, true);
                worksheet.Paste(cell_bfFFT, false);
                cell_bfFFT.Value = "";
            }

            var cell_afTime = worksheet.Cells.Find("$AfterTime");
            if (cell_afTime != null)
            {
                Clipboard.SetDataObject(items.Img_AfterTime, true);
                worksheet.Paste(cell_afTime, false);
                cell_afTime.Value = "";
            }

            var cell_afFFT = worksheet.Cells.Find("$AfterFFT");
            if (cell_afFFT != null)
            {
                Clipboard.SetDataObject(items.Img_AfterFFT, true);
                worksheet.Paste(cell_afFFT, false);
                cell_afFFT.Value = "";
            }


            var cell_DailyData = worksheet.Cells.Find("$DailyData");
            if (cell_DailyData != null)
            {
                var range1 = worksheet.get_Range("A11", "M11");
                int num = 10;
                foreach (var item in items.DailyDatas)
                {
                    object[,] values =
                    {{
                         item.Machine,
                         item.Point,
                         item.Function,
                         item.Unit,
                         item.Caution,
                         item.Failure,
                         item.Repair,
                         item.Stop,
                         item.MIN.ToString("#.00"),
                         item.MAX.ToString("#.00"),
                         item.AVG.ToString("#.00"),
                         item.Status.Stat,
                         "",
                    }};

                    if (num < items.DailyDatas.Length + 8)
                        range1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

                    var range2 = worksheet.get_Range("A" + num, "M" + num);
                    range2.Value2 = values;

                    Excel.Range range = worksheet.Cells[num, "L"] as Excel.Range;
                    range.Interior.Color = item.Status.StatColor;
                    range.Font.Color = item.Status.StatColor_Font;
                    
                    num++;
                    ReleaseObject(ref range2);
                }
                ReleaseObject(ref range1);
            }
            ReleaseObject(ref worksheet);
        }

        private static void ReleaseObject<T>(ref T obj) where T : class
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.ReleaseComObject(obj);
            }
            obj = null;
        }
    }
}
