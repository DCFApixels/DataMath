namespace DCFApixels.DataMath.TODO
{
    //Columns c0, c1, c2, c3
    /// <summary>Not Implemented</summary>
    public interface IMatrix1xN<TVector> where TVector : struct, IVector1<TVector>
    {
        public int colums { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x1<TVector> : IMatrix1xN<TVector> where TVector : struct, IVector1<TVector>
    {
        public ref TVector c0 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x2<TVector> : IMatrix1x1<TVector> where TVector : struct, IVector1<TVector>
    {
        public ref TVector c1 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x3<TVector> : IMatrix1x2<TVector> where TVector : struct, IVector1<TVector>
    {
        public ref TVector c2 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x4<TVector> : IMatrix1x3<TVector> where TVector : struct, IVector1<TVector>
    {
        public ref TVector c3 { get; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix2xN<TVector> where TVector : struct, IVector2<TVector>
    {
        public int colums { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x1<TVector> : IMatrix2xN<TVector> where TVector : struct, IVector2<TVector>
    {
        public ref TVector c0 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x2<TVector> : IMatrix2x1<TVector> where TVector : struct, IVector2<TVector>
    {
        public ref TVector c1 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x3<TVector> : IMatrix2x2<TVector> where TVector : struct, IVector2<TVector>
    {
        public ref TVector c2 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x4<TVector> : IMatrix2x3<TVector> where TVector : struct, IVector2<TVector>
    {
        public ref TVector c3 { get; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix3xN<TVector> where TVector : struct, IVector3<TVector>
    {
        public int colums { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x1<TVector> : IMatrix3xN<TVector> where TVector : struct, IVector3<TVector>
    {
        public ref TVector c0 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x2<TVector> : IMatrix3x1<TVector> where TVector : struct, IVector3<TVector>
    {
        public ref TVector c1 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x3<TVector> : IMatrix3x2<TVector> where TVector : struct, IVector3<TVector>
    {
        public ref TVector c2 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x4<TVector> : IMatrix3x3<TVector> where TVector : struct, IVector3<TVector>
    {
        public ref TVector c3 { get; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix4xN<TVector> where TVector : struct, IVector3<TVector>
    {
        public int colums { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x1<TVector> : IMatrix4xN<TVector> where TVector : struct, IVector4<TVector>
    {
        public ref TVector c0 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x2<TVector> : IMatrix4x1<TVector> where TVector : struct, IVector4<TVector>
    {
        public ref TVector c1 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x3<TVector> : IMatrix4x2<TVector> where TVector : struct, IVector4<TVector>
    {
        public ref TVector c2 { get; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x4<TVector> : IMatrix4x3<TVector> where TVector : struct, IVector4<TVector>
    {
        public ref TVector c3 { get; }
    }
}
