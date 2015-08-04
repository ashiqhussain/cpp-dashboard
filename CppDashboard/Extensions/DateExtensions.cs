using System;

namespace CppDashboard.Extensions
{
    public static class DateExtensions
    {
        public static string FormattedMins(this DateTime date, int duration)
        {
            var start = date.AddMinutes(duration).ToString("s").Replace("T", " ");

            return start;
        }

        public static DateTime StartMins(this DateTime date, int duration)
        {
            var start = date.AddMinutes(-duration);

            return start;
        }

        public static string Formatted(this DateTime date)
        {
            var start = date.ToString("s").Replace("T", " ");

            return start;
        }
    }
}