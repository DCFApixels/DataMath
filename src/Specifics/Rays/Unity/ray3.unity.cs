#if UNITY_5_3_OR_NEWER
#pragma warning disable CS8981
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct ray3
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Ray(ray3 a) { return new Ray(a.src, a.dir); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ray3(Ray a) { return new ray3(a.origin, a.direction); }
    }
}
#endif