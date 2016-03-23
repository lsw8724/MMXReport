using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excel=Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMXReport
{
    public class ReportItem
    {
        public string DateTime;
        public string Name;
        public string Ref;
        public string Value;
        public string Machine;
        public string AnalysisType;
        //public string Alarm;
        public System.Drawing.Bitmap Img; 
    }
    public class ExcelIOManager
    {
        public string TemplateFileName { get; set; }
        private ReportItem Items { get; set; }
        public ExcelIOManager(string templateFileName,ReportItem item)
        {
            Items = item;
            TemplateFileName = templateFileName;
            CreateExcel();
        }
        private void CreateExcel()
        {
            Excel.Application excel = null;
            Excel.Workbook workbook = null;
            
            var dlg = new SaveFileDialog();
            string startPath = System.Windows.Forms.Application.StartupPath;
            string templateFilePath = startPath + "\\ReportTemplate\\" + TemplateFileName;
            dlg.InitialDirectory = startPath;
            dlg.DefaultExt = "xlsx";
            dlg.Filter = " (*.xlsx)|*.xlsx|" + " (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                excel = new Excel.Application();
                workbook = excel.Workbooks.Open(templateFilePath);
                GenerateReport(workbook);
                workbook.SaveAs(dlg.FileName);
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
                //if (workbook != null) workbook.Close();
                //if (excel != null) excel.Quit();
            }
        }
        private void GenerateReport(Excel.Workbook workbook)
        {
            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            var cell_dateTime = worksheet.Cells.Find("$DateTime");
            if (cell_dateTime != null) cell_dateTime.Value = Items.DateTime;

            var cell_name = worksheet.Cells.Find("$Name");
            if (cell_name != null) cell_name.Value = Items.Name;

            var cell_machine = worksheet.Cells.Find("$Machine");
            if (cell_machine != null) cell_machine.Value = Items.Machine;

            var cell_point = worksheet.Cells.Find("$Ref");
            if (cell_point != null) cell_point.Value = Items.Ref;

            var cell_measure = worksheet.Cells.Find("$Value");
            if (cell_measure != null) cell_measure.Value = Items.Value;

            var cell_Analysis = worksheet.Cells.Find("$AnalysisType");
            if (cell_Analysis != null) cell_Analysis.Value = Items.AnalysisType;

            var cell_plotImg = worksheet.Cells.Find("$PlotImage");
            if (cell_plotImg != null)
            {
                Clipboard.SetDataObject(Items.Img, true);
                worksheet.Paste(cell_plotImg, false);
                cell_plotImg.Value = "";
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
