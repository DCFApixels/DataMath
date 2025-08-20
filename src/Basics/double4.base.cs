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
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 32)]
    public partial struct double4 :
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
        [EditorBrowsable(EditorBrowsableState.Never)] public int count { [IN(LINE)] get { return Count; } }

        public unsafe double this[int index]
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

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xx { [IN(LINE)] get => new double2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xy { [IN(LINE)] get => new double2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xz { [IN(LINE)] get => new double2(x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 xw { [IN(LINE)] get => new double2(x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yx { [IN(LINE)] get => new double2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yy { [IN(LINE)] get => new double2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yz { [IN(LINE)] get => new double2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yw { [IN(LINE)] get => new double2(y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zx { [IN(LINE)] get => new double2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zy { [IN(LINE)] get => new double2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zz { [IN(LINE)] get => new double2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zw { [IN(LINE)] get => new double2(z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wx { [IN(LINE)] get => new double2(w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wy { [IN(LINE)] get => new double2(w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 wz { [IN(LINE)] get => new double2(w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 ww { [IN(LINE)] get => new double2(w, w); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxx { [IN(LINE)] get => new double3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxy { [IN(LINE)] get => new double3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxz { [IN(LINE)] get => new double3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxw { [IN(LINE)] get => new double3(x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyx { [IN(LINE)] get => new double3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyy { [IN(LINE)] get => new double3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyz { [IN(LINE)] get => new double3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyw { [IN(LINE)] get => new double3(x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzx { [IN(LINE)] get => new double3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzy { [IN(LINE)] get => new double3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzz { [IN(LINE)] get => new double3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzw { [IN(LINE)] get => new double3(x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwx { [IN(LINE)] get => new double3(x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwy { [IN(LINE)] get => new double3(x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xwz { [IN(LINE)] get => new double3(x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xww { [IN(LINE)] get => new double3(x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxx { [IN(LINE)] get => new double3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxy { [IN(LINE)] get => new double3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxz { [IN(LINE)] get => new double3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxw { [IN(LINE)] get => new double3(y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyx { [IN(LINE)] get => new double3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyy { [IN(LINE)] get => new double3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyz { [IN(LINE)] get => new double3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyw { [IN(LINE)] get => new double3(y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzx { [IN(LINE)] get => new double3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzy { [IN(LINE)] get => new double3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzz { [IN(LINE)] get => new double3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzw { [IN(LINE)] get => new double3(y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywx { [IN(LINE)] get => new double3(y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywy { [IN(LINE)] get => new double3(y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 ywz { [IN(LINE)] get => new double3(y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yww { [IN(LINE)] get => new double3(y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxx { [IN(LINE)] get => new double3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxy { [IN(LINE)] get => new double3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxz { [IN(LINE)] get => new double3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxw { [IN(LINE)] get => new double3(z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyx { [IN(LINE)] get => new double3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyy { [IN(LINE)] get => new double3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyz { [IN(LINE)] get => new double3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyw { [IN(LINE)] get => new double3(z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzx { [IN(LINE)] get => new double3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzy { [IN(LINE)] get => new double3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzz { [IN(LINE)] get => new double3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzw { [IN(LINE)] get => new double3(z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwx { [IN(LINE)] get => new double3(z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwy { [IN(LINE)] get => new double3(z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zwz { [IN(LINE)] get => new double3(z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zww { [IN(LINE)] get => new double3(z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxx { [IN(LINE)] get => new double3(w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxy { [IN(LINE)] get => new double3(w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxz { [IN(LINE)] get => new double3(w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wxw { [IN(LINE)] get => new double3(w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyx { [IN(LINE)] get => new double3(w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyy { [IN(LINE)] get => new double3(w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyz { [IN(LINE)] get => new double3(w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wyw { [IN(LINE)] get => new double3(w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzx { [IN(LINE)] get => new double3(w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzy { [IN(LINE)] get => new double3(w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzz { [IN(LINE)] get => new double3(w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wzw { [IN(LINE)] get => new double3(w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwx { [IN(LINE)] get => new double3(w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwy { [IN(LINE)] get => new double3(w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 wwz { [IN(LINE)] get => new double3(w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 www { [IN(LINE)] get => new double3(w, w, w); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxx { [IN(LINE)] get => new double4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxy { [IN(LINE)] get => new double4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxz { [IN(LINE)] get => new double4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxw { [IN(LINE)] get => new double4(x, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyx { [IN(LINE)] get => new double4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyy { [IN(LINE)] get => new double4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyz { [IN(LINE)] get => new double4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyw { [IN(LINE)] get => new double4(x, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzx { [IN(LINE)] get => new double4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzy { [IN(LINE)] get => new double4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzz { [IN(LINE)] get => new double4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzw { [IN(LINE)] get => new double4(x, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwx { [IN(LINE)] get => new double4(x, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwy { [IN(LINE)] get => new double4(x, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxwz { [IN(LINE)] get => new double4(x, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxww { [IN(LINE)] get => new double4(x, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxx { [IN(LINE)] get => new double4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxy { [IN(LINE)] get => new double4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxz { [IN(LINE)] get => new double4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxw { [IN(LINE)] get => new double4(x, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyx { [IN(LINE)] get => new double4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyy { [IN(LINE)] get => new double4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyz { [IN(LINE)] get => new double4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyw { [IN(LINE)] get => new double4(x, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzx { [IN(LINE)] get => new double4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzy { [IN(LINE)] get => new double4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzz { [IN(LINE)] get => new double4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzw { [IN(LINE)] get => new double4(x, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywx { [IN(LINE)] get => new double4(x, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywy { [IN(LINE)] get => new double4(x, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xywz { [IN(LINE)] get => new double4(x, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyww { [IN(LINE)] get => new double4(x, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxx { [IN(LINE)] get => new double4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxy { [IN(LINE)] get => new double4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxz { [IN(LINE)] get => new double4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxw { [IN(LINE)] get => new double4(x, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyx { [IN(LINE)] get => new double4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyy { [IN(LINE)] get => new double4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyz { [IN(LINE)] get => new double4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyw { [IN(LINE)] get => new double4(x, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzx { [IN(LINE)] get => new double4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzy { [IN(LINE)] get => new double4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzz { [IN(LINE)] get => new double4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzw { [IN(LINE)] get => new double4(x, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwx { [IN(LINE)] get => new double4(x, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwy { [IN(LINE)] get => new double4(x, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzwz { [IN(LINE)] get => new double4(x, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzww { [IN(LINE)] get => new double4(x, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxx { [IN(LINE)] get => new double4(x, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxy { [IN(LINE)] get => new double4(x, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxz { [IN(LINE)] get => new double4(x, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwxw { [IN(LINE)] get => new double4(x, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyx { [IN(LINE)] get => new double4(x, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyy { [IN(LINE)] get => new double4(x, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyz { [IN(LINE)] get => new double4(x, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwyw { [IN(LINE)] get => new double4(x, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzx { [IN(LINE)] get => new double4(x, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzy { [IN(LINE)] get => new double4(x, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzz { [IN(LINE)] get => new double4(x, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwzw { [IN(LINE)] get => new double4(x, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwx { [IN(LINE)] get => new double4(x, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwy { [IN(LINE)] get => new double4(x, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwwz { [IN(LINE)] get => new double4(x, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xwww { [IN(LINE)] get => new double4(x, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxx { [IN(LINE)] get => new double4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxy { [IN(LINE)] get => new double4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxz { [IN(LINE)] get => new double4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxw { [IN(LINE)] get => new double4(y, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyx { [IN(LINE)] get => new double4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyy { [IN(LINE)] get => new double4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyz { [IN(LINE)] get => new double4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyw { [IN(LINE)] get => new double4(y, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzx { [IN(LINE)] get => new double4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzy { [IN(LINE)] get => new double4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzz { [IN(LINE)] get => new double4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzw { [IN(LINE)] get => new double4(y, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwx { [IN(LINE)] get => new double4(y, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwy { [IN(LINE)] get => new double4(y, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxwz { [IN(LINE)] get => new double4(y, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxww { [IN(LINE)] get => new double4(y, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxx { [IN(LINE)] get => new double4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxy { [IN(LINE)] get => new double4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxz { [IN(LINE)] get => new double4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxw { [IN(LINE)] get => new double4(y, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyx { [IN(LINE)] get => new double4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyy { [IN(LINE)] get => new double4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyz { [IN(LINE)] get => new double4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyw { [IN(LINE)] get => new double4(y, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzx { [IN(LINE)] get => new double4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzy { [IN(LINE)] get => new double4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzz { [IN(LINE)] get => new double4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzw { [IN(LINE)] get => new double4(y, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywx { [IN(LINE)] get => new double4(y, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywy { [IN(LINE)] get => new double4(y, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yywz { [IN(LINE)] get => new double4(y, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyww { [IN(LINE)] get => new double4(y, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxx { [IN(LINE)] get => new double4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxy { [IN(LINE)] get => new double4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxz { [IN(LINE)] get => new double4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxw { [IN(LINE)] get => new double4(y, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyx { [IN(LINE)] get => new double4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyy { [IN(LINE)] get => new double4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyz { [IN(LINE)] get => new double4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyw { [IN(LINE)] get => new double4(y, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzx { [IN(LINE)] get => new double4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzy { [IN(LINE)] get => new double4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzz { [IN(LINE)] get => new double4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzw { [IN(LINE)] get => new double4(y, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwx { [IN(LINE)] get => new double4(y, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwy { [IN(LINE)] get => new double4(y, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzwz { [IN(LINE)] get => new double4(y, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzww { [IN(LINE)] get => new double4(y, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxx { [IN(LINE)] get => new double4(y, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxy { [IN(LINE)] get => new double4(y, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxz { [IN(LINE)] get => new double4(y, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywxw { [IN(LINE)] get => new double4(y, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyx { [IN(LINE)] get => new double4(y, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyy { [IN(LINE)] get => new double4(y, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyz { [IN(LINE)] get => new double4(y, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywyw { [IN(LINE)] get => new double4(y, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzx { [IN(LINE)] get => new double4(y, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzy { [IN(LINE)] get => new double4(y, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzz { [IN(LINE)] get => new double4(y, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywzw { [IN(LINE)] get => new double4(y, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwx { [IN(LINE)] get => new double4(y, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwy { [IN(LINE)] get => new double4(y, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywwz { [IN(LINE)] get => new double4(y, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ywww { [IN(LINE)] get => new double4(y, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxx { [IN(LINE)] get => new double4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxy { [IN(LINE)] get => new double4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxz { [IN(LINE)] get => new double4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxw { [IN(LINE)] get => new double4(z, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyx { [IN(LINE)] get => new double4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyy { [IN(LINE)] get => new double4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyz { [IN(LINE)] get => new double4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyw { [IN(LINE)] get => new double4(z, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzx { [IN(LINE)] get => new double4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzy { [IN(LINE)] get => new double4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzz { [IN(LINE)] get => new double4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzw { [IN(LINE)] get => new double4(z, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwx { [IN(LINE)] get => new double4(z, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwy { [IN(LINE)] get => new double4(z, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxwz { [IN(LINE)] get => new double4(z, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxww { [IN(LINE)] get => new double4(z, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxx { [IN(LINE)] get => new double4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxy { [IN(LINE)] get => new double4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxz { [IN(LINE)] get => new double4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxw { [IN(LINE)] get => new double4(z, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyx { [IN(LINE)] get => new double4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyy { [IN(LINE)] get => new double4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyz { [IN(LINE)] get => new double4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyw { [IN(LINE)] get => new double4(z, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzx { [IN(LINE)] get => new double4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzy { [IN(LINE)] get => new double4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzz { [IN(LINE)] get => new double4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzw { [IN(LINE)] get => new double4(z, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywx { [IN(LINE)] get => new double4(z, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywy { [IN(LINE)] get => new double4(z, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zywz { [IN(LINE)] get => new double4(z, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyww { [IN(LINE)] get => new double4(z, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxx { [IN(LINE)] get => new double4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxy { [IN(LINE)] get => new double4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxz { [IN(LINE)] get => new double4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxw { [IN(LINE)] get => new double4(z, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyx { [IN(LINE)] get => new double4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyy { [IN(LINE)] get => new double4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyz { [IN(LINE)] get => new double4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyw { [IN(LINE)] get => new double4(z, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzx { [IN(LINE)] get => new double4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzy { [IN(LINE)] get => new double4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzz { [IN(LINE)] get => new double4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzw { [IN(LINE)] get => new double4(z, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwx { [IN(LINE)] get => new double4(z, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwy { [IN(LINE)] get => new double4(z, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzwz { [IN(LINE)] get => new double4(z, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzww { [IN(LINE)] get => new double4(z, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxx { [IN(LINE)] get => new double4(z, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxy { [IN(LINE)] get => new double4(z, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxz { [IN(LINE)] get => new double4(z, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwxw { [IN(LINE)] get => new double4(z, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyx { [IN(LINE)] get => new double4(z, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyy { [IN(LINE)] get => new double4(z, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyz { [IN(LINE)] get => new double4(z, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwyw { [IN(LINE)] get => new double4(z, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzx { [IN(LINE)] get => new double4(z, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzy { [IN(LINE)] get => new double4(z, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzz { [IN(LINE)] get => new double4(z, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwzw { [IN(LINE)] get => new double4(z, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwx { [IN(LINE)] get => new double4(z, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwy { [IN(LINE)] get => new double4(z, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwwz { [IN(LINE)] get => new double4(z, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zwww { [IN(LINE)] get => new double4(z, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxx { [IN(LINE)] get => new double4(w, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxy { [IN(LINE)] get => new double4(w, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxz { [IN(LINE)] get => new double4(w, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxxw { [IN(LINE)] get => new double4(w, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyx { [IN(LINE)] get => new double4(w, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyy { [IN(LINE)] get => new double4(w, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyz { [IN(LINE)] get => new double4(w, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxyw { [IN(LINE)] get => new double4(w, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzx { [IN(LINE)] get => new double4(w, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzy { [IN(LINE)] get => new double4(w, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzz { [IN(LINE)] get => new double4(w, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxzw { [IN(LINE)] get => new double4(w, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwx { [IN(LINE)] get => new double4(w, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwy { [IN(LINE)] get => new double4(w, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxwz { [IN(LINE)] get => new double4(w, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wxww { [IN(LINE)] get => new double4(w, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxx { [IN(LINE)] get => new double4(w, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxy { [IN(LINE)] get => new double4(w, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxz { [IN(LINE)] get => new double4(w, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyxw { [IN(LINE)] get => new double4(w, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyx { [IN(LINE)] get => new double4(w, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyy { [IN(LINE)] get => new double4(w, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyz { [IN(LINE)] get => new double4(w, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyyw { [IN(LINE)] get => new double4(w, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzx { [IN(LINE)] get => new double4(w, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzy { [IN(LINE)] get => new double4(w, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzz { [IN(LINE)] get => new double4(w, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyzw { [IN(LINE)] get => new double4(w, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywx { [IN(LINE)] get => new double4(w, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywy { [IN(LINE)] get => new double4(w, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wywz { [IN(LINE)] get => new double4(w, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wyww { [IN(LINE)] get => new double4(w, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxx { [IN(LINE)] get => new double4(w, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxy { [IN(LINE)] get => new double4(w, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxz { [IN(LINE)] get => new double4(w, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzxw { [IN(LINE)] get => new double4(w, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyx { [IN(LINE)] get => new double4(w, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyy { [IN(LINE)] get => new double4(w, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyz { [IN(LINE)] get => new double4(w, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzyw { [IN(LINE)] get => new double4(w, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzx { [IN(LINE)] get => new double4(w, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzy { [IN(LINE)] get => new double4(w, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzz { [IN(LINE)] get => new double4(w, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzzw { [IN(LINE)] get => new double4(w, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwx { [IN(LINE)] get => new double4(w, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwy { [IN(LINE)] get => new double4(w, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzwz { [IN(LINE)] get => new double4(w, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wzww { [IN(LINE)] get => new double4(w, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxx { [IN(LINE)] get => new double4(w, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxy { [IN(LINE)] get => new double4(w, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxz { [IN(LINE)] get => new double4(w, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwxw { [IN(LINE)] get => new double4(w, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyx { [IN(LINE)] get => new double4(w, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyy { [IN(LINE)] get => new double4(w, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyz { [IN(LINE)] get => new double4(w, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwyw { [IN(LINE)] get => new double4(w, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzx { [IN(LINE)] get => new double4(w, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzy { [IN(LINE)] get => new double4(w, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzz { [IN(LINE)] get => new double4(w, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwzw { [IN(LINE)] get => new double4(w, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwx { [IN(LINE)] get => new double4(w, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwy { [IN(LINE)] get => new double4(w, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwwz { [IN(LINE)] get => new double4(w, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 wwww { [IN(LINE)] get => new double4(w, w, w, w); }
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