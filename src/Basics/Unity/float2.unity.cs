#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        [IN(LINE)] public float2(Vector2 v) { x = v.x; y = v.y; }
        [IN(LINE)] public float2(Vector2Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public float2(Vector3 v) { x = v.x; y = v.y; }
        [IN(LINE)] public float2(Vector3Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public float2(Vector4 v) { x = v.x; y = v.y; }

        [IN(LINE)] public static implicit operator Vector2(float2 a) => new Vector2(a.x, a.y);
        [IN(LINE)] public static explicit operator Vector2Int(float2 a) => new Vector2Int((int)a.x, (int)a.y);
        [IN(LINE)] public static implicit operator Vector3(float2 a) => new Vector3(a.x, a.y, 0f);
        [IN(LINE)] public static explicit operator Vector3Int(float2 a) => new Vector3Int((int)a.x, (int)a.y, 0);
        [IN(LINE)] public static implicit operator Vector4(float2 a) => new Vector4(a.x, a.y, 0f, 0f);

        [IN(LINE)] public static implicit operator float2(Vector2 a) { return new float2(a); }
        [IN(LINE)] public static implicit operator float2(Vector2Int a) { return new float2(a); }
        [IN(LINE)] public static explicit operator float2(Vector3 a) { return new float2(a); }
        [IN(LINE)] public static explicit operator float2(Vector3Int a) { return new float2(a); }
        [IN(LINE)] public static explicit operator float2(Vector4 a) { return new float2(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(float2))] internal class Float2Editor : VectorFieldDrawer { }
}
#endif

#endif