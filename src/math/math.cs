namespace DCFApixels.DataMath
{
    public static partial class math //consts
    {
        #region Constants
        /// <summary> The circle constant. Defined as the circumference of a circle divided by its radius. Equivalent to 2*pi. </summary>
        public const float TAU = 6.28318530717959f;
        /// <summary> The circle constant. Defined as the circumference of a circle divided by its radius. Equivalent to 2*pi. </summary>
        public const double TAU_D = 6.28318530717959d;

        /// <summary> An obscure circle constant. Defined as the circumference of a circle divided by its diameter. Equivalent to 0.5*tau. </summary>
        //public const float PI = 3.14159274F;
        public const double PI_ = 3.1415926535897931;
        public const float PI = 3.14159265359f;
        /// <summary> Euler's number. The base of the natural logarithm. f(x)=e^x is equal to its own derivative. </summary>
        public const double E_D = 2.7182818284590451;
        public const float E = 2.71828182846f;
        /// <summary> The golden ratio. It is the value of a/b where a/b = (a+b)/a. It's the positive root of x^2-x-1. </summary>
        public const float GOLDEN_RATIO = 1.61803398875f;
        /// <summary> The square root of two. The length of the vector (1,1). </summary>
        public const float SQRT2 = 1.41421356237f;
        /// <summary> The reciprocal of the square root of two. The components of the vector (1,1). </summary>
        public const float RSQRT2 = 1f / SQRT2;


        /// <summary> Multiply an angle in degrees by this, to convert it to radians. </summary>
        public const float Deg2Rad = TAU / 360f;
        /// <summary> Multiply an angle in radians by this, to convert it to degrees. </summary>
        public const float Rad2Deg = 360f / TAU;
        /// <summary> Multiply an angle in degrees by this, to convert it to radians. </summary>
        public const double Deg2Rad_D = TAU_D / 360d;
        /// <summary> Multiply an angle in radians by this, to convert it to degrees. </summary>
        public const double Rad2Deg_D = 360d / TAU_D;

        private const float FloatMinNormal = 1.17549435E-38f;
        private const float FloatMinDenormal = float.Epsilon;
        private const bool IsFlushToZeroEnabled = FloatMinDenormal == 0f;

        public const float Epsilon = (IsFlushToZeroEnabled ? FloatMinNormal : FloatMinDenormal);
        #endregion

    }
}
