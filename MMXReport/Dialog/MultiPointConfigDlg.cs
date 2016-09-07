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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace MMXReport.Dialog
{
    public partial class MultiPointConfigDlg : BaseConfigDlg
    {
        public MultiPointConfiguration MultiPointConf { get { return (MultiPointConfiguration)BaseConfig; } }

        public MultiPointConfigDlg(CommonConfig common, BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();
            Text = MultiLang.TrendOfMeasurements + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;
            groupControl2.Text = MultiLang.TypeOfMeasurement;
            groupControl3.Text = MultiLang.Unit;
            groupControl4.Text = "Y " + MultiLang.Scale;
            Gr_Machine.Text = MultiLang.PlantMap;
            Gr_Bandpass.Text = MultiLang.BandPass;
            Radio_Day.Text = MultiLang.Day;
            Radio_Week.Text = MultiLang.Week;
            Radio_Month.Text = MultiLang.Month;
            
            MimicNodeTree.DataSource = common.LoadMimicNodes();
            MimicNodeTree.BestFitColumns();
            MimicNodeTree.ExpandAll();
            MimicNodeTree.CollapseAll();
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

        private void Radio_Day_CheckedChanged(object sender, EventArgs e)
        {
            MultiPointConf.StatTermType = "day";
        }

        private void Radio_Week_CheckedChanged(object sender, EventArgs e)
        {
            MultiPointConf.StatTermType = "week";
        }

        private void Radio_Month_CheckedChanged(object sender, EventArgs e)
        {
            MultiPointConf.StatTermType = "month";
        }

        private void MimicNodeTree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            TreeChildAllCheck(e.Node.Nodes);
            MimicTreeNodes pointNodes = (MimicNodeTree.DataSource as MimicTreeNodes).SearchNodes(300);
            MultiPointConf.SetChannelList(pointNodes.Where(x => x.Active));
            List_Bandpass.DataSource = MultiPointConf.CommonBandpassList;
        }

        private void TreeChildAllCheck(TreeListNodes nodes)
        {
            if (nodes.Count == 0)
            {
                (MimicNodeTree.GetDataRecordByNode(nodes.ParentNode) as MimicTreeNode).Active = nodes.ParentNode.Checked;
                return;
            }

            foreach (TreeListNode node in nodes)
            {
                node.Checked = nodes.ParentNode.Checked;
                TreeChildAllCheck(node.Nodes);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for(int i=0; i<MultiPointConf.CommonBandpassList.Count; i++)
            {
                if (i == e.FocusedRowHandle)
                {
                    MultiPointConf.CommonBandpassList[i].Active = true;
                    MultiPointConf.SelectedBandpass = MultiPointConf.CommonBandpassList[i];
                }
                else
                    MultiPointConf.CommonBandpassList[i].Active = false;
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