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
    public partial class GeneralConfigDlg : BaseConfigDlg
    {
        public GeneralTrendConfiguration GeneralConf { get { return (GeneralTrendConfiguration)BaseConfig; } }

        public GeneralConfigDlg(BaseConfiguration baseConf)
            : base(baseConf)
        {
            InitializeComponent();
            Text = MultiLang.GenaralTrend + " " + MultiLang.Filter;
            Btn_Close.Text = MultiLang.Close;
            groupControl1.Text = MultiLang.OperationPeriod;
            groupControl2.Text = MultiLang.TypeOfMeasurement;
            groupControl3.Text = MultiLang.Unit;
            groupControl4.Text = "Y " + MultiLang.Scale;
            Gr_Machine1.Text = MultiLang.PlantMap + "1";
            Gr_Machine2.Text = MultiLang.PlantMap + "2";
            Gr_Machine3.Text = MultiLang.PlantMap + "3";
            Gr_Measurement1.Text = MultiLang.Measurement + "1";
            Gr_Measurement2.Text = MultiLang.Measurement + "2";
            Gr_Measurement3.Text = MultiLang.Measurement + "3";
            Radio_Day.Text = MultiLang.Day;
            Radio_Week.Text = MultiLang.Week;
            Radio_Month.Text = MultiLang.Month;

            TreeListInit(MimicNodeTree1);
            TreeListInit(MimicNodeTree2);
            TreeListInit(MimicNodeTree3);
            DateEdit_Start.DateTime = BaseConfig.StartDate;
            DateEdit_End.DateTime = BaseConfig.EndDate;

            cbe_alarmScale1.DataBindings.Add(new Binding("EditValue", GeneralConf, "AlarmReferenceName") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale1.DataBindings.Add(new Binding("SelectedIndex", GeneralConf, "ScaleTypeIdx") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_Scale1.DataBindings.Add(new Binding("EditValue", GeneralConf, "MaxScale") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });

            cbe_alarmScale2.DataBindings.Add(new Binding("EditValue", GeneralConf, "AlarmReferenceName2") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale2.DataBindings.Add(new Binding("SelectedIndex", GeneralConf, "ScaleTypeIdx2") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_Scale2.DataBindings.Add(new Binding("EditValue", GeneralConf, "MaxScale2") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });

            cbe_alarmScale3.DataBindings.Add(new Binding("EditValue", GeneralConf, "AlarmReferenceName3") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            radioGroupScale3.DataBindings.Add(new Binding("SelectedIndex", GeneralConf, "ScaleTypeIdx3") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            te_Scale3.DataBindings.Add(new Binding("EditValue", GeneralConf, "MaxScale3") { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });

        }

        private void TreeListInit(TreeList tl)
        {
            tl.DataSource = GeneralConf.MimicNodes;
            tl.BestFitColumns();
            tl.ExpandAll();
            tl.CollapseAll();
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
            GeneralConf.StatTermType = "day";
        }

        private void Radio_Week_CheckedChanged(object sender, EventArgs e)
        {
            GeneralConf.StatTermType = "week";
        }

        private void Radio_Month_CheckedChanged(object sender, EventArgs e)
        {
            GeneralConf.StatTermType = "month";
        }

        private void MimicNodeTree_AfterCheckNode(object sender, NodeEventArgs e)
        {
            var tl = sender as TreeList;
            TreeChildAllCheck(tl, e.Node.Nodes);
            MimicTreeNodes pointNodes = (tl.DataSource as MimicTreeNodes).SearchNodes(300);
            GeneralConf.SetChannelList(pointNodes.Where(x => x.Active));
            switch (tl.Name)
            {
                case "MimicNodeTree1": 
                    List_Bandpass1.DataSource = GeneralConf.CommonBandpassList; 
                    cbeAlarmScale_Update(cbe_alarmScale1);
                    break;
                case "MimicNodeTree2": 
                    List_Bandpass2.DataSource = GeneralConf.CommonBandpassList;
                    cbeAlarmScale_Update(cbe_alarmScale2);
                    break;
                case "MimicNodeTree3": 
                    List_Bandpass3.DataSource = GeneralConf.CommonBandpassList; 
                    cbeAlarmScale_Update(cbe_alarmScale3);
                    break;
            }
        }

        private void TreeChildAllCheck(TreeList tl ,TreeListNodes nodes)
        {
            if (nodes.Count == 0)
            {
                (tl.GetDataRecordByNode(nodes.ParentNode) as MimicTreeNode).Active = nodes.ParentNode.Checked;
                return;
            }

            foreach (TreeListNode node in nodes)
            {
                node.Checked = nodes.ParentNode.Checked;
                TreeChildAllCheck(tl,node.Nodes);
            }
            switch (tl.Name)
            {
                case "MimicNodeTree1": cbeAlarmScale_Update(cbe_alarmScale1); break;
                case "MimicNodeTree2": cbeAlarmScale_Update(cbe_alarmScale2); break;
                case "MimicNodeTree3": cbeAlarmScale_Update(cbe_alarmScale3); break;
            } 
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for(int i=0; i<GeneralConf.CommonBandpassList.Count; i++)
            {
                if (i == e.FocusedRowHandle)
                {
                    GeneralConf.CommonBandpassList[i].Active = true;
                    GeneralConf.SelectedBandpass = GeneralConf.CommonBandpassList[i];
                }
                else
                    GeneralConf.CommonBandpassList[i].Active = false;
            }
        }

        private void cbeAlarmScale_Update(ComboBoxEdit cbe)
        {
            if (GeneralConf.SelectedChannelList == null) return;
            var cbItems = new ComboBoxItemCollection(new RepositoryItemComboBox());
            foreach (var ch in GeneralConf.SelectedChannelList)
                cbItems.Add(Name = ch.PointName);
            cbe.Properties.Items.Assign(cbItems);
        }

        private void cbe_alarmScale_Properties_PropertiesChanged(object sender, EventArgs e)
        {
            var cbe = sender as RepositoryItemComboBox;
            if (cbe == null) return;
            if (cbe.Items.Count == 0)
                cbe.OwnerEdit.Text = string.Empty;
        }
    }
}