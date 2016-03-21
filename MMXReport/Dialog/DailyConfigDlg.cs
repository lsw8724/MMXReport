using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MMXReport.TsiConfig;

namespace MMXReport.Dialog
{
    public partial class DailyConfigDlg : BaseConfigDlg
    {
        public DailyConfigDlg(DailyConfiguration daily) : base(daily)
        {
            InitializeComponent();
            DateEdit.DateTime = DateTime.Now.Date;
        }

        private void DateEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseConfig.StartDate = DateEdit.DateTime.Date;
        }
    }
}