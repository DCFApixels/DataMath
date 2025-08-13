namespace DCFApixels.DataMath
{
    public interface IColorHSV
    {
        public float h { get; set; }
        public float s { get; set; }
        public float v { get; set; }
        public float a { get; set; }
    }
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
