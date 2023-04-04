namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public interface IRange<T> : IVector2<T>, IRay1<T>
        where T : struct
    {
        public T distance { get; set; }

        public T AbsDistance { get; }
        public T Min { get; }
        public T Max { get; }
        public T AbsMin { get; }
        public T AbsMax { get; }
        public bool IsNegative { get; }
        public bool IsPositive { get; }

        public T Center { get; }
        //public T direction { get; }
    }
}
