#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray3
    {
        #region Length/Normalized
        public float3 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public float3 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public float3 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float3 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float3 Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray3 Normalized { [IN(LINE)] get { return new ray3(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // ray3
    {
        #region Abs
        [IN(LINE)] public static ray3 Abs(ray3 a) { return new ray3(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float3 Clamp(float3 a, ray3 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float3 Repeat(float3 a, ray3 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float3 PingPong(float3 a, ray3 range) { return PingPong(a, range.From, range.To); }
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static float3 SmoothStep(ray3 range, float3 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float3 Max(ray3 range) { return IsPositive(range.dir) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static float3 Min(ray3 range) { return IsPositive(range.dir) ? range.src : range.src + range.dir; }
        #endregion

        #region Lerp
        [IN(LINE)] public static float3 Lerp(ray3 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpClamp(ray3 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpRepeat(ray3 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float3 UnLerp(ray3 range, float3 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float3 UnLerpClamp(ray3 range, float3 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float3 UnLerpRepeat(ray3 range, float3 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float3 Remap(ray3 oldRange, ray3 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float3 LerpAngle(ray3 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpAngleClamp(ray3 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpAngleRepeat(ray3 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float3 MoveTowards(ray3 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float3 MoveTowards(ray3 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float3 MoveTowardsAngle(ray3 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool3 IsNegative(ray3 a) { return IsNegative(a.src); }
        [IN(LINE)] public static bool3 IsPositive(ray3 a) { return IsPositive(a.src); }
        [IN(LINE)] public static bool3 IsFinite(ray3 a) { return IsFinite(a.src); }
        [IN(LINE)] public static bool3 IsInfinity(ray3 a) { return IsInfinity(a.src); }
        [IN(LINE)] public static bool3 IsNegativeInfinity(ray3 a) { return IsNegativeInfinity(a.src); }
        [IN(LINE)] public static bool3 IsPositiveInfinity(ray3 a) { return IsPositiveInfinity(a.src); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static ray3 GammaToLinearSpace(ray3 a) { const float Gamma = 2.2f; return new ray3(Pow(a.src, Gamma), Pow(a.dir, Gamma)); }
        [IN(LINE)] public static ray3 LinearToGammaSpace(ray3 a) { const float InverseGamma = 1.0f / 2.2f; return new ray3(Pow(a.src, InverseGamma), Pow(a.dir, InverseGamma)); }
        [IN(LINE)] public static ray3 Degrees(ray3 radians) { return new ray3(Degrees(radians.src), Degrees(radians.dir)); }
        [IN(LINE)] public static ray3 Radians(ray3 degrees) { return new ray3(Radians(degrees.src), Radians(degrees.dir)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(ray3 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSqr(ray3 a) { return LengthSqr(a.dir); }
        [IN(LINE)] public static ray3 Normalize(ray3 a) { return new ray3(a.src, Normalize(a.dir)); }
        [IN(LINE)] public static ray3 NormalizeSafe(ray3 a, float defaultvalue = 0f) { return new ray3(a.src, NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(ray3 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static ray3 Reverse(ray3 a) { return new ray3(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float3 GetPoint(ray3 ray, float distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(ray3 line, float3 point, float tolerance = 0.0001f)
        {
            float3 toPointVector = point - line.src;

            // Проверяем коллинеарность
            float3 crossProduct = Cross(line.dir, toPointVector);
            if (crossProduct.LengthSqr > tolerance) { return false; }

            // Проверяем, что точка находится между началом и концом отрезка
            float dotProduct = Dot(line.dir, toPointVector);
            if (dotProduct < -tolerance) { return false; }

            float squaredLength = line.dir.LengthSqr;
            if (dotProduct > squaredLength + tolerance) { return false; }

            return true;
        }
        //[IN(LINE)] public static float ProjectDistance(float3 src, float3 dir, float3 point) { return Dot(point - src, dir) / Dot(dir, dir); }
        [IN(LINE)] public static float3 ProjectPoint(ray3 ray, float3 point) { return ray.src + Project(point - ray.src, ray.dir); }



        #endregion
    }
}