#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        public static explicit operator Vector2(uint3 a) => new Vector2(a.x, a.y);
        public static implicit operator Vector2Int(uint3 a) => new Vector2Int((int)a.x, (int)a.y);

        public static explicit operator Vector3(uint3 a) => new Vector3(a.x, a.y, a.z);
        public static implicit operator Vector3Int(uint3 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);

        public static explicit operator Vector4(uint3 a) => new Vector4(a.x, a.y, a.z, 0f);
    }

    public static partial class math
    {
        
    }
}
#endif