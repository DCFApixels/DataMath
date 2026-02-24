#if UNITY_5_3_OR_NEWER && UNITY_EDITOR
using DCFApixels.DataMath.DisplayAttributes;
using System;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

namespace DCFApixels.DataMath.Unity.Editors
{
    //[CustomPropertyDrawer(typeof(RangeFieldAttribute), true)]
    [CustomPropertyDrawer(typeof(intray1), true)]
    [CustomPropertyDrawer(typeof(ray1), true)]
    public class RangedValueDrawer : PropertyDrawer
    {
        private const float SPACING = 4f;
        private bool _isInit = false;
        private RangeValueDisplayMode _mode = RangeValueDisplayMode.None;
        private RangeValueDisplayModeAttribute _modeAttribute;
        private SerializedProperty[] _elemProperties = new SerializedProperty[2];
        private void Init(SerializedProperty property)
        {
            if (_isInit) { return; }
            _modeAttribute = fieldInfo.GetCustomAttribute<RangeValueDisplayModeAttribute>();
            if(_modeAttribute != null)
            {
                _mode = _modeAttribute.Mode;
            }

            _elemProperties[0] = property.FindPropertyRelative(nameof(ray1.src));
            _elemProperties[1] = property.FindPropertyRelative(nameof(ray1.dir));

            _isInit = true;
        }

        private static GUIContent _tmpLabel;
        protected static GUIContent TmpLabel
        {
            get
            {
                if (_tmpLabel == null) { _tmpLabel = new GUIContent(); }
                return _tmpLabel;
            }
        }
        private GUIContent GetTempLabel(string text, string tooltip = "")
        {
            var result = TmpLabel;
            result.text = text;
            result.tooltip = tooltip;
            return result;
        }

        protected float Line => EditorGUIUtility.singleLineHeight;
        protected float Space => EditorGUIUtility.standardVerticalSpacing;

        private SerializedProperty SrcProp { get { return _elemProperties[0]; } }
        private SerializedProperty DirProp { get { return _elemProperties[1]; } }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Init(property);

            float defaultlabelWidth = EditorGUIUtility.labelWidth;

            Rect labelRect = position;
            labelRect.width = defaultlabelWidth;

            Rect fieldRect = position;
            fieldRect.xMin = labelRect.xMax;

            if (string.IsNullOrEmpty(label.tooltip) && position.Contains(Event.current.mousePosition))
            {
                string minmaxTooltip;
                switch (SrcProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        minmaxTooltip = new intray1(SrcProp.intValue, DirProp.intValue).ToString();
                        break;
                    case SerializedPropertyType.Float:
                        minmaxTooltip = new ray1(SrcProp.floatValue, DirProp.floatValue).ToString();
                        break;
                    default:
                        minmaxTooltip = "error";
                        break;
                }
                label.tooltip = minmaxTooltip;
            }

            EditorGUI.LabelField(labelRect, label);

            EditorGUI.BeginChangeCheck();
            switch (_mode)
            {
                case RangeValueDisplayMode.Clamped:
                    DrawClampedRangeField(fieldRect, property, UnsafeUtility.As<RangeValueDisplayModeAttribute, ClampedRangeAttribute>(ref _modeAttribute), SrcProp, DirProp);
                    break;
                case RangeValueDisplayMode.MinMax:
                    DrawMinMaxField(fieldRect, property, UnsafeUtility.As<RangeValueDisplayModeAttribute, MinMaxRangeAttribute>(ref _modeAttribute), SrcProp, DirProp);
                    break;
                case RangeValueDisplayMode.FromTo:
                    DrawFromToField(fieldRect, property, UnsafeUtility.As<RangeValueDisplayModeAttribute, FromToRangeAttribute>(ref _modeAttribute), SrcProp, DirProp);
                    break;
                default:
                    DrawDefaultField(fieldRect, SrcProp, DirProp);
                    break;
            }
            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUIUtility.labelWidth = defaultlabelWidth;
        }

        private void DrawDefaultField(Rect fieldRect, SerializedProperty xProp, SerializedProperty lengthProp)
        {
            using (new IndentLevelScope(0))
            {
                float width = fieldRect.width / 2f - SPACING / 2f;

                Rect minRect = fieldRect;
                minRect.width = width;
                minRect.x = fieldRect.xMin;

                Rect maxRect = fieldRect;
                maxRect.width = width;
                maxRect.x = minRect.xMax + SPACING;

                EditorGUIUtility.labelWidth = 24f;
                EditorGUI.PropertyField(minRect, xProp, GetTempLabel("src", nameof(ray1.src)));
                EditorGUIUtility.labelWidth = 24f;
                EditorGUI.PropertyField(maxRect, lengthProp, GetTempLabel("dir", nameof(ray1.dir)));
            }
        }
        private void DrawClampedRangeField(Rect fieldRect, SerializedProperty property, ClampedRangeAttribute attribute, SerializedProperty srcProp, SerializedProperty dirProp)
        {
            using (new IndentLevelScope(0))
            {
                float rightFieldWidth = 24f;
                float verticalSpacing = Space;

                //if (fieldRect.width <= rightFieldWidth * 4.5f)
                //if (fieldRect.width <= rightFieldWidth * 4.5f)
                //{
                //    rightFieldWidth = 0;
                //    verticalSpacing = 0;
                //}

                Rect leftFieldRect = fieldRect;
                leftFieldRect.xMax -= rightFieldWidth * 2f + verticalSpacing * 2f;

                Rect rightFieldRect1 = fieldRect;
                rightFieldRect1.x = leftFieldRect.xMax + verticalSpacing;
                rightFieldRect1.width = rightFieldWidth;

                Rect rightFieldRect2 = rightFieldRect1;
                rightFieldRect2.x = rightFieldRect1.xMax + verticalSpacing;

                switch (srcProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        {
                            int from = srcProp.intValue;
                            int to = dirProp.intValue + from;

                            MinMaxSliderInt(leftFieldRect, ref from, ref to, (int)attribute.Min, (int)attribute.Max);

                            from = EditorGUI.IntField(rightFieldRect1, from);
                            to = EditorGUI.IntField(rightFieldRect2, to);
                            to = Mathf.Max(from, to);

                            srcProp.intValue = from;
                            dirProp.intValue = to - from;
                        }
                        break;
                    case SerializedPropertyType.Float:
                        {
                            float from = srcProp.floatValue;
                            float to = dirProp.floatValue + from;

                            EditorGUI.MinMaxSlider(leftFieldRect, ref from, ref to, attribute.Min, attribute.Max);

                            from = EditorGUI.FloatField(rightFieldRect1, from);
                            to = EditorGUI.FloatField(rightFieldRect2, to);
                            to = Mathf.Max(from, to);

                            srcProp.floatValue = from;
                            dirProp.floatValue = to - from;
                        }
                        break;
                    default:
                        GUI.Label(fieldRect, "error");
                        break;
                }
                ;
            }
        }
        private void DrawFromToField(Rect fieldRect, SerializedProperty property, FromToRangeAttribute attribute, SerializedProperty srcProp, SerializedProperty dirProp)
        {
            using (new IndentLevelScope(0))
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

                switch (srcProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        {
                            int from = srcProp.intValue;
                            int to = dirProp.intValue + from;

                            from = EditorGUI.IntField(minRect, "from", from);
                            to = EditorGUI.IntField(maxRect, "to", to);

                            srcProp.intValue = from;
                            dirProp.intValue = to - from;
                        }
                        break;
                    case SerializedPropertyType.Float:
                        {
                            float from = srcProp.floatValue;
                            float to = dirProp.floatValue + from;

                            from = EditorGUI.FloatField(minRect, "from", from);
                            to = EditorGUI.FloatField(maxRect, "to", to);

                            srcProp.floatValue = from;
                            dirProp.floatValue = to - from;
                        }
                        break;
                    default:
                        GUI.Label(fieldRect, "error");
                        break;
                }
            }
        }
        private void DrawMinMaxField(Rect fieldRect, SerializedProperty property, MinMaxRangeAttribute attribute, SerializedProperty srcProp, SerializedProperty dirProp)
        {
            using (new IndentLevelScope(0))
            {
                const float SignButtonWidth = 18f;
                Rect signButtonRect = fieldRect;
                signButtonRect.width = SignButtonWidth;
                fieldRect.xMin += SignButtonWidth;

                float width = fieldRect.width / 2f - SPACING / 2f;

                Rect minRect = fieldRect;
                minRect.width = width;
                minRect.x = fieldRect.xMin;

                Rect maxRect = fieldRect;
                maxRect.width = width;
                maxRect.x = minRect.xMax + SPACING;

                EditorGUIUtility.labelWidth = 24f;
                EditorGUI.indentLevel = 0;

                switch (srcProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        {
                            int from = srcProp.intValue;
                            int dir = dirProp.intValue;
                            if (GUI.Button(signButtonRect, DM.IsPositive(dir) ? "+" : "-"))
                            {
                                EditorGUI.FocusTextInControl(null);
                                from = dir + from;
                                dir = -dir;
                            }
                            var to = dir + from;

                            if(from <= to)
                            {
                                from = EditorGUI.IntField(minRect, "min", from);
                                to = EditorGUI.IntField(maxRect, "max", to);
                            }
                            else
                            {
                                from = EditorGUI.IntField(maxRect, "max", from);
                                to = EditorGUI.IntField(minRect, "min", to);
                            }

                            srcProp.intValue = from;
                            dirProp.intValue = to - from;
                        }
                        break;
                    case SerializedPropertyType.Float:
                        {
                            float from = srcProp.floatValue;
                            float dir = dirProp.floatValue;
                            if(GUI.Button(signButtonRect, DM.IsPositive(dir) ? "+" : "-"))
                            {
                                EditorGUI.FocusTextInControl(null);
                                from = dir + from;
                                dir = -dir;
                            }
                            var to = dir + from;

                            if (from <= to)
                            {
                                from = EditorGUI.FloatField(minRect, "min", from);
                                to = EditorGUI.FloatField(maxRect, "max", to);
                            }
                            else
                            {
                                from = EditorGUI.FloatField(maxRect, "max", from);
                                to = EditorGUI.FloatField(minRect, "min", to);
                            }

                            srcProp.floatValue = from;
                            dirProp.floatValue = to - from;
                        }
                        break;
                    default:
                        GUI.Label(fieldRect, "error");
                        break;
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }


        #region Utils
        private static void MinMaxSliderInt(Rect position, ref int minValue, ref int maxValue, float minLimit, float maxLimit)
        {
            float minValueFloat = minValue;
            float maxValueFloat = maxValue;
            EditorGUI.MinMaxSlider(position, ref minValueFloat, ref maxValueFloat, minLimit, maxLimit);
            minValue = Mathf.RoundToInt(minValueFloat);
            maxValue = Mathf.RoundToInt(maxValueFloat);
        }
        private struct IndentLevelScope : IDisposable
        {
            private int value;
            public IndentLevelScope(int indentLevel)
            {
                value = EditorGUI.indentLevel;
                EditorGUI.indentLevel = indentLevel;
            }
            public static IndentLevelScope Decrement() { return new IndentLevelScope(EditorGUI.indentLevel - 1); }
            public void End() { EditorGUI.indentLevel = value; }
            void IDisposable.Dispose() { End(); }
        }
        #endregion
    }
}
#endif