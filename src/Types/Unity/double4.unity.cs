#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {
        public static implicit operator Vector2(double4 a) => new Vector2((float)a.x, (float)a.y);
        public static implicit operator Vector2Int(double4 a) => new Vector2Int((int)a.x, (int)a.y);

        public static implicit operator Vector3(double4 a) => new Vector3((float)a.x, (float)a.y, (float)a.z);
        public static implicit operator Vector3Int(double4 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);

        public static implicit operator Vector4(double4 a) => new Vector4((float)a.x, (float)a.y, (float)a.z, (float)a.w);
    }

    public static partial class math
    {
        
    }
}
#endif