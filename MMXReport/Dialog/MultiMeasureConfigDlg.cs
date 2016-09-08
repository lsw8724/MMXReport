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
using DevExpress.XtraEditors.Repository;

namespace MMXReport.Dialog
{
    public partial class MultiMeasureConfigDlg : BaseConfigDlg
    {
        public MultiMeasureConfiguration MultiBandConf { get { return (MultiMeasureConfiguration)BaseConfig; } }

        public MultiMeasureConfigDlg(CommonConfig common, BaseConfiguration baseConf) :base(baseConf)
        {
            InitializeComponent();
            Text = MultiLang.TrendOfPoint + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;
            groupControl2.Text = MultiLang.TypeOfMeasurement;
            groupControl3.Text = MultiLang.Unit;
            groupControl5.Text ="Y "+ MultiLang.Scale;
            Gr_Machine.Text = MultiLang.PlantMap;
            Gr_Bandpass.Text = MultiLang.BandPass;
            Radio_Day.Text = MultiLang.Day;
            Radio_Week.Text = MultiLang.Week;
            Radio_Month.Text = MultiLang.Month;
            CheckEdit_All.Text = MultiLang.BatchCheck;
            MimicNodeTree.DataSource = common.MimicNodes;
            MimicNodeTree.BestFitColumns();
            DateEdit_Start.DateTime = BaseConfig.StartDate;
            DateEdit_End.DateTime = BaseConfig.EndDate;
            MimicNodeTree.SetFocusedNode(MimicNodeTree.Nodes.FirstNode);
            
            cbe_alarmScale.DataBindings.Add(new Binding("EditValue", MultiBandConf, "AlarmReferenceName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale.DataBindings.Add(new Binding("SelectedIndex", MultiBandConf, "ScaleTypeIdx") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_Scale.DataBindings.Add(new Binding("EditValue", MultiBandConf, "MaxScale") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged }); 
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
            MultiBandConf.StatTermType = "day";
        }

        private void Radio_Week_CheckedChanged(object sender, EventArgs e)
        {
            MultiBandConf.StatTermType = "week";
        }

        private void Radio_Month_CheckedChanged(object sender, EventArgs e)
        {
            MultiBandConf.StatTermType = "month";
        }

        private void MimicNodeTree_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            MimicTreeNode mimicNode = MimicNodeTree.GetDataRecordByNode(e.Node) as MimicTreeNode;
            if (mimicNode.ThisNode.NodeType == 300)
            {
                ChannelConfig channel = new ChannelConfig(mimicNode);
                BaseConfig.Channel = channel;
                CheckList_Measures.DataSource = channel.BandpassArr.Where(x=>x.Visible);
                cbeAlarmScale_Update();
            }
            else
            {
                CheckList_Measures.DataSource = null;
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BaseConfig.Channel.BandpassArr[e.RowHandle].Active = (bool)e.Value;
            cbeAlarmScale_Update();
        }

        private void CheckEdit_All_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseConfig.Channel == null) return;

            foreach (var band in BaseConfig.Channel.BandpassArr)
                band.Active = CheckEdit_All.Checked;
            CheckList_Measures.RefreshDataSource();
            cbeAlarmScale_Update(); 
        }

        private void cbeAlarmScale_Update()
        {
            var cbItems = new ComboBoxItemCollection(new RepositoryItemComboBox());
            foreach (var measure in BaseConfig.Channel.BandpassArr.Where(x => x.Active).ToList())
                cbItems.Add(Name = measure.DisplayName);
            cbe_alarmScale.Properties.Items.Assign(cbItems);
        }

        private void cbe_alarmScale_Properties_PropertiesChanged(object sender, EventArgs e)
        {
            if (cbe_alarmScale.Properties.Items.Count == 0)
                cbe_alarmScale.EditValue = string.Empty;
            else if (cbe_alarmScale.Properties.Items.Count == 1)
                cbe_alarmScale.SelectedIndex = 0;
        }
    }
}