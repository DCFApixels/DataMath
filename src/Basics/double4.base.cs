#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using DCFApixels.DataMath.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 32)]
    public unsafe partial struct double4 :
        IEquatable<double4>,
        IFormattable,
        IVector4Impl<double>,
        IColor,
        IEnumerableVector<double, double4>
    {
        #region Consts
        public const int Count = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly double4 zero = new double4(0d, 0d, 0d, 0d);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly double4 one = new double4(1d, 1d, 1d, 1d);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly double4 left = new double4(unchecked((double)-1d), 0d, 0d, 0d);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly double4 right = new double4(1d, 0d, 0d, 0d);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly double4 down = new double4(0d, unchecked((double)-1d), 0d, 0d);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly double4 up = new double4(0d, 1d, 0d, 0d);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly double4 back = new double4(0d, 0d, unchecked((double)-1d), 0d);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly double4 forward = new double4(0d, 0d, 1d, 0d);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly double4 before = new double4(0d, 0d, 0d, unchecked((double)-1d));
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly double4 after = new double4(0d, 0d, 0d, 1d);
        #endregion

        public double x;
        public double y;
        public double z;
        public double w;

        #region IColor
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (double)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (double)value; } }
        public float b { [IN(LINE)] get { return (float)z; } [IN(LINE)] set { z = (double)value; } }
        public float a { [IN(LINE)] get { return (float)w; } [IN(LINE)] set { w = (double)value; } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector1<double>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector2<double>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector3<double>.z { [IN(LINE)] get { return z; } [IN(LINE)] set { z = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] double IVector4<double>.w { [IN(LINE)] get { return w; } [IN(LINE)] set { w = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public double this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (double4* array = &this) { return ((double*)array)[index]; }
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
        [IN(LINE)]
        public double4((double x, double y, double z, double w) a)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = a.w;
        }
        [IN(LINE)]
        public double4((double x, double y, double z) a, double w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, (double x, double y, double z) a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public double4((double x, double y) a, double z, double w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, (double x, double y) a, double w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, double y, (double x, double y) a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public double4((double x, double y) a, (double x, double y) b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public double4(double x, double y, double z, double w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public double4(double3 a, double w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, double3 a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public double4(double2 a, double z, double w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, double2 a, double w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public double4(double x, double y, double2 a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public double4(double2 a, double2 b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public double4(float v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [IN(LINE)]
        public double4(float4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }
        [IN(LINE)]
        public double4(double v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public double4(double4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [IN(LINE)]
        public double4(int v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [IN(LINE)]
        public double4(int4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }
        [IN(LINE)]
        public double4(uint v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [IN(LINE)]
        public double4(uint4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }

        [IN(LINE)]
        public double4(ReadOnlySpan<double> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2]; w = values[3];
#else
            this = Unsafe.ReadUnaligned<double4>(ref Unsafe.As<double, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out double x, out double y, out double z, out double w) { x = this.x; y = this.y; z = this.z; w = this.w; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static double4 operator +(double4 a, double4 b) { return new double4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        [IN(LINE)] public static double4 operator +(double4 a, double b) { return new double4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static double4 operator +(double a, double4 b) { return new double4(a + b.x, a + b.y, a + b.z, a + b.w); }

        [IN(LINE)] public static double4 operator -(double4 a, double4 b) { return new double4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        [IN(LINE)] public static double4 operator -(double4 a, double b) { return new double4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static double4 operator -(double a, double4 b) { return new double4(a - b.x, a - b.y, a - b.z, a - b.w); }

        [IN(LINE)] public static double4 operator *(double4 a, double4 b) { return new double4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        [IN(LINE)] public static double4 operator *(double4 a, double b) { return new double4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static double4 operator *(double a, double4 b) { return new double4(a * b.x, a * b.y, a * b.z, a * b.w); }

        [IN(LINE)] public static double4 operator /(double4 a, double4 b) { return new double4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        [IN(LINE)] public static double4 operator /(double4 a, double b) { return new double4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static double4 operator /(double a, double4 b) { return new double4(a / b.x, a / b.y, a / b.z, a / b.w); }

        [IN(LINE)] public static double4 operator %(double4 a, double4 b) { return new double4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w); }
        [IN(LINE)] public static double4 operator %(double4 a, double b) { return new double4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static double4 operator %(double a, double4 b) { return new double4(a % b.x, a % b.y, a % b.z, a % b.w); }

        [IN(LINE)] public static double4 operator ++(double4 a) { return new double4(++a.x, ++a.y, ++a.z, ++a.w); }
        [IN(LINE)] public static double4 operator --(double4 a) { return new double4(--a.x, --a.y, --a.z, --a.w); }
        [IN(LINE)] public static double4 operator +(double4 a) { return new double4(+a.x, +a.y, +a.z, +a.w); }
        [IN(LINE)] public static double4 operator -(double4 a) { return new double4((double)-a.x, (double)-a.y, (double)-a.z, (double)-a.w); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool4 operator <(double4 a, double4 b) { return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w); }
        [IN(LINE)] public static bool4 operator <(double4 a, double b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        [IN(LINE)] public static bool4 operator <(double a, double4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }

        [IN(LINE)] public static bool4 operator <=(double4 a, double4 b) { return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
        [IN(LINE)] public static bool4 operator <=(double4 a, double b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        [IN(LINE)] public static bool4 operator <=(double a, double4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }

        [IN(LINE)] public static bool4 operator >(double4 a, double4 b) { return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w); }
        [IN(LINE)] public static bool4 operator >(double4 a, double b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        [IN(LINE)] public static bool4 operator >(double a, double4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }

        [IN(LINE)] public static bool4 operator >=(double4 a, double4 b) { return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        [IN(LINE)] public static bool4 operator >=(double4 a, double b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        [IN(LINE)] public static bool4 operator >=(double a, double4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }

        [IN(LINE)] public static bool4 operator ==(double4 a, double4 b) { return new bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }
        [IN(LINE)] public static bool4 operator ==(double4 a, double b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        [IN(LINE)] public static bool4 operator ==(double a, double4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }

        [IN(LINE)] public static bool4 operator !=(double4 a, double4 b) { return new bool4(a.x != b.x, a.y != b.y, a.z != b.z, a.w != b.w); }
        [IN(LINE)] public static bool4 operator !=(double4 a, double b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        [IN(LINE)] public static bool4 operator !=(double a, double4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        #endregion

        #region Other
        [IN(LINE)] public static double4 operator !(double4 a) { return 1d - a; }
        #endregion

        #endregion

        #region Swizzles

        #region Swizzle2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xx { [IN(LINE)] get => new double2(x, x); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xy { [IN(LINE)] get => new double2(x, y); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xz { [IN(LINE)] get => new double2(x, z); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xw { [IN(LINE)] get => new double2(x, w); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 x_ { [IN(LINE)] get => new double2(x, 0d); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yx { [IN(LINE)] get => new double2(y, x); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yy { [IN(LINE)] get => new double2(y, y); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yz { [IN(LINE)] get => new double2(y, z); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yw { [IN(LINE)] get => new double2(y, w); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 y_ { [IN(LINE)] get => new double2(y, 0d); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zx { [IN(LINE)] get => new double2(z, x); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zy { [IN(LINE)] get => new double2(z, y); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zz { [IN(LINE)] get => new double2(z, z); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zw { [IN(LINE)] get => new double2(z, w); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 z_ { [IN(LINE)] get => new double2(z, 0d); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wx { [IN(LINE)] get => new double2(w, x); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wy { [IN(LINE)] get => new double2(w, y); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wz { [IN(LINE)] get => new double2(w, z); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 ww { [IN(LINE)] get => new double2(w, w); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 w_ { [IN(LINE)] get => new double2(w, 0d); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _x { [IN(LINE)] get => new double2(0d, x); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _y { [IN(LINE)] get => new double2(0d, y); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _z { [IN(LINE)] get => new double2(0d, z); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _w { [IN(LINE)] get => new double2(0d, w); [IN(LINE)] set { w = value.y; } }
        #endregion

        #region Swizzle3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxx { [IN(LINE)] get => new double3(x, x, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxy { [IN(LINE)] get => new double3(x, x, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxz { [IN(LINE)] get => new double3(x, x, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxw { [IN(LINE)] get => new double3(x, x, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xx_ { [IN(LINE)] get => new double3(x, x, 0d); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyx { [IN(LINE)] get => new double3(x, y, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyy { [IN(LINE)] get => new double3(x, y, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyz { [IN(LINE)] get => new double3(x, y, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyw { [IN(LINE)] get => new double3(x, y, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xy_ { [IN(LINE)] get => new double3(x, y, 0d); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzx { [IN(LINE)] get => new double3(x, z, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzy { [IN(LINE)] get => new double3(x, z, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzz { [IN(LINE)] get => new double3(x, z, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzw { [IN(LINE)] get => new double3(x, z, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xz_ { [IN(LINE)] get => new double3(x, z, 0d); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwx { [IN(LINE)] get => new double3(x, w, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwy { [IN(LINE)] get => new double3(x, w, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwz { [IN(LINE)] get => new double3(x, w, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xww { [IN(LINE)] get => new double3(x, w, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xw_ { [IN(LINE)] get => new double3(x, w, 0d); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_x { [IN(LINE)] get => new double3(x, 0d, x); [IN(LINE)] set { x = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_y { [IN(LINE)] get => new double3(x, 0d, y); [IN(LINE)] set { x = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_z { [IN(LINE)] get => new double3(x, 0d, z); [IN(LINE)] set { x = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_w { [IN(LINE)] get => new double3(x, 0d, w); [IN(LINE)] set { x = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x__ { [IN(LINE)] get => new double3(x, 0d, 0d); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxx { [IN(LINE)] get => new double3(y, x, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxy { [IN(LINE)] get => new double3(y, x, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxz { [IN(LINE)] get => new double3(y, x, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxw { [IN(LINE)] get => new double3(y, x, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yx_ { [IN(LINE)] get => new double3(y, x, 0d); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyx { [IN(LINE)] get => new double3(y, y, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyy { [IN(LINE)] get => new double3(y, y, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyz { [IN(LINE)] get => new double3(y, y, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyw { [IN(LINE)] get => new double3(y, y, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yy_ { [IN(LINE)] get => new double3(y, y, 0d); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzx { [IN(LINE)] get => new double3(y, z, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzy { [IN(LINE)] get => new double3(y, z, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzz { [IN(LINE)] get => new double3(y, z, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzw { [IN(LINE)] get => new double3(y, z, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yz_ { [IN(LINE)] get => new double3(y, z, 0d); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywx { [IN(LINE)] get => new double3(y, w, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywy { [IN(LINE)] get => new double3(y, w, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywz { [IN(LINE)] get => new double3(y, w, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yww { [IN(LINE)] get => new double3(y, w, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yw_ { [IN(LINE)] get => new double3(y, w, 0d); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_x { [IN(LINE)] get => new double3(y, 0d, x); [IN(LINE)] set { y = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_y { [IN(LINE)] get => new double3(y, 0d, y); [IN(LINE)] set { y = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_z { [IN(LINE)] get => new double3(y, 0d, z); [IN(LINE)] set { y = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_w { [IN(LINE)] get => new double3(y, 0d, w); [IN(LINE)] set { y = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y__ { [IN(LINE)] get => new double3(y, 0d, 0d); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxx { [IN(LINE)] get => new double3(z, x, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxy { [IN(LINE)] get => new double3(z, x, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxz { [IN(LINE)] get => new double3(z, x, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxw { [IN(LINE)] get => new double3(z, x, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zx_ { [IN(LINE)] get => new double3(z, x, 0d); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyx { [IN(LINE)] get => new double3(z, y, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyy { [IN(LINE)] get => new double3(z, y, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyz { [IN(LINE)] get => new double3(z, y, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyw { [IN(LINE)] get => new double3(z, y, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zy_ { [IN(LINE)] get => new double3(z, y, 0d); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzx { [IN(LINE)] get => new double3(z, z, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzy { [IN(LINE)] get => new double3(z, z, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzz { [IN(LINE)] get => new double3(z, z, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzw { [IN(LINE)] get => new double3(z, z, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zz_ { [IN(LINE)] get => new double3(z, z, 0d); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwx { [IN(LINE)] get => new double3(z, w, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwy { [IN(LINE)] get => new double3(z, w, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwz { [IN(LINE)] get => new double3(z, w, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zww { [IN(LINE)] get => new double3(z, w, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zw_ { [IN(LINE)] get => new double3(z, w, 0d); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_x { [IN(LINE)] get => new double3(z, 0d, x); [IN(LINE)] set { z = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_y { [IN(LINE)] get => new double3(z, 0d, y); [IN(LINE)] set { z = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_z { [IN(LINE)] get => new double3(z, 0d, z); [IN(LINE)] set { z = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_w { [IN(LINE)] get => new double3(z, 0d, w); [IN(LINE)] set { z = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z__ { [IN(LINE)] get => new double3(z, 0d, 0d); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxx { [IN(LINE)] get => new double3(w, x, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxy { [IN(LINE)] get => new double3(w, x, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxz { [IN(LINE)] get => new double3(w, x, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxw { [IN(LINE)] get => new double3(w, x, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wx_ { [IN(LINE)] get => new double3(w, x, 0d); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyx { [IN(LINE)] get => new double3(w, y, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyy { [IN(LINE)] get => new double3(w, y, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyz { [IN(LINE)] get => new double3(w, y, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyw { [IN(LINE)] get => new double3(w, y, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wy_ { [IN(LINE)] get => new double3(w, y, 0d); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzx { [IN(LINE)] get => new double3(w, z, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzy { [IN(LINE)] get => new double3(w, z, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzz { [IN(LINE)] get => new double3(w, z, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzw { [IN(LINE)] get => new double3(w, z, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wz_ { [IN(LINE)] get => new double3(w, z, 0d); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwx { [IN(LINE)] get => new double3(w, w, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwy { [IN(LINE)] get => new double3(w, w, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwz { [IN(LINE)] get => new double3(w, w, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 www { [IN(LINE)] get => new double3(w, w, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ww_ { [IN(LINE)] get => new double3(w, w, 0d); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 w_x { [IN(LINE)] get => new double3(w, 0d, x); [IN(LINE)] set { w = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 w_y { [IN(LINE)] get => new double3(w, 0d, y); [IN(LINE)] set { w = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 w_z { [IN(LINE)] get => new double3(w, 0d, z); [IN(LINE)] set { w = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 w_w { [IN(LINE)] get => new double3(w, 0d, w); [IN(LINE)] set { w = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 w__ { [IN(LINE)] get => new double3(w, 0d, 0d); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xx { [IN(LINE)] get => new double3(0d, x, x); [IN(LINE)] set { x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xy { [IN(LINE)] get => new double3(0d, x, y); [IN(LINE)] set { x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xz { [IN(LINE)] get => new double3(0d, x, z); [IN(LINE)] set { x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xw { [IN(LINE)] get => new double3(0d, x, w); [IN(LINE)] set { x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _x_ { [IN(LINE)] get => new double3(0d, x, 0d); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yx { [IN(LINE)] get => new double3(0d, y, x); [IN(LINE)] set { y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yy { [IN(LINE)] get => new double3(0d, y, y); [IN(LINE)] set { y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yz { [IN(LINE)] get => new double3(0d, y, z); [IN(LINE)] set { y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yw { [IN(LINE)] get => new double3(0d, y, w); [IN(LINE)] set { y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _y_ { [IN(LINE)] get => new double3(0d, y, 0d); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zx { [IN(LINE)] get => new double3(0d, z, x); [IN(LINE)] set { z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zy { [IN(LINE)] get => new double3(0d, z, y); [IN(LINE)] set { z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zz { [IN(LINE)] get => new double3(0d, z, z); [IN(LINE)] set { z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zw { [IN(LINE)] get => new double3(0d, z, w); [IN(LINE)] set { z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _z_ { [IN(LINE)] get => new double3(0d, z, 0d); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _wx { [IN(LINE)] get => new double3(0d, w, x); [IN(LINE)] set { w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _wy { [IN(LINE)] get => new double3(0d, w, y); [IN(LINE)] set { w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _wz { [IN(LINE)] get => new double3(0d, w, z); [IN(LINE)] set { w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _ww { [IN(LINE)] get => new double3(0d, w, w); [IN(LINE)] set { w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _w_ { [IN(LINE)] get => new double3(0d, w, 0d); [IN(LINE)] set { w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __x { [IN(LINE)] get => new double3(0d, 0d, x); [IN(LINE)] set { x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __y { [IN(LINE)] get => new double3(0d, 0d, y); [IN(LINE)] set { y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __z { [IN(LINE)] get => new double3(0d, 0d, z); [IN(LINE)] set { z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __w { [IN(LINE)] get => new double3(0d, 0d, w); [IN(LINE)] set { w = value.z; } }
        #endregion

        #region Swizzle4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxx { [IN(LINE)] get => new double4(x, x, x, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxy { [IN(LINE)] get => new double4(x, x, x, y); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxz { [IN(LINE)] get => new double4(x, x, x, z); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxw { [IN(LINE)] get => new double4(x, x, x, w); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxx_ { [IN(LINE)] get => new double4(x, x, x, 0d); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyx { [IN(LINE)] get => new double4(x, x, y, x); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyy { [IN(LINE)] get => new double4(x, x, y, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyz { [IN(LINE)] get => new double4(x, x, y, z); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyw { [IN(LINE)] get => new double4(x, x, y, w); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxy_ { [IN(LINE)] get => new double4(x, x, y, 0d); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzx { [IN(LINE)] get => new double4(x, x, z, x); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzy { [IN(LINE)] get => new double4(x, x, z, y); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzz { [IN(LINE)] get => new double4(x, x, z, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzw { [IN(LINE)] get => new double4(x, x, z, w); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxz_ { [IN(LINE)] get => new double4(x, x, z, 0d); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwx { [IN(LINE)] get => new double4(x, x, w, x); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwy { [IN(LINE)] get => new double4(x, x, w, y); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwz { [IN(LINE)] get => new double4(x, x, w, z); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxww { [IN(LINE)] get => new double4(x, x, w, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxw_ { [IN(LINE)] get => new double4(x, x, w, 0d); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_x { [IN(LINE)] get => new double4(x, x, 0d, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_y { [IN(LINE)] get => new double4(x, x, 0d, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_z { [IN(LINE)] get => new double4(x, x, 0d, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_w { [IN(LINE)] get => new double4(x, x, 0d, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx__ { [IN(LINE)] get => new double4(x, x, 0d, 0d); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxx { [IN(LINE)] get => new double4(x, y, x, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxy { [IN(LINE)] get => new double4(x, y, x, y); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxz { [IN(LINE)] get => new double4(x, y, x, z); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxw { [IN(LINE)] get => new double4(x, y, x, w); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyx_ { [IN(LINE)] get => new double4(x, y, x, 0d); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyx { [IN(LINE)] get => new double4(x, y, y, x); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyy { [IN(LINE)] get => new double4(x, y, y, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyz { [IN(LINE)] get => new double4(x, y, y, z); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyw { [IN(LINE)] get => new double4(x, y, y, w); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyy_ { [IN(LINE)] get => new double4(x, y, y, 0d); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzx { [IN(LINE)] get => new double4(x, y, z, x); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzy { [IN(LINE)] get => new double4(x, y, z, y); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzz { [IN(LINE)] get => new double4(x, y, z, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzw { [IN(LINE)] get => new double4(x, y, z, w); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyz_ { [IN(LINE)] get => new double4(x, y, z, 0d); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywx { [IN(LINE)] get => new double4(x, y, w, x); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywy { [IN(LINE)] get => new double4(x, y, w, y); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywz { [IN(LINE)] get => new double4(x, y, w, z); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyww { [IN(LINE)] get => new double4(x, y, w, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyw_ { [IN(LINE)] get => new double4(x, y, w, 0d); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_x { [IN(LINE)] get => new double4(x, y, 0d, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_y { [IN(LINE)] get => new double4(x, y, 0d, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_z { [IN(LINE)] get => new double4(x, y, 0d, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_w { [IN(LINE)] get => new double4(x, y, 0d, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy__ { [IN(LINE)] get => new double4(x, y, 0d, 0d); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxx { [IN(LINE)] get => new double4(x, z, x, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxy { [IN(LINE)] get => new double4(x, z, x, y); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxz { [IN(LINE)] get => new double4(x, z, x, z); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxw { [IN(LINE)] get => new double4(x, z, x, w); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzx_ { [IN(LINE)] get => new double4(x, z, x, 0d); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyx { [IN(LINE)] get => new double4(x, z, y, x); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyy { [IN(LINE)] get => new double4(x, z, y, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyz { [IN(LINE)] get => new double4(x, z, y, z); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyw { [IN(LINE)] get => new double4(x, z, y, w); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzy_ { [IN(LINE)] get => new double4(x, z, y, 0d); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzx { [IN(LINE)] get => new double4(x, z, z, x); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzy { [IN(LINE)] get => new double4(x, z, z, y); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzz { [IN(LINE)] get => new double4(x, z, z, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzw { [IN(LINE)] get => new double4(x, z, z, w); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzz_ { [IN(LINE)] get => new double4(x, z, z, 0d); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwx { [IN(LINE)] get => new double4(x, z, w, x); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwy { [IN(LINE)] get => new double4(x, z, w, y); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwz { [IN(LINE)] get => new double4(x, z, w, z); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzww { [IN(LINE)] get => new double4(x, z, w, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzw_ { [IN(LINE)] get => new double4(x, z, w, 0d); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_x { [IN(LINE)] get => new double4(x, z, 0d, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_y { [IN(LINE)] get => new double4(x, z, 0d, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_z { [IN(LINE)] get => new double4(x, z, 0d, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_w { [IN(LINE)] get => new double4(x, z, 0d, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz__ { [IN(LINE)] get => new double4(x, z, 0d, 0d); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxx { [IN(LINE)] get => new double4(x, w, x, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxy { [IN(LINE)] get => new double4(x, w, x, y); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxz { [IN(LINE)] get => new double4(x, w, x, z); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxw { [IN(LINE)] get => new double4(x, w, x, w); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwx_ { [IN(LINE)] get => new double4(x, w, x, 0d); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyx { [IN(LINE)] get => new double4(x, w, y, x); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyy { [IN(LINE)] get => new double4(x, w, y, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyz { [IN(LINE)] get => new double4(x, w, y, z); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyw { [IN(LINE)] get => new double4(x, w, y, w); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwy_ { [IN(LINE)] get => new double4(x, w, y, 0d); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzx { [IN(LINE)] get => new double4(x, w, z, x); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzy { [IN(LINE)] get => new double4(x, w, z, y); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzz { [IN(LINE)] get => new double4(x, w, z, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzw { [IN(LINE)] get => new double4(x, w, z, w); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwz_ { [IN(LINE)] get => new double4(x, w, z, 0d); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwx { [IN(LINE)] get => new double4(x, w, w, x); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwy { [IN(LINE)] get => new double4(x, w, w, y); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwz { [IN(LINE)] get => new double4(x, w, w, z); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwww { [IN(LINE)] get => new double4(x, w, w, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xww_ { [IN(LINE)] get => new double4(x, w, w, 0d); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xw_x { [IN(LINE)] get => new double4(x, w, 0d, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xw_y { [IN(LINE)] get => new double4(x, w, 0d, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xw_z { [IN(LINE)] get => new double4(x, w, 0d, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xw_w { [IN(LINE)] get => new double4(x, w, 0d, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xw__ { [IN(LINE)] get => new double4(x, w, 0d, 0d); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xx { [IN(LINE)] get => new double4(x, 0d, x, x); [IN(LINE)] set { x = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xy { [IN(LINE)] get => new double4(x, 0d, x, y); [IN(LINE)] set { x = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xz { [IN(LINE)] get => new double4(x, 0d, x, z); [IN(LINE)] set { x = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xw { [IN(LINE)] get => new double4(x, 0d, x, w); [IN(LINE)] set { x = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_x_ { [IN(LINE)] get => new double4(x, 0d, x, 0d); [IN(LINE)] set { x = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yx { [IN(LINE)] get => new double4(x, 0d, y, x); [IN(LINE)] set { x = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yy { [IN(LINE)] get => new double4(x, 0d, y, y); [IN(LINE)] set { x = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yz { [IN(LINE)] get => new double4(x, 0d, y, z); [IN(LINE)] set { x = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yw { [IN(LINE)] get => new double4(x, 0d, y, w); [IN(LINE)] set { x = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_y_ { [IN(LINE)] get => new double4(x, 0d, y, 0d); [IN(LINE)] set { x = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zx { [IN(LINE)] get => new double4(x, 0d, z, x); [IN(LINE)] set { x = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zy { [IN(LINE)] get => new double4(x, 0d, z, y); [IN(LINE)] set { x = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zz { [IN(LINE)] get => new double4(x, 0d, z, z); [IN(LINE)] set { x = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zw { [IN(LINE)] get => new double4(x, 0d, z, w); [IN(LINE)] set { x = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_z_ { [IN(LINE)] get => new double4(x, 0d, z, 0d); [IN(LINE)] set { x = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_wx { [IN(LINE)] get => new double4(x, 0d, w, x); [IN(LINE)] set { x = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_wy { [IN(LINE)] get => new double4(x, 0d, w, y); [IN(LINE)] set { x = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_wz { [IN(LINE)] get => new double4(x, 0d, w, z); [IN(LINE)] set { x = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_ww { [IN(LINE)] get => new double4(x, 0d, w, w); [IN(LINE)] set { x = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_w_ { [IN(LINE)] get => new double4(x, 0d, w, 0d); [IN(LINE)] set { x = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__x { [IN(LINE)] get => new double4(x, 0d, 0d, x); [IN(LINE)] set { x = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__y { [IN(LINE)] get => new double4(x, 0d, 0d, y); [IN(LINE)] set { x = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__z { [IN(LINE)] get => new double4(x, 0d, 0d, z); [IN(LINE)] set { x = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__w { [IN(LINE)] get => new double4(x, 0d, 0d, w); [IN(LINE)] set { x = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x___ { [IN(LINE)] get => new double4(x, 0d, 0d, 0d); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxx { [IN(LINE)] get => new double4(y, x, x, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxy { [IN(LINE)] get => new double4(y, x, x, y); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxz { [IN(LINE)] get => new double4(y, x, x, z); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxw { [IN(LINE)] get => new double4(y, x, x, w); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxx_ { [IN(LINE)] get => new double4(y, x, x, 0d); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyx { [IN(LINE)] get => new double4(y, x, y, x); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyy { [IN(LINE)] get => new double4(y, x, y, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyz { [IN(LINE)] get => new double4(y, x, y, z); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyw { [IN(LINE)] get => new double4(y, x, y, w); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxy_ { [IN(LINE)] get => new double4(y, x, y, 0d); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzx { [IN(LINE)] get => new double4(y, x, z, x); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzy { [IN(LINE)] get => new double4(y, x, z, y); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzz { [IN(LINE)] get => new double4(y, x, z, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzw { [IN(LINE)] get => new double4(y, x, z, w); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxz_ { [IN(LINE)] get => new double4(y, x, z, 0d); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwx { [IN(LINE)] get => new double4(y, x, w, x); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwy { [IN(LINE)] get => new double4(y, x, w, y); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwz { [IN(LINE)] get => new double4(y, x, w, z); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxww { [IN(LINE)] get => new double4(y, x, w, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxw_ { [IN(LINE)] get => new double4(y, x, w, 0d); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_x { [IN(LINE)] get => new double4(y, x, 0d, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_y { [IN(LINE)] get => new double4(y, x, 0d, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_z { [IN(LINE)] get => new double4(y, x, 0d, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_w { [IN(LINE)] get => new double4(y, x, 0d, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx__ { [IN(LINE)] get => new double4(y, x, 0d, 0d); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxx { [IN(LINE)] get => new double4(y, y, x, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxy { [IN(LINE)] get => new double4(y, y, x, y); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxz { [IN(LINE)] get => new double4(y, y, x, z); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxw { [IN(LINE)] get => new double4(y, y, x, w); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyx_ { [IN(LINE)] get => new double4(y, y, x, 0d); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyx { [IN(LINE)] get => new double4(y, y, y, x); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyy { [IN(LINE)] get => new double4(y, y, y, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyz { [IN(LINE)] get => new double4(y, y, y, z); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyw { [IN(LINE)] get => new double4(y, y, y, w); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyy_ { [IN(LINE)] get => new double4(y, y, y, 0d); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzx { [IN(LINE)] get => new double4(y, y, z, x); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzy { [IN(LINE)] get => new double4(y, y, z, y); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzz { [IN(LINE)] get => new double4(y, y, z, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzw { [IN(LINE)] get => new double4(y, y, z, w); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyz_ { [IN(LINE)] get => new double4(y, y, z, 0d); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywx { [IN(LINE)] get => new double4(y, y, w, x); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywy { [IN(LINE)] get => new double4(y, y, w, y); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywz { [IN(LINE)] get => new double4(y, y, w, z); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyww { [IN(LINE)] get => new double4(y, y, w, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyw_ { [IN(LINE)] get => new double4(y, y, w, 0d); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_x { [IN(LINE)] get => new double4(y, y, 0d, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_y { [IN(LINE)] get => new double4(y, y, 0d, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_z { [IN(LINE)] get => new double4(y, y, 0d, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_w { [IN(LINE)] get => new double4(y, y, 0d, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy__ { [IN(LINE)] get => new double4(y, y, 0d, 0d); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxx { [IN(LINE)] get => new double4(y, z, x, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxy { [IN(LINE)] get => new double4(y, z, x, y); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxz { [IN(LINE)] get => new double4(y, z, x, z); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxw { [IN(LINE)] get => new double4(y, z, x, w); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzx_ { [IN(LINE)] get => new double4(y, z, x, 0d); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyx { [IN(LINE)] get => new double4(y, z, y, x); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyy { [IN(LINE)] get => new double4(y, z, y, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyz { [IN(LINE)] get => new double4(y, z, y, z); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyw { [IN(LINE)] get => new double4(y, z, y, w); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzy_ { [IN(LINE)] get => new double4(y, z, y, 0d); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzx { [IN(LINE)] get => new double4(y, z, z, x); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzy { [IN(LINE)] get => new double4(y, z, z, y); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzz { [IN(LINE)] get => new double4(y, z, z, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzw { [IN(LINE)] get => new double4(y, z, z, w); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzz_ { [IN(LINE)] get => new double4(y, z, z, 0d); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwx { [IN(LINE)] get => new double4(y, z, w, x); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwy { [IN(LINE)] get => new double4(y, z, w, y); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwz { [IN(LINE)] get => new double4(y, z, w, z); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzww { [IN(LINE)] get => new double4(y, z, w, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzw_ { [IN(LINE)] get => new double4(y, z, w, 0d); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_x { [IN(LINE)] get => new double4(y, z, 0d, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_y { [IN(LINE)] get => new double4(y, z, 0d, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_z { [IN(LINE)] get => new double4(y, z, 0d, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_w { [IN(LINE)] get => new double4(y, z, 0d, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz__ { [IN(LINE)] get => new double4(y, z, 0d, 0d); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxx { [IN(LINE)] get => new double4(y, w, x, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxy { [IN(LINE)] get => new double4(y, w, x, y); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxz { [IN(LINE)] get => new double4(y, w, x, z); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxw { [IN(LINE)] get => new double4(y, w, x, w); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywx_ { [IN(LINE)] get => new double4(y, w, x, 0d); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyx { [IN(LINE)] get => new double4(y, w, y, x); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyy { [IN(LINE)] get => new double4(y, w, y, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyz { [IN(LINE)] get => new double4(y, w, y, z); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyw { [IN(LINE)] get => new double4(y, w, y, w); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywy_ { [IN(LINE)] get => new double4(y, w, y, 0d); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzx { [IN(LINE)] get => new double4(y, w, z, x); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzy { [IN(LINE)] get => new double4(y, w, z, y); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzz { [IN(LINE)] get => new double4(y, w, z, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzw { [IN(LINE)] get => new double4(y, w, z, w); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywz_ { [IN(LINE)] get => new double4(y, w, z, 0d); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwx { [IN(LINE)] get => new double4(y, w, w, x); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwy { [IN(LINE)] get => new double4(y, w, w, y); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwz { [IN(LINE)] get => new double4(y, w, w, z); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywww { [IN(LINE)] get => new double4(y, w, w, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yww_ { [IN(LINE)] get => new double4(y, w, w, 0d); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yw_x { [IN(LINE)] get => new double4(y, w, 0d, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yw_y { [IN(LINE)] get => new double4(y, w, 0d, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yw_z { [IN(LINE)] get => new double4(y, w, 0d, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yw_w { [IN(LINE)] get => new double4(y, w, 0d, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yw__ { [IN(LINE)] get => new double4(y, w, 0d, 0d); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xx { [IN(LINE)] get => new double4(y, 0d, x, x); [IN(LINE)] set { y = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xy { [IN(LINE)] get => new double4(y, 0d, x, y); [IN(LINE)] set { y = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xz { [IN(LINE)] get => new double4(y, 0d, x, z); [IN(LINE)] set { y = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xw { [IN(LINE)] get => new double4(y, 0d, x, w); [IN(LINE)] set { y = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_x_ { [IN(LINE)] get => new double4(y, 0d, x, 0d); [IN(LINE)] set { y = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yx { [IN(LINE)] get => new double4(y, 0d, y, x); [IN(LINE)] set { y = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yy { [IN(LINE)] get => new double4(y, 0d, y, y); [IN(LINE)] set { y = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yz { [IN(LINE)] get => new double4(y, 0d, y, z); [IN(LINE)] set { y = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yw { [IN(LINE)] get => new double4(y, 0d, y, w); [IN(LINE)] set { y = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_y_ { [IN(LINE)] get => new double4(y, 0d, y, 0d); [IN(LINE)] set { y = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zx { [IN(LINE)] get => new double4(y, 0d, z, x); [IN(LINE)] set { y = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zy { [IN(LINE)] get => new double4(y, 0d, z, y); [IN(LINE)] set { y = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zz { [IN(LINE)] get => new double4(y, 0d, z, z); [IN(LINE)] set { y = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zw { [IN(LINE)] get => new double4(y, 0d, z, w); [IN(LINE)] set { y = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_z_ { [IN(LINE)] get => new double4(y, 0d, z, 0d); [IN(LINE)] set { y = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_wx { [IN(LINE)] get => new double4(y, 0d, w, x); [IN(LINE)] set { y = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_wy { [IN(LINE)] get => new double4(y, 0d, w, y); [IN(LINE)] set { y = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_wz { [IN(LINE)] get => new double4(y, 0d, w, z); [IN(LINE)] set { y = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_ww { [IN(LINE)] get => new double4(y, 0d, w, w); [IN(LINE)] set { y = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_w_ { [IN(LINE)] get => new double4(y, 0d, w, 0d); [IN(LINE)] set { y = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__x { [IN(LINE)] get => new double4(y, 0d, 0d, x); [IN(LINE)] set { y = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__y { [IN(LINE)] get => new double4(y, 0d, 0d, y); [IN(LINE)] set { y = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__z { [IN(LINE)] get => new double4(y, 0d, 0d, z); [IN(LINE)] set { y = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__w { [IN(LINE)] get => new double4(y, 0d, 0d, w); [IN(LINE)] set { y = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y___ { [IN(LINE)] get => new double4(y, 0d, 0d, 0d); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxx { [IN(LINE)] get => new double4(z, x, x, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxy { [IN(LINE)] get => new double4(z, x, x, y); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxz { [IN(LINE)] get => new double4(z, x, x, z); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxw { [IN(LINE)] get => new double4(z, x, x, w); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxx_ { [IN(LINE)] get => new double4(z, x, x, 0d); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyx { [IN(LINE)] get => new double4(z, x, y, x); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyy { [IN(LINE)] get => new double4(z, x, y, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyz { [IN(LINE)] get => new double4(z, x, y, z); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyw { [IN(LINE)] get => new double4(z, x, y, w); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxy_ { [IN(LINE)] get => new double4(z, x, y, 0d); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzx { [IN(LINE)] get => new double4(z, x, z, x); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzy { [IN(LINE)] get => new double4(z, x, z, y); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzz { [IN(LINE)] get => new double4(z, x, z, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzw { [IN(LINE)] get => new double4(z, x, z, w); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxz_ { [IN(LINE)] get => new double4(z, x, z, 0d); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwx { [IN(LINE)] get => new double4(z, x, w, x); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwy { [IN(LINE)] get => new double4(z, x, w, y); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwz { [IN(LINE)] get => new double4(z, x, w, z); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxww { [IN(LINE)] get => new double4(z, x, w, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxw_ { [IN(LINE)] get => new double4(z, x, w, 0d); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_x { [IN(LINE)] get => new double4(z, x, 0d, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_y { [IN(LINE)] get => new double4(z, x, 0d, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_z { [IN(LINE)] get => new double4(z, x, 0d, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_w { [IN(LINE)] get => new double4(z, x, 0d, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx__ { [IN(LINE)] get => new double4(z, x, 0d, 0d); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxx { [IN(LINE)] get => new double4(z, y, x, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxy { [IN(LINE)] get => new double4(z, y, x, y); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxz { [IN(LINE)] get => new double4(z, y, x, z); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxw { [IN(LINE)] get => new double4(z, y, x, w); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyx_ { [IN(LINE)] get => new double4(z, y, x, 0d); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyx { [IN(LINE)] get => new double4(z, y, y, x); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyy { [IN(LINE)] get => new double4(z, y, y, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyz { [IN(LINE)] get => new double4(z, y, y, z); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyw { [IN(LINE)] get => new double4(z, y, y, w); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyy_ { [IN(LINE)] get => new double4(z, y, y, 0d); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzx { [IN(LINE)] get => new double4(z, y, z, x); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzy { [IN(LINE)] get => new double4(z, y, z, y); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzz { [IN(LINE)] get => new double4(z, y, z, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzw { [IN(LINE)] get => new double4(z, y, z, w); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyz_ { [IN(LINE)] get => new double4(z, y, z, 0d); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywx { [IN(LINE)] get => new double4(z, y, w, x); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywy { [IN(LINE)] get => new double4(z, y, w, y); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywz { [IN(LINE)] get => new double4(z, y, w, z); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyww { [IN(LINE)] get => new double4(z, y, w, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyw_ { [IN(LINE)] get => new double4(z, y, w, 0d); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_x { [IN(LINE)] get => new double4(z, y, 0d, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_y { [IN(LINE)] get => new double4(z, y, 0d, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_z { [IN(LINE)] get => new double4(z, y, 0d, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_w { [IN(LINE)] get => new double4(z, y, 0d, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy__ { [IN(LINE)] get => new double4(z, y, 0d, 0d); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxx { [IN(LINE)] get => new double4(z, z, x, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxy { [IN(LINE)] get => new double4(z, z, x, y); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxz { [IN(LINE)] get => new double4(z, z, x, z); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxw { [IN(LINE)] get => new double4(z, z, x, w); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzx_ { [IN(LINE)] get => new double4(z, z, x, 0d); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyx { [IN(LINE)] get => new double4(z, z, y, x); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyy { [IN(LINE)] get => new double4(z, z, y, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyz { [IN(LINE)] get => new double4(z, z, y, z); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyw { [IN(LINE)] get => new double4(z, z, y, w); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzy_ { [IN(LINE)] get => new double4(z, z, y, 0d); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzx { [IN(LINE)] get => new double4(z, z, z, x); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzy { [IN(LINE)] get => new double4(z, z, z, y); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzz { [IN(LINE)] get => new double4(z, z, z, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzw { [IN(LINE)] get => new double4(z, z, z, w); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzz_ { [IN(LINE)] get => new double4(z, z, z, 0d); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwx { [IN(LINE)] get => new double4(z, z, w, x); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwy { [IN(LINE)] get => new double4(z, z, w, y); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwz { [IN(LINE)] get => new double4(z, z, w, z); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzww { [IN(LINE)] get => new double4(z, z, w, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzw_ { [IN(LINE)] get => new double4(z, z, w, 0d); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_x { [IN(LINE)] get => new double4(z, z, 0d, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_y { [IN(LINE)] get => new double4(z, z, 0d, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_z { [IN(LINE)] get => new double4(z, z, 0d, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_w { [IN(LINE)] get => new double4(z, z, 0d, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz__ { [IN(LINE)] get => new double4(z, z, 0d, 0d); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxx { [IN(LINE)] get => new double4(z, w, x, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxy { [IN(LINE)] get => new double4(z, w, x, y); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxz { [IN(LINE)] get => new double4(z, w, x, z); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxw { [IN(LINE)] get => new double4(z, w, x, w); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwx_ { [IN(LINE)] get => new double4(z, w, x, 0d); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyx { [IN(LINE)] get => new double4(z, w, y, x); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyy { [IN(LINE)] get => new double4(z, w, y, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyz { [IN(LINE)] get => new double4(z, w, y, z); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyw { [IN(LINE)] get => new double4(z, w, y, w); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwy_ { [IN(LINE)] get => new double4(z, w, y, 0d); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzx { [IN(LINE)] get => new double4(z, w, z, x); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzy { [IN(LINE)] get => new double4(z, w, z, y); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzz { [IN(LINE)] get => new double4(z, w, z, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzw { [IN(LINE)] get => new double4(z, w, z, w); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwz_ { [IN(LINE)] get => new double4(z, w, z, 0d); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwx { [IN(LINE)] get => new double4(z, w, w, x); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwy { [IN(LINE)] get => new double4(z, w, w, y); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwz { [IN(LINE)] get => new double4(z, w, w, z); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwww { [IN(LINE)] get => new double4(z, w, w, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zww_ { [IN(LINE)] get => new double4(z, w, w, 0d); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zw_x { [IN(LINE)] get => new double4(z, w, 0d, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zw_y { [IN(LINE)] get => new double4(z, w, 0d, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zw_z { [IN(LINE)] get => new double4(z, w, 0d, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zw_w { [IN(LINE)] get => new double4(z, w, 0d, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zw__ { [IN(LINE)] get => new double4(z, w, 0d, 0d); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xx { [IN(LINE)] get => new double4(z, 0d, x, x); [IN(LINE)] set { z = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xy { [IN(LINE)] get => new double4(z, 0d, x, y); [IN(LINE)] set { z = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xz { [IN(LINE)] get => new double4(z, 0d, x, z); [IN(LINE)] set { z = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xw { [IN(LINE)] get => new double4(z, 0d, x, w); [IN(LINE)] set { z = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_x_ { [IN(LINE)] get => new double4(z, 0d, x, 0d); [IN(LINE)] set { z = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yx { [IN(LINE)] get => new double4(z, 0d, y, x); [IN(LINE)] set { z = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yy { [IN(LINE)] get => new double4(z, 0d, y, y); [IN(LINE)] set { z = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yz { [IN(LINE)] get => new double4(z, 0d, y, z); [IN(LINE)] set { z = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yw { [IN(LINE)] get => new double4(z, 0d, y, w); [IN(LINE)] set { z = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_y_ { [IN(LINE)] get => new double4(z, 0d, y, 0d); [IN(LINE)] set { z = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zx { [IN(LINE)] get => new double4(z, 0d, z, x); [IN(LINE)] set { z = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zy { [IN(LINE)] get => new double4(z, 0d, z, y); [IN(LINE)] set { z = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zz { [IN(LINE)] get => new double4(z, 0d, z, z); [IN(LINE)] set { z = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zw { [IN(LINE)] get => new double4(z, 0d, z, w); [IN(LINE)] set { z = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_z_ { [IN(LINE)] get => new double4(z, 0d, z, 0d); [IN(LINE)] set { z = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_wx { [IN(LINE)] get => new double4(z, 0d, w, x); [IN(LINE)] set { z = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_wy { [IN(LINE)] get => new double4(z, 0d, w, y); [IN(LINE)] set { z = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_wz { [IN(LINE)] get => new double4(z, 0d, w, z); [IN(LINE)] set { z = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_ww { [IN(LINE)] get => new double4(z, 0d, w, w); [IN(LINE)] set { z = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_w_ { [IN(LINE)] get => new double4(z, 0d, w, 0d); [IN(LINE)] set { z = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__x { [IN(LINE)] get => new double4(z, 0d, 0d, x); [IN(LINE)] set { z = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__y { [IN(LINE)] get => new double4(z, 0d, 0d, y); [IN(LINE)] set { z = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__z { [IN(LINE)] get => new double4(z, 0d, 0d, z); [IN(LINE)] set { z = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__w { [IN(LINE)] get => new double4(z, 0d, 0d, w); [IN(LINE)] set { z = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z___ { [IN(LINE)] get => new double4(z, 0d, 0d, 0d); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxx { [IN(LINE)] get => new double4(w, x, x, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxy { [IN(LINE)] get => new double4(w, x, x, y); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxz { [IN(LINE)] get => new double4(w, x, x, z); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxw { [IN(LINE)] get => new double4(w, x, x, w); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxx_ { [IN(LINE)] get => new double4(w, x, x, 0d); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyx { [IN(LINE)] get => new double4(w, x, y, x); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyy { [IN(LINE)] get => new double4(w, x, y, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyz { [IN(LINE)] get => new double4(w, x, y, z); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyw { [IN(LINE)] get => new double4(w, x, y, w); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxy_ { [IN(LINE)] get => new double4(w, x, y, 0d); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzx { [IN(LINE)] get => new double4(w, x, z, x); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzy { [IN(LINE)] get => new double4(w, x, z, y); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzz { [IN(LINE)] get => new double4(w, x, z, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzw { [IN(LINE)] get => new double4(w, x, z, w); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxz_ { [IN(LINE)] get => new double4(w, x, z, 0d); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwx { [IN(LINE)] get => new double4(w, x, w, x); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwy { [IN(LINE)] get => new double4(w, x, w, y); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwz { [IN(LINE)] get => new double4(w, x, w, z); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxww { [IN(LINE)] get => new double4(w, x, w, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxw_ { [IN(LINE)] get => new double4(w, x, w, 0d); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wx_x { [IN(LINE)] get => new double4(w, x, 0d, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wx_y { [IN(LINE)] get => new double4(w, x, 0d, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wx_z { [IN(LINE)] get => new double4(w, x, 0d, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wx_w { [IN(LINE)] get => new double4(w, x, 0d, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wx__ { [IN(LINE)] get => new double4(w, x, 0d, 0d); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxx { [IN(LINE)] get => new double4(w, y, x, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxy { [IN(LINE)] get => new double4(w, y, x, y); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxz { [IN(LINE)] get => new double4(w, y, x, z); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxw { [IN(LINE)] get => new double4(w, y, x, w); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyx_ { [IN(LINE)] get => new double4(w, y, x, 0d); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyx { [IN(LINE)] get => new double4(w, y, y, x); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyy { [IN(LINE)] get => new double4(w, y, y, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyz { [IN(LINE)] get => new double4(w, y, y, z); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyw { [IN(LINE)] get => new double4(w, y, y, w); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyy_ { [IN(LINE)] get => new double4(w, y, y, 0d); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzx { [IN(LINE)] get => new double4(w, y, z, x); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzy { [IN(LINE)] get => new double4(w, y, z, y); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzz { [IN(LINE)] get => new double4(w, y, z, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzw { [IN(LINE)] get => new double4(w, y, z, w); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyz_ { [IN(LINE)] get => new double4(w, y, z, 0d); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywx { [IN(LINE)] get => new double4(w, y, w, x); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywy { [IN(LINE)] get => new double4(w, y, w, y); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywz { [IN(LINE)] get => new double4(w, y, w, z); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyww { [IN(LINE)] get => new double4(w, y, w, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyw_ { [IN(LINE)] get => new double4(w, y, w, 0d); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wy_x { [IN(LINE)] get => new double4(w, y, 0d, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wy_y { [IN(LINE)] get => new double4(w, y, 0d, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wy_z { [IN(LINE)] get => new double4(w, y, 0d, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wy_w { [IN(LINE)] get => new double4(w, y, 0d, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wy__ { [IN(LINE)] get => new double4(w, y, 0d, 0d); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxx { [IN(LINE)] get => new double4(w, z, x, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxy { [IN(LINE)] get => new double4(w, z, x, y); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxz { [IN(LINE)] get => new double4(w, z, x, z); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxw { [IN(LINE)] get => new double4(w, z, x, w); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzx_ { [IN(LINE)] get => new double4(w, z, x, 0d); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyx { [IN(LINE)] get => new double4(w, z, y, x); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyy { [IN(LINE)] get => new double4(w, z, y, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyz { [IN(LINE)] get => new double4(w, z, y, z); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyw { [IN(LINE)] get => new double4(w, z, y, w); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzy_ { [IN(LINE)] get => new double4(w, z, y, 0d); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzx { [IN(LINE)] get => new double4(w, z, z, x); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzy { [IN(LINE)] get => new double4(w, z, z, y); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzz { [IN(LINE)] get => new double4(w, z, z, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzw { [IN(LINE)] get => new double4(w, z, z, w); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzz_ { [IN(LINE)] get => new double4(w, z, z, 0d); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwx { [IN(LINE)] get => new double4(w, z, w, x); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwy { [IN(LINE)] get => new double4(w, z, w, y); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwz { [IN(LINE)] get => new double4(w, z, w, z); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzww { [IN(LINE)] get => new double4(w, z, w, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzw_ { [IN(LINE)] get => new double4(w, z, w, 0d); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wz_x { [IN(LINE)] get => new double4(w, z, 0d, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wz_y { [IN(LINE)] get => new double4(w, z, 0d, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wz_z { [IN(LINE)] get => new double4(w, z, 0d, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wz_w { [IN(LINE)] get => new double4(w, z, 0d, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wz__ { [IN(LINE)] get => new double4(w, z, 0d, 0d); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxx { [IN(LINE)] get => new double4(w, w, x, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxy { [IN(LINE)] get => new double4(w, w, x, y); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxz { [IN(LINE)] get => new double4(w, w, x, z); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxw { [IN(LINE)] get => new double4(w, w, x, w); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwx_ { [IN(LINE)] get => new double4(w, w, x, 0d); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyx { [IN(LINE)] get => new double4(w, w, y, x); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyy { [IN(LINE)] get => new double4(w, w, y, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyz { [IN(LINE)] get => new double4(w, w, y, z); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyw { [IN(LINE)] get => new double4(w, w, y, w); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwy_ { [IN(LINE)] get => new double4(w, w, y, 0d); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzx { [IN(LINE)] get => new double4(w, w, z, x); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzy { [IN(LINE)] get => new double4(w, w, z, y); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzz { [IN(LINE)] get => new double4(w, w, z, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzw { [IN(LINE)] get => new double4(w, w, z, w); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwz_ { [IN(LINE)] get => new double4(w, w, z, 0d); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwx { [IN(LINE)] get => new double4(w, w, w, x); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwy { [IN(LINE)] get => new double4(w, w, w, y); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwz { [IN(LINE)] get => new double4(w, w, w, z); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwww { [IN(LINE)] get => new double4(w, w, w, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 www_ { [IN(LINE)] get => new double4(w, w, w, 0d); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ww_x { [IN(LINE)] get => new double4(w, w, 0d, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ww_y { [IN(LINE)] get => new double4(w, w, 0d, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ww_z { [IN(LINE)] get => new double4(w, w, 0d, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ww_w { [IN(LINE)] get => new double4(w, w, 0d, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ww__ { [IN(LINE)] get => new double4(w, w, 0d, 0d); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_xx { [IN(LINE)] get => new double4(w, 0d, x, x); [IN(LINE)] set { w = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_xy { [IN(LINE)] get => new double4(w, 0d, x, y); [IN(LINE)] set { w = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_xz { [IN(LINE)] get => new double4(w, 0d, x, z); [IN(LINE)] set { w = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_xw { [IN(LINE)] get => new double4(w, 0d, x, w); [IN(LINE)] set { w = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_x_ { [IN(LINE)] get => new double4(w, 0d, x, 0d); [IN(LINE)] set { w = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_yx { [IN(LINE)] get => new double4(w, 0d, y, x); [IN(LINE)] set { w = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_yy { [IN(LINE)] get => new double4(w, 0d, y, y); [IN(LINE)] set { w = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_yz { [IN(LINE)] get => new double4(w, 0d, y, z); [IN(LINE)] set { w = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_yw { [IN(LINE)] get => new double4(w, 0d, y, w); [IN(LINE)] set { w = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_y_ { [IN(LINE)] get => new double4(w, 0d, y, 0d); [IN(LINE)] set { w = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_zx { [IN(LINE)] get => new double4(w, 0d, z, x); [IN(LINE)] set { w = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_zy { [IN(LINE)] get => new double4(w, 0d, z, y); [IN(LINE)] set { w = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_zz { [IN(LINE)] get => new double4(w, 0d, z, z); [IN(LINE)] set { w = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_zw { [IN(LINE)] get => new double4(w, 0d, z, w); [IN(LINE)] set { w = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_z_ { [IN(LINE)] get => new double4(w, 0d, z, 0d); [IN(LINE)] set { w = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_wx { [IN(LINE)] get => new double4(w, 0d, w, x); [IN(LINE)] set { w = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_wy { [IN(LINE)] get => new double4(w, 0d, w, y); [IN(LINE)] set { w = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_wz { [IN(LINE)] get => new double4(w, 0d, w, z); [IN(LINE)] set { w = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_ww { [IN(LINE)] get => new double4(w, 0d, w, w); [IN(LINE)] set { w = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w_w_ { [IN(LINE)] get => new double4(w, 0d, w, 0d); [IN(LINE)] set { w = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w__x { [IN(LINE)] get => new double4(w, 0d, 0d, x); [IN(LINE)] set { w = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w__y { [IN(LINE)] get => new double4(w, 0d, 0d, y); [IN(LINE)] set { w = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w__z { [IN(LINE)] get => new double4(w, 0d, 0d, z); [IN(LINE)] set { w = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w__w { [IN(LINE)] get => new double4(w, 0d, 0d, w); [IN(LINE)] set { w = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 w___ { [IN(LINE)] get => new double4(w, 0d, 0d, 0d); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxx { [IN(LINE)] get => new double4(0d, x, x, x); [IN(LINE)] set { x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxy { [IN(LINE)] get => new double4(0d, x, x, y); [IN(LINE)] set { x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxz { [IN(LINE)] get => new double4(0d, x, x, z); [IN(LINE)] set { x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxw { [IN(LINE)] get => new double4(0d, x, x, w); [IN(LINE)] set { x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xx_ { [IN(LINE)] get => new double4(0d, x, x, 0d); [IN(LINE)] set { x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyx { [IN(LINE)] get => new double4(0d, x, y, x); [IN(LINE)] set { x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyy { [IN(LINE)] get => new double4(0d, x, y, y); [IN(LINE)] set { x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyz { [IN(LINE)] get => new double4(0d, x, y, z); [IN(LINE)] set { x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyw { [IN(LINE)] get => new double4(0d, x, y, w); [IN(LINE)] set { x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xy_ { [IN(LINE)] get => new double4(0d, x, y, 0d); [IN(LINE)] set { x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzx { [IN(LINE)] get => new double4(0d, x, z, x); [IN(LINE)] set { x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzy { [IN(LINE)] get => new double4(0d, x, z, y); [IN(LINE)] set { x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzz { [IN(LINE)] get => new double4(0d, x, z, z); [IN(LINE)] set { x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzw { [IN(LINE)] get => new double4(0d, x, z, w); [IN(LINE)] set { x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xz_ { [IN(LINE)] get => new double4(0d, x, z, 0d); [IN(LINE)] set { x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xwx { [IN(LINE)] get => new double4(0d, x, w, x); [IN(LINE)] set { x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xwy { [IN(LINE)] get => new double4(0d, x, w, y); [IN(LINE)] set { x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xwz { [IN(LINE)] get => new double4(0d, x, w, z); [IN(LINE)] set { x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xww { [IN(LINE)] get => new double4(0d, x, w, w); [IN(LINE)] set { x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xw_ { [IN(LINE)] get => new double4(0d, x, w, 0d); [IN(LINE)] set { x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_x { [IN(LINE)] get => new double4(0d, x, 0d, x); [IN(LINE)] set { x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_y { [IN(LINE)] get => new double4(0d, x, 0d, y); [IN(LINE)] set { x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_z { [IN(LINE)] get => new double4(0d, x, 0d, z); [IN(LINE)] set { x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_w { [IN(LINE)] get => new double4(0d, x, 0d, w); [IN(LINE)] set { x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x__ { [IN(LINE)] get => new double4(0d, x, 0d, 0d); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxx { [IN(LINE)] get => new double4(0d, y, x, x); [IN(LINE)] set { y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxy { [IN(LINE)] get => new double4(0d, y, x, y); [IN(LINE)] set { y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxz { [IN(LINE)] get => new double4(0d, y, x, z); [IN(LINE)] set { y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxw { [IN(LINE)] get => new double4(0d, y, x, w); [IN(LINE)] set { y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yx_ { [IN(LINE)] get => new double4(0d, y, x, 0d); [IN(LINE)] set { y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyx { [IN(LINE)] get => new double4(0d, y, y, x); [IN(LINE)] set { y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyy { [IN(LINE)] get => new double4(0d, y, y, y); [IN(LINE)] set { y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyz { [IN(LINE)] get => new double4(0d, y, y, z); [IN(LINE)] set { y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyw { [IN(LINE)] get => new double4(0d, y, y, w); [IN(LINE)] set { y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yy_ { [IN(LINE)] get => new double4(0d, y, y, 0d); [IN(LINE)] set { y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzx { [IN(LINE)] get => new double4(0d, y, z, x); [IN(LINE)] set { y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzy { [IN(LINE)] get => new double4(0d, y, z, y); [IN(LINE)] set { y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzz { [IN(LINE)] get => new double4(0d, y, z, z); [IN(LINE)] set { y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzw { [IN(LINE)] get => new double4(0d, y, z, w); [IN(LINE)] set { y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yz_ { [IN(LINE)] get => new double4(0d, y, z, 0d); [IN(LINE)] set { y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _ywx { [IN(LINE)] get => new double4(0d, y, w, x); [IN(LINE)] set { y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _ywy { [IN(LINE)] get => new double4(0d, y, w, y); [IN(LINE)] set { y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _ywz { [IN(LINE)] get => new double4(0d, y, w, z); [IN(LINE)] set { y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yww { [IN(LINE)] get => new double4(0d, y, w, w); [IN(LINE)] set { y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yw_ { [IN(LINE)] get => new double4(0d, y, w, 0d); [IN(LINE)] set { y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_x { [IN(LINE)] get => new double4(0d, y, 0d, x); [IN(LINE)] set { y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_y { [IN(LINE)] get => new double4(0d, y, 0d, y); [IN(LINE)] set { y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_z { [IN(LINE)] get => new double4(0d, y, 0d, z); [IN(LINE)] set { y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_w { [IN(LINE)] get => new double4(0d, y, 0d, w); [IN(LINE)] set { y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y__ { [IN(LINE)] get => new double4(0d, y, 0d, 0d); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxx { [IN(LINE)] get => new double4(0d, z, x, x); [IN(LINE)] set { z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxy { [IN(LINE)] get => new double4(0d, z, x, y); [IN(LINE)] set { z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxz { [IN(LINE)] get => new double4(0d, z, x, z); [IN(LINE)] set { z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxw { [IN(LINE)] get => new double4(0d, z, x, w); [IN(LINE)] set { z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zx_ { [IN(LINE)] get => new double4(0d, z, x, 0d); [IN(LINE)] set { z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyx { [IN(LINE)] get => new double4(0d, z, y, x); [IN(LINE)] set { z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyy { [IN(LINE)] get => new double4(0d, z, y, y); [IN(LINE)] set { z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyz { [IN(LINE)] get => new double4(0d, z, y, z); [IN(LINE)] set { z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyw { [IN(LINE)] get => new double4(0d, z, y, w); [IN(LINE)] set { z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zy_ { [IN(LINE)] get => new double4(0d, z, y, 0d); [IN(LINE)] set { z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzx { [IN(LINE)] get => new double4(0d, z, z, x); [IN(LINE)] set { z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzy { [IN(LINE)] get => new double4(0d, z, z, y); [IN(LINE)] set { z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzz { [IN(LINE)] get => new double4(0d, z, z, z); [IN(LINE)] set { z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzw { [IN(LINE)] get => new double4(0d, z, z, w); [IN(LINE)] set { z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zz_ { [IN(LINE)] get => new double4(0d, z, z, 0d); [IN(LINE)] set { z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zwx { [IN(LINE)] get => new double4(0d, z, w, x); [IN(LINE)] set { z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zwy { [IN(LINE)] get => new double4(0d, z, w, y); [IN(LINE)] set { z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zwz { [IN(LINE)] get => new double4(0d, z, w, z); [IN(LINE)] set { z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zww { [IN(LINE)] get => new double4(0d, z, w, w); [IN(LINE)] set { z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zw_ { [IN(LINE)] get => new double4(0d, z, w, 0d); [IN(LINE)] set { z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_x { [IN(LINE)] get => new double4(0d, z, 0d, x); [IN(LINE)] set { z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_y { [IN(LINE)] get => new double4(0d, z, 0d, y); [IN(LINE)] set { z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_z { [IN(LINE)] get => new double4(0d, z, 0d, z); [IN(LINE)] set { z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_w { [IN(LINE)] get => new double4(0d, z, 0d, w); [IN(LINE)] set { z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z__ { [IN(LINE)] get => new double4(0d, z, 0d, 0d); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wxx { [IN(LINE)] get => new double4(0d, w, x, x); [IN(LINE)] set { w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wxy { [IN(LINE)] get => new double4(0d, w, x, y); [IN(LINE)] set { w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wxz { [IN(LINE)] get => new double4(0d, w, x, z); [IN(LINE)] set { w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wxw { [IN(LINE)] get => new double4(0d, w, x, w); [IN(LINE)] set { w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wx_ { [IN(LINE)] get => new double4(0d, w, x, 0d); [IN(LINE)] set { w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wyx { [IN(LINE)] get => new double4(0d, w, y, x); [IN(LINE)] set { w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wyy { [IN(LINE)] get => new double4(0d, w, y, y); [IN(LINE)] set { w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wyz { [IN(LINE)] get => new double4(0d, w, y, z); [IN(LINE)] set { w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wyw { [IN(LINE)] get => new double4(0d, w, y, w); [IN(LINE)] set { w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wy_ { [IN(LINE)] get => new double4(0d, w, y, 0d); [IN(LINE)] set { w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wzx { [IN(LINE)] get => new double4(0d, w, z, x); [IN(LINE)] set { w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wzy { [IN(LINE)] get => new double4(0d, w, z, y); [IN(LINE)] set { w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wzz { [IN(LINE)] get => new double4(0d, w, z, z); [IN(LINE)] set { w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wzw { [IN(LINE)] get => new double4(0d, w, z, w); [IN(LINE)] set { w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wz_ { [IN(LINE)] get => new double4(0d, w, z, 0d); [IN(LINE)] set { w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wwx { [IN(LINE)] get => new double4(0d, w, w, x); [IN(LINE)] set { w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wwy { [IN(LINE)] get => new double4(0d, w, w, y); [IN(LINE)] set { w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _wwz { [IN(LINE)] get => new double4(0d, w, w, z); [IN(LINE)] set { w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _www { [IN(LINE)] get => new double4(0d, w, w, w); [IN(LINE)] set { w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _ww_ { [IN(LINE)] get => new double4(0d, w, w, 0d); [IN(LINE)] set { w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _w_x { [IN(LINE)] get => new double4(0d, w, 0d, x); [IN(LINE)] set { w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _w_y { [IN(LINE)] get => new double4(0d, w, 0d, y); [IN(LINE)] set { w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _w_z { [IN(LINE)] get => new double4(0d, w, 0d, z); [IN(LINE)] set { w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _w_w { [IN(LINE)] get => new double4(0d, w, 0d, w); [IN(LINE)] set { w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _w__ { [IN(LINE)] get => new double4(0d, w, 0d, 0d); [IN(LINE)] set { w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xx { [IN(LINE)] get => new double4(0d, 0d, x, x); [IN(LINE)] set { x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xy { [IN(LINE)] get => new double4(0d, 0d, x, y); [IN(LINE)] set { x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xz { [IN(LINE)] get => new double4(0d, 0d, x, z); [IN(LINE)] set { x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xw { [IN(LINE)] get => new double4(0d, 0d, x, w); [IN(LINE)] set { x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __x_ { [IN(LINE)] get => new double4(0d, 0d, x, 0d); [IN(LINE)] set { x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yx { [IN(LINE)] get => new double4(0d, 0d, y, x); [IN(LINE)] set { y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yy { [IN(LINE)] get => new double4(0d, 0d, y, y); [IN(LINE)] set { y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yz { [IN(LINE)] get => new double4(0d, 0d, y, z); [IN(LINE)] set { y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yw { [IN(LINE)] get => new double4(0d, 0d, y, w); [IN(LINE)] set { y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __y_ { [IN(LINE)] get => new double4(0d, 0d, y, 0d); [IN(LINE)] set { y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zx { [IN(LINE)] get => new double4(0d, 0d, z, x); [IN(LINE)] set { z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zy { [IN(LINE)] get => new double4(0d, 0d, z, y); [IN(LINE)] set { z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zz { [IN(LINE)] get => new double4(0d, 0d, z, z); [IN(LINE)] set { z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zw { [IN(LINE)] get => new double4(0d, 0d, z, w); [IN(LINE)] set { z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __z_ { [IN(LINE)] get => new double4(0d, 0d, z, 0d); [IN(LINE)] set { z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __wx { [IN(LINE)] get => new double4(0d, 0d, w, x); [IN(LINE)] set { w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __wy { [IN(LINE)] get => new double4(0d, 0d, w, y); [IN(LINE)] set { w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __wz { [IN(LINE)] get => new double4(0d, 0d, w, z); [IN(LINE)] set { w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __ww { [IN(LINE)] get => new double4(0d, 0d, w, w); [IN(LINE)] set { w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __w_ { [IN(LINE)] get => new double4(0d, 0d, w, 0d); [IN(LINE)] set { w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___x { [IN(LINE)] get => new double4(0d, 0d, 0d, x); [IN(LINE)] set { x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___y { [IN(LINE)] get => new double4(0d, 0d, 0d, y); [IN(LINE)] set { y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___z { [IN(LINE)] get => new double4(0d, 0d, 0d, z); [IN(LINE)] set { z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___w { [IN(LINE)] get => new double4(0d, 0d, 0d, w); [IN(LINE)] set { w = value.w; } }
        #endregion

        #endregion


        #region Other
        [IN(LINE)]
        public /*readonly*/ void CopyTo(Span<double> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            destination[0] = x; destination[1] = y; destination[2] = z; destination[3] = w;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<double, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is double4 target && Equals(target); }
        [IN(LINE)] public bool Equals(double4 a) { return x == a.x && y == a.y && z == a.z && w == a.w; }
        public override string ToString() { return $"double4({x}, {y}, {z}, {w})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public double x, y, z, w;
            public DebuggerProxy(double4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<double, double4> GetEnumerator() { return new VectorEnumerator<double, double4>(this); }
        VectorEnumerator<double, double4> IEnumerableVector<double, double4>.GetEnumerator() { return new VectorEnumerator<double, double4>(this); }
        IEnumerator<double> IEnumerable<double>.GetEnumerator() { return new VectorEnumerator<double, double4>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<double, double4>(this); }
        #endregion
    }
}