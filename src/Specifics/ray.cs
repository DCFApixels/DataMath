namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public partial struct ray : IRay<float, float3>
    {
        public float3 origin;
        public float3 direction;

        #region Properties
        float3 IRay<float, float3>.Origin
        {
            get => origin;
            set => origin = value;
        }
        float3 IRay<float, float3>.Direction
        {
            get => direction;
            set => direction = value;
        }
        public float OriginX
        {
            get => origin.x;
            set => origin.x = value;
        }
        public float OriginY
        {
            get => origin.y;
            set => origin.y = value;
        }
        public float OriginZ
        {
            get => origin.z;
            set => origin.z = value;
        }
        public float DirectionX
        {
            get => direction.x;
            set => direction.x = value;
        }
        public float DirectionY
        {
            get => direction.y;
            set => direction.y = value;
        }
        public float DirectionZ
        {
            get => direction.z;
            set => direction.z = value;
        }
        #endregion
    }
}
