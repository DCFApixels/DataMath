#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct colorhsv
    {
        [IN(LINE)] public colorhsv(Color v) { this = new colorhsv(new color(v)); }
        [IN(LINE)] public colorhsv(Color32 v) { this = new colorhsv(new color32(v)); }

        [IN(LINE)] public static explicit operator Color(colorhsv a)
        {
            Color result = Color.HSVToRGB(a.h, a.s, a.v); ;
            result.a = a.a;
            return result;
        }
        [IN(LINE)] public static explicit operator Color32(colorhsv a)
        {
            Color c = (Color)a;
            return (Color32)c;
        }

        [IN(LINE)] public static implicit operator colorhsv(Color a) { return new colorhsv(a); }
        [IN(LINE)] public static implicit operator colorhsv(Color32 a) { return new colorhsv(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(colorhsv))] internal class ColorHSVEditor : ColorHSVFieldDrawer { }
}
#endif

#endif