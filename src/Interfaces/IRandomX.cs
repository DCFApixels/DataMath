namespace DCFApixels.DataMath
{
    public interface IRandom1
    {
        public float NextFloat();
    }
    public interface IRandom2 : IRandom1
    {
        public float NextFloat2();
    }
    public interface IRandom3 : IRandom2
    {
        public float NextFloat3();
    }
    public interface IRandom4 : IRandom3
    {
        public float NextFloat4();
    }
}
