using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct uint2 : 
        IEquatable<uint2>, 
        IFormattable, 
        IValue2<uint>, 
        IColor
    {
        #region Consts
        public const int length = 2;

        ///<summary>(0, 0)</summary>
        public static readonly uint2 zero = new uint2(0u, 0u);
        ///<summary>(1, 1)</summary>
        public static readonly uint2 one = new uint2(1u, 1u);

        ///<summary>(-1, 0)</summary>
        public static readonly uint2 left = new uint2(-1u, 0u);
        ///<summary>(1, 0)</summary>
        public static readonly uint2 right = new uint2(1u, 0u);
        ///<summary>(0, -1)</summary>
        public static readonly uint2 down = new uint2(0u, -1u);
        ///<summary>(0, 1)</summary>
        public static readonly uint2 up = new uint2(0u, 1u);
        #endregion

        public uint x;
        public uint y;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (uint)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (uint)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        public float a 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        #endregion

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IValue1<uint>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IValue2<uint>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => length;
        }

        public unsafe ref uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (uint2* array = &this) { return ref ((uint*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(float x, float y)
        {
            this.x = (uint)x; this.y = (uint)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(float v)
        {
            x = (uint)v; y = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(float2 v)
        {
            x = (uint)v.x; y = (uint)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(double x, double y)
        {
            this.x = (uint)x; this.y = (uint)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(double v)
        {
            x = (uint)v; y = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(double2 v)
        {
            x = (uint)v.x; y = (uint)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(int x, int y)
        {
            this.x = (uint)x; this.y = (uint)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(int v)
        {
            x = (uint)v; y = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(int2 v)
        {
            x = (uint)v.x; y = (uint)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint x, uint y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint2 v)
        {
            x = v.x; y = v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator *(uint2 a, uint2 b) => new uint2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator *(uint2 a, uint b) => new uint2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator *(uint a, uint2 b) => new uint2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator +(uint2 a, uint2 b) => new uint2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator +(uint2 a, uint b) => new uint2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator +(uint a, uint2 b) => new uint2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator -(uint2 a, uint2 b) => new uint2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator -(uint2 a, uint b) => new uint2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator -(uint a, uint2 b) => new uint2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator /(uint2 a, uint2 b) => new uint2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator /(uint2 a, uint b) => new uint2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator /(uint a, uint2 b) => new uint2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator %(uint2 a, uint2 b) => new uint2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator %(uint2 a, uint b) => new uint2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator %(uint a, uint2 b) => new uint2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ++(uint2 a) => new uint2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator --(uint2 a) => new uint2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator -(uint2 a) => new uint2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static uint2 operator +(uint2 a) => new uint2(+a.x, +a.y);
        #endregion

        #region Bit operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ~(uint2 a) => new uint2(~a.x, ~a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator <<(uint2 a, int n) => new uint2(a.x << n, a.y << n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator >>(uint2 a, int n) => new uint2(a.x >> n, a.y >> n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator |(uint2 a, uint2 b) => new uint2(a.x | b.x, a.y | b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator |(uint2 a, uint b) => new uint2(a.x | b, a.y | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator |(uint a, uint2 b) => new uint2(a | b.x, a | b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator &(uint2 a, uint2 b) => new uint2(a.x & b.x, a.y & b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator &(uint2 a, uint b) => new uint2(a.x & b, a.y & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator &(uint a, uint2 b) => new uint2(a & b.x, a & b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^(uint2 a, uint2 b) => new uint2(a.x ^ b.x, a.y ^ b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^(uint2 a, uint b) => new uint2(a.x ^ b, a.y ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^(uint a, uint2 b) => new uint2(a ^ b.x, a ^ b.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint2 a, uint2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint2 a, uint b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint a, uint2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint2 a, uint2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint2 a, uint b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint a, uint2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, y);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, y);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, y);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is uint2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"uint2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly uint2 _value;
            private byte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(uint2 value) { _value = value; _pointer = 0; }
            public uint Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < length;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() { }
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public uint x;
            public uint y;
            public DebuggerProxy(uint2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}