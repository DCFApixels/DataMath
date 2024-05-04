#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(int3 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(int3 a) => new Vector2Int(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(int3 a) => new Vector3(a.x, a.y, a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3Int(int3 a) => new Vector3Int(a.x, a.y, a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(int3 a) => new Vector4(a.x, a.y, a.z, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Vector2 a) => new int3(a.x, a.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(Vector2Int a) => new int3(a.x, a.y, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Vector3 a) => new int3(a.x, a.y, a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(Vector3Int a) => new int3(a.x, a.y, a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Vector4 a) => new int3(a.x, a.y, a.z);
    }

    public static partial class math
    {

    }
}
#endif