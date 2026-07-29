#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
#endif
using System.Numerics;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct quat
    {
        public quat Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
    }

    public static partial class DM // quat
    {
        [IN(LINE)]
        public static quat LookRotation(float3 forward)
        {
            return LookRotation(forward, float3.up);
        }
        [IN(LINE)]
        public static quat LookRotation(float3 forward, float3 up)
        {
            float3 t = Normalize(Cross(up, forward));
            return new quat(t, Cross(forward, t), forward);
        }
        [IN(LINE)]
        public static quat LookRotationSafe(float3 forward)
        {
            return LookRotationSafe(forward, new float3(0f, 1f, 0f));
        }
        [IN(LINE)]
        public static quat LookRotationSafe(float3 forward, float3 up)
        {
            if (!All(IsFinite(forward)) || !All(IsFinite(up))) { return quat.Identity; }

            float forwardLengthSq = LengthSq(forward);
            if (forwardLengthSq <= FloatMinNormal) { return quat.Identity; }

            float3 f = forward * RSqrt(forwardLengthSq);
            float3 t = Cross(up, f);
            float tLengthSq = LengthSq(t);

            if (tLengthSq <= FloatMinNormal)
            {
                float3 fallbackUp = Abs(f.y) < 0.999f ? new float3(0f, 1f, 0f) : new float3(1f, 0f, 0f);
                t = Cross(fallbackUp, f);
                tLengthSq = LengthSq(t);
                if (tLengthSq <= FloatMinNormal) { return quat.Identity; }
            }

            t *= RSqrt(tLengthSq);
            return new quat(t, Cross(f, t), f);
        }


        [IN(LINE)]
        private static float4 ChangeSign(float4 a, float4 b)
        {
            const uint SING_MASK = 0x80000000;
            return AsFloat4(AsUInt4(a) ^ (AsUInt4(b) & SING_MASK));
        }
        [IN(LINE)]
        public static quat Lerp(quat a, quat b, float t)
        {
            return new quat(Normalize(a.value + t * (ChangeSign(b.value, Dot(a, b)) - a.value)));
        }
        [IN(LINE)] public static quat LerpClamp(quat a, quat b, float t) { return Lerp(a, b, Clamp01(t)); }
        [IN(LINE)] public static quat LerpPingPong(quat a, quat b, float t) {return Lerp(a, b, PingPong01(t)); }

        [IN(LINE)]
        public static quat Slerp(quat a, quat b, float t)
        {
            float dt = Dot(a, b);
            if (dt < 0.0f)
            {
                dt = -dt;
                b.value = -b.value;
            }

            if (dt < 0.9995f)
            {
                float angle = Acos(dt);
                float s = RSqrt(1.0f - dt * dt);    // 1.0f / Sin(angle)
                float w1 = Sin(angle * (1.0f - t)) * s;
                float w2 = Sin(angle * t) * s;
                return new quat(a.value * w1 + b.value * w2);
            }
            else
            {
                // if the angle is small, use linear interpolation
                return Lerp(a, b, t);
            }
        }
        [IN(LINE)] public static quat SlerpClamp(quat a, quat b, float t) { return Slerp(a, b, Clamp01(t)); }
        [IN(LINE)] public static quat SlerpPingPong(quat a, quat b, float t) { return Slerp(a, b, PingPong01(t)); }

        [IN(LINE)]
        public static float Dot(quat a, quat b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }
        [IN(LINE)] public static quat Normalize(quat q) { return new quat(Normalize(q.value)); }
        [IN(LINE)] public static quat NormalizeSafe(quat q) { return NormalizeSafe(q, quat.Identity); }
        [IN(LINE)]
        public static quat NormalizeSafe(quat q, quat defaultvalue)
        {
            float lengthSq = Dot(q, q);
            return lengthSq > FloatMinNormal ? new quat(q.value * RSqrt(lengthSq)) : defaultvalue;
        }
        [IN(LINE)] public static quat Conjugate(quat q) { return new quat(-q.x, -q.y, -q.z, q.w); }
        [IN(LINE)]
        public static quat Inverse(quat q)
        {
            float invLengthSq = 1f / Dot(q, q);
            return new quat(-q.x * invLengthSq, -q.y * invLengthSq, -q.z * invLengthSq, q.w * invLengthSq);
        }
        [IN(LINE)] public static bool IsNormalized(quat q) { return Approximately(Dot(q, q), 1f, FloatZeroTolerance); }
        [IN(LINE)] public static bool IsFinite(quat q) { return IsFinite(q.x) && IsFinite(q.y) && IsFinite(q.z) && IsFinite(q.w); }

        /// <summary>Returns the angle between rotations in degrees.</summary>
        [IN(LINE)]
        public static float Angle(quat a, quat b)
        {
            const float DOT_EQUALS_EPSILON = 0.999999f;
            float num = Min(Abs(Dot(a, b)), 1f);
            return (num > DOT_EQUALS_EPSILON) ? 0f : (Acos(num) * 2f * 57.29578f);
        }
        /// <summary>Rotates toward the target by at most maxDegreesDelta degrees.</summary>
        [IN(LINE)]
        public static quat RotateTowards(quat from, quat to, float maxDegreesDelta)
        {
            float num = Angle(from, to);
            if (num == 0f)
            {
                return to;
            }
            return Slerp(from, to, Min(1f, maxDegreesDelta / num));
        }

        /// <summary>Returns Euler angles in radians.</summary>
        [IN(LINE)]
        public static float3 ToEuler(quat q)
        {
            const float EPSILON = 1e-6f;
            const float CUT_OFF = (1f - 2f * EPSILON) * (1f - 2f * EPSILON);

            var qv = q.value;
            var d1 = qv * qv.wwww * 2f; //xw, yw, zw, ww
            var d2 = qv * qv.yzxw * 2f; //xy, yz, zx, ww
            var d3 = qv * qv;

            float y1 = d2.z - d1.y;
            if (y1 * y1 < CUT_OFF)
            {
                var x1 = d2.y + d1.x;
                var x2 = d3.z + d3.w - d3.y - d3.x;
                var z1 = d2.x + d1.z;
                var z2 = d3.x + d3.w - d3.y - d3.z;
                return new float3(Atan2(x1, x2), -Asin(y1), Atan2(z1, z2));
            }
            else //xzx
            {
                y1 = Clamp(y1, -1f, 1f);
                var abcd = new float4(d2.z, d1.y, d2.x, d1.z);
                var x1 = 2f * (abcd.x * abcd.w + abcd.y * abcd.z); //2 * (ad + bc)
                var x2 = CSum(abcd * abcd * new float4(-1f, 1f, -1f, 1f));
                return new float3(Atan2(x1, x2), -Asin(y1), 0f);
            }
        }

        /// <summary>Creates a rotation from Euler angles in radians.</summary>
        [IN(LINE)]
        public static quat FromEuler(float x, float y, float z) { return FromEuler(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians.</summary>
        [IN(LINE)]
        public static quat FromEuler(float3 xyz)
        {
            float3 halfXYZ = 0.5f * xyz;
            float3 s = Sin(halfXYZ);
            float3 c = Cos(halfXYZ);
            //return new quat(float4(s.x, s.y, s.z, c.x) * c.yxxy * c.zzyz + s.yxxy * s.zzyz * float4(s.x, s.y, s.z, s.x) * float4(-1.0f, 1.0f, -1.0f, 1.0f));
            return new quat(
                s.x * c.y * c.z - s.y * s.z * c.x,
                s.y * c.x * c.z + s.x * s.z * c.y,
                s.z * c.x * c.y - s.x * s.y * c.z,
                c.x * c.y * c.z + s.y * s.z * s.x);
        }
        /// <summary>Creates a rotation around axis by angleRad radians.</summary>
        [IN(LINE)]
        public static quat FromAxisAngle(float3 axis, float angleRad)
        {
            float lengthSq = LengthSq(axis);
            if (lengthSq <= FloatMinNormal) { return quat.Identity; }

            float halfAngle = angleRad * 0.5f;
            float s = Sin(halfAngle) * RSqrt(lengthSq);
            return new quat(axis.x * s, axis.y * s, axis.z * s, Cos(halfAngle));
        }
        /// <summary>Extracts axis and angleRad in radians.</summary>
        [IN(LINE)]
        public static void ToAxisAngle(quat q, out float3 axis, out float angleRad)
        {
            q = NormalizeSafe(q);
            if (q.w < 0f) { q.value = -q.value; }
            float w = Clamp(q.w, -1f, 1f);
            angleRad = Acos(w) * 2f;
            float axisLength = Sqrt(Max(0f, 1f - w * w));

            if (axisLength <= FloatZeroTolerance)
            {
                axis = new float3(1f, 0f, 0f);
                return;
            }

            axis = new float3(q.x, q.y, q.z) / axisLength;
        }
        [IN(LINE)]
        public static quat FromToRotation(float3 from, float3 to)
        {
            float fromLengthSq = LengthSq(from);
            float toLengthSq = LengthSq(to);
            if (fromLengthSq <= FloatMinNormal || toLengthSq <= FloatMinNormal) { return quat.Identity; }

            float3 f = from * RSqrt(fromLengthSq);
            float3 t = to * RSqrt(toLengthSq);
            float dot = ClampMirror1(Dot(f, t));

            if (dot > 1f - FloatZeroTolerance) { return quat.Identity; }
            if (dot < -1f + FloatZeroTolerance)
            {
                float3 axis = Cross(new float3(1f, 0f, 0f), f);
                if (LengthSq(axis) <= FloatMinNormal) { axis = Cross(new float3(0f, 1f, 0f), f); }
                return FromAxisAngle(axis, PI);
            }

            float3 cross = Cross(f, t);
            float s = Sqrt((1f + dot) * 2f);
            float invS = 1f / s;
            return Normalize(new quat(cross.x * invS, cross.y * invS, cross.z * invS, s * 0.5f));
        }

    }
}
