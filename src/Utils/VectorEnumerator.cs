using System.Collections;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public interface IEnumerableVector<T, TVector> : IEnumerable<T>
        where T : unmanaged
        where TVector : unmanaged, IVectorN<T>
    {
        public new VectorEnumerator<T, TVector> GetEnumerator();
    }
    public struct VectorEnumerator<T, TVector> : IEnumerator<T>
        where T : unmanaged
        where TVector : unmanaged, IVectorN<T>
    {
        private readonly TVector _value;
        private int _index;
        [IN(LINE)] public VectorEnumerator(TVector value) { _value = value; _index = -1; }
        public T Current { [IN(LINE)] get => _value[_index]; }
        object IEnumerator.Current { [IN(LINE)] get => _value[_index]; }
        [IN(LINE)] public void Dispose() { }
        [IN(LINE)] public bool MoveNext() => ++_index < _value.count;
        [IN(LINE)] public void Reset() { }
    }
}
