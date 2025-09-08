#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray2
    {
        #region Length/Normalized
        public float2 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public float2 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public float2 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float2 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float2 Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray2 Normalized { [IN(LINE)] get { return new ray2(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // ray2
    {
        #region Abs
        [IN(LINE)] public static ray2 Abs(ray2 a) { return new ray2(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float2 Clamp(float2 a, ray2 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float2 Repeat(float2 a, ray2 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float2 PingPong(float2 a, ray2 range) { return PingPong(a, range.From, range.To); }
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static float2 SmoothStep(ray2 range, float2 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float2 Max(ray2 range) { return IsPositive(range.dir) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static float2 Min(ray2 range) { return IsPositive(range.dir) ? range.src : range.src + range.dir; }
        #endregion

        #region Lerp
        [IN(LINE)] public static float2 Lerp(ray2 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpClamp(ray2 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpRepeat(ray2 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float2 UnLerp(ray2 range, float2 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float2 UnLerpClamp(ray2 range, float2 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float2 UnLerpRepeat(ray2 range, float2 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float2 Remap(ray2 oldRange, ray2 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float2 LerpAngle(ray2 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpAngleClamp(ray2 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpAngleRepeat(ray2 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float2 MoveTowards(ray2 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float2 MoveTowards(ray2 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float2 MoveTowardsAngle(ray2 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool2 IsNegative(ray2 a) { return IsNegative(a.src); }
        [IN(LINE)] public static bool2 IsPositive(ray2 a) { return IsPositive(a.src); }
        [IN(LINE)] public static bool2 IsFinite(ray2 a) { return IsFinite(a.src); }
        [IN(LINE)] public static bool2 IsInfinity(ray2 a) { return IsInfinity(a.src); }
        [IN(LINE)] public static bool2 IsNegativeInfinity(ray2 a) { return IsNegativeInfinity(a.src); }
        [IN(LINE)] public static bool2 IsPositiveInfinity(ray2 a) { return IsPositiveInfinity(a.src); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static ray2 GammaToLinearSpace(ray2 a) { const float Gamma = 2.2f; return new ray2(Pow(a.src, Gamma), Pow(a.dir, Gamma)); }
        [IN(LINE)] public static ray2 LinearToGammaSpace(ray2 a) { const float InverseGamma = 1.0f / 2.2f; return new ray2(Pow(a.src, InverseGamma), Pow(a.dir, InverseGamma)); }
        [IN(LINE)] public static ray2 Degrees(ray2 radians) { return new ray2(Degrees(radians.src), Degrees(radians.dir)); }
        [IN(LINE)] public static ray2 Radians(ray2 degrees) { return new ray2(Radians(degrees.src), Radians(degrees.dir)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(ray2 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSqr(ray2 a) { return LengthSqr(a.dir); }
        [IN(LINE)] public static ray2 Normalize(ray2 a) { return new ray2(a.src, Normalize(a.dir)); }
        [IN(LINE)] public static ray2 NormalizeSafe(ray2 a, float defaultvalue = 0f) { return new ray2(a.src, NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(ray2 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static ray2 Reverse(ray2 a) { return new ray2(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float2 GetPoint(ray2 ray, float distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(ray2 line, float2 point, float tolerance = 0.0001f)
        {
            float2 toPointVector = point - line.src;

            // Проверяем коллинеарность
            float crossProduct = Cross(line.dir, toPointVector);
            if (Abs(crossProduct) > tolerance) { return false; }

            // Проверяем, что точка находится между началом и концом отрезка
            float dotProduct = Dot(line.dir, toPointVector);
            if (dotProduct < -tolerance) { return false; }

            float squaredLength = line.dir.LengthSqr;
            if (dotProduct > squaredLength + tolerance) { return false; }

            return true;
        }
        //[IN(LINE)] public static float ProjectDistance(float2 src, float2 dir, float2 point) { return Dot(point - src, dir) / Dot(dir, dir); }
        [IN(LINE)] public static float2 ProjectPoint(ray2 ray, float2 point) { return ray.src + Project(point - ray.src, ray.dir); }



        #endregion
    }
}