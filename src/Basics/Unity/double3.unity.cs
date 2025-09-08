#if UNITY_5_3_OR_NEWER
#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        [IN(LINE)] public double3(Vector2 v) { x = v.x; y = v.y; z = 0; }
        [IN(LINE)] public double3(Vector2Int v) { x = v.x; y = v.y; z = 0; }
        [IN(LINE)] public double3(Vector3 v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public double3(Vector3Int v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public double3(Vector4 v) { x = v.x; y = v.y; z = v.z; }

        [IN(LINE)] public static explicit operator Vector2(double3 a) { return new Vector2((float)a.x, (float)a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(double3 a) { return new Vector2Int((int)a.x, (int)a.y); }
        [IN(LINE)] public static explicit operator Vector3(double3 a) { return new Vector3((float)a.x, (float)a.y, (float)a.z); }
        [IN(LINE)] public static explicit operator Vector3Int(double3 a) { return new Vector3Int((int)a.x, (int)a.y, (int)a.z); }
        [IN(LINE)] public static explicit operator Vector4(double3 a) { return new Vector4((float)a.x, (float)a.y, (float)a.z, 0f); }

        [IN(LINE)] public static implicit operator double3(Vector2 a) { return new double3(a); }
        [IN(LINE)] public static implicit operator double3(Vector2Int a) { return new double3(a); }
        [IN(LINE)] public static implicit operator double3(Vector3 a) { return new double3(a); }
        [IN(LINE)] public static implicit operator double3(Vector3Int a) { return new double3(a); }
        [IN(LINE)] public static explicit operator double3(Vector4 a) { return new double3(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(double3))] internal class Double3Editor : VectorFieldDrawer { }
}
#endif

#endif