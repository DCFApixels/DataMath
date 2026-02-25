#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool3(Axis v) => new bool3(v);
        [IN(LINE)] public static implicit operator bool3((bool, bool, bool) v) => new bool3(v);

        [IN(LINE)] public static implicit operator bool3(bool v) => new bool3(v);
        //[IN(LINE)] public static implicit operator bool3(bool3 v) => new bool3(v);
        [IN(LINE)] public static implicit operator bool3(int v) => new bool3(v);
        [IN(LINE)] public static implicit operator bool3(int3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(uint v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(uint3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(float v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(float3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(double v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(double3 v) => new bool3(v);
        #endregion

        public bool3(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = true; y = false; z = false; break;
                case Axis.Y: x = false; y = true; z = false; break;
                case Axis.Z: x = false; y = false; z = true; break;
                default: x = false; y = false; z = false; break;
            }
        }
        public bool3(bool v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? true : false; swizzleRaw >>= 3;
            z = ((swizzleRaw & 7) - 1) == 1 ? true : false;
        }
        public bool3(bool2 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1];
        }
        public bool3(bool3 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1];
        }
        public bool3(bool4 v, Swizzle swizzle) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1];
        }
    }

    public static partial class DM
    {
        [IN(LINE)] public static bool3 Bool3((bool, bool, bool) v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(bool v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(bool3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(int v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(int3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(uint v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(uint3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(float v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(float3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(double v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(double3 v) => new bool3(v);
    }

    public static partial class DMBasic
    {

    }
}
