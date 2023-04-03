namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public interface IRect<T, TN> : IValue4<T>
        where T : struct 
        where TN : struct, IValue2<T>
    {
        public T Height { get; }
        public T Width { get; }
        public TN Center { get; }
    }
}
