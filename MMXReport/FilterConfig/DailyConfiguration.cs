using MMXReport.TsiConfig;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class DailyConfiguration : BaseConfiguration
    {
        public ShiftItem SelectedItem { get; set; }
        public DailyConfiguration()
        {
        }
    }

    public class ShiftItem
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string TimeStrFrom { get { return From.ToString("HH:mm:ss"); } }
        public string TimeStrTo { get { return To.ToString("HH:mm:ss"); } }
        public string Description { get; set; }

        public ShiftItem(DateTime from, DateTime to, string desc)
        {
            From = from;
            To = to;
            Description = desc;
        }

        public DevExpress.XtraEditors.Controls.RadioGroupItem ToRadioItem()
        {
            return new DevExpress.XtraEditors.Controls.RadioGroupItem(this, Description);
        }
    }
}
