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
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct ray2 :
        IEquatable<ray2>,
        IFormattable,
        IRange2Impl<float, float2>
    {
        #region Consts
        public static readonly ray2 zero = new ray2(0, 0);
        public static readonly ray2 one = new ray2(0, 1);
        #endregion

        public float2 src;
        public float2 dir;

        #region IRangeN
        float2 IRangeN<float, float2>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float2 IRangeN<float, float2>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        public float2 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { float2 endPoint = b; src = value; dir = endPoint - src; }
        }
        public float2 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public float2 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { float2 currentMax = max; src = value; dir = currentMax - value; }
        }
        public float2 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { float2 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float2 center
        {
            [IN(LINE)]
            get { return src + dir * 0.5f; }
            [IN(LINE)]
            set { src = value - dir * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float2)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float2)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float2); }
        #endregion

        #region Constructors
        [IN(LINE)] public ray2(float2 src, float2 dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public ray2(intray2 ray) { src = ray.src; dir = ray.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(ray2 a, ray2 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(ray2 a, ray2 b) { return !a.Equals(b); }

        [IN(LINE)] public static ray2 operator -(ray2 range, float v) { return new ray2(range.src - v, range.dir - v); }
        [IN(LINE)] public static ray2 operator +(ray2 range, float v) { return new ray2(range.src + v, range.dir + v); }
        [IN(LINE)] public static ray2 operator /(ray2 range, float v) { return new ray2(range.src / v, range.dir / v); }
        [IN(LINE)] public static ray2 operator *(ray2 range, float v) { return new ray2(range.src * v, range.dir * v); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is ray2 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray2 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray2)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray2)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float2 src, dir;
            public DebuggerProxy(ray2 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}