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
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct ray3 :
        IEquatable<ray3>,
        IFormattable,
        IRay3Impl<float, float3>
    {
        #region Consts
        public static readonly ray3 zero = new ray3(0, 0);
        public static readonly ray3 one = new ray3(0, 1);
        #endregion

        public float3 src;
        public float3 dir;

        #region IRayN
        float3 IRayN<float, float3>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        float3 IRayN<float, float3>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRayN.IsVectorN { [IN(LINE)] get { return true; } }
        #endregion

        #region Constructors
        [IN(LINE)] public ray3(float3 src, float3 dir) { this.src = src; this.dir = dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(ray3 a, ray3 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(ray3 a, ray3 b) { return !a.Equals(b); }

        [IN(LINE)] public static ray3 operator -(ray3 range, float v) { return new ray3(range.src - v, range.dir - v); }
        [IN(LINE)] public static ray3 operator +(ray3 range, float v) { return new ray3(range.src + v, range.dir + v); }
        [IN(LINE)] public static ray3 operator /(ray3 range, float v) { return new ray3(range.src / v, range.dir / v); }
        [IN(LINE)] public static ray3 operator *(ray3 range, float v) { return new ray3(range.src * v, range.dir * v); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(src) ^ DM.Hash(dir); }
        [IN(LINE)] public override bool Equals(object o) { return o is ray3 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray3 a) { return DM.All(src == a.src && dir == a.dir); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray3)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray3)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float3 src;
            public float3 dir;
            public DebuggerProxy(ray3 v)
            {
                src = v.src;
                dir = v.dir;
            }
        }
        #endregion
    }
}