using System;
using System.Collections;
using System.Collections.Generic;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public interface IVectorN : IEnumerable
    {
        int count { [IN(LINE)] get; }
        object GetComponentRaw(int index);
        void SetComponentRaw(int index, object raw);
        Type GetComponentType();
    }
    public interface IVectorN<T> : IVectorN, IEnumerable<T> where T : unmanaged
    {
        T this[int index] { [IN(LINE)] get; [IN(LINE)] set; }
    }
    //public interface IVectorN<T, TV> : IVectorN<T>
    //    where T : unmanaged
    //    where TV : IVectorN<T>
    //{
    //    TV zero { [IN(LINE)] get; }
    //    TV one { [IN(LINE)] get; }
    //}
    public interface IVector1<T> : IVectorN<T> where T : unmanaged
    {
        T x { [IN(LINE)] get; [IN(LINE)] set; }
    }
    public interface IVector2<T> : IVector1<T> where T : unmanaged
    {
        T y { [IN(LINE)] get; [IN(LINE)] set; }
    }
    public interface IVector3<T> : IVector2<T> where T : unmanaged
    {
        T z { [IN(LINE)] get; [IN(LINE)] set; }
    }
    public interface IVector4<T> : IVector3<T> where T : unmanaged
    {
        T w { [IN(LINE)] get; [IN(LINE)] set; }
    }

    public interface IVector1Impl<T> : IVector1<T> where T : unmanaged { }
    public interface IVector2Impl<T> : IVector2<T> where T : unmanaged { }
    public interface IVector3Impl<T> : IVector3<T> where T : unmanaged { }
    public interface IVector4Impl<T> : IVector4<T> where T : unmanaged { }
}