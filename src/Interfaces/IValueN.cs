namespace DCFApixels.DataMath
{
    public interface IValueN<T> where T : struct
    {
        public int Length { get; }
        public ref T this[int index] { get; }
    }
    public interface IValue2<T> : IValueN<T> where T : struct
    {
        public T x { get; set; }
        public T y { get; set; }
    }

    public interface IValue3<T> : IValue2<T> where T : struct
    {
        public T z { get; set; }
    }
    public interface IValue4<T> : IValue3<T> where T : struct
    {
        public T w { get; set; }
    }
}
