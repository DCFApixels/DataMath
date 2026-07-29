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
    /// <summary>Three-dimensional integer line segment stored as two endpoints; preferred type for clamp, lerp, remap, and range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intline3 :
        IEquatable<intline3>,
        IFormattable,
        IRange3Impl<int, int3>
    {
        public int3 a;
        public int3 b;

        #region IRangeN
        public int3 src
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
        public int3 dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        int3 IRangeN<int, int3>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        int3 IRangeN<int, int3>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int3 min
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
        public int3 max
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
        public float3 center
        {
            [IN(LINE)]
            get { return (float3)a + (float3)(b - a) * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int3)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int3)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int3); }
        #endregion

        #region Constructors
        [IN(LINE)] public intline3(int3 a, int3 b) { this.a = a; this.b = b; }
        [IN(LINE)] public intline3(intray3 a) { this.a = a.a; this.b = a.b; }
        [IN(LINE)] public intline3(line3 a) { this.a = (int3)a.a; this.b = (int3)a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intline3 a, intline3 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intline3 a, intline3 b) { return !a.Equals(b); }

        [IN(LINE)] public static intline3 operator -(intline3 range, int v) { return new intline3(range.a - v, range.b - v); }
        [IN(LINE)] public static intline3 operator +(intline3 range, int v) { return new intline3(range.a + v, range.b + v); }
        [IN(LINE)] public static intline3 operator /(intline3 range, int v) { return new intline3(range.a / v, range.b / v); }
        [IN(LINE)] public static intline3 operator *(intline3 range, int v) { return new intline3(range.a * v, range.b * v); }

        [IN(LINE)] public static implicit operator intray3(intline3 a) { return new intray3(a); }
        [IN(LINE)] public static implicit operator line3(intline3 a) { return new line3(a.a, a.b); }
        [IN(LINE)] public static explicit operator intline3(line3 a) { return new intline3(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is intline3 target && Equals(target); }
        [IN(LINE)] public bool Equals(intline3 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intline3)}({a}, {b})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intline3)}({a.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int3 a, b;
            public DebuggerProxy(intline3 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
