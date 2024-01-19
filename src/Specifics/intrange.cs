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
    public struct intrange :
        IEquatable<intrange>,
        IFormattable,
        IRange<int>
    {
        #region Consts
        public static readonly intrange one = new intrange(0, 1);
        #endregion

        /// <summary>The start of this range</summary>
        public int start;
        /// <summary>The length of this range</summary>
        public int extent;

        #region Properties
        int IRange<int>.start { [IN(LINE)] get => start; [IN(LINE)] set => start = value; }
        int IRange<int>.extent { [IN(LINE)] get => extent; [IN(LINE)] set => extent = value; }

        public int AbsExtent { [IN(LINE)] get => math.abs(extent); }
        public int Min
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
        public int Max
        {
            [IN(LINE)]
            get => start + extent;
            [IN(LINE)]
            set
            {
                int a = Max - value;
                extent -= a;
            }
        }
        public int AbsMin => math.abs(Min);
        public int AbsMax => math.abs(Max);
        public bool IsNegative { [IN(LINE)] get => extent < 0; }
        public bool IsPositive { [IN(LINE)] get => extent >= 0; }
        public int Center { [IN(LINE)] get => start + extent / 2; }
        #endregion

        #region Constructors
        [IN(LINE)]
        public intrange(int extent)
        {
            start = 0;
            this.extent = extent;
        }
        [IN(LINE)]
        public intrange(int start, int extent)
        {
            this.start = start;
            this.extent = extent;
        }
        [IN(LINE)]
        public static intrange MinMax(int min, int max) => new intrange(min, max - min);
        #endregion

        #region operators
        [IN(LINE)] public static implicit operator intrange((int, int) tuple) => new intrange(tuple.Item1, tuple.Item2);
        [IN(LINE)] public static explicit operator intrange(floatrange range) => new intrange((int)range.start, (int)range.extent);

        [IN(LINE)] public static implicit operator intrange(int a) => new intrange(0, a);
        [IN(LINE)] public static implicit operator intrange(int2 a) => new intrange(a.x, a.y);
        [IN(LINE)] public static explicit operator intrange(uint a) => new intrange(0, (int)a);
        [IN(LINE)] public static explicit operator intrange(uint2 a) => new intrange((int)a.x, (int)a.y);
        [IN(LINE)] public static explicit operator intrange(float a) => new intrange(0, (int)a);
        [IN(LINE)] public static explicit operator intrange(float2 a) => new intrange((int)a.x, (int)a.y);
        [IN(LINE)] public static explicit operator intrange(double a) => new intrange(0, (int)a);
        [IN(LINE)] public static explicit operator intrange(double2 a) => new intrange((int)a.x, (int)a.y);

        [IN(LINE)] public static bool operator ==(intrange a, intrange b) => a.Equals(b);
        [IN(LINE)] public static bool operator !=(intrange a, intrange b) => !a.Equals(b);

        [IN(LINE)] public static intrange operator -(intrange range, int v) => new intrange(range.start - v, range.extent - v);
        [IN(LINE)] public static intrange operator +(intrange range, int v) => new intrange(range.start + v, range.extent + v);
        [IN(LINE)] public static intrange operator /(intrange range, int v) => new intrange(range.start / v, range.extent / v);
        [IN(LINE)] public static intrange operator *(intrange range, int v) => new intrange(range.start * v, range.extent * v);
        [IN(LINE)] public static intrange operator -(intrange range, float v) => new intrange(math.int1(range.start - v), math.int1(range.extent - v));
        [IN(LINE)] public static intrange operator +(intrange range, float v) => new intrange(math.int1(range.start + v), math.int1(range.extent + v));
        [IN(LINE)] public static intrange operator /(intrange range, float v) => new intrange(math.int1(range.start / v), math.int1(range.extent / v));
        [IN(LINE)] public static intrange operator *(intrange range, float v) => new intrange(math.int1(range.start * v), math.int1(range.extent * v));
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() => math.asint(start) ^ math.asint(extent);
        [IN(LINE)] public override bool Equals(object o) => o is intrange target && Equals(target);
        [IN(LINE)] public bool Equals(intrange a) => start == a.start && extent == a.extent;
        [IN(LINE)] public override string ToString() => $"{nameof(intrange)}({start}, {extent})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(intrange)}({start.ToString(format, formatProvider)}, {extent.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public int start, extent;
            public DebuggerProxy(intrange v) { start = v.start; extent = v.extent; }
        }
        #endregion
    }
}
