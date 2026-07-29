#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
#endif
using DCFApixels.DataMath.Internal;
using System;
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
            const float SLERP_EPSILON = 1e-6f;

            float cosOmega = Dot(a, b);
            float sign = 1f;
            if (cosOmega < 0f)
            {
                cosOmega = -cosOmega;
                sign = -1f;
            }

            if (cosOmega > 1f - SLERP_EPSILON)
            {
                return new quat(Normalize(a.value * (1f - t) + b.value * (t * sign)));
            }

            float omega = Acos(cosOmega);
            float invSinOmega = RSqrt(1f - cosOmega * cosOmega);
            float weightA = Sin((1f - t) * omega) * invSinOmega;
            float weightB = Sin(t * omega) * invSinOmega * sign;
            return new quat(a.value * weightA + b.value * weightB);
        }
        [IN(LINE)] public static quat SlerpClamp(quat a, quat b, float t) { return Slerp(a, b, Clamp01(t)); }
        [IN(LINE)] public static quat SlerpPingPong(quat a, quat b, float t) { return Slerp(a, b, PingPong01(t)); }

        [IN(LINE)] public static float Dot(quat a, quat b) { return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w; }
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

        private const float EulerThreshold = (1f - 2f * 1e-4f) * (1f - 2f * 1e-4f);

        [IN(LINE)]
        private static void GetEulerProducts(quat q, out float4 vw2, out float4 vyzx2, out float4 vv)
        {
            float4 v = q.value;
            vw2 = v * v.wwww * 2f; // xw, yw, zw, ww
            vyzx2 = v * v.yzxw * 2f; // xy, yz, zx, ww
            vv = v * v; // xx, yy, zz, ww
        }

        /// <summary>Returns Euler angles in radians using ZXY order.</summary>
        [IN(LINE)]
        public static float3 ToEuler(quat q) { return ToEulerZXY(q); }
        /// <summary>Returns Euler angles in radians using the specified axis order.</summary>
        [IN(LINE)]
        public static float3 ToEuler(quat q, AxisOrder order)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            switch (order)
            {
                case AxisOrder.XYZ: return ToEulerXYZCore(vw2, vyzx2, vv);
                case AxisOrder.XZY: return ToEulerXZYCore(vw2, vyzx2, vv);
                case AxisOrder.YXZ: return ToEulerYXZCore(vw2, vyzx2, vv);
                case AxisOrder.YZX: return ToEulerYZXCore(vw2, vyzx2, vv);
                case AxisOrder.ZXY: return ToEulerZXYCore(vw2, vyzx2, vv);
                case AxisOrder.ZYX: return ToEulerZYXCore(vw2, vyzx2, vv);
                default:
                    Throw.ArgumentOutOfRange(nameof(order));
                    return default;
            }
        }

        /// <summary>Returns Euler angles in radians using XYZ order.</summary>
        [IN(LINE)]
        public static float3 ToEulerXYZ(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerXYZCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerXYZCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float m20 = vyzx2.z - vw2.y;
            float m11 = vv.y + vv.w - vv.x - vv.z;
            float m12 = vyzx2.y - vw2.x;

            if (m20 * m20 < EulerThreshold)
            {
                return new float3(
                    Atan2(vyzx2.y + vw2.x, vv.z + vv.w - vv.x - vv.y),
                    -Asin(m20),
                    Atan2(vyzx2.x + vw2.z, vv.x + vv.w - vv.y - vv.z));
            }

            return new float3(Atan2(-m12, m11), -Asin(Clamp(m20, -1f, 1f)), 0f);
        }

        /// <summary>Returns Euler angles in radians using XZY order.</summary>
        [IN(LINE)]
        public static float3 ToEulerXZY(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerXZYCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerXZYCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float m10 = vyzx2.x + vw2.z;
            float m20 = vyzx2.z - vw2.y;
            float m21 = vyzx2.y + vw2.x;
            float m22 = vv.z + vv.w - vv.x - vv.y;

            if (m10 * m10 < EulerThreshold)
            {
                return new float3(
                    Atan2(vw2.x - vyzx2.y, vv.y + vv.w - vv.x - vv.z),
                    Atan2(-m20, vv.x + vv.w - vv.y - vv.z),
                    Asin(m10));
            }

            return new float3(Atan2(m21, m22), 0f, Asin(Clamp(m10, -1f, 1f)));
        }

        /// <summary>Returns Euler angles in radians using YXZ order.</summary>
        [IN(LINE)]
        public static float3 ToEulerYXZ(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerYXZCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerYXZCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float m01 = vyzx2.x - vw2.z;
            float m02 = vyzx2.z + vw2.y;
            float m20 = vyzx2.z - vw2.y;
            float m21 = vyzx2.y + vw2.x;

            if (m21 * m21 < EulerThreshold)
            {
                return new float3(
                    Asin(m21),
                    Atan2(-m20, vv.z + vv.w - vv.x - vv.y),
                    Atan2(-m01, vv.y + vv.w - vv.x - vv.z));
            }

            return new float3(Asin(Clamp(m21, -1f, 1f)), Atan2(m02, vv.x + vv.w - vv.y - vv.z), 0f);
        }

        /// <summary>Returns Euler angles in radians using YZX order.</summary>
        [IN(LINE)]
        public static float3 ToEulerYZX(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerYZXCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerYZXCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float m01 = vyzx2.x - vw2.z;
            float m02 = vyzx2.z + vw2.y;
            float m20 = vyzx2.z - vw2.y;
            float m21 = vyzx2.y + vw2.x;

            if (m01 * m01 < EulerThreshold)
            {
                return new float3(
                    Atan2(m21, vv.y + vv.w - vv.x - vv.z),
                    Atan2(m02, vv.x + vv.w - vv.y - vv.z),
                    -Asin(m01));
            }

            return new float3(0f, Atan2(-m20, vv.z + vv.w - vv.x - vv.y), -Asin(Clamp(m01, -1f, 1f)));
        }

        /// <summary>Returns Euler angles in radians using ZXY order.</summary>
        [IN(LINE)]
        public static float3 ToEulerZXY(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerZXYCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerZXYCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float xw2 = vw2.x;
            float yw2 = vw2.y;
            float zw2 = vw2.z;
            float xy2 = vyzx2.x;
            float yz2 = vyzx2.y;
            float zx2 = vyzx2.z;
            float m12 = yz2 - xw2;

            if (m12 * m12 < EulerThreshold)
            {
                return new float3(
                    -Asin(m12),
                    Atan2(zx2 + yw2, vv.z + vv.w - vv.x - vv.y),
                    Atan2(xy2 + zw2, vv.y + vv.w - vv.x - vv.z));
            }

            float4 abcd = new float4(zx2, yw2, yz2, xw2);
            return new float3(
                -Asin(Clamp(m12, -1f, 1f)),
                0f,
                Atan2(2f * (abcd.x * abcd.w + abcd.y * abcd.z), CSum(abcd * abcd * new float4(-1f, 1f, -1f, 1f))));
        }

        /// <summary>Returns Euler angles in radians using ZYX order.</summary>
        [IN(LINE)]
        public static float3 ToEulerZYX(quat q)
        {
            GetEulerProducts(q, out float4 vw2, out float4 vyzx2, out float4 vv);
            return ToEulerZYXCore(vw2, vyzx2, vv);
        }
        [IN(LINE)]
        private static float3 ToEulerZYXCore(float4 vw2, float4 vyzx2, float4 vv)
        {
            float m01 = vyzx2.x - vw2.z;
            float m02 = vyzx2.z + vw2.y;
            float m10 = vyzx2.x + vw2.z;
            float m12 = vyzx2.y - vw2.x;

            if (m02 * m02 < EulerThreshold)
            {
                return new float3(
                    Atan2(-m12, vv.z + vv.w - vv.x - vv.y),
                    Asin(m02),
                    Atan2(-m01, vv.x + vv.w - vv.y - vv.z));
            }

            return new float3(0f, Asin(Clamp(m02, -1f, 1f)), Atan2(m10, vv.y + vv.w - vv.x - vv.z));
        }

        /// <summary>Creates a rotation from Euler angles in radians using ZXY order.</summary>
        [IN(LINE)]
        public static quat FromEuler(float x, float y, float z) { return FromEulerZXY(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using ZXY order.</summary>
        [IN(LINE)]
        public static quat FromEuler(float3 xyz) { return FromEulerZXY(xyz); }
        /// <summary>Creates a rotation from Euler angles in radians using the specified axis order.</summary>
        [IN(LINE)]
        public static quat FromEuler(float x, float y, float z, AxisOrder order) { return FromEuler(new float3(x, y, z), order); }
        /// <summary>Creates a rotation from Euler angles in radians using the specified axis order.</summary>
        [IN(LINE)]
        public static quat FromEuler(float3 xyz, AxisOrder order)
        {
            switch (order)
            {
                case AxisOrder.XYZ: return FromEulerXYZ(xyz);
                case AxisOrder.XZY: return FromEulerXZY(xyz);
                case AxisOrder.YXZ: return FromEulerYXZ(xyz);
                case AxisOrder.YZX: return FromEulerYZX(xyz);
                case AxisOrder.ZXY: return FromEulerZXY(xyz);
                case AxisOrder.ZYX: return FromEulerZYX(xyz);
                default:
                    Throw.ArgumentOutOfRange(nameof(order));
                    return quat.Identity;
            }
        }

        /// <summary>Creates a rotation from Euler angles in radians using XYZ order.</summary>
        [IN(LINE)] public static quat FromEulerXYZ(float x, float y, float z) { return FromEulerXYZ(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using XYZ order.</summary>
        [IN(LINE)]
        public static quat FromEulerXYZ(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz - cxsysz,
                cxsycz + sxcysz,
                cxcysz - sxsycz,
                cxcycz + sxsysz);
        }
        /// <summary>Creates a rotation from Euler angles in radians using XZY order.</summary>
        [IN(LINE)] public static quat FromEulerXZY(float x, float y, float z) { return FromEulerXZY(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using XZY order.</summary>
        [IN(LINE)]
        public static quat FromEulerXZY(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz + cxsysz,
                cxsycz + sxcysz,
                cxcysz - sxsycz,
                cxcycz - sxsysz);
        }
        /// <summary>Creates a rotation from Euler angles in radians using YXZ order.</summary>
        [IN(LINE)] public static quat FromEulerYXZ(float x, float y, float z) { return FromEulerYXZ(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using YXZ order.</summary>
        [IN(LINE)]
        public static quat FromEulerYXZ(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz - cxsysz,
                cxsycz + sxcysz,
                cxcysz + sxsycz,
                cxcycz - sxsysz);
        }
        /// <summary>Creates a rotation from Euler angles in radians using YZX order.</summary>
        [IN(LINE)] public static quat FromEulerYZX(float x, float y, float z) { return FromEulerYZX(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using YZX order.</summary>
        [IN(LINE)]
        public static quat FromEulerYZX(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz - cxsysz,
                cxsycz - sxcysz,
                cxcysz + sxsycz,
                cxcycz + sxsysz);
        }
        /// <summary>Creates a rotation from Euler angles in radians using ZXY order.</summary>
        [IN(LINE)] public static quat FromEulerZXY(float x, float y, float z) { return FromEulerZXY(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using ZXY order.</summary>
        [IN(LINE)]
        public static quat FromEulerZXY(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz + cxsysz,
                cxsycz - sxcysz,
                cxcysz - sxsycz,
                cxcycz + sxsysz);
        }
        /// <summary>Creates a rotation from Euler angles in radians using ZYX order.</summary>
        [IN(LINE)] public static quat FromEulerZYX(float x, float y, float z) { return FromEulerZYX(new float3(x, y, z)); }
        /// <summary>Creates a rotation from Euler angles in radians using ZYX order.</summary>
        [IN(LINE)]
        public static quat FromEulerZYX(float3 xyz)
        {
            float3 half = xyz * 0.5f;
            float3 s = Sin(half);
            float3 c = Cos(half);

            float sxcycz = s.x * c.y * c.z;
            float cxsysz = c.x * s.y * s.z;
            float cxsycz = c.x * s.y * c.z;
            float sxcysz = s.x * c.y * s.z;
            float cxcysz = c.x * c.y * s.z;
            float sxsycz = s.x * s.y * c.z;
            float cxcycz = c.x * c.y * c.z;
            float sxsysz = s.x * s.y * s.z;

            return new quat(
                sxcycz + cxsysz,
                cxsycz - sxcysz,
                cxcysz + sxsycz,
                cxcycz - sxsysz);
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
