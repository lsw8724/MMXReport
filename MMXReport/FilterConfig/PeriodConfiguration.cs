using MMXReport.TsiConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class PeriodConfiguration : MultiPointConfiguration
    {
        public PeriodConfiguration()
        {
            StartDate = new DateTime(StartDate.Year,1,1);
        }
    }
}
