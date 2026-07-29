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
    /// <summary>One-dimensional integer range stored as two endpoints; preferred type for clamp, lerp, remap, and range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intline1 :
        IEquatable<intline1>,
        IFormattable,
        IRange1Impl<int>
    {
        public int a;
        public int b;

        #region IRangeN
        public int src
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
        public int dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        int IRangeN<int, int>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        int IRangeN<int, int>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int min
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
        public int max
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
        public float center
        {
            [IN(LINE)]
            get { return (a + b) * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return false; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int); }
        #endregion

        #region Constructors
        [IN(LINE)] public intline1(int a, int b) { this.a = a; this.b = b; }
        [IN(LINE)] public intline1(intray1 a) { this.a = a.a; this.b = a.b; }
        [IN(LINE)] public intline1(line1 a) { this.a = (int)a.a; this.b = (int)a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intline1 a, intline1 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intline1 a, intline1 b) { return !a.Equals(b); }

        [IN(LINE)] public static intline1 operator -(intline1 range, int v) { return new intline1(range.a - v, range.b - v); }
        [IN(LINE)] public static intline1 operator +(intline1 range, int v) { return new intline1(range.a + v, range.b + v); }
        [IN(LINE)] public static intline1 operator /(intline1 range, int v) { return new intline1(range.a / v, range.b / v); }
        [IN(LINE)] public static intline1 operator *(intline1 range, int v) { return new intline1(range.a * v, range.b * v); }

        [IN(LINE)] public static implicit operator intray1(intline1 a) { return new intray1(a); }
        [IN(LINE)] public static implicit operator line1(intline1 a) { return new line1(a.a, a.b); }
        [IN(LINE)] public static explicit operator intline1(line1 a) { return new intline1(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is intline1 target && Equals(target); }
        [IN(LINE)] public bool Equals(intline1 a) { return this.a == a.a && b == a.b; }
        [IN(LINE)] public override string ToString() { return $"{nameof(intline1)}({a}, {b})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intline1)}({a.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int a, b;
            public DebuggerProxy(intline1 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
