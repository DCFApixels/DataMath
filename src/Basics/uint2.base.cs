using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct uint2 : 
        IEquatable<uint2>, 
        IFormattable, 
        IVector2<uint>, 
        IColor,
        IEnumerableVector<uint, uint2>
    {
        #region Consts
        public const int LENGTH = 2;

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

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector1<uint>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector2<uint>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LENGTH;
        }

        public unsafe ref uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
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
         public uint2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, 0u);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(0u, y);
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
         public uint3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, 0u);
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
         public uint3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, 0u);
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
         public uint3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, 0u);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, 0u, y);
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
         public uint4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, 0u);
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
         public uint4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, 0u);
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
         public uint4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, 0u);
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
         public uint4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, 0u);
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
         public uint4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, 0u);
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
         public uint4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, 0u);
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
         public uint4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, 0u);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, 0u, y);
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
        VectorEnumerator<uint, uint2> IEnumerableVector<uint, uint2>.GetEnumerator() => new VectorEnumerator<uint, uint2>(this);
        IEnumerator<uint> IEnumerable<uint>.GetEnumerator() => new VectorEnumerator<uint, uint2>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<uint, uint2>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly uint* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in uint2 value)
            {
                fixed (uint2* array = &value)
                {
                    _pointer = (uint*)array;
                    _index = -1;
                }
            }
            public uint Current => _pointer[_index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_index < LENGTH;
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