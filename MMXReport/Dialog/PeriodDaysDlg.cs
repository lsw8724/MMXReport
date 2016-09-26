using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MMXReport.Dialog
{
    public partial class PeriodDaysDlg : BaseConfigDlg
    {
        public PeriodDaysDlg(PeriodDaysConfiguration periodDaysConf) : base(periodDaysConf)
        {
            InitializeComponent();
            Text =MultiLang.Report + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;

            dateEdit_from.DateTime = DateTime.Now.Date;
            dateEdit_to.DateTime = DateTime.Now.Date;

            dateEdit_from.DataBindings.Add(new Binding("DateTime", periodDaysConf, "StartDate") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            dateEdit_to.DataBindings.Add(new Binding("DateTime", periodDaysConf, "EndDate") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
        }
    }
}