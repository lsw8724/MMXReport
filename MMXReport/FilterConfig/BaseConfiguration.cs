using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MMXReport.TsiConfig;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

namespace MMXReport
{
    public enum ScaleType { Auto=0, Alarm=1, Custom=2 };
    public abstract class BaseConfiguration
    {
        public double MaxScale { get; set; }
        public int ScaleTypeIdx { get; set; }
        public string AlarmReferenceName { get; set; } 
        public bool AutoScale { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateStr { get { return StartDate.ToString("yyyy-MM-dd"); }}
        public string EndDateStr { get { return EndDate.ToString("yyyy-MM-dd"); }}
        public ChannelConfig Channel { get; set; }
        public string ValueMeasureType { get; set; }
       
        public BaseConfiguration()
        {
            SetDefault();
        }

        protected void SetDefault()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            ValueMeasureType = "avg";
            AutoScale = true;
        }
    }
}
