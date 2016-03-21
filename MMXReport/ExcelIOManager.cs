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
    public class ExcelIOManager
    {
        public Excel.Application _Excel { get; set; }
        public Excel.Workbook _Workbook { get; set; }
        public Excel.Worksheet _Worksheet { get; set; }
        public string TemplateFileName { get; set; }
        public ExcelIOManager(string templateFileName)
        {
            TemplateFileName = templateFileName;
            CreateExcel();
        }
        private void CreateExcel()
        {
            var dlg = new SaveFileDialog();
            string startPath = System.Windows.Forms.Application.StartupPath;
            string templateFilePath = startPath + "\\ReportTemplate\\" + TemplateFileName;
            dlg.InitialDirectory = startPath;
            dlg.DefaultExt = "xlsx";
            dlg.Filter = " (*.xlsx)|*.xlsx|" + " (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                _Excel = new Excel.Application();
                _Workbook = _Excel.Workbooks.Open(templateFilePath);
                GenerateReport();
                _Workbook.SaveAs(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (_Workbook != null) _Workbook.Close();
                if (_Excel != null) _Excel.Quit();
            }
        }
        private void GenerateReport()
        {
            _Worksheet = _Workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            for (int i = 15; i < 100; i++)
                _Worksheet.Cells[i, 1] = i;
              
        }
    }
}
