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
    /// <summary>Three-dimensional integer line segment stored as start point plus displacement; use intline3 for endpoint/range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct intray3 :
        IEquatable<intray3>,
        IFormattable,
        IRange3Impl<int, int3>
    {
        #region Consts
        public static readonly intray3 zero = new intray3(0, 0);
        public static readonly intray3 one = new intray3(0, 1);
        #endregion

        public int3 src;
        public int3 dir;

        #region IRangeN
        public int3 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { int3 endPoint = b; src = value; dir = endPoint - src; }
        }
        public int3 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public int3 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { int3 currentMax = max; src = value; dir = currentMax - value; }
        }
        public int3 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { int3 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float3 center
        {
            [IN(LINE)]
            get { return (float3)src + (float3)dir * 0.5f; }
        }
        int3 IRangeN<int, int3>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        int3 IRangeN<int, int3>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (int3)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (int3)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(int3); }
        #endregion

        #region Constructors
        [IN(LINE)] public intray3(int3 src, int3 dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public intray3(ray3 ray) { src = (int3)ray.src; dir = (int3)ray.dir; }
        [IN(LINE)] public intray3(intline3 a) { src = a.src; dir = a.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intray3 a, intray3 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intray3 a, intray3 b) { return !a.Equals(b); }

        [IN(LINE)] public static intray3 operator -(intray3 range, int v) { return new intray3(range.src - v, range.dir); }
        [IN(LINE)] public static intray3 operator +(intray3 range, int v) { return new intray3(range.src + v, range.dir); }
        [IN(LINE)] public static intray3 operator /(intray3 range, int v) { return new intray3(range.src / v, range.dir / v); }
        [IN(LINE)] public static intray3 operator *(intray3 range, int v) { return new intray3(range.src * v, range.dir * v); }
        [IN(LINE)] public static implicit operator intline3(intray3 a) { return new intline3(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is intray3 target && Equals(target); }
        [IN(LINE)] public bool Equals(intray3 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(intray3)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intray3)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int3 src, dir;
            public DebuggerProxy(intray3 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}
