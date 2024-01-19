using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public struct floatrange :
        IEquatable<floatrange>,
        IFormattable,
        IRange<float>
    {
        #region Consts
        public static readonly floatrange one = new floatrange(0f, 1f);
        #endregion

        /// <summary>The start of this range</summary>
        public float start;
        /// <summary>The length of this range</summary>
        public float extent;

        #region Properties
        float IRange<float>.start { [IN(LINE)] get => start; [IN(LINE)] set => start = value; }
        float IRange<float>.extent { [IN(LINE)] get => extent; [IN(LINE)] set => extent = value; }

        public float AbsExtent { [IN(LINE)] get => math.abs(extent); }
        public float Min
        {
            [IN(LINE)]
            get => start;
            [IN(LINE)]
            set
            {
                extent -= value - start;
                start = value;
            }
        }
        public float Max
        {
            [IN(LINE)]
            get => start + extent;
            [IN(LINE)]
            set
            {
                float a = Max - value;
                extent -= a;
            }
        }
        public float AbsMin => math.abs(Min);
        public float AbsMax => math.abs(Max);
        public bool IsNegative { [IN(LINE)] get => extent < 0; }
        public bool IsPositive { [IN(LINE)] get => extent >= 0; }
        public float Center { [IN(LINE)] get => start + extent / 2f; }
        #endregion

        #region Constructors
        [IN(LINE)]
        public floatrange(float extent)
        {
            start = 0;
            this.extent = extent;
        }
        [IN(LINE)]
        public floatrange(float start, float extent)
        {
            this.start = start;
            this.extent = extent;
        }
        [IN(LINE)]
        public static floatrange MinMax(float min, float max) => new floatrange(min, max - min);
        #endregion

        #region operators
        [IN(LINE)] public static implicit operator floatrange((float, float) tuple) => new floatrange(tuple.Item1, tuple.Item2);
        [IN(LINE)] public static implicit operator floatrange(intrange range) => new floatrange(range.start, range.extent);

        [IN(LINE)] public static implicit operator floatrange(int a) => new floatrange(0, a);
        [IN(LINE)] public static implicit operator floatrange(int2 a) => new floatrange(a.x, a.y);
        [IN(LINE)] public static implicit operator floatrange(uint a) => new floatrange(0, a);
        [IN(LINE)] public static implicit operator floatrange(uint2 a) => new floatrange(a.x, a.y);
        [IN(LINE)] public static implicit operator floatrange(float a) => new floatrange(0f, a);
        [IN(LINE)] public static implicit operator floatrange(float2 a) => new floatrange(a.x, a.y);
        [IN(LINE)] public static explicit operator floatrange(double a) => new floatrange(0, (float)a);
        [IN(LINE)] public static explicit operator floatrange(double2 a) => new floatrange((float)a.x, (float)a.y);

        [IN(LINE)] public static bool operator ==(floatrange a, floatrange b) => a.Equals(b);
        [IN(LINE)] public static bool operator !=(floatrange a, floatrange b) => !a.Equals(b);

        [IN(LINE)] public static floatrange operator -(floatrange range, float v) => new floatrange(range.start - v, range.extent - v);
        [IN(LINE)] public static floatrange operator +(floatrange range, float v) => new floatrange(range.start + v, range.extent + v);
        [IN(LINE)] public static floatrange operator /(floatrange range, float v) => new floatrange(range.start / v, range.extent / v);
        [IN(LINE)] public static floatrange operator *(floatrange range, float v) => new floatrange(range.start * v, range.extent * v);
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() => math.asint(start) ^ math.asint(extent);
        [IN(LINE)] public override bool Equals(object o) => o is floatrange target && Equals(target);
        [IN(LINE)] public bool Equals(floatrange a) => start == a.start && extent == a.extent;
        [IN(LINE)] public override string ToString() => $"{nameof(floatrange)}({start}, {extent})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(floatrange)}({start.ToString(format, formatProvider)}, {extent.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float start, extent;
            public DebuggerProxy(floatrange v) { start = v.start; extent = v.extent; }
        }
        #endregion
    }
}
