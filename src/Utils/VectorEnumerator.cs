using System.Collections;
using System.Collections.Generic;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

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
        [IN(LINE)] public VectorEnumerator(TVector value) { _value = value; _pointer = -1; }
        public T Current { [IN(LINE)] get => _value[_pointer]; }
        object IEnumerator.Current { [IN(LINE)] get => _value[_pointer]; }
        [IN(LINE)] public void Dispose() { }
        [IN(LINE)] public bool MoveNext() => ++_pointer < _value.length;
        [IN(LINE)] public void Reset() { }
    }
}
