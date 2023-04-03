namespace DCFApixels.DataMath
{
    public interface IColor
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }
    }

    public interface IColor32
    {
        public byte r8 { get; set; }
        public byte g8 { get; set; }
        public byte b8 { get; set; }
        public byte a8 { get; set; }
    }
}
