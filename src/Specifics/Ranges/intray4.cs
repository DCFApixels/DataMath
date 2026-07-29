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
    /// <summary>Four-dimensional integer line segment stored as start point plus displacement; use intline4 for endpoint/range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intray4 :
        IEquatable<intray4>,
        IFormattable,
        IRange4Impl<int, int4>
    {
        #region Consts
        public static readonly intray4 zero = new intray4(0, 0);
        public static readonly intray4 one = new intray4(0, 1);
        #endregion

        public int4 src;
        public int4 dir;

        #region IRangeN
        public int4 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { int4 endPoint = b; src = value; dir = endPoint - src; }
        }
        public int4 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public int4 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { int4 currentMax = max; src = value; dir = currentMax - value; }
        }
        public int4 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { int4 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float4 center
        {
            [IN(LINE)]
            get { return (float4)src + (float4)dir * 0.5f; }
        }
        int4 IRangeN<int, int4>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        int4 IRangeN<int, int4>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int4)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int4)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int4); }
        #endregion

        #region Constructors
        [IN(LINE)] public intray4(int4 src, int4 dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public intray4(ray4 ray) { src = (int4)ray.src; dir = (int4)ray.dir; }
        [IN(LINE)] public intray4(intline4 a) { src = a.src; dir = a.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intray4 a, intray4 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intray4 a, intray4 b) { return !a.Equals(b); }

        [IN(LINE)] public static intray4 operator -(intray4 range, int v) { return new intray4(range.src - v, range.dir); }
        [IN(LINE)] public static intray4 operator +(intray4 range, int v) { return new intray4(range.src + v, range.dir); }
        [IN(LINE)] public static intray4 operator /(intray4 range, int v) { return new intray4(range.src / v, range.dir / v); }
        [IN(LINE)] public static intray4 operator *(intray4 range, int v) { return new intray4(range.src * v, range.dir * v); }
        [IN(LINE)] public static implicit operator intline4(intray4 a) { return new intline4(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is intray4 target && Equals(target); }
        [IN(LINE)] public bool Equals(intray4 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intray4)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intray4)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int4 src, dir;
            public DebuggerProxy(intray4 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}
