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
    public partial struct float2 : 
        IEquatable<float2>, 
        IFormattable, 
        IVector2<float>, 
        IColor,
        IEnumerableVector<float, float2>
    {
        #region Consts
        public const int LENGTH = 2;

        ///<summary>(0, 0)</summary>
        public static readonly float2 zero = new float2(0f, 0f);
        ///<summary>(1, 1)</summary>
        public static readonly float2 one = new float2(1f, 1f);

        ///<summary>(-1, 0)</summary>
        public static readonly float2 left = new float2(-1f, 0f);
        ///<summary>(1, 0)</summary>
        public static readonly float2 right = new float2(1f, 0f);
        ///<summary>(0, -1)</summary>
        public static readonly float2 down = new float2(0f, -1f);
        ///<summary>(0, 1)</summary>
        public static readonly float2 up = new float2(0f, 1f);
        #endregion

        public float x;
        public float y;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (float)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (float)value;
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
        float IVector1<float>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector2<float>.y
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

        public unsafe ref float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (float2* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float x, float y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float2 v)
        {
            x = v.x; y = v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double x, double y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int x, int y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint x, uint y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float2 a, float2 b) => new float2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float2 a, float b) => new float2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float a, float2 b) => new float2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float2 a, float2 b) => new float2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float2 a, float b) => new float2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float a, float2 b) => new float2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a, float2 b) => new float2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a, float b) => new float2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float a, float2 b) => new float2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float2 a, float2 b) => new float2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float2 a, float b) => new float2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float a, float2 b) => new float2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float2 a, float2 b) => new float2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float2 a, float b) => new float2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float a, float2 b) => new float2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator ++(float2 a) => new float2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator --(float2 a) => new float2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a) => new float2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static float2 operator +(float2 a) => new float2(+a.x, +a.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2 a, float2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2 a, float b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float a, float2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2 a, float2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2 a, float b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float a, float2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(0f, y);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, 0f, y);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, 0f, y);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is float2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"float2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<float, float2> IEnumerableVector<float, float2>.GetEnumerator() => new VectorEnumerator<float, float2>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => new VectorEnumerator<float, float2>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<float, float2>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly float* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in float2 value)
            {
                fixed (float2* array = &value)
                {
                    _pointer = (float*)array;
                    _index = -1;
                }
            }
            public float Current => _pointer[_index];
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
            public float x;
            public float y;
            public DebuggerProxy(float2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}