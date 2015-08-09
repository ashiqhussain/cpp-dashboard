using System.Collections.Generic;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public interface IOfflineConfigs
    {
        IEnumerable<OfflineConfig> Configs { get; }
    }
}