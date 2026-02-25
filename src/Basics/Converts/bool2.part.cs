#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool2(Axis v) => new bool2(v);
        [IN(LINE)] public static implicit operator bool2((bool, bool) v) => new bool2(v);

        [IN(LINE)] public static implicit operator bool2(bool v) => new bool2(v);
        //[IN(LINE)] public static implicit operator bool2(bool2 v) => new bool2(v);
        [IN(LINE)] public static implicit operator bool2(int v) => new bool2(v);
        [IN(LINE)] public static implicit operator bool2(int2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(uint v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(uint2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(float v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(float2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(double v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(double2 v) => new bool2(v);
        #endregion

        public bool2(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = true; y = false; break;
                case Axis.Y: x = false; y = true; break;
                default: x = false; y = false; break;
            }
        }
        public bool2(bool v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? true : false;
        }
        public bool2(bool2 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public bool2(bool3 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public bool2(bool4 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
    }

    public static partial class DM
    {
        [IN(LINE)] public static bool2 Bool2((bool, bool) v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(bool v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(bool2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(int v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(int2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(uint v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(uint2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(float v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(float2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(double v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(double2 v) => new bool2(v);
    }

    public static partial class DMBasic
    {

    }
}
