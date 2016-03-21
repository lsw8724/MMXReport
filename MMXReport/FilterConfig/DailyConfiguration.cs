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
        public DailyConfiguration(DBConnector dbconn) : base(dbconn)
        {
        }
    }
}
