#if UNITY_5_3_OR_NEWER
#pragma warning disable CS8981
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct ray2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Ray2D(ray2 a) { return new Ray2D(a.src, a.dir); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ray2(Ray2D a) { return new ray2(a.origin, a.direction); }
    }
}
#endif