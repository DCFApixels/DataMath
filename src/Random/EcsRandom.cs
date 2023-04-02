using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCFApixels.DragonECS
{
    public readonly struct EcsRandom
    {
        public readonly int layerID; // 0 = default layer;

        public EcsRandom(string layerName)
        {
            layerID = 0;
        }
    }

    public static class EcsRandomCore
    {
        private static Dictionary<string, int> _randomLayers = new Dictionary<string, int>();
        private static int _increment = 1;
        static EcsRandomCore()
        {
            _randomLayers.Add("", 0); // default layer
        }
        internal static int GetLayerID(string layername)
        {
           
            if(!_randomLayers.TryGetValue(layername, out int id))
            {
                id = _increment++;
                _randomLayers.Add(layername, id);
                onLayerDeclared(layername, id);
            }
            return id;
        }

        public delegate void LayerDeclaredHandler(string name, int id);
        public static LayerDeclaredHandler onLayerDeclared = delegate{};
    }
}
