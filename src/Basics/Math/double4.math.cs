using DCFApixels.DataMath.Internal;
using System;
using System.ComponentModel;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {
        #region Length/Normalized
        public double Length { [IN(LINE)] get { return DM.Length(this); } }
        public double LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public double4 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // double4
    {
        #region Abs/Sign
        [IN(LINE)] public static double4 Abs(double4 a) { return new double4(Abs(a.x), Abs(a.y), Abs(a.z), Abs(a.w)); }
        [IN(LINE)] public static double4 Sign(double4 a) { return new double4(Sign(a.x), Sign(a.y), Sign(a.z), Sign(a.w)); }
        [IN(LINE)] public static int4 Sign2Int(double4 a) { return new int4(Sign2Int(a.x), Sign2Int(a.y), Sign2Int(a.z), Sign2Int(a.w)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static double4 Round(double4 a) { return new double4(Round(a.x), Round(a.y), Round(a.z), Round(a.w)); }
        [IN(LINE)] public static int4 Round2Int(double4 a) { return new int4(Round2Int(a.x), Round2Int(a.y), Round2Int(a.z), Round2Int(a.w)); }
        [IN(LINE)] public static double4 Floor(double4 a) { return new double4(Floor(a.x), Floor(a.y), Floor(a.z), Floor(a.w)); }
        [IN(LINE)] public static int4 Floor2Int(double4 a) { return new int4(Floor2Int(a.x), Floor2Int(a.y), Floor2Int(a.z), Floor2Int(a.w)); }
        [IN(LINE)] public static double4 Ceil(double4 a) { return new double4(Ceil(a.x), Ceil(a.y), Ceil(a.z), Ceil(a.w)); }
        [IN(LINE)] public static int4 Ceil2Int(double4 a) { return new int4(Ceil2Int(a.x), Ceil2Int(a.y), Ceil2Int(a.z), Ceil2Int(a.w)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Round2UInt(double4 a) { return new int4(Round2UInt(a.x), Round2UInt(a.y), Round2UInt(a.z), Round2UInt(a.w)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Floor2UInt(double4 a) { return new int4(Floor2UInt(a.x), Floor2UInt(a.y), Floor2UInt(a.z), Floor2UInt(a.w)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Ceil2UInt(double4 a) { return new int4(Ceil2UInt(a.x), Ceil2UInt(a.y), Ceil2UInt(a.z), Ceil2UInt(a.w)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static double4 Clamp(double4 a, double4 min, double4 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double4 Clamp01(double4 a) { return Clamp(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double4 ClampMirror1(double4 a) { return Clamp(a, -1d, 1d); }

        [IN(LINE)] public static double4 Repeat(double4 a, double4 length) { return Clamp(a - Floor(a / length) * length, 0d, length); }
        [IN(LINE)] public static double4 Repeat(double4 a, double4 min, double4 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static double4 Repeat01(double4 a) { return Repeat(a, 1d); }
        [IN(LINE)] public static double4 RepeatMirror1(double4 a) { return Repeat(a, -1d, 1d); }

        [IN(LINE)] public static double4 PingPong(double4 a, double4 length) { return length - Abs(Repeat(a, length * 2d) - length); }
        [IN(LINE)] public static double4 PingPong(double4 a, double4 min, double4 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static double4 PingPong01(double4 a) { return PingPong(a, 0d, 1d); }
        [IN(LINE)] public static double4 PingPongMirror1(double4 a) { return PingPong(a, -1d, 1d); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static double4 SmoothStep(double4 from, double4 to, double4 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0d - (2.0d * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double4 SmoothStep01(double4 a) { return SmoothStep(a, 0d, 1d); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double4 SmoothStepMirror1(double4 a) { return SmoothStep(a, -1d, 1d); }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static double4 Max(double4 a, double4 b) { return new double4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w)); }
        [IN(LINE)] public static double4 AbsMax(double4 a, double4 b) { return new double4(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z), AbsMax(a.w, b.w)); }
        [IN(LINE)] public static double4 Min(double4 a, double4 b) { return new double4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w)); }
        [IN(LINE)] public static double4 AbsMin(double4 a, double4 b) { return new double4(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z), AbsMin(a.w, b.w)); }
        [IN(LINE)] public static double CMax(double4 a) { return CMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static double CAbsMax(double4 a) { return CAbsMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static double CMin(double4 a) { return CMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static double CAbsMin(double4 a) { return CAbsMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static double CSum(double4 a) { return a.x + a.y + a.z + a.w; }
        #endregion

        #region Lerp
        [IN(LINE)] public static double4 Lerp(double4 start, double4 end, double4 t) { return start + t * (end - start); }
        [IN(LINE)] public static double4 LerpClamp(double4 start, double4 end, double4 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static double4 LerpRepeat(double4 start, double4 end, double4 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static double4 UnLerp(double4 start, double4 end, double4 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static double4 UnLerpClamp(double4 start, double4 end, double4 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static double4 UnLerpRepeat(double4 start, double4 end, double4 a) { return Repeat01(UnLerp(start, end, a)); }


        [IN(LINE)]
        public static double4 MoveTowards(double4 from, double4 to, double distance)
        {
            double4 dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static double4 MoveTowards(double4 from, double4 to, double distance, out double excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            double4 dif = to - from;
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

            return new double4(from.x + dif.x / difmag * distance, from.y + dif.y / difmag * distance, from.z + dif.z / difmag * distance, from.w + dif.w / difmag * distance);
        }
        [IN(LINE)]
        public static double4 Remap(double4 oldStart, double4 oldEnd, double4 newStart, double4 newEnd, double4 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }


        [IN(LINE)]
        public static double4 LerpAngle(double4 start, double4 end, double t)
        {
            double4 angle = Repeat(end - start, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static double4 DeltaAngle(double4 current, double4 target)
        {
            double4 angle = Repeat(target - current, 360d);
            if (angle > 180d) { angle -= 360d; }
            //double angle = Repeat(end - start, -180d, 180d);
            return angle;
        }
        [IN(LINE)]
        public static double4 MoveTowardsAngle(double4 current, double4 target, double maxDelta)
        {
            double4 delta = DeltaAngle(current, target);
            if (0d - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region double State Checks
        [IN(LINE)] public static bool4 IsNormaldouble(double4 a) { return new bool4(double.IsNormal(a.x), double.IsNormal(a.y), double.IsNormal(a.z), double.IsNormal(a.w)); }
        [IN(LINE)] public static bool4 IsFinite(double4 a) { return new bool4(double.IsFinite(a.x), double.IsFinite(a.y), double.IsFinite(a.z), double.IsFinite(a.w)); }
        [IN(LINE)] public static bool4 IsNaN(double4 a) { return new bool4(double.IsNaN(a.x), double.IsNaN(a.y), double.IsNaN(a.z), double.IsNaN(a.w)); }
        [IN(LINE)] public static bool4 IsInfinity(double4 a) { return new bool4(double.IsInfinity(a.x), double.IsInfinity(a.y), double.IsInfinity(a.z), double.IsInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsNegativeInfinity(double4 a) { return new bool4(double.IsNegativeInfinity(a.x), double.IsNegativeInfinity(a.y), double.IsNegativeInfinity(a.z), double.IsNegativeInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsPositiveInfinity(double4 a) { return new bool4(double.IsPositiveInfinity(a.x), double.IsPositiveInfinity(a.y), double.IsPositiveInfinity(a.z), double.IsPositiveInfinity(a.w)); }
        #endregion

        #region Color
        [IN(LINE)] public static double4 GammaToLinearSpace(double4 value) { const double Gamma = 2.2d; return Pow(value, Gamma); }
        [IN(LINE)] public static double4 LinearToGammaSpace(double4 value) { const double InverseGamma = 1.0d / 2.2d; return Pow(value, InverseGamma); }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool4 Approximately(double4 a, double4 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8d)); }
        [IN(LINE)] public static bool4 Approximately(double4 a, double4 b, double4 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Other
        [IN(LINE)] public static double Length(double4 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static double LengthSqr(double4 a) { return Dot(a, a); }
        [IN(LINE)] public static double Distance(double4 a, double4 b) { return Length(b - a); }
        [IN(LINE)] public static double DistanceSqr(double4 a, double4 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static double4 Normalize(double4 a) { return 1d / Sqrt(Dot(a, a)) * a; }

        [IN(LINE)] public static double Dot(double4 a, double4 b) { return a.x * b.x + a.y * b.y + a.z * b.z; }
        [IN(LINE)] public static double4 Project(double4 a, double4 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static double4 ProjectSafe(double4 a, double4 ontoB, double4 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, IsInfinity(proj)/*all*/);
        }
        [IN(LINE)] public static double4 Reflect(double4 v, double4 n) { return v - 2d * n * Dot(v, n); }

        [IN(LINE)] public static double4 Select(double4 falseValue, double4 trueValue, bool4 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static double4 Step(double4 threshold, double4 a) { return Select(0.0d, 1.0d, a >= threshold); }

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static double4 Degrees(double4 a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static double4 Radians(double4 a) { return a * Deg2Rad; }

        [IN(LINE)] public static double4 Cos(double4 a) { return new double4(Cos(a.x), Cos(a.y), Cos(a.z), Cos(a.w)); }
        [IN(LINE)] public static double4 Cosh(double4 a) { return new double4(Cosh(a.x), Cosh(a.y), Cosh(a.z), Cosh(a.w)); }
        [IN(LINE)] public static double4 Acos(double4 a) { return new double4(Acos(a.x), Acos(a.y), Acos(a.z), Acos(a.w)); }
        [IN(LINE)] public static double4 Sin(double4 a) { return new double4(Sin(a.x), Sin(a.y), Sin(a.z), Sin(a.w)); }
        [IN(LINE)] public static double4 Sinh(double4 a) { return new double4(Sinh(a.x), Sinh(a.y), Sinh(a.z), Sinh(a.w)); }
        [IN(LINE)] public static double4 Asin(double4 a) { return new double4(Asin(a.x), Asin(a.y), Asin(a.z), Asin(a.w)); }

        [IN(LINE)] public static double4 Atan(double4 a) { return new double4(Atan(a.x), Atan(a.y), Atan(a.z), Atan(a.w)); }
        [IN(LINE)] public static double4 Atan2(double4 a, double4 b) { return new double4(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z), Atan2(a.w, b.w)); }

        [IN(LINE)] public static double4 Sqr(double4 a) { return a * a; }
        [IN(LINE)] public static double4 Pow(double4 a, double4 b) { return new double4(Pow(a.x, a.y), Pow(a.y, a.y), Pow(a.z, a.z), Pow(a.w, a.w)); }
        [IN(LINE)] public static double4 Exp(double4 pow) { return new double4(Exp(pow.x), Exp(pow.y), Exp(pow.z), Exp(pow.z)); }
        [IN(LINE)] public static double4 Exp2(double4 pow) { return new double4(Exp2(pow.x), Exp2(pow.y), Exp2(pow.z), Exp2(pow.z)); }
        [IN(LINE)] public static double4 Exp10(double4 pow) { return new double4(Exp10(pow.x), Exp10(pow.y), Exp10(pow.z), Exp10(pow.z)); }
        [IN(LINE)] public static double4 Log(double4 f, double4 p) { return new double4(Log(f.x, p.x), Log(f.y, p.y), Log(f.z, p.z), Log(f.w, p.w)); }
        [IN(LINE)] public static double4 Log(double4 f) { return new double4(Log(f.x), Log(f.y), Log(f.z), Log(f.z)); }
        [IN(LINE)] public static double4 Log2(double4 f) { return new double4(Log2(f.x), Log2(f.y), Log2(f.z), Log2(f.z)); }
        [IN(LINE)] public static double4 Log10(double4 f) { return new double4(Log10(f.x), Log10(f.y), Log10(f.z), Log10(f.z)); }
        [IN(LINE)] public static double4 Sqrt(double4 a) { return new double4(Sqrt(a.x), Sqrt(a.y), Sqrt(a.z), Sqrt(a.w)); }

        [IN(LINE)] public static double4 Tan(double4 a) { return new double4(Tan(a.x), Tan(a.y), Tan(a.z), Tan(a.w)); }
        [IN(LINE)] public static double4 Tanh(double4 a) { return new double4(Tanh(a.x), Tanh(a.y), Tanh(a.z), Tanh(a.w)); }

        [IN(LINE)] public static double4 Truncate(double4 a) { return new double4(Truncate(a.x), Truncate(a.y), Truncate(a.z), Truncate(a.w)); }
        #endregion


        #region Hash
        [IN(LINE)]
        public static uint UHash(double4 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double4 v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}