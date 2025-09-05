#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        [IN(LINE)] public float3(Vector2 v) { x = v.x; y = v.y; z = 0; }
        [IN(LINE)] public float3(Vector2Int v) { x = v.x; y = v.y; z = 0; }
        [IN(LINE)] public float3(Vector3 v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public float3(Vector3Int v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public float3(Vector4 v) { x = v.x; y = v.y; z = v.z; }

        [IN(LINE)] public static explicit operator Vector2(float3 a) => new Vector2(a.x, a.y);
        [IN(LINE)] public static explicit operator Vector2Int(float3 a) => new Vector2Int((int)a.x, (int)a.y);
        [IN(LINE)] public static implicit operator Vector3(float3 a) => new Vector3(a.x, a.y, a.z);
        [IN(LINE)] public static explicit operator Vector3Int(float3 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);
        [IN(LINE)] public static implicit operator Vector4(float3 a) => new Vector4(a.x, a.y, a.z, 0f);

        [IN(LINE)] public static implicit operator float3(Vector2 a) { return new float3(a); }
        [IN(LINE)] public static implicit operator float3(Vector2Int a) { return new float3(a); }
        [IN(LINE)] public static implicit operator float3(Vector3 a) { return new float3(a); }
        [IN(LINE)] public static implicit operator float3(Vector3Int a) { return new float3(a); }
        [IN(LINE)] public static explicit operator float3(Vector4 a) { return new float3(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(float3))] internal class Float3Editor : VectorFieldDrawer { }
}
#endif

#endif