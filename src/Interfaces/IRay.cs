namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public interface IRayBase<T>
        where T : struct
    {
        public T originX { get; set; }
        public T originY { get; set; }
        public T originZ { get; set; }

        public T directionX { get; set; }
        public T directionY { get; set; }
        public T directionZ { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay<T, TN> : IRayBase<T>
        where T : struct
        where TN : IValue3<T>
    {
        public TN origin { get; set; }
        public TN direction { get; set; }
    }
}
