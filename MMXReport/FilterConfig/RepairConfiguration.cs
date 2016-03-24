using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class RepairConfiguration : BaseConfiguration
    {
        public DateTime BeforeRepairDate { get; set; }
        public DateTime AfterRepairDate { get; set; }
        public int RepairOffsetDay { get; set; }
        public RepairConfiguration(DBConnector dbconn) : base(dbconn)
        {
            RepairOffsetDay = 10;
        }
    }
}
