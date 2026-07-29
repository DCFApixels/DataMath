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
    /// <summary>Three-dimensional float line segment stored as start point plus displacement; use line3 for endpoint/range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct ray3 :
        IEquatable<ray3>,
        IFormattable,
        IRange3Impl<float, float3>
    {
        #region Consts
        public static readonly ray3 zero = new ray3(0, 0);
        public static readonly ray3 one = new ray3(0, 1);
        #endregion

        public float3 src;
        public float3 dir;

        #region IRangeN
        float3 IRangeN<float, float3>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float3 IRangeN<float, float3>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        public float3 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { float3 endPoint = b; src = value; dir = endPoint - src; }
        }
        public float3 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public float3 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { float3 currentMax = max; src = value; dir = currentMax - value; }
        }
        public float3 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { float3 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float3 center
        {
            [IN(LINE)]
            get { return src + dir * 0.5f; }
            [IN(LINE)]
            set { src = value - dir * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float3)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float3)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float3); }
        #endregion

        #region Constructors
        [IN(LINE)] public ray3(float3 src, float3 dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public ray3(intray3 ray) { src = ray.src; dir = ray.dir; }
        [IN(LINE)] public ray3(line3 a) { src = a.src; dir = a.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(ray3 a, ray3 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(ray3 a, ray3 b) { return !a.Equals(b); }

        [IN(LINE)] public static ray3 operator -(ray3 range, float v) { return new ray3(range.src - v, range.dir); }
        [IN(LINE)] public static ray3 operator +(ray3 range, float v) { return new ray3(range.src + v, range.dir); }
        [IN(LINE)] public static ray3 operator /(ray3 range, float v) { return new ray3(range.src / v, range.dir / v); }
        [IN(LINE)] public static ray3 operator *(ray3 range, float v) { return new ray3(range.src * v, range.dir * v); }

        [IN(LINE)] public static implicit operator line3(ray3 a) { return new line3(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is ray3 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray3 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray3)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray3)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float3 src, dir;
            public DebuggerProxy(ray3 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}
