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
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (float)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (float)value; }
        public float b { [IN(LINE)] get => 0f; [IN(LINE)] set {} }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set {} }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector1<float>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector2<float>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float2* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public float2(float x, float y) { this.x = x; this.y = y; }
        [IN(LINE)] public float2(float v) { x = v; y = v; }
        [IN(LINE)] public float2(float2 v) { x = v.x; y = v.y; }
        [IN(LINE)] public float2(double x, double y) { this.x = (float)x; this.y = (float)y; }
        [IN(LINE)] public float2(double v) { x = (float)v; y = (float)v; }
        [IN(LINE)] public float2(double2 v) { x = (float)v.x; y = (float)v.y; }
        [IN(LINE)] public float2(int x, int y) { this.x = (float)x; this.y = (float)y; }
        [IN(LINE)] public float2(int v) { x = (float)v; y = (float)v; }
        [IN(LINE)] public float2(int2 v) { x = (float)v.x; y = (float)v.y; }
        [IN(LINE)] public float2(uint x, uint y) { this.x = (float)x; this.y = (float)y; }
        [IN(LINE)] public float2(uint v) { x = (float)v; y = (float)v; }
        [IN(LINE)] public float2(uint2 v) { x = (float)v.x; y = (float)v.y; }

        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static float2 operator *(float2 a, float2 b) => new float2(a.x * b.x, a.y * b.y);
        [IN(LINE)] public static float2 operator *(float2 a, float b) => new float2(a.x * b, a.y * b);
        [IN(LINE)] public static float2 operator *(float a, float2 b) => new float2(a * b.x, a * b.y);

        [IN(LINE)] public static float2 operator +(float2 a, float2 b) => new float2(a.x + b.x, a.y + b.y);
        [IN(LINE)] public static float2 operator +(float2 a, float b) => new float2(a.x + b, a.y + b);
        [IN(LINE)] public static float2 operator +(float a, float2 b) => new float2(a + b.x, a + b.y);

        [IN(LINE)] public static float2 operator -(float2 a, float2 b) => new float2(a.x - b.x, a.y - b.y);
        [IN(LINE)] public static float2 operator -(float2 a, float b) => new float2(a.x - b, a.y - b);
        [IN(LINE)] public static float2 operator -(float a, float2 b) => new float2(a - b.x, a - b.y);

        [IN(LINE)] public static float2 operator /(float2 a, float2 b) => new float2(a.x / b.x, a.y / b.y);
        [IN(LINE)] public static float2 operator /(float2 a, float b) => new float2(a.x / b, a.y / b);
        [IN(LINE)] public static float2 operator /(float a, float2 b) => new float2(a / b.x, a / b.y);

        [IN(LINE)] public static float2 operator %(float2 a, float2 b) => new float2(a.x % b.x, a.y % b.y);
        [IN(LINE)] public static float2 operator %(float2 a, float b) => new float2(a.x % b, a.y % b);
        [IN(LINE)] public static float2 operator %(float a, float2 b) => new float2(a % b.x, a % b.y);

        [IN(LINE)] public static float2 operator ++(float2 a) => new float2(++a.x, ++a.y);
        [IN(LINE)] public static float2 operator --(float2 a) => new float2(--a.x, --a.y);
        [IN(LINE)] public static float2 operator -(float2 a) => new float2(-a.x, -a.y);
        [IN(LINE)] public static float2 operator +(float2 a) => new float2(+a.x, +a.y);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(float2 a, float2 b) => a.x == b.x && a.y == b.y;
        [IN(LINE)] public static bool operator ==(float2 a, float b) => a.x == b && a.y == b;
        [IN(LINE)] public static bool operator ==(float a, float2 b) => a == b.x && a == b.y;

        [IN(LINE)] public static bool operator !=(float2 a, float2 b) => a.x != b.x || a.y != b.y;
        [IN(LINE)] public static bool operator !=(float2 a, float b) => a.x != b || a.y != b;
        [IN(LINE)] public static bool operator !=(float a, float2 b) => a != b.x || a != b.y;
        #endregion

        #endregion

        #region Swaps

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xx { [IN(LINE)] get => new float2(x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xy { [IN(LINE)] get => new float2(x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 x_ { [IN(LINE)] get => new float2(x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yx { [IN(LINE)] get => new float2(y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yy { [IN(LINE)] get => new float2(y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 y_ { [IN(LINE)] get => new float2(y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _x { [IN(LINE)] get => new float2(0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _y { [IN(LINE)] get => new float2(0f, y); }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxx { [IN(LINE)] get => new float3(x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxy { [IN(LINE)] get => new float3(x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xx_ { [IN(LINE)] get => new float3(x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyx { [IN(LINE)] get => new float3(x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyy { [IN(LINE)] get => new float3(x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xy_ { [IN(LINE)] get => new float3(x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_x { [IN(LINE)] get => new float3(x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_y { [IN(LINE)] get => new float3(x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x__ { [IN(LINE)] get => new float3(x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxx { [IN(LINE)] get => new float3(y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxy { [IN(LINE)] get => new float3(y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yx_ { [IN(LINE)] get => new float3(y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyx { [IN(LINE)] get => new float3(y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyy { [IN(LINE)] get => new float3(y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yy_ { [IN(LINE)] get => new float3(y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_x { [IN(LINE)] get => new float3(y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_y { [IN(LINE)] get => new float3(y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y__ { [IN(LINE)] get => new float3(y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xx { [IN(LINE)] get => new float3(0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xy { [IN(LINE)] get => new float3(0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _x_ { [IN(LINE)] get => new float3(0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yx { [IN(LINE)] get => new float3(0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yy { [IN(LINE)] get => new float3(0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _y_ { [IN(LINE)] get => new float3(0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __x { [IN(LINE)] get => new float3(0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __y { [IN(LINE)] get => new float3(0f, 0f, y); }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxx { [IN(LINE)] get => new float4(x, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxy { [IN(LINE)] get => new float4(x, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxx_ { [IN(LINE)] get => new float4(x, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyx { [IN(LINE)] get => new float4(x, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyy { [IN(LINE)] get => new float4(x, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxy_ { [IN(LINE)] get => new float4(x, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_x { [IN(LINE)] get => new float4(x, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_y { [IN(LINE)] get => new float4(x, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx__ { [IN(LINE)] get => new float4(x, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxx { [IN(LINE)] get => new float4(x, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxy { [IN(LINE)] get => new float4(x, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyx_ { [IN(LINE)] get => new float4(x, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyx { [IN(LINE)] get => new float4(x, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyy { [IN(LINE)] get => new float4(x, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyy_ { [IN(LINE)] get => new float4(x, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_x { [IN(LINE)] get => new float4(x, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_y { [IN(LINE)] get => new float4(x, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy__ { [IN(LINE)] get => new float4(x, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xx { [IN(LINE)] get => new float4(x, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xy { [IN(LINE)] get => new float4(x, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_x_ { [IN(LINE)] get => new float4(x, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yx { [IN(LINE)] get => new float4(x, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yy { [IN(LINE)] get => new float4(x, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_y_ { [IN(LINE)] get => new float4(x, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__x { [IN(LINE)] get => new float4(x, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__y { [IN(LINE)] get => new float4(x, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x___ { [IN(LINE)] get => new float4(x, 0f, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxx { [IN(LINE)] get => new float4(y, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxy { [IN(LINE)] get => new float4(y, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxx_ { [IN(LINE)] get => new float4(y, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyx { [IN(LINE)] get => new float4(y, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyy { [IN(LINE)] get => new float4(y, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxy_ { [IN(LINE)] get => new float4(y, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_x { [IN(LINE)] get => new float4(y, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_y { [IN(LINE)] get => new float4(y, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx__ { [IN(LINE)] get => new float4(y, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxx { [IN(LINE)] get => new float4(y, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxy { [IN(LINE)] get => new float4(y, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyx_ { [IN(LINE)] get => new float4(y, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyx { [IN(LINE)] get => new float4(y, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyy { [IN(LINE)] get => new float4(y, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyy_ { [IN(LINE)] get => new float4(y, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_x { [IN(LINE)] get => new float4(y, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_y { [IN(LINE)] get => new float4(y, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy__ { [IN(LINE)] get => new float4(y, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xx { [IN(LINE)] get => new float4(y, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xy { [IN(LINE)] get => new float4(y, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_x_ { [IN(LINE)] get => new float4(y, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yx { [IN(LINE)] get => new float4(y, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yy { [IN(LINE)] get => new float4(y, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_y_ { [IN(LINE)] get => new float4(y, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__x { [IN(LINE)] get => new float4(y, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__y { [IN(LINE)] get => new float4(y, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y___ { [IN(LINE)] get => new float4(y, 0f, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxx { [IN(LINE)] get => new float4(0f, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxy { [IN(LINE)] get => new float4(0f, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xx_ { [IN(LINE)] get => new float4(0f, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyx { [IN(LINE)] get => new float4(0f, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyy { [IN(LINE)] get => new float4(0f, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xy_ { [IN(LINE)] get => new float4(0f, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_x { [IN(LINE)] get => new float4(0f, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_y { [IN(LINE)] get => new float4(0f, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x__ { [IN(LINE)] get => new float4(0f, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxx { [IN(LINE)] get => new float4(0f, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxy { [IN(LINE)] get => new float4(0f, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yx_ { [IN(LINE)] get => new float4(0f, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyx { [IN(LINE)] get => new float4(0f, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyy { [IN(LINE)] get => new float4(0f, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yy_ { [IN(LINE)] get => new float4(0f, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_x { [IN(LINE)] get => new float4(0f, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_y { [IN(LINE)] get => new float4(0f, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y__ { [IN(LINE)] get => new float4(0f, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xx { [IN(LINE)] get => new float4(0f, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xy { [IN(LINE)] get => new float4(0f, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __x_ { [IN(LINE)] get => new float4(0f, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yx { [IN(LINE)] get => new float4(0f, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yy { [IN(LINE)] get => new float4(0f, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __y_ { [IN(LINE)] get => new float4(0f, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___x { [IN(LINE)] get => new float4(0f, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___y { [IN(LINE)] get => new float4(0f, 0f, 0f, y); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => math.hash(this);
        public override bool Equals(object o) => o is float2 target && Equals(target); 
        [IN(LINE)] public bool Equals(float2 a) => x == a.x && y == a.y; 
        public override string ToString() => $"float2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float x, y;
            public DebuggerProxy(float2 v) { x = v.x; y = v.y; }
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
            [IN(LINE)]
            public Enumerator(in float2 value)
            {
                fixed (float2* array = &value)
                {
                    _pointer = (float*)array;
                    _index = -1;
                }
            }
            public float Current { [IN(LINE)] get => _pointer[_index]; }
            [IN(LINE)] public void Dispose() { }
            [IN(LINE)] public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)] public void Reset() { }
        }
        #endregion
    }
}