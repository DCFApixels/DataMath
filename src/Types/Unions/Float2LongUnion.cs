using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
    public readonly struct Float2LongUnion
    {
        [FieldOffset(0)]
        public readonly float2 float2Value;
        [FieldOffset(0)]
        public readonly long longValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Float2LongUnion(float2 value) : this()
        {
            float2Value = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Float2LongUnion(float2 float2Value, long longValue)
        {
            this.float2Value = float2Value;
            this.longValue = longValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Float2LongUnion FromLong(long value) => new Float2LongUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float2LongUnion(float2 v) => new Float2LongUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float2LongUnion(long v) => FromLong(v);
        #endregion
    }
}