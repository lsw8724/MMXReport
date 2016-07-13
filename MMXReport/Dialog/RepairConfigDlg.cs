using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using MMXReport.TsiConfig;

namespace MMXReport.Dialog
{
    public partial class RepairConfigDlg : BaseConfigDlg
    {
        private RepairConfiguration RepairConf { get { return (RepairConfiguration)BaseConfig; } }
        public RepairConfigDlg()
        {
            InitializeComponent();           
        }

        public RepairConfigDlg(CommonConfig common, BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();
            Text = MultiLang.MaintenanceTask + " " + MultiLang.Report + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.MaintenancePeriod;
            groupControl2.Text = MultiLang.TypeOfMeasurement;
            groupControl3.Text = "Y " + MultiLang.Scale;
            Gr_Machine.Text = MultiLang.PlantMap;
            Gr_Bandpass.Text = MultiLang.BandPass;
            CheckEdit_All.Text = MultiLang.BatchCheck;
            labelControl1.Text = MultiLang.BeforeMaintenance;
            labelControl2.Text = MultiLang.AfterMaintenance;
            labelControl4.Text = MultiLang.Days;
            MimicNodeTree.DataSource = common.MimicNodes;
            MimicNodeTree.BestFitColumns();
            Numeric_RepairOffset.Value = RepairConf.RepairOffsetDay;
            DateEdit_Before.DateTime = BaseConfig.StartDate;
            DateEdit_After.DateTime = BaseConfig.EndDate;
        }

        private void StartDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            RepairConf.BeforeRepairDate = DateEdit_Before.DateTime.Date;
            RepairConf.StartDate = DateEdit_Before.DateTime.AddDays(-1 * RepairConf.RepairOffsetDay).Date;
        }

        private void EndDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            RepairConf.AfterRepairDate = DateEdit_After.DateTime.Date;
            RepairConf.EndDate = DateEdit_After.DateTime.AddDays(RepairConf.RepairOffsetDay).Date;
        }

        private void Radio_Max_CheckedChanged_1(object sender, EventArgs e)
        {
            BaseConfig.ValueMeasureType = "max";
        }

        private void Radio_Min_CheckedChanged_1(object sender, EventArgs e)
        {
            BaseConfig.ValueMeasureType = "min";
        }

        private void Radio_Avg_CheckedChanged_1(object sender, EventArgs e)
        {
            BaseConfig.ValueMeasureType = "avg";
        }

        private void MimicNodeTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            MimicNode mimicNode = MimicNodeTree.GetDataRecordByNode(e.Node) as MimicNode;
            if (mimicNode.NodeType == 300)
            {
                ChannelConfig channel = new ChannelConfig(mimicNode, BaseConfig.DBConn);
                BaseConfig.Channel = channel;
                CheckList_Bandpass.DataSource = channel.BandpassArr.Where(x => x.Visible);
            }
            else
            {
                CheckList_Bandpass.DataSource = null;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BaseConfig.Channel.BandpassArr[e.RowHandle].Active = (bool)e.Value;
        }

        private void CheckEdit_All_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseConfig.Channel != null)
            {
                foreach (var band in BaseConfig.Channel.BandpassArr)
                    band.Active = CheckEdit_All.Checked;
                CheckList_Bandpass.RefreshDataSource();
            }
        }

        private void Numeric_RepairOffset_ValueChanged(object sender, EventArgs e)
        {
            RepairConf.RepairOffsetDay = Convert.ToInt16(Numeric_RepairOffset.Value);
        }

        private double GetScaleMax(TextEdit te)
        {
            if (te.Text == string.Empty) return 0;
            else return Convert.ToDouble(te.Text);
        }

        private void Radio_CustomScale_CheckedChanged(object sender, EventArgs e)
        {
            switch((sender as RadioButton).Name)
            {
                case "Radio_CustomScale":
                    RepairConf.AutoScale = false;
                    TextEdit_Scale.Enabled = true;
                    RepairConf.MaxScale = GetScaleMax(TextEdit_Scale);
                    break;
                case "Radio_CustomScale_Time":
                    RepairConf.AutoScale_Time = false;
                    TextEdit_Scale_Time.Enabled = true;
                    RepairConf.MaxScale_Time = GetScaleMax(TextEdit_Scale_Time);
                    break;
                case "Radio_CustomScale_FFT":
                    RepairConf.AutoScale_FFT = false;
                    TextEdit_Scale_FFT.Enabled = true;
                    RepairConf.MaxScale_FFT = GetScaleMax(TextEdit_Scale_FFT);
                    break;
            }
        }

        private void Radio_AutoScale_CheckedChanged(object sender, EventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case "Radio_AutoScale":
                    RepairConf.AutoScale = true;
                    TextEdit_Scale.Enabled = false;
                    break;
                case "Radio_AutoScale_Time":
                    RepairConf.AutoScale_Time = true;
                    TextEdit_Scale_Time.Enabled = false;
                    break;
                case "Radio_AutoScale_FFT":
                    RepairConf.AutoScale_FFT = true;
                    TextEdit_Scale_FFT.Enabled = false;
                    break;
            }
        }

        private void TextEdit_Scale_EditValueChanged(object sender, EventArgs e)
        {
            switch ((sender as TextEdit).Name)
            {
                case "TextEdit_Scale": RepairConf.MaxScale = GetScaleMax(TextEdit_Scale); break;
                case "TextEdit_Scale_Time": RepairConf.MaxScale_Time = GetScaleMax(TextEdit_Scale_Time); break;
                case "TextEdit_Scale_FFT": RepairConf.MaxScale_FFT = GetScaleMax(TextEdit_Scale_FFT); break;
            }
        }
    }
}