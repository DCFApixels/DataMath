#if DISABLE_DEBUG
#undef DEBUG
#endif
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 24)]
    public partial struct double3 :
        IEquatable<double3>,
        IFormattable,
        IVector3<double>,
        IColor,
        IEnumerableVector<double, double3>
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly double3 zero = new double3(0d, 0d, 0d);
        ///<summary>(1, 1, 1)</summary>
        public static readonly double3 one = new double3(1d, 1d, 1d);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly double3 left = new double3(-1d, 0d, 0d);
        ///<summary>(1, 0, 0)</summary>
        public static readonly double3 right = new double3(1d, 0d, 0d);
        ///<summary>(0, -1, 0)</summary>
        public static readonly double3 down = new double3(0d, -1d, 0d);
        ///<summary>(0, 1, 0)</summary>
        public static readonly double3 up = new double3(0d, 1d, 0d);
        ///<summary>(0, 0, -1)</summary>
        public static readonly double3 back = new double3(0d, 0d, -1d);
        ///<summary>(0, 0, 1)</summary>
        public static readonly double3 forward = new double3(0d, 0d, 1d);
        #endregion

        public double x;
        public double y;
        public double z;

        #region IColor
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (double)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (double)value; }
        public float b { [IN(LINE)] get => (float)z; [IN(LINE)] set => z = (double)value; }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set { } }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector1<double>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector2<double>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector3<double>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe double this[int index]
        {
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (double3* array = &this) { return ((double*)array)[index]; }
            }
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (double* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public double3(float x, float y, float z) { this.x = (double)x; this.y = (double)y; this.z = (double)z; }
        [IN(LINE)] public double3(float v) { x = (double)v; y = (double)v; z = (double)v; }
        [IN(LINE)] public double3(float3 v) { x = (double)v.x; y = (double)v.y; z = (double)v.z; }
        [IN(LINE)] public double3(double x, double y, double z) { this.x = x; this.y = y; this.z = z; }
        [IN(LINE)] public double3(double v) { x = v; y = v; z = v; }
        [IN(LINE)] public double3(double3 v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public double3(int x, int y, int z) { this.x = (double)x; this.y = (double)y; this.z = (double)z; }
        [IN(LINE)] public double3(int v) { x = (double)v; y = (double)v; z = (double)v; }
        [IN(LINE)] public double3(int3 v) { x = (double)v.x; y = (double)v.y; z = (double)v.z; }
        [IN(LINE)] public double3(uint x, uint y, uint z) { this.x = (double)x; this.y = (double)y; this.z = (double)z; }
        [IN(LINE)] public double3(uint v) { x = (double)v; y = (double)v; z = (double)v; }
        [IN(LINE)] public double3(uint3 v) { x = (double)v.x; y = (double)v.y; z = (double)v.z; }

        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static double3 operator *(double3 a, double3 b) => new double3(a.x * b.x, a.y * b.y, a.z * b.z);
        [IN(LINE)] public static double3 operator *(double3 a, double b) => new double3(a.x * b, a.y * b, a.z * b);
        [IN(LINE)] public static double3 operator *(double a, double3 b) => new double3(a * b.x, a * b.y, a * b.z);

        [IN(LINE)] public static double3 operator +(double3 a, double3 b) => new double3(a.x + b.x, a.y + b.y, a.z + b.z);
        [IN(LINE)] public static double3 operator +(double3 a, double b) => new double3(a.x + b, a.y + b, a.z + b);
        [IN(LINE)] public static double3 operator +(double a, double3 b) => new double3(a + b.x, a + b.y, a + b.z);

        [IN(LINE)] public static double3 operator -(double3 a, double3 b) => new double3(a.x - b.x, a.y - b.y, a.z - b.z);
        [IN(LINE)] public static double3 operator -(double3 a, double b) => new double3(a.x - b, a.y - b, a.z - b);
        [IN(LINE)] public static double3 operator -(double a, double3 b) => new double3(a - b.x, a - b.y, a - b.z);

        [IN(LINE)] public static double3 operator /(double3 a, double3 b) => new double3(a.x / b.x, a.y / b.y, a.z / b.z);
        [IN(LINE)] public static double3 operator /(double3 a, double b) => new double3(a.x / b, a.y / b, a.z / b);
        [IN(LINE)] public static double3 operator /(double a, double3 b) => new double3(a / b.x, a / b.y, a / b.z);

        [IN(LINE)] public static double3 operator %(double3 a, double3 b) => new double3(a.x % b.x, a.y % b.y, a.z % b.z);
        [IN(LINE)] public static double3 operator %(double3 a, double b) => new double3(a.x % b, a.y % b, a.z % b);
        [IN(LINE)] public static double3 operator %(double a, double3 b) => new double3(a % b.x, a % b.y, a % b.z);

        [IN(LINE)] public static double3 operator ++(double3 a) => new double3(++a.x, ++a.y, ++a.z);
        [IN(LINE)] public static double3 operator --(double3 a) => new double3(--a.x, --a.y, --a.z);
        [IN(LINE)] public static double3 operator -(double3 a) => new double3(-a.x, -a.y, -a.z);
        [IN(LINE)] public static double3 operator +(double3 a) => new double3(+a.x, +a.y, +a.z);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(double3 a, double3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [IN(LINE)] public static bool operator ==(double3 a, double b) => a.x == b && a.y == b && a.z == b;
        [IN(LINE)] public static bool operator ==(double a, double3 b) => a == b.x && a == b.y && a == b.z;

        [IN(LINE)] public static bool operator !=(double3 a, double3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [IN(LINE)] public static bool operator !=(double3 a, double b) => a.x != b || a.y != b || a.z != b;
        [IN(LINE)] public static bool operator !=(double a, double3 b) => a != b.x || a != b.y || a != b.z;
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
        public double2 x_ { [IN(LINE)] get => new double2(x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yx { [IN(LINE)] get => new double2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yy { [IN(LINE)] get => new double2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 yz { [IN(LINE)] get => new double2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 y_ { [IN(LINE)] get => new double2(y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zx { [IN(LINE)] get => new double2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zy { [IN(LINE)] get => new double2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 zz { [IN(LINE)] get => new double2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 z_ { [IN(LINE)] get => new double2(z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _x { [IN(LINE)] get => new double2(0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _y { [IN(LINE)] get => new double2(0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double2 _z { [IN(LINE)] get => new double2(0d, z); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxx { [IN(LINE)] get => new double3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxy { [IN(LINE)] get => new double3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xxz { [IN(LINE)] get => new double3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xx_ { [IN(LINE)] get => new double3(x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyx { [IN(LINE)] get => new double3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyy { [IN(LINE)] get => new double3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xyz { [IN(LINE)] get => new double3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xy_ { [IN(LINE)] get => new double3(x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzx { [IN(LINE)] get => new double3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzy { [IN(LINE)] get => new double3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xzz { [IN(LINE)] get => new double3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 xz_ { [IN(LINE)] get => new double3(x, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_x { [IN(LINE)] get => new double3(x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_y { [IN(LINE)] get => new double3(x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x_z { [IN(LINE)] get => new double3(x, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 x__ { [IN(LINE)] get => new double3(x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxx { [IN(LINE)] get => new double3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxy { [IN(LINE)] get => new double3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yxz { [IN(LINE)] get => new double3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yx_ { [IN(LINE)] get => new double3(y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyx { [IN(LINE)] get => new double3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyy { [IN(LINE)] get => new double3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yyz { [IN(LINE)] get => new double3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yy_ { [IN(LINE)] get => new double3(y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzx { [IN(LINE)] get => new double3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzy { [IN(LINE)] get => new double3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yzz { [IN(LINE)] get => new double3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 yz_ { [IN(LINE)] get => new double3(y, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_x { [IN(LINE)] get => new double3(y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_y { [IN(LINE)] get => new double3(y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y_z { [IN(LINE)] get => new double3(y, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 y__ { [IN(LINE)] get => new double3(y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxx { [IN(LINE)] get => new double3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxy { [IN(LINE)] get => new double3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zxz { [IN(LINE)] get => new double3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zx_ { [IN(LINE)] get => new double3(z, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyx { [IN(LINE)] get => new double3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyy { [IN(LINE)] get => new double3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zyz { [IN(LINE)] get => new double3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zy_ { [IN(LINE)] get => new double3(z, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzx { [IN(LINE)] get => new double3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzy { [IN(LINE)] get => new double3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zzz { [IN(LINE)] get => new double3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 zz_ { [IN(LINE)] get => new double3(z, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_x { [IN(LINE)] get => new double3(z, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_y { [IN(LINE)] get => new double3(z, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z_z { [IN(LINE)] get => new double3(z, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 z__ { [IN(LINE)] get => new double3(z, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xx { [IN(LINE)] get => new double3(0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xy { [IN(LINE)] get => new double3(0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _xz { [IN(LINE)] get => new double3(0d, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _x_ { [IN(LINE)] get => new double3(0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yx { [IN(LINE)] get => new double3(0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yy { [IN(LINE)] get => new double3(0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _yz { [IN(LINE)] get => new double3(0d, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _y_ { [IN(LINE)] get => new double3(0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zx { [IN(LINE)] get => new double3(0d, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zy { [IN(LINE)] get => new double3(0d, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _zz { [IN(LINE)] get => new double3(0d, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 _z_ { [IN(LINE)] get => new double3(0d, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __x { [IN(LINE)] get => new double3(0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __y { [IN(LINE)] get => new double3(0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double3 __z { [IN(LINE)] get => new double3(0d, 0d, z); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxx { [IN(LINE)] get => new double4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxy { [IN(LINE)] get => new double4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxxz { [IN(LINE)] get => new double4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxx_ { [IN(LINE)] get => new double4(x, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyx { [IN(LINE)] get => new double4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyy { [IN(LINE)] get => new double4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxyz { [IN(LINE)] get => new double4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxy_ { [IN(LINE)] get => new double4(x, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzx { [IN(LINE)] get => new double4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzy { [IN(LINE)] get => new double4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxzz { [IN(LINE)] get => new double4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xxz_ { [IN(LINE)] get => new double4(x, x, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_x { [IN(LINE)] get => new double4(x, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_y { [IN(LINE)] get => new double4(x, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx_z { [IN(LINE)] get => new double4(x, x, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xx__ { [IN(LINE)] get => new double4(x, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxx { [IN(LINE)] get => new double4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxy { [IN(LINE)] get => new double4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyxz { [IN(LINE)] get => new double4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyx_ { [IN(LINE)] get => new double4(x, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyx { [IN(LINE)] get => new double4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyy { [IN(LINE)] get => new double4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyyz { [IN(LINE)] get => new double4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyy_ { [IN(LINE)] get => new double4(x, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzx { [IN(LINE)] get => new double4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzy { [IN(LINE)] get => new double4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyzz { [IN(LINE)] get => new double4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xyz_ { [IN(LINE)] get => new double4(x, y, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_x { [IN(LINE)] get => new double4(x, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_y { [IN(LINE)] get => new double4(x, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy_z { [IN(LINE)] get => new double4(x, y, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xy__ { [IN(LINE)] get => new double4(x, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxx { [IN(LINE)] get => new double4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxy { [IN(LINE)] get => new double4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzxz { [IN(LINE)] get => new double4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzx_ { [IN(LINE)] get => new double4(x, z, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyx { [IN(LINE)] get => new double4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyy { [IN(LINE)] get => new double4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzyz { [IN(LINE)] get => new double4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzy_ { [IN(LINE)] get => new double4(x, z, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzx { [IN(LINE)] get => new double4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzy { [IN(LINE)] get => new double4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzzz { [IN(LINE)] get => new double4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xzz_ { [IN(LINE)] get => new double4(x, z, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_x { [IN(LINE)] get => new double4(x, z, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_y { [IN(LINE)] get => new double4(x, z, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz_z { [IN(LINE)] get => new double4(x, z, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 xz__ { [IN(LINE)] get => new double4(x, z, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xx { [IN(LINE)] get => new double4(x, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xy { [IN(LINE)] get => new double4(x, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_xz { [IN(LINE)] get => new double4(x, 0d, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_x_ { [IN(LINE)] get => new double4(x, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yx { [IN(LINE)] get => new double4(x, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yy { [IN(LINE)] get => new double4(x, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_yz { [IN(LINE)] get => new double4(x, 0d, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_y_ { [IN(LINE)] get => new double4(x, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zx { [IN(LINE)] get => new double4(x, 0d, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zy { [IN(LINE)] get => new double4(x, 0d, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_zz { [IN(LINE)] get => new double4(x, 0d, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x_z_ { [IN(LINE)] get => new double4(x, 0d, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__x { [IN(LINE)] get => new double4(x, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__y { [IN(LINE)] get => new double4(x, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x__z { [IN(LINE)] get => new double4(x, 0d, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 x___ { [IN(LINE)] get => new double4(x, 0d, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxx { [IN(LINE)] get => new double4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxy { [IN(LINE)] get => new double4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxxz { [IN(LINE)] get => new double4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxx_ { [IN(LINE)] get => new double4(y, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyx { [IN(LINE)] get => new double4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyy { [IN(LINE)] get => new double4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxyz { [IN(LINE)] get => new double4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxy_ { [IN(LINE)] get => new double4(y, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzx { [IN(LINE)] get => new double4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzy { [IN(LINE)] get => new double4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxzz { [IN(LINE)] get => new double4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yxz_ { [IN(LINE)] get => new double4(y, x, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_x { [IN(LINE)] get => new double4(y, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_y { [IN(LINE)] get => new double4(y, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx_z { [IN(LINE)] get => new double4(y, x, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yx__ { [IN(LINE)] get => new double4(y, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxx { [IN(LINE)] get => new double4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxy { [IN(LINE)] get => new double4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyxz { [IN(LINE)] get => new double4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyx_ { [IN(LINE)] get => new double4(y, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyx { [IN(LINE)] get => new double4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyy { [IN(LINE)] get => new double4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyyz { [IN(LINE)] get => new double4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyy_ { [IN(LINE)] get => new double4(y, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzx { [IN(LINE)] get => new double4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzy { [IN(LINE)] get => new double4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyzz { [IN(LINE)] get => new double4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yyz_ { [IN(LINE)] get => new double4(y, y, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_x { [IN(LINE)] get => new double4(y, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_y { [IN(LINE)] get => new double4(y, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy_z { [IN(LINE)] get => new double4(y, y, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yy__ { [IN(LINE)] get => new double4(y, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxx { [IN(LINE)] get => new double4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxy { [IN(LINE)] get => new double4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzxz { [IN(LINE)] get => new double4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzx_ { [IN(LINE)] get => new double4(y, z, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyx { [IN(LINE)] get => new double4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyy { [IN(LINE)] get => new double4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzyz { [IN(LINE)] get => new double4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzy_ { [IN(LINE)] get => new double4(y, z, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzx { [IN(LINE)] get => new double4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzy { [IN(LINE)] get => new double4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzzz { [IN(LINE)] get => new double4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yzz_ { [IN(LINE)] get => new double4(y, z, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_x { [IN(LINE)] get => new double4(y, z, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_y { [IN(LINE)] get => new double4(y, z, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz_z { [IN(LINE)] get => new double4(y, z, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 yz__ { [IN(LINE)] get => new double4(y, z, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xx { [IN(LINE)] get => new double4(y, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xy { [IN(LINE)] get => new double4(y, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_xz { [IN(LINE)] get => new double4(y, 0d, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_x_ { [IN(LINE)] get => new double4(y, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yx { [IN(LINE)] get => new double4(y, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yy { [IN(LINE)] get => new double4(y, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_yz { [IN(LINE)] get => new double4(y, 0d, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_y_ { [IN(LINE)] get => new double4(y, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zx { [IN(LINE)] get => new double4(y, 0d, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zy { [IN(LINE)] get => new double4(y, 0d, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_zz { [IN(LINE)] get => new double4(y, 0d, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y_z_ { [IN(LINE)] get => new double4(y, 0d, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__x { [IN(LINE)] get => new double4(y, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__y { [IN(LINE)] get => new double4(y, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y__z { [IN(LINE)] get => new double4(y, 0d, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 y___ { [IN(LINE)] get => new double4(y, 0d, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxx { [IN(LINE)] get => new double4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxy { [IN(LINE)] get => new double4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxxz { [IN(LINE)] get => new double4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxx_ { [IN(LINE)] get => new double4(z, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyx { [IN(LINE)] get => new double4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyy { [IN(LINE)] get => new double4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxyz { [IN(LINE)] get => new double4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxy_ { [IN(LINE)] get => new double4(z, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzx { [IN(LINE)] get => new double4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzy { [IN(LINE)] get => new double4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxzz { [IN(LINE)] get => new double4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zxz_ { [IN(LINE)] get => new double4(z, x, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_x { [IN(LINE)] get => new double4(z, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_y { [IN(LINE)] get => new double4(z, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx_z { [IN(LINE)] get => new double4(z, x, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zx__ { [IN(LINE)] get => new double4(z, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxx { [IN(LINE)] get => new double4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxy { [IN(LINE)] get => new double4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyxz { [IN(LINE)] get => new double4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyx_ { [IN(LINE)] get => new double4(z, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyx { [IN(LINE)] get => new double4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyy { [IN(LINE)] get => new double4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyyz { [IN(LINE)] get => new double4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyy_ { [IN(LINE)] get => new double4(z, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzx { [IN(LINE)] get => new double4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzy { [IN(LINE)] get => new double4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyzz { [IN(LINE)] get => new double4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zyz_ { [IN(LINE)] get => new double4(z, y, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_x { [IN(LINE)] get => new double4(z, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_y { [IN(LINE)] get => new double4(z, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy_z { [IN(LINE)] get => new double4(z, y, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zy__ { [IN(LINE)] get => new double4(z, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxx { [IN(LINE)] get => new double4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxy { [IN(LINE)] get => new double4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzxz { [IN(LINE)] get => new double4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzx_ { [IN(LINE)] get => new double4(z, z, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyx { [IN(LINE)] get => new double4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyy { [IN(LINE)] get => new double4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzyz { [IN(LINE)] get => new double4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzy_ { [IN(LINE)] get => new double4(z, z, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzx { [IN(LINE)] get => new double4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzy { [IN(LINE)] get => new double4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzzz { [IN(LINE)] get => new double4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zzz_ { [IN(LINE)] get => new double4(z, z, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_x { [IN(LINE)] get => new double4(z, z, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_y { [IN(LINE)] get => new double4(z, z, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz_z { [IN(LINE)] get => new double4(z, z, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 zz__ { [IN(LINE)] get => new double4(z, z, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xx { [IN(LINE)] get => new double4(z, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xy { [IN(LINE)] get => new double4(z, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_xz { [IN(LINE)] get => new double4(z, 0d, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_x_ { [IN(LINE)] get => new double4(z, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yx { [IN(LINE)] get => new double4(z, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yy { [IN(LINE)] get => new double4(z, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_yz { [IN(LINE)] get => new double4(z, 0d, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_y_ { [IN(LINE)] get => new double4(z, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zx { [IN(LINE)] get => new double4(z, 0d, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zy { [IN(LINE)] get => new double4(z, 0d, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_zz { [IN(LINE)] get => new double4(z, 0d, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z_z_ { [IN(LINE)] get => new double4(z, 0d, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__x { [IN(LINE)] get => new double4(z, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__y { [IN(LINE)] get => new double4(z, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z__z { [IN(LINE)] get => new double4(z, 0d, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 z___ { [IN(LINE)] get => new double4(z, 0d, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxx { [IN(LINE)] get => new double4(0d, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxy { [IN(LINE)] get => new double4(0d, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xxz { [IN(LINE)] get => new double4(0d, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xx_ { [IN(LINE)] get => new double4(0d, x, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyx { [IN(LINE)] get => new double4(0d, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyy { [IN(LINE)] get => new double4(0d, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xyz { [IN(LINE)] get => new double4(0d, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xy_ { [IN(LINE)] get => new double4(0d, x, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzx { [IN(LINE)] get => new double4(0d, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzy { [IN(LINE)] get => new double4(0d, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xzz { [IN(LINE)] get => new double4(0d, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _xz_ { [IN(LINE)] get => new double4(0d, x, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_x { [IN(LINE)] get => new double4(0d, x, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_y { [IN(LINE)] get => new double4(0d, x, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x_z { [IN(LINE)] get => new double4(0d, x, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _x__ { [IN(LINE)] get => new double4(0d, x, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxx { [IN(LINE)] get => new double4(0d, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxy { [IN(LINE)] get => new double4(0d, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yxz { [IN(LINE)] get => new double4(0d, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yx_ { [IN(LINE)] get => new double4(0d, y, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyx { [IN(LINE)] get => new double4(0d, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyy { [IN(LINE)] get => new double4(0d, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yyz { [IN(LINE)] get => new double4(0d, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yy_ { [IN(LINE)] get => new double4(0d, y, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzx { [IN(LINE)] get => new double4(0d, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzy { [IN(LINE)] get => new double4(0d, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yzz { [IN(LINE)] get => new double4(0d, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _yz_ { [IN(LINE)] get => new double4(0d, y, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_x { [IN(LINE)] get => new double4(0d, y, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_y { [IN(LINE)] get => new double4(0d, y, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y_z { [IN(LINE)] get => new double4(0d, y, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _y__ { [IN(LINE)] get => new double4(0d, y, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxx { [IN(LINE)] get => new double4(0d, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxy { [IN(LINE)] get => new double4(0d, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zxz { [IN(LINE)] get => new double4(0d, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zx_ { [IN(LINE)] get => new double4(0d, z, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyx { [IN(LINE)] get => new double4(0d, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyy { [IN(LINE)] get => new double4(0d, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zyz { [IN(LINE)] get => new double4(0d, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zy_ { [IN(LINE)] get => new double4(0d, z, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzx { [IN(LINE)] get => new double4(0d, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzy { [IN(LINE)] get => new double4(0d, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zzz { [IN(LINE)] get => new double4(0d, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _zz_ { [IN(LINE)] get => new double4(0d, z, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_x { [IN(LINE)] get => new double4(0d, z, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_y { [IN(LINE)] get => new double4(0d, z, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z_z { [IN(LINE)] get => new double4(0d, z, 0d, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 _z__ { [IN(LINE)] get => new double4(0d, z, 0d, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xx { [IN(LINE)] get => new double4(0d, 0d, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xy { [IN(LINE)] get => new double4(0d, 0d, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __xz { [IN(LINE)] get => new double4(0d, 0d, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __x_ { [IN(LINE)] get => new double4(0d, 0d, x, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yx { [IN(LINE)] get => new double4(0d, 0d, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yy { [IN(LINE)] get => new double4(0d, 0d, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __yz { [IN(LINE)] get => new double4(0d, 0d, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __y_ { [IN(LINE)] get => new double4(0d, 0d, y, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zx { [IN(LINE)] get => new double4(0d, 0d, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zy { [IN(LINE)] get => new double4(0d, 0d, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __zz { [IN(LINE)] get => new double4(0d, 0d, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 __z_ { [IN(LINE)] get => new double4(0d, 0d, z, 0d); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___x { [IN(LINE)] get => new double4(0d, 0d, 0d, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___y { [IN(LINE)] get => new double4(0d, 0d, 0d, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double4 ___z { [IN(LINE)] get => new double4(0d, 0d, 0d, z); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => DM.Hash(this);
        public override bool Equals(object o) => o is double3 target && Equals(target);
        [IN(LINE)] public bool Equals(double3 a) => x == a.x && y == a.y && z == a.z;
        public override string ToString() => $"double3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public double x, y, z;
            public DebuggerProxy(double3 v) { x = v.x; y = v.y; z = v.z; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<double, double3> GetEnumerator() => new VectorEnumerator<double, double3>(this);
        IEnumerator<double> IEnumerable<double>.GetEnumerator() => new VectorEnumerator<double, double3>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<double, double3>(this);
        #endregion
    }
}
