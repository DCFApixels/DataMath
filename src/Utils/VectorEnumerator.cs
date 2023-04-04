using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public interface IEnumerableVector<T, TVector> : IEnumerable<T>
        where T : struct
        where TVector : struct, IVectorN<T>
    {
        public new VectorEnumerator<T, TVector> GetEnumerator();
    }
    public struct VectorEnumerator<T, TVector> : IEnumerator<T>
        where T : struct 
        where TVector : struct, IVectorN<T>
    {
        private readonly TVector _value;
        private sbyte _pointer;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public VectorEnumerator(TVector value) { _value = value; _pointer = -1; }
        public T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _value[_pointer];
        }
        object IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _value[_pointer];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext() => ++_pointer < _value.length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset() { }
    }
}
