#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        public static explicit operator Vector2(int4 a) => new Vector2(a.x, a.y);
        public static explicit operator Vector2Int(int4 a) => new Vector2Int(a.x, a.y);

        public static explicit operator Vector3(int4 a) => new Vector3(a.x, a.y, a.z);
        public static explicit operator Vector3Int(int4 a) => new Vector3Int(a.x, a.y, a.z);

        public static explicit operator Vector4(int4 a) => new Vector4(a.x, a.y, a.z, a.w);
    }

    public static partial class math
    {
        
    }
}
#endif