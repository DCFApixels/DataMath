using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [Serializable]
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [StructLayout(LayoutKind.Sequential, Pack = sizeof(float), Size = 4 * Count)]
    public struct color :
        IEquatable<color>,
        IFormattable,
        IVector4<float>,
        IColor,
        IEnumerableVector<float, color>
    {
        #region Consts
        public const int Count = 4;

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

        private const float ByteToFloatMult = 1f / byte.MaxValue;
        #endregion

        public float r;
        public float g;
        public float b;
        public float a;

        #region Properties
        public float w { [IN(LINE)] get { return r; } [IN(LINE)] set { r = value; } }
        public float z { [IN(LINE)] get { return g; } [IN(LINE)] set { g = value; } }
        public float y { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float x { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        float IColor.r { [IN(LINE)] get { return r; } [IN(LINE)] set { r = value; } }
        float IColor.g { [IN(LINE)] get { return g; } [IN(LINE)] set { g = value; } }
        float IColor.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        float IColor.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public int count { [IN(LINE)] get => Count; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (color* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (float* array = &r) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public color(float r, float g, float b)
        {
            this.r = r; this.g = g;
            this.b = b; a = 1;
        }
        [IN(LINE)]
        public color(float r, float g, float b, float a)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = a;
        }
        [IN(LINE)] public color((float r, float g, float b) v) { r = v.r; g = v.g; b = v.b; a = 1f; }
        [IN(LINE)] public color((float r, float g, float b, float a) v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)] public color(float3 v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)] public color(float4 v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)] public color(double3 v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)] public color(double4 v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)]
        public color(color32 v)
        {
            r = v.r8 * ByteToFloatMult; g = v.g8 * ByteToFloatMult;
            b = v.b8 * ByteToFloatMult; a = v.a8 * ByteToFloatMult;
        }
        [IN(LINE)]
        public color(int colorCode)
        {
            ColorCodeUnion v = colorCode;
            r = v.r8 * ByteToFloatMult; g = v.g8 * ByteToFloatMult;
            b = v.b8 * ByteToFloatMult; a = v.a8 * ByteToFloatMult;
        }
        [IN(LINE)]
        public color(uint colorCode)
        {
            ColorCodeUnion v = colorCode;
            r = v.r8 * ByteToFloatMult; g = v.g8 * ByteToFloatMult;
            b = v.b8 * ByteToFloatMult; a = v.a8 * ByteToFloatMult;
        }
        #endregion

        #region Arithmetic operators
        [IN(LINE)] public static color operator *(color a, color b) => new color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        [IN(LINE)] public static color operator *(color a, float b) => new color(a.r * b, a.g * b, a.b * b, a.a * b);
        [IN(LINE)] public static color operator *(float a, color b) => new color(a * b.r, a * b.g, a * b.b, a * b.a);
        [IN(LINE)] public static color operator *(color a, float4 b) => new color(a.r * b.x, a.g * b.y, a.b * b.z, a.a * b.w);
        [IN(LINE)] public static color operator *(float4 a, color b) => new color(a.x * b.r, a.y * b.g, a.z * b.b, a.w * b.a);

        [IN(LINE)] public static color operator +(color a, color b) => new color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        [IN(LINE)] public static color operator +(color a, float b) => new color(a.r + b, a.g + b, a.b + b, a.a + b);
        [IN(LINE)] public static color operator +(float a, color b) => new color(a + b.r, a + b.g, a + b.b, a + b.a);
        [IN(LINE)] public static color operator +(color a, float4 b) => new color(a.r + b.x, a.g + b.y, a.b + b.z, a.a + b.w);
        [IN(LINE)] public static color operator +(float4 a, color b) => new color(a.x + b.r, a.y + b.g, a.z + b.b, a.w + b.a);

        [IN(LINE)] public static color operator -(color a, color b) => new color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        [IN(LINE)] public static color operator -(color a, float b) => new color(a.r - b, a.g - b, a.b - b, a.a - b);
        [IN(LINE)] public static color operator -(float a, color b) => new color(a - b.r, a - b.g, a - b.b, a - b.a);
        [IN(LINE)] public static color operator -(color a, float4 b) => new color(a.r - b.x, a.g - b.y, a.b - b.z, a.a - b.w);
        [IN(LINE)] public static color operator -(float4 a, color b) => new color(a.x - b.r, a.y - b.g, a.z - b.b, a.w - b.a);

        [IN(LINE)] public static color operator /(color a, color b) => new color(a.r / b.r, a.g / b.g, a.b / b.b, a.a / b.a);
        [IN(LINE)] public static color operator /(color a, float b) => new color(a.r / b, a.g / b, a.b / b, a.a / b);
        [IN(LINE)] public static color operator /(float a, color b) => new color(a / b.r, a / b.g, a / b.b, a / b.a);
        [IN(LINE)] public static color operator /(color a, float4 b) => new color(a.r / b.x, a.g / b.y, a.b / b.z, a.a / b.w);
        [IN(LINE)] public static color operator /(float4 a, color b) => new color(a.x / b.r, a.y / b.g, a.z / b.b, a.w / b.a);

        [IN(LINE)] public static color operator %(color a, color b) => new color(a.r % b.r, a.g % b.g, a.b % b.b, a.a % b.a);
        [IN(LINE)] public static color operator %(color a, float b) => new color(a.r % b, a.g % b, a.b % b, a.a % b);
        [IN(LINE)] public static color operator %(float a, color b) => new color(a % b.r, a % b.g, a % b.b, a % b.a);
        [IN(LINE)] public static color operator %(color a, float4 b) => new color(a.r % b.z, a.g % b.y, a.b % b.z, a.a % b.w);
        [IN(LINE)] public static color operator %(float4 a, color b) => new color(a.z % b.r, a.y % b.g, a.z % b.b, a.w % b.a);

        [IN(LINE)] public static color operator ++(color a) => new color(++a.r, ++a.g, ++a.b, ++a.a);
        [IN(LINE)] public static color operator --(color a) => new color(--a.r, --a.g, --a.b, --a.a);
        [IN(LINE)] public static color operator -(color a) => new color(-a.r, -a.g, -a.b, -a.a);
        [IN(LINE)] public static color operator +(color a) => new color(+a.r, +a.g, +a.b, +a.a);
        #endregion

        #region Converts
        public static explicit operator color(int colorcode) { return new color(colorcode); }
        public static explicit operator color(uint colorcode) { return new color(colorcode); }
        public static implicit operator color(color32 a) { return new color(a); }
        public static implicit operator color(float3 a) { return new color(a); }
        public static implicit operator color(float4 a) { return new color(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is color target && Equals(target); }
        [IN(LINE)] public bool Equals(color a) { return r == a.r && g == a.g && b == a.b && this.a == a.a; }
        public override string ToString() { return $"{nameof(color)}({r}, {g}, {b}, {a})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(color)}({r.ToString(format, formatProvider)}, {g.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)}, {a.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float r, g, b, a;
            public DebuggerProxy(color value) { r = value.r; g = value.g; b = value.b; a = value.a; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<float, color> GetEnumerator() { return new VectorEnumerator<float, color>(this); }
        VectorEnumerator<float, color> IEnumerableVector<float, color>.GetEnumerator() { return new VectorEnumerator<float, color>(this); }
        IEnumerator<float> IEnumerable<float>.GetEnumerator() { return new VectorEnumerator<float, color>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<float, color>(this); }
        #endregion
    }
}
