using DCFApixels.DataMath;
using System.Runtime.CompilerServices;

namespace DataMath.src.Basics.Converts
{
    public static partial class DoubleConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ToBasic2<T>(this ref T self) where T : struct, IVector2<double>
        {
            return new double2(self.x, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ToBasic3<T>(this ref T self) where T : struct, IVector3<double>
        {
            return new double3(self.x, self.y, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToBasic4<T>(this ref T self) where T : struct, IVector4<double>
        {
            return new double4(self.x, self.y, self.y, self.w);
        }
    }
    public static partial class FloatConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ToBasic2<T>(this ref T self) where T : struct, IVector2<float>
        {
            return new float2(self.x, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ToBasic3<T>(this ref T self) where T : struct, IVector3<float>
        {
            return new float3(self.x, self.y, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToBasic4<T>(this ref T self) where T : struct, IVector4<float>
        {
            return new float4(self.x, self.y, self.y, self.w);
        }
    }
    public static partial class IntConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ToBasic2<T>(this ref T self) where T : struct, IVector2<int>
        {
            return new int2(self.x, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ToBasic3<T>(this ref T self) where T : struct, IVector3<int>
        {
            return new int3(self.x, self.y, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToBasic4<T>(this ref T self) where T : struct, IVector4<int>
        {
            return new int4(self.x, self.y, self.y, self.w);
        }
    }
    public static partial class UIntConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ToBasic2<T>(this ref T self) where T : struct, IVector2<uint>
        {
            return new uint2(self.x, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ToBasic3<T>(this ref T self) where T : struct, IVector3<uint>
        {
            return new uint3(self.x, self.y, self.y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToBasic4<T>(this ref T self) where T : struct, IVector4<uint>
        {
            return new uint4(self.x, self.y, self.y, self.w);
        }
    }
}
