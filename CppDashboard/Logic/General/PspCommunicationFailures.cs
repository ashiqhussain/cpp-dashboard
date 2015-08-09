using System.Linq;
using CppDashboard.DataProvider;

namespace CppDashboard.Logic.General
{
    public interface IPspCommunicationFailures
    {
        /// <summary>
        /// Returns the number PspCommunication Failures during the given period.
        /// </summary>
        /// <returns></returns>
        int GetTotal();
    }

    public class PspCommunicationFailures : IPspCommunicationFailures
    {
        private readonly IMonitoringEvents _monitoringEvents;

        public PspCommunicationFailures(IMonitoringEvents monitoringEvents)
        {
            _monitoringEvents = monitoringEvents;
        }

        /// <summary>
        /// Returns the number PspCommunication Failures during the given period.
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            var pspComms = _monitoringEvents.PaymentEvents;

            var count = pspComms.Count(c => c.EventType.Equals("PSPCommunicationFailed"));

            return count;
        }
    }
}