using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
    public struct UInt2LongUnion
    {
        [FieldOffset(0)]
        public uint2 uint2Value;
        [FieldOffset(0)]
        public long longValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt2LongUnion(uint2 value) : this()
        {
            uint2Value = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private UInt2LongUnion(uint2 uint2Value, long longValue)
        {
            this.uint2Value = uint2Value;
            this.longValue = longValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt2LongUnion FromLong(long value) => new UInt2LongUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt2LongUnion(uint2 v) => new UInt2LongUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt2LongUnion(long v) => FromLong(v);
        #endregion
    }
}