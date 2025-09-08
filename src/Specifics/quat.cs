#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using DCFApixels.DataMath.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public unsafe partial struct quat :
        IEquatable<quat>,
        IFormattable,
        IVector4Impl<float>, 
        IEnumerableVector<float, quat>
    {
        #region Consts
        public const int Count = 4;
        public static readonly quat Identity = new quat(0f, 0f, 0f, 1f);
        #endregion

        public float4 value;

        #region Constructors
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
        public quat(float3 c0, float3 c1, float3 c2)
        {
            float3 u = c0;
            float3 v = c1;
            float3 w = c2;

            uint u_sign = (DM.AsUInt(u.x) & 0x80000000);
            float t = v.y + DM.AsFloat(DM.AsUInt(w.z) ^ u_sign);
            uint4 u_mask = new uint4((int)u_sign >> 31);
            uint4 t_mask = new uint4(DM.AsInt(t) >> 31);

            float tr = 1.0f + DM.Abs(u.x);

            uint4 sign_flips = new uint4(
                0x00000000, 0x80000000, 0x80000000, 0x80000000) ^
                (u_mask & new uint4(0x00000000, 0x80000000, 0x00000000, 0x80000000)) ^
                (t_mask & new uint4(0x80000000, 0x80000000, 0x80000000, 0x00000000));

            value = new float4(tr, u.y, w.x, v.z) + DM.AsFloat4(DM.AsUInt4(new float4(t, v.x, u.z, w.y)) ^ sign_flips);

            value = DM.AsFloat4((DM.AsUInt4(value) & ~u_mask) | (DM.AsUInt4(value.zwxy) & u_mask));
            value = DM.AsFloat4((DM.AsUInt4(value.wzyx) & ~t_mask) | (DM.AsUInt4(value) & t_mask));
            value = DM.Normalize(value);
        }

        [IN(LINE)]
        public quat(ReadOnlySpan<float> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2]; w = values[3];
#else
            this = Unsafe.ReadUnaligned<quat>(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out float x, out float y, out float z, out float w) { x = this.x; y = this.y; z = this.z; w = this.w; }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] public float x { [IN(LINE)] get => value.x; [IN(LINE)] set => this.value.x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)] public float y { [IN(LINE)] get => value.y; [IN(LINE)] set => this.value.y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)] public float z { [IN(LINE)] get => value.z; [IN(LINE)] set => this.value.z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)] public float w { [IN(LINE)] get => value.w; [IN(LINE)] set => this.value.w = value; }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public unsafe float this[int index]
        {
            [IN(LINE)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (quat* array = &this) { return ((float*)array)[index]; }
            }
            [IN(LINE)]
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (float* array = &this.value.x) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is float cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(float); }
        #endregion

        #region IVectorEnumerable
        public VectorEnumerator<float, quat> GetEnumerator() => new VectorEnumerator<float, quat>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region operators
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
                q1w * q2w - dot);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator *(quat q, float3 v)
        {
            float3 t = 2 * DM.Cross(new float3(q.x, q.y, q.z), v);
            return v + q.w * t + DM.Cross(new float3(q.x, q.y, q.z), t);
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
        #endregion

        #region Other
        [IN(LINE)]
        public /*readonly*/ void CopyTo(Span<float> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            destination[0] = x; destination[1] = y; destination[2] = z; destination[3] = w;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is quat target && Equals(target); }
        [IN(LINE)] public bool Equals(quat a) { return x == a.x && y == a.y && z == a.z && w == a.w; }
        public override string ToString() { return $"quat({value}({DM.ToEuler(this)}))"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"quat({value.ToString(format, formatProvider)}({DM.ToEuler(this).ToString(format, formatProvider)}))";
        }

        internal class DebuggerProxy
        {
            public float4 quat;
            public float3 euler;
            public DebuggerProxy(quat v)
            {
                quat = v.value;
                euler = DM.ToEuler(v);
            }
        }
        #endregion
    }
}