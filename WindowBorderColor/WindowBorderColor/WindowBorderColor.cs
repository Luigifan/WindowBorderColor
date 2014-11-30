using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WindowBorderColor
{
    public class WindowBorderColor
    {
        /// <summary>
        /// Retrieves the aero border color on Windows 8/Windows 8.1
        /// </summary>
        /// <returns>System.Drawing.Color drawingColor: the actual color</returns>
        public System.Drawing.Color BorderColor()
        {
            System.Windows.Media.Color mediaColor = SystemParameters.WindowGlassColor;
            System.Drawing.Color drawingColor = System.Drawing.Color.FromArgb(160, mediaColor.R, mediaColor.G, mediaColor.B);
            return drawingColor;
        }
        /// <summary>
        /// Gets the right ContrastColor (aka set your font color to whatever this spits out)
        /// </summary>
        /// <param name="color">Put in the value you retrieved for BorderColor</param>
        /// <returns>White or black, depending. It outputs a System.Drawing.Color</returns>
        public System.Drawing.Color ConstrastColor(System.Drawing.Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return System.Drawing.Color.FromArgb(d, d, d);
        }
        //
    }
}
