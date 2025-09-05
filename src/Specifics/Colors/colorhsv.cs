using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
using System.ComponentModel;
using DCFApixels.DataMath.Internal;


#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace DCFApixels.DataMath
{
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [StructLayout(LayoutKind.Sequential, Pack = sizeof(float), Size = 4 * Count)]
    public partial struct colorhsv :
        IEquatable<colorhsv>,
        IFormattable,
        IVector4<float>,
        IColorHSV,
        IEnumerableVector<float, colorhsv>
    {
        #region Consts
        public const int Count = 4;

        /// <summary> rgba(1, 0, 0, 1) </summary>
        public readonly static colorhsv red = ColorUtility.RGBToHSV(color.red);
        /// <summary> rgba(0, 1, 0, 1) </summary>
        public readonly static colorhsv green = ColorUtility.RGBToHSV(color.green);
        /// <summary> rgba(0, 0, 1, 1) </summary>
        public readonly static colorhsv blue = ColorUtility.RGBToHSV(color.blue);
        /// <summary> rgba(0, 0, 0, 0) </summary>
        public readonly static colorhsv clean = ColorUtility.RGBToHSV(color.clean);

        /// <summary> rgba(1, 1, 1, 1) </summary>
        public readonly static colorhsv white = ColorUtility.RGBToHSV(color.white);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static colorhsv gray = ColorUtility.RGBToHSV(color.gray);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static colorhsv grey = gray;
        /// <summary> rgba(0, 0, 0, 1) </summary>
        public readonly static colorhsv black = ColorUtility.RGBToHSV(color.black);

        /// <summary> rgba(1, 1, 0, 1) </summary>
        public readonly static colorhsv yellow = ColorUtility.RGBToHSV(color.yellow);
        /// <summary> rgba(1, 0.5, 0, 1) </summary>
        public readonly static colorhsv orange = ColorUtility.RGBToHSV(color.orange);
        /// <summary> rgba(0, 1, 1, 1) </summary>
        public readonly static colorhsv cyan = ColorUtility.RGBToHSV(color.cyan);
        /// <summary> rgba(1, 0, 1, 1) </summary>
        public readonly static colorhsv magenta = ColorUtility.RGBToHSV(color.magenta);
        #endregion

        public float h;
        public float s;
        public float v;
        public float a;

        #region Properties
        public float w { [IN(LINE)] get { return h; } [IN(LINE)] set { h = value; } }
        public float z { [IN(LINE)] get { return s; } [IN(LINE)] set { s = value; } }
        public float y { [IN(LINE)] get { return v; } [IN(LINE)] set { v = value; } }
        public float x { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IColorHSV.h { [IN(LINE)] get { return h; } [IN(LINE)] set { h = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IColorHSV.s { [IN(LINE)] get { return s; } [IN(LINE)] set { s = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IColorHSV.v { [IN(LINE)] get { return v; } [IN(LINE)] set { v = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IColorHSV.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (colorhsv* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (float* array = &h) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is float cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(float); }
        #endregion

        #region Constructors
        [IN(LINE)] public colorhsv(colorhsv v) { this = v; }
        [IN(LINE)]
        public colorhsv(float h, float s, float v)
        {
            this.h = h; this.s = s;
            this.v = v; a = 1;
        }
        [IN(LINE)]
        public colorhsv(float h, float s, float v, float a)
        {
            this.h = h; this.s = s;
            this.v = v; this.a = a;
        }
        [IN(LINE)] public colorhsv(int colorCode) : this(new color(colorCode)) { }
        [IN(LINE)] public colorhsv(uint colorCode) : this(new color(colorCode)) { }
        [IN(LINE)] public colorhsv(color v) { this = ColorUtility.RGBToHSV(v); }
        [IN(LINE)] public colorhsv(color32 v) : this(new color(v)) { }
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

        #region Converts
        public static explicit operator colorhsv(int colorcode) { return new colorhsv(colorcode); }
        public static explicit operator colorhsv(uint colorcode) { return new colorhsv(colorcode); }
        public static explicit operator colorhsv(color a) { return new colorhsv(a); }
        public static implicit operator colorhsv(color32 a) { return new colorhsv(a); }
        #endregion


        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is colorhsv target && Equals(target); }
        [IN(LINE)] public bool Equals(colorhsv a) { return h == a.h && s == a.s && v == a.v && this.a == a.a; }
        public override string ToString() { return $"{nameof(colorhsv)}({h}, {s}, {v}, {a})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(colorhsv)}({h.ToString(format, formatProvider)}, {s.ToString(format, formatProvider)}, {v.ToString(format, formatProvider)}, {a.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float h, s, v, a;
            public DebuggerProxy(colorhsv value) { h = value.h; s = value.s; v = value.v; a = value.a; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<float, colorhsv> GetEnumerator() { return new VectorEnumerator<float, colorhsv>(this); }
        VectorEnumerator<float, colorhsv> IEnumerableVector<float, colorhsv>.GetEnumerator() { return new VectorEnumerator<float, colorhsv>(this); }
        IEnumerator<float> IEnumerable<float>.GetEnumerator() { return new VectorEnumerator<float, colorhsv>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<float, colorhsv>(this); }
        #endregion
    }
}