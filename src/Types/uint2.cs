using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct uint2 : IEquatable<uint2>, IFormattable, IValue2<uint>
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

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint X 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Y 
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

        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(float v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(bool2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(int v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(int2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(uint v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(uint2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double2 v) => new uint2(v);
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
        public override int GetHashCode() => unchecked((int)math.hash(this));
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
            public bool MoveNext() => ++_pointer < _value.Length;

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

    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(uint2 v)
        {
            return csum(asuint(v) * uint2(0xFA3A3285u, 0xAD55999Du)) + 0xDCDD5341u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 one_minus(uint2 v) => 1u - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 abs(uint2 v)
        {
            return new uint2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(uint2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        
    }
}
