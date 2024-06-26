#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(double4 a) => new Vector2((float)a.x, (float)a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(double4 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3(double4 a) => new Vector3((float)a.x, (float)a.y, (float)a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(double4 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector4(double4 a) => new Vector4((float)a.x, (float)a.y, (float)a.z, (float)a.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(Vector2 a) => new double4(a.x, a.y, 0d, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(Vector2Int a) => new double4(a.x, a.y, 0d, 0d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(Vector3 a) => new double4(a.x, a.y, a.z, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(Vector3Int a) => new double4(a.x, a.y, a.z, 0d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(Vector4 a) => new double4(a.x, a.y, a.z, a.w);
    }

    public static partial class math
    {

    }
}
#endif