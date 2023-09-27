using System.Runtime.CompilerServices;

namespace DataMath.src.Random
{
    public static class XorRandomUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NextState(int state)
        {
            unchecked
            {
                return (state << 13) ^ (state >> 17) ^ (state << 5);
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint NextState(uint state)
        {
            unchecked 
            { 
                return (state << 13) ^ (state >> 17) ^ (state << 5); 
            };
        }
    }
    public struct XorRandom
    {
        private uint _state;

        public XorRandom(int seed)
        {
            _state = (uint)seed;
            long x = long.MaxValue;
        }
        public XorRandom(uint seed)
        {
            _state = seed;
        }

        public int NextInt()
        {
            _state = XorRandomUtility.NextState(_state);
            return (int)_state;
        }
        public uint NextUInt()
        {
            _state = XorRandomUtility.NextState(_state);
            return _state;
        }
    }
}
