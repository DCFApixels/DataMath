using System;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    public interface IRayN
    {
        bool IsVectorN { [IN(LINE)] get; }
        object GetSrcRaw();
        object GetDirRaw();
        void SetSrcRaw(object raw);
        void SetDirRaw(object raw);
        [IN(LINE)] Type GetComponentType();
    }
    public interface IRayN<T, TVector> : IRayN
        where T : unmanaged
        where TVector : unmanaged
    {
        TVector src { [IN(LINE)] get; [IN(LINE)] set; }
        TVector dir { [IN(LINE)] get; [IN(LINE)] set; }
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
