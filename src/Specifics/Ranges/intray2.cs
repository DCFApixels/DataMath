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
    /// <summary>Two-dimensional integer line segment stored as start point plus displacement; use intline2 for endpoint/range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intray2 :
        IEquatable<intray2>,
        IFormattable,
        IRange2Impl<int, int2>
    {
        #region Consts
        public static readonly intray2 zero = new intray2(0, 0);
        public static readonly intray2 one = new intray2(0, 1);
        #endregion

        public int2 src;
        public int2 dir;

        #region IRangeN
        public int2 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { int2 endPoint = b; src = value; dir = endPoint - src; }
        }
        public int2 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public int2 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { int2 currentMax = max; src = value; dir = currentMax - value; }
        }
        public int2 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { int2 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float2 center
        {
            [IN(LINE)]
            get { return src + (float2)dir * 0.5f; }
        }
        int2 IRangeN<int, int2>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        int2 IRangeN<int, int2>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int2)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int2)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int2); }
        #endregion

        #region Constructors
        [IN(LINE)] public intray2(int2 src, int2 dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public intray2(ray2 ray) { src = (int2)ray.src; dir = (int2)ray.dir; }
        [IN(LINE)] public intray2(intline2 a) { src = a.src; dir = a.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intray2 a, intray2 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intray2 a, intray2 b) { return !a.Equals(b); }

        [IN(LINE)] public static intray2 operator -(intray2 range, int v) { return new intray2(range.src - v, range.dir); }
        [IN(LINE)] public static intray2 operator +(intray2 range, int v) { return new intray2(range.src + v, range.dir); }
        [IN(LINE)] public static intray2 operator /(intray2 range, int v) { return new intray2(range.src / v, range.dir / v); }
        [IN(LINE)] public static intray2 operator *(intray2 range, int v) { return new intray2(range.src * v, range.dir * v); }
        [IN(LINE)] public static implicit operator intline2(intray2 a) { return new intline2(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is intray2 target && Equals(target); }
        [IN(LINE)] public bool Equals(intray2 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intray2)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intray2)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int2 src, dir;
            public DebuggerProxy(intray2 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}
