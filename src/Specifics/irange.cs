using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using static DCFApixels.DataMath.DM;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public struct irange :
        IEquatable<irange>,
        IFormattable,
        IRange<int>
    {
        #region Consts
        public static readonly irange one = new irange(0, 1);
        #endregion

        /// <summary>The start of this range</summary>
        public int start;
        /// <summary>The length of this range</summary>
        public int extent;

        #region Properties
        int IRange<int>.start { [IN(LINE)] get => start; [IN(LINE)] set => start = value; }
        int IRange<int>.extent { [IN(LINE)] get => extent; [IN(LINE)] set => extent = value; }

        public int AbsExtent { [IN(LINE)] get => DM.Abs(extent); }
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
        public int AbsMin => DM.Abs(Min);
        public int AbsMax => DM.Abs(Max);
        public bool IsNegative { [IN(LINE)] get => extent < 0; }
        public bool IsPositive { [IN(LINE)] get => extent >= 0; }
        public int Center { [IN(LINE)] get => start + extent / 2; }
        #endregion

        #region Constructors
        [IN(LINE)]
        public irange(int extent)
        {
            start = 0;
            this.extent = extent;
        }
        [IN(LINE)]
        public irange(int start, int extent)
        {
            this.start = start;
            this.extent = extent;
        }
        [IN(LINE)]
        public static irange MinMax(int min, int max) => new irange(min, max - min);
        #endregion

        #region operators
        [IN(LINE)] public static implicit operator irange((int, int) tuple) => new irange(tuple.Item1, tuple.Item2);
        [IN(LINE)] public static explicit operator irange(frange range) => new irange((int)range.start, (int)range.extent);

        [IN(LINE)] public static implicit operator irange(int a) => new irange(0, a);
        [IN(LINE)] public static implicit operator irange(int2 a) => new irange(a.x, a.y);
        [IN(LINE)] public static explicit operator irange(uint a) => new irange(0, (int)a);
        [IN(LINE)] public static explicit operator irange(uint2 a) => new irange((int)a.x, (int)a.y);
        [IN(LINE)] public static explicit operator irange(float a) => new irange(0, (int)a);
        [IN(LINE)] public static explicit operator irange(float2 a) => new irange((int)a.x, (int)a.y);
        [IN(LINE)] public static explicit operator irange(double a) => new irange(0, (int)a);
        [IN(LINE)] public static explicit operator irange(double2 a) => new irange((int)a.x, (int)a.y);

        [IN(LINE)] public static bool operator ==(irange a, irange b) => a.Equals(b);
        [IN(LINE)] public static bool operator !=(irange a, irange b) => !a.Equals(b);

        [IN(LINE)] public static irange operator -(irange range, int v) => new irange(range.start - v, range.extent - v);
        [IN(LINE)] public static irange operator +(irange range, int v) => new irange(range.start + v, range.extent + v);
        [IN(LINE)] public static irange operator /(irange range, int v) => new irange(range.start / v, range.extent / v);
        [IN(LINE)] public static irange operator *(irange range, int v) => new irange(range.start * v, range.extent * v);
        [IN(LINE)] public static irange operator -(irange range, float v) => new irange(Int1(range.start - v), Int1(range.extent - v));
        [IN(LINE)] public static irange operator +(irange range, float v) => new irange(Int1(range.start + v), Int1(range.extent + v));
        [IN(LINE)] public static irange operator /(irange range, float v) => new irange(Int1(range.start / v), Int1(range.extent / v));
        [IN(LINE)] public static irange operator *(irange range, float v) => new irange(Int1(range.start * v), Int1(range.extent * v));
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() => DM.AsInt(start) ^ DM.AsInt(extent);
        [IN(LINE)] public override bool Equals(object o) => o is irange target && Equals(target);
        [IN(LINE)] public bool Equals(irange a) => start == a.start && extent == a.extent;
        [IN(LINE)] public override string ToString() => $"{nameof(irange)}({start}, {extent})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(irange)}({start.ToString(format, formatProvider)}, {extent.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public int start, extent;
            public DebuggerProxy(irange v) { start = v.start; extent = v.extent; }
        }
        #endregion
    }
}
