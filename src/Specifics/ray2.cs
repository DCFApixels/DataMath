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
    public unsafe partial struct ray2 :
        IEquatable<ray2>,
        IFormattable,
        IRay2Impl<float, float2>
    {
        #region Consts
        public static readonly ray2 zero = new ray2(0, 0);
        public static readonly ray2 one = new ray2(0, 1);
        #endregion

        public float2 src;
        public float2 dir;

        #region IRayN
        float2 IRayN<float, float2>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float2 IRayN<float, float2>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRayN.IsVectorN { [IN(LINE)] get { return true; } }
        #endregion

        #region Constructors
        [IN(LINE)] public ray2(float2 src, float2 dir) { this.src = src; this.dir = dir; }
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
        [IN(LINE)] public override bool Equals(object o) { return o is ray2 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray2 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray2)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray2)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float2 src;
            public float2 dir;
            public DebuggerProxy(ray2 v)
            {
                src = v.src;
                dir = v.dir;
            }
        }
        #endregion
    }
}