using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial struct quaternion : IVector4<float>, IEnumerableVector<float, quaternion>
    {
        public const int LENGTH = 4;

        public float x;
        public float y;
        public float z;
        public float w;

        #region IVectorN
        float IVector1<float>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        float IVector2<float>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        float IVector3<float>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        float IVector4<float>.w { [IN(LINE)] get => w; [IN(LINE)] set => w = value; }
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (quaternion* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region IVectorEnumerable
        public VectorEnumerator<float, quaternion> GetEnumerator() => new VectorEnumerator<float, quaternion>(this);
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
            public DebuggerProxy(quaternion v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }
        #endregion
    }
}
