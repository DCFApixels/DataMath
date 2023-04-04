using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct double2 : 
        IEquatable<double2>, 
        IFormattable, 
        IValue2<double>, 
        IColor
    {
        #region Consts
        public const int length = 2;

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
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (double)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (double)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        public float a 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        #endregion

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IValue1<double>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IValue2<double>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => length;
        }

        public unsafe ref double this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (double2* array = &this) { return ref ((double*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float x, float y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(float2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double x, double y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(double2 v)
        {
            x = v.x; y = v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int x, int y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(int2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint x, uint y)
        {
            this.x = (double)x; this.y = (double)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint v)
        {
            x = (double)v; y = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2(uint2 v)
        {
            x = (double)v.x; y = (double)v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double2 a, double2 b) => new double2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double2 a, double b) => new double2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator *(double a, double2 b) => new double2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double2 a, double2 b) => new double2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double2 a, double b) => new double2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator +(double a, double2 b) => new double2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a, double2 b) => new double2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a, double b) => new double2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double a, double2 b) => new double2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double2 a, double2 b) => new double2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double2 a, double b) => new double2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator /(double a, double2 b) => new double2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double2 a, double2 b) => new double2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double2 a, double b) => new double2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator %(double a, double2 b) => new double2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator ++(double2 a) => new double2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator --(double2 a) => new double2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator -(double2 a) => new double2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static double2 operator +(double2 a) => new double2(+a.x, +a.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double2 a, double2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double2 a, double b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double a, double2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double2 a, double2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double2 a, double b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double a, double2 b) => a != b.x || a != b.y;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, y);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, y);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, y);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is double2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"double2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly double2 _value;
            private sbyte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(double2 value) { _value = value; _pointer = -1; }
            public double Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < length;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() { }
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public double x;
            public double y;
            public DebuggerProxy(double2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}