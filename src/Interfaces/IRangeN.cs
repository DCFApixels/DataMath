using System;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public interface IRangeN
    {
        bool IsVectorN { [IN(LINE)] get; }
        object GetSrcRaw();
        object GetDirRaw();
        void SetSrcRaw(object raw);
        void SetDirRaw(object raw);
        [IN(LINE)] Type GetComponentType();
    }
    public interface IRangeN<T, TVector> : IRangeN
        where T : unmanaged
        where TVector : unmanaged
    {
        TVector src { [IN(LINE)] get; [IN(LINE)] set; }
        TVector dir { [IN(LINE)] get; [IN(LINE)] set; }
        TVector a { [IN(LINE)] get; [IN(LINE)] set; }
        TVector b { [IN(LINE)] get; [IN(LINE)] set; }
        TVector min { [IN(LINE)] get; [IN(LINE)] set; }
        TVector max { [IN(LINE)] get; [IN(LINE)] set; }
    }
    public interface IRange1Impl<T> : IRangeN<T, T>
        where T : unmanaged
    {
    }

    public interface IRange2Impl<T, TVector> : IRangeN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector2<T>
    {
    }

    public interface IRange3Impl<T, TVector> : IRangeN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector3<T>
    {
    }

    public interface IRange4Impl<T, TVector> : IRangeN<T, TVector>
        where T : unmanaged
        where TVector : unmanaged, IVector4<T>
    {
    }
}
