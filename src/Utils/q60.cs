using System;
using System.Runtime.CompilerServices;

namespace DataMath.src.Utils
{
    public readonly struct q60
    {
        public const int N = 4;
        public const int M = 64 - N;
        public const int HALF_N = N / 2;
        public const int HALF_M = M / 2;
        public const ulong ONE = 1L << M;
        public const ulong ZERO = 0;

        public static readonly q60 One = new q60(ONE);
        public static readonly q60 Zero = new q60(ZERO);
        public static readonly q60 MinValuie = Zero;
        public static readonly q60 MaxValue = new q60(ulong.MaxValue);

        private readonly ulong _v;

        public ulong Left => (_v & 0xF000_0000_0000_0000) >> M;
        public ulong Right => _v & 0x0FFF_FFFF_FFFF_FFFF;

        private q60(ulong value)
        {
            _v = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 Add(q60 a, q60 b) => new q60(a._v + b._v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 Subtract(q60 a, q60 b) => new q60(a._v - b._v);


        //a.m + b.m
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 Multiple(q60 a, q60 b)
        {
            return new q60(
                    (a._v >> HALF_M) * (b._v >> HALF_M)
                );
        }
        //a.m - b.m
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 Divide(q60 a, q60 b)
        {
            Console.WriteLine(ONE / b._v);
            Console.WriteLine(b._v / ONE);
            Console.WriteLine("---------------------------");
            return new q60(
                    (a._v >> HALF_M) * ((b._v / ONE) >> HALF_M)
                );
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 FromDouble(double value)
        {
            return new q60((ulong)(value * ONE));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 FromDecimal(decimal value)
        {
            return new q60((ulong)(value * ONE));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(q60 value)
        {
            return (double)value._v / ONE;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(q60 value)
        {
            return (decimal)value._v / ONE;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 FromBits(ulong value)
        {
            return new q60(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return ToDecimal(this).ToString();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator +(q60 a, q60 b) => Add(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator -(q60 a, q60 b) => Subtract(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator *(q60 a, q60 b) => Multiple(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator /(q60 a, q60 b) => Divide(a, b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator &(ulong a, q60 b) => new q60(a & b._v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator &(q60 a, ulong b) => new q60(a._v & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator &(q60 a, q60 b) => new q60(a._v & b._v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator |(ulong a, q60 b) => new q60(a | b._v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator |(q60 a, ulong b) => new q60(a._v | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator |(q60 a, q60 b) => new q60(a._v | b._v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator ^(ulong a, q60 b) => new q60(a ^ b._v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator ^(q60 a, ulong b) => new q60(a._v ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator ^(q60 a, q60 b) => new q60(a._v ^ b._v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static q60 operator ~(q60 a) => new q60(~a._v);
    }
}
