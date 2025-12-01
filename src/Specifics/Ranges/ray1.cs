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
    public unsafe partial struct ray1 :
        IEquatable<ray1>,
        IFormattable,
        IRange1Impl<float>
    {
        #region Consts
        public static readonly ray1 zero = new ray1(0, 0);
        public static readonly ray1 one = new ray1(0, 1);
        #endregion

        public float src;
        public float dir;

        #region IRangeN
        float IRangeN<float, float>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float IRangeN<float, float>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        public float a
        {
            [IN(LINE)]
            get { return src; }
            [IN(LINE)]
            set { float endPoint = b; src = value; dir = endPoint - src; }
        }
        public float b
        {
            [IN(LINE)]
            get { return src + dir; }
            [IN(LINE)]
            set { dir = value - src; }
        }
        public float min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set { float currentMax = max; src = value; dir = currentMax - value; }
        }
        public float max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set { float currentMin = min; dir = value - currentMin; src = currentMin; }
        }
        public float center
        {
            [IN(LINE)]
            get { return src + dir * 0.5f; }
            [IN(LINE)]
            set { src = value - dir * 0.5f; }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return false; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float); }
        #endregion

        #region Constructors
        [IN(LINE)] public ray1(float src, float dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public ray1(intray1 ray) { src = ray.src; dir = ray.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(ray1 a, ray1 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(ray1 a, ray1 b) { return !a.Equals(b); }

        [IN(LINE)] public static ray1 operator -(ray1 range, float v) { return new ray1(range.src - v, range.dir - v); }
        [IN(LINE)] public static ray1 operator +(ray1 range, float v) { return new ray1(range.src + v, range.dir + v); }
        [IN(LINE)] public static ray1 operator /(ray1 range, float v) { return new ray1(range.src / v, range.dir / v); }
        [IN(LINE)] public static ray1 operator *(ray1 range, float v) { return new ray1(range.src * v, range.dir * v); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.AsInt(src) ^ DM.AsInt(dir); }
        public override bool Equals(object o) { return o is ray1 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray1 a) { return src == a.src && dir == a.dir; }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray1)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray1)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float src, dir;
            public DebuggerProxy(ray1 v) { src = v.src; dir = v.dir; }
        }
        #endregion
    }
}