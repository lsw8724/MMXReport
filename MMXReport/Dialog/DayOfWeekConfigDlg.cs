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
    public partial class DayOfWeekConfigDlg : BaseConfigDlg
    {
        public DayOfWeekConfigDlg(CommonConfig common, BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();
            Text = MultiLang.WeeklyComparison + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;
            groupControl2.Text = MultiLang.TypeOfMeasurement;
            groupControl3.Text = "X " + MultiLang.Scale;
            Gr_Machine.Text = MultiLang.PlantMap;
            Gr_Bandpass.Text = MultiLang.BandPass;
            CheckEdit_All.Text = MultiLang.BatchCheck;

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
            MimicTreeNode mimicNode = MimicNodeTree.GetDataRecordByNode(e.Node) as MimicTreeNode;
            if (mimicNode.ThisNode.NodeType == 300)
            {
                ChannelConfig channel = new ChannelConfig(mimicNode);
                BaseConfig.Channel = channel;
                CheckList_Bandpass.DataSource = channel.BandpassArr.Where(x=>x.Visible);
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

        private void Radio_CustomScale_CheckedChanged(object sender, EventArgs e)
        {
            BaseConfig.AutoScale = false;
            TextEdit_Scale.Enabled = true;
            if (TextEdit_Scale.Text == string.Empty) BaseConfig.MaxScale = 0;
            else BaseConfig.MaxScale = Convert.ToDouble(TextEdit_Scale.Text);
        }

        private void Radio_AutoScale_CheckedChanged(object sender, EventArgs e)
        {
            BaseConfig.AutoScale = true;
            TextEdit_Scale.Enabled = false;
        }

        private void TextEdit_Scale_EditValueChanged(object sender, EventArgs e)
        {
            if (TextEdit_Scale.Text == string.Empty) BaseConfig.MaxScale = 0;
            else BaseConfig.MaxScale = Convert.ToDouble(TextEdit_Scale.Text);
        }
    }
}