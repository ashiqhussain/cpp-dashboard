using System.Linq;

namespace CppDashboard.Logic
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
        /// <summary>
        /// Returns the number PspCommunication Failures during the given period.
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            var pspComms = DataLoader.Instance.MonitoringEvents;

            var count = pspComms.Count(c => c.EventType.Equals("PSPCommunicationFailed"));

            return count;
        }
    }
}