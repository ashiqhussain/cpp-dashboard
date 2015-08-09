using System.Collections.Generic;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public interface IMonitoringEvents
    {
        IEnumerable<PaymentEvent> PaymentEvents { get; }
    }
}