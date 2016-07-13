using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MMXReport.Properties;

namespace MMXReport.Dialog
{
    public partial class LoginDialog : DevExpress.XtraEditors.XtraForm
    {
        public LoginDialog()
        {
            InitializeComponent();
            radioGroup1.DataBindings.Add(new Binding("SelectedIndex",Settings.Default,"LanguageSelectedIdx"));
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Settings.Default.LastUICulture = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value as string;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }
    }
}