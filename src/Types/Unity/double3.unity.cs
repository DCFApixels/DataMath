#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(double3 a) => new Vector2((float)a.x, (float)a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(double3 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3(double3 a) => new Vector3((float)a.x, (float)a.y, (float)a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(double3 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector4(double3 a) => new Vector4((float)a.x, (float)a.y, (float)a.z, 0f);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Vector2 a) => new double3(a.x, a.y, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Vector2Int a) => new double3(a.x, a.y, 0d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Vector3 a) => new double3(a.x, a.y, a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(Vector3Int a) => new double3(a.x, a.y, a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3(Vector4 a) => new double3(a.x, a.y, a.z);
    }

    public static partial class math
    {
        
    }
}
#endif