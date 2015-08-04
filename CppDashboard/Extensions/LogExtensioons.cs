using System;
using System.Collections.Generic;
using System.Linq;
using CppDashboard.Models;

namespace CppDashboard.Extensions
{
    public static class LogExtensioons
    {
        public static IEnumerable<Log> ErrorsAndWarningsOnlyPlease(this IEnumerable<Log> logs)
        {
            return logs.Where(l => 
                l.Level.Equals("Error", StringComparison.InvariantCultureIgnoreCase) ||
                l.Level.Equals("Warning", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}