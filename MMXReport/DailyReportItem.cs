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

        public static ChannelStatus CheckStatus(float[] alarms, float maxValue)
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
