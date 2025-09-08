using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 4)]
    public ref struct ColorCodeUnion
    {
        [FieldOffset(3)]
        public byte r8;
        [FieldOffset(2)]
        public byte g8;
        [FieldOffset(1)]
        public byte b8;
        [FieldOffset(0)]
        public byte a8;

        [FieldOffset(0)]
        public uint code;

        #region Properrties
        public float r
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => r8 / 255f;
        }
        public float g
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => g8 / 255f;
        }
        public float b
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => b8 / 255f;
        }
        public float a
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => a8 / 255f;
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ColorCodeUnion(uint code) : this()
        {
            this.code = code;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ColorCodeUnion(int code) : this()
        {
            this.code = unchecked((uint)code);
        }
        #endregion

        #region operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ColorCodeUnion(uint code) => new ColorCodeUnion(code);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ColorCodeUnion(int code) => new ColorCodeUnion(code);
        #endregion
    }
}