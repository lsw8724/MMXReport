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
    public partial class PeriodConfigDlg : BaseConfigDlg
    {
        public PeriodConfiguration PeriodConf { get { return (PeriodConfiguration)BaseConfig; } }

        public PeriodConfigDlg(CommonConfig common, BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();

            MimicNodeTree.DataSource = common.CreateMimicNodes(baseConf.DBConn);
            MimicNodeTree.BestFitColumns();
            MimicNodeTree.ExpandAll();
            MimicNodeTree.CollapseAll();
            DateEdit_Start.DateTime = BaseConfig.StartDate;
        }

        private void StartDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            BaseConfig.StartDate = DateEdit_Start.DateTime.Date;
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

        private void MimicNodeTree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            TreeChildAllCheck(e.Node.Nodes);
            MimicNodes pointNodes = (MimicNodeTree.DataSource as MimicNodes).SearchNodes(300);
            PeriodConf.SetChannelList(pointNodes.Where(x => x.Active));
            List_Bandpass.DataSource = PeriodConf.CommonBandpassList;
        }

        private void TreeChildAllCheck(TreeListNodes nodes)
        {
            if (nodes.Count == 0) return;
            foreach (TreeListNode node in nodes)
            {
                node.Checked = nodes.ParentNode.Checked;
                (MimicNodeTree.GetDataRecordByNode(node) as MimicNode).Active = node.Checked;
                TreeChildAllCheck(node.Nodes);
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for (int i = 0; i < PeriodConf.CommonBandpassList.Count; i++)
            {
                if (i == e.FocusedRowHandle)
                {
                    PeriodConf.CommonBandpassList[i].Active = true;
                    PeriodConf.SelectedBandpass = PeriodConf.CommonBandpassList[i];
                }
                else
                    PeriodConf.CommonBandpassList[i].Active = false;
            }
        }
    }
}