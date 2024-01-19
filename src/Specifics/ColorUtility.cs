using DCFApixels.DataMath.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SharpColor = System.Drawing.Color;

namespace DCFApixels.DataMath
{
    public static class ColorUtility
    {

        public static SharpColor ToSharpColor<T>(T color) where T : IColor
        {
            return SharpColor.FromArgb(
                (int)(color.a * 255),
                (int)(color.r * 255),
                (int)(color.g * 255),
                (int)(color.b * 255));
        }
        public static SharpColor ToSharpColor(color color)
        {
            return SharpColor.FromArgb(
                ((int)(color.a * 255)) & int.MaxValue % 256,
                ((int)(color.r * 255)) & int.MaxValue % 256,
                ((int)(color.g * 255)) & int.MaxValue % 256,
                ((int)(color.b * 255)) & int.MaxValue % 256);
        }
        public static SharpColor ToSharpColor(colorhsv hsvColor) 
        {
            return ToSharpColor(HSVToRGB(hsvColor));
        }

        public static colorhsv RGBToHSV(color rgbColor)
        {
            colorhsv result = new colorhsv();
            RGBToHSV(rgbColor, out result.h, out result.s, out result.v);
            result.a = 1f;
            return result;
        }
        public static void RGBToHSV(color rgbColor, out float h, out float s, out float v)
        {
            if ((rgbColor.b > rgbColor.g) && (rgbColor.b > rgbColor.r))
                RGBToHSVInternal(4f, rgbColor.b, rgbColor.r, rgbColor.g, out h, out s, out v);
            else if (rgbColor.g > rgbColor.r)
                RGBToHSVInternal(2f, rgbColor.g, rgbColor.b, rgbColor.r, out h, out s, out v);
            else
                RGBToHSVInternal(0f, rgbColor.r, rgbColor.g, rgbColor.b, out h, out s, out v);
        }
        private static void RGBToHSVInternal(float offset, float dominantcolor, float colorone, float colortwo, out float h, out float s, out float v)
        {
            v = dominantcolor;
            if (v != 0)
            {
                float small = colorone > colortwo ? colortwo : colorone;
                float diff = v - small;

                if (diff != 0)
                {
                    s = diff / v;
                    h = offset + ((colorone - colortwo) / diff);
                }
                else
                {
                    s = 0;
                    h = offset + (colorone - colortwo);
                }
                h /= 6;
                if (h < 0)
                    h += 1.0f;
                return;
            }
            s = 0;
            h = 0;
        }


        public static color HSVToRGB(colorhsv hsvColor)
        {
            color result = HSVToRGB(hsvColor.h, hsvColor.s, hsvColor.v);
            result.a = hsvColor.a;
            return result;
        }
        public static color HSVToRGB(float h, float s, float v)
        {
            return HSVToRGB(h, s, v, true);
        }
        public static color HSVToRGB(float h, float s, float v, bool hdr)
        {
            color retval = color.white;
            if (s == 0)
            {
                retval.r = v;
                retval.g = v;
                retval.b = v;
            }
            else if (v == 0)
            {
                retval.r = 0;
                retval.g = 0;
                retval.b = 0;
            }
            else
            {
                retval.r = 0;
                retval.g = 0;
                retval.b = 0;

                float t_S, t_V, h_to_floor;

                t_S = s;
                t_V = v;
                h_to_floor = h * 6.0f;

                int temp = (int)math.Floor(h_to_floor);
                float t = h_to_floor - temp;
                float var_1 = (t_V) * (1 - t_S);
                float var_2 = t_V * (1 - t_S * t);
                float var_3 = t_V * (1 - t_S * (1 - t));

                switch (temp)
                {
                    case 0:
                        retval.r = t_V;
                        retval.g = var_3;
                        retval.b = var_1;
                        break;

                    case 1:
                        retval.r = var_2;
                        retval.g = t_V;
                        retval.b = var_1;
                        break;

                    case 2:
                        retval.r = var_1;
                        retval.g = t_V;
                        retval.b = var_3;
                        break;

                    case 3:
                        retval.r = var_1;
                        retval.g = var_2;
                        retval.b = t_V;
                        break;

                    case 4:
                        retval.r = var_3;
                        retval.g = var_1;
                        retval.b = t_V;
                        break;

                    case 5:
                        retval.r = t_V;
                        retval.g = var_1;
                        retval.b = var_2;
                        break;

                    case 6:
                        retval.r = t_V;
                        retval.g = var_3;
                        retval.b = var_1;
                        break;

                    case -1:
                        retval.r = t_V;
                        retval.g = var_1;
                        retval.b = var_2;
                        break;
                }

                if (!hdr)
                {
                    retval.r = math.Clamp(retval.r, 0.0f, 1.0f);
                    retval.g = math.Clamp(retval.g, 0.0f, 1.0f);
                    retval.b = math.Clamp(retval.b, 0.0f, 1.0f);
                }
            }
            return retval;
        }
    }
}
