#if DISABLE_DEBUG
#undef DEBUG
#endif
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
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (uint)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (uint)value; }
        public float b { [IN(LINE)] get => 0f; [IN(LINE)] set { } }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set { } }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector1<uint>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector2<uint>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe uint this[int index]
        {
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint2* array = &this) { return ((uint*)array)[index]; }
            }
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public uint2(float x, float y) { this.x = (uint)x; this.y = (uint)y; }
        [IN(LINE)] public uint2(float v) { x = (uint)v; y = (uint)v; }
        [IN(LINE)] public uint2(float2 v) { x = (uint)v.x; y = (uint)v.y; }
        [IN(LINE)] public uint2(double x, double y) { this.x = (uint)x; this.y = (uint)y; }
        [IN(LINE)] public uint2(double v) { x = (uint)v; y = (uint)v; }
        [IN(LINE)] public uint2(double2 v) { x = (uint)v.x; y = (uint)v.y; }
        [IN(LINE)] public uint2(int x, int y) { this.x = (uint)x; this.y = (uint)y; }
        [IN(LINE)] public uint2(int v) { x = (uint)v; y = (uint)v; }
        [IN(LINE)] public uint2(int2 v) { x = (uint)v.x; y = (uint)v.y; }
        [IN(LINE)] public uint2(uint x, uint y) { this.x = x; this.y = y; }
        [IN(LINE)] public uint2(uint v) { x = v; y = v; }
        [IN(LINE)] public uint2(uint2 v) { x = v.x; y = v.y; }

        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static uint2 operator *(uint2 a, uint2 b) => new uint2(a.x * b.x, a.y * b.y);
        [IN(LINE)] public static uint2 operator *(uint2 a, uint b) => new uint2(a.x * b, a.y * b);
        [IN(LINE)] public static uint2 operator *(uint a, uint2 b) => new uint2(a * b.x, a * b.y);

        [IN(LINE)] public static uint2 operator +(uint2 a, uint2 b) => new uint2(a.x + b.x, a.y + b.y);
        [IN(LINE)] public static uint2 operator +(uint2 a, uint b) => new uint2(a.x + b, a.y + b);
        [IN(LINE)] public static uint2 operator +(uint a, uint2 b) => new uint2(a + b.x, a + b.y);

        [IN(LINE)] public static uint2 operator -(uint2 a, uint2 b) => new uint2(a.x - b.x, a.y - b.y);
        [IN(LINE)] public static uint2 operator -(uint2 a, uint b) => new uint2(a.x - b, a.y - b);
        [IN(LINE)] public static uint2 operator -(uint a, uint2 b) => new uint2(a - b.x, a - b.y);

        [IN(LINE)] public static uint2 operator /(uint2 a, uint2 b) => new uint2(a.x / b.x, a.y / b.y);
        [IN(LINE)] public static uint2 operator /(uint2 a, uint b) => new uint2(a.x / b, a.y / b);
        [IN(LINE)] public static uint2 operator /(uint a, uint2 b) => new uint2(a / b.x, a / b.y);

        [IN(LINE)] public static uint2 operator %(uint2 a, uint2 b) => new uint2(a.x % b.x, a.y % b.y);
        [IN(LINE)] public static uint2 operator %(uint2 a, uint b) => new uint2(a.x % b, a.y % b);
        [IN(LINE)] public static uint2 operator %(uint a, uint2 b) => new uint2(a % b.x, a % b.y);

        [IN(LINE)] public static uint2 operator ++(uint2 a) => new uint2(++a.x, ++a.y);
        [IN(LINE)] public static uint2 operator --(uint2 a) => new uint2(--a.x, --a.y);
        [IN(LINE)] public static uint2 operator -(uint2 a) => new uint2(-a.x, -a.y);
        [IN(LINE)] public static uint2 operator +(uint2 a) => new uint2(+a.x, +a.y);
        #endregion

        #region Bits
        [IN(LINE)] public static uint2 operator ~(uint2 a) => new uint2(~a.x, ~a.y);
        [IN(LINE)] public static uint2 operator <<(uint2 a, int n) => new uint2(a.x << n, a.y << n);
        [IN(LINE)] public static uint2 operator >>(uint2 a, int n) => new uint2(a.x >> n, a.y >> n);

        [IN(LINE)] public static uint2 operator |(uint2 a, uint2 b) => new uint2(a.x | b.x, a.y | b.y);
        [IN(LINE)] public static uint2 operator |(uint2 a, uint b) => new uint2(a.x | b, a.y | b);
        [IN(LINE)] public static uint2 operator |(uint a, uint2 b) => new uint2(a | b.x, a | b.y);

        [IN(LINE)] public static uint2 operator &(uint2 a, uint2 b) => new uint2(a.x & b.x, a.y & b.y);
        [IN(LINE)] public static uint2 operator &(uint2 a, uint b) => new uint2(a.x & b, a.y & b);
        [IN(LINE)] public static uint2 operator &(uint a, uint2 b) => new uint2(a & b.x, a & b.y);

        [IN(LINE)] public static uint2 operator ^(uint2 a, uint2 b) => new uint2(a.x ^ b.x, a.y ^ b.y);
        [IN(LINE)] public static uint2 operator ^(uint2 a, uint b) => new uint2(a.x ^ b, a.y ^ b);
        [IN(LINE)] public static uint2 operator ^(uint a, uint2 b) => new uint2(a ^ b.x, a ^ b.y);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(uint2 a, uint2 b) => a.x == b.x && a.y == b.y;
        [IN(LINE)] public static bool operator ==(uint2 a, uint b) => a.x == b && a.y == b;
        [IN(LINE)] public static bool operator ==(uint a, uint2 b) => a == b.x && a == b.y;

        [IN(LINE)] public static bool operator !=(uint2 a, uint2 b) => a.x != b.x || a.y != b.y;
        [IN(LINE)] public static bool operator !=(uint2 a, uint b) => a.x != b || a.y != b;
        [IN(LINE)] public static bool operator !=(uint a, uint2 b) => a != b.x || a != b.y;
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 xx { [IN(LINE)] get => new uint2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 xy { [IN(LINE)] get => new uint2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 x_ { [IN(LINE)] get => new uint2(x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 yx { [IN(LINE)] get => new uint2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 yy { [IN(LINE)] get => new uint2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 y_ { [IN(LINE)] get => new uint2(y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 _x { [IN(LINE)] get => new uint2(0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 _y { [IN(LINE)] get => new uint2(0u, y); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xxx { [IN(LINE)] get => new uint3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xxy { [IN(LINE)] get => new uint3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xx_ { [IN(LINE)] get => new uint3(x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xyx { [IN(LINE)] get => new uint3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xyy { [IN(LINE)] get => new uint3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xy_ { [IN(LINE)] get => new uint3(x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x_x { [IN(LINE)] get => new uint3(x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x_y { [IN(LINE)] get => new uint3(x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x__ { [IN(LINE)] get => new uint3(x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yxx { [IN(LINE)] get => new uint3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yxy { [IN(LINE)] get => new uint3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yx_ { [IN(LINE)] get => new uint3(y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yyx { [IN(LINE)] get => new uint3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yyy { [IN(LINE)] get => new uint3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yy_ { [IN(LINE)] get => new uint3(y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y_x { [IN(LINE)] get => new uint3(y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y_y { [IN(LINE)] get => new uint3(y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y__ { [IN(LINE)] get => new uint3(y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _xx { [IN(LINE)] get => new uint3(0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _xy { [IN(LINE)] get => new uint3(0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _x_ { [IN(LINE)] get => new uint3(0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _yx { [IN(LINE)] get => new uint3(0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _yy { [IN(LINE)] get => new uint3(0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _y_ { [IN(LINE)] get => new uint3(0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 __x { [IN(LINE)] get => new uint3(0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 __y { [IN(LINE)] get => new uint3(0u, 0u, y); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxxx { [IN(LINE)] get => new uint4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxxy { [IN(LINE)] get => new uint4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxx_ { [IN(LINE)] get => new uint4(x, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxyx { [IN(LINE)] get => new uint4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxyy { [IN(LINE)] get => new uint4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxy_ { [IN(LINE)] get => new uint4(x, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx_x { [IN(LINE)] get => new uint4(x, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx_y { [IN(LINE)] get => new uint4(x, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx__ { [IN(LINE)] get => new uint4(x, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyxx { [IN(LINE)] get => new uint4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyxy { [IN(LINE)] get => new uint4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyx_ { [IN(LINE)] get => new uint4(x, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyyx { [IN(LINE)] get => new uint4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyyy { [IN(LINE)] get => new uint4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyy_ { [IN(LINE)] get => new uint4(x, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy_x { [IN(LINE)] get => new uint4(x, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy_y { [IN(LINE)] get => new uint4(x, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy__ { [IN(LINE)] get => new uint4(x, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_xx { [IN(LINE)] get => new uint4(x, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_xy { [IN(LINE)] get => new uint4(x, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_x_ { [IN(LINE)] get => new uint4(x, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_yx { [IN(LINE)] get => new uint4(x, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_yy { [IN(LINE)] get => new uint4(x, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_y_ { [IN(LINE)] get => new uint4(x, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x__x { [IN(LINE)] get => new uint4(x, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x__y { [IN(LINE)] get => new uint4(x, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x___ { [IN(LINE)] get => new uint4(x, 0u, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxxx { [IN(LINE)] get => new uint4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxxy { [IN(LINE)] get => new uint4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxx_ { [IN(LINE)] get => new uint4(y, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxyx { [IN(LINE)] get => new uint4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxyy { [IN(LINE)] get => new uint4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxy_ { [IN(LINE)] get => new uint4(y, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx_x { [IN(LINE)] get => new uint4(y, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx_y { [IN(LINE)] get => new uint4(y, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx__ { [IN(LINE)] get => new uint4(y, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyxx { [IN(LINE)] get => new uint4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyxy { [IN(LINE)] get => new uint4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyx_ { [IN(LINE)] get => new uint4(y, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyyx { [IN(LINE)] get => new uint4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyyy { [IN(LINE)] get => new uint4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyy_ { [IN(LINE)] get => new uint4(y, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy_x { [IN(LINE)] get => new uint4(y, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy_y { [IN(LINE)] get => new uint4(y, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy__ { [IN(LINE)] get => new uint4(y, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_xx { [IN(LINE)] get => new uint4(y, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_xy { [IN(LINE)] get => new uint4(y, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_x_ { [IN(LINE)] get => new uint4(y, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_yx { [IN(LINE)] get => new uint4(y, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_yy { [IN(LINE)] get => new uint4(y, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_y_ { [IN(LINE)] get => new uint4(y, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y__x { [IN(LINE)] get => new uint4(y, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y__y { [IN(LINE)] get => new uint4(y, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y___ { [IN(LINE)] get => new uint4(y, 0u, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xxx { [IN(LINE)] get => new uint4(0u, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xxy { [IN(LINE)] get => new uint4(0u, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xx_ { [IN(LINE)] get => new uint4(0u, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xyx { [IN(LINE)] get => new uint4(0u, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xyy { [IN(LINE)] get => new uint4(0u, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xy_ { [IN(LINE)] get => new uint4(0u, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x_x { [IN(LINE)] get => new uint4(0u, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x_y { [IN(LINE)] get => new uint4(0u, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x__ { [IN(LINE)] get => new uint4(0u, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yxx { [IN(LINE)] get => new uint4(0u, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yxy { [IN(LINE)] get => new uint4(0u, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yx_ { [IN(LINE)] get => new uint4(0u, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yyx { [IN(LINE)] get => new uint4(0u, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yyy { [IN(LINE)] get => new uint4(0u, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yy_ { [IN(LINE)] get => new uint4(0u, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y_x { [IN(LINE)] get => new uint4(0u, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y_y { [IN(LINE)] get => new uint4(0u, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y__ { [IN(LINE)] get => new uint4(0u, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __xx { [IN(LINE)] get => new uint4(0u, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __xy { [IN(LINE)] get => new uint4(0u, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __x_ { [IN(LINE)] get => new uint4(0u, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __yx { [IN(LINE)] get => new uint4(0u, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __yy { [IN(LINE)] get => new uint4(0u, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __y_ { [IN(LINE)] get => new uint4(0u, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 ___x { [IN(LINE)] get => new uint4(0u, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 ___y { [IN(LINE)] get => new uint4(0u, 0u, 0u, y); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => math.Hash(this);
        public override bool Equals(object o) => o is uint2 target && Equals(target);
        [IN(LINE)] public bool Equals(uint2 a) => x == a.x && y == a.y;
        public override string ToString() => $"uint2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public uint x, y;
            public DebuggerProxy(uint2 v) { x = v.x; y = v.y; }
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
            [IN(LINE)]
            public Enumerator(in uint2 value)
            {
                fixed (uint2* array = &value)
                {
                    _pointer = (uint*)array;
                    _index = -1;
                }
            }
            public uint Current { [IN(LINE)] get => _pointer[_index]; }
            [IN(LINE)] public void Dispose() { }
            [IN(LINE)] public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)] public void Reset() { }
        }
        #endregion
    }
}