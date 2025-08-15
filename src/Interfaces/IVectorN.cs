using System.Collections.Generic;

namespace DCFApixels.DataMath
{
    public interface IVectorN<T> : IEnumerable<T> where T : unmanaged
    {
        public int count { get; }
        public T this[int index] { get; set; }
    }
    public interface IVector1<T> : IVectorN<T> where T : unmanaged
    {
        public T x { get; set; }
    }
    public interface IVector2<T> : IVector1<T> where T : unmanaged
    {
        public T y { get; set; }
    }
    public interface IVector3<T> : IVector2<T> where T : unmanaged
    {
        public T z { get; set; }
    }
    public interface IVector4<T> : IVector3<T> where T : unmanaged
    {
        public T w { get; set; }
    }
}
