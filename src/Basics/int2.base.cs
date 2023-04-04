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
    public partial struct int2 : 
        IEquatable<int2>, 
        IFormattable, 
        IVector2<int>, 
        IColor
    {
        #region Consts
        public const int LENGTH = 2;

        ///<summary>(0, 0)</summary>
        public static readonly int2 zero = new int2(0, 0);
        ///<summary>(1, 1)</summary>
        public static readonly int2 one = new int2(1, 1);

        ///<summary>(-1, 0)</summary>
        public static readonly int2 left = new int2(-1, 0);
        ///<summary>(1, 0)</summary>
        public static readonly int2 right = new int2(1, 0);
        ///<summary>(0, -1)</summary>
        public static readonly int2 down = new int2(0, -1);
        ///<summary>(0, 1)</summary>
        public static readonly int2 up = new int2(0, 1);
        #endregion

        public int x;
        public int y;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (int)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (int)value;
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
        int IVector1<int>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        int IVector2<int>.y
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

        public unsafe ref int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (int2* array = &this) { return ref ((int*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(float x, float y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(float v)
        {
            x = (int)v; y = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(float2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(double x, double y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(double v)
        {
            x = (int)v; y = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(double2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int x, int y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int2 v)
        {
            x = v.x; y = v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(uint x, uint y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(uint v)
        {
            x = (int)v; y = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(uint2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator *(int2 a, int2 b) => new int2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator *(int2 a, int b) => new int2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator *(int a, int2 b) => new int2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator +(int2 a, int2 b) => new int2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator +(int2 a, int b) => new int2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator +(int a, int2 b) => new int2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator -(int2 a, int2 b) => new int2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator -(int2 a, int b) => new int2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator -(int a, int2 b) => new int2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator /(int2 a, int2 b) => new int2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator /(int2 a, int b) => new int2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator /(int a, int2 b) => new int2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator %(int2 a, int2 b) => new int2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator %(int2 a, int b) => new int2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator %(int a, int2 b) => new int2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ++(int2 a) => new int2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator --(int2 a) => new int2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator -(int2 a) => new int2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static int2 operator +(int2 a) => new int2(+a.x, +a.y);
        #endregion

        #region Bit operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ~(int2 a) => new int2(~a.x, ~a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator <<(int2 a, int n) => new int2(a.x << n, a.y << n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator >>(int2 a, int n) => new int2(a.x >> n, a.y >> n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator |(int2 a, int2 b) => new int2(a.x | b.x, a.y | b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator |(int2 a, int b) => new int2(a.x | b, a.y | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator |(int a, int2 b) => new int2(a | b.x, a | b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator &(int2 a, int2 b) => new int2(a.x & b.x, a.y & b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator &(int2 a, int b) => new int2(a.x & b, a.y & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator &(int a, int2 b) => new int2(a & b.x, a & b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^(int2 a, int2 b) => new int2(a.x ^ b.x, a.y ^ b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^(int2 a, int b) => new int2(a.x ^ b, a.y ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^(int a, int2 b) => new int2(a ^ b.x, a ^ b.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int2 a, int2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int2 a, int b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int a, int2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int2 a, int2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int2 a, int b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int a, int2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(0, y);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, 0, y);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, 0, y);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is int2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"int2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly int2 _value;
            private sbyte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(int2 value) { _value = value; _pointer = -1; }
            public int Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < LENGTH;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() { }
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public int x;
            public int y;
            public DebuggerProxy(int2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}