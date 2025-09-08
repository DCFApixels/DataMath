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
    public partial struct double2
    {
        [IN(LINE)] public double2(Vector2 v) { x = v.x; y = v.y; }
        [IN(LINE)] public double2(Vector2Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public double2(Vector3 v) { x = v.x; y = v.y; }
        [IN(LINE)] public double2(Vector3Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public double2(Vector4 v) { x = v.x; y = v.y; }

        [IN(LINE)] public static explicit operator Vector2(double2 a) { return new Vector2((float)a.x, (float)a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(double2 a) { return new Vector2Int((int)a.x, (int)a.y); }
        [IN(LINE)] public static explicit operator Vector3(double2 a) { return new Vector3((float)a.x, (float)a.y, 0f); }
        [IN(LINE)] public static explicit operator Vector3Int(double2 a) { return new Vector3Int((int)a.x, (int)a.y, 0); }
        [IN(LINE)] public static explicit operator Vector4(double2 a) { return new Vector4((float)a.x, (float)a.y, 0f, 0f); }

        [IN(LINE)] public static implicit operator double2(Vector2 a) { return new double2(a.x, a.y); }
        [IN(LINE)] public static implicit operator double2(Vector2Int a) { return new double2(a.x, a.y); }
        [IN(LINE)] public static explicit operator double2(Vector3 a) { return new double2(a.x, a.y); }
        [IN(LINE)] public static explicit operator double2(Vector3Int a) { return new double2(a.x, a.y); }
        [IN(LINE)] public static explicit operator double2(Vector4 a) { return new double2(a.x, a.y); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(double2))] internal class Double2Editor : VectorFieldDrawer { }
}
#endif

#endif