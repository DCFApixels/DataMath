#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(int4 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(int4 a) => new Vector2Int(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3(int4 a) => new Vector3(a.x, a.y, a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(int4 a) => new Vector3Int(a.x, a.y, a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(int4 a) => new Vector4(a.x, a.y, a.z, a.w);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(Vector2 a) => new int4(a.x, a.y, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(Vector2Int a) => new int4(a.x, a.y, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(Vector3 a) => new int4(a.x, a.y, a.z, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(Vector3Int a) => new int4(a.x, a.y, a.z, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(Vector4 a) => new int4(a.x, a.y, a.z, a.w);
    }
}
#endif