#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct quat
    {
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
        [IN(LINE)]
        public static quat LerpClamp(quat a, quat b, float t)
        {
            return Lerp(a, b, Clamp01(t));
        }

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
        [IN(LINE)]
        public static quat SlerpClamp(quat a, quat b, float t)
        {
            return Slerp(a, b, Clamp01(t));
        }

        [IN(LINE)]
        public static float Dot(quat a, quat b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        [IN(LINE)]
        public static float Angle(quat a, quat b)
        {
            const float DOT_EQUALS_EPSILON = 0.999999f;
            float num = Min(Abs(Dot(a, b)), 1f);
            return (num > DOT_EQUALS_EPSILON) ? 0f : (Acos(num) * 2f * 57.29578f);
        }
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

        [IN(LINE)]
        public static float3 ToEuler(quat q)
        {
            const float EPSILON = 1e-6f;
            const float CUT_OFF = (1f - 2f * EPSILON) * (1f - 2f * EPSILON);

            float4 qv = DMBasic.ToBasic(q);
            float4 d1 = qv * qv.wwww * new float4(2f); //xw, yw, zw, ww
            float4 d2 = qv * qv.yzxw * new float4(2f); //xy, yz, zx, ww
            float4 d3 = qv * qv;

            float y1 = d2.z - d1.y;
            if (y1 * y1 < CUT_OFF)
            {
                float x1 = d2.y + d1.x;
                float x2 = d3.z + d3.w - d3.y - d3.x;
                float z1 = d2.x + d1.z;
                float z2 = d3.x + d3.w - d3.y - d3.z;
                return new float3(Atan2(x1, x2), -Asin(y1), Atan2(z1, z2));
            }
            else
            {
                y1 = Clamp(y1, -1f, 1f);
                float4 abcd = new float4(d2.z, d1.y, d2.x, d1.z);
                float x1 = 2f * (abcd.x * abcd.w + abcd.y * abcd.z); //2 * (ad + bc)
                float x2 = CSum(abcd * abcd * new float4(-1f, 1f, -1f, 1f));
                return new float3(Atan2(x1, x2), -Asin(y1), 0f);
            }
        }

        [IN(LINE)]
        public static quat FromEuler(float x, float y, float z) { return FromEuler(new float3(x, y, z)); }
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

    }
}
