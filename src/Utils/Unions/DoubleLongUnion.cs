using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
    public struct DoubleLongUnion
    {
        [FieldOffset(0)]
        public double doubleValue;
        [FieldOffset(0)]
        public long longValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DoubleLongUnion(double value) : this()
        {
            doubleValue = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private DoubleLongUnion(double doubleValue, long longValue)
        {
            this.doubleValue = doubleValue;
            this.longValue = longValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DoubleLongUnion FromLong(long value) => new DoubleLongUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DoubleLongUnion(double v) => new DoubleLongUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DoubleLongUnion(long v) => FromLong(v);
        #endregion
    }
}
