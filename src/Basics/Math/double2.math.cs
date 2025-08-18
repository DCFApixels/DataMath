using System;
using System.ComponentModel;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        #region Length/Normalized
        public double Length { [IN(LINE)] get { return DM.Length(this); } }
        public double LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public double2 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // double2
    {
        #region Abs/Sign
        [IN(LINE)] public static double2 Abs(double2 a) { return new double2(Abs(a.x), Abs(a.y)); }
        [IN(LINE)] public static double2 Sign(double2 a) { return new double2(Sign(a.x), Sign(a.y)); }
        [IN(LINE)] public static int2 Sign2Int(double2 a) { return new int2(Sign2Int(a.x), Sign2Int(a.y)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static double2 Round(double2 a) { return new double2(Round(a.x), Round(a.y)); }
        [IN(LINE)] public static int2 Round2Int(double2 a) { return new int2(Round2Int(a.x), Round2Int(a.y)); }
        [IN(LINE)] public static double2 Floor(double2 a) { return new double2(Floor(a.x), Floor(a.y)); }
        [IN(LINE)] public static int2 Floor2Int(double2 a) { return new int2(Floor2Int(a.x), Floor2Int(a.y)); }
        [IN(LINE)] public static double2 Ceil(double2 a) { return new double2(Ceil(a.x), Ceil(a.y)); }
        [IN(LINE)] public static int2 Ceil2Int(double2 a) { return new int2(Ceil2Int(a.x), Ceil2Int(a.y)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Round2UInt(double2 a) { return new uint2(Round2UInt(a.x), Round2UInt(a.y)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Floor2UInt(double2 a) { return new uint2(Floor2UInt(a.x), Floor2UInt(a.y)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Ceil2UInt(double2 a) { return new uint2(Ceil2UInt(a.x), Ceil2UInt(a.y)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static double2 Clamp(double2 a, double2 min, double2 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double2 Clamp01(double2 a) { return Clamp(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double2 ClampMirror1(double2 a) { return Clamp(a, -1d, 1d); }

        [IN(LINE)] public static double2 Repeat(double2 a, double2 length) { return Clamp(a - Floor(a / length) * length, 0d, length); }
        [IN(LINE)] public static double2 Repeat(double2 a, double2 min, double2 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static double2 Repeat01(double2 a) { return Repeat(a, 1d); }
        [IN(LINE)] public static double2 RepeatMirror1(double2 a) { return Repeat(a, -1d, 1d); }

        [IN(LINE)] public static double2 PingPong(double2 a, double2 length) { return length - Abs(Repeat(a, length * 2d) - length); }
        [IN(LINE)] public static double2 PingPong(double2 a, double2 min, double2 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static double2 PingPong01(double2 a) { return PingPong(a, 0d, 1d); }
        [IN(LINE)] public static double2 PingPongMirror1(double2 a) { return PingPong(a, -1d, 1d); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static double2 SmoothStep(double2 from, double2 to, double2 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0d - (2.0d * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double2 SmoothStep01(double2 a) { return SmoothStep(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double2 SmoothStepMirror1(double2 a) { return SmoothStep(a, -1d, 1d); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(double2 a) { return a.x != default && a.y != default; }
        [IN(LINE)] public static bool Any(double2 a) { return a.x != default || a.y != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static double2 Max(double2 a, double2 b) { return new double2(Max(a.x, b.x), Max(a.y, b.y)); }
        [IN(LINE)] public static double2 AbsMax(double2 a, double2 b) { return new double2(AbsMax(a.x, b.x), AbsMax(a.y, b.y)); }
        [IN(LINE)] public static double2 Min(double2 a, double2 b) { return new double2(Min(a.x, b.x), Min(a.y, b.y)); }
        [IN(LINE)] public static double2 AbsMin(double2 a, double2 b) { return new double2(AbsMin(a.x, b.x), AbsMin(a.y, b.y)); }
        [IN(LINE)] public static double CMax(double2 a) { return CMax(a.x, a.y); }
        [IN(LINE)] public static double CAbsMax(double2 a) { return CAbsMax(a.x, a.y); }
        [IN(LINE)] public static double CMin(double2 a) { return CMin(a.x, a.y); }
        [IN(LINE)] public static double CAbsMin(double2 a) { return CAbsMin(a.x, a.y); }
        [IN(LINE)] public static double CSum(double2 a) { return a.x + a.y; }
        #endregion

        #region Lerp
        [IN(LINE)] public static double2 Lerp(double2 start, double2 end, double2 t) { return start + t * (end - start); }
        [IN(LINE)] public static double2 LerpClamp(double2 start, double2 end, double2 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static double2 LerpRepeat(double2 start, double2 end, double2 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static double2 UnLerp(double2 start, double2 end, double2 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static double2 UnLerpClamp(double2 start, double2 end, double2 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static double2 UnLerpRepeat(double2 start, double2 end, double2 a) { return Repeat01(UnLerp(start, end, a)); }


        [IN(LINE)]
        public static double2 MoveTowards(double2 from, double2 to, double distance)
        {
            double2 dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static double2 MoveTowards(double2 from, double2 to, double distance, out double excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            double2 dif = to - from;
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

            return new double2(from.x + dif.x / difmag * distance, from.y + dif.y / difmag * distance);
        }
        [IN(LINE)]
        public static double2 Remap(double2 oldStart, double2 oldEnd, double2 newStart, double2 newEnd, double2 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }


        [IN(LINE)]
        public static double2 LerpAngle(double2 start, double2 end, double t)
        {
            double2 angle = Repeat(end - start, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static double2 DeltaAngle(double2 current, double2 target)
        {
            double2 angle = Repeat(target - current, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return angle;
        }
        [IN(LINE)]
        public static double2 MoveTowardsAngle(double2 current, double2 target, double maxDelta)
        {
            double2 delta = DeltaAngle(current, target);
            if (0d - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region double State Checks
        [IN(LINE)] public static bool2 IsNormaldouble(double2 a) { return new bool2(double.IsNormal(a.x), double.IsNormal(a.y)); }
        [IN(LINE)] public static bool2 IsFinite(double2 a) { return new bool2(double.IsFinite(a.x), double.IsFinite(a.y)); }
        [IN(LINE)] public static bool2 IsNaN(double2 a) { return new bool2(double.IsNaN(a.x), double.IsNaN(a.y)); }
        [IN(LINE)] public static bool2 IsInfinity(double2 a) { return new bool2(double.IsInfinity(a.x), double.IsInfinity(a.y)); }
        [IN(LINE)] public static bool2 IsNegativeInfinity(double2 a) { return new bool2(double.IsNegativeInfinity(a.x), double.IsNegativeInfinity(a.y)); }
        [IN(LINE)] public static bool2 IsPositiveInfinity(double2 a) { return new bool2(double.IsPositiveInfinity(a.x), double.IsPositiveInfinity(a.y)); }
        #endregion

        #region Color
        [IN(LINE)] public static double2 GammaToLinearSpace(double2 value) { const double Gamma = 2.2d; return Pow(value, Gamma); }
        [IN(LINE)] public static double2 LinearToGammaSpace(double2 value) { const double InverseGamma = 1.0d / 2.2d; return Pow(value, InverseGamma); }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool2 Approximately(double2 a, double2 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8d)); }
        [IN(LINE)] public static bool2 Approximately(double2 a, double2 b, double2 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Other
        [IN(LINE)] public static double Length(double2 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static double LengthSqr(double2 a) { return Dot(a, a); }
        [IN(LINE)] public static double Distance(double2 a, double2 b) { return Length(b - a); }
        [IN(LINE)] public static double DistanceSqr(double2 a, double2 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static double2 Normalize(double2 a) { return 1.0d / Sqrt(Dot(a, a)) * a; }
        [IN(LINE)]
        public static double2 NormalizeSafe(double2 a, double2 defaultvalue = default)
        {
            var len = Dot(a, a);
            return Select(defaultvalue, 1f / Sqrt(len) * a, len > FloatMinNormal);
        }

        [IN(LINE)] public static double2 Project(double2 a, double2 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static double2 ProjectSafe(double2 a, double2 ontoB, double2 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, All(IsInfinity(proj)));
        }
        //[IN(LINE)] public static double2 Cross(double2 a, double2 b) { return (a * b.yzx - a.yzx * b).yzx; }
        [IN(LINE)] public static double2 Reflect(double2 v, double2 n) { return v - 2d * n * Dot(v, n); }

        [IN(LINE)] public static double2 Select(double2 falseValue, double2 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static double2 Step(double2 threshold, double2 a) { return Select(0.0d, 1.0d, a >= threshold); }

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static double2 Degrees(double2 a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static double2 Radians(double2 a) { return a * Deg2Rad; }

        [IN(LINE)] public static double2 Cos(double2 a) { return new double2(Cos(a.x), Cos(a.y)); }
        [IN(LINE)] public static double2 Cosh(double2 a) { return new double2(Cosh(a.x), Cosh(a.y)); }
        [IN(LINE)] public static double2 Acos(double2 a) { return new double2(Acos(a.x), Acos(a.y)); }
        [IN(LINE)] public static double2 Sin(double2 a) { return new double2(Sin(a.x), Sin(a.y)); }
        [IN(LINE)] public static double2 Sinh(double2 a) { return new double2(Sinh(a.x), Sinh(a.y)); }
        [IN(LINE)] public static double2 Asin(double2 a) { return new double2(Asin(a.x), Asin(a.y)); }

        [IN(LINE)] public static double2 Atan(double2 a) { return new double2(Atan(a.x), Atan(a.y)); }
        [IN(LINE)] public static double2 Atan2(double2 a, double2 b) { return new double2(Atan2(a.x, b.x), Atan2(a.y, b.y)); }

        [IN(LINE)] public static double Dot(double2 a, double2 b) { return a.x * b.x + a.y * b.y; }
        [IN(LINE)] public static double2 Sqr(double2 a) { return a * a; }
        [IN(LINE)] public static double2 Sqrt(double2 a) { return new double2(Sqrt(a.x), Sqrt(a.y)); }
        [IN(LINE)] public static double2 Pow(double2 a, double2 b) { return new double2(Pow(a.x, a.y), Pow(a.y, a.y)); }
        [IN(LINE)] public static double2 Exp(double2 pow) { return new double2(Exp(pow.x), Exp(pow.y)); }
        [IN(LINE)] public static double2 Exp2(double2 pow) { return new double2(Exp2(pow.x), Exp2(pow.y)); }
        [IN(LINE)] public static double2 Exp10(double2 pow) { return new double2(Exp10(pow.x), Exp10(pow.y)); }
        [IN(LINE)] public static double2 Log(double2 f, double2 p) { return new double2(Log(f.x, p.x), Log(f.y, p.y)); }
        [IN(LINE)] public static double2 Log(double2 f) { return new double2(Log(f.x), Log(f.y)); }
        [IN(LINE)] public static double2 Log2(double2 f) { return new double2(Log2(f.x), Log2(f.y)); }
        [IN(LINE)] public static double2 Log10(double2 f) { return new double2(Log10(f.x), Log10(f.y)); }

        [IN(LINE)] public static double2 Tan(double2 a) { return new double2(Tan(a.x), Tan(a.y)); }
        [IN(LINE)] public static double2 Tanh(double2 a) { return new double2(Tanh(a.x), Tanh(a.y)); }

        [IN(LINE)] public static double2 Truncate(double2 a) { return new double2(Truncate(a.x), Truncate(a.y)); }
        #endregion


        #region Hash
        [IN(LINE)]
        public static uint UHash(double2 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double2 v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}