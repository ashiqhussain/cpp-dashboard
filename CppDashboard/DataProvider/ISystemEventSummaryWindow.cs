using System.Collections.Generic;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public interface ISystemEventSummaryWindow
    {
        IEnumerable<SystemEventSummary> EventSummary { get; }
    }
}