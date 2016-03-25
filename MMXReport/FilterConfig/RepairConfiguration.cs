using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class RepairConfiguration : BaseConfiguration
    {
        public bool AutoScale_Time { get; set; }
        public bool AutoScale_FFT { get; set; }
        public double MaxScale_Time { get; set; }
        public double MaxScale_FFT { get; set; }
        public DateTime BeforeRepairDate { get; set; }
        public DateTime AfterRepairDate { get; set; }
        public int RepairOffsetDay { get; set; }
        public RepairConfiguration(DBConnector dbconn) : base(dbconn)
        {
            RepairOffsetDay = 10;
            AutoScale_Time = true;
            AutoScale_FFT = true;
        }
    }
}
