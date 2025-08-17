using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public struct frange :
        IEquatable<frange>,
        IFormattable,
        IRange<float>
    {
        #region Consts
        public static readonly frange one = new frange(0f, 1f);
        #endregion

        /// <summary>The start of this range</summary>
        public float start;
        /// <summary>The length of this range</summary>
        public float extent;

        #region Properties
        float IRange<float>.start { [IN(LINE)] get => start; [IN(LINE)] set => start = value; }
        float IRange<float>.extent { [IN(LINE)] get => extent; [IN(LINE)] set => extent = value; }

        public float AbsExtent { [IN(LINE)] get => DM.Abs(extent); }
        public float Min
        {
            [IN(LINE)]
            get => start;
            [IN(LINE)]
            set
            {
                extent -= value - start;
                start = value;
            }
        }
        public float Max
        {
            [IN(LINE)]
            get => start + extent;
            [IN(LINE)]
            set
            {
                extent -= (Max - value);
            }
        }
        public float AbsMin => DM.Abs(Min);
        public float AbsMax => DM.Abs(Max);
        public bool IsNegative { [IN(LINE)] get => extent < 0; }
        public bool IsPositive { [IN(LINE)] get => extent >= 0; }
        public float Center { [IN(LINE)] get => start + extent / 2f; }
        #endregion

        #region Constructors
        [IN(LINE)]
        public frange(float extent)
        {
            start = 0;
            this.extent = extent;
        }
        [IN(LINE)]
        public frange(float start, float extent)
        {
            this.start = start;
            this.extent = extent;
        }
        [IN(LINE)]
        public static frange MinMax(float min, float max) => new frange(min, max - min);
        #endregion

        #region operators
        [IN(LINE)] public static implicit operator frange((float, float) tuple) => new frange(tuple.Item1, tuple.Item2);
        [IN(LINE)] public static implicit operator frange(irange range) => new frange(range.start, range.extent);

        [IN(LINE)] public static implicit operator frange(int a) => new frange(0, a);
        [IN(LINE)] public static implicit operator frange(int2 a) => new frange(a.x, a.y);
        [IN(LINE)] public static implicit operator frange(uint a) => new frange(0, a);
        [IN(LINE)] public static implicit operator frange(uint2 a) => new frange(a.x, a.y);
        [IN(LINE)] public static implicit operator frange(float a) => new frange(0f, a);
        [IN(LINE)] public static implicit operator frange(float2 a) => new frange(a.x, a.y);
        [IN(LINE)] public static explicit operator frange(double a) => new frange(0, (float)a);
        [IN(LINE)] public static explicit operator frange(double2 a) => new frange((float)a.x, (float)a.y);

        [IN(LINE)] public static bool operator ==(frange a, frange b) => a.Equals(b);
        [IN(LINE)] public static bool operator !=(frange a, frange b) => !a.Equals(b);

        [IN(LINE)] public static frange operator -(frange range, float v) => new frange(range.start - v, range.extent - v);
        [IN(LINE)] public static frange operator +(frange range, float v) => new frange(range.start + v, range.extent + v);
        [IN(LINE)] public static frange operator /(frange range, float v) => new frange(range.start / v, range.extent / v);
        [IN(LINE)] public static frange operator *(frange range, float v) => new frange(range.start * v, range.extent * v);
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() => DM.AsInt(start) ^ DM.AsInt(extent);
        [IN(LINE)] public override bool Equals(object o) => o is frange target && Equals(target);
        [IN(LINE)] public bool Equals(frange a) => start == a.start && extent == a.extent;
        [IN(LINE)] public override string ToString() => $"{nameof(frange)}({start}, {extent})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(frange)}({start.ToString(format, formatProvider)}, {extent.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float start, extent;
            public DebuggerProxy(frange v) { start = v.start; extent = v.extent; }
        }
        #endregion

        #region Contains/Overlaps
        public bool Contains(float v)
        {
            v -= start;
            return v >= 0 && v <= extent;
        }
        public bool Contains(frange r)
        {
            return r.Min >= Min && r.Max <= Max;
        }
        public bool Overlaps(frange other)
        {
            float separation = MathF.Abs(other.Center - Center);
            float total = (other.extent + extent) / 2;
            return separation < total;
        }
        #endregion
    }

    public static partial class DM // floatrange
    {
        #region clamp/clamp01
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(frange r, float v)
        {
            if (v < r.Min) return r.Min;
            if (v > r.Max) return r.Max;
            return v;
        }
        #endregion

        #region lerp
        [IN(LINE)]
        public static float2 Lerp(frange range, float t)
        {
            return range.start + t * range.extent;
        }
        [IN(LINE)]
        public static float2 LerpClamp(frange range, float t)
        {
            t = Clamp01(t);
            return range.start + t * range.extent;
        }
        [IN(LINE)]
        public static float2 LerpLoop(frange range, float t)
        {
            t %= 1f;
            return range.start + t * range.extent;
        }
        [IN(LINE)]
        public static float2 UnLerp(frange range, float2 v)
        {
            return (v - range.start) / range.extent;
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static frange Reverse(frange r)
        {
            return frange.MinMax(r.Max, r.Min);
        }
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
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(ClampedRangeAttribute), true)]
    [CustomPropertyDrawer(typeof(MinMaxRangeAttribute), true)]
    [CustomPropertyDrawer(typeof(floatrange), true)]
    [CustomPropertyDrawer(typeof(intrange), true)]
    public class RangedValueDrawer : PropertyDrawer
    {
        private const float SPACING = 4f;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            float defaultlabelWidth = EditorGUIUtility.labelWidth;

            SerializedProperty xProp = property.FindPropertyRelative(nameof(floatrange.start));
            SerializedProperty lengthProp = property.FindPropertyRelative(nameof(floatrange.extent));

            Rect labelRect = position;
            labelRect.width = defaultlabelWidth;

            Rect fieldRect = position;
            fieldRect.xMin = labelRect.xMax;

            if (string.IsNullOrEmpty(label.tooltip))
            {
                string minmaxTooltip;
                switch (xProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        minmaxTooltip = new intrange(xProp.intValue, lengthProp.intValue).ToString();
                        break;
                    case SerializedPropertyType.Float:
                        minmaxTooltip = new floatrange(xProp.floatValue, lengthProp.floatValue).ToString();
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
                EditorGUI.PropertyField(minRect, xProp, new GUIContent("S", nameof(floatrange.start)));
                EditorGUIUtility.labelWidth = 12f;
                EditorGUI.PropertyField(maxRect, lengthProp, new GUIContent("E", nameof(floatrange.extent)));
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
                };
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
