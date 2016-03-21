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
        public List<BandpassConfig> SelectedBandpassList { get; set; }
        public List<ChannelConfig> SelectedChannelList { get; set; }
        public string StatTermType { get; set; }
        public MultiPointConfiguration(DBConnector dbconn) : base(dbconn)
        {
            StatTermType = "day";
        }

        public void SetChannelList(IEnumerable<MimicNode> mimicNodes)
        {
            SelectedChannelList = new List<ChannelConfig>();
            foreach (var node in mimicNodes)
                SelectedChannelList.Add(new ChannelConfig(node, DBConn));
            SelectedBandpassList = CollectCommonOverrides();
        }

        private List<BandpassConfig> CollectCommonOverrides()
        {
            List<BandpassConfig> bandList = new List<BandpassConfig>();
            if (SelectedChannelList.Count > 0)
            {
                BandpassConfig[] bandArr = SelectedChannelList.First().BandpassArr;
                bool[] isCommonBandpass = new bool[9];
                for (int i = 0; i < bandArr.Length; i++)
                {
                    foreach (var ch in SelectedChannelList)
                    {
                        if (isCommonBandpass[i]) break;
                        if (bandArr[i].DisplayName != ch.BandpassArr[i].DisplayName)
                        {
                            isCommonBandpass[i] = true;
                            break;
                        }
                    }
                    if (!isCommonBandpass[i])
                        bandList.Add(bandArr[i]);
                }
                bandList[0].Active = true;
            }
            return bandList;
        }
    }
}
