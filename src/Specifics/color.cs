using System.Collections;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public struct color :
        IVector4<float>,
        IColor,
        IEquatable<color>,
        IFormattable
    {
        #region Consts
        public const int LENGTH = 4;

        /// <summary> rgba(1, 0, 0, 1) </summary>
        public readonly static color red = new color(1f, 0f, 0f);
        /// <summary> rgba(0, 1, 0, 1) </summary>
        public readonly static color green = new color(0f, 1f, 0f);
        /// <summary> rgba(0, 0, 1, 1) </summary>
        public readonly static color blue = new color(0f, 0f, 0f);
        /// <summary> rgba(0, 0, 0, 0) </summary>
        public readonly static color clean = new color(0f, 0f, 0f, 0f);

        /// <summary> rgba(1, 1, 1, 1) </summary>
        public readonly static color white = new color(1f, 1f, 1f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static color gray = new color(0.5f, 0.5f, 0.5f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static color grey = gray;
        /// <summary> rgba(0, 0, 0, 1) </summary>
        public readonly static color black = new color(0f, 0f, 0f);

        /// <summary> rgba(1, 1, 0, 1) </summary>
        public readonly static color yellow = new color(1f, 1f, 0f);
        /// <summary> rgba(1, 0.5, 0, 1) </summary>
        public readonly static color orange = new color(1f, 0.5f, 0f);
        /// <summary> rgba(0, 1, 1, 1) </summary>
        public readonly static color cyan = new color(0f, 1f, 1f);
        /// <summary> rgba(1, 0, 1, 1) </summary>
        public readonly static color magenta = new color(1f, 0f, 1f);
        #endregion

        public float r;
        public float g;
        public float b;
        public float a;

        #region Properties
        public float w { [IN(LINE)] get => r; [IN(LINE)] set => r = value; }
        public float z { [IN(LINE)] get => g; [IN(LINE)] set => g = value; }
        public float y { [IN(LINE)] get => b; [IN(LINE)] set => b = value; }
        public float x { [IN(LINE)] get => a; [IN(LINE)] set => a = value; }
        float IColor.r { [IN(LINE)] get => r; [IN(LINE)] set => r = value; }
        float IColor.g { [IN(LINE)] get => g; [IN(LINE)] set => g = value; }
        float IColor.b { [IN(LINE)] get => b; [IN(LINE)] set => b = value; }
        float IColor.a { [IN(LINE)] get => a; [IN(LINE)] set => a = value; }
        float IVector4<float>.w { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float IVector3<float>.z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float IVector2<float>.y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        float IVector1<float>.x { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int count { [IN(LINE)] get => LENGTH; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (color* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &r) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        public color(float r, float g, float b)
        {
            this.r = r; this.g = g;
            this.b = b; a = 1;
        }
        public color(float r, float g, float b, float a)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = a;
        }
        #endregion

        #region Arithmetic operators
        [IN(LINE)]
        public static color operator *(color a, color b) => new color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        [IN(LINE)]
        public static color operator *(color a, float b) => new color(a.r * b, a.g * b, a.b * b, a.a * b);
        [IN(LINE)]
        public static color operator *(float a, color b) => new color(a * b.r, a * b.g, a * b.b, a * b.a);
        [IN(LINE)]
        public static color operator *(color a, float4 b) => new color(a.r * b.x, a.g * b.y, a.b * b.z, a.a * b.w);
        [IN(LINE)]
        public static color operator *(float4 a, color b) => new color(a.x * b.r, a.y * b.g, a.z * b.b, a.w * b.a);

        [IN(LINE)]
        public static color operator +(color a, color b) => new color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        [IN(LINE)]
        public static color operator +(color a, float b) => new color(a.r + b, a.g + b, a.b + b, a.a + b);
        [IN(LINE)]
        public static color operator +(float a, color b) => new color(a + b.r, a + b.g, a + b.b, a + b.a);
        [IN(LINE)]
        public static color operator +(color a, float4 b) => new color(a.r + b.x, a.g + b.y, a.b + b.z, a.a + b.w);
        [IN(LINE)]
        public static color operator +(float4 a, color b) => new color(a.x + b.r, a.y + b.g, a.z + b.b, a.w + b.a);

        [IN(LINE)]
        public static color operator -(color a, color b) => new color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        [IN(LINE)]
        public static color operator -(color a, float b) => new color(a.r - b, a.g - b, a.b - b, a.a - b);
        [IN(LINE)]
        public static color operator -(float a, color b) => new color(a - b.r, a - b.g, a - b.b, a - b.a);
        [IN(LINE)]
        public static color operator -(color a, float4 b) => new color(a.r - b.x, a.g - b.y, a.b - b.z, a.a - b.w);
        [IN(LINE)]
        public static color operator -(float4 a, color b) => new color(a.x - b.r, a.y - b.g, a.z - b.b, a.w - b.a);

        [IN(LINE)]
        public static color operator /(color a, color b) => new color(a.r / b.r, a.g / b.g, a.b / b.b, a.a / b.a);
        [IN(LINE)]
        public static color operator /(color a, float b) => new color(a.r / b, a.g / b, a.b / b, a.a / b);
        [IN(LINE)]
        public static color operator /(float a, color b) => new color(a / b.r, a / b.g, a / b.b, a / b.a);
        [IN(LINE)]
        public static color operator /(color a, float4 b) => new color(a.r / b.x, a.g / b.y, a.b / b.z, a.a / b.w);
        [IN(LINE)]
        public static color operator /(float4 a, color b) => new color(a.x / b.r, a.y / b.g, a.z / b.b, a.w / b.a);

        [IN(LINE)]
        public static color operator %(color a, color b) => new color(a.r % b.r, a.g % b.g, a.b % b.b, a.a % b.a);
        [IN(LINE)]
        public static color operator %(color a, float b) => new color(a.r % b, a.g % b, a.b % b, a.a % b);
        [IN(LINE)]
        public static color operator %(float a, color b) => new color(a % b.r, a % b.g, a % b.b, a % b.a);
        [IN(LINE)]
        public static color operator %(color a, float4 b) => new color(a.r % b.z, a.g % b.y, a.b % b.z, a.a % b.w);
        [IN(LINE)]
        public static color operator %(float4 a, color b) => new color(a.z % b.r, a.y % b.g, a.z % b.b, a.w % b.a);

        [IN(LINE)]
        public static color operator ++(color a) => new color(++a.r, ++a.g, ++a.b, ++a.a);
        [IN(LINE)]
        public static color operator --(color a) => new color(--a.r, --a.g, --a.b, --a.a);
        [IN(LINE)]
        public static color operator -(color a) => new color(-a.r, -a.g, -a.b, -a.a);
        [IN(LINE)]
        public static color operator +(color a) => new color(+a.r, +a.g, +a.b, +a.a);
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() => DM.AsInt(r) ^ DM.AsInt(g) ^ DM.AsInt(b) ^ DM.AsInt(a);
        [IN(LINE)] public override bool Equals(object o) => o is color target && Equals(target);
        [IN(LINE)] public bool Equals(color a) => r == a.r && g == a.g && b == a.b && this.a == a.a;
        [IN(LINE)] public override string ToString() => $"{nameof(color)}({r}, {g}, {b}, {a})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(color)}({r.ToString(format, formatProvider)}, {g.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)}, {a.ToString(format, formatProvider)})";
        }
        #endregion

        #region GetEnumerator
        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
