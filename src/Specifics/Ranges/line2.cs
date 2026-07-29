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
    /// <summary>Two-dimensional float line segment stored as two endpoints; preferred type for clamp, lerp, remap, and range-value APIs.</summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public unsafe partial struct line2 :
        IEquatable<line2>,
        IFormattable,
        IRange2Impl<float, float2>
    {
        public float2 a;
        public float2 b;

        #region IRangeN
        public float2 src
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
        public float2 dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        float2 IRangeN<float, float2>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        float2 IRangeN<float, float2>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float2 min
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
        public float2 max
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
        public float2 center
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
        void IRangeN.SetSrcRaw(object raw) { src = (float2)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float2)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float2); }
        #endregion

        #region Constructors
        [IN(LINE)] public line2(float2 a, float2 b) { this.a = a; this.b = b; }
        [IN(LINE)] public line2(ray2 a) { this.a = a.a; this.b = a.b; }
        #endregion

        #region operators
        [IN(LINE)] public static bool operator ==(line2 a, line2 b) { return a.Equals(b); }
        [IN(LINE)] public static bool operator !=(line2 a, line2 b) { return !a.Equals(b); }

        [IN(LINE)] public static line2 operator -(line2 range, float v) { return new line2(range.a - v, range.b - v); }
        [IN(LINE)] public static line2 operator +(line2 range, float v) { return new line2(range.a + v, range.b + v); }
        [IN(LINE)] public static line2 operator /(line2 range, float v) { return new line2(range.a / v, range.b / v); }
        [IN(LINE)] public static line2 operator *(line2 range, float v) { return new line2(range.a * v, range.b * v); }

        [IN(LINE)] public static implicit operator ray2(line2 a) { return new ray2(a); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        public override bool Equals(object o) { return o is line2 target && Equals(target); }
        [IN(LINE)] public bool Equals(line2 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(line2)}({a}, {b})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(line2)}({a.ToString(format, formatProvider)}, {b.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float2 a, b;
            public DebuggerProxy(line2 v) { a = v.a; b = v.b; }
        }
        #endregion
    }
}
