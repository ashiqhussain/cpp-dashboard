using CppDashboard.DataProvider;
using WebGrease.Css.Extensions;

namespace CppDashboard.Initialisers
{
    public class SystemDataInitialiser : IInitialiser
    {
        private readonly ILoadSystemData[] _systemData;

        public SystemDataInitialiser(ILoadSystemData[] systemData)
        {
            _systemData = systemData;
        }

        public void Load()
        {
            _systemData.ForEach(l => l.Load());
        }
    }
}