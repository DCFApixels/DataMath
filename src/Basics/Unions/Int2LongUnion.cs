using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
    public readonly struct Int2LongUnion
    {
        [FieldOffset(0)]
        public readonly int2 int2Value;
        [FieldOffset(0)]
        public readonly long longValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int2LongUnion(int2 value) : this()
        {
            int2Value = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Int2LongUnion(int2 int2Value, long longValue)
        {
            this.int2Value = int2Value;
            this.longValue = longValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int2LongUnion FromLong(long value) => new Int2LongUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Int2LongUnion(int2 v) => new Int2LongUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Int2LongUnion(long v) => FromLong(v);
        #endregion
    }
}