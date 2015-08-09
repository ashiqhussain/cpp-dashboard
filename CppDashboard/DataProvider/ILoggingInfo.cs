using System.Collections.Generic;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public interface ILoggingInfo
    {
        IEnumerable<Log> Logs { get; }
    }
}