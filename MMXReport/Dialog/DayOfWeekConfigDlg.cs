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
    public partial class DayOfWeekConfigDlg : BaseConfigDlg
    {
        public DayOfWeekConfigDlg(CommonConfig common, BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();
            MimicNodeTree.DataSource = common.MimicNodes;
            MimicNodeTree.BestFitColumns();
            DateEdit_Start.DateTime = BaseConfig.StartDate;
            DateEdit_End.DateTime = BaseConfig.EndDate;
        }

        private void StartDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseConfig.StartDate = DateEdit_Start.DateTime.Date;
        }

        private void EndDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseConfig.EndDate = DateEdit_End.DateTime.Date;
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
    }
}