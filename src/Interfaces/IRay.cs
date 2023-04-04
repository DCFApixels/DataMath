namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public interface IRay1<T>
        where T : struct
    {
        public T Origin { get; set; }
        public T Direction { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay2Base<T>
        where T : struct
    {
        public T OriginX { get; set; }
        public T OriginY { get; set; }

        public T DirectionX { get; set; }
        public T DirectionY { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay2<T, TN> : IRay2Base<T>
        where T : struct
        where TN : IVector2<T>
    {
        public TN Origin { get; set; }
        public TN Direction { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay3Base<TVector>
        where TVector : struct
    {
        public TVector OriginX { get; set; }
        public TVector OriginY { get; set; }
        public TVector OriginZ { get; set; }

        public TVector DirectionX { get; set; }
        public TVector DirectionY { get; set; }
        public TVector DirectionZ { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay3<T, TVector> : IRay3Base<T>
        where T : struct
        where TVector : IVector3<T>
    {
        public TVector Origin { get; set; }
        public TVector Direction { get; set; }
    }
}
