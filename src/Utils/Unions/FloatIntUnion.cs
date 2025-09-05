using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public float floatValue;
        [FieldOffset(0)]
        public int intValue;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FloatIntUnion(float value) : this()
        {
            floatValue = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FloatIntUnion(float floatValue, int intValue)
        {
            this.floatValue = floatValue;
            this.intValue = intValue;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FloatIntUnion FromInt(int value) => new FloatIntUnion(default, value);
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FloatIntUnion(float v) => new FloatIntUnion(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator FloatIntUnion(int v) => FromInt(v);
        #endregion
    }
}