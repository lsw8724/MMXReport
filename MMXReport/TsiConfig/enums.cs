using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport.TsiConfig
{
    public enum TsiCmsCalculateType
    {
        None,

        //DSP계산
        VelocityBand,
        AccelerationBand,
        EnvelopBand,
        Peak,
        PeakToPeak,
        Crestfactor,
        DC,

        //외부
        Modbus,
        NET100,
        MELSEC
    }

    //비진동용
    public enum TsiCmsMeasureType
    {
        [Description("(미설정)")]
        None,
        [Description("진동")]
        Vibration,
        [Description("전류")]
        Current,
        [Description("전압")]
        Voltage,
        [Description("온도")]
        Temperature,
        [Description("토크")]
        Torque,
        [Description("풍량")]
        AirVolume,
        [Description("시간")]
        Duration,
        [Description("압력")]
        Pressure,
    }

    public enum VectorOverrideOrder
    {
        [Description("1X Amp")]
        OneXAmp =0,

        [Description("1X Phase")]
        OneXPhase,

        [Description("2X Amp")]
        TwoXAmp,

        [Description("2X Phase")]
        TwoXPhase,

        [Description("nX Amp")]
        nXAmp,

        [Description("nX Phase")]
        nXPhase,

        [Description("Direct")]
        Direct,

        [Description("Bandpass")]
        Bandpass,

        [Description("CrestFactor")]
        CrestFactor,
    }
}
