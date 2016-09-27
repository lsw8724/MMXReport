using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MMXReport.TsiConfig;
using DevExpress.XtraEditors.Controls;
using MMXReport.Properties;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace MMXReport.Dialog
{
    public partial class DailyConfigDlg : BaseConfigDlg
    {
        public DailyConfigDlg(DailyConfiguration dailyConf) : base(dailyConf)
        {
            InitializeComponent();
            DateEdit.DateTime = DateTime.Now.Date;
            Text = MultiLang.Daily + " " + MultiLang.Report + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;

            if (Settings.Default.ShiftItems != null)
            {
                foreach (var str in Settings.Default.ShiftItems)
                {
                    var item = JsonConvert.DeserializeObject<ShiftItem>(str);
                    radioGroup1.Properties.Items.Add(item.ToRadioItem());
                }
            }
            if (radioGroup1.Properties.Items.Count > 0) radioGroup1.SelectedIndex = 0;
        }

        private void DateEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseConfig.StartDate = DateEdit.DateTime.Date;
        }

        private void radioGroup1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(radioGroup1.PointToScreen(new Point(e.X,e.Y)));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var item = new ShiftItem(DateTime.Today, DateTime.Today,"Shift");
            radioGroup1.Properties.Items.Add(item.ToRadioItem());
            SaveShiftItem();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (radioGroup1.SelectedIndex == -1) return;
            radioGroup1.Properties.Items.RemoveAt(radioGroup1.SelectedIndex);
            SaveShiftItem();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == -1) return;
            var item = radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value as ShiftItem;
            propertyGridControl1.SelectedObject = item;
            (BaseConfig as DailyConfiguration).SelectedItem = item;
        }

        private void propertyGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (radioGroup1.SelectedIndex == -1) return;
            radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description = (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value as ShiftItem).Description;
            radioGroup1.Invalidate();
            radioGroup1.Refresh();

            SaveShiftItem();
        }

        private void SaveShiftItem()
        {
            var items = new StringCollection();
            foreach (RadioGroupItem item in radioGroup1.Properties.Items)
                items.Add(JsonConvert.SerializeObject(item.Value as ShiftItem));

            Settings.Default.ShiftItems = items;
            Settings.Default.Save();
        }
    }
}