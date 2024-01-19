#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct ray3
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Ray(ray3 a) => new Ray(a.origin, a.direction);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ray3(Ray a) => new ray3(a.origin, a.direction);
    }
}
#endif