﻿namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public interface IRayBase<T>
        where T : struct
    {
        public T OriginX { get; set; }
        public T OriginY { get; set; }
        public T OriginZ { get; set; }

        public T DirectionX { get; set; }
        public T DirectionY { get; set; }
        public T DirectionZ { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay<T, TN> : IRayBase<T>
        where T : struct
        where TN : IVector3<T>
    {
        public TN Origin { get; set; }
        public TN Direction { get; set; }
    }


    /// <summary>Not Implemented</summary>
    public interface IRay2DBase<T>
        where T : struct
    {
        public T OriginX { get; set; }
        public T OriginY { get; set; }

        public T DirectionX { get; set; }
        public T DirectionY { get; set; }
    }

    /// <summary>Not Implemented</summary>
    public interface IRay2D<T, TN> : IRay2DBase<T>
        where T : struct
        where TN : IVector2<T>
    {
        public TN Origin { get; set; }
        public TN Direction { get; set; }
    }
}
