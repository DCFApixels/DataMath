using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public interface IVectorN<T> where T : struct
    {
        public int length { get; }
        public T this[int index] { get; set; }
    }
    public interface IVector1<T> : IVectorN<T> where T : struct
    {
        public T x { get; set; }
    }
    public interface IVector2<T> : IVector1<T> where T : struct
    {
        public T y { get; set; }
    }
    public interface IVector3<T> : IVector2<T> where T : struct
    {
        public T z { get; set; }
    }
    public interface IVector4<T> : IVector3<T> where T : struct
    {
        public T w { get; set; }
    }

    public interface IBoolVector
    {
        public bool all { get; set; }
        public bool any { get; }
    }
}
