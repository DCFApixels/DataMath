using System;
#if UNITY_5_3_OR_NEWER
using UnityEngine;
#else
using DCFApixels.DataMath.Internal;
namespace DCFApixels.DataMath.Internal
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public abstract class PropertyAttribute : Attribute { }
}
#endif

namespace DCFApixels.DataMath.DisplayAttributes
{
    #region range
    //public sealed class RangeFieldAttribute : PropertyAttribute
    //{
    //    public bool IsShowDefaultDraw;
    //    public RangeFieldAttribute(bool isShowDefaultDraw = false)
    //    {
    //        IsShowDefaultDraw = isShowDefaultDraw;
    //    }
    //}
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public abstract class RangeValueDisplayModeAttribute : Attribute
    {
        public abstract RangeValueDisplayMode Mode { get; }
    }
    public enum RangeValueDisplayMode
    {
        None = 0,
        Clamped = 1,
        MinMax = 2,
        FromTo = 3,
    }

    public class ClampedRangeAttribute : RangeValueDisplayModeAttribute
    {
        public float Min;
        public float Max;
        public override RangeValueDisplayMode Mode { get { return RangeValueDisplayMode.Clamped; } }
        public ClampedRangeAttribute(float min, float max)
        {
            this.Min = min;
            this.Max = max;
        }
        public ClampedRangeAttribute() : this(0f, 1f) { }
    }
    public class MinMaxRangeAttribute : RangeValueDisplayModeAttribute
    {
        public override RangeValueDisplayMode Mode { get { return RangeValueDisplayMode.MinMax; } }
    }
    public class FromToRangeAttribute : RangeValueDisplayModeAttribute
    {
        public override RangeValueDisplayMode Mode { get { return RangeValueDisplayMode.FromTo; } }
    }
    #endregion

    #region vectors
    public sealed class VectorFieldAttribute : PropertyAttribute
    {
        public bool IsShowDefaultDraw;
        public VectorFieldAttribute(bool isShowDefaultDraw = false)
        {
            IsShowDefaultDraw = isShowDefaultDraw;
        }
    }
    public sealed class EulerFieldAttribute : PropertyAttribute
    {
        public bool IsShowDefaultDraw;
        public EulerFieldAttribute(bool isShowDefaultDraw = false)
        {
            IsShowDefaultDraw = isShowDefaultDraw;
        }
    }
    public sealed class ColorFieldAttribute : PropertyAttribute
    {
        public bool IsShowDefaultDraw;
        public ColorFieldAttribute(bool isShowDefaultDraw = false)
        {
            IsShowDefaultDraw = isShowDefaultDraw;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ColorHSVFieldAttribute : PropertyAttribute
    {
        public bool IsShowDefaultDraw;
        public ColorHSVFieldAttribute(bool isShowDefaultDraw = false)
        {
            IsShowDefaultDraw = isShowDefaultDraw;
        }
    }
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class Color32FieldAttribute : PropertyAttribute
    {
        public bool IsShowDefaultDraw;
        public Color32FieldAttribute(bool isShowDefaultDraw = false)
        {
            IsShowDefaultDraw = isShowDefaultDraw;
        }
    }
    #endregion
}