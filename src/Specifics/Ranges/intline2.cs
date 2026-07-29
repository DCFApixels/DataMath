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
    /// <summary>Two-dimensional integer line segment stored as two endpoints; preferred type for clamp, lerp, remap, and range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intline2 :
        IEquatable<intline2>,
        IFormattable,
        IRange2Impl<int, int2>
    {
        public int2 a;
        public int2 b;

        #region IRangeN
        public int2 src
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
        public int2 dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        int2 IRangeN<int, int2>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        int2 IRangeN<int, int2>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int2 min
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
        public int2 max
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
        public float2 center
        {
            [IN(LINE)]
            get { return (float2)a + (float2)(b - a) * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int2)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int2)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int2); }
        #endregion

        #region Constructors
        [IN(LINE)] public intline2(int2 a, int2 b) { this.a = a; this.b = b; }
        [IN(LINE)] public intline2(intray2 a) { this.a = a.a; this.b = a.b; }
        [IN(LINE)] public intline2(line2 a) { this.a = (int2)a.a; this.b = (int2)a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intline2 a, intline2 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intline2 a, intline2 b) { return !a.Equals(b); }

        [IN(LINE)] public static intline2 operator -(intline2 range, int v) { return new intline2(range.a - v, range.b - v); }
        [IN(LINE)] public static intline2 operator +(intline2 range, int v) { return new intline2(range.a + v, range.b + v); }
        [IN(LINE)] public static intline2 operator /(intline2 range, int v) { return new intline2(range.a / v, range.b / v); }
        [IN(LINE)] public static intline2 operator *(intline2 range, int v) { return new intline2(range.a * v, range.b * v); }

        [IN(LINE)] public static implicit operator intray2(intline2 a) { return new intray2(a); }
        [IN(LINE)] public static implicit operator line2(intline2 a) { return new line2(a.a, a.b); }
        [IN(LINE)] public static explicit operator intline2(line2 a) { return new intline2(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is intline2 target && Equals(target); }
        [IN(LINE)] public bool Equals(intline2 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intline2)}({a}, {b})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intline2)}({a.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int2 a, b;
            public DebuggerProxy(intline2 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
