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
    public partial class BaseConfigDlg : DevExpress.XtraEditors.XtraForm
    {
        public BaseConfiguration BaseConfig { get; set; }

        public BaseConfigDlg()
        {
            InitializeComponent();
            Btn_Close.Text = MultiLang.Close;
        }

        public BaseConfigDlg(BaseConfiguration baseConf)
        {
            BaseConfig = baseConf;
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}