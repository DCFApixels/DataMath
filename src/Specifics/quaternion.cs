using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public partial struct quaternion : IVector4<float>, IEnumerableVector<float, quaternion>
    {
        public const int LENGTH = 4;

        public float x;
        public float y;
        public float z;
        public float w;

        #region IVectorN
        float IVector1<float>.x { get => x; set => x = value; }
        float IVector2<float>.y { get => y; set => y = value; }
        float IVector3<float>.z { get => z; set => z = value; }
        float IVector4<float>.w { get => w; set => w = value; }
        public unsafe ref float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (quaternion* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        public int length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LENGTH;
        }
        #endregion

        #region IVectorEnumerable
        public VectorEnumerator<float, quaternion> GetEnumerator() => new VectorEnumerator<float, quaternion>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
