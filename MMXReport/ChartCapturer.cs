using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMXReport
{
    public class ChartCapturer
    {
        public ChartCapturer(Size size, Point p)
        {
            Bitmap screenshot = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraph = Graphics.FromImage(screenshot);
            screenGraph.CopyFromScreen(p, Point.Empty, size, CopyPixelOperation.SourceCopy);
            screenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
