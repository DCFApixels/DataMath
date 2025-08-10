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
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 3)]
    public partial struct bool3 :
        IEquatable<bool3>,
        IVector3<bool>,
        IColor,
        IEnumerableVector<bool, bool3>
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly bool3 zero = new bool3(0, 0, 0);
        ///<summary>(1, 1, 1)</summary>
        public static readonly bool3 one = new bool3(1, 1, 1);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly bool3 left = new bool3(-1, 0, 0);
        ///<summary>(1, 0, 0)</summary>
        public static readonly bool3 right = new bool3(1, 0, 0);
        ///<summary>(0, -1, 0)</summary>
        public static readonly bool3 down = new bool3(0, -1, 0);
        ///<summary>(0, 1, 0)</summary>
        public static readonly bool3 up = new bool3(0, 1, 0);
        ///<summary>(0, 0, -1)</summary>
        public static readonly bool3 back = new bool3(0, 0, -1);
        ///<summary>(0, 0, 1)</summary>
        public static readonly bool3 forward = new bool3(0, 0, 1);
        #endregion

        public bool x;
        public bool y;
        public bool z;

        #region IColor
        public float r { [IN(LINE)] get => x ? 1f : 0f; [IN(LINE)] set => x = value > 0f; }
        public float g { [IN(LINE)] get => y ? 1f : 0f; [IN(LINE)] set => y = value > 0f; }
        public float b { [IN(LINE)] get => z ? 1f : 0f; [IN(LINE)] set => z = value > 0f; }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set { } }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector1<bool>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector2<bool>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector3<bool>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }
        public bool all { [IN(LINE)] get => x & y & z; [IN(LINE)] set { x = value; y = value; z = value; } }
        public bool any { [IN(LINE)] get => x | y | z; }

        public unsafe bool this[int index]
        {
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (bool3* array = &this) { return ((bool*)array)[index]; }
            }
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (bool* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public bool3(bool x, bool y, bool z) { this.x = x; this.y = y; this.z = z; }
        [IN(LINE)] public bool3(bool v) { x = v; y = v; z = v; }
        [IN(LINE)] public bool3(bool3 v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public bool3(float x, float y, float z) { this.x = x > 0; this.y = y > 0; this.z = z > 0; }
        [IN(LINE)] public bool3(float v) { x = v > 0; y = v > 0; z = v > 0; }
        [IN(LINE)] public bool3(float3 v) { x = v.x > 0; y = v.y > 0; z = v.z > 0; }
        [IN(LINE)] public bool3(double x, double y, double z) { this.x = x > 0; this.y = y > 0; this.z = z > 0; }
        [IN(LINE)] public bool3(double v) { x = v > 0; y = v > 0; z = v > 0; }
        [IN(LINE)] public bool3(double3 v) { x = v.x > 0; y = v.y > 0; z = v.z > 0; }
        [IN(LINE)] public bool3(int x, int y, int z) { this.x = x > 0; this.y = y > 0; this.z = z > 0; }
        [IN(LINE)] public bool3(int v) { x = v > 0; y = v > 0; z = v > 0; }
        [IN(LINE)] public bool3(int3 v) { x = v.x > 0; y = v.y > 0; z = v.z > 0; }
        [IN(LINE)] public bool3(uint x, uint y, uint z) { this.x = x > 0; this.y = y > 0; this.z = z > 0; }
        [IN(LINE)] public bool3(uint v) { x = v > 0; y = v > 0; z = v > 0; }
        [IN(LINE)] public bool3(uint3 v) { x = v.x > 0; y = v.y > 0; z = v.z > 0; }
        #endregion

        #region operators

        #region Bits
        [IN(LINE)] public static bool3 operator !(bool3 a) => new bool3(!a.x, !a.y, !a.z);

        [IN(LINE)] public static bool3 operator |(bool3 a, bool3 b) => new bool3(a.x | b.x, a.y | b.y, a.z | b.z);
        [IN(LINE)] public static bool3 operator |(bool3 a, bool b) => new bool3(a.x | b, a.y | b, a.z | b);
        [IN(LINE)] public static bool3 operator |(bool a, bool3 b) => new bool3(a | b.x, a | b.y, a | b.z);

        [IN(LINE)] public static bool3 operator &(bool3 a, bool3 b) => new bool3(a.x & b.x, a.y & b.y, a.z & b.z);
        [IN(LINE)] public static bool3 operator &(bool3 a, bool b) => new bool3(a.x & b, a.y & b, a.z & b);
        [IN(LINE)] public static bool3 operator &(bool a, bool3 b) => new bool3(a & b.x, a & b.y, a & b.z);

        [IN(LINE)] public static bool3 operator ^(bool3 a, bool3 b) => new bool3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z);
        [IN(LINE)] public static bool3 operator ^(bool3 a, bool b) => new bool3(a.x ^ b, a.y ^ b, a.z ^ b);
        [IN(LINE)] public static bool3 operator ^(bool a, bool3 b) => new bool3(a ^ b.x, a ^ b.y, a ^ b.z);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(bool3 a, bool3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [IN(LINE)] public static bool operator ==(bool3 a, bool b) => a.x == b && a.y == b && a.z == b;
        [IN(LINE)] public static bool operator ==(bool a, bool3 b) => a == b.x && a == b.y && a == b.z;

        [IN(LINE)] public static bool operator !=(bool3 a, bool3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [IN(LINE)] public static bool operator !=(bool3 a, bool b) => a.x != b || a.y != b || a.z != b;
        [IN(LINE)] public static bool operator !=(bool a, bool3 b) => a != b.x || a != b.y || a != b.z;

        [IN(LINE)] public static bool operator ==(bool3 a, DM.AllCheckMode b) { return a.all; }
        [IN(LINE)] public static bool operator !=(bool3 a, DM.AllCheckMode b) { return !a.all; }
        [IN(LINE)] public static bool operator ==(DM.AllCheckMode b, bool3 a) { return a.all; }
        [IN(LINE)] public static bool operator !=(DM.AllCheckMode b, bool3 a) { return !a.all; }

        [IN(LINE)] public static bool operator ==(bool3 a, DM.AnyCheckMode b) { return a.any; }
        [IN(LINE)] public static bool operator !=(bool3 a, DM.AnyCheckMode b) { return !a.any; }
        [IN(LINE)] public static bool operator ==(DM.AnyCheckMode b, bool3 a) { return a.any; }
        [IN(LINE)] public static bool operator !=(DM.AnyCheckMode b, bool3 a) { return !a.any; }
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 xx { [IN(LINE)] get => new bool2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 xy { [IN(LINE)] get => new bool2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 xz { [IN(LINE)] get => new bool2(x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 x_ { [IN(LINE)] get => new bool2(x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 yx { [IN(LINE)] get => new bool2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 yy { [IN(LINE)] get => new bool2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 yz { [IN(LINE)] get => new bool2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 y_ { [IN(LINE)] get => new bool2(y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 zx { [IN(LINE)] get => new bool2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 zy { [IN(LINE)] get => new bool2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 zz { [IN(LINE)] get => new bool2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 z_ { [IN(LINE)] get => new bool2(z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 _x { [IN(LINE)] get => new bool2(false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 _y { [IN(LINE)] get => new bool2(false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 _z { [IN(LINE)] get => new bool2(false, z); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xxx { [IN(LINE)] get => new bool3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xxy { [IN(LINE)] get => new bool3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xxz { [IN(LINE)] get => new bool3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xx_ { [IN(LINE)] get => new bool3(x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xyx { [IN(LINE)] get => new bool3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xyy { [IN(LINE)] get => new bool3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xyz { [IN(LINE)] get => new bool3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xy_ { [IN(LINE)] get => new bool3(x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xzx { [IN(LINE)] get => new bool3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xzy { [IN(LINE)] get => new bool3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xzz { [IN(LINE)] get => new bool3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xz_ { [IN(LINE)] get => new bool3(x, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x_x { [IN(LINE)] get => new bool3(x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x_y { [IN(LINE)] get => new bool3(x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x_z { [IN(LINE)] get => new bool3(x, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x__ { [IN(LINE)] get => new bool3(x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yxx { [IN(LINE)] get => new bool3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yxy { [IN(LINE)] get => new bool3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yxz { [IN(LINE)] get => new bool3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yx_ { [IN(LINE)] get => new bool3(y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yyx { [IN(LINE)] get => new bool3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yyy { [IN(LINE)] get => new bool3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yyz { [IN(LINE)] get => new bool3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yy_ { [IN(LINE)] get => new bool3(y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yzx { [IN(LINE)] get => new bool3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yzy { [IN(LINE)] get => new bool3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yzz { [IN(LINE)] get => new bool3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yz_ { [IN(LINE)] get => new bool3(y, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y_x { [IN(LINE)] get => new bool3(y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y_y { [IN(LINE)] get => new bool3(y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y_z { [IN(LINE)] get => new bool3(y, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y__ { [IN(LINE)] get => new bool3(y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zxx { [IN(LINE)] get => new bool3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zxy { [IN(LINE)] get => new bool3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zxz { [IN(LINE)] get => new bool3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zx_ { [IN(LINE)] get => new bool3(z, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zyx { [IN(LINE)] get => new bool3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zyy { [IN(LINE)] get => new bool3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zyz { [IN(LINE)] get => new bool3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zy_ { [IN(LINE)] get => new bool3(z, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zzx { [IN(LINE)] get => new bool3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zzy { [IN(LINE)] get => new bool3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zzz { [IN(LINE)] get => new bool3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 zz_ { [IN(LINE)] get => new bool3(z, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 z_x { [IN(LINE)] get => new bool3(z, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 z_y { [IN(LINE)] get => new bool3(z, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 z_z { [IN(LINE)] get => new bool3(z, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 z__ { [IN(LINE)] get => new bool3(z, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _xx { [IN(LINE)] get => new bool3(false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _xy { [IN(LINE)] get => new bool3(false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _xz { [IN(LINE)] get => new bool3(false, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _x_ { [IN(LINE)] get => new bool3(false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _yx { [IN(LINE)] get => new bool3(false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _yy { [IN(LINE)] get => new bool3(false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _yz { [IN(LINE)] get => new bool3(false, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _y_ { [IN(LINE)] get => new bool3(false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _zx { [IN(LINE)] get => new bool3(false, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _zy { [IN(LINE)] get => new bool3(false, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _zz { [IN(LINE)] get => new bool3(false, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _z_ { [IN(LINE)] get => new bool3(false, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 __x { [IN(LINE)] get => new bool3(false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 __y { [IN(LINE)] get => new bool3(false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 __z { [IN(LINE)] get => new bool3(false, false, z); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxxx { [IN(LINE)] get => new bool4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxxy { [IN(LINE)] get => new bool4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxxz { [IN(LINE)] get => new bool4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxx_ { [IN(LINE)] get => new bool4(x, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxyx { [IN(LINE)] get => new bool4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxyy { [IN(LINE)] get => new bool4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxyz { [IN(LINE)] get => new bool4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxy_ { [IN(LINE)] get => new bool4(x, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxzx { [IN(LINE)] get => new bool4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxzy { [IN(LINE)] get => new bool4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxzz { [IN(LINE)] get => new bool4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxz_ { [IN(LINE)] get => new bool4(x, x, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx_x { [IN(LINE)] get => new bool4(x, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx_y { [IN(LINE)] get => new bool4(x, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx_z { [IN(LINE)] get => new bool4(x, x, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx__ { [IN(LINE)] get => new bool4(x, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyxx { [IN(LINE)] get => new bool4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyxy { [IN(LINE)] get => new bool4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyxz { [IN(LINE)] get => new bool4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyx_ { [IN(LINE)] get => new bool4(x, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyyx { [IN(LINE)] get => new bool4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyyy { [IN(LINE)] get => new bool4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyyz { [IN(LINE)] get => new bool4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyy_ { [IN(LINE)] get => new bool4(x, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyzx { [IN(LINE)] get => new bool4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyzy { [IN(LINE)] get => new bool4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyzz { [IN(LINE)] get => new bool4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyz_ { [IN(LINE)] get => new bool4(x, y, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy_x { [IN(LINE)] get => new bool4(x, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy_y { [IN(LINE)] get => new bool4(x, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy_z { [IN(LINE)] get => new bool4(x, y, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy__ { [IN(LINE)] get => new bool4(x, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzxx { [IN(LINE)] get => new bool4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzxy { [IN(LINE)] get => new bool4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzxz { [IN(LINE)] get => new bool4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzx_ { [IN(LINE)] get => new bool4(x, z, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzyx { [IN(LINE)] get => new bool4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzyy { [IN(LINE)] get => new bool4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzyz { [IN(LINE)] get => new bool4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzy_ { [IN(LINE)] get => new bool4(x, z, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzzx { [IN(LINE)] get => new bool4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzzy { [IN(LINE)] get => new bool4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzzz { [IN(LINE)] get => new bool4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xzz_ { [IN(LINE)] get => new bool4(x, z, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xz_x { [IN(LINE)] get => new bool4(x, z, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xz_y { [IN(LINE)] get => new bool4(x, z, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xz_z { [IN(LINE)] get => new bool4(x, z, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xz__ { [IN(LINE)] get => new bool4(x, z, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_xx { [IN(LINE)] get => new bool4(x, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_xy { [IN(LINE)] get => new bool4(x, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_xz { [IN(LINE)] get => new bool4(x, false, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_x_ { [IN(LINE)] get => new bool4(x, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_yx { [IN(LINE)] get => new bool4(x, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_yy { [IN(LINE)] get => new bool4(x, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_yz { [IN(LINE)] get => new bool4(x, false, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_y_ { [IN(LINE)] get => new bool4(x, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_zx { [IN(LINE)] get => new bool4(x, false, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_zy { [IN(LINE)] get => new bool4(x, false, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_zz { [IN(LINE)] get => new bool4(x, false, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_z_ { [IN(LINE)] get => new bool4(x, false, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x__x { [IN(LINE)] get => new bool4(x, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x__y { [IN(LINE)] get => new bool4(x, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x__z { [IN(LINE)] get => new bool4(x, false, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x___ { [IN(LINE)] get => new bool4(x, false, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxxx { [IN(LINE)] get => new bool4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxxy { [IN(LINE)] get => new bool4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxxz { [IN(LINE)] get => new bool4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxx_ { [IN(LINE)] get => new bool4(y, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxyx { [IN(LINE)] get => new bool4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxyy { [IN(LINE)] get => new bool4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxyz { [IN(LINE)] get => new bool4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxy_ { [IN(LINE)] get => new bool4(y, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxzx { [IN(LINE)] get => new bool4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxzy { [IN(LINE)] get => new bool4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxzz { [IN(LINE)] get => new bool4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxz_ { [IN(LINE)] get => new bool4(y, x, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx_x { [IN(LINE)] get => new bool4(y, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx_y { [IN(LINE)] get => new bool4(y, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx_z { [IN(LINE)] get => new bool4(y, x, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx__ { [IN(LINE)] get => new bool4(y, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyxx { [IN(LINE)] get => new bool4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyxy { [IN(LINE)] get => new bool4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyxz { [IN(LINE)] get => new bool4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyx_ { [IN(LINE)] get => new bool4(y, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyyx { [IN(LINE)] get => new bool4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyyy { [IN(LINE)] get => new bool4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyyz { [IN(LINE)] get => new bool4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyy_ { [IN(LINE)] get => new bool4(y, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyzx { [IN(LINE)] get => new bool4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyzy { [IN(LINE)] get => new bool4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyzz { [IN(LINE)] get => new bool4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyz_ { [IN(LINE)] get => new bool4(y, y, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy_x { [IN(LINE)] get => new bool4(y, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy_y { [IN(LINE)] get => new bool4(y, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy_z { [IN(LINE)] get => new bool4(y, y, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy__ { [IN(LINE)] get => new bool4(y, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzxx { [IN(LINE)] get => new bool4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzxy { [IN(LINE)] get => new bool4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzxz { [IN(LINE)] get => new bool4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzx_ { [IN(LINE)] get => new bool4(y, z, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzyx { [IN(LINE)] get => new bool4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzyy { [IN(LINE)] get => new bool4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzyz { [IN(LINE)] get => new bool4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzy_ { [IN(LINE)] get => new bool4(y, z, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzzx { [IN(LINE)] get => new bool4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzzy { [IN(LINE)] get => new bool4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzzz { [IN(LINE)] get => new bool4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yzz_ { [IN(LINE)] get => new bool4(y, z, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yz_x { [IN(LINE)] get => new bool4(y, z, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yz_y { [IN(LINE)] get => new bool4(y, z, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yz_z { [IN(LINE)] get => new bool4(y, z, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yz__ { [IN(LINE)] get => new bool4(y, z, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_xx { [IN(LINE)] get => new bool4(y, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_xy { [IN(LINE)] get => new bool4(y, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_xz { [IN(LINE)] get => new bool4(y, false, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_x_ { [IN(LINE)] get => new bool4(y, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_yx { [IN(LINE)] get => new bool4(y, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_yy { [IN(LINE)] get => new bool4(y, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_yz { [IN(LINE)] get => new bool4(y, false, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_y_ { [IN(LINE)] get => new bool4(y, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_zx { [IN(LINE)] get => new bool4(y, false, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_zy { [IN(LINE)] get => new bool4(y, false, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_zz { [IN(LINE)] get => new bool4(y, false, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_z_ { [IN(LINE)] get => new bool4(y, false, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y__x { [IN(LINE)] get => new bool4(y, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y__y { [IN(LINE)] get => new bool4(y, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y__z { [IN(LINE)] get => new bool4(y, false, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y___ { [IN(LINE)] get => new bool4(y, false, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxxx { [IN(LINE)] get => new bool4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxxy { [IN(LINE)] get => new bool4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxxz { [IN(LINE)] get => new bool4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxx_ { [IN(LINE)] get => new bool4(z, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxyx { [IN(LINE)] get => new bool4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxyy { [IN(LINE)] get => new bool4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxyz { [IN(LINE)] get => new bool4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxy_ { [IN(LINE)] get => new bool4(z, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxzx { [IN(LINE)] get => new bool4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxzy { [IN(LINE)] get => new bool4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxzz { [IN(LINE)] get => new bool4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zxz_ { [IN(LINE)] get => new bool4(z, x, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zx_x { [IN(LINE)] get => new bool4(z, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zx_y { [IN(LINE)] get => new bool4(z, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zx_z { [IN(LINE)] get => new bool4(z, x, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zx__ { [IN(LINE)] get => new bool4(z, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyxx { [IN(LINE)] get => new bool4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyxy { [IN(LINE)] get => new bool4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyxz { [IN(LINE)] get => new bool4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyx_ { [IN(LINE)] get => new bool4(z, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyyx { [IN(LINE)] get => new bool4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyyy { [IN(LINE)] get => new bool4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyyz { [IN(LINE)] get => new bool4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyy_ { [IN(LINE)] get => new bool4(z, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyzx { [IN(LINE)] get => new bool4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyzy { [IN(LINE)] get => new bool4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyzz { [IN(LINE)] get => new bool4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zyz_ { [IN(LINE)] get => new bool4(z, y, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zy_x { [IN(LINE)] get => new bool4(z, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zy_y { [IN(LINE)] get => new bool4(z, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zy_z { [IN(LINE)] get => new bool4(z, y, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zy__ { [IN(LINE)] get => new bool4(z, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzxx { [IN(LINE)] get => new bool4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzxy { [IN(LINE)] get => new bool4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzxz { [IN(LINE)] get => new bool4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzx_ { [IN(LINE)] get => new bool4(z, z, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzyx { [IN(LINE)] get => new bool4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzyy { [IN(LINE)] get => new bool4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzyz { [IN(LINE)] get => new bool4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzy_ { [IN(LINE)] get => new bool4(z, z, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzzx { [IN(LINE)] get => new bool4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzzy { [IN(LINE)] get => new bool4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzzz { [IN(LINE)] get => new bool4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zzz_ { [IN(LINE)] get => new bool4(z, z, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zz_x { [IN(LINE)] get => new bool4(z, z, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zz_y { [IN(LINE)] get => new bool4(z, z, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zz_z { [IN(LINE)] get => new bool4(z, z, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 zz__ { [IN(LINE)] get => new bool4(z, z, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_xx { [IN(LINE)] get => new bool4(z, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_xy { [IN(LINE)] get => new bool4(z, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_xz { [IN(LINE)] get => new bool4(z, false, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_x_ { [IN(LINE)] get => new bool4(z, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_yx { [IN(LINE)] get => new bool4(z, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_yy { [IN(LINE)] get => new bool4(z, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_yz { [IN(LINE)] get => new bool4(z, false, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_y_ { [IN(LINE)] get => new bool4(z, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_zx { [IN(LINE)] get => new bool4(z, false, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_zy { [IN(LINE)] get => new bool4(z, false, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_zz { [IN(LINE)] get => new bool4(z, false, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z_z_ { [IN(LINE)] get => new bool4(z, false, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z__x { [IN(LINE)] get => new bool4(z, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z__y { [IN(LINE)] get => new bool4(z, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z__z { [IN(LINE)] get => new bool4(z, false, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 z___ { [IN(LINE)] get => new bool4(z, false, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xxx { [IN(LINE)] get => new bool4(false, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xxy { [IN(LINE)] get => new bool4(false, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xxz { [IN(LINE)] get => new bool4(false, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xx_ { [IN(LINE)] get => new bool4(false, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xyx { [IN(LINE)] get => new bool4(false, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xyy { [IN(LINE)] get => new bool4(false, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xyz { [IN(LINE)] get => new bool4(false, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xy_ { [IN(LINE)] get => new bool4(false, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xzx { [IN(LINE)] get => new bool4(false, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xzy { [IN(LINE)] get => new bool4(false, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xzz { [IN(LINE)] get => new bool4(false, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xz_ { [IN(LINE)] get => new bool4(false, x, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x_x { [IN(LINE)] get => new bool4(false, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x_y { [IN(LINE)] get => new bool4(false, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x_z { [IN(LINE)] get => new bool4(false, x, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x__ { [IN(LINE)] get => new bool4(false, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yxx { [IN(LINE)] get => new bool4(false, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yxy { [IN(LINE)] get => new bool4(false, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yxz { [IN(LINE)] get => new bool4(false, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yx_ { [IN(LINE)] get => new bool4(false, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yyx { [IN(LINE)] get => new bool4(false, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yyy { [IN(LINE)] get => new bool4(false, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yyz { [IN(LINE)] get => new bool4(false, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yy_ { [IN(LINE)] get => new bool4(false, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yzx { [IN(LINE)] get => new bool4(false, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yzy { [IN(LINE)] get => new bool4(false, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yzz { [IN(LINE)] get => new bool4(false, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yz_ { [IN(LINE)] get => new bool4(false, y, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y_x { [IN(LINE)] get => new bool4(false, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y_y { [IN(LINE)] get => new bool4(false, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y_z { [IN(LINE)] get => new bool4(false, y, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y__ { [IN(LINE)] get => new bool4(false, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zxx { [IN(LINE)] get => new bool4(false, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zxy { [IN(LINE)] get => new bool4(false, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zxz { [IN(LINE)] get => new bool4(false, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zx_ { [IN(LINE)] get => new bool4(false, z, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zyx { [IN(LINE)] get => new bool4(false, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zyy { [IN(LINE)] get => new bool4(false, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zyz { [IN(LINE)] get => new bool4(false, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zy_ { [IN(LINE)] get => new bool4(false, z, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zzx { [IN(LINE)] get => new bool4(false, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zzy { [IN(LINE)] get => new bool4(false, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zzz { [IN(LINE)] get => new bool4(false, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _zz_ { [IN(LINE)] get => new bool4(false, z, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _z_x { [IN(LINE)] get => new bool4(false, z, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _z_y { [IN(LINE)] get => new bool4(false, z, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _z_z { [IN(LINE)] get => new bool4(false, z, false, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _z__ { [IN(LINE)] get => new bool4(false, z, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __xx { [IN(LINE)] get => new bool4(false, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __xy { [IN(LINE)] get => new bool4(false, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __xz { [IN(LINE)] get => new bool4(false, false, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __x_ { [IN(LINE)] get => new bool4(false, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __yx { [IN(LINE)] get => new bool4(false, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __yy { [IN(LINE)] get => new bool4(false, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __yz { [IN(LINE)] get => new bool4(false, false, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __y_ { [IN(LINE)] get => new bool4(false, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __zx { [IN(LINE)] get => new bool4(false, false, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __zy { [IN(LINE)] get => new bool4(false, false, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __zz { [IN(LINE)] get => new bool4(false, false, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __z_ { [IN(LINE)] get => new bool4(false, false, z, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 ___x { [IN(LINE)] get => new bool4(false, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 ___y { [IN(LINE)] get => new bool4(false, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 ___z { [IN(LINE)] get => new bool4(false, false, false, z); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => DM.Hash(this);
        public override bool Equals(object o) => o is bool3 target && Equals(target);
        [IN(LINE)] public bool Equals(bool3 a) => x == a.x && y == a.y && z == a.z;
        public override string ToString() => $"bool3({x}, {y}, {z})";

        internal class DebuggerProxy
        {
            public bool x, y, z;
            public DebuggerProxy(bool3 v) { x = v.x; y = v.y; z = v.z; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<bool, bool3> GetEnumerator() { return new VectorEnumerator<bool, bool3>(this); }
        VectorEnumerator<bool, bool3> IEnumerableVector<bool, bool3>.GetEnumerator() { return new VectorEnumerator<bool, bool3>(this); }
        IEnumerator<bool> IEnumerable<bool>.GetEnumerator() { return new VectorEnumerator<bool, bool3>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<bool, bool3>(this); }
        #endregion
    }
}