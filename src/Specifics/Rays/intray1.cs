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
    [StructLayout(LayoutKind.Sequential, Pack = sizeof(int), Size = sizeof(int) * 2)]
    public unsafe partial struct intray1 :
        IEquatable<intray1>,
        IFormattable,
        IRay1Impl<int>
    {
        #region Consts
        public static readonly intray1 zero = new intray1(0, 0);
        public static readonly intray1 one = new intray1(0, 1);
        #endregion

        public int src;
        public int dir;

        #region IRayN
        int IRayN<int, int>.src { [IN(LINE)] get { return src; } [IN(LINE)] set { src = value; } }
        int IRayN<int, int>.dir { [IN(LINE)] get { return dir; } [IN(LINE)] set { dir = value; } }
        bool IRayN.IsVectorN { [IN(LINE)] get { return false; } }
        #endregion

        #region Constructors
        [IN(LINE)] public intray1(int src, int dir) { this.src = src; this.dir = dir; }
        [IN(LINE)] public intray1(ray1 ray) { src = (int)ray.src; dir = (int)ray.dir; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(intray1 a, intray1 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(intray1 a, intray1 b) { return !a.Equals(b); }

        [IN(LINE)] public static intray1 operator -(intray1 range, int v) { return new intray1(range.src - v, range.dir - v); }
        [IN(LINE)] public static intray1 operator +(intray1 range, int v) { return new intray1(range.src + v, range.dir + v); }
        [IN(LINE)] public static intray1 operator /(intray1 range, int v) { return new intray1(range.src / v, range.dir / v); }
        [IN(LINE)] public static intray1 operator *(intray1 range, int v) { return new intray1(range.src * v, range.dir * v); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.AsInt(src) ^ DM.AsInt(dir); }
        [IN(LINE)] public override bool Equals(object o) { return o is intray1 target && Equals(target); }
        [IN(LINE)] public bool Equals(intray1 a) { return src == a.src && dir == a.dir; }
        [IN(LINE)] public override string ToString() { return $"{nameof(intray1)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intray1)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public int src;
            public int dir;
            public DebuggerProxy(intray1 v)
            {
                src = v.src;
                dir = v.dir;
            }
        }
        #endregion
    }
}