using System.Linq;
using CppDashboard.DataProvider;

namespace CppDashboard.Logic.Offline
{
    public class SystemOnlineOrOfflineStatus
    {
        private readonly IOfflineConfigs _offlineConfigs;

        public SystemOnlineOrOfflineStatus(IOfflineConfigs offlineConfigs)
        {
            _offlineConfigs = offlineConfigs;
        }

        public bool IsSystemOnline()
        {
            var automatic = int.Parse(_offlineConfigs.Configs.First(h => h.Key.Equals("Offline:Status")).Value);
            var manual = int.Parse(_offlineConfigs.Configs.First(h => h.Key.Equals("Offline:ManualOverrideEnabled")).Value);

            if (automatic == 1 || manual == 1)
            {
                return false;
            }

            return true;
        }
    }
}