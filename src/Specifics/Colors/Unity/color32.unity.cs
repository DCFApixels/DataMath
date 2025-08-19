#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct color32
    {
        [IN(LINE)] public color32(Color v) { this = new color32(new color(v)); }
        [IN(LINE)] public color32(Color32 v) { r8 = v.r; g8 = v.g; b8 = v.b; a8 = v.a; }

        [IN(LINE)] public static explicit operator Color(color32 a) { return new Color32(a.r8, a.g8, a.b8, a.a8); }
        [IN(LINE)] public static explicit operator Color32(color32 a) { return (Color)new Color32(a.r8, a.g8, a.b8, a.a8); }

        [IN(LINE)] public static implicit operator color32(Color a) { return new color32(a); }
        [IN(LINE)] public static implicit operator color32(Color32 a) { return new color32(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(color32))] internal class Color32Editor : Color32FieldDrawer { }
}
#endif

#endif