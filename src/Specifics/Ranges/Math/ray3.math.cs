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
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray3 Normalized { [IN(LINE)] get { return new ray3(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // ray3
    {
        #region Abs
        [IN(LINE)] public static ray3 Abs(ray3 a) { return new ray3(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float3 Max(ray3 range) { return Select(range.src, range.src + range.dir, range.dir >= 0f); }
        [IN(LINE)] public static float3 Min(ray3 range) { return Select(range.src + range.dir, range.src, range.dir >= 0f); }
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
        [IN(LINE)] public static float LengthSq(ray3 a) { return LengthSq(a.dir); }
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
            if (crossProduct.LengthSq > tolerance) { return false; }

            // Проверяем, что точка находится между началом и концом отрезка
            float dotProduct = Dot(line.dir, toPointVector);
            if (dotProduct < -tolerance) { return false; }

            float squaredLength = line.dir.LengthSq;
            if (dotProduct > squaredLength + tolerance) { return false; }

            return true;
        }
        [IN(LINE)] public static float3 ProjectPoint(ray3 ray, float3 point) { return ray.src + Project(point - ray.src, ray.dir); }
        [IN(LINE)] public static float UnLerpProjected(ray3 ray, float3 point) { return Dot(point - ray.src, ray.dir) / LengthSq(ray.dir); }
        [IN(LINE)]
        public static float3 ClosestPoint(ray3 ray, float3 point)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray.src; }
            return ray.src + Project(point - ray.src, ray.dir);
        }
        [IN(LINE)]
        public static float3 ClosestPointClamp(ray3 ray, float3 point)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray.src; }
            float t = Clamp01(Dot(point - ray.src, ray.dir) / lengthSq);
            return ray.src + ray.dir * t;
        }
        [IN(LINE)]
        public static bool ContainsProjected(ray3 ray, float3 point, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return LengthSq(point - ray.src) <= tolerance * tolerance; }
            float dot = Dot(ray.dir, point - ray.src);
            return dot >= -tolerance && dot <= lengthSq + tolerance;
        }
        [IN(LINE)]
        public static bool ContainsProjected(ray3 a, ray3 b, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(a.dir);
            if (lengthSq <= 0f) { return ContainsProjected(a, b.src, tolerance) && ContainsProjected(a, b.src + b.dir, tolerance); }
            line1 aProjection = new line1(0f, lengthSq);
            line1 bProjection = new line1(Dot(a.dir, b.src - a.src), Dot(a.dir, b.src + b.dir - a.src));
            return Contains(aProjection, bProjection, tolerance);
        }
        [IN(LINE)]
        public static bool OverlapsProjected(ray3 a, ray3 b, float tolerance = 0.0001f)
        {
            float lengthSq = LengthSq(a.dir);
            if (lengthSq <= 0f) { return ContainsProjected(b, a.src, tolerance); }
            line1 aProjection = new line1(0f, lengthSq);
            line1 bProjection = new line1(Dot(a.dir, b.src - a.src), Dot(a.dir, b.src + b.dir - a.src));
            return Overlaps(aProjection, bProjection, tolerance);
        }
        [IN(LINE)]
        public static ray3 Expand(ray3 ray, float amount)
        {
            float lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0f) { return ray; }
            float3 offset = Normalize(ray.dir) * amount;
            return new ray3(ray.src - offset, ray.dir + offset * 2f);
        }
        #endregion
    }
}
