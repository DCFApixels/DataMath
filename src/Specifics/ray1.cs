#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
    [StructLayout(LayoutKind.Sequential, Pack = sizeof(float), Size = sizeof(float) * 2)]
    public partial struct ray1 :
        IEquatable<ray1>,
        IFormattable,
        IRay1Impl<float>
    {
        #region Consts
        public static readonly ray1 zero = new ray1(0, 0);
        public static readonly ray1 one = new ray1(0, 1);
        #endregion

        public float src;
        public float dir;

        #region IRayN
        float IRayN<float, float>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float IRayN<float, float>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRayN.IsVectorN { [IN(LINE)] get { return false; } }
        #endregion

        #region Constructors
        [IN(LINE)] public ray1(float src, float dir) { this.src = src; this.dir = dir; }
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
        [IN(LINE)] public override bool Equals(object o) { return o is ray1 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray1 a) { return src == a.src && dir == a.dir; }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray1)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray1)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float src;
            public float dir;
            public DebuggerProxy(ray1 v)
            {
                src = v.src;
                dir = v.dir;
            }
        }
        #endregion
    }
}