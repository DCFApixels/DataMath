using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.TODO
{
    //Columns c0, c1, c2, c3
    //Fields mRC: m00, m21

    /// <summary>Not Implemented</summary>
    public interface IMatrix<T> : IVectorN<T> where T : unmanaged
    {
        /// <summary>rows count / y length</summary>
        int Rows { [IN(LINE)] get; }
        /// <summary>columns count / x length</summary>
        int Columns { [IN(LINE)] get; }
        T this[int x, int y] { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix1x1Cells<T> : IMatrix<T> where T : unmanaged
    {
        /// <summary>m[0, 0] c0.x</summary>
        T m00 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x2Cells<T> : IMatrix1x1Cells<T> where T : unmanaged
    {
        /// <summary>m[0, 1] c1.x</summary>
        T m01 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x3Cells<T> : IMatrix1x2Cells<T> where T : unmanaged
    {
        /// <summary>m[0, 2] c2.x</summary>
        T m02 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x4Cells<T> : IMatrix1x3Cells<T> where T : unmanaged
    {
        /// <summary>m[0, 3] c3.x</summary>
        T m03 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix2x1Cells<T> : IMatrix1x1Cells<T> where T : unmanaged
    {
        /// <summary>m[1, 0] c0.y</summary>
        T m10 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x2Cells<T> : IMatrix1x2Cells<T>, IMatrix2x1Cells<T> where T : unmanaged
    {
        /// <summary>m[1, 1] c1.y</summary>
        T m11 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x3Cells<T> : IMatrix1x3Cells<T>, IMatrix2x2Cells<T> where T : unmanaged
    {
        /// <summary>m[1, 2] c2.y</summary>
        T m12 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x4Cells<T> : IMatrix1x4Cells<T>, IMatrix2x3Cells<T> where T : unmanaged
    {
        /// <summary>m[1, 3] c3.y</summary>
        T m13 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix3x1Cells<T> : IMatrix2x1Cells<T> where T : unmanaged
    {
        /// <summary>m[2, 0] c0.z</summary>
        T m20 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x2Cells<T> : IMatrix2x2Cells<T>, IMatrix3x1Cells<T> where T : unmanaged
    {
        /// <summary>m[2, 1] c1.z</summary>
        T m21 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x3Cells<T> : IMatrix2x3Cells<T>, IMatrix3x2Cells<T> where T : unmanaged
    {
        /// <summary>m[2, 2] c2.z</summary>
        T m22 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x4Cells<T> : IMatrix2x4Cells<T>, IMatrix3x3Cells<T> where T : unmanaged
    {
        /// <summary>m[2, 3] c3.z</summary>
        T m23 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix4x1Cells<T> : IMatrix3x1Cells<T> where T : unmanaged
    {
        /// <summary>m[3, 0] c0.w</summary>
        T m30 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x2Cells<T> : IMatrix3x2Cells<T>, IMatrix4x1Cells<T> where T : unmanaged
    {
        /// <summary>m[3, 1] c1.w</summary>
        T m31 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x3Cells<T> : IMatrix3x3Cells<T>, IMatrix4x2Cells<T> where T : unmanaged
    {
        /// <summary>m[3, 2] c2.w</summary>
        T m32 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x4Cells<T> : IMatrix3x4Cells<T>, IMatrix4x3Cells<T> where T : unmanaged
    {
        /// <summary>m[3, 3] c3.w</summary>
        T m33 { [IN(LINE)] get; [IN(LINE)] set; }
    }





    /// <summary>Not Implemented</summary>
    public interface IMatrix1x1<T, TVector1> : IMatrix2x1Cells<T>
        where T : unmanaged
        where TVector1 : unmanaged, IVector1<T>
    {
        /// <summary>m[n < 2, 0]</summary>
        TVector1 c0 { [IN(LINE)] get; [IN(LINE)] set; }
        [IN(LINE)] TVector1 GetColumn(int index);
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x2<T, TVector1> : IMatrix1x1<T, TVector1>, IMatrix2x2Cells<T>
        where T : unmanaged
        where TVector1 : unmanaged, IVector1<T>
    {
        /// <summary>m[n < 2, 1]</summary>
        TVector1 c1 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x3<T, TVector1> : IMatrix1x2<T, TVector1>, IMatrix2x3Cells<T>
        where T : unmanaged
        where TVector1 : unmanaged, IVector1<T>
    {
        /// <summary>m[n < 2, 2]</summary>
        TVector1 c2 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix1x4<T, TVector1> : IMatrix1x3<T, TVector1>, IMatrix2x4Cells<T>
        where T : unmanaged
        where TVector1 : unmanaged, IVector1<T>
    {
        /// <summary>m[n < 2, 3]</summary>
        TVector1 c3 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix2x1<T, TVector2> : IMatrix2x1Cells<T>
        where T : unmanaged
        where TVector2 : unmanaged, IVector2<T>
    {
        /// <summary>m[n < 2, 0]</summary>
        TVector2 c0 { [IN(LINE)] get; [IN(LINE)] set; }
        [IN(LINE)] TVector2 GetColumn(int index);
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x2<T, TVector2> : IMatrix2x1<T, TVector2>, IMatrix2x2Cells<T>
        where T : unmanaged
        where TVector2 : unmanaged, IVector2<T>
    {
        /// <summary>m[n < 2, 1]</summary>
        TVector2 c1 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x3<T, TVector2> : IMatrix2x2<T, TVector2>, IMatrix2x3Cells<T>
        where T : unmanaged
        where TVector2 : unmanaged, IVector2<T>
    {
        /// <summary>m[n < 2, 2]</summary>
        TVector2 c2 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix2x4<T, TVector2> : IMatrix2x3<T, TVector2>, IMatrix2x4Cells<T>
        where T : unmanaged
        where TVector2 : unmanaged, IVector2<T>
    {
        /// <summary>m[n < 2, 3]</summary>
        TVector2 c3 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix3x1<T, TVector3> : IMatrix2x1Cells<T>
        where T : unmanaged
        where TVector3 : unmanaged, IVector3<T>
    {
        /// <summary>m[n < 3, 0]</summary>
        TVector3 c0 { [IN(LINE)] get; [IN(LINE)] set; }
        [IN(LINE)] TVector3 GetColumn(int index);
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x2<T, TVector3> : IMatrix3x1<T, TVector3>, IMatrix3x2Cells<T>
        where T : unmanaged
        where TVector3 : unmanaged, IVector3<T>
    {
        /// <summary>m[n < 3, 1]</summary>
        TVector3 c1 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x3<T, TVector3> : IMatrix3x2<T, TVector3>, IMatrix3x3Cells<T>
        where T : unmanaged
        where TVector3 : unmanaged, IVector3<T>
    {
        /// <summary>m[n < 3, 2]</summary>
        TVector3 c2 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix3x4<T, TVector3> : IMatrix3x3<T, TVector3>, IMatrix3x4Cells<T>
        where T : unmanaged
        where TVector3 : unmanaged, IVector3<T>
    {
        /// <summary>m[n < 3, 3]</summary>
        TVector3 c3 { [IN(LINE)] get; [IN(LINE)] set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IMatrix4x1<T, TVector4> : IMatrix4x1Cells<T>
        where T : unmanaged
        where TVector4 : unmanaged, IVector4<T>
    {
        /// <summary>m[n < 4, 0]</summary>
        TVector4 c0 { [IN(LINE)] get; [IN(LINE)] set; }
        [IN(LINE)] TVector4 GetColumn(int index);
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x2<T, TVector4> : IMatrix4x1<T, TVector4>, IMatrix4x2Cells<T>
        where T : unmanaged
        where TVector4 : unmanaged, IVector4<T>
    {
        /// <summary>m[n < 4, 1]</summary>
        TVector4 c1 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x3<T, TVector4> : IMatrix4x2<T, TVector4>, IMatrix4x3Cells<T>
        where T : unmanaged
        where TVector4 : unmanaged, IVector4<T>
    {
        /// <summary>m[n < 4, 2]</summary>
        TVector4 c2 { [IN(LINE)] get; [IN(LINE)] set; }
    }
    /// <summary>Not Implemented</summary>
    public interface IMatrix4x4<T, TVector4> : IMatrix4x3<T, TVector4>, IMatrix4x4Cells<T>
        where T : unmanaged
        where TVector4 : unmanaged, IVector4<T>
    {
        /// <summary>m[n < 4, 3]</summary>
        TVector4 c3 { [IN(LINE)] get; [IN(LINE)] set; }
    }
}