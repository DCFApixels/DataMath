#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using System;
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
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray4 Normalized { [IN(LINE)] get { return new ray4(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // ray4
    {
        #region Abs
        [IN(LINE)] public static ray4 Abs(ray4 a) { return new ray4(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float4 Max(ray4 range) { return Select(range.src, range.src + range.dir, range.dir >= 0f); }
        [IN(LINE)] public static float4 Min(ray4 range) { return Select(range.src + range.dir, range.src, range.dir >= 0f); }
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
        [IN(LINE)] public static float LengthSq(ray4 a) { return LengthSq(a.dir); }
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

            float squaredLength = line.dir.LengthSq;
            if (dotProduct > squaredLength + tolerance) { return false; }

            return true;
        }
        [IN(LINE)] public static float4 ProjectPoint(ray4 ray, float4 point) { return ray.src + Project(point - ray.src, ray.dir); }
        [IN(LINE)] public static float UnLerpProjected(ray4 ray, float4 point) { return Dot(point - ray.src, ray.dir) / LengthSq(ray.dir); }
        [IN(LINE)]
        public static float4 ClosestPoint(ray4 ray, float4 point)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray.src; }
            return ray.src + Project(point - ray.src, ray.dir);
        }
        [IN(LINE)]
        public static float4 ClosestPointClamp(ray4 ray, float4 point)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray.src; }
            float t = Clamp01(Dot(point - ray.src, ray.dir) / lengthSq);
            return ray.src + ray.dir * t;
        }
        [IN(LINE)]
        public static bool ContainsProjected(ray4 ray, float4 point, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return LengthSq(point - ray.src) <= tolerance * tolerance; }
            float dot = Dot(ray.dir, point - ray.src);
            return dot >= -tolerance && dot <= lengthSq + tolerance;
        }
        [IN(LINE)]
        public static bool ContainsProjected(ray4 a, ray4 b, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(a.dir);
            if (lengthSq <= 0f) { return ContainsProjected(a, b.src, tolerance) && ContainsProjected(a, b.src + b.dir, tolerance); }
            line1 aProjection = new line1(0f, lengthSq);
            line1 bProjection = new line1(Dot(a.dir, b.src - a.src), Dot(a.dir, b.src + b.dir - a.src));
            return Contains(aProjection, bProjection, tolerance);
        }
        [IN(LINE)]
        public static bool OverlapsProjected(ray4 a, ray4 b, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(a.dir);
            if (lengthSq <= 0f) { return ContainsProjected(b, a.src, tolerance); }
            line1 aProjection = new line1(0f, lengthSq);
            line1 bProjection = new line1(Dot(a.dir, b.src - a.src), Dot(a.dir, b.src + b.dir - a.src));
            return Overlaps(aProjection, bProjection, tolerance);
        }
        [IN(LINE)]
        public static ray4 Expand(ray4 ray, float amount)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray; }
            float4 offset = Normalize(ray.dir) * amount;
            return new ray4(ray.src - offset, ray.dir + offset * 2f);
        }
        #endregion
    }
}
