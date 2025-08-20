#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace DCFApixels.DataMath
{
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct double2 :
        IEquatable<double2>,
        IFormattable,
        IVector2Impl<double>,
        IColor,
        IEnumerableVector<double, double2>
    {
        #region Consts
        public const int Count = 2;

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
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (double)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (double)value; } }
        public float b { [IN(LINE)] get { return 0f; } [IN(LINE)] set { } }
        public float a { [IN(LINE)] get { return 1f; } [IN(LINE)] set { } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector1<double>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector2<double>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] public int count { [IN(LINE)] get { return Count; } }

        public unsafe double this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (double2* array = &this) { return ((double*)array)[index]; }
            }
            [IN(LINE)]
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (double* array = &x) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is double cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(double); }
        #endregion

        #region Constructors
        [IN(LINE)] public double2(double x, double y) { this.x = x; this.y = y; }

        [IN(LINE)] public double2(float v) { x = (double)v; y = (double)v; }
        [IN(LINE)] public double2(float2 v) { x = (double)v.x; y = (double)v.y; }

        [IN(LINE)] public double2(double v) { x = v; y = v; }
        [IN(LINE)] public double2(double2 v) { x = v.x; y = v.y; }

        [IN(LINE)] public double2(int v) { x = (double)v; y = (double)v; }
        [IN(LINE)] public double2(int2 v) { x = (double)v.x; y = (double)v.y; }

        [IN(LINE)] public double2(uint v) { x = (double)v; y = (double)v; }
        [IN(LINE)] public double2(uint2 v) { x = (double)v.x; y = (double)v.y; }


        [IN(LINE)]
        public double2(ReadOnlySpan<double> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1];
#else
            this = Unsafe.ReadUnaligned<double2>(ref Unsafe.As<double, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out float x, out float y) { x = this.x; y = this.y; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static double2 operator +(double2 a, double2 b) { return new double2(a.x + b.x, a.y + b.y); }
        [IN(LINE)] public static double2 operator +(double2 a, double b) { return new double2(a.x + b, a.y + b); }
        [IN(LINE)] public static double2 operator +(double a, double2 b) { return new double2(a + b.x, a + b.y); }

        [IN(LINE)] public static double2 operator -(double2 a, double2 b) { return new double2(a.x - b.x, a.y - b.y); }
        [IN(LINE)] public static double2 operator -(double2 a, double b) { return new double2(a.x - b, a.y - b); }
        [IN(LINE)] public static double2 operator -(double a, double2 b) { return new double2(a - b.x, a - b.y); }

        [IN(LINE)] public static double2 operator *(double2 a, double2 b) { return new double2(a.x * b.x, a.y * b.y); }
        [IN(LINE)] public static double2 operator *(double2 a, double b) { return new double2(a.x * b, a.y * b); }
        [IN(LINE)] public static double2 operator *(double a, double2 b) { return new double2(a * b.x, a * b.y); }

        [IN(LINE)] public static double2 operator /(double2 a, double2 b) { return new double2(a.x / b.x, a.y / b.y); }
        [IN(LINE)] public static double2 operator /(double2 a, double b) { return new double2(a.x / b, a.y / b); }
        [IN(LINE)] public static double2 operator /(double a, double2 b) { return new double2(a / b.x, a / b.y); }

        [IN(LINE)] public static double2 operator %(double2 a, double2 b) { return new double2(a.x % b.x, a.y % b.y); }
        [IN(LINE)] public static double2 operator %(double2 a, double b) { return new double2(a.x % b, a.y % b); }
        [IN(LINE)] public static double2 operator %(double a, double2 b) { return new double2(a % b.x, a % b.y); }

        [IN(LINE)] public static double2 operator ++(double2 a) { return new double2(++a.x, ++a.y); }
        [IN(LINE)] public static double2 operator --(double2 a) { return new double2(--a.x, --a.y); }
        [IN(LINE)] public static double2 operator +(double2 a) { return new double2(+a.x, +a.y); }
        [IN(LINE)] public static double2 operator -(double2 a) { return new double2(-a.x, -a.y); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool2 operator <(double2 a, double2 b) { return new bool2(a.x < b.x, a.y < b.y); }
        [IN(LINE)] public static bool2 operator <(double2 a, double b) { return new bool2(a.x < b, a.y < b); }
        [IN(LINE)] public static bool2 operator <(double a, double2 b) { return new bool2(a < b.x, a < b.y); }

        [IN(LINE)] public static bool2 operator <=(double2 a, double2 b) { return new bool2(a.x <= b.x, a.y <= b.y); }
        [IN(LINE)] public static bool2 operator <=(double2 a, double b) { return new bool2(a.x <= b, a.y <= b); }
        [IN(LINE)] public static bool2 operator <=(double a, double2 b) { return new bool2(a <= b.x, a <= b.y); }

        [IN(LINE)] public static bool2 operator >(double2 a, double2 b) { return new bool2(a.x > b.x, a.y > b.y); }
        [IN(LINE)] public static bool2 operator >(double2 a, double b) { return new bool2(a.x > b, a.y > b); }
        [IN(LINE)] public static bool2 operator >(double a, double2 b) { return new bool2(a > b.x, a > b.y); }

        [IN(LINE)] public static bool2 operator >=(double2 a, double2 b) { return new bool2(a.x >= b.x, a.y >= b.y); }
        [IN(LINE)] public static bool2 operator >=(double2 a, double b) { return new bool2(a.x >= b, a.y >= b); }
        [IN(LINE)] public static bool2 operator >=(double a, double2 b) { return new bool2(a >= b.x, a >= b.y); }

        [IN(LINE)] public static bool2 operator ==(double2 a, double2 b) { return new bool2(a.x == b.x, a.y == b.y); }
        [IN(LINE)] public static bool2 operator ==(double2 a, double b) { return new bool2(a.x == b, a.y == b); }
        [IN(LINE)] public static bool2 operator ==(double a, double2 b) { return new bool2(a == b.x, a == b.y); }

        [IN(LINE)] public static bool2 operator !=(double2 a, double2 b) { return new bool2(a.x != b.x, a.y != b.y); }
        [IN(LINE)] public static bool2 operator !=(double2 a, double b) { return new bool2(a.x != b, a.y != b); }
        [IN(LINE)] public static bool2 operator !=(double a, double2 b) { return new bool2(a != b.x, a != b.y); }
        #endregion

        #region Other
        [IN(LINE)] public static double2 operator !(double2 a) { return 1d - a; }
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xx { [IN(LINE)] get => new double2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xy { [IN(LINE)] get => new double2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 x_ { [IN(LINE)] get => new double2(x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yx { [IN(LINE)] get => new double2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yy { [IN(LINE)] get => new double2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 y_ { [IN(LINE)] get => new double2(y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _x { [IN(LINE)] get => new double2(0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _y { [IN(LINE)] get => new double2(0d, y); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxx { [IN(LINE)] get => new double3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxy { [IN(LINE)] get => new double3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xx_ { [IN(LINE)] get => new double3(x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyx { [IN(LINE)] get => new double3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyy { [IN(LINE)] get => new double3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xy_ { [IN(LINE)] get => new double3(x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_x { [IN(LINE)] get => new double3(x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_y { [IN(LINE)] get => new double3(x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x__ { [IN(LINE)] get => new double3(x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxx { [IN(LINE)] get => new double3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxy { [IN(LINE)] get => new double3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yx_ { [IN(LINE)] get => new double3(y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyx { [IN(LINE)] get => new double3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyy { [IN(LINE)] get => new double3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yy_ { [IN(LINE)] get => new double3(y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_x { [IN(LINE)] get => new double3(y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_y { [IN(LINE)] get => new double3(y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y__ { [IN(LINE)] get => new double3(y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xx { [IN(LINE)] get => new double3(0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xy { [IN(LINE)] get => new double3(0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _x_ { [IN(LINE)] get => new double3(0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yx { [IN(LINE)] get => new double3(0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yy { [IN(LINE)] get => new double3(0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _y_ { [IN(LINE)] get => new double3(0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __x { [IN(LINE)] get => new double3(0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __y { [IN(LINE)] get => new double3(0d, 0d, y); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxx { [IN(LINE)] get => new double4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxy { [IN(LINE)] get => new double4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxx_ { [IN(LINE)] get => new double4(x, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyx { [IN(LINE)] get => new double4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyy { [IN(LINE)] get => new double4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxy_ { [IN(LINE)] get => new double4(x, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_x { [IN(LINE)] get => new double4(x, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_y { [IN(LINE)] get => new double4(x, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx__ { [IN(LINE)] get => new double4(x, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxx { [IN(LINE)] get => new double4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxy { [IN(LINE)] get => new double4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyx_ { [IN(LINE)] get => new double4(x, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyx { [IN(LINE)] get => new double4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyy { [IN(LINE)] get => new double4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyy_ { [IN(LINE)] get => new double4(x, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_x { [IN(LINE)] get => new double4(x, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_y { [IN(LINE)] get => new double4(x, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy__ { [IN(LINE)] get => new double4(x, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xx { [IN(LINE)] get => new double4(x, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xy { [IN(LINE)] get => new double4(x, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_x_ { [IN(LINE)] get => new double4(x, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yx { [IN(LINE)] get => new double4(x, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yy { [IN(LINE)] get => new double4(x, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_y_ { [IN(LINE)] get => new double4(x, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__x { [IN(LINE)] get => new double4(x, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__y { [IN(LINE)] get => new double4(x, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x___ { [IN(LINE)] get => new double4(x, 0d, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxx { [IN(LINE)] get => new double4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxy { [IN(LINE)] get => new double4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxx_ { [IN(LINE)] get => new double4(y, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyx { [IN(LINE)] get => new double4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyy { [IN(LINE)] get => new double4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxy_ { [IN(LINE)] get => new double4(y, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_x { [IN(LINE)] get => new double4(y, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_y { [IN(LINE)] get => new double4(y, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx__ { [IN(LINE)] get => new double4(y, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxx { [IN(LINE)] get => new double4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxy { [IN(LINE)] get => new double4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyx_ { [IN(LINE)] get => new double4(y, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyx { [IN(LINE)] get => new double4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyy { [IN(LINE)] get => new double4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyy_ { [IN(LINE)] get => new double4(y, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_x { [IN(LINE)] get => new double4(y, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_y { [IN(LINE)] get => new double4(y, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy__ { [IN(LINE)] get => new double4(y, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xx { [IN(LINE)] get => new double4(y, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xy { [IN(LINE)] get => new double4(y, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_x_ { [IN(LINE)] get => new double4(y, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yx { [IN(LINE)] get => new double4(y, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yy { [IN(LINE)] get => new double4(y, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_y_ { [IN(LINE)] get => new double4(y, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__x { [IN(LINE)] get => new double4(y, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__y { [IN(LINE)] get => new double4(y, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y___ { [IN(LINE)] get => new double4(y, 0d, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxx { [IN(LINE)] get => new double4(0d, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxy { [IN(LINE)] get => new double4(0d, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xx_ { [IN(LINE)] get => new double4(0d, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyx { [IN(LINE)] get => new double4(0d, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyy { [IN(LINE)] get => new double4(0d, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xy_ { [IN(LINE)] get => new double4(0d, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_x { [IN(LINE)] get => new double4(0d, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_y { [IN(LINE)] get => new double4(0d, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x__ { [IN(LINE)] get => new double4(0d, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxx { [IN(LINE)] get => new double4(0d, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxy { [IN(LINE)] get => new double4(0d, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yx_ { [IN(LINE)] get => new double4(0d, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyx { [IN(LINE)] get => new double4(0d, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyy { [IN(LINE)] get => new double4(0d, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yy_ { [IN(LINE)] get => new double4(0d, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_x { [IN(LINE)] get => new double4(0d, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_y { [IN(LINE)] get => new double4(0d, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y__ { [IN(LINE)] get => new double4(0d, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xx { [IN(LINE)] get => new double4(0d, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xy { [IN(LINE)] get => new double4(0d, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __x_ { [IN(LINE)] get => new double4(0d, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yx { [IN(LINE)] get => new double4(0d, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yy { [IN(LINE)] get => new double4(0d, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __y_ { [IN(LINE)] get => new double4(0d, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___x { [IN(LINE)] get => new double4(0d, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___y { [IN(LINE)] get => new double4(0d, 0d, 0d, y); }
        #endregion

        #endregion


        #region Other
        [IN(LINE)]
        public readonly void CopyTo(Span<double> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            for (int i = 0; i < Count; i++) { destination[i] = this[i]; }
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<double, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is double2 target && Equals(target); }
        [IN(LINE)] public bool Equals(double2 a) { return x == a.x && y == a.y; }
        public override string ToString() { return $"double2({x}, {y})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public double x, y;
            public DebuggerProxy(double2 v) { x = v.x; y = v.y; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<double, double2> GetEnumerator() { return new VectorEnumerator<double, double2>(this); }
        VectorEnumerator<double, double2> IEnumerableVector<double, double2>.GetEnumerator() { return new VectorEnumerator<double, double2>(this); }
        IEnumerator<double> IEnumerable<double>.GetEnumerator() { return new VectorEnumerator<double, double2>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<double, double2>(this); }
        #endregion
    }
}