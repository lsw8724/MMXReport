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
    public abstract class BaseConfiguration
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateStr { get { return StartDate.ToString("yyyy-MM-dd"); }}
        public string EndDateStr { get { return EndDate.ToString("yyyy-MM-dd"); }}
        public ChannelConfig Channel { get; set; }
        public string ValueMeasureType { get; set; }
        public DBConnector DBConn { get; set; }
       
        public BaseConfiguration(DBConnector dbconn)
        {
            DBConn = dbconn;
            SetDefault();
        }

        protected void SetDefault()
        {
            StartDate = new DateTime(2015, 10, 1);
            EndDate = DateTime.Now;
            ValueMeasureType = "max";
        }
    }
}
