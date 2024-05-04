namespace DCFApixels.DataMath.TODO
{
    //Columns c0, c1, c2, c3
    //Fields mRC: m00, m21

    /// <summary>Not Implemented</summary>
    public interface IMatrix<T> : IVectorN<T> where T : struct
    {
        /// <summary>rows count / y length</summary>
        public int rows { get; }
        /// <summary>columns count / x length</summary>
        public int columns { get; }
        public T this[int r, int c] { get; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix1x1Cells<T> : IMatrix<T>, IVector1<T> where T : struct
    {
        /// <summary>m[0, 0] c0.x</summary>
        public T m00 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x2Cells<T> : IMatrix1x1Cells<T>, IVector2<T> where T : struct
    {
        /// <summary>m[0, 1] c1.x</summary>
        public T m01 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x3Cells<T> : IMatrix1x2Cells<T>, IVector3<T> where T : struct
    {
        /// <summary>m[0, 2] c2.x</summary>
        public T m02 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x4Cells<T> : IMatrix1x3Cells<T>, IVector4<T> where T : struct
    {
        /// <summary>m[0, 3] c3.x</summary>
        public T m03 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix2x1Cells<T> : IMatrix1x1Cells<T> where T : struct
    {
        /// <summary>m[1, 0] c0.y</summary>
        public T m10 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x2Cells<T> : IMatrix1x2Cells<T>, IMatrix2x1Cells<T> where T : struct
    {
        /// <summary>m[1, 1] c1.y</summary>
        public T m11 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x3Cells<T> : IMatrix1x3Cells<T>, IMatrix2x2Cells<T> where T : struct
    {
        /// <summary>m[1, 2] c2.y</summary>
        public T m12 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x4Cells<T> : IMatrix1x4Cells<T>, IMatrix2x3Cells<T> where T : struct
    {
        /// <summary>m[1, 3] c3.y</summary>
        public T m13 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix3x1Cells<T> : IMatrix2x1Cells<T> where T : struct
    {
        /// <summary>m[2, 0] c0.z</summary>
        public T m20 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x2Cells<T> : IMatrix2x2Cells<T>, IMatrix3x1Cells<T> where T : struct
    {
        /// <summary>m[2, 1] c1.z</summary>
        public T m21 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x3Cells<T> : IMatrix2x3Cells<T>, IMatrix3x2Cells<T> where T : struct
    {
        /// <summary>m[2, 2] c2.z</summary>
        public T m22 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x4Cells<T> : IMatrix2x4Cells<T>, IMatrix3x3Cells<T> where T : struct
    {
        /// <summary>m[2, 3] c3.z</summary>
        public T m23 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix4x1Cells<T> : IMatrix3x1Cells<T> where T : struct
    {
        /// <summary>m[3, 0] c0.w</summary>
        public T m30 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x2Cells<T> : IMatrix3x2Cells<T>, IMatrix4x1Cells<T> where T : struct
    {
        /// <summary>m[3, 1] c1.w</summary>
        public T m31 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x3Cells<T> : IMatrix3x3Cells<T>, IMatrix4x2Cells<T> where T : struct
    {
        /// <summary>m[3, 2] c2.w</summary>
        public T m32 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x4Cells<T> : IMatrix3x4Cells<T>, IMatrix4x3Cells<T> where T : struct
    {
        /// <summary>m[3, 3] c3.w</summary>
        public T m33 { get; set; }
    }





    /// <summary>Not Implemented</summary>
    public interface IMatrix1x1<T, TVector1> : IMatrix2x1Cells<T>
        where T : struct
        where TVector1 : struct, IVector1<T>
    {
        /// <summary>m[n < 2, 0]</summary>
        public TVector1 c0 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x2<T, TVector1> : IMatrix1x1<T, TVector1>, IMatrix2x2Cells<T>
        where T : struct
        where TVector1 : struct, IVector1<T>
    {
        /// <summary>m[n < 2, 1]</summary>
        public TVector1 c1 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x3<T, TVector1> : IMatrix1x2<T, TVector1>, IMatrix2x3Cells<T>
        where T : struct
        where TVector1 : struct, IVector1<T>
    {
        /// <summary>m[n < 2, 2]</summary>
        public TVector1 c2 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x4<T, TVector1> : IMatrix1x3<T, TVector1>, IMatrix2x4Cells<T>
        where T : struct
        where TVector1 : struct, IVector1<T>
    {
        /// <summary>m[n < 2, 3]</summary>
        public TVector1 c3 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix2x1<T, TVector2> : IMatrix2x1Cells<T>
        where T : struct
        where TVector2 : struct, IVector2<T>
    {
        /// <summary>m[n < 2, 0]</summary>
        public TVector2 c0 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x2<T, TVector2> : IMatrix2x1<T, TVector2>, IMatrix2x2Cells<T>
        where T : struct
        where TVector2 : struct, IVector2<T>
    {
        /// <summary>m[n < 2, 1]</summary>
        public TVector2 c1 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x3<T, TVector2> : IMatrix2x2<T, TVector2>, IMatrix2x3Cells<T>
        where T : struct
        where TVector2 : struct, IVector2<T>
    {
        /// <summary>m[n < 2, 2]</summary>
        public TVector2 c2 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x4<T, TVector2> : IMatrix2x3<T, TVector2>, IMatrix2x4Cells<T>
        where T : struct
        where TVector2 : struct, IVector2<T>
    {
        /// <summary>m[n < 2, 3]</summary>
        public TVector2 c3 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix3x1<T, TVector3> : IMatrix2x1Cells<T>
        where T : struct
        where TVector3 : struct, IVector3<T>
    {
        /// <summary>m[n < 3, 0]</summary>
        public TVector3 c0 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x2<T, TVector3> : IMatrix3x1<T, TVector3>, IMatrix3x2Cells<T>
        where T : struct
        where TVector3 : struct, IVector3<T>
    {
        /// <summary>m[n < 3, 1]</summary>
        public TVector3 c1 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x3<T, TVector3> : IMatrix3x2<T, TVector3>, IMatrix3x3Cells<T>
        where T : struct
        where TVector3 : struct, IVector3<T>
    {
        /// <summary>m[n < 3, 2]</summary>
        public TVector3 c2 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x4<T, TVector3> : IMatrix3x3<T, TVector3>, IMatrix3x4Cells<T>
        where T : struct
        where TVector3 : struct, IVector3<T>
    {
        /// <summary>m[n < 3, 3]</summary>
        public TVector3 c3 { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix4x1<T, TVector4> : IMatrix4x1Cells<T>
        where T : struct
        where TVector4 : struct, IVector4<T>
    {
        /// <summary>m[n < 4, 0]</summary>
        public TVector4 c0 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x2<T, TVector4> : IMatrix4x1<T, TVector4>, IMatrix4x2Cells<T>
        where T : struct
        where TVector4 : struct, IVector4<T>
    {
        /// <summary>m[n < 4, 1]</summary>
        public TVector4 c1 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x3<T, TVector4> : IMatrix4x2<T, TVector4>, IMatrix4x3Cells<T>
        where T : struct
        where TVector4 : struct, IVector4<T>
    {
        /// <summary>m[n < 4, 2]</summary>
        public TVector4 c2 { get; set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x4<T, TVector4> : IMatrix4x3<T, TVector4>, IMatrix4x4Cells<T>
        where T : struct
        where TVector4 : struct, IVector4<T>
    {
        /// <summary>m[n < 4, 3]</summary>
        public TVector4 c3 { get; set; }
    }
}
