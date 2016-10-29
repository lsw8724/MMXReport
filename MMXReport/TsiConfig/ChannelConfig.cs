using MMXReport.DataBase;
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
        public bool Visible { get; set; }
        public bool Active { get; set; }
        public string BandpassName { get; set; }
        public string DisplayName { get; set; }
        public DspVectorOverride OverrideInfo { get; set; }
    }

    public class ChannelConfig
    {
        public string MachineName { get; set; }
        public string LineName { get; set; }
        public string PointName{get;set;}
        public int Id { get; set; }
        public DspVectorOverride[] Overrides { get; set; }
        public BandpassConfig[] BandpassArr { get; set; }
        public ChannelConfig(MimicTreeNode treeNode)
        {
            LineName = treeNode.ParentNode.ParentNode.ThisNode.Name;
            MachineName = treeNode.ParentNode.ThisNode.Name;
            PointName = treeNode.ThisNode.Name;
            Id = treeNode.ThisNode.ChannelId;
            var channel = SQLRepository.SensorChannelCache.Where(x=>x.Value.Id == treeNode.ThisNode.ChannelId).FirstOrDefault();
            var extra = channel.Value.ExtraJson;
            if(extra != null && extra.VectorOverrides != null)
                Overrides = extra.VectorOverrides.Where(x =>!string.IsNullOrWhiteSpace(x.OverrideName)).ToArray();
            SetBandPass();
        }

        private void SetBandPass()
        {
            if (Overrides != null)
            {
                BandpassArr = new BandpassConfig[Overrides.Length];

                for (int i = 0; i < BandpassArr.Length; i++)
                {
                    string bandpassName = Enum.GetValues(typeof(VectorOverrideOrder)).GetValue(i).ToString();

                    BandpassArr[i] = new BandpassConfig()
                    {
                        Visible = (Overrides[i].OverrideName == null || Overrides[i].OverrideName == string.Empty) ? false : true,
                        DisplayName = Overrides[i].OverrideName,
                        OverrideInfo = Overrides[i],
                        BandpassName = bandpassName
                    };
                }
            }
            else //TSI 설정
            {
                BandpassArr = new BandpassConfig[Enum.GetValues(typeof(VectorOverrideOrder)).Length];

                for (int i = 0; i < BandpassArr.Length; i++)
                {
                    string bandpassName = Enum.GetValues(typeof(VectorOverrideOrder)).GetValue(i).ToString();

                    BandpassArr[i] = new BandpassConfig()
                    {
                        Visible = true,
                        DisplayName = bandpassName,
                        OverrideInfo = null,
                        BandpassName = bandpassName
                    };
                }
            }
        }
    }
}
