using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMXReport.TsiConfig
{
    public class BandpassConfig
    {
        public bool Active { get; set; }
        public string BandpassName { get; set; }
        public DspVectorOverride OverrideInfo { get; set; }
        public string DisplayName { get; set; }
        public string DisplayUnit { get; set; }
    }

    public class ChannelConfig
    {
        public string PointName{get;set;}
        public int Id { get; set; }
        public DspVectorOverride[] Overrides { get; set; }
        public BandpassConfig[] BandpassArr { get; set; }
        public ChannelConfig(MimicNode mimicNode, DBConnector dbConn)
        {
            PointName = mimicNode.NodeName;
            Id = mimicNode.ChannelId;
            Overrides = dbConn.LoadExtraJSON(mimicNode.ChannelId).VectorOverrides;
            SetBandPass();
        }

        private void SetBandPass()
        {
            BandpassArr = new BandpassConfig[Overrides.Count()];
            
            for(int i=0 ; i<BandpassArr.Length; i++)
            {
                string bandpassName = Enum.GetValues(typeof(VectorOverrideOrder)).GetValue(i).ToString();
                BandpassArr[i] = new BandpassConfig()
                {
                    OverrideInfo = Overrides[i],
                    DisplayName = (!Overrides[i].Override || Overrides[i].OverrideName == null || Overrides[i].OverrideName == string.Empty)? bandpassName:Overrides[i].OverrideName,
                    BandpassName = bandpassName
                };
            }
        }
    }
}
