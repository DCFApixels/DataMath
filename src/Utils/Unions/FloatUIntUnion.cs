using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
    public struct FloatUIntUnion
    {
        [FieldOffset(0)]
        public float floatValue;
        [FieldOffset(0)]
        public uint uintValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FloatUIntUnion(float value) : this()
        {
            floatValue = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FloatUIntUnion(float floatValue, uint uintValue)
        {
            this.floatValue = floatValue;
            this.uintValue = uintValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FloatUIntUnion FromUInt(uint value) => new FloatUIntUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FloatUIntUnion(float v) => new FloatUIntUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FloatUIntUnion(uint v) => FromUInt(v);
        #endregion
    }
}