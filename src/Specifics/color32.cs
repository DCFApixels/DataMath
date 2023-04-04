using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public partial struct color32 : IColor32, IVector4<byte>
    {
        public const int LENGTH = 4;
        [MarshalAs(UnmanagedType.I1)]
        public byte r8;
        [MarshalAs(UnmanagedType.I1)]
        public byte g8;
        [MarshalAs(UnmanagedType.I1)]
        public byte b8;
        [MarshalAs(UnmanagedType.I1)]
        public byte a8;

        #region Constructors
        public color32(byte r, byte g, byte b)
        {
            r8 = r; g8 = g;
            b8 = b; a8 = 1;
        }
        public color32(byte r, byte g, byte b, byte a)
        {
            r8 = r; g8 = g;
            b8 = b; a8 = a;
        }
        /// <summary>accepting color code constructor</summary>
        public color32(ColorCodeUnion colorcode)
        {
            r8 = colorcode.r8;
            g8 = colorcode.g8;
            b8 = colorcode.b8;
            a8 = colorcode.a8;
        }
        #endregion

        #region IColor32
        byte IColor32.r8 { get => r8; set => r8 = value; }
        byte IColor32.g8 { get => g8; set => g8 = value; }
        byte IColor32.b8 { get => b8; set => b8 = value; }
        byte IColor32.a8 { get => a8; set => a8 = value; }
        #endregion

        #region IValueN
        public byte w { get => r8; set => r8 = value; }
        public byte z { get => g8; set => g8 = value; }
        public byte y { get => b8; set => b8 = value; }
        public byte x { get => a8; set => a8 = value; }

        public int length => LENGTH;
        public unsafe ref byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (color32* array = &this) { return ref ((byte*)array)[index]; }
            }
        }
        #endregion

        public static implicit operator color32(int colorcode) => new color32(colorcode);
        public static implicit operator color32(uint colorcode) => new color32(colorcode);

        #region Utils
        internal class DebuggerProxy
        {
            public byte r8;
            public byte g8;
            public byte b8;
            public byte a8;
            public DebuggerProxy(color32 v)
            {
                r8 = v.r8;
                g8 = v.g8;
                b8 = v.b8;
                a8 = v.a8;
            }
        }
        #endregion
    }
}
