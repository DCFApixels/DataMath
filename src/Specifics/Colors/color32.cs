using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [Serializable]
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [StructLayout(LayoutKind.Sequential, Pack = sizeof(byte), Size = 4 * Count)]
    public partial struct color32 :
        IEquatable<color32>,
        //IFormattable,
        IVector4<byte>,
        IColor32,
        IEnumerableVector<byte, color32>
    {
        #region Consts
        public const int Count = 4;

        /// <summary> Red color in RGB (255, 0, 0) </summary>
        public const uint Red = 0xFF0000FF;
        /// <summary> Green color in RGB (0, 255, 0) </summary>
        public const uint Green = 0x00FF00FF;
        /// <summary> Blue color in RGB (0, 0, 255) </summary>
        public const uint Blue = 0x0000FFFF;
        /// <summary> Transparent color in RGBA (0, 0, 0, 0) </summary>
        public const uint Clean = 0x00000000;

        /// <summary> White color in RGB (255, 255, 255) </summary>
        public const uint White = 0xFFFFFFFF;
        /// <summary> Gray color in RGB (127, 127, 127) </summary>
        public const uint Gray = 0x7F7F7FFF;
        /// <summary> Grey color in RGB (127, 127, 127) </summary>
        public const uint Grey = Gray;
        /// <summary> Black color in RGB (0, 0, 0) </summary>
        public const uint Black = 0x000000FF;

        /// <summary> Yellow color in RGB (255, 255, 0) </summary>
        public const uint Yellow = 0xFFFF00FF;
        /// <summary> Orange color in RGB (255, 127, 0) </summary>
        public const uint Orange = 0xFF7F00FF;
        /// <summary> Cyan color in RGB (0, 255, 255) </summary>
        public const uint Cyan = 0x00FFFFFF;
        /// <summary> Magenta color in RGB (255, 0, 255) </summary>
        public const uint Magenta = 0xFF00FFFF;
        #endregion

        public byte r8;
        public byte g8;
        public byte b8;
        public byte a8;

        #region Properties
        public byte x { [IN(LINE)] get => r8; [IN(LINE)] set => r8 = value; }
        public byte y { [IN(LINE)] get => g8; [IN(LINE)] set => g8 = value; }
        public byte z { [IN(LINE)] get => b8; [IN(LINE)] set => b8 = value; }
        public byte w { [IN(LINE)] get => a8; [IN(LINE)] set => a8 = value; }
        byte IColor32.r8 { [IN(LINE)] get => r8; [IN(LINE)] set => r8 = value; }
        byte IColor32.g8 { [IN(LINE)] get => g8; [IN(LINE)] set => g8 = value; }
        byte IColor32.b8 { [IN(LINE)] get => b8; [IN(LINE)] set => b8 = value; }
        byte IColor32.a8 { [IN(LINE)] get => a8; [IN(LINE)] set => a8 = value; }
        public int count { [IN(LINE)] get => Count; }

        public unsafe byte this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (color32* array = &this) { return ((byte*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (byte* array = &r8) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public color32(byte r, byte g, byte b)
        {
            r8 = r; g8 = g;
            b8 = b; a8 = 1;
        }
        [IN(LINE)]
        public color32(byte r, byte g, byte b, byte a)
        {
            r8 = r; g8 = g;
            b8 = b; a8 = a;
        }
        [IN(LINE)] public color32((byte r, byte g, byte b) v) { r8 = v.r; g8 = v.g; b8 = v.b; a8 = 1; }
        [IN(LINE)] public color32((byte r, byte g, byte b, byte a) v) { r8 = v.r; g8 = v.g; b8 = v.b; a8 = v.a; }
        [IN(LINE)]
        public color32(color color)
        {
            byte To(float a) { return (byte)(a * byte.MaxValue); }
            r8 = To(color.r); g8 = To(color.g);
            b8 = To(color.b); a8 = To(color.a);
        }
        [IN(LINE)]
        public color32(int colorCode)
        {
            ColorCodeUnion u = colorCode;
            r8 = u.r8; g8 = u.g8;
            b8 = u.b8; a8 = u.a8;
        }
        [IN(LINE)]
        public color32(uint colorCode)
        {
            ColorCodeUnion u = colorCode;
            r8 = u.r8; g8 = u.g8;
            b8 = u.b8; a8 = u.a8;
        }
        #endregion

        #region Converts
        public static implicit operator color32(int colorcode) { return new color32(colorcode); }
        public static implicit operator color32(uint colorcode) { return new color32(colorcode); }
        public static explicit operator color32(color a) { return new color32(a); }
        #endregion

        #region Other 
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is color32 target && Equals(target); }
        [IN(LINE)] public bool Equals(color32 a) { return r8 == a.r8 && g8 == a.g8 && b8 == a.b8 && a8 == a.a8; }
        public override string ToString() { return $"{nameof(color32)}({r8}, {g8}, {b8}, {a8})"; }

        internal class DebuggerProxy
        {
            public byte r8, g8, b8, a8;
            public DebuggerProxy(color32 v) { r8 = v.r8; g8 = v.g8; b8 = v.b8; a8 = v.a8; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<byte, color32> GetEnumerator() { return new VectorEnumerator<byte, color32>(this); }
        VectorEnumerator<byte, color32> IEnumerableVector<byte, color32>.GetEnumerator() { return new VectorEnumerator<byte, color32>(this); }
        IEnumerator<byte> IEnumerable<byte>.GetEnumerator() { return new VectorEnumerator<byte, color32>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<byte, color32>(this); }
        #endregion
    }
}
