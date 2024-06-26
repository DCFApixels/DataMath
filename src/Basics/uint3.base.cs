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
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public partial struct uint3 :
        IEquatable<uint3>,
        IFormattable,
        IVector3<uint>,
        IColor,
        IEnumerableVector<uint, uint3>
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly uint3 zero = new uint3(0u, 0u, 0u);
        ///<summary>(1, 1, 1)</summary>
        public static readonly uint3 one = new uint3(1u, 1u, 1u);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly uint3 left = new uint3(-1u, 0u, 0u);
        ///<summary>(1, 0, 0)</summary>
        public static readonly uint3 right = new uint3(1u, 0u, 0u);
        ///<summary>(0, -1, 0)</summary>
        public static readonly uint3 down = new uint3(0u, -1u, 0u);
        ///<summary>(0, 1, 0)</summary>
        public static readonly uint3 up = new uint3(0u, 1u, 0u);
        ///<summary>(0, 0, -1)</summary>
        public static readonly uint3 back = new uint3(0u, 0u, -1u);
        ///<summary>(0, 0, 1)</summary>
        public static readonly uint3 forward = new uint3(0u, 0u, 1u);
        #endregion

        public uint x;
        public uint y;
        public uint z;

        #region IColor
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (uint)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (uint)value; }
        public float b { [IN(LINE)] get => (float)z; [IN(LINE)] set => z = (uint)value; }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set { } }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector1<uint>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector2<uint>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector3<uint>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe uint this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint3* array = &this) { return ((uint*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public uint3(float x, float y, float z) { this.x = (uint)x; this.y = (uint)y; this.z = (uint)z; }
        [IN(LINE)] public uint3(float v) { x = (uint)v; y = (uint)v; z = (uint)v; }
        [IN(LINE)] public uint3(float3 v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }
        [IN(LINE)] public uint3(double x, double y, double z) { this.x = (uint)x; this.y = (uint)y; this.z = (uint)z; }
        [IN(LINE)] public uint3(double v) { x = (uint)v; y = (uint)v; z = (uint)v; }
        [IN(LINE)] public uint3(double3 v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }
        [IN(LINE)] public uint3(int x, int y, int z) { this.x = (uint)x; this.y = (uint)y; this.z = (uint)z; }
        [IN(LINE)] public uint3(int v) { x = (uint)v; y = (uint)v; z = (uint)v; }
        [IN(LINE)] public uint3(int3 v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }
        [IN(LINE)] public uint3(uint x, uint y, uint z) { this.x = x; this.y = y; this.z = z; }
        [IN(LINE)] public uint3(uint v) { x = v; y = v; z = v; }
        [IN(LINE)] public uint3(uint3 v) { x = v.x; y = v.y; z = v.z; }

        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static uint3 operator *(uint3 a, uint3 b) => new uint3(a.x * b.x, a.y * b.y, a.z * b.z);
        [IN(LINE)] public static uint3 operator *(uint3 a, uint b) => new uint3(a.x * b, a.y * b, a.z * b);
        [IN(LINE)] public static uint3 operator *(uint a, uint3 b) => new uint3(a * b.x, a * b.y, a * b.z);

        [IN(LINE)] public static uint3 operator +(uint3 a, uint3 b) => new uint3(a.x + b.x, a.y + b.y, a.z + b.z);
        [IN(LINE)] public static uint3 operator +(uint3 a, uint b) => new uint3(a.x + b, a.y + b, a.z + b);
        [IN(LINE)] public static uint3 operator +(uint a, uint3 b) => new uint3(a + b.x, a + b.y, a + b.z);

        [IN(LINE)] public static uint3 operator -(uint3 a, uint3 b) => new uint3(a.x - b.x, a.y - b.y, a.z - b.z);
        [IN(LINE)] public static uint3 operator -(uint3 a, uint b) => new uint3(a.x - b, a.y - b, a.z - b);
        [IN(LINE)] public static uint3 operator -(uint a, uint3 b) => new uint3(a - b.x, a - b.y, a - b.z);

        [IN(LINE)] public static uint3 operator /(uint3 a, uint3 b) => new uint3(a.x / b.x, a.y / b.y, a.z / b.z);
        [IN(LINE)] public static uint3 operator /(uint3 a, uint b) => new uint3(a.x / b, a.y / b, a.z / b);
        [IN(LINE)] public static uint3 operator /(uint a, uint3 b) => new uint3(a / b.x, a / b.y, a / b.z);

        [IN(LINE)] public static uint3 operator %(uint3 a, uint3 b) => new uint3(a.x % b.x, a.y % b.y, a.z % b.z);
        [IN(LINE)] public static uint3 operator %(uint3 a, uint b) => new uint3(a.x % b, a.y % b, a.z % b);
        [IN(LINE)] public static uint3 operator %(uint a, uint3 b) => new uint3(a % b.x, a % b.y, a % b.z);

        [IN(LINE)] public static uint3 operator ++(uint3 a) => new uint3(++a.x, ++a.y, ++a.z);
        [IN(LINE)] public static uint3 operator --(uint3 a) => new uint3(--a.x, --a.y, --a.z);
        [IN(LINE)] public static uint3 operator -(uint3 a) => new uint3(-a.x, -a.y, -a.z);
        [IN(LINE)] public static uint3 operator +(uint3 a) => new uint3(+a.x, +a.y, +a.z);
        #endregion

        #region Bits
        [IN(LINE)] public static uint3 operator ~(uint3 a) => new uint3(~a.x, ~a.y, ~a.z);
        [IN(LINE)] public static uint3 operator <<(uint3 a, int n) => new uint3(a.x << n, a.y << n, a.z << n);
        [IN(LINE)] public static uint3 operator >>(uint3 a, int n) => new uint3(a.x >> n, a.y >> n, a.z >> n);

        [IN(LINE)] public static uint3 operator |(uint3 a, uint3 b) => new uint3(a.x | b.x, a.y | b.y, a.z | b.z);
        [IN(LINE)] public static uint3 operator |(uint3 a, uint b) => new uint3(a.x | b, a.y | b, a.z | b);
        [IN(LINE)] public static uint3 operator |(uint a, uint3 b) => new uint3(a | b.x, a | b.y, a | b.z);

        [IN(LINE)] public static uint3 operator &(uint3 a, uint3 b) => new uint3(a.x & b.x, a.y & b.y, a.z & b.z);
        [IN(LINE)] public static uint3 operator &(uint3 a, uint b) => new uint3(a.x & b, a.y & b, a.z & b);
        [IN(LINE)] public static uint3 operator &(uint a, uint3 b) => new uint3(a & b.x, a & b.y, a & b.z);

        [IN(LINE)] public static uint3 operator ^(uint3 a, uint3 b) => new uint3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z);
        [IN(LINE)] public static uint3 operator ^(uint3 a, uint b) => new uint3(a.x ^ b, a.y ^ b, a.z ^ b);
        [IN(LINE)] public static uint3 operator ^(uint a, uint3 b) => new uint3(a ^ b.x, a ^ b.y, a ^ b.z);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(uint3 a, uint3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [IN(LINE)] public static bool operator ==(uint3 a, uint b) => a.x == b && a.y == b && a.z == b;
        [IN(LINE)] public static bool operator ==(uint a, uint3 b) => a == b.x && a == b.y && a == b.z;

        [IN(LINE)] public static bool operator !=(uint3 a, uint3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [IN(LINE)] public static bool operator !=(uint3 a, uint b) => a.x != b || a.y != b || a.z != b;
        [IN(LINE)] public static bool operator !=(uint a, uint3 b) => a != b.x || a != b.y || a != b.z;
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 xx { [IN(LINE)] get => new uint2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 xy { [IN(LINE)] get => new uint2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 xz { [IN(LINE)] get => new uint2(x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 x_ { [IN(LINE)] get => new uint2(x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 yx { [IN(LINE)] get => new uint2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 yy { [IN(LINE)] get => new uint2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 yz { [IN(LINE)] get => new uint2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 y_ { [IN(LINE)] get => new uint2(y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 zx { [IN(LINE)] get => new uint2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 zy { [IN(LINE)] get => new uint2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 zz { [IN(LINE)] get => new uint2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 z_ { [IN(LINE)] get => new uint2(z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 _x { [IN(LINE)] get => new uint2(0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 _y { [IN(LINE)] get => new uint2(0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint2 _z { [IN(LINE)] get => new uint2(0u, z); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xxx { [IN(LINE)] get => new uint3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xxy { [IN(LINE)] get => new uint3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xxz { [IN(LINE)] get => new uint3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xx_ { [IN(LINE)] get => new uint3(x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xyx { [IN(LINE)] get => new uint3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xyy { [IN(LINE)] get => new uint3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xyz { [IN(LINE)] get => new uint3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xy_ { [IN(LINE)] get => new uint3(x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xzx { [IN(LINE)] get => new uint3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xzy { [IN(LINE)] get => new uint3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xzz { [IN(LINE)] get => new uint3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 xz_ { [IN(LINE)] get => new uint3(x, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x_x { [IN(LINE)] get => new uint3(x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x_y { [IN(LINE)] get => new uint3(x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x_z { [IN(LINE)] get => new uint3(x, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 x__ { [IN(LINE)] get => new uint3(x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yxx { [IN(LINE)] get => new uint3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yxy { [IN(LINE)] get => new uint3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yxz { [IN(LINE)] get => new uint3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yx_ { [IN(LINE)] get => new uint3(y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yyx { [IN(LINE)] get => new uint3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yyy { [IN(LINE)] get => new uint3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yyz { [IN(LINE)] get => new uint3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yy_ { [IN(LINE)] get => new uint3(y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yzx { [IN(LINE)] get => new uint3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yzy { [IN(LINE)] get => new uint3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yzz { [IN(LINE)] get => new uint3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 yz_ { [IN(LINE)] get => new uint3(y, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y_x { [IN(LINE)] get => new uint3(y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y_y { [IN(LINE)] get => new uint3(y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y_z { [IN(LINE)] get => new uint3(y, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 y__ { [IN(LINE)] get => new uint3(y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zxx { [IN(LINE)] get => new uint3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zxy { [IN(LINE)] get => new uint3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zxz { [IN(LINE)] get => new uint3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zx_ { [IN(LINE)] get => new uint3(z, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zyx { [IN(LINE)] get => new uint3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zyy { [IN(LINE)] get => new uint3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zyz { [IN(LINE)] get => new uint3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zy_ { [IN(LINE)] get => new uint3(z, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zzx { [IN(LINE)] get => new uint3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zzy { [IN(LINE)] get => new uint3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zzz { [IN(LINE)] get => new uint3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 zz_ { [IN(LINE)] get => new uint3(z, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 z_x { [IN(LINE)] get => new uint3(z, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 z_y { [IN(LINE)] get => new uint3(z, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 z_z { [IN(LINE)] get => new uint3(z, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 z__ { [IN(LINE)] get => new uint3(z, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _xx { [IN(LINE)] get => new uint3(0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _xy { [IN(LINE)] get => new uint3(0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _xz { [IN(LINE)] get => new uint3(0u, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _x_ { [IN(LINE)] get => new uint3(0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _yx { [IN(LINE)] get => new uint3(0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _yy { [IN(LINE)] get => new uint3(0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _yz { [IN(LINE)] get => new uint3(0u, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _y_ { [IN(LINE)] get => new uint3(0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _zx { [IN(LINE)] get => new uint3(0u, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _zy { [IN(LINE)] get => new uint3(0u, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _zz { [IN(LINE)] get => new uint3(0u, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 _z_ { [IN(LINE)] get => new uint3(0u, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 __x { [IN(LINE)] get => new uint3(0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 __y { [IN(LINE)] get => new uint3(0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint3 __z { [IN(LINE)] get => new uint3(0u, 0u, z); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxxx { [IN(LINE)] get => new uint4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxxy { [IN(LINE)] get => new uint4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxxz { [IN(LINE)] get => new uint4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxx_ { [IN(LINE)] get => new uint4(x, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxyx { [IN(LINE)] get => new uint4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxyy { [IN(LINE)] get => new uint4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxyz { [IN(LINE)] get => new uint4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxy_ { [IN(LINE)] get => new uint4(x, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxzx { [IN(LINE)] get => new uint4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxzy { [IN(LINE)] get => new uint4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxzz { [IN(LINE)] get => new uint4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xxz_ { [IN(LINE)] get => new uint4(x, x, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx_x { [IN(LINE)] get => new uint4(x, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx_y { [IN(LINE)] get => new uint4(x, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx_z { [IN(LINE)] get => new uint4(x, x, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xx__ { [IN(LINE)] get => new uint4(x, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyxx { [IN(LINE)] get => new uint4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyxy { [IN(LINE)] get => new uint4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyxz { [IN(LINE)] get => new uint4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyx_ { [IN(LINE)] get => new uint4(x, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyyx { [IN(LINE)] get => new uint4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyyy { [IN(LINE)] get => new uint4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyyz { [IN(LINE)] get => new uint4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyy_ { [IN(LINE)] get => new uint4(x, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyzx { [IN(LINE)] get => new uint4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyzy { [IN(LINE)] get => new uint4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyzz { [IN(LINE)] get => new uint4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xyz_ { [IN(LINE)] get => new uint4(x, y, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy_x { [IN(LINE)] get => new uint4(x, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy_y { [IN(LINE)] get => new uint4(x, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy_z { [IN(LINE)] get => new uint4(x, y, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xy__ { [IN(LINE)] get => new uint4(x, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzxx { [IN(LINE)] get => new uint4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzxy { [IN(LINE)] get => new uint4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzxz { [IN(LINE)] get => new uint4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzx_ { [IN(LINE)] get => new uint4(x, z, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzyx { [IN(LINE)] get => new uint4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzyy { [IN(LINE)] get => new uint4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzyz { [IN(LINE)] get => new uint4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzy_ { [IN(LINE)] get => new uint4(x, z, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzzx { [IN(LINE)] get => new uint4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzzy { [IN(LINE)] get => new uint4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzzz { [IN(LINE)] get => new uint4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xzz_ { [IN(LINE)] get => new uint4(x, z, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xz_x { [IN(LINE)] get => new uint4(x, z, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xz_y { [IN(LINE)] get => new uint4(x, z, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xz_z { [IN(LINE)] get => new uint4(x, z, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 xz__ { [IN(LINE)] get => new uint4(x, z, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_xx { [IN(LINE)] get => new uint4(x, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_xy { [IN(LINE)] get => new uint4(x, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_xz { [IN(LINE)] get => new uint4(x, 0u, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_x_ { [IN(LINE)] get => new uint4(x, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_yx { [IN(LINE)] get => new uint4(x, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_yy { [IN(LINE)] get => new uint4(x, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_yz { [IN(LINE)] get => new uint4(x, 0u, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_y_ { [IN(LINE)] get => new uint4(x, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_zx { [IN(LINE)] get => new uint4(x, 0u, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_zy { [IN(LINE)] get => new uint4(x, 0u, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_zz { [IN(LINE)] get => new uint4(x, 0u, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x_z_ { [IN(LINE)] get => new uint4(x, 0u, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x__x { [IN(LINE)] get => new uint4(x, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x__y { [IN(LINE)] get => new uint4(x, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x__z { [IN(LINE)] get => new uint4(x, 0u, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 x___ { [IN(LINE)] get => new uint4(x, 0u, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxxx { [IN(LINE)] get => new uint4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxxy { [IN(LINE)] get => new uint4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxxz { [IN(LINE)] get => new uint4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxx_ { [IN(LINE)] get => new uint4(y, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxyx { [IN(LINE)] get => new uint4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxyy { [IN(LINE)] get => new uint4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxyz { [IN(LINE)] get => new uint4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxy_ { [IN(LINE)] get => new uint4(y, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxzx { [IN(LINE)] get => new uint4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxzy { [IN(LINE)] get => new uint4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxzz { [IN(LINE)] get => new uint4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yxz_ { [IN(LINE)] get => new uint4(y, x, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx_x { [IN(LINE)] get => new uint4(y, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx_y { [IN(LINE)] get => new uint4(y, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx_z { [IN(LINE)] get => new uint4(y, x, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yx__ { [IN(LINE)] get => new uint4(y, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyxx { [IN(LINE)] get => new uint4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyxy { [IN(LINE)] get => new uint4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyxz { [IN(LINE)] get => new uint4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyx_ { [IN(LINE)] get => new uint4(y, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyyx { [IN(LINE)] get => new uint4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyyy { [IN(LINE)] get => new uint4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyyz { [IN(LINE)] get => new uint4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyy_ { [IN(LINE)] get => new uint4(y, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyzx { [IN(LINE)] get => new uint4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyzy { [IN(LINE)] get => new uint4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyzz { [IN(LINE)] get => new uint4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yyz_ { [IN(LINE)] get => new uint4(y, y, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy_x { [IN(LINE)] get => new uint4(y, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy_y { [IN(LINE)] get => new uint4(y, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy_z { [IN(LINE)] get => new uint4(y, y, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yy__ { [IN(LINE)] get => new uint4(y, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzxx { [IN(LINE)] get => new uint4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzxy { [IN(LINE)] get => new uint4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzxz { [IN(LINE)] get => new uint4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzx_ { [IN(LINE)] get => new uint4(y, z, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzyx { [IN(LINE)] get => new uint4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzyy { [IN(LINE)] get => new uint4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzyz { [IN(LINE)] get => new uint4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzy_ { [IN(LINE)] get => new uint4(y, z, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzzx { [IN(LINE)] get => new uint4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzzy { [IN(LINE)] get => new uint4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzzz { [IN(LINE)] get => new uint4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yzz_ { [IN(LINE)] get => new uint4(y, z, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yz_x { [IN(LINE)] get => new uint4(y, z, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yz_y { [IN(LINE)] get => new uint4(y, z, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yz_z { [IN(LINE)] get => new uint4(y, z, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 yz__ { [IN(LINE)] get => new uint4(y, z, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_xx { [IN(LINE)] get => new uint4(y, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_xy { [IN(LINE)] get => new uint4(y, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_xz { [IN(LINE)] get => new uint4(y, 0u, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_x_ { [IN(LINE)] get => new uint4(y, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_yx { [IN(LINE)] get => new uint4(y, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_yy { [IN(LINE)] get => new uint4(y, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_yz { [IN(LINE)] get => new uint4(y, 0u, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_y_ { [IN(LINE)] get => new uint4(y, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_zx { [IN(LINE)] get => new uint4(y, 0u, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_zy { [IN(LINE)] get => new uint4(y, 0u, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_zz { [IN(LINE)] get => new uint4(y, 0u, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y_z_ { [IN(LINE)] get => new uint4(y, 0u, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y__x { [IN(LINE)] get => new uint4(y, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y__y { [IN(LINE)] get => new uint4(y, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y__z { [IN(LINE)] get => new uint4(y, 0u, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 y___ { [IN(LINE)] get => new uint4(y, 0u, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxxx { [IN(LINE)] get => new uint4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxxy { [IN(LINE)] get => new uint4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxxz { [IN(LINE)] get => new uint4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxx_ { [IN(LINE)] get => new uint4(z, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxyx { [IN(LINE)] get => new uint4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxyy { [IN(LINE)] get => new uint4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxyz { [IN(LINE)] get => new uint4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxy_ { [IN(LINE)] get => new uint4(z, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxzx { [IN(LINE)] get => new uint4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxzy { [IN(LINE)] get => new uint4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxzz { [IN(LINE)] get => new uint4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zxz_ { [IN(LINE)] get => new uint4(z, x, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zx_x { [IN(LINE)] get => new uint4(z, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zx_y { [IN(LINE)] get => new uint4(z, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zx_z { [IN(LINE)] get => new uint4(z, x, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zx__ { [IN(LINE)] get => new uint4(z, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyxx { [IN(LINE)] get => new uint4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyxy { [IN(LINE)] get => new uint4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyxz { [IN(LINE)] get => new uint4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyx_ { [IN(LINE)] get => new uint4(z, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyyx { [IN(LINE)] get => new uint4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyyy { [IN(LINE)] get => new uint4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyyz { [IN(LINE)] get => new uint4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyy_ { [IN(LINE)] get => new uint4(z, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyzx { [IN(LINE)] get => new uint4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyzy { [IN(LINE)] get => new uint4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyzz { [IN(LINE)] get => new uint4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zyz_ { [IN(LINE)] get => new uint4(z, y, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zy_x { [IN(LINE)] get => new uint4(z, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zy_y { [IN(LINE)] get => new uint4(z, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zy_z { [IN(LINE)] get => new uint4(z, y, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zy__ { [IN(LINE)] get => new uint4(z, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzxx { [IN(LINE)] get => new uint4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzxy { [IN(LINE)] get => new uint4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzxz { [IN(LINE)] get => new uint4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzx_ { [IN(LINE)] get => new uint4(z, z, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzyx { [IN(LINE)] get => new uint4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzyy { [IN(LINE)] get => new uint4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzyz { [IN(LINE)] get => new uint4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzy_ { [IN(LINE)] get => new uint4(z, z, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzzx { [IN(LINE)] get => new uint4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzzy { [IN(LINE)] get => new uint4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzzz { [IN(LINE)] get => new uint4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zzz_ { [IN(LINE)] get => new uint4(z, z, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zz_x { [IN(LINE)] get => new uint4(z, z, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zz_y { [IN(LINE)] get => new uint4(z, z, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zz_z { [IN(LINE)] get => new uint4(z, z, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 zz__ { [IN(LINE)] get => new uint4(z, z, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_xx { [IN(LINE)] get => new uint4(z, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_xy { [IN(LINE)] get => new uint4(z, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_xz { [IN(LINE)] get => new uint4(z, 0u, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_x_ { [IN(LINE)] get => new uint4(z, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_yx { [IN(LINE)] get => new uint4(z, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_yy { [IN(LINE)] get => new uint4(z, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_yz { [IN(LINE)] get => new uint4(z, 0u, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_y_ { [IN(LINE)] get => new uint4(z, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_zx { [IN(LINE)] get => new uint4(z, 0u, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_zy { [IN(LINE)] get => new uint4(z, 0u, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_zz { [IN(LINE)] get => new uint4(z, 0u, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z_z_ { [IN(LINE)] get => new uint4(z, 0u, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z__x { [IN(LINE)] get => new uint4(z, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z__y { [IN(LINE)] get => new uint4(z, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z__z { [IN(LINE)] get => new uint4(z, 0u, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 z___ { [IN(LINE)] get => new uint4(z, 0u, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xxx { [IN(LINE)] get => new uint4(0u, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xxy { [IN(LINE)] get => new uint4(0u, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xxz { [IN(LINE)] get => new uint4(0u, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xx_ { [IN(LINE)] get => new uint4(0u, x, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xyx { [IN(LINE)] get => new uint4(0u, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xyy { [IN(LINE)] get => new uint4(0u, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xyz { [IN(LINE)] get => new uint4(0u, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xy_ { [IN(LINE)] get => new uint4(0u, x, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xzx { [IN(LINE)] get => new uint4(0u, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xzy { [IN(LINE)] get => new uint4(0u, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xzz { [IN(LINE)] get => new uint4(0u, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _xz_ { [IN(LINE)] get => new uint4(0u, x, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x_x { [IN(LINE)] get => new uint4(0u, x, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x_y { [IN(LINE)] get => new uint4(0u, x, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x_z { [IN(LINE)] get => new uint4(0u, x, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _x__ { [IN(LINE)] get => new uint4(0u, x, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yxx { [IN(LINE)] get => new uint4(0u, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yxy { [IN(LINE)] get => new uint4(0u, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yxz { [IN(LINE)] get => new uint4(0u, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yx_ { [IN(LINE)] get => new uint4(0u, y, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yyx { [IN(LINE)] get => new uint4(0u, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yyy { [IN(LINE)] get => new uint4(0u, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yyz { [IN(LINE)] get => new uint4(0u, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yy_ { [IN(LINE)] get => new uint4(0u, y, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yzx { [IN(LINE)] get => new uint4(0u, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yzy { [IN(LINE)] get => new uint4(0u, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yzz { [IN(LINE)] get => new uint4(0u, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _yz_ { [IN(LINE)] get => new uint4(0u, y, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y_x { [IN(LINE)] get => new uint4(0u, y, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y_y { [IN(LINE)] get => new uint4(0u, y, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y_z { [IN(LINE)] get => new uint4(0u, y, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _y__ { [IN(LINE)] get => new uint4(0u, y, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zxx { [IN(LINE)] get => new uint4(0u, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zxy { [IN(LINE)] get => new uint4(0u, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zxz { [IN(LINE)] get => new uint4(0u, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zx_ { [IN(LINE)] get => new uint4(0u, z, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zyx { [IN(LINE)] get => new uint4(0u, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zyy { [IN(LINE)] get => new uint4(0u, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zyz { [IN(LINE)] get => new uint4(0u, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zy_ { [IN(LINE)] get => new uint4(0u, z, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zzx { [IN(LINE)] get => new uint4(0u, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zzy { [IN(LINE)] get => new uint4(0u, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zzz { [IN(LINE)] get => new uint4(0u, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _zz_ { [IN(LINE)] get => new uint4(0u, z, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _z_x { [IN(LINE)] get => new uint4(0u, z, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _z_y { [IN(LINE)] get => new uint4(0u, z, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _z_z { [IN(LINE)] get => new uint4(0u, z, 0u, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 _z__ { [IN(LINE)] get => new uint4(0u, z, 0u, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __xx { [IN(LINE)] get => new uint4(0u, 0u, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __xy { [IN(LINE)] get => new uint4(0u, 0u, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __xz { [IN(LINE)] get => new uint4(0u, 0u, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __x_ { [IN(LINE)] get => new uint4(0u, 0u, x, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __yx { [IN(LINE)] get => new uint4(0u, 0u, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __yy { [IN(LINE)] get => new uint4(0u, 0u, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __yz { [IN(LINE)] get => new uint4(0u, 0u, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __y_ { [IN(LINE)] get => new uint4(0u, 0u, y, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __zx { [IN(LINE)] get => new uint4(0u, 0u, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __zy { [IN(LINE)] get => new uint4(0u, 0u, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __zz { [IN(LINE)] get => new uint4(0u, 0u, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 __z_ { [IN(LINE)] get => new uint4(0u, 0u, z, 0u); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 ___x { [IN(LINE)] get => new uint4(0u, 0u, 0u, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 ___y { [IN(LINE)] get => new uint4(0u, 0u, 0u, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint4 ___z { [IN(LINE)] get => new uint4(0u, 0u, 0u, z); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => math.Hash(this);
        public override bool Equals(object o) => o is uint3 target && Equals(target);
        [IN(LINE)] public bool Equals(uint3 a) => x == a.x && y == a.y && z == a.z;
        public override string ToString() => $"uint3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public uint x, y, z;
            public DebuggerProxy(uint3 v) { x = v.x; y = v.y; z = v.z; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<uint, uint3> IEnumerableVector<uint, uint3>.GetEnumerator() => new VectorEnumerator<uint, uint3>(this);
        IEnumerator<uint> IEnumerable<uint>.GetEnumerator() => new VectorEnumerator<uint, uint3>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<uint, uint3>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly uint* _pointer;
            private sbyte _index;
            [IN(LINE)]
            public Enumerator(in uint3 value)
            {
                fixed (uint3* array = &value)
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
