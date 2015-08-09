using System.Collections.Generic;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public interface IPaymentInfo
    {
        IEnumerable<Payment> Payments { get; }
    }
}