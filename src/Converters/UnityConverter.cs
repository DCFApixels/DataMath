#if UNITY_5_3_OR_NEWER
using DCFApixels.DataMath;
using DCFApixels.DataMath.TODO;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
    public static partial class UnityConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color ToUnityColor<T>(this ref T self) where T : struct, IColor
        {
            return new Color(self.r, self.g, self.b, self.a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Ray ToUnityRay<T>(this ref T self) where T : struct, IRay3Base<float>
        {
            return new Ray(new Vector3(self.OriginX, self.OriginY, self.OriginZ), new Vector3(self.DirectionX, self.DirectionY, self.DirectionZ));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToUnityQuaternion<T>(this ref T self) where T : struct, IQuaternion<float>
        {
            return new Quaternion(self.x, self.y, self.z, self.w);
        }
    }
}
#endif