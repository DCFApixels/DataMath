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
    public unsafe partial struct line1 :
        IEquatable<line1>,
        IFormattable,
        IRange1Impl<float>
    {
        public float a;
        public float b;

        #region IRangeN
        public float src
        {
            [IN(LINE)]
            get { return a; }
            [IN(LINE)]
            set
            {
                var direction = b - a;
                a = value;
                b = value + direction;
            }
        }
        public float dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        float IRangeN<float, float>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        float IRangeN<float, float>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set
            {
                var currentMax = DM.Max(a, b);
                a = value;
                b = currentMax;
            }
        }
        public float max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set
            {
                var currentMin = DM.Min(a, b);
                a = currentMin;
                b = value;
            }
        }
        public float center
        {
            [IN(LINE)]
            get { return (a + b) * 0.5f; }
            [IN(LINE)]
            set
            {
                var halfSize = (b - a) * 0.5f;
                a = value - halfSize;
                b = value + halfSize;
            }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float); }
        #endregion

        #region Constructors
        [IN(LINE)] public line1(float a, float b) { this.a = a; this.b = b; }
        [IN(LINE)] public line1(ray1 a) { this.a = a.a; this.b = a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(line1 a, line1 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(line1 a, line1 b) { return !a.Equals(b); }

        [IN(LINE)] public static line1 operator -(line1 range, float v) { return new line1(range.src - v, range.dir - v); }
        [IN(LINE)] public static line1 operator +(line1 range, float v) { return new line1(range.src + v, range.dir + v); }
        [IN(LINE)] public static line1 operator /(line1 range, float v) { return new line1(range.src / v, range.dir / v); }
        [IN(LINE)] public static line1 operator *(line1 range, float v) { return new line1(range.src * v, range.dir * v); }

        [IN(LINE)] public static implicit operator ray1(line1 a) { return new ray1(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is ray1 target && Equals(target); }
        [IN(LINE)] public bool Equals(line1 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray1)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray1)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float a, b;
            public DebuggerProxy(ray1 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
