#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using System;
using System.Numerics;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray4
    {
        #region Length/Normalized
        public float4 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public float4 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public float4 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float4 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float4 Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray4 Normalized { [IN(LINE)] get { return new ray4(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // ray4
    {
        #region Abs
        [IN(LINE)] public static ray4 Abs(ray4 a) { return new ray4(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float4 Clamp(float4 a, ray4 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float4 Repeat(float4 a, ray4 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float4 PingPong(float4 a, ray4 range) { return PingPong(a, range.From, range.To); }
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static float4 SmoothStep(ray4 range, float4 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float4 Max(ray4 range) { return IsPositive(range.dir) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static float4 Min(ray4 range) { return IsPositive(range.dir) ? range.src : range.src + range.dir; }
        #endregion

        #region Lerp
        [IN(LINE)] public static float4 Lerp(ray4 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpClamp(ray4 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpRepeat(ray4 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float4 UnLerp(ray4 range, float4 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float4 UnLerpClamp(ray4 range, float4 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float4 UnLerpRepeat(ray4 range, float4 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float4 Remap(ray4 oldRange, ray4 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float4 LerpAngle(ray4 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpAngleClamp(ray4 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpAngleRepeat(ray4 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float4 MoveTowards(ray4 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float4 MoveTowards(ray4 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float4 MoveTowardsAngle(ray4 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool4 IsNegative(ray4 a) { return IsNegative(a.src); }
        [IN(LINE)] public static bool4 IsPositive(ray4 a) { return IsPositive(a.src); }
        [IN(LINE)] public static bool4 IsFinite(ray4 a) { return IsFinite(a.src); }
        [IN(LINE)] public static bool4 IsInfinity(ray4 a) { return IsInfinity(a.src); }
        [IN(LINE)] public static bool4 IsNegativeInfinity(ray4 a) { return IsNegativeInfinity(a.src); }
        [IN(LINE)] public static bool4 IsPositiveInfinity(ray4 a) { return IsPositiveInfinity(a.src); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static ray4 GammaToLinearSpace(ray4 a) { const float Gamma = 2.2f; return new ray4(Pow(a.src, Gamma), Pow(a.dir, Gamma)); }
        [IN(LINE)] public static ray4 LinearToGammaSpace(ray4 a) { const float InverseGamma = 1.0f / 2.2f; return new ray4(Pow(a.src, InverseGamma), Pow(a.dir, InverseGamma)); }
        [IN(LINE)] public static ray4 Degrees(ray4 radians) { return new ray4(Degrees(radians.src), Degrees(radians.dir)); }
        [IN(LINE)] public static ray4 Radians(ray4 degrees) { return new ray4(Radians(degrees.src), Radians(degrees.dir)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(ray4 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSqr(ray4 a) { return LengthSqr(a.dir); }
        [IN(LINE)] public static ray4 Normalize(ray4 a) { return new ray4(a.src, Normalize(a.dir)); }
        [IN(LINE)] public static ray4 NormalizeSafe(ray4 a, float defaultvalue = 0f) { return new ray4(a.src, NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(ray4 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static ray4 Reverse(ray4 a) { return new ray4(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float4 GetPoint(ray4 ray, float distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(ray4 line, float4 point, float tolerance = 0.0001f)
        {
            float4 toPointVector = point - line.src;

            // Проверяем коллинеарность через сравнение направлений
            float4 normalizedLineVector = Normalize(line.dir);
            float4 normalizedToPointVector = Normalize(toPointVector);
            float directionSimilarity = Dot(normalizedLineVector, normalizedToPointVector);
            if (Math.Abs(Math.Abs(directionSimilarity) - 1.0f) > tolerance)
            {
                return false;
            }

            // Проверяем, что точка находится между началом и концом отрезка
            float dotProduct = Dot(line.dir, toPointVector);
            if (dotProduct < -tolerance) { return false; }

            float squaredLength = line.dir.LengthSqr;
            if (dotProduct > squaredLength + tolerance) { return false; }

            return true;
        }
        //[IN(LINE)] public static float ProjectDistance(float4 src, float4 dir, float4 point) { return Dot(point - src, dir) / Dot(dir, dir); }
        [IN(LINE)] public static float4 ProjectPoint(ray4 ray, float4 point) { return ray.src + Project(point - ray.src, ray.dir); }



        #endregion
    }
}