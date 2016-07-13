using MathNet.Numerics.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMXReport
{
    public class WaveData
    {
        public DateTime DataUTCTime { get; set; }
        public int FMax { get; set; }
        public int Line { get; set; }
        public double Duration { get { return (double)Line / FMax; } }
        public float[] AsyncData { get; set; }
    }

    public class SpectrumData
    {
        public DateTime DataUTCTime { get; set; }
        public int FMax { get; set; }
        public int Line { get; set; }
        public double Duration { get { return (double)Line / FMax; } }
        public float[] XValues { get; set; }
        public float[] YValues { get; set; }
    }

    public class FFTConvertor
    {
        public SpectrumData CalcSpectrumData(WaveData wave)
        {
            float[] fft = PositiveFFT(wave.AsyncData);
            int lineCount = fft.Length;
            float[] freq = new float[lineCount];
            for (int i = 0; i < lineCount; i++)
                freq[i] = (float)(i / wave.Duration);
            return new SpectrumData()
            {
                DataUTCTime = wave.DataUTCTime,
                FMax = wave.FMax,
                Line = wave.Line,
                YValues = fft,
                XValues = freq
            };
        }

        #region FFT 계산
        private static RealFourierTransformation rft = new RealFourierTransformation(TransformationConvention.NoScaling);
        private static float[] PositiveFFT(float[] timeData)
        {
            var N = timeData.Length;
            double[] rawfft = FFT(timeData);
            var normalizer = 4.0 / N;
            double[] optScale = rawfft.Take(N / 2).Select(f => f * normalizer).ToArray();  //스케일링 최적화
            float[] result = new float[optScale.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = (float)optScale[i];
            return result;
        }

        private static double[] FFT(float[] timeData)
        {
            double[] xdata = new double[timeData.Length];
            for (int i = 0; i < timeData.Length; i++)
                xdata[i] = timeData[i];
            double[] reals, imags;
            rft.TransformForward(xdata, out reals, out imags);
            for (int i = 0; i < reals.Length; i++)
                reals[i] = Math.Sqrt(reals[i] * reals[i] + imags[i] * imags[i]);
            return reals;
        }
        #endregion
    }
}
