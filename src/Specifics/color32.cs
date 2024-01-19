using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

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
        public byte x { [IN(LINE)] get => r8; [IN(LINE)] set => r8 = value; }
        public byte y { [IN(LINE)] get => g8; [IN(LINE)] set => g8 = value; }
        public byte z { [IN(LINE)] get => b8; [IN(LINE)] set => b8 = value; }
        public byte w { [IN(LINE)] get => a8; [IN(LINE)] set => a8 = value; }
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe byte this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (color32* array = &this) { return ((byte*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (byte* array = &r8) { array[index] = value; }
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
