namespace DCFApixels.DataMath
{
    public interface IValueN<T> where T : struct
    {
        public int Length { get; }
        public ref T this[int index] { get; }
    }
    public interface IValue2<T> where T : struct
    {
        public T X { get; set; }
        public T Y { get; set; }
    }

    public interface IValue3<T> : IValue2<T> where T : struct
    {
        public T Z { get; set; }
    }
    public interface IValue4<T> : IValue3<T> where T : struct
    {
        public T W { get; set; }
    }
}
