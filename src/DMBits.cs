namespace DCFApixels.DataMath
{
    public static partial class DMBits
    {
        public const uint FloatExponentMask = 0x7F800000;
        public const uint FloatMantissaMask = 0x007FFFFF;
        public const ulong DoubleExponentMask = 0x7FF0000000000000;
        public const ulong DoubleMantissaMask = 0x000FFFFFFFFFFFFF;
    }
}