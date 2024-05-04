using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.TODO
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4 * 2, Size = 8 * 2)]
    public partial struct float2x2 :
        IMatrix2x2<float, float2>,
        IEnumerableVector<float, float2x2>,
        IEquatable<float2x2>,
        IFormattable
    {
        #region Consts
        public const int ROWS = 2;
        public const int COLUMNS = 2;
        public const int LENGTH = ROWS * COLUMNS;

        public static readonly float2x2 identity = new float2x2(1.0f, 0.0f, 0.0f, 1.0f);
        public static readonly float2x2 zero;
        #endregion

        public float2 c0;
        public float2 c1;

        #region Constructors
        [IN(LINE)]
        public float2x2(float2 c0, float2 c1)
        {
            this.c0 = c0; this.c1 = c1;
        }
        [IN(LINE)]
        public float2x2(float m00, float m01,
                        float m10, float m11)
        {
            c0 = new float2(m00, m10);
            c1 = new float2(m01, m11);
        }
        [IN(LINE)]
        public float2x2(float v)
        {
            c0 = v; c1 = v;
        }
        [IN(LINE)]
        public float2x2(int v)
        {
            c0 = v; c1 = v;
        }
        //    [IN(LINE)]
        //    public float2x2(int2x2 v)
        //    {
        //        c0 = v.c0; c1 = v.c1;
        //    }
        [IN(LINE)]
        public float2x2(uint v)
        {
            c0 = v; c1 = v;
        }
        //    [IN(LINE)]
        //    public float2x2(uint2x2 v)
        //    {
        //        c0 = v.c0; c1 = v.c1;
        //    }
        [IN(LINE)]
        public float2x2(double v)
        {
            c0 = (float2)v; c1 = (float2)v;
        }
        //    [IN(LINE)]
        //    public float2x2(double2x2 v)
        //    {
        //        c0 = (float2)v.c0; c1 = (float2)v.c1;
        //    }
        #endregion

        #region IMatrixRxC
        public int rows { [IN(LINE)] get => ROWS; }
        public int columns { [IN(LINE)] get => COLUMNS; }
        public int length { [IN(LINE)] get => LENGTH; }

        public float this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public float this[int r, int c]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        float2 IMatrix2x1<float, float2>.c0 { [IN(LINE)] get => c0; [IN(LINE)] set => c0 = value; }
        float2 IMatrix2x2<float, float2>.c1 { [IN(LINE)] get => c1; [IN(LINE)] set => c1 = value; }

        public float m00 { [IN(LINE)] get => c0.x; [IN(LINE)] set => c0.x = value; }
        public float m01 { [IN(LINE)] get => c1.x; [IN(LINE)] set => c1.x = value; }
        public float m10 { [IN(LINE)] get => c0.y; [IN(LINE)] set => c0.y = value; }
        public float m11 { [IN(LINE)] get => c1.y; [IN(LINE)] set => c1.y = value; }

        public float x { [IN(LINE)] get => c0.x; [IN(LINE)] set => c1.x = value; }
        public float y { [IN(LINE)] get => c0.y; [IN(LINE)] set => c1.y = value; }
        #endregion

        #region Arithmetic operators
        [IN(LINE)]
        public static float2x2 operator *(float2x2 a, float2x2 b) => new float2x2(a.c0 * b.c0, a.c1 * b.c1);
        [IN(LINE)]
        public static float2x2 operator *(float2x2 a, float b) => new float2x2(a.c0 * b, a.c1 * b);
        [IN(LINE)]
        public static float2x2 operator *(float a, float2x2 b) => new float2x2(a * b.c0, a * b.c1);

        [IN(LINE)]
        public static float2x2 operator +(float2x2 a, float2x2 b) => new float2x2(a.c0 + b.c0, a.c1 + b.c1);
        [IN(LINE)]
        public static float2x2 operator +(float2x2 a, float b) => new float2x2(a.c0 + b, a.c1 + b);
        [IN(LINE)]
        public static float2x2 operator +(float a, float2x2 b) => new float2x2(a + b.c0, a + b.c1);

        [IN(LINE)]
        public static float2x2 operator -(float2x2 a, float2x2 b) => new float2x2(a.c0 - b.c0, a.c1 - b.c1);
        [IN(LINE)]
        public static float2x2 operator -(float2x2 a, float b) => new float2x2(a.c0 - b, a.c1 - b);
        [IN(LINE)]
        public static float2x2 operator -(float a, float2x2 b) => new float2x2(a - b.c0, a - b.c1);

        [IN(LINE)]
        public static float2x2 operator /(float2x2 a, float2x2 b) => new float2x2(a.c0 / b.c0, a.c1 / b.c1);
        [IN(LINE)]
        public static float2x2 operator /(float2x2 a, float b) => new float2x2(a.c0 / b, a.c1 / b);
        [IN(LINE)]
        public static float2x2 operator /(float a, float2x2 b) => new float2x2(a / b.c0, a / b.c1);

        [IN(LINE)]
        public static float2x2 operator %(float2x2 a, float2x2 b) => new float2x2(a.c0 % b.c0, a.c1 % b.c1);
        [IN(LINE)]
        public static float2x2 operator %(float2x2 a, float b) => new float2x2(a.c0 % b, a.c1 % b);
        [IN(LINE)]
        public static float2x2 operator %(float a, float2x2 b) => new float2x2(a % b.c0, a % b.c1);

        [IN(LINE)]
        public static float2x2 operator ++(float2x2 a) => new float2x2(++a.c0, ++a.c1);
        [IN(LINE)]
        public static float2x2 operator --(float2x2 a) => new float2x2(--a.c0, --a.c1);
        [IN(LINE)]
        public static float2x2 operator -(float2x2 a) => new float2x2(-a.c0, -a.c1);
        [IN(LINE)]
        public static float2x2 operator +(float2x2 a) => new float2x2(+a.c0, +a.c1);
        #endregion

        #region Boolean operators
        [IN(LINE)]
        public static bool operator ==(float2x2 a, float2x2 b) => a.c0 == b.c0 && a.c1 == b.c1;
        [IN(LINE)]
        public static bool operator ==(float2x2 a, float b) => a.c0 == b && a.c1 == b;
        [IN(LINE)]
        public static bool operator ==(float a, float2x2 b) => a == b.c0 && a == b.c1;

        [IN(LINE)]
        public static bool operator !=(float2x2 a, float2x2 b) => a.c0 != b.c0 || a.c1 != b.c1;
        [IN(LINE)]
        public static bool operator !=(float2x2 a, float b) => a.c0 != b || a.c1 != b;
        [IN(LINE)]
        public static bool operator !=(float a, float2x2 b) => a != b.c0 || a != b.c1;
        #endregion

        #region Enumerator
        VectorEnumerator<float, float2x2> IEnumerableVector<float, float2x2>.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly float* _pointer;
            private sbyte _index;
            [IN(LINE)]
            public Enumerator(in float2x2 value)
            {
                fixed (float2x2* array = &value)
                {
                    _pointer = (float*)array;
                    _index = -1;
                }
            }
            public float Current => _pointer[_index];
            [IN(LINE)]
            public void Dispose() { }
            [IN(LINE)]
            public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)]
            public void Reset() { }
        }
        #endregion

        #region Other
        [IN(LINE)]
        public override int GetHashCode() => math_TODO.hash(this);
        [IN(LINE)]
        public override bool Equals(object o) => o is float2 target && Equals(target);
        [IN(LINE)]
        public bool Equals(float2x2 other)
        {
            return
                c0.Equals(other.c0) &&
                c1.Equals(other.c1);
        }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(float2x2)}(" +
                $"({m00.ToString(formatProvider)}, {m10.ToString(formatProvider)}), " +
                $"({m01.ToString(formatProvider)}, {m11.ToString(formatProvider)}))";
        }
        [IN(LINE)]
        public override string ToString()
        {
            return $"{nameof(float2x2)}(" +
                $"({m00}, {m10}), " +
                $"({m01}, {m11}))";
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public float2 c0;
            public float2 c1;
            public DebuggerProxy(float2x2 v)
            {
                c0 = v.c0;
                c1 = v.c1;
            }
        }
        #endregion
    }
}
