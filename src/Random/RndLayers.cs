using System;
using System.Collections.Generic;

namespace DCFApixels.DataMath
{
    //public static class Rnd
    //{
    //    private const string DEFAULT_LAYER_NAMEKEY = "";
    //    private const int DEFAULT_LAYER = 0;
    //    private static Dictionary<string, int> _randomLayers = new Dictionary<string, int>();
    //    private static int _increment = 1;
    //    private static int _size;
    //
    //    private static States<int>  _states32 = new States<int>();
    //    private static States<long> _states64 = new States<long>();
    //
    //    static Rnd()
    //    {
    //        _randomLayers.Add(DEFAULT_LAYER_NAMEKEY, DEFAULT_LAYER);
    //        _size = 1;
    //    }
    //    internal static int GetLayerID() => GetLayerID(DEFAULT_LAYER_NAMEKEY);
    //    internal static int GetLayerID(string layername)
    //    {
    //        if(!_randomLayers.TryGetValue(layername, out int id))
    //        {
    //            id = _increment++;
    //            if(_size<= id)
    //            {
    //                _size <<= 1;
    //                _states32.Resize(_size);
    //                _states64.Resize(_size);
    //            }
    //            _randomLayers.Add(layername, id);
    //            onLayerDeclared(layername, id);
    //        }
    //        return id;
    //    }
    //
    //    public delegate void LayerDeclaredHandler(string name, int id);
    //    public static LayerDeclaredHandler onLayerDeclared = delegate{};
    //
    //    private class States<T>
    //    {
    //        public T[] states = new T[0];
    //        public void Resize(int newSize)
    //        {
    //            Array.Resize(ref states, newSize);
    //        }
    //    }
    //}
}
