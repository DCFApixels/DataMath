#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct quat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Quaternion(quat a) => new Quaternion(a.x, a.y, a.z, a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quat(Quaternion a) => new quat(a.x, a.y, a.z, a.w);
    }
}
#endif