using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using MMXReport.TsiConfig;
using System.Drawing;

namespace MMXReport
{
    public class ChannelStatus
    {
        public Color StatColor;
        public Color StatColor_Font;
        public string Stat;
    }
    public class DailyReportItem
    {
        public int ChannelId { get; set; }
        public string Machine { get; set; }
        public string Point { get; set; }
        public string Function { get; set; }
        public string Unit { get; set; }
        public float Caution { get; set; }
        public float Failure { get; set; }
        public float Repair { get; set; }
        public float Stop { get; set; }
        public float MIN { get; set; }
        public float MAX { get; set; }
        public float AVG { get; set; }
        public ChannelStatus Status { get; set; }
        public string Remark { get; set; }

        public DailyReportItem()//Sample 데이터
        {
            ChannelId = 1;
            Machine = "설비 - 1";
            Point = "Point #1";
            Function = "Vrms";
            Unit = "㎜/s";
            Caution = 5.3f;
            Failure = 6.5f;
            Repair = 7.7f;
            Stop = 8.9f;
            MIN = 1.5f;
            MAX = 3.0f;
            AVG = 2.0f;
            Status = new ChannelStatus() { Stat = "Good", StatColor = Color.LightGreen };
            Remark = "";
        }
        public DailyReportItem(DataRow row) // 0 chid, 1 Machine, 2 Point, 3 Bandpass, 4 MIN, 5 MAX, 6 AVG, 7 ExtraJSON
        {
            int chid = Convert.ToInt32(row.ItemArray[0]);
            DspVectorOverride[] overrides = JsonConvert.DeserializeObject<ExtraChannelConfig>(row.ItemArray[7].ToString()).VectorOverrides;
            int overrideIdx = Array.IndexOf(Enum.GetNames(typeof(VectorOverrideOrder)), row.ItemArray[3].ToString());
            float[] alarms = overrides[overrideIdx].AlarmValues;
            if (alarms == null) alarms = new float[] { 0f, 0f, 0f, 0f };
            if (overrides[overrideIdx].OverrideName != null && overrides[overrideIdx].OverrideName != string.Empty)
            {
                ChannelId = chid;
                Machine = row.ItemArray[1].ToString();
                Point = row.ItemArray[2].ToString();
                Function = overrides[overrideIdx].OverrideName;
                Unit = overrides[overrideIdx].OverrideUnit;
                Caution = alarms[0];
                Failure = alarms[1];
                Repair = alarms[2];
                Stop = alarms[3];
                MIN = Convert.ToSingle(row.ItemArray[4]);
                MAX = Convert.ToSingle(row.ItemArray[5]);
                AVG = Convert.ToSingle(row.ItemArray[6]);
                Status = CheckStatus(alarms, MAX);
                Remark = "";
            }
        }

        private ChannelStatus CheckStatus(float[] alarms, float maxValue)
        {
            ChannelStatus status = new ChannelStatus();
            if (maxValue >= alarms[3])
            {
                status.Stat = "Stop";
                status.StatColor = Color.Red;
                status.StatColor_Font = Color.White;
            }
            else if (maxValue >= alarms[2])
            {
                status.Stat = "Repair";
                status.StatColor = Color.OrangeRed;
                status.StatColor_Font = Color.White;
            }
            else if (maxValue >= alarms[1])
            {
                status.StatColor = Color.Yellow;
                status.StatColor_Font = Color.Black;
                status.Stat = "Failure";
            }
            else if (maxValue >= alarms[0])
            {
                status.StatColor = Color.Pink;
                status.StatColor_Font = Color.Black;
                status.Stat = "Caution";
            }
            else
            {
                status.StatColor = Color.LightGreen;
                status.StatColor_Font = Color.Black;
                status.Stat = "Good";
            }
            return status;
        }
    }

}
