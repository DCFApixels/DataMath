namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    public interface IRayN
    {
        bool IsVectorN { get; }
    }
    public interface IRayN<T, TVector> : IRayN
        where T : unmanaged
        where TVector : unmanaged
    {
        TVector src { get; set; }
        TVector dir { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IRay1Impl<T> : IRayN<T, T>
        where T : unmanaged
    {
    }

    /// <summary>Not Implemented</summary>
    public interface IRay2Impl<T, TVector> : IRayN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector2<T>
    {
    }

    /// <summary>Not Implemented</summary>
    public interface IRay3Impl<T, TVector> : IRayN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector3<T>
    {
    }
}
