namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    public interface IRayN<T, TVector>
        where T : unmanaged
        where TVector : IVector2<T>
    {
        public TVector GetPoint(float distance);
    }
    /// <summary>Not Implemented</summary>
    public interface IRay1Base<T>
        where T : unmanaged
    {
        public T OriginX { get; set; }
        public T DirectionX { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay1<T> : IRay1Base<T>
        where T : unmanaged
    {
        public T origin { get; set; }
        public T direction { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay2Base<T>
        where T : unmanaged
    {
        public T OriginX { get; set; }
        public T OriginY { get; set; }

        public T DirectionX { get; set; }
        public T DirectionY { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay2<T, TVector> : IRay2Base<T>
        where T : unmanaged
        where TVector : IVector2<T>
    {
        public TVector origin { get; set; }
        public TVector direction { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay3Base<T>
        where T : unmanaged
    {
        public T OriginX { get; set; }
        public T OriginY { get; set; }
        public T OriginZ { get; set; }

        public T DirectionX { get; set; }
        public T DirectionY { get; set; }
        public T DirectionZ { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay3<T, TVector> : IRay3Base<T>
        where T : unmanaged
        where TVector : IVector3<T>
    {
        public TVector origin { get; set; }
        public TVector direction { get; set; }
    }
}
