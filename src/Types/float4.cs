using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial struct float4 : IEquatable<float4>, IFormattable, IValue4<float>
    {
        #region Consts
        public const int length = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly float4 zero = new float4(0f, 0f, 0f, 0f);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly float4 one = new float4(1f, 1f, 1f, 1f);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly float4 left = new float4(-1f, 0f, 0f, 0f);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly float4 right = new float4(1f, 0f, 0f, 0f);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly float4 down = new float4(0f, -1f, 0f, 0f);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly float4 up = new float4(0f, 1f, 0f, 0f);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly float4 back = new float4(0f, 0f, -1f, 0f);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly float4 forward = new float4(0f, 0f, 1f, 0f);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly float4 before = new float4(0f, 0f, 0f, -1f);
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly float4 after = new float4(0f, 0f, 0f, 1f);
        #endregion

        public float x;
        public float y;
        public float z;
        public float w;

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float X 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Y 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Z 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = value;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float W 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => w;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => w = value;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => length;
        }

        public unsafe ref float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (float4* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(float4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(double x, double y, double z, double w)
        {
            this.x = (float)x; this.y = (float)y;
            this.z = (float)z; this.w = (float)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(double v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(double4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(int x, int y, int z, int w)
        {
            this.x = (float)x; this.y = (float)y;
            this.z = (float)z; this.w = (float)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(int v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(int4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(uint x, uint y, uint z, uint w)
        {
            this.x = (float)x; this.y = (float)y;
            this.z = (float)z; this.w = (float)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(uint v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4(uint4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }

        #endregion

        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(float v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(bool4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double4 v) => new float4(v);
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 wx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 wy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 wz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 ww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(w, w);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 ywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 ywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 ywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 wwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 www
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(w, w, w);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ywww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 wwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(w, w, w, w);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is float4 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => unchecked((int)math.hash(this));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"float4({x}, {y}, {z}, {w})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float4 a) => x == a.x && y == a.y && z == a.z && w == a.w; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly float4 _value;
            private byte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(float4 value) { _value = value; _pointer = 0; }
            public float Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < _value.Length;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() { }
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public float x;
            public float y;
            public float z;
            public float w;
            public DebuggerProxy(float4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }
        #endregion
    }

    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint hash(float4 v)
        {
            return csum(asuint(v) * uint2(0xFA3A3285u, 0xAD55999Du)) + 0xDCDD5341u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 one_minus(float4 v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 abs(float4 v)
        {
            return new float4(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z), SMathF.Abs(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(float4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 round(float4 v)
        {
            return new float4(SMathF.Round(v.x), SMathF.Round(v.y), SMathF.Round(v.z), SMathF.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 round2int(float4 v)
        {
            return new int4((int)SMathF.Round(v.x), (int)SMathF.Round(v.y), (int)SMathF.Round(v.z), (int)SMathF.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 floor(float4 v)
        {
            return new float4(SMathF.Floor(v.x), SMathF.Floor(v.y), SMathF.Floor(v.z), SMathF.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floor2int(float4 v)
        {
            return new int4((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y), (int)SMathF.Floor(v.z), (int)SMathF.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ceil(float4 v)
        {
            return new float4(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y), SMathF.Ceiling(v.z), SMathF.Ceiling(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceil2int(float4 v)
        {
            return new int4((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y), (int)SMathF.Ceiling(v.z), (int)SMathF.Ceiling(v.w));
        }
        
    }
}
