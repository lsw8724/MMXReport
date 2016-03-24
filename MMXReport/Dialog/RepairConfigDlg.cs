using System;
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
                CheckList_Bandpass.DataSource = channel.BandpassArr;
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
    }
}