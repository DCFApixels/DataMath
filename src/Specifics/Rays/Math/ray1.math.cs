#if DISABLE_DEBUG
#undef DEBUG
#endif
using System.Numerics;
using System.Reflection;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray1
    {
        #region Length/Normalized
        public float From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public float To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public float Min { [IN(LINE)] get { return DM.Min(this); } }
        public float Max { [IN(LINE)] get { return DM.Max(this); } }
        public float Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray1 Normalized { [IN(LINE)] get { return new ray1(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM  // ray1
    {
        #region Abs
        [IN(LINE)] public static ray1 Abs(ray1 a) { return new ray1(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float Clamp(float a, ray1 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float Repeat(float a, ray1 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float PingPong(float a, ray1 range) { return PingPong(a, range.From, range.To); }
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static float SmoothStep(ray1 range, float a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float Max(ray1 range) { return IsPositive(range.dir) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static float Min(ray1 range) { return IsPositive(range.dir) ? range.src : range.src + range.dir; }
        #endregion

        #region Lerp
        [IN(LINE)] public static float Lerp(ray1 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpClamp(ray1 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpRepeat(ray1 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float UnLerp(ray1 range, float a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpClamp(ray1 range, float a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpRepeat(ray1 range, float a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float Remap(ray1 oldRange, ray1 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float LerpAngle(ray1 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleClamp(ray1 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleRepeat(ray1 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float MoveTowards(ray1 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float MoveTowards(ray1 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float MoveTowardsAngle(ray1 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool IsNegative(ray1 a) { return float.IsNegative(a.src); }
        [IN(LINE)] public static bool IsPositive(ray1 a) { return !float.IsNegative(a.src); }
        [IN(LINE)] public static bool IsFinite(ray1 a) { return float.IsFinite(a.src); }
        [IN(LINE)] public static bool IsInfinity(ray1 a) { return float.IsInfinity(a.src); }
        [IN(LINE)] public static bool IsNegativeInfinity(ray1 a) { return float.IsNegativeInfinity(a.src); }
        [IN(LINE)] public static bool IsPositiveInfinity(ray1 a) { return float.IsPositiveInfinity(a.src); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static ray1 GammaToLinearSpace(ray1 a) { const float Gamma = 2.2f; return new ray1(Pow(a.src, Gamma), Pow(a.dir, Gamma)); }
        [IN(LINE)] public static ray1 LinearToGammaSpace(ray1 a) { const float InverseGamma = 1.0f / 2.2f; return new ray1(Pow(a.src, InverseGamma), Pow(a.dir, InverseGamma)); }
        [IN(LINE)] public static ray1 Degrees(ray1 radians) { return new ray1(Degrees(radians.src), Degrees(radians.dir)); }
        [IN(LINE)] public static ray1 Radians(ray1 degrees) { return new ray1(Radians(degrees.src), Radians(degrees.dir)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(ray1 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSqr(ray1 a) { return LengthSqr(a.dir); }
        [IN(LINE)] public static ray1 Normalize(ray1 a) { return new ray1(a.src, Normalize(a.dir)); }
        [IN(LINE)] public static ray1 NormalizeSafe(ray1 a, float defaultvalue = 0f) { return new ray1(a.src, NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(ray1 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static ray1 Reverse(ray1 a) { return new ray1(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float GetPoint(ray1 ray, float distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(ray1 range, float a, float tolerance = 0.0001f) { return a >= range.Min && a <= range.Max; }
        [IN(LINE)] public static float ProjectPoint(ray1 ray, float point) { return point; }
        #endregion
    }
}


#region Unity
#if UNITY_5_3_OR_NEWER
namespace DCFApixels.DataMath
{
    using UnityEngine;
    public class ClampedRangeAttribute : PropertyAttribute
    {
        public readonly float min;
        public readonly float max;
        public ClampedRangeAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
        public ClampedRangeAttribute() : this(0f, 1f) { }
    }

    public class MinMaxRangeAttribute : PropertyAttribute
    {
    }
}
#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    using System;
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(ClampedRangeAttribute), true)]
    [CustomPropertyDrawer(typeof(MinMaxRangeAttribute), true)]
    [CustomPropertyDrawer(typeof(ray1), true)]
    public class RangedValueDrawer : PropertyDrawer
    {
        private const float SPACING = 4f;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            float defaultlabelWidth = EditorGUIUtility.labelWidth;

            SerializedProperty xProp = property.FindPropertyRelative(nameof(ray1.src));
            SerializedProperty lengthProp = property.FindPropertyRelative(nameof(ray1.dir));

            Rect labelRect = position;
            labelRect.width = defaultlabelWidth;

            Rect fieldRect = position;
            fieldRect.xMin = labelRect.xMax;

            if (string.IsNullOrEmpty(label.tooltip))
            {
                string minmaxTooltip;
                switch (xProp.propertyType)
                {
                    //case SerializedPropertyType.Integer:
                    //    minmaxTooltip = new irange(xProp.intValue, lengthProp.intValue).ToString();
                    //    break;
                    case SerializedPropertyType.Float:
                        minmaxTooltip = new ray1(xProp.floatValue, lengthProp.floatValue).ToString();
                        break;
                    default:
                        minmaxTooltip = "error";
                        break;
                }
                label.tooltip = minmaxTooltip;
            }

            EditorGUI.LabelField(labelRect, label);

            if (attribute is MinMaxRangeAttribute minMaxRangeAttribute)
            {
                DrawMinMaxField(fieldRect, property, minMaxRangeAttribute, xProp, lengthProp);
                goto exit;
            }

            if (attribute is ClampedRangeAttribute clampedRangeAttribute)
            {
                DrawClampedRangeField(fieldRect, property, clampedRangeAttribute, xProp, lengthProp);
                goto exit;
            }

            DrawDefaultField(fieldRect, xProp, lengthProp);

            exit:;
            EditorGUIUtility.labelWidth = defaultlabelWidth;
        }

        private void DrawDefaultField(Rect fieldRect, SerializedProperty xProp, SerializedProperty lengthProp)
        {
            using (new FixIndentLevel(0))
            {
                float width = fieldRect.width / 2f - SPACING / 2f;

                Rect minRect = fieldRect;
                minRect.width = width;
                minRect.x = fieldRect.xMin;

                Rect maxRect = fieldRect;
                maxRect.width = width;
                maxRect.x = minRect.xMax + SPACING;

                EditorGUIUtility.labelWidth = 12f;
                EditorGUI.PropertyField(minRect, xProp, new GUIContent("S", nameof(ray1.src)));
                EditorGUIUtility.labelWidth = 12f;
                EditorGUI.PropertyField(maxRect, lengthProp, new GUIContent("E", nameof(ray1.dir)));
            }
        }
        private void DrawClampedRangeField(Rect fieldRect, SerializedProperty property, ClampedRangeAttribute attribute, SerializedProperty xProp, SerializedProperty lengthProp)
        {
            using (new FixIndentLevel(0))
            {
                float rightFieldWidth = 24;
                float verticalSpacing = EditorGUIUtility.standardVerticalSpacing;

                if (fieldRect.width <= rightFieldWidth * 4.5f)
                {
                    rightFieldWidth = 0;
                    verticalSpacing = 0;
                }

                Rect leftFieldRect = fieldRect;
                leftFieldRect.xMax -= rightFieldWidth * 2f + verticalSpacing * 2f;

                Rect rightFieldRect1 = fieldRect;
                rightFieldRect1.x = leftFieldRect.xMax + verticalSpacing;
                rightFieldRect1.width = rightFieldWidth;

                Rect rightFieldRect2 = rightFieldRect1;
                rightFieldRect2.x = rightFieldRect1.xMax + verticalSpacing;

                switch (xProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        {
                            int min = xProp.intValue;
                            int max = lengthProp.intValue + min;

                            MinMaxSlider(leftFieldRect, ref min, ref max, (int)attribute.min, (int)attribute.max);

                            min = EditorGUI.IntField(rightFieldRect1, min);
                            max = EditorGUI.IntField(rightFieldRect2, max);
                            max = Mathf.Max(min, max);

                            xProp.intValue = min;
                            lengthProp.intValue = Mathf.Abs(max) - min;

                            property.serializedObject.ApplyModifiedProperties();
                        }
                        break;
                    case SerializedPropertyType.Float:
                        {
                            float min = xProp.floatValue;
                            float max = lengthProp.floatValue + min;

                            EditorGUI.MinMaxSlider(leftFieldRect, ref min, ref max, attribute.min, attribute.max);

                            min = EditorGUI.FloatField(rightFieldRect1, min);
                            max = EditorGUI.FloatField(rightFieldRect2, max);
                            max = Mathf.Max(min, max);

                            xProp.floatValue = min;
                            lengthProp.floatValue = Mathf.Abs(max) - min;

                            property.serializedObject.ApplyModifiedProperties();
                        }
                        break;
                    default:
                        GUI.Label(fieldRect, "error");
                        break;
                }
                ;
            }
        }
        private void DrawMinMaxField(Rect fieldRect, SerializedProperty property, MinMaxRangeAttribute attribute, SerializedProperty xProp, SerializedProperty lengthProp)
        {
            using (new FixIndentLevel(0))
            {
                float width = fieldRect.width / 2f - SPACING / 2f;

                Rect minRect = fieldRect;
                minRect.width = width;
                minRect.x = fieldRect.xMin;

                Rect maxRect = fieldRect;
                maxRect.width = width;
                maxRect.x = minRect.xMax + SPACING;

                EditorGUIUtility.labelWidth = 24f;
                EditorGUI.indentLevel = 0;

                switch (xProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        {
                            int min = xProp.intValue;
                            int max = lengthProp.intValue + min;

                            min = EditorGUI.IntField(minRect, min < max ? "Min" : "Max", min);
                            max = EditorGUI.IntField(maxRect, min < max ? "Max" : "Min", max);

                            xProp.intValue = min;
                            lengthProp.intValue = Mathf.Abs(max) - min;

                            property.serializedObject.ApplyModifiedProperties();
                        }
                        break;
                    case SerializedPropertyType.Float:
                        {
                            float min = xProp.floatValue;
                            float max = lengthProp.floatValue + min;

                            min = EditorGUI.FloatField(minRect, min < max ? "min" : "max", min);
                            max = EditorGUI.FloatField(maxRect, min < max ? "max" : "min", max);

                            xProp.floatValue = min;
                            lengthProp.floatValue = Mathf.Abs(max) - min;

                            property.serializedObject.ApplyModifiedProperties();
                        }
                        break;
                    default:
                        GUI.Label(fieldRect, "error");
                        break;
                }
            }
        }

        private void MinMaxSlider(Rect position, ref int minValue, ref int maxValue, float minLimit, float maxLimit)
        {
            float minValueFloat = minValue;
            float maxValueFloat = maxValue;
            EditorGUI.MinMaxSlider(position, ref minValueFloat, ref maxValueFloat, minLimit, maxLimit);
            minValue = Mathf.RoundToInt(minValueFloat);
            maxValue = Mathf.RoundToInt(maxValueFloat);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        private struct FixIndentLevel : IDisposable
        {
            private int lastValue;
            public FixIndentLevel(int indentLevel)
            {
                lastValue = EditorGUI.indentLevel;
                EditorGUI.indentLevel = indentLevel;
            }
            public void End()
            {
                EditorGUI.indentLevel = lastValue;
            }
            void IDisposable.Dispose()
            {
                End();
            }
        }
    }
}
#endif
#endif
#endregion
