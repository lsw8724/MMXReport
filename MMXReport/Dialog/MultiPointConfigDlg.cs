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
using DevExpress.XtraEditors.Repository;

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

            cbe_alarmScale.DataBindings.Add(new Binding("EditValue", MultiPointConf, "AlarmReferenceName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale.DataBindings.Add(new Binding("SelectedIndex", MultiPointConf, "ScaleTypeIdx") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_Scale.DataBindings.Add(new Binding("EditValue", MultiPointConf, "MaxScale") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
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
            cbeAlarmScale_Update();
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
            cbeAlarmScale_Update();
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
            cbeAlarmScale_Update();
        }

        private void cbeAlarmScale_Update()
        {
            if (MultiPointConf.SelectedChannelList == null) return;
            var cbItems = new ComboBoxItemCollection(new RepositoryItemComboBox());
            foreach (var ch in MultiPointConf.SelectedChannelList)
                cbItems.Add(Name = ch.PointName);
            cbe_alarmScale.Properties.Items.Assign(cbItems);
        }

        private void cbe_alarmScale_Properties_PropertiesChanged(object sender, EventArgs e)
        {
            if (cbe_alarmScale.Properties.Items.Count == 0)
                cbe_alarmScale.SelectedIndex = -1;
        }
    }
}