#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        [IN(LINE)] public float4(Vector2 v) { x = v.x; y = v.y; z = 0; w = 0; }
        [IN(LINE)] public float4(Vector2Int v) { x = v.x; y = v.y; z = 0; w = 0; }
        [IN(LINE)] public float4(Vector3 v) { x = v.x; y = v.y; z = v.z; w = 0; }
        [IN(LINE)] public float4(Vector3Int v) { x = v.x; y = v.y; z = v.z; w = 0; }
        [IN(LINE)] public float4(Vector4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }

        [IN(LINE)] public static explicit operator Vector2(float4 a) => new Vector2(a.x, a.y);
        [IN(LINE)] public static explicit operator Vector2Int(float4 a) => new Vector2Int((int)a.x, (int)a.y);
        [IN(LINE)] public static explicit operator Vector3(float4 a) => new Vector3(a.x, a.y, a.z);
        [IN(LINE)] public static explicit operator Vector3Int(float4 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);
        [IN(LINE)] public static implicit operator Vector4(float4 a) => new Vector4(a.x, a.y, a.z, a.w);

        [IN(LINE)] public static implicit operator float4(Vector2 a) { return new float4(a); }
        [IN(LINE)] public static implicit operator float4(Vector2Int a) { return new float4(a); }
        [IN(LINE)] public static implicit operator float4(Vector3 a) { return new float4(a); }
        [IN(LINE)] public static implicit operator float4(Vector3Int a) { return new float4(a); }
        [IN(LINE)] public static implicit operator float4(Vector4 a) { return new float4(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(float4))] internal class Float4Editor : VectorFieldDrawer { }
}
#endif

#endif