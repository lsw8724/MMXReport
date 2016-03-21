using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.TsiConfig
{
    public class ExtraChannelConfig
    {
        ////알람off 불감대
        //public int AlarmDeadBand { get; set; }
        public int PeakWindowSize { get; set; }
        public TorqueCalConfig TorqueConfig { get; set; }
        public TorqueCalConfig TorqueConfigOrDefault { get { return TorqueConfig == null ? new TorqueCalConfig() : TorqueConfig; } }
        public ExtraCncMeasure[] CncMeasures { get; set; }  //두산 공작기계용
        public DspVectorOverride[] VectorOverrides { get; set; }    //인덱스는 VectorOverrideOrder
        public string ModbusIp { get; set; }
        public int ModbusPort { get; set; }
        public string Net100Url { get; set; }
        public string Net100Id { get; set; }
        public string Net100Password { get; set; }
        public string MelsecIp { get; set; }
        public int MelsecPort { get; set; }
        public ExtraChannelConfig()
        {
            PeakWindowSize = 1;
            ModbusIp = "192.168.0.0";
            ModbusPort = 502; //혹은 4800을 보통 사용
            //VectorOverrides = Enumerable.Range(0, 6).Select(i => new DspVectorOverride()).ToArray();  //생성버튼으로 생성하도록 수정
        }
    }

    public class TorqueCalConfig { }
     
    public class ExtraCncMeasure { }

    public class DspVectorOverride
    {
        public bool Override = false;
        public string OverrideName;         // [Write ignore]
        public string OverrideUnit;
        public TsiCmsCalculateType DspType;
        public TsiCmsMeasureType MeasureType;
        public float fOption1;
        public float fOption2;

        public int nOption1;
        public int nOption2;
        public int nOption3;                // [Write ignore]
        public int nOption4;                // [Write ignore]
        public float fOption3;
        public float fOption4;
        public string sOption1;

        public float[] AlarmValues;

        //DSP용 설정만 write
        public void Write(System.IO.BinaryWriter writer)
        {
            writer.Write((short)(Override ? 1 : 0));
            writer.Write((short)DspType);
            writer.Write(fOption1);
            writer.Write(fOption2);

            writer.Write(nOption1);
            writer.Write(nOption2);

            writer.Write(fOption3);
            writer.Write(fOption4);
        }
    }

}
