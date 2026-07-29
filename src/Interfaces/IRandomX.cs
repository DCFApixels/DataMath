namespace DCFApixels.DataMath
{
    public interface IRandom1
    {
        public float NextFloat();
    }
    public interface IRandom2 : IRandom1
    {
        public float2 NextFloat2();
    }
    public interface IRandom3 : IRandom2
    {
        public float3 NextFloat3();
    }
    public interface IRandom4 : IRandom3
    {
        public float4 NextFloat4();
    }
}
