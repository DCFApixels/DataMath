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
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial struct int4 :
        IEquatable<int4>,
        IFormattable,
        IVector4Impl<int>,
        IColor,
        IEnumerableVector<int, int4>
    {
        #region Consts
        public const int Count = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly int4 zero = new int4(0, 0, 0, 0);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly int4 one = new int4(1, 1, 1, 1);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly int4 left = new int4(unchecked((int)-1), 0, 0, 0);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly int4 right = new int4(1, 0, 0, 0);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly int4 down = new int4(0, unchecked((int)-1), 0, 0);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly int4 up = new int4(0, 1, 0, 0);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly int4 back = new int4(0, 0, unchecked((int)-1), 0);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly int4 forward = new int4(0, 0, 1, 0);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly int4 before = new int4(0, 0, 0, unchecked((int)-1));
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly int4 after = new int4(0, 0, 0, 1);
        #endregion

        public int x;
        public int y;
        public int z;
        public int w;

        #region IColor
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (int)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (int)value; } }
        public float b { [IN(LINE)] get { return (float)z; } [IN(LINE)] set { z = (int)value; } }
        public float a { [IN(LINE)] get { return (float)w; } [IN(LINE)] set { w = (int)value; } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector1<int>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector2<int>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector3<int>.z { [IN(LINE)] get { return z; } [IN(LINE)] set { z = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector4<int>.w { [IN(LINE)] get { return w; } [IN(LINE)] set { w = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public unsafe int this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (int4* array = &this) { return ((int*)array)[index]; }
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
        [IN(LINE)]
        public int4((int x, int y, int z, int w) a)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = a.w;
        }
        [IN(LINE)]
        public int4((int x, int y, int z) a, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, (int x, int y, int z) a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public int4((int x, int y) a, int z, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, (int x, int y) a, int w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int y, (int x, int y) a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public int4((int x, int y) a, (int x, int y) b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public int4(int x, int y, int z, int w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int3 a, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int3 a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public int4(int2 a, int z, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int2 a, int w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int y, int2 a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public int4(int2 a, int2 b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public int4(float v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(float4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }
        [IN(LINE)]
        public int4(double v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(double4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }
        [IN(LINE)]
        public int4(int v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public int4(int4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [IN(LINE)]
        public int4(uint v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(uint4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }

        [IN(LINE)]
        public int4(ReadOnlySpan<int> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2]; w = values[3];
#else
            this = Unsafe.ReadUnaligned<int4>(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out int x, out int y, out int z, out int w) { x = this.x; y = this.y; z = this.z; w = this.w; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static int4 operator +(int4 a, int4 b) { return new int4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        [IN(LINE)] public static int4 operator +(int4 a, int b) { return new int4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static int4 operator +(int a, int4 b) { return new int4(a + b.x, a + b.y, a + b.z, a + b.w); }

        [IN(LINE)] public static int4 operator -(int4 a, int4 b) { return new int4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        [IN(LINE)] public static int4 operator -(int4 a, int b) { return new int4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static int4 operator -(int a, int4 b) { return new int4(a - b.x, a - b.y, a - b.z, a - b.w); }

        [IN(LINE)] public static int4 operator *(int4 a, int4 b) { return new int4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        [IN(LINE)] public static int4 operator *(int4 a, int b) { return new int4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static int4 operator *(int a, int4 b) { return new int4(a * b.x, a * b.y, a * b.z, a * b.w); }

        [IN(LINE)] public static int4 operator /(int4 a, int4 b) { return new int4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        [IN(LINE)] public static int4 operator /(int4 a, int b) { return new int4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static int4 operator /(int a, int4 b) { return new int4(a / b.x, a / b.y, a / b.z, a / b.w); }

        [IN(LINE)] public static int4 operator %(int4 a, int4 b) { return new int4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w); }
        [IN(LINE)] public static int4 operator %(int4 a, int b) { return new int4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static int4 operator %(int a, int4 b) { return new int4(a % b.x, a % b.y, a % b.z, a % b.w); }

        [IN(LINE)] public static int4 operator ++(int4 a) { return new int4(++a.x, ++a.y, ++a.z, ++a.w); }
        [IN(LINE)] public static int4 operator --(int4 a) { return new int4(--a.x, --a.y, --a.z, --a.w); }
        [IN(LINE)] public static int4 operator +(int4 a) { return new int4(+a.x, +a.y, +a.z, +a.w); }
        [IN(LINE)] public static int4 operator -(int4 a) { return new int4((int)-a.x, (int)-a.y, (int)-a.z, (int)-a.w); }
        #endregion

        #region Bits
        [IN(LINE)] public static int4 operator ~(int4 a) { return new int4(~a.x, ~a.y, ~a.z, ~a.w); }
        [IN(LINE)] public static int4 operator <<(int4 a, int n) { return new int4(a.x << n, a.y << n, a.z << n, a.w << n); }
        [IN(LINE)] public static int4 operator >>(int4 a, int n) { return new int4(a.x >> n, a.y >> n, a.z >> n, a.w >> n); }

        [IN(LINE)] public static int4 operator |(int4 a, int4 b) { return new int4(a.x | b.x, a.y | b.y, a.z | b.z, a.w | b.w); }
        [IN(LINE)] public static int4 operator |(int4 a, int b) { return new int4(a.x | b, a.y | b, a.z | b, a.w | b); }
        [IN(LINE)] public static int4 operator |(int a, int4 b) { return new int4(a | b.x, a | b.y, a | b.z, a | b.w); }

        [IN(LINE)] public static int4 operator &(int4 a, int4 b) { return new int4(a.x & b.x, a.y & b.y, a.z & b.z, a.w & b.w); }
        [IN(LINE)] public static int4 operator &(int4 a, int b) { return new int4(a.x & b, a.y & b, a.z & b, a.w & b); }
        [IN(LINE)] public static int4 operator &(int a, int4 b) { return new int4(a & b.x, a & b.y, a & b.z, a & b.w); }

        [IN(LINE)] public static int4 operator ^(int4 a, int4 b) { return new int4(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z, a.w ^ b.w); }
        [IN(LINE)] public static int4 operator ^(int4 a, int b) { return new int4(a.x ^ b, a.y ^ b, a.z ^ b, a.w ^ b); }
        [IN(LINE)] public static int4 operator ^(int a, int4 b) { return new int4(a ^ b.x, a ^ b.y, a ^ b.z, a ^ b.w); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool4 operator <(int4 a, int4 b) { return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w); }
        [IN(LINE)] public static bool4 operator <(int4 a, int b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        [IN(LINE)] public static bool4 operator <(int a, int4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }

        [IN(LINE)] public static bool4 operator <=(int4 a, int4 b) { return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
        [IN(LINE)] public static bool4 operator <=(int4 a, int b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        [IN(LINE)] public static bool4 operator <=(int a, int4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }

        [IN(LINE)] public static bool4 operator >(int4 a, int4 b) { return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w); }
        [IN(LINE)] public static bool4 operator >(int4 a, int b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        [IN(LINE)] public static bool4 operator >(int a, int4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }

        [IN(LINE)] public static bool4 operator >=(int4 a, int4 b) { return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        [IN(LINE)] public static bool4 operator >=(int4 a, int b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        [IN(LINE)] public static bool4 operator >=(int a, int4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }

        [IN(LINE)] public static bool4 operator ==(int4 a, int4 b) { return new bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }
        [IN(LINE)] public static bool4 operator ==(int4 a, int b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        [IN(LINE)] public static bool4 operator ==(int a, int4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }

        [IN(LINE)] public static bool4 operator !=(int4 a, int4 b) { return new bool4(a.x != b.x, a.y != b.y, a.z != b.z, a.w != b.w); }
        [IN(LINE)] public static bool4 operator !=(int4 a, int b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        [IN(LINE)] public static bool4 operator !=(int a, int4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        #endregion

        #region Other
        [IN(LINE)] public static int4 operator !(int4 a) { return 1 - a; }
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
        public int2 xw { [IN(LINE)] get => new int2(x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yx { [IN(LINE)] get => new int2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yy { [IN(LINE)] get => new int2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yz { [IN(LINE)] get => new int2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yw { [IN(LINE)] get => new int2(y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zx { [IN(LINE)] get => new int2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zy { [IN(LINE)] get => new int2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zz { [IN(LINE)] get => new int2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zw { [IN(LINE)] get => new int2(z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wx { [IN(LINE)] get => new int2(w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wy { [IN(LINE)] get => new int2(w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wz { [IN(LINE)] get => new int2(w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 ww { [IN(LINE)] get => new int2(w, w); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxx { [IN(LINE)] get => new int3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxy { [IN(LINE)] get => new int3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxz { [IN(LINE)] get => new int3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxw { [IN(LINE)] get => new int3(x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyx { [IN(LINE)] get => new int3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyy { [IN(LINE)] get => new int3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyz { [IN(LINE)] get => new int3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyw { [IN(LINE)] get => new int3(x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzx { [IN(LINE)] get => new int3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzy { [IN(LINE)] get => new int3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzz { [IN(LINE)] get => new int3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzw { [IN(LINE)] get => new int3(x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwx { [IN(LINE)] get => new int3(x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwy { [IN(LINE)] get => new int3(x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwz { [IN(LINE)] get => new int3(x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xww { [IN(LINE)] get => new int3(x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxx { [IN(LINE)] get => new int3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxy { [IN(LINE)] get => new int3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxz { [IN(LINE)] get => new int3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxw { [IN(LINE)] get => new int3(y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyx { [IN(LINE)] get => new int3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyy { [IN(LINE)] get => new int3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyz { [IN(LINE)] get => new int3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyw { [IN(LINE)] get => new int3(y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzx { [IN(LINE)] get => new int3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzy { [IN(LINE)] get => new int3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzz { [IN(LINE)] get => new int3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzw { [IN(LINE)] get => new int3(y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywx { [IN(LINE)] get => new int3(y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywy { [IN(LINE)] get => new int3(y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywz { [IN(LINE)] get => new int3(y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yww { [IN(LINE)] get => new int3(y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxx { [IN(LINE)] get => new int3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxy { [IN(LINE)] get => new int3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxz { [IN(LINE)] get => new int3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxw { [IN(LINE)] get => new int3(z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyx { [IN(LINE)] get => new int3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyy { [IN(LINE)] get => new int3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyz { [IN(LINE)] get => new int3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyw { [IN(LINE)] get => new int3(z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzx { [IN(LINE)] get => new int3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzy { [IN(LINE)] get => new int3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzz { [IN(LINE)] get => new int3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzw { [IN(LINE)] get => new int3(z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwx { [IN(LINE)] get => new int3(z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwy { [IN(LINE)] get => new int3(z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwz { [IN(LINE)] get => new int3(z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zww { [IN(LINE)] get => new int3(z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxx { [IN(LINE)] get => new int3(w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxy { [IN(LINE)] get => new int3(w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxz { [IN(LINE)] get => new int3(w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxw { [IN(LINE)] get => new int3(w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyx { [IN(LINE)] get => new int3(w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyy { [IN(LINE)] get => new int3(w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyz { [IN(LINE)] get => new int3(w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyw { [IN(LINE)] get => new int3(w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzx { [IN(LINE)] get => new int3(w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzy { [IN(LINE)] get => new int3(w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzz { [IN(LINE)] get => new int3(w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzw { [IN(LINE)] get => new int3(w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwx { [IN(LINE)] get => new int3(w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwy { [IN(LINE)] get => new int3(w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwz { [IN(LINE)] get => new int3(w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 www { [IN(LINE)] get => new int3(w, w, w); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxx { [IN(LINE)] get => new int4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxy { [IN(LINE)] get => new int4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxz { [IN(LINE)] get => new int4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxw { [IN(LINE)] get => new int4(x, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyx { [IN(LINE)] get => new int4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyy { [IN(LINE)] get => new int4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyz { [IN(LINE)] get => new int4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyw { [IN(LINE)] get => new int4(x, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzx { [IN(LINE)] get => new int4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzy { [IN(LINE)] get => new int4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzz { [IN(LINE)] get => new int4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzw { [IN(LINE)] get => new int4(x, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwx { [IN(LINE)] get => new int4(x, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwy { [IN(LINE)] get => new int4(x, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwz { [IN(LINE)] get => new int4(x, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxww { [IN(LINE)] get => new int4(x, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxx { [IN(LINE)] get => new int4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxy { [IN(LINE)] get => new int4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxz { [IN(LINE)] get => new int4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxw { [IN(LINE)] get => new int4(x, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyx { [IN(LINE)] get => new int4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyy { [IN(LINE)] get => new int4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyz { [IN(LINE)] get => new int4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyw { [IN(LINE)] get => new int4(x, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzx { [IN(LINE)] get => new int4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzy { [IN(LINE)] get => new int4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzz { [IN(LINE)] get => new int4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzw { [IN(LINE)] get => new int4(x, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywx { [IN(LINE)] get => new int4(x, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywy { [IN(LINE)] get => new int4(x, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywz { [IN(LINE)] get => new int4(x, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyww { [IN(LINE)] get => new int4(x, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxx { [IN(LINE)] get => new int4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxy { [IN(LINE)] get => new int4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxz { [IN(LINE)] get => new int4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxw { [IN(LINE)] get => new int4(x, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyx { [IN(LINE)] get => new int4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyy { [IN(LINE)] get => new int4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyz { [IN(LINE)] get => new int4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyw { [IN(LINE)] get => new int4(x, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzx { [IN(LINE)] get => new int4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzy { [IN(LINE)] get => new int4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzz { [IN(LINE)] get => new int4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzw { [IN(LINE)] get => new int4(x, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwx { [IN(LINE)] get => new int4(x, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwy { [IN(LINE)] get => new int4(x, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwz { [IN(LINE)] get => new int4(x, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzww { [IN(LINE)] get => new int4(x, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxx { [IN(LINE)] get => new int4(x, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxy { [IN(LINE)] get => new int4(x, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxz { [IN(LINE)] get => new int4(x, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxw { [IN(LINE)] get => new int4(x, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyx { [IN(LINE)] get => new int4(x, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyy { [IN(LINE)] get => new int4(x, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyz { [IN(LINE)] get => new int4(x, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyw { [IN(LINE)] get => new int4(x, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzx { [IN(LINE)] get => new int4(x, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzy { [IN(LINE)] get => new int4(x, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzz { [IN(LINE)] get => new int4(x, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzw { [IN(LINE)] get => new int4(x, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwx { [IN(LINE)] get => new int4(x, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwy { [IN(LINE)] get => new int4(x, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwz { [IN(LINE)] get => new int4(x, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwww { [IN(LINE)] get => new int4(x, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxx { [IN(LINE)] get => new int4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxy { [IN(LINE)] get => new int4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxz { [IN(LINE)] get => new int4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxw { [IN(LINE)] get => new int4(y, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyx { [IN(LINE)] get => new int4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyy { [IN(LINE)] get => new int4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyz { [IN(LINE)] get => new int4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyw { [IN(LINE)] get => new int4(y, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzx { [IN(LINE)] get => new int4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzy { [IN(LINE)] get => new int4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzz { [IN(LINE)] get => new int4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzw { [IN(LINE)] get => new int4(y, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwx { [IN(LINE)] get => new int4(y, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwy { [IN(LINE)] get => new int4(y, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwz { [IN(LINE)] get => new int4(y, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxww { [IN(LINE)] get => new int4(y, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxx { [IN(LINE)] get => new int4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxy { [IN(LINE)] get => new int4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxz { [IN(LINE)] get => new int4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxw { [IN(LINE)] get => new int4(y, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyx { [IN(LINE)] get => new int4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyy { [IN(LINE)] get => new int4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyz { [IN(LINE)] get => new int4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyw { [IN(LINE)] get => new int4(y, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzx { [IN(LINE)] get => new int4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzy { [IN(LINE)] get => new int4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzz { [IN(LINE)] get => new int4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzw { [IN(LINE)] get => new int4(y, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywx { [IN(LINE)] get => new int4(y, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywy { [IN(LINE)] get => new int4(y, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywz { [IN(LINE)] get => new int4(y, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyww { [IN(LINE)] get => new int4(y, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxx { [IN(LINE)] get => new int4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxy { [IN(LINE)] get => new int4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxz { [IN(LINE)] get => new int4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxw { [IN(LINE)] get => new int4(y, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyx { [IN(LINE)] get => new int4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyy { [IN(LINE)] get => new int4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyz { [IN(LINE)] get => new int4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyw { [IN(LINE)] get => new int4(y, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzx { [IN(LINE)] get => new int4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzy { [IN(LINE)] get => new int4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzz { [IN(LINE)] get => new int4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzw { [IN(LINE)] get => new int4(y, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwx { [IN(LINE)] get => new int4(y, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwy { [IN(LINE)] get => new int4(y, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwz { [IN(LINE)] get => new int4(y, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzww { [IN(LINE)] get => new int4(y, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxx { [IN(LINE)] get => new int4(y, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxy { [IN(LINE)] get => new int4(y, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxz { [IN(LINE)] get => new int4(y, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxw { [IN(LINE)] get => new int4(y, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyx { [IN(LINE)] get => new int4(y, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyy { [IN(LINE)] get => new int4(y, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyz { [IN(LINE)] get => new int4(y, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyw { [IN(LINE)] get => new int4(y, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzx { [IN(LINE)] get => new int4(y, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzy { [IN(LINE)] get => new int4(y, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzz { [IN(LINE)] get => new int4(y, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzw { [IN(LINE)] get => new int4(y, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwx { [IN(LINE)] get => new int4(y, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwy { [IN(LINE)] get => new int4(y, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwz { [IN(LINE)] get => new int4(y, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywww { [IN(LINE)] get => new int4(y, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxx { [IN(LINE)] get => new int4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxy { [IN(LINE)] get => new int4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxz { [IN(LINE)] get => new int4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxw { [IN(LINE)] get => new int4(z, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyx { [IN(LINE)] get => new int4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyy { [IN(LINE)] get => new int4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyz { [IN(LINE)] get => new int4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyw { [IN(LINE)] get => new int4(z, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzx { [IN(LINE)] get => new int4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzy { [IN(LINE)] get => new int4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzz { [IN(LINE)] get => new int4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzw { [IN(LINE)] get => new int4(z, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwx { [IN(LINE)] get => new int4(z, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwy { [IN(LINE)] get => new int4(z, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwz { [IN(LINE)] get => new int4(z, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxww { [IN(LINE)] get => new int4(z, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxx { [IN(LINE)] get => new int4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxy { [IN(LINE)] get => new int4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxz { [IN(LINE)] get => new int4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxw { [IN(LINE)] get => new int4(z, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyx { [IN(LINE)] get => new int4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyy { [IN(LINE)] get => new int4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyz { [IN(LINE)] get => new int4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyw { [IN(LINE)] get => new int4(z, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzx { [IN(LINE)] get => new int4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzy { [IN(LINE)] get => new int4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzz { [IN(LINE)] get => new int4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzw { [IN(LINE)] get => new int4(z, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywx { [IN(LINE)] get => new int4(z, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywy { [IN(LINE)] get => new int4(z, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywz { [IN(LINE)] get => new int4(z, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyww { [IN(LINE)] get => new int4(z, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxx { [IN(LINE)] get => new int4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxy { [IN(LINE)] get => new int4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxz { [IN(LINE)] get => new int4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxw { [IN(LINE)] get => new int4(z, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyx { [IN(LINE)] get => new int4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyy { [IN(LINE)] get => new int4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyz { [IN(LINE)] get => new int4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyw { [IN(LINE)] get => new int4(z, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzx { [IN(LINE)] get => new int4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzy { [IN(LINE)] get => new int4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzz { [IN(LINE)] get => new int4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzw { [IN(LINE)] get => new int4(z, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwx { [IN(LINE)] get => new int4(z, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwy { [IN(LINE)] get => new int4(z, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwz { [IN(LINE)] get => new int4(z, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzww { [IN(LINE)] get => new int4(z, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxx { [IN(LINE)] get => new int4(z, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxy { [IN(LINE)] get => new int4(z, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxz { [IN(LINE)] get => new int4(z, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxw { [IN(LINE)] get => new int4(z, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyx { [IN(LINE)] get => new int4(z, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyy { [IN(LINE)] get => new int4(z, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyz { [IN(LINE)] get => new int4(z, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyw { [IN(LINE)] get => new int4(z, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzx { [IN(LINE)] get => new int4(z, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzy { [IN(LINE)] get => new int4(z, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzz { [IN(LINE)] get => new int4(z, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzw { [IN(LINE)] get => new int4(z, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwx { [IN(LINE)] get => new int4(z, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwy { [IN(LINE)] get => new int4(z, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwz { [IN(LINE)] get => new int4(z, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwww { [IN(LINE)] get => new int4(z, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxx { [IN(LINE)] get => new int4(w, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxy { [IN(LINE)] get => new int4(w, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxz { [IN(LINE)] get => new int4(w, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxw { [IN(LINE)] get => new int4(w, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyx { [IN(LINE)] get => new int4(w, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyy { [IN(LINE)] get => new int4(w, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyz { [IN(LINE)] get => new int4(w, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyw { [IN(LINE)] get => new int4(w, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzx { [IN(LINE)] get => new int4(w, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzy { [IN(LINE)] get => new int4(w, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzz { [IN(LINE)] get => new int4(w, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzw { [IN(LINE)] get => new int4(w, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwx { [IN(LINE)] get => new int4(w, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwy { [IN(LINE)] get => new int4(w, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwz { [IN(LINE)] get => new int4(w, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxww { [IN(LINE)] get => new int4(w, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxx { [IN(LINE)] get => new int4(w, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxy { [IN(LINE)] get => new int4(w, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxz { [IN(LINE)] get => new int4(w, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxw { [IN(LINE)] get => new int4(w, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyx { [IN(LINE)] get => new int4(w, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyy { [IN(LINE)] get => new int4(w, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyz { [IN(LINE)] get => new int4(w, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyw { [IN(LINE)] get => new int4(w, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzx { [IN(LINE)] get => new int4(w, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzy { [IN(LINE)] get => new int4(w, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzz { [IN(LINE)] get => new int4(w, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzw { [IN(LINE)] get => new int4(w, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywx { [IN(LINE)] get => new int4(w, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywy { [IN(LINE)] get => new int4(w, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywz { [IN(LINE)] get => new int4(w, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyww { [IN(LINE)] get => new int4(w, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxx { [IN(LINE)] get => new int4(w, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxy { [IN(LINE)] get => new int4(w, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxz { [IN(LINE)] get => new int4(w, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxw { [IN(LINE)] get => new int4(w, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyx { [IN(LINE)] get => new int4(w, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyy { [IN(LINE)] get => new int4(w, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyz { [IN(LINE)] get => new int4(w, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyw { [IN(LINE)] get => new int4(w, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzx { [IN(LINE)] get => new int4(w, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzy { [IN(LINE)] get => new int4(w, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzz { [IN(LINE)] get => new int4(w, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzw { [IN(LINE)] get => new int4(w, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwx { [IN(LINE)] get => new int4(w, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwy { [IN(LINE)] get => new int4(w, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwz { [IN(LINE)] get => new int4(w, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzww { [IN(LINE)] get => new int4(w, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxx { [IN(LINE)] get => new int4(w, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxy { [IN(LINE)] get => new int4(w, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxz { [IN(LINE)] get => new int4(w, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxw { [IN(LINE)] get => new int4(w, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyx { [IN(LINE)] get => new int4(w, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyy { [IN(LINE)] get => new int4(w, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyz { [IN(LINE)] get => new int4(w, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyw { [IN(LINE)] get => new int4(w, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzx { [IN(LINE)] get => new int4(w, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzy { [IN(LINE)] get => new int4(w, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzz { [IN(LINE)] get => new int4(w, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzw { [IN(LINE)] get => new int4(w, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwx { [IN(LINE)] get => new int4(w, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwy { [IN(LINE)] get => new int4(w, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwz { [IN(LINE)] get => new int4(w, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwww { [IN(LINE)] get => new int4(w, w, w, w); }
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
            destination[0] = x; destination[1] = y; destination[2] = z; destination[3] = w;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is int4 target && Equals(target); }
        [IN(LINE)] public bool Equals(int4 a) { return x == a.x && y == a.y && z == a.z && w == a.w; }
        public override string ToString() { return $"int4({x}, {y}, {z}, {w})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public int x, y, z, w;
            public DebuggerProxy(int4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<int, int4> GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        VectorEnumerator<int, int4> IEnumerableVector<int, int4>.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        IEnumerator<int> IEnumerable<int>.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        #endregion
    }
}