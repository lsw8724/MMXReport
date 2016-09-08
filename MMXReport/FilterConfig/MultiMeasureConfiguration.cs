using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class MultiMeasureConfiguration : BaseConfiguration
    {
        public string StatTermType { get; set; }
       
        public MultiMeasureConfiguration()
        {
            StatTermType = "day";
            MaxScale = 100;
        }
    }
}
