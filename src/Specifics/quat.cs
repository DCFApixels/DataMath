using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using static DCFApixels.DataMath.math;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial struct quat : IVector4<float>, IEnumerableVector<float, quat>
    {
        public const int LENGTH = 4;

        public float4 value;



        [IN(LINE)]
        public quat(float x, float y, float z, float w)
        {
            value = new float4(x, y, z, w);
        }
        [IN(LINE)]
        public quat(float4 a)
        {
            value = new float4(a.x, a.y, a.z, a.w);
        }

        #region IVectorN
        public float x { [IN(LINE)] get => value.x; [IN(LINE)] set => this.value.x = value; }
        public float y { [IN(LINE)] get => value.y; [IN(LINE)] set => this.value.y = value; }
        public float z { [IN(LINE)] get => value.z; [IN(LINE)] set => this.value.z = value; }
        public float w { [IN(LINE)] get => value.w; [IN(LINE)] set => this.value.w = value; }
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (quat* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &this.value.x) { array[index] = value; }
            }
        }
        #endregion

        #region IVectorEnumerable
        public VectorEnumerator<float, quat> GetEnumerator() => new VectorEnumerator<float, quat>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public float x;
            public float y;
            public float z;
            public float w;
            public DebuggerProxy(quat v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }
        #endregion


        [IN(LINE)] public static quat operator -(quat a) => new quat(-a.x, -a.y, -a.z, -a.w);
        [IN(LINE)] public static quat operator +(quat a, quat b) => new quat(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        [IN(LINE)] public static quat operator -(quat a, quat b) => new quat(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

        public static quat operator *(quat a, quat b)
        {
            float q1x = a.x;
            float q1y = a.y;
            float q1z = a.z;
            float q1w = a.w;

            float q2x = b.x;
            float q2y = b.y;
            float q2z = b.z;
            float q2w = b.w;

            // cross(av, bv)
            float cx = q1y * q2z - q1z * q2y;
            float cy = q1z * q2x - q1x * q2z;
            float cz = q1x * q2y - q1y * q2x;

            float dot = q1x * q2x + q1y * q2y + q1z * q2z;

            return new quat(
                q1x * q2w + q2x * q1w + cx,
                q1y * q2w + q2y * q1w + cy,
                q1z * q2w + q2z * q1w + cz,
                q1w * q2w - dot );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator *(quat q, float3 v)
        {
            float3 t = 2 * Cross(new float3(q.x, q.y, q.z), v);
            return v + q.w * t + Cross(new float3(q.x, q.y, q.z), t);
        }

        public static quat operator /(quat a, quat b)
        {
            float q1x = a.x;
            float q1y = a.y;
            float q1z = a.z;
            float q1w = a.w;

            //-------------------------------------
            // Inverse part.
            float ls = b.x * b.x + b.y * b.y +
                       b.z * b.z + b.w * b.w;
            float invNorm = 1.0f / ls;

            float q2x = -b.x * invNorm;
            float q2y = -b.y * invNorm;
            float q2z = -b.z * invNorm;
            float q2w = b.w * invNorm;

            //-------------------------------------
            // Multiply part.

            // cross(av, bv)
            float cx = q1y * q2z - q1z * q2y;
            float cy = q1z * q2x - q1x * q2z;
            float cz = q1x * q2y - q1y * q2x;

            float dot = q1x * q2x + q1y * q2y + q1z * q2z;

            return new quat(
                q1x * q2w + q2x * q1w + cx,
                q1y * q2w + q2y * q1w + cy,
                q1z * q2w + q2z * q1w + cz,
                q1w * q2w - dot);
        }

        //[IN(LINE)] public static quat operator *(quat a, float b) => new quat(a.x * b, a.y * b, a.z * b, a.w * b);
    }

    public partial class math
    {

        private static float4 ChangeSign(float4 a, float4 b)
        {
            const uint SING_MASK = 0x80000000;
            return asfloat4(asuint4(a) ^ (asuint4(b) & SING_MASK));
        }
        [IN(LINE)]
        public static quat Lerp(quat a, quat b, float t)
        {
            return new quat(
                Normalize(a.value + t * (ChangeSign(b.value, Dot(a, b)) - a.value))
                );
        }

        [IN(LINE)]
        public static quat Slerp(quat a, quat b, float t)
        {
            return SlerpUnclamped(a, b, Clamp01(t));
        }
        [IN(LINE)]
        public static quat SlerpUnclamped(quat a, quat b, float t)
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
                float s = 1f / Sqrt(1.0f - dt * dt);    // 1.0f / Sin(angle)
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
            return SlerpUnclamped(from, to, Min(1f, maxDegreesDelta / num));
        }

        [IN(LINE)]
        public static float3 ToEuler(quat q)
        {
            const float EPSILON = 1e-6f;
            const float CUT_OFF = (1f - 2f * EPSILON) * (1f - 2f * EPSILON);

            float4 qv = Float4(q);
            float4 d1 = qv * qv.wwww * Float4(2f); //xw, yw, zw, ww
            float4 d2 = qv * qv.yzxw * Float4(2f); //xy, yz, zx, ww
            float4 d3 = qv * qv;

            float y1 = d2.z - d1.y;
            if (y1 * y1 < CUT_OFF)
            {
                float x1 = d2.y + d1.x;
                float x2 = d3.z + d3.w - d3.y - d3.x;
                float z1 = d2.x + d1.z;
                float z2 = d3.x + d3.w - d3.y - d3.z;
                return Float3(Atan2(x1, x2), -Asin(y1), Atan2(z1, z2));
            }
            else
            {
                y1 = Clamp(y1, -1f, 1f);
                float4 abcd = Float4(d2.z, d1.y, d2.x, d1.z);
                float x1 = 2f * (abcd.x * abcd.w + abcd.y * abcd.z); //2 * (ad + bc)
                float x2 = CSum(abcd * abcd * Float4(-1f, 1f, -1f, 1f));
                return Float3(Atan2(x1, x2), -Asin(y1), 0f);
            }
        }

        [IN(LINE)]
        public static quat FromEuler(float x, float y, float z) => FromEuler(Float3(x, y, z));
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
