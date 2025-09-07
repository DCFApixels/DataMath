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
    public interface IRay1Impl<T> : IRayN<T, T>
        where T : unmanaged
    {
    }

    public interface IRay2Impl<T, TVector> : IRayN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector2<T>
    {
    }

    public interface IRay3Impl<T, TVector> : IRayN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector3<T>
    {
    }

    public interface IRay4Impl<T, TVector> : IRayN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector4<T>
    {
    }
}
