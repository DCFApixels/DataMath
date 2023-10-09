using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct int2 : 
        IEquatable<int2>, 
        IFormattable, 
        IVector2<int>, 
        IColor,
        IEnumerableVector<int, int2>
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
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (int)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (int)value; }
        public float b { [IN(LINE)] get => 0f; [IN(LINE)] set {} }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set {} }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        int IVector1<int>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        int IVector2<int>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe int this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (int2* array = &this) { return ((int*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (int* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public int2(float x, float y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [IN(LINE)]
        public int2(float v)
        {
            x = (int)v; y = (int)v;
        }
        [IN(LINE)]
        public int2(float2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }
        [IN(LINE)]
        public int2(double x, double y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [IN(LINE)]
        public int2(double v)
        {
            x = (int)v; y = (int)v;
        }
        [IN(LINE)]
        public int2(double2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }
        [IN(LINE)]
        public int2(int x, int y)
        {
            this.x = x; this.y = y;
        }
        [IN(LINE)]
        public int2(int v)
        {
            x = v; y = v;
        }
        [IN(LINE)]
        public int2(int2 v)
        {
            x = v.x; y = v.y;
        }
        [IN(LINE)]
        public int2(uint x, uint y)
        {
            this.x = (int)x; this.y = (int)y;
        }
        [IN(LINE)]
        public int2(uint v)
        {
            x = (int)v; y = (int)v;
        }
        [IN(LINE)]
        public int2(uint2 v)
        {
            x = (int)v.x; y = (int)v.y;
        }

        #endregion

        #region Arithmetic operators
        [IN(LINE)]
        public static int2 operator *(int2 a, int2 b) => new int2(a.x * b.x, a.y * b.y);
        [IN(LINE)]
        public static int2 operator *(int2 a, int b) => new int2(a.x * b, a.y * b);
        [IN(LINE)]
        public static int2 operator *(int a, int2 b) => new int2(a * b.x, a * b.y);

        [IN(LINE)]
        public static int2 operator +(int2 a, int2 b) => new int2(a.x + b.x, a.y + b.y);
        [IN(LINE)]
        public static int2 operator +(int2 a, int b) => new int2(a.x + b, a.y + b);
        [IN(LINE)]
        public static int2 operator +(int a, int2 b) => new int2(a + b.x, a + b.y);

        [IN(LINE)]
        public static int2 operator -(int2 a, int2 b) => new int2(a.x - b.x, a.y - b.y);
        [IN(LINE)]
        public static int2 operator -(int2 a, int b) => new int2(a.x - b, a.y - b);
        [IN(LINE)]
        public static int2 operator -(int a, int2 b) => new int2(a - b.x, a - b.y);

        [IN(LINE)]
        public static int2 operator /(int2 a, int2 b) => new int2(a.x / b.x, a.y / b.y);
        [IN(LINE)]
        public static int2 operator /(int2 a, int b) => new int2(a.x / b, a.y / b);
        [IN(LINE)]
        public static int2 operator /(int a, int2 b) => new int2(a / b.x, a / b.y);

        [IN(LINE)]
        public static int2 operator %(int2 a, int2 b) => new int2(a.x % b.x, a.y % b.y);
        [IN(LINE)]
        public static int2 operator %(int2 a, int b) => new int2(a.x % b, a.y % b);
        [IN(LINE)]
        public static int2 operator %(int a, int2 b) => new int2(a % b.x, a % b.y);

        [IN(LINE)]
        public static int2 operator ++(int2 a) => new int2(++a.x, ++a.y);
        [IN(LINE)]
        public static int2 operator --(int2 a) => new int2(--a.x, --a.y);
        [IN(LINE)]
        public static int2 operator -(int2 a) => new int2(-a.x, -a.y);
        [IN(LINE)]                                                               
        public static int2 operator +(int2 a) => new int2(+a.x, +a.y);
        #endregion

        #region Bit operators
        [IN(LINE)]
        public static int2 operator ~(int2 a) => new int2(~a.x, ~a.y);
        [IN(LINE)]
        public static int2 operator <<(int2 a, int n) => new int2(a.x << n, a.y << n);
        [IN(LINE)]
        public static int2 operator >>(int2 a, int n) => new int2(a.x >> n, a.y >> n);

        [IN(LINE)]
        public static int2 operator |(int2 a, int2 b) => new int2(a.x | b.x, a.y | b.y);
        [IN(LINE)]
        public static int2 operator |(int2 a, int b) => new int2(a.x | b, a.y | b);
        [IN(LINE)]
        public static int2 operator |(int a, int2 b) => new int2(a | b.x, a | b.y);

        [IN(LINE)]
        public static int2 operator &(int2 a, int2 b) => new int2(a.x & b.x, a.y & b.y);
        [IN(LINE)]
        public static int2 operator &(int2 a, int b) => new int2(a.x & b, a.y & b);
        [IN(LINE)]
        public static int2 operator &(int a, int2 b) => new int2(a & b.x, a & b.y);

        [IN(LINE)]
        public static int2 operator ^(int2 a, int2 b) => new int2(a.x ^ b.x, a.y ^ b.y);
        [IN(LINE)]
        public static int2 operator ^(int2 a, int b) => new int2(a.x ^ b, a.y ^ b);
        [IN(LINE)]
        public static int2 operator ^(int a, int2 b) => new int2(a ^ b.x, a ^ b.y);
        #endregion

        #region Boolean operators
        [IN(LINE)]
        public static bool operator ==(int2 a, int2 b) => a.x == b.x && a.y == b.y;
        [IN(LINE)]
        public static bool operator ==(int2 a, int b) => a.x == b && a.y == b;
        [IN(LINE)]
        public static bool operator ==(int a, int2 b) => a == b.x && a == b.y;

        [IN(LINE)]
        public static bool operator !=(int2 a, int2 b) => a.x != b.x || a.y != b.y;
        [IN(LINE)]
        public static bool operator !=(int2 a, int b) => a.x != b || a.y != b;
        [IN(LINE)]
        public static bool operator !=(int a, int2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xx { [IN(LINE)] get => new int2(x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xy { [IN(LINE)] get => new int2(x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 x_ { [IN(LINE)] get => new int2(x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yx { [IN(LINE)] get => new int2(y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yy { [IN(LINE)] get => new int2(y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 y_ { [IN(LINE)] get => new int2(y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _x { [IN(LINE)] get => new int2(0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _y { [IN(LINE)] get => new int2(0, y); }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxx { [IN(LINE)] get => new int3(x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxy { [IN(LINE)] get => new int3(x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xx_ { [IN(LINE)] get => new int3(x, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyx { [IN(LINE)] get => new int3(x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyy { [IN(LINE)] get => new int3(x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xy_ { [IN(LINE)] get => new int3(x, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_x { [IN(LINE)] get => new int3(x, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_y { [IN(LINE)] get => new int3(x, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x__ { [IN(LINE)] get => new int3(x, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxx { [IN(LINE)] get => new int3(y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxy { [IN(LINE)] get => new int3(y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yx_ { [IN(LINE)] get => new int3(y, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyx { [IN(LINE)] get => new int3(y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyy { [IN(LINE)] get => new int3(y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yy_ { [IN(LINE)] get => new int3(y, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_x { [IN(LINE)] get => new int3(y, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_y { [IN(LINE)] get => new int3(y, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y__ { [IN(LINE)] get => new int3(y, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xx { [IN(LINE)] get => new int3(0, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xy { [IN(LINE)] get => new int3(0, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _x_ { [IN(LINE)] get => new int3(0, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yx { [IN(LINE)] get => new int3(0, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yy { [IN(LINE)] get => new int3(0, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _y_ { [IN(LINE)] get => new int3(0, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __x { [IN(LINE)] get => new int3(0, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __y { [IN(LINE)] get => new int3(0, 0, y); }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxx { [IN(LINE)] get => new int4(x, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxy { [IN(LINE)] get => new int4(x, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxx_ { [IN(LINE)] get => new int4(x, x, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyx { [IN(LINE)] get => new int4(x, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyy { [IN(LINE)] get => new int4(x, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxy_ { [IN(LINE)] get => new int4(x, x, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_x { [IN(LINE)] get => new int4(x, x, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_y { [IN(LINE)] get => new int4(x, x, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx__ { [IN(LINE)] get => new int4(x, x, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxx { [IN(LINE)] get => new int4(x, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxy { [IN(LINE)] get => new int4(x, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyx_ { [IN(LINE)] get => new int4(x, y, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyx { [IN(LINE)] get => new int4(x, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyy { [IN(LINE)] get => new int4(x, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyy_ { [IN(LINE)] get => new int4(x, y, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_x { [IN(LINE)] get => new int4(x, y, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_y { [IN(LINE)] get => new int4(x, y, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy__ { [IN(LINE)] get => new int4(x, y, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xx { [IN(LINE)] get => new int4(x, 0, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xy { [IN(LINE)] get => new int4(x, 0, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_x_ { [IN(LINE)] get => new int4(x, 0, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yx { [IN(LINE)] get => new int4(x, 0, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yy { [IN(LINE)] get => new int4(x, 0, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_y_ { [IN(LINE)] get => new int4(x, 0, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__x { [IN(LINE)] get => new int4(x, 0, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__y { [IN(LINE)] get => new int4(x, 0, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x___ { [IN(LINE)] get => new int4(x, 0, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxx { [IN(LINE)] get => new int4(y, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxy { [IN(LINE)] get => new int4(y, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxx_ { [IN(LINE)] get => new int4(y, x, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyx { [IN(LINE)] get => new int4(y, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyy { [IN(LINE)] get => new int4(y, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxy_ { [IN(LINE)] get => new int4(y, x, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_x { [IN(LINE)] get => new int4(y, x, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_y { [IN(LINE)] get => new int4(y, x, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx__ { [IN(LINE)] get => new int4(y, x, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxx { [IN(LINE)] get => new int4(y, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxy { [IN(LINE)] get => new int4(y, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyx_ { [IN(LINE)] get => new int4(y, y, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyx { [IN(LINE)] get => new int4(y, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyy { [IN(LINE)] get => new int4(y, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyy_ { [IN(LINE)] get => new int4(y, y, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_x { [IN(LINE)] get => new int4(y, y, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_y { [IN(LINE)] get => new int4(y, y, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy__ { [IN(LINE)] get => new int4(y, y, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xx { [IN(LINE)] get => new int4(y, 0, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xy { [IN(LINE)] get => new int4(y, 0, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_x_ { [IN(LINE)] get => new int4(y, 0, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yx { [IN(LINE)] get => new int4(y, 0, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yy { [IN(LINE)] get => new int4(y, 0, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_y_ { [IN(LINE)] get => new int4(y, 0, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__x { [IN(LINE)] get => new int4(y, 0, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__y { [IN(LINE)] get => new int4(y, 0, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y___ { [IN(LINE)] get => new int4(y, 0, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxx { [IN(LINE)] get => new int4(0, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxy { [IN(LINE)] get => new int4(0, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xx_ { [IN(LINE)] get => new int4(0, x, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyx { [IN(LINE)] get => new int4(0, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyy { [IN(LINE)] get => new int4(0, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xy_ { [IN(LINE)] get => new int4(0, x, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_x { [IN(LINE)] get => new int4(0, x, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_y { [IN(LINE)] get => new int4(0, x, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x__ { [IN(LINE)] get => new int4(0, x, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxx { [IN(LINE)] get => new int4(0, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxy { [IN(LINE)] get => new int4(0, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yx_ { [IN(LINE)] get => new int4(0, y, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyx { [IN(LINE)] get => new int4(0, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyy { [IN(LINE)] get => new int4(0, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yy_ { [IN(LINE)] get => new int4(0, y, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_x { [IN(LINE)] get => new int4(0, y, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_y { [IN(LINE)] get => new int4(0, y, 0, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y__ { [IN(LINE)] get => new int4(0, y, 0, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xx { [IN(LINE)] get => new int4(0, 0, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xy { [IN(LINE)] get => new int4(0, 0, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __x_ { [IN(LINE)] get => new int4(0, 0, x, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yx { [IN(LINE)] get => new int4(0, 0, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yy { [IN(LINE)] get => new int4(0, 0, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __y_ { [IN(LINE)] get => new int4(0, 0, y, 0); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___x { [IN(LINE)] get => new int4(0, 0, 0, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___y { [IN(LINE)] get => new int4(0, 0, 0, y); }
        #endregion


        #region Other 
        [IN(LINE)]
        public override int GetHashCode() => math.hash(this);
        [IN(LINE)]
        public override bool Equals(object o) => o is int2 target && Equals(target); 
        [IN(LINE)]
        public bool Equals(int2 a) => x == a.x && y == a.y; 
        [IN(LINE)]
        public override string ToString() => $"int2({x}, {y})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<int, int2> IEnumerableVector<int, int2>.GetEnumerator() => new VectorEnumerator<int, int2>(this);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new VectorEnumerator<int, int2>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<int, int2>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly int* _pointer;
            private sbyte _index;
            [IN(LINE)]
            public Enumerator(in int2 value)
            {
                fixed (int2* array = &value)
                {
                    _pointer = (int*)array;
                    _index = -1;
                }
            }
            public int Current => _pointer[_index];
            [IN(LINE)]
            public void Dispose() { }
            [IN(LINE)]
            public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)]
            public void Reset() { }
        }

        internal class DebuggerProxy
        {
            public int x, y;
            public DebuggerProxy(int2 v) { x = v.x; y = v.y; }
        }
        #endregion
    }
}