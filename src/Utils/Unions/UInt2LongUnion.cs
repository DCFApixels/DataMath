using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
    public struct UInt2ULongUnion
    {
        [FieldOffset(0)]
        public uint2 uint2Value;
        [FieldOffset(0)]
        public ulong ulongValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt2ULongUnion(uint2 value) : this()
        {
            uint2Value = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private UInt2ULongUnion(uint2 uint2Value, ulong ulongValue)
        {
            this.uint2Value = uint2Value;
            this.ulongValue = ulongValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt2ULongUnion Fromulong(ulong value) => new UInt2ULongUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt2ULongUnion(uint2 v) => new UInt2ULongUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt2ULongUnion(ulong v) => Fromulong(v);
        #endregion
    }
}