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
            Gr_Measurement.Text = MultiLang.Measurement;
            CheckEdit_All.Text = MultiLang.BatchCheck;
            labelControl1.Text = MultiLang.BeforeMaintenance;
            labelControl2.Text = MultiLang.AfterMaintenance;
            labelControl4.Text = MultiLang.Days;
            MimicNodeTree.DataSource = common.MimicNodes;
            MimicNodeTree.BestFitColumns();
            Numeric_RepairOffset.Value = RepairConf.RepairOffsetDay;
            DateEdit_Before.DateTime = BaseConfig.StartDate;
            DateEdit_After.DateTime = BaseConfig.EndDate;

            cbe_alarmScale.DataBindings.Add(new Binding("EditValue", RepairConf, "AlarmReferenceName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale.DataBindings.Add(new Binding("SelectedIndex", RepairConf, "ScaleTypeIdx") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScaleTime.DataBindings.Add(new Binding("SelectedIndex", RepairConf, "ScaleTypeIdx_Time") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScaleFFT.DataBindings.Add(new Binding("SelectedIndex", RepairConf, "ScaleTypeIdx_FFT") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_maxScale.DataBindings.Add(new Binding("EditValue", RepairConf, "MaxScale") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_maxScaleTime.DataBindings.Add(new Binding("EditValue", RepairConf, "MaxScale_Time") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_minScaleTime.DataBindings.Add(new Binding("EditValue", RepairConf, "MinScale_Time") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_maxScaleFFT.DataBindings.Add(new Binding("EditValue", RepairConf, "MaxScale_FFT") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });            
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
            MimicTreeNode mimicNode = MimicNodeTree.GetDataRecordByNode(e.Node) as MimicTreeNode;
            if (mimicNode.ThisNode.NodeType == 300)
            {
                ChannelConfig channel = new ChannelConfig(mimicNode);
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
            cbeAlarmScale_Update(); 
        }

        private void CheckEdit_All_CheckedChanged(object sender, EventArgs e)
        {
            if (BaseConfig.Channel != null)
            {
                foreach (var band in BaseConfig.Channel.BandpassArr)
                    band.Active = CheckEdit_All.Checked;
                CheckList_Bandpass.RefreshDataSource();
                cbeAlarmScale_Update(); 
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