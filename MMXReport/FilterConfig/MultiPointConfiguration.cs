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
            if (SelectedChannelList.Count > 0)
            {
                BandpassConfig[] bandArr = SelectedChannelList.First().BandpassArr;
                bool[] isNotCommonBandpass = new bool[9];
                for (int i = 0; i < bandArr.Length; i++)
                {
                    foreach (var ch in SelectedChannelList)
                    {
                        if (isNotCommonBandpass[i]) break;
                        if (bandArr[i].OverrideInfo.OverrideName != ch.BandpassArr[i].OverrideInfo.OverrideName || !ch.BandpassArr[i].Visible)
                        {
                            isNotCommonBandpass[i] = true;
                            break;
                        }
                    }
                    if (!isNotCommonBandpass[i])
                        commonBandList.Add(bandArr[i]);
                }
                if(commonBandList.Count > 0)
                    commonBandList[0].Active = true;
            }
            return commonBandList;
        }
    }
}
