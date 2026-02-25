#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool4(Axis v) => new bool4(v);
        [IN(LINE)] public static implicit operator bool4((bool, bool, bool, bool) v) => new bool4(v);

        [IN(LINE)] public static implicit operator bool4(bool v) => new bool4(v);
        //[IN(LINE)] public static implicit operator bool4(bool4 v) => new bool4(v);
        [IN(LINE)] public static implicit operator bool4(int v) => new bool4(v);
        [IN(LINE)] public static implicit operator bool4(int4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(uint v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(uint4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(float v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(float4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(double v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(double4 v) => new bool4(v);
        #endregion

        public bool4(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = true; y = false; z = false; w = false; break;
                case Axis.Y: x = false; y = true; z = false; w = false; break;
                case Axis.Z: x = false; y = false; z = true; w = false; break;
                case Axis.W: x = false; y = false; z = false; w = true; break;
                default: x = false; y = false; z = false; w = false; break;
            }
        }
        public bool4(bool v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            z = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            w = ((swizzleRaw & 7) - 1) == 1 ? true : false;
        }
        public bool4(bool2 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public bool4(bool3 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public bool4(bool4 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
    }

    public static partial class DM
    {
        [IN(LINE)] public static bool4 Bool4((bool, bool, bool, bool) v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(bool v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(bool4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(int v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(int4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(uint v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(uint4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(float v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(float4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(double v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(double4 v) => new bool4(v);
    }

    public static partial class DMBasic
    {

    }
}
