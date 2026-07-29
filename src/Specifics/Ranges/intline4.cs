#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using System;
using System.Diagnostics;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    /// <summary>Four-dimensional integer line segment stored as two endpoints; preferred type for clamp, lerp, remap, and range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intline4 :
        IEquatable<intline4>,
        IFormattable,
        IRange4Impl<int, int4>
    {
        public int4 a;
        public int4 b;

        #region IRangeN
        public int4 src
        {
            [IN(LINE)]
            get { return a; }
            [IN(LINE)]
            set
            {
                var direction = b - a;
                a = value;
                b = value + direction;
            }
        }
        public int4 dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        int4 IRangeN<int, int4>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        int4 IRangeN<int, int4>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int4 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set
            {
                var currentMax = DM.Max(a, b);
                a = value;
                b = currentMax;
            }
        }
        public int4 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set
            {
                var currentMin = DM.Min(a, b);
                a = currentMin;
                b = value;
            }
        }
        public float4 center
        {
            [IN(LINE)]
            get { return (float4)a + (float4)(b - a) * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int4)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int4)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int4); }
        #endregion

        #region Constructors
        [IN(LINE)] public intline4(int4 a, int4 b) { this.a = a; this.b = b; }
        [IN(LINE)] public intline4(intray4 a) { this.a = a.a; this.b = a.b; }
        [IN(LINE)] public intline4(line4 a) { this.a = (int4)a.a; this.b = (int4)a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intline4 a, intline4 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intline4 a, intline4 b) { return !a.Equals(b); }

        [IN(LINE)] public static intline4 operator -(intline4 range, int v) { return new intline4(range.a - v, range.b - v); }
        [IN(LINE)] public static intline4 operator +(intline4 range, int v) { return new intline4(range.a + v, range.b + v); }
        [IN(LINE)] public static intline4 operator /(intline4 range, int v) { return new intline4(range.a / v, range.b / v); }
        [IN(LINE)] public static intline4 operator *(intline4 range, int v) { return new intline4(range.a * v, range.b * v); }

        [IN(LINE)] public static implicit operator intray4(intline4 a) { return new intray4(a); }
        [IN(LINE)] public static implicit operator line4(intline4 a) { return new line4(a.a, a.b); }
        [IN(LINE)] public static explicit operator intline4(line4 a) { return new intline4(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is intline4 target && Equals(target); }
        [IN(LINE)] public bool Equals(intline4 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intline4)}({a}, {b})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intline4)}({a.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int4 a, b;
            public DebuggerProxy(intline4 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
