using DevExpress.XtraTreeList.Nodes;
using MMXReport.TsiConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class MultiPointConfiguration : BaseConfiguration
    {
        public List<BandpassConfig> CommonBandpassList { get; set; }
        public List<ChannelConfig> SelectedChannelList { get; set; }
        public BandpassConfig SelectedBandpass { get; set; }
        public string StatTermType { get; set; }
        public MultiPointConfiguration()
        {
            StatTermType = "day";
            CommonBandpassList = new List<BandpassConfig>();
            MaxScale = 100;
        }

        public void SetChannelList(IEnumerable<MimicTreeNode> mimicNodes)
        {
            SelectedChannelList = new List<ChannelConfig>();
            foreach (var node in mimicNodes)
                SelectedChannelList.Add(new ChannelConfig(node));
            CommonBandpassList = CollectCommonOverrides();
        }

        private List<BandpassConfig> CollectCommonOverrides()
        {
            List<BandpassConfig> commonBandList = new List<BandpassConfig>();
            List<BandpassConfig> noneCommonBandList = new List<BandpassConfig>();
            if (SelectedChannelList.Count <= 0) return commonBandList;

            for (int i=0; i<SelectedChannelList.Count; i++)
            {
                if(i==0) 
                    foreach(var measure in SelectedChannelList[i].BandpassArr)
                        commonBandList.Add(measure);
                else
                    foreach (var measure in commonBandList)
                    {
                        if (!SelectedChannelList[i].BandpassArr.Select(x => x.DisplayName).Contains(measure.DisplayName))
                            noneCommonBandList.Add(measure);
                    }                    
            }
            foreach (var measure in noneCommonBandList)
                commonBandList.Remove(measure);
            return commonBandList;
        }
    }
}
