using System;
using System.ComponentModel;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        #region Length/Normalized
        public double Length { [IN(LINE)] get { return DM.Length(this); } }
        public double LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public double3 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // double3
    {
        #region Abs/Sign
        [IN(LINE)] public static double3 Abs(double3 a) { return new double3(Abs(a.x), Abs(a.y), Abs(a.z)); }
        [IN(LINE)] public static double3 Sign(double3 a) { return new double3(Sign(a.x), Sign(a.y), Sign(a.z)); }
        [IN(LINE)] public static int3 Sign2Int(double3 a) { return new int3(Sign2Int(a.x), Sign2Int(a.y), Sign2Int(a.z)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static double3 Round(double3 a) { return new double3(Round(a.x), Round(a.y), Round(a.z)); }
        [IN(LINE)] public static int3 Round2Int(double3 a) { return new int3(Round2Int(a.x), Round2Int(a.y), Round2Int(a.z)); }
        [IN(LINE)] public static double3 Floor(double3 a) { return new double3(Floor(a.x), Floor(a.y), Floor(a.z)); }
        [IN(LINE)] public static int3 Floor2Int(double3 a) { return new int3(Floor2Int(a.x), Floor2Int(a.y), Floor2Int(a.z)); }
        [IN(LINE)] public static double3 Ceil(double3 a) { return new double3(Ceil(a.x), Ceil(a.y), Ceil(a.z)); }
        [IN(LINE)] public static int3 Ceil2Int(double3 a) { return new int3(Ceil2Int(a.x), Ceil2Int(a.y), Ceil2Int(a.z)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Round2UInt(double3 a) { return new uint3(Round2UInt(a.x), Round2UInt(a.y), Round2UInt(a.z)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Floor2UInt(double3 a) { return new uint3(Floor2UInt(a.x), Floor2UInt(a.y), Floor2UInt(a.z)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Ceil2UInt(double3 a) { return new uint3(Ceil2UInt(a.x), Ceil2UInt(a.y), Ceil2UInt(a.z)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static double3 Clamp(double3 a, double3 min, double3 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double3 Clamp01(double3 a) { return Clamp(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double3 ClampMirror1(double3 a) { return Clamp(a, -1d, 1d); }

        [IN(LINE)] public static double3 Repeat(double3 a, double3 length) { return Clamp(a - Floor(a / length) * length, 0d, length); }
        [IN(LINE)] public static double3 Repeat(double3 a, double3 min, double3 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static double3 Repeat01(double3 a) { return Repeat(a, 1d); }
        [IN(LINE)] public static double3 RepeatMirror1(double3 a) { return Repeat(a, -1d, 1d); }

        [IN(LINE)] public static double3 PingPong(double3 a, double3 length) { return length - Abs(Repeat(a, length * 2d) - length); }
        [IN(LINE)] public static double3 PingPong(double3 a, double3 min, double3 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static double3 PingPong01(double3 a) { return PingPong(a, 0d, 1d); }
        [IN(LINE)] public static double3 PingPongMirror1(double3 a) { return PingPong(a, -1d, 1d); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static double3 SmoothStep(double3 from, double3 to, double3 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0d - (2.0d * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double3 SmoothStep01(double3 a) { return SmoothStep(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double3 SmoothStepMirror1(double3 a) { return SmoothStep(a, -1d, 1d); }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static double3 Max(double3 a, double3 b) { return new double3(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z)); }
        [IN(LINE)] public static double3 AbsMax(double3 a, double3 b) { return new double3(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z)); }
        [IN(LINE)] public static double3 Min(double3 a, double3 b) { return new double3(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z)); }
        [IN(LINE)] public static double3 AbsMin(double3 a, double3 b) { return new double3(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z)); }
        [IN(LINE)] public static double CMax(double3 a) { return CMax(a.x, a.y, a.z); }
        [IN(LINE)] public static double CAbsMax(double3 a) { return CAbsMax(a.x, a.y, a.z); }
        [IN(LINE)] public static double CMin(double3 a) { return CMin(a.x, a.y, a.z); }
        [IN(LINE)] public static double CAbsMin(double3 a) { return CAbsMin(a.x, a.y, a.z); }
        [IN(LINE)] public static double CSum(double3 a) { return a.x + a.y + a.z; }
        #endregion

        #region Lerp
        [IN(LINE)] public static double3 Lerp(double3 start, double3 end, double3 t) { return start + t * (end - start); }
        [IN(LINE)] public static double3 LerpClamp(double3 start, double3 end, double3 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static double3 LerpRepeat(double3 start, double3 end, double3 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static double3 UnLerp(double3 start, double3 end, double3 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static double3 UnLerpClamp(double3 start, double3 end, double3 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static double3 UnLerpRepeat(double3 start, double3 end, double3 a) { return Repeat01(UnLerp(start, end, a)); }


        [IN(LINE)]
        public static double3 MoveTowards(double3 from, double3 to, double distance)
        {
            double3 dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static double3 MoveTowards(double3 from, double3 to, double distance, out double excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            double3 dif = to - from;
            double difpowmag = LengthSqr(dif);
            if (difpowmag == 0d)
            {
                excess = distance;
                return to;
            }
            double difmag = Sqrt(difpowmag);
            excess = distance - difmag;
            if (excess > -double.Epsilon)
            {
                return to;
            }

            return new double3(from.x + dif.x / difmag * distance, from.y + dif.y / difmag * distance, from.z + dif.z / difmag * distance);
        }
        [IN(LINE)]
        public static double3 Remap(double3 oldStart, double3 oldEnd, double3 newStart, double3 newEnd, double3 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }


        [IN(LINE)]
        public static double3 LerpAngle(double3 start, double3 end, double t)
        {
            double3 angle = Repeat(end - start, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static double3 DeltaAngle(double3 current, double3 target)
        {
            double3 angle = Repeat(target - current, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return angle;
        }
        [IN(LINE)]
        public static double3 MoveTowardsAngle(double3 current, double3 target, double maxDelta)
        {
            double3 delta = DeltaAngle(current, target);
            if (0d - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region double State Checks
        [IN(LINE)] public static bool3 IsNormaldouble(double3 a) { return new bool3(double.IsNormal(a.x), double.IsNormal(a.y), double.IsNormal(a.z)); }
        [IN(LINE)] public static bool3 IsFinite(double3 a) { return new bool3(double.IsFinite(a.x), double.IsFinite(a.y), double.IsFinite(a.z)); }
        [IN(LINE)] public static bool3 IsNaN(double3 a) { return new bool3(double.IsNaN(a.x), double.IsNaN(a.y), double.IsNaN(a.z)); }
        [IN(LINE)] public static bool3 IsInfinity(double3 a) { return new bool3(double.IsInfinity(a.x), double.IsInfinity(a.y), double.IsInfinity(a.z)); }
        [IN(LINE)] public static bool3 IsNegativeInfinity(double3 a) { return new bool3(double.IsNegativeInfinity(a.x), double.IsNegativeInfinity(a.y), double.IsNegativeInfinity(a.z)); }
        [IN(LINE)] public static bool3 IsPositiveInfinity(double3 a) { return new bool3(double.IsPositiveInfinity(a.x), double.IsPositiveInfinity(a.y), double.IsPositiveInfinity(a.z)); }
        #endregion

        #region Color
        [IN(LINE)] public static double3 GammaToLinearSpace(double3 value) { const double Gamma = 2.2d; return Pow(value, Gamma); }
        [IN(LINE)] public static double3 LinearToGammaSpace(double3 value) { const double InverseGamma = 1.0d / 2.2d; return Pow(value, InverseGamma); }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool3 Approximately(double3 a, double3 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8d)); }
        [IN(LINE)] public static bool3 Approximately(double3 a, double3 b, double3 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Other
        [IN(LINE)] public static double Length(double3 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static double LengthSqr(double3 a) { return Dot(a, a); }
        [IN(LINE)] public static double Distance(double3 a, double3 b) { return Length(b - a); }
        [IN(LINE)] public static double DistanceSqr(double3 a, double3 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static double3 Normalize(double3 a) { return 1.0d / Sqrt(Dot(a, a)) * a; }

        [IN(LINE)] public static double Dot(double3 a, double3 b) { return a.x * b.x + a.y * b.y + a.z * b.z; }
        [IN(LINE)] public static double3 Project(double3 a, double3 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static double3 ProjectSafe(double3 a, double3 ontoB, double3 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, IsInfinity(proj)/*all*/);
        }
        [IN(LINE)] public static double3 Reflect(double3 v, double3 n) { return v - 2d * n * Dot(v, n); }

        [IN(LINE)] public static double3 Select(double3 falseValue, double3 trueValue, bool3 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static double3 Step(double3 threshold, double3 a) { return Select(0.0d, 1.0d, a >= threshold); }

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static double3 Degrees(double3 a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static double3 Radians(double3 a) { return a * Deg2Rad; }

        [IN(LINE)] public static double3 Cos(double3 a) { return new double3(Cos(a.x), Cos(a.y), Cos(a.z)); }
        [IN(LINE)] public static double3 Cosh(double3 a) { return new double3(Cosh(a.x), Cosh(a.y), Cosh(a.z)); }
        [IN(LINE)] public static double3 Acos(double3 a) { return new double3(Acos(a.x), Acos(a.y), Acos(a.z)); }
        [IN(LINE)] public static double3 Sin(double3 a) { return new double3(Sin(a.x), Sin(a.y), Sin(a.z)); }
        [IN(LINE)] public static double3 Sinh(double3 a) { return new double3(Sinh(a.x), Sinh(a.y), Sinh(a.z)); }
        [IN(LINE)] public static double3 Asin(double3 a) { return new double3(Asin(a.x), Asin(a.y), Asin(a.z)); }

        [IN(LINE)] public static double3 Atan(double3 a) { return new double3(Atan(a.x), Atan(a.y), Atan(a.z)); }
        [IN(LINE)] public static double3 Atan2(double3 a, double3 b) { return new double3(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z)); }

        [IN(LINE)] public static double3 Sqr(double3 a) { return a * a; }
        [IN(LINE)] public static double3 Pow(double3 a, double3 b) { return new double3(Pow(a.x, a.y), Pow(a.y, a.y), Pow(a.z, a.z)); }
        [IN(LINE)] public static double3 Exp(double3 pow) { return new double3(Exp(pow.x), Exp(pow.y), Exp(pow.z)); }
        [IN(LINE)] public static double3 Exp2(double3 pow) { return new double3(Exp2(pow.x), Exp2(pow.y), Exp2(pow.z)); }
        [IN(LINE)] public static double3 Exp10(double3 pow) { return new double3(Exp10(pow.x), Exp10(pow.y), Exp10(pow.z)); }
        [IN(LINE)] public static double3 Log(double3 f, double3 p) { return new double3(Log(f.x, p.x), Log(f.y, p.y), Log(f.z, p.z)); }
        [IN(LINE)] public static double3 Log(double3 f) { return new double3(Log(f.x), Log(f.y), Log(f.z)); }
        [IN(LINE)] public static double3 Log2(double3 f) { return new double3(Log2(f.x), Log2(f.y), Log2(f.z)); }
        [IN(LINE)] public static double3 Log10(double3 f) { return new double3(Log10(f.x), Log10(f.y), Log10(f.z)); }
        [IN(LINE)] public static double3 Sqrt(double3 a) { return new double3(Sqrt(a.x), Sqrt(a.y), Sqrt(a.z)); }

        [IN(LINE)] public static double3 Tan(double3 a) { return new double3(Tan(a.x), Tan(a.y), Tan(a.z)); }
        [IN(LINE)] public static double3 Tanh(double3 a) { return new double3(Tanh(a.x), Tanh(a.y), Tanh(a.z)); }

        [IN(LINE)] public static double3 Truncate(double3 a) { return new double3(Truncate(a.x), Truncate(a.y), Truncate(a.z)); }
        #endregion


        #region Hash
        [IN(LINE)]
        public static uint UHash(double3 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double3 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Specific
        [IN(LINE)] public static double3 Cross(double3 a, double3 b) { return (a * b.yzx - a.yzx * b).yzx; }
        #endregion
    }
}