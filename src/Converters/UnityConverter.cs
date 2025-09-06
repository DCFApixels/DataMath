#if UNITY_5_3_OR_NEWER
using DCFApixels.DataMath;
using DCFApixels.DataMath.TODO;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public static partial class UnityConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color ToUnityColor<T>(this ref T self) where T : unmanaged, IColor
        {
            return new Color(self.r, self.g, self.b, self.a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Ray ToUnityRay<T>(this ref T self, Ray _ = default) where T : unmanaged, IRay3Impl<float, float3>
        {
            return new Ray((Vector3)self.src, (Vector3)self.dir);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Ray2D ToUnityRay<T>(this ref T self, Ray2D _ = default) where T : unmanaged, IRay2Impl<float, float3>
        {
            return new Ray2D((Vector2)self.src, (Vector2)self.dir);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToUnityQuaternion<T>(this ref T self) where T : unmanaged, IQuaternion<float>
        {
            return new Quaternion(self.x, self.y, self.z, self.w);
        }
    }
}
#endif