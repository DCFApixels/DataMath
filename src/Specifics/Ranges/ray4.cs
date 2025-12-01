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
    public unsafe partial struct ray4 :
        IEquatable<ray4>,
        IFormattable,
        IRange4Impl<float, float4>
    {
        #region Consts
        public static readonly ray4 zero = new ray4(0, 0);
        public static readonly ray4 one = new ray4(0, 1);
        #endregion

        public float4 src;
        public float4 dir;

        #region IRangeN
        float4 IRangeN<float, float4>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float4 IRangeN<float, float4>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        public float4 a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { float4 endPoint = b; src = value; dir = endPoint - src; }
        }
        public float4 b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public float4 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { float4 currentMax = max; src = value; dir = currentMax - value; }
        }
        public float4 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { float4 currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float4 center
        {
            [IN(LINE)]
            get { return src + dir * 0.5f; }
            [IN(LINE)]
            set { src = value - dir * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float4)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float4)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float4); }
        #endregion

        #region Constructors
        [IN(LINE)] public ray4(float4 src, float4 dir) { this.src = src; this.dir = dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(ray4 a, ray4 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(ray4 a, ray4 b) { return !a.Equals(b); }

        [IN(LINE)] public static ray4 operator -(ray4 range, float v) { return new ray4(range.src - v, range.dir - v); }
        [IN(LINE)] public static ray4 operator +(ray4 range, float v) { return new ray4(range.src + v, range.dir + v); }
        [IN(LINE)] public static ray4 operator /(ray4 range, float v) { return new ray4(range.src / v, range.dir / v); }
        [IN(LINE)] public static ray4 operator *(ray4 range, float v) { return new ray4(range.src * v, range.dir * v); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        public override bool Equals(object o) { return o is ray4 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray4 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray4)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray4)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float4 src, dir;
            public DebuggerProxy(ray4 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}