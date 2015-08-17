using CppDashboard.DataProvider;
using WebGrease.Css.Extensions;

namespace CppDashboard.Initialisers
{
    public class ShortTermDataInitialiser : IInitialiser
    {
        private readonly ILoadVolatileData[] _loadVolatileData;
        private static bool _loaded;

        public ShortTermDataInitialiser(ILoadVolatileData[] loadVolatileData)
        {
            _loadVolatileData = loadVolatileData;
        }

        public void Load()
        {
            if (_loaded) return;
            _loadVolatileData.ForEach(a => a.Load());
            _loaded = true;
        }
    }
}