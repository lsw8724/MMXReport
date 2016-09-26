using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class RepairConfiguration : BaseConfiguration
    {
        public int ScaleTypeIdx_Time {get;set;}
        public int ScaleTypeIdx_FFT{ get; set; }
        public double MaxScale_Time { get; set; }
        public double MaxScale_FFT { get; set; }
        public double MinScale_Time { get; set; }
        public DateTime BeforeRepairDate { get; set; }
        public DateTime AfterRepairDate { get; set; }
        public int RepairOffsetDay { get; set; }
        public RepairConfiguration()
        {
            RepairOffsetDay = 10;
            MaxScale = 100;
            MinScale_Time = -10;
            MaxScale_Time = 10;
            MaxScale_FFT = 100;
        }
    }
}
