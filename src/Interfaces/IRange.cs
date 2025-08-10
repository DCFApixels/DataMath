namespace DCFApixels.DataMath
{
    public interface IRange<T>
        where T : unmanaged
    {
        /// <summary>The start of this range</summary>
        public T start { get; set; }
        /// <summary>The length of this range</summary>
        public T extent { get; set; }

        public T AbsExtent { get; }
        public T Min { get; set; }
        public T Max { get; set; }
        public T AbsMin { get; }
        public T AbsMax { get; }
        public bool IsNegative { get; }
        public bool IsPositive { get; }

        public T Center { get; }
    }
}
