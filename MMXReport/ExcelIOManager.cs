using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excel=Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;

namespace MMXReport
{
    public class ReportItems
    {
        public string DateTime;
        public string Name;
        public string Ref;
        public string Value;
        public string Machine;
        public string AnalysisType;
        //public string Alarm;
        public System.Drawing.Bitmap Img;
        public List<DailyReportItem> DailyDatas;
    }
    public class ExcelIOManager
    {
        public void CreateExcel(string templateFileName, ReportItems items)
        {
            Excel.Application excel = null;
            Excel.Workbook workbook = null;
            
            var dlg = new SaveFileDialog();
            string startPath = System.Windows.Forms.Application.StartupPath;
            string templateFilePath = startPath + "\\ReportTemplate\\" + templateFileName;
            dlg.InitialDirectory = startPath;
            dlg.DefaultExt = "xlsx";
            dlg.Filter = " (*.xlsx)|*.xlsx|" + " (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                excel = new Excel.Application();
                workbook = excel.Workbooks.Open(templateFilePath);
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Dialog.WaitLoadingDlg), false, false);
                GenerateReport(workbook, items);
                workbook.SaveAs(dlg.FileName);
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
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

        private void GenerateReport(Excel.Workbook workbook, ReportItems items)
        {
            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            var cell_dateTime = worksheet.Cells.Find("$DateTime");
            if (cell_dateTime != null) cell_dateTime.Value = items.DateTime;

            var cell_name = worksheet.Cells.Find("$Name");
            if (cell_name != null) cell_name.Value = items.Name;

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

            var cell_DailyData = worksheet.Cells.Find("$DailyData");
            if (cell_DailyData != null)
            {
                var range1 = worksheet.get_Range("A11", "M11");
                int num = 10;
                foreach (var item in items.DailyDatas)
                {
                    if (num < items.DailyDatas.Count+8)
                        range1.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    worksheet.Cells[num,"A"] = item.Machine;
                    worksheet.Cells[num,"B"] = item.Point;
                    worksheet.Cells[num,"C"] = item.Function;
                    worksheet.Cells[num,"D"] = item.Unit;
                    worksheet.Cells[num,"E"] = item.Caution;
                    worksheet.Cells[num,"F"] = item.Failure;
                    worksheet.Cells[num,"G"] = item.Repair;
                    worksheet.Cells[num, "H"] = item.Stop;
                    worksheet.Cells[num, "I"] = item.MIN.ToString("#.00");
                    worksheet.Cells[num, "J"] = item.MAX.ToString("#.00");
                    worksheet.Cells[num, "K"] = item.AVG.ToString("#.00");
                    
                    Excel.Range range = worksheet.Cells[num, "L"] as Excel.Range;
                    range.Value = item.Status;
                    switch(item.Status)
                    {
                        case "Good": 
                            range.Interior.Color = Color.LightGreen;
                            range.Font.Color = Color.Black;
                            break;
                        case "Caution":
                            range.Interior.Color = Color.Pink;
                            range.Font.Color = Color.Black;
                            break;
                        case "Failure":
                            range.Interior.Color = Color.Yellow;
                            range.Font.Color = Color.Black;
                            break;
                        case "Repair":
                            range.Interior.Color = Color.OrangeRed;
                            range.Font.Color = Color.White;
                            break;
                        case "Stop":
                            range.Interior.Color = Color.Red;
                            range.Font.Color = Color.White;
                            break;
                    }
                    num++;
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
