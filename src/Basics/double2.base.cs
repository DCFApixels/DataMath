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
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct double2 : 
        IEquatable<double2>, 
        IFormattable, 
        IVector2<double>, 
        IColor,
        IEnumerableVector<double, double2>
    {
        #region Consts
        public const int LENGTH = 2;

        ///<summary>(0, 0)</summary>
        public static readonly double2 zero = new double2(0d, 0d);
        ///<summary>(1, 1)</summary>
        public static readonly double2 one = new double2(1d, 1d);

        ///<summary>(-1, 0)</summary>
        public static readonly double2 left = new double2(-1d, 0d);
        ///<summary>(1, 0)</summary>
        public static readonly double2 right = new double2(1d, 0d);
        ///<summary>(0, -1)</summary>
        public static readonly double2 down = new double2(0d, -1d);
        ///<summary>(0, 1)</summary>
        public static readonly double2 up = new double2(0d, 1d);
        #endregion

        public double x;
        public double y;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (double)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (double)value;
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
        double IVector1<double>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector2<double>.y
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

        public unsafe ref double this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (double2* array = &this) { return ref ((double*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float x, float y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double x, double y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double2 v)
        {
            x = v.x; y = v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int x, int y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint x, uint y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double2 a, double2 b) => new double2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double2 a, double b) => new double2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double a, double2 b) => new double2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double2 a, double2 b) => new double2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double2 a, double b) => new double2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double a, double2 b) => new double2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a, double2 b) => new double2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a, double b) => new double2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double a, double2 b) => new double2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double2 a, double2 b) => new double2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double2 a, double b) => new double2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double a, double2 b) => new double2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double2 a, double2 b) => new double2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double2 a, double b) => new double2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double a, double2 b) => new double2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator ++(double2 a) => new double2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator --(double2 a) => new double2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a) => new double2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static double2 operator +(double2 a) => new double2(+a.x, +a.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double2 a, double2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double2 a, double b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double a, double2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double2 a, double2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double2 a, double b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double a, double2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(0d, y);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, 0d, y);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, 0d, y);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is double2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"double2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<double, double2> IEnumerableVector<double, double2>.GetEnumerator() => new VectorEnumerator<double, double2>(this);
        IEnumerator<double> IEnumerable<double>.GetEnumerator() => new VectorEnumerator<double, double2>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<double, double2>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly double* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in double2 value)
            {
                fixed (double2* array = &value)
                {
                    _pointer = (double*)array;
                    _index = -1;
                }
            }
            public double Current => _pointer[_index];
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
            public double x;
            public double y;
            public DebuggerProxy(double2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}