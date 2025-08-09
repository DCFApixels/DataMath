using System;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public struct colorhsv :
        IVector4<float>,
        IEquatable<colorhsv>,
        IFormattable
    {
        public const int LENGTH = 4;

        public readonly static colorhsv white = ColorUtility.RGBToHSV(color.white);
        public readonly static colorhsv black = ColorUtility.RGBToHSV(color.black);

        public float h;
        public float s;
        public float v;
        public float a;

        #region Properties
        public float w { get => h; set => h = value; }
        public float z { get => s; set => s = value; }
        public float y { get => v; set => v = value; }
        public float x { get => a; set => a = value; }
        public int length => LENGTH;

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (colorhsv* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &h) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        public colorhsv(float h, float s, float v)
        {
            this.h = h; this.s = s;
            this.v = v; a = 1;
        }
        public colorhsv(float h, float s, float v, float a)
        {
            this.h = h; this.s = s;
            this.v = v; this.a = a;
        }
        #endregion

        #region Arithmetic operators
        [IN(LINE)]
        public static colorhsv operator *(colorhsv a, colorhsv b) => new colorhsv(a.h * b.h, a.s * b.s, a.v * b.v, a.a * b.a);
        [IN(LINE)]
        public static colorhsv operator *(colorhsv a, float b) => new colorhsv(a.h * b, a.s * b, a.v * b, a.a * b);
        [IN(LINE)]
        public static colorhsv operator *(float a, colorhsv b) => new colorhsv(a * b.h, a * b.s, a * b.v, a * b.a);
        [IN(LINE)]
        public static colorhsv operator *(colorhsv a, float4 b) => new colorhsv(a.h * b.x, a.s * b.y, a.v * b.z, a.a * b.w);
        [IN(LINE)]
        public static colorhsv operator *(float4 a, colorhsv b) => new colorhsv(a.x * b.h, a.y * b.s, a.z * b.v, a.w * b.a);

        [IN(LINE)]
        public static colorhsv operator +(colorhsv a, colorhsv b) => new colorhsv(a.h + b.h, a.s + b.s, a.v + b.v, a.a + b.a);
        [IN(LINE)]
        public static colorhsv operator +(colorhsv a, float b) => new colorhsv(a.h + b, a.s + b, a.v + b, a.a + b);
        [IN(LINE)]
        public static colorhsv operator +(float a, colorhsv b) => new colorhsv(a + b.h, a + b.s, a + b.v, a + b.a);
        [IN(LINE)]
        public static colorhsv operator +(colorhsv a, float4 b) => new colorhsv(a.h + b.x, a.s + b.y, a.v + b.z, a.a + b.w);
        [IN(LINE)]
        public static colorhsv operator +(float4 a, colorhsv b) => new colorhsv(a.x + b.h, a.y + b.s, a.z + b.v, a.w + b.a);

        [IN(LINE)]
        public static colorhsv operator -(colorhsv a, colorhsv b) => new colorhsv(a.h - b.h, a.s - b.s, a.v - b.v, a.a - b.a);
        [IN(LINE)]
        public static colorhsv operator -(colorhsv a, float b) => new colorhsv(a.h - b, a.s - b, a.v - b, a.a - b);
        [IN(LINE)]
        public static colorhsv operator -(float a, colorhsv b) => new colorhsv(a - b.h, a - b.s, a - b.v, a - b.a);
        [IN(LINE)]
        public static colorhsv operator -(colorhsv a, float4 b) => new colorhsv(a.h - b.x, a.s - b.y, a.v - b.z, a.a - b.w);
        [IN(LINE)]
        public static colorhsv operator -(float4 a, colorhsv b) => new colorhsv(a.x - b.h, a.y - b.s, a.z - b.v, a.w - b.a);

        [IN(LINE)]
        public static colorhsv operator /(colorhsv a, colorhsv b) => new colorhsv(a.h / b.h, a.s / b.s, a.v / b.v, a.a / b.a);
        [IN(LINE)]
        public static colorhsv operator /(colorhsv a, float b) => new colorhsv(a.h / b, a.s / b, a.v / b, a.a / b);
        [IN(LINE)]
        public static colorhsv operator /(float a, colorhsv b) => new colorhsv(a / b.h, a / b.s, a / b.v, a / b.a);
        [IN(LINE)]
        public static colorhsv operator /(colorhsv a, float4 b) => new colorhsv(a.h / b.x, a.s / b.y, a.v / b.z, a.a / b.w);
        [IN(LINE)]
        public static colorhsv operator /(float4 a, colorhsv b) => new colorhsv(a.x / b.h, a.y / b.s, a.z / b.v, a.w / b.a);

        [IN(LINE)]
        public static colorhsv operator %(colorhsv a, colorhsv b) => new colorhsv(a.h % b.h, a.s % b.s, a.v % b.v, a.a % b.a);
        [IN(LINE)]
        public static colorhsv operator %(colorhsv a, float b) => new colorhsv(a.h % b, a.s % b, a.v % b, a.a % b);
        [IN(LINE)]
        public static colorhsv operator %(float a, colorhsv b) => new colorhsv(a % b.h, a % b.s, a % b.v, a % b.a);
        [IN(LINE)]
        public static colorhsv operator %(colorhsv a, float4 b) => new colorhsv(a.h % b.z, a.s % b.y, a.v % b.z, a.a % b.w);
        [IN(LINE)]
        public static colorhsv operator %(float4 a, colorhsv b) => new colorhsv(a.z % b.h, a.y % b.s, a.z % b.v, a.w % b.a);

        [IN(LINE)]
        public static colorhsv operator ++(colorhsv a) => new colorhsv(++a.h, ++a.s, ++a.v, ++a.a);
        [IN(LINE)]
        public static colorhsv operator --(colorhsv a) => new colorhsv(--a.h, --a.s, --a.v, --a.a);
        [IN(LINE)]
        public static colorhsv operator -(colorhsv a) => new colorhsv(-a.h, -a.s, -a.v, -a.a);
        [IN(LINE)]
        public static colorhsv operator +(colorhsv a) => new colorhsv(+a.h, +a.s, +a.v, +a.a);
        #endregion


        #region Other
        [IN(LINE)] public override int GetHashCode() => math.AsInt(h) ^ math.AsInt(s) ^ math.AsInt(v) ^ math.AsInt(a);
        [IN(LINE)] public override bool Equals(object o) => o is colorhsv target && Equals(target);
        [IN(LINE)] public bool Equals(colorhsv a) => h == a.h && s == a.s && v == a.v && this.a == a.a;
        [IN(LINE)] public override string ToString() => $"{nameof(colorhsv)}({h}, {s}, {v}, {a})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(colorhsv)}({h.ToString(format, formatProvider)}, {s.ToString(format, formatProvider)}, {v.ToString(format, formatProvider)}, {a.ToString(format, formatProvider)})";
        }
        #endregion
    }
}
