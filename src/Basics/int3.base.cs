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
using static DCFApixels.DataMath.InlineConsts;
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
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public partial struct int3 :
        IEquatable<int3>,
        IFormattable,
        IVector3Impl<int>,
        IColor,
        IEnumerableVector<int, int3>
    {
        #region Consts
        public const int Count = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly int3 zero = new int3(0, 0, 0);
        ///<summary>(1, 1, 1)</summary>
        public static readonly int3 one = new int3(1, 1, 1);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly int3 left = new int3(unchecked((int)-1), 0, 0);
        ///<summary>(1, 0, 0)</summary>
        public static readonly int3 right = new int3(1, 0, 0);
        ///<summary>(0, -1, 0)</summary>
        public static readonly int3 down = new int3(0, unchecked((int)-1), 0);
        ///<summary>(0, 1, 0)</summary>
        public static readonly int3 up = new int3(0, 1, 0);
        ///<summary>(0, 0, -1)</summary>
        public static readonly int3 back = new int3(0, 0, unchecked((int)-1));
        ///<summary>(0, 0, 1)</summary>
        public static readonly int3 forward = new int3(0, 0, 1);
        #endregion

        public int x;
        public int y;
        public int z;

        #region IColor
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (int)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (int)value; } }
        public float b { [IN(LINE)] get { return (float)z; } [IN(LINE)] set { z = (int)value; } }
        public float a { [IN(LINE)] get { return 1f; } [IN(LINE)] set { } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector1<int>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector2<int>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector3<int>.z { [IN(LINE)] get { return z; } [IN(LINE)] set { z = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public unsafe int this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (int3* array = &this) { return ((int*)array)[index]; }
            }
            [IN(LINE)]
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (int* array = &x) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is int cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(int); }
        #endregion

        #region Constructors
        [IN(LINE)] public int3(int x, int y, int z) { this.x = x; this.y = y; this.z = z; }
        [IN(LINE)] public int3(int2 a, int z) { this.x = a.x; this.y = a.y; this.z = z; }
        [IN(LINE)] public int3(int x, int2 a) { this.x = x; this.y = a.x; this.z = a.y; }

        [IN(LINE)] public int3((int x, int y, int z) a) { this.x = a.x; this.y = a.y; this.z = a.z; }
        [IN(LINE)] public int3((int x, int y) a, int z) { this.x = a.x; this.y = a.y; this.z = z; }
        [IN(LINE)] public int3(int x, (int x, int y) a) { this.x = x; this.y = a.x; this.z = a.y; }

        [IN(LINE)] public int3(float v) { x = (int)v; y = (int)v; z = (int)v; }
        [IN(LINE)] public int3(float3 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; }
        [IN(LINE)] public int3(double v) { x = (int)v; y = (int)v; z = (int)v; }
        [IN(LINE)] public int3(double3 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; }
        [IN(LINE)] public int3(int v) { x = v; y = v; z = v; }
        [IN(LINE)] public int3(int3 v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public int3(uint v) { x = (int)v; y = (int)v; z = (int)v; }
        [IN(LINE)] public int3(uint3 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; }

        [IN(LINE)]
        public int3(ReadOnlySpan<int> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2];
#else
            this = Unsafe.ReadUnaligned<int3>(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out int x, out int y, out int z) { x = this.x; y = this.y; z = this.z; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static int3 operator +(int3 a, int3 b) { return new int3(a.x + b.x, a.y + b.y, a.z + b.z); }
        [IN(LINE)] public static int3 operator +(int3 a, int b) { return new int3(a.x + b, a.y + b, a.z + b); }
        [IN(LINE)] public static int3 operator +(int a, int3 b) { return new int3(a + b.x, a + b.y, a + b.z); }

        [IN(LINE)] public static int3 operator -(int3 a, int3 b) { return new int3(a.x - b.x, a.y - b.y, a.z - b.z); }
        [IN(LINE)] public static int3 operator -(int3 a, int b) { return new int3(a.x - b, a.y - b, a.z - b); }
        [IN(LINE)] public static int3 operator -(int a, int3 b) { return new int3(a - b.x, a - b.y, a - b.z); }

        [IN(LINE)] public static int3 operator *(int3 a, int3 b) { return new int3(a.x * b.x, a.y * b.y, a.z * b.z); }
        [IN(LINE)] public static int3 operator *(int3 a, int b) { return new int3(a.x * b, a.y * b, a.z * b); }
        [IN(LINE)] public static int3 operator *(int a, int3 b) { return new int3(a * b.x, a * b.y, a * b.z); }

        [IN(LINE)] public static int3 operator /(int3 a, int3 b) { return new int3(a.x / b.x, a.y / b.y, a.z / b.z); }
        [IN(LINE)] public static int3 operator /(int3 a, int b) { return new int3(a.x / b, a.y / b, a.z / b); }
        [IN(LINE)] public static int3 operator /(int a, int3 b) { return new int3(a / b.x, a / b.y, a / b.z); }

        [IN(LINE)] public static int3 operator %(int3 a, int3 b) { return new int3(a.x % b.x, a.y % b.y, a.z % b.z); }
        [IN(LINE)] public static int3 operator %(int3 a, int b) { return new int3(a.x % b, a.y % b, a.z % b); }
        [IN(LINE)] public static int3 operator %(int a, int3 b) { return new int3(a % b.x, a % b.y, a % b.z); }

        [IN(LINE)] public static int3 operator ++(int3 a) { return new int3(++a.x, ++a.y, ++a.z); }
        [IN(LINE)] public static int3 operator --(int3 a) { return new int3(--a.x, --a.y, --a.z); }
        [IN(LINE)] public static int3 operator +(int3 a) { return new int3(+a.x, +a.y, +a.z); }
        [IN(LINE)] public static int3 operator -(int3 a) { return new int3((int)-a.x, (int)-a.y, (int)-a.z); }
        #endregion

        #region Bits
        [IN(LINE)] public static int3 operator ~(int3 a) { return new int3(~a.x, ~a.y, ~a.z); }
        [IN(LINE)] public static int3 operator <<(int3 a, int n) { return new int3(a.x << n, a.y << n, a.z << n); }
        [IN(LINE)] public static int3 operator >>(int3 a, int n) { return new int3(a.x >> n, a.y >> n, a.z >> n); }

        [IN(LINE)] public static int3 operator |(int3 a, int3 b) { return new int3(a.x | b.x, a.y | b.y, a.z | b.z); }
        [IN(LINE)] public static int3 operator |(int3 a, int b) { return new int3(a.x | b, a.y | b, a.z | b); }
        [IN(LINE)] public static int3 operator |(int a, int3 b) { return new int3(a | b.x, a | b.y, a | b.z); }

        [IN(LINE)] public static int3 operator &(int3 a, int3 b) { return new int3(a.x & b.x, a.y & b.y, a.z & b.z); }
        [IN(LINE)] public static int3 operator &(int3 a, int b) { return new int3(a.x & b, a.y & b, a.z & b); }
        [IN(LINE)] public static int3 operator &(int a, int3 b) { return new int3(a & b.x, a & b.y, a & b.z); }

        [IN(LINE)] public static int3 operator ^(int3 a, int3 b) { return new int3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z); }
        [IN(LINE)] public static int3 operator ^(int3 a, int b) { return new int3(a.x ^ b, a.y ^ b, a.z ^ b); }
        [IN(LINE)] public static int3 operator ^(int a, int3 b) { return new int3(a ^ b.x, a ^ b.y, a ^ b.z); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool3 operator <(int3 a, int3 b) { return new bool3(a.x < b.x, a.y < b.y, a.z < b.z); }
        [IN(LINE)] public static bool3 operator <(int3 a, int b) { return new bool3(a.x < b, a.y < b, a.z < b); }
        [IN(LINE)] public static bool3 operator <(int a, int3 b) { return new bool3(a < b.x, a < b.y, a < b.z); }

        [IN(LINE)] public static bool3 operator <=(int3 a, int3 b) { return new bool3(a.x <= b.x, a.y <= b.y, a.z <= b.z); }
        [IN(LINE)] public static bool3 operator <=(int3 a, int b) { return new bool3(a.x <= b, a.y <= b, a.z <= b); }
        [IN(LINE)] public static bool3 operator <=(int a, int3 b) { return new bool3(a <= b.x, a <= b.y, a <= b.z); }

        [IN(LINE)] public static bool3 operator >(int3 a, int3 b) { return new bool3(a.x > b.x, a.y > b.y, a.z > b.z); }
        [IN(LINE)] public static bool3 operator >(int3 a, int b) { return new bool3(a.x > b, a.y > b, a.z > b); }
        [IN(LINE)] public static bool3 operator >(int a, int3 b) { return new bool3(a > b.x, a > b.y, a > b.z); }

        [IN(LINE)] public static bool3 operator >=(int3 a, int3 b) { return new bool3(a.x >= b.x, a.y >= b.y, a.z >= b.z); }
        [IN(LINE)] public static bool3 operator >=(int3 a, int b) { return new bool3(a.x >= b, a.y >= b, a.z >= b); }
        [IN(LINE)] public static bool3 operator >=(int a, int3 b) { return new bool3(a >= b.x, a >= b.y, a >= b.z); }

        [IN(LINE)] public static bool3 operator ==(int3 a, int3 b) { return new bool3(a.x == b.x, a.y == b.y, a.z == b.z); }
        [IN(LINE)] public static bool3 operator ==(int3 a, int b) { return new bool3(a.x == b, a.y == b, a.z == b); }
        [IN(LINE)] public static bool3 operator ==(int a, int3 b) { return new bool3(a == b.x, a == b.y, a == b.z); }

        [IN(LINE)] public static bool3 operator !=(int3 a, int3 b) { return new bool3(a.x != b.x, a.y != b.y, a.z != b.z); }
        [IN(LINE)] public static bool3 operator !=(int3 a, int b) { return new bool3(a.x != b, a.y != b, a.z != b); }
        [IN(LINE)] public static bool3 operator !=(int a, int3 b) { return new bool3(a != b.x, a != b.y, a != b.z); }
        #endregion

        #region Other
        [IN(LINE)] public static int3 operator !(int3 a) { return 1 - a; }
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xx { [IN(LINE)] get => new int2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xy { [IN(LINE)] get => new int2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xz { [IN(LINE)] get => new int2(x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 x_ { [IN(LINE)] get => new int2(x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yx { [IN(LINE)] get => new int2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yy { [IN(LINE)] get => new int2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yz { [IN(LINE)] get => new int2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 y_ { [IN(LINE)] get => new int2(y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zx { [IN(LINE)] get => new int2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zy { [IN(LINE)] get => new int2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zz { [IN(LINE)] get => new int2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 z_ { [IN(LINE)] get => new int2(z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _x { [IN(LINE)] get => new int2(0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _y { [IN(LINE)] get => new int2(0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _z { [IN(LINE)] get => new int2(0, z); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxx { [IN(LINE)] get => new int3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxy { [IN(LINE)] get => new int3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxz { [IN(LINE)] get => new int3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xx_ { [IN(LINE)] get => new int3(x, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyx { [IN(LINE)] get => new int3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyy { [IN(LINE)] get => new int3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyz { [IN(LINE)] get => new int3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xy_ { [IN(LINE)] get => new int3(x, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzx { [IN(LINE)] get => new int3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzy { [IN(LINE)] get => new int3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzz { [IN(LINE)] get => new int3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xz_ { [IN(LINE)] get => new int3(x, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_x { [IN(LINE)] get => new int3(x, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_y { [IN(LINE)] get => new int3(x, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_z { [IN(LINE)] get => new int3(x, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x__ { [IN(LINE)] get => new int3(x, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxx { [IN(LINE)] get => new int3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxy { [IN(LINE)] get => new int3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxz { [IN(LINE)] get => new int3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yx_ { [IN(LINE)] get => new int3(y, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyx { [IN(LINE)] get => new int3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyy { [IN(LINE)] get => new int3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyz { [IN(LINE)] get => new int3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yy_ { [IN(LINE)] get => new int3(y, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzx { [IN(LINE)] get => new int3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzy { [IN(LINE)] get => new int3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzz { [IN(LINE)] get => new int3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yz_ { [IN(LINE)] get => new int3(y, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_x { [IN(LINE)] get => new int3(y, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_y { [IN(LINE)] get => new int3(y, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_z { [IN(LINE)] get => new int3(y, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y__ { [IN(LINE)] get => new int3(y, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxx { [IN(LINE)] get => new int3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxy { [IN(LINE)] get => new int3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxz { [IN(LINE)] get => new int3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zx_ { [IN(LINE)] get => new int3(z, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyx { [IN(LINE)] get => new int3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyy { [IN(LINE)] get => new int3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyz { [IN(LINE)] get => new int3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zy_ { [IN(LINE)] get => new int3(z, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzx { [IN(LINE)] get => new int3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzy { [IN(LINE)] get => new int3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzz { [IN(LINE)] get => new int3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zz_ { [IN(LINE)] get => new int3(z, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_x { [IN(LINE)] get => new int3(z, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_y { [IN(LINE)] get => new int3(z, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_z { [IN(LINE)] get => new int3(z, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z__ { [IN(LINE)] get => new int3(z, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xx { [IN(LINE)] get => new int3(0, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xy { [IN(LINE)] get => new int3(0, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xz { [IN(LINE)] get => new int3(0, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _x_ { [IN(LINE)] get => new int3(0, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yx { [IN(LINE)] get => new int3(0, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yy { [IN(LINE)] get => new int3(0, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yz { [IN(LINE)] get => new int3(0, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _y_ { [IN(LINE)] get => new int3(0, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zx { [IN(LINE)] get => new int3(0, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zy { [IN(LINE)] get => new int3(0, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zz { [IN(LINE)] get => new int3(0, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _z_ { [IN(LINE)] get => new int3(0, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __x { [IN(LINE)] get => new int3(0, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __y { [IN(LINE)] get => new int3(0, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __z { [IN(LINE)] get => new int3(0, 0, z); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxx { [IN(LINE)] get => new int4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxy { [IN(LINE)] get => new int4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxz { [IN(LINE)] get => new int4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxx_ { [IN(LINE)] get => new int4(x, x, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyx { [IN(LINE)] get => new int4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyy { [IN(LINE)] get => new int4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyz { [IN(LINE)] get => new int4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxy_ { [IN(LINE)] get => new int4(x, x, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzx { [IN(LINE)] get => new int4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzy { [IN(LINE)] get => new int4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzz { [IN(LINE)] get => new int4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxz_ { [IN(LINE)] get => new int4(x, x, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_x { [IN(LINE)] get => new int4(x, x, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_y { [IN(LINE)] get => new int4(x, x, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_z { [IN(LINE)] get => new int4(x, x, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx__ { [IN(LINE)] get => new int4(x, x, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxx { [IN(LINE)] get => new int4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxy { [IN(LINE)] get => new int4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxz { [IN(LINE)] get => new int4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyx_ { [IN(LINE)] get => new int4(x, y, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyx { [IN(LINE)] get => new int4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyy { [IN(LINE)] get => new int4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyz { [IN(LINE)] get => new int4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyy_ { [IN(LINE)] get => new int4(x, y, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzx { [IN(LINE)] get => new int4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzy { [IN(LINE)] get => new int4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzz { [IN(LINE)] get => new int4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyz_ { [IN(LINE)] get => new int4(x, y, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_x { [IN(LINE)] get => new int4(x, y, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_y { [IN(LINE)] get => new int4(x, y, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_z { [IN(LINE)] get => new int4(x, y, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy__ { [IN(LINE)] get => new int4(x, y, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxx { [IN(LINE)] get => new int4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxy { [IN(LINE)] get => new int4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxz { [IN(LINE)] get => new int4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzx_ { [IN(LINE)] get => new int4(x, z, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyx { [IN(LINE)] get => new int4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyy { [IN(LINE)] get => new int4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyz { [IN(LINE)] get => new int4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzy_ { [IN(LINE)] get => new int4(x, z, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzx { [IN(LINE)] get => new int4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzy { [IN(LINE)] get => new int4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzz { [IN(LINE)] get => new int4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzz_ { [IN(LINE)] get => new int4(x, z, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_x { [IN(LINE)] get => new int4(x, z, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_y { [IN(LINE)] get => new int4(x, z, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_z { [IN(LINE)] get => new int4(x, z, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz__ { [IN(LINE)] get => new int4(x, z, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xx { [IN(LINE)] get => new int4(x, 0, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xy { [IN(LINE)] get => new int4(x, 0, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xz { [IN(LINE)] get => new int4(x, 0, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_x_ { [IN(LINE)] get => new int4(x, 0, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yx { [IN(LINE)] get => new int4(x, 0, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yy { [IN(LINE)] get => new int4(x, 0, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yz { [IN(LINE)] get => new int4(x, 0, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_y_ { [IN(LINE)] get => new int4(x, 0, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zx { [IN(LINE)] get => new int4(x, 0, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zy { [IN(LINE)] get => new int4(x, 0, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zz { [IN(LINE)] get => new int4(x, 0, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_z_ { [IN(LINE)] get => new int4(x, 0, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__x { [IN(LINE)] get => new int4(x, 0, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__y { [IN(LINE)] get => new int4(x, 0, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__z { [IN(LINE)] get => new int4(x, 0, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x___ { [IN(LINE)] get => new int4(x, 0, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxx { [IN(LINE)] get => new int4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxy { [IN(LINE)] get => new int4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxz { [IN(LINE)] get => new int4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxx_ { [IN(LINE)] get => new int4(y, x, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyx { [IN(LINE)] get => new int4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyy { [IN(LINE)] get => new int4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyz { [IN(LINE)] get => new int4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxy_ { [IN(LINE)] get => new int4(y, x, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzx { [IN(LINE)] get => new int4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzy { [IN(LINE)] get => new int4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzz { [IN(LINE)] get => new int4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxz_ { [IN(LINE)] get => new int4(y, x, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_x { [IN(LINE)] get => new int4(y, x, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_y { [IN(LINE)] get => new int4(y, x, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_z { [IN(LINE)] get => new int4(y, x, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx__ { [IN(LINE)] get => new int4(y, x, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxx { [IN(LINE)] get => new int4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxy { [IN(LINE)] get => new int4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxz { [IN(LINE)] get => new int4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyx_ { [IN(LINE)] get => new int4(y, y, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyx { [IN(LINE)] get => new int4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyy { [IN(LINE)] get => new int4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyz { [IN(LINE)] get => new int4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyy_ { [IN(LINE)] get => new int4(y, y, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzx { [IN(LINE)] get => new int4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzy { [IN(LINE)] get => new int4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzz { [IN(LINE)] get => new int4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyz_ { [IN(LINE)] get => new int4(y, y, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_x { [IN(LINE)] get => new int4(y, y, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_y { [IN(LINE)] get => new int4(y, y, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_z { [IN(LINE)] get => new int4(y, y, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy__ { [IN(LINE)] get => new int4(y, y, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxx { [IN(LINE)] get => new int4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxy { [IN(LINE)] get => new int4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxz { [IN(LINE)] get => new int4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzx_ { [IN(LINE)] get => new int4(y, z, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyx { [IN(LINE)] get => new int4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyy { [IN(LINE)] get => new int4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyz { [IN(LINE)] get => new int4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzy_ { [IN(LINE)] get => new int4(y, z, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzx { [IN(LINE)] get => new int4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzy { [IN(LINE)] get => new int4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzz { [IN(LINE)] get => new int4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzz_ { [IN(LINE)] get => new int4(y, z, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_x { [IN(LINE)] get => new int4(y, z, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_y { [IN(LINE)] get => new int4(y, z, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_z { [IN(LINE)] get => new int4(y, z, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz__ { [IN(LINE)] get => new int4(y, z, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xx { [IN(LINE)] get => new int4(y, 0, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xy { [IN(LINE)] get => new int4(y, 0, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xz { [IN(LINE)] get => new int4(y, 0, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_x_ { [IN(LINE)] get => new int4(y, 0, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yx { [IN(LINE)] get => new int4(y, 0, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yy { [IN(LINE)] get => new int4(y, 0, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yz { [IN(LINE)] get => new int4(y, 0, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_y_ { [IN(LINE)] get => new int4(y, 0, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zx { [IN(LINE)] get => new int4(y, 0, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zy { [IN(LINE)] get => new int4(y, 0, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zz { [IN(LINE)] get => new int4(y, 0, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_z_ { [IN(LINE)] get => new int4(y, 0, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__x { [IN(LINE)] get => new int4(y, 0, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__y { [IN(LINE)] get => new int4(y, 0, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__z { [IN(LINE)] get => new int4(y, 0, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y___ { [IN(LINE)] get => new int4(y, 0, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxx { [IN(LINE)] get => new int4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxy { [IN(LINE)] get => new int4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxz { [IN(LINE)] get => new int4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxx_ { [IN(LINE)] get => new int4(z, x, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyx { [IN(LINE)] get => new int4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyy { [IN(LINE)] get => new int4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyz { [IN(LINE)] get => new int4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxy_ { [IN(LINE)] get => new int4(z, x, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzx { [IN(LINE)] get => new int4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzy { [IN(LINE)] get => new int4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzz { [IN(LINE)] get => new int4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxz_ { [IN(LINE)] get => new int4(z, x, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_x { [IN(LINE)] get => new int4(z, x, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_y { [IN(LINE)] get => new int4(z, x, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_z { [IN(LINE)] get => new int4(z, x, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx__ { [IN(LINE)] get => new int4(z, x, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxx { [IN(LINE)] get => new int4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxy { [IN(LINE)] get => new int4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxz { [IN(LINE)] get => new int4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyx_ { [IN(LINE)] get => new int4(z, y, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyx { [IN(LINE)] get => new int4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyy { [IN(LINE)] get => new int4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyz { [IN(LINE)] get => new int4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyy_ { [IN(LINE)] get => new int4(z, y, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzx { [IN(LINE)] get => new int4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzy { [IN(LINE)] get => new int4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzz { [IN(LINE)] get => new int4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyz_ { [IN(LINE)] get => new int4(z, y, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_x { [IN(LINE)] get => new int4(z, y, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_y { [IN(LINE)] get => new int4(z, y, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_z { [IN(LINE)] get => new int4(z, y, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy__ { [IN(LINE)] get => new int4(z, y, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxx { [IN(LINE)] get => new int4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxy { [IN(LINE)] get => new int4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxz { [IN(LINE)] get => new int4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzx_ { [IN(LINE)] get => new int4(z, z, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyx { [IN(LINE)] get => new int4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyy { [IN(LINE)] get => new int4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyz { [IN(LINE)] get => new int4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzy_ { [IN(LINE)] get => new int4(z, z, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzx { [IN(LINE)] get => new int4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzy { [IN(LINE)] get => new int4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzz { [IN(LINE)] get => new int4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzz_ { [IN(LINE)] get => new int4(z, z, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_x { [IN(LINE)] get => new int4(z, z, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_y { [IN(LINE)] get => new int4(z, z, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_z { [IN(LINE)] get => new int4(z, z, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz__ { [IN(LINE)] get => new int4(z, z, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xx { [IN(LINE)] get => new int4(z, 0, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xy { [IN(LINE)] get => new int4(z, 0, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xz { [IN(LINE)] get => new int4(z, 0, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_x_ { [IN(LINE)] get => new int4(z, 0, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yx { [IN(LINE)] get => new int4(z, 0, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yy { [IN(LINE)] get => new int4(z, 0, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yz { [IN(LINE)] get => new int4(z, 0, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_y_ { [IN(LINE)] get => new int4(z, 0, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zx { [IN(LINE)] get => new int4(z, 0, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zy { [IN(LINE)] get => new int4(z, 0, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zz { [IN(LINE)] get => new int4(z, 0, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_z_ { [IN(LINE)] get => new int4(z, 0, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__x { [IN(LINE)] get => new int4(z, 0, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__y { [IN(LINE)] get => new int4(z, 0, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__z { [IN(LINE)] get => new int4(z, 0, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z___ { [IN(LINE)] get => new int4(z, 0, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxx { [IN(LINE)] get => new int4(0, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxy { [IN(LINE)] get => new int4(0, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxz { [IN(LINE)] get => new int4(0, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xx_ { [IN(LINE)] get => new int4(0, x, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyx { [IN(LINE)] get => new int4(0, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyy { [IN(LINE)] get => new int4(0, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyz { [IN(LINE)] get => new int4(0, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xy_ { [IN(LINE)] get => new int4(0, x, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzx { [IN(LINE)] get => new int4(0, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzy { [IN(LINE)] get => new int4(0, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzz { [IN(LINE)] get => new int4(0, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xz_ { [IN(LINE)] get => new int4(0, x, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_x { [IN(LINE)] get => new int4(0, x, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_y { [IN(LINE)] get => new int4(0, x, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_z { [IN(LINE)] get => new int4(0, x, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x__ { [IN(LINE)] get => new int4(0, x, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxx { [IN(LINE)] get => new int4(0, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxy { [IN(LINE)] get => new int4(0, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxz { [IN(LINE)] get => new int4(0, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yx_ { [IN(LINE)] get => new int4(0, y, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyx { [IN(LINE)] get => new int4(0, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyy { [IN(LINE)] get => new int4(0, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyz { [IN(LINE)] get => new int4(0, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yy_ { [IN(LINE)] get => new int4(0, y, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzx { [IN(LINE)] get => new int4(0, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzy { [IN(LINE)] get => new int4(0, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzz { [IN(LINE)] get => new int4(0, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yz_ { [IN(LINE)] get => new int4(0, y, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_x { [IN(LINE)] get => new int4(0, y, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_y { [IN(LINE)] get => new int4(0, y, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_z { [IN(LINE)] get => new int4(0, y, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y__ { [IN(LINE)] get => new int4(0, y, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxx { [IN(LINE)] get => new int4(0, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxy { [IN(LINE)] get => new int4(0, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxz { [IN(LINE)] get => new int4(0, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zx_ { [IN(LINE)] get => new int4(0, z, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyx { [IN(LINE)] get => new int4(0, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyy { [IN(LINE)] get => new int4(0, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyz { [IN(LINE)] get => new int4(0, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zy_ { [IN(LINE)] get => new int4(0, z, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzx { [IN(LINE)] get => new int4(0, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzy { [IN(LINE)] get => new int4(0, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzz { [IN(LINE)] get => new int4(0, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zz_ { [IN(LINE)] get => new int4(0, z, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_x { [IN(LINE)] get => new int4(0, z, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_y { [IN(LINE)] get => new int4(0, z, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_z { [IN(LINE)] get => new int4(0, z, 0, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z__ { [IN(LINE)] get => new int4(0, z, 0, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xx { [IN(LINE)] get => new int4(0, 0, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xy { [IN(LINE)] get => new int4(0, 0, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xz { [IN(LINE)] get => new int4(0, 0, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __x_ { [IN(LINE)] get => new int4(0, 0, x, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yx { [IN(LINE)] get => new int4(0, 0, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yy { [IN(LINE)] get => new int4(0, 0, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yz { [IN(LINE)] get => new int4(0, 0, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __y_ { [IN(LINE)] get => new int4(0, 0, y, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zx { [IN(LINE)] get => new int4(0, 0, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zy { [IN(LINE)] get => new int4(0, 0, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zz { [IN(LINE)] get => new int4(0, 0, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __z_ { [IN(LINE)] get => new int4(0, 0, z, 0); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___x { [IN(LINE)] get => new int4(0, 0, 0, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___y { [IN(LINE)] get => new int4(0, 0, 0, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___z { [IN(LINE)] get => new int4(0, 0, 0, z); }
        #endregion

        #endregion


        #region Other
        [IN(LINE)]
        public /*readonly*/ void CopyTo(Span<int> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            destination[0] = x; destination[1] = y; destination[2] = z;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is int3 target && Equals(target); }
        [IN(LINE)] public bool Equals(int3 a) { return x == a.x && y == a.y && z == a.z; }
        public override string ToString() { return $"int3({x}, {y}, {z})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public int x, y, z;
            public DebuggerProxy(int3 v) { x = v.x; y = v.y; z = v.z; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<int, int3> GetEnumerator() { return new VectorEnumerator<int, int3>(this); }
        VectorEnumerator<int, int3> IEnumerableVector<int, int3>.GetEnumerator() { return new VectorEnumerator<int, int3>(this); }
        IEnumerator<int> IEnumerable<int>.GetEnumerator() { return new VectorEnumerator<int, int3>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<int, int3>(this); }
        #endregion
    }
}