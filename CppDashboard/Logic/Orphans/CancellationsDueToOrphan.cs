using System.Linq;
using CppDashboard.DataProvider;

namespace CppDashboard.Logic
{
    public interface ICancellationsDueToOrphan
    {
        /// <summary>
        /// Returns the number of cancellations due to orphan payments.
        /// </summary>
        int GetTotal();
    }

    public class CancellationsDueToOrphan : ICancellationsDueToOrphan
    {
        private readonly IMonitoringEvents _monitoringEvents;

        public CancellationsDueToOrphan(IMonitoringEvents monitoringEvents)
        {
            _monitoringEvents = monitoringEvents;
        }

        /// <summary>
        /// Returns the number of cancellations due to orphan payments.
        /// </summary>
        public int GetTotal()
        {
            var paymentEvents = _monitoringEvents.PaymentEvents;

            // Count all the "OrphanPaymentDetected" events
            var orphanPayments = paymentEvents.Where(o => o.EventType.Equals("OrphanPaymentDetected"));

            // Then check for "CancelPaymentAuthorized" and "CancelPaymentSubmitted" events with Original payment id.
            int total = 0;

            foreach (var orphanPayment in orphanPayments)
            {
                var local = orphanPayment;
                var cancelRequests = paymentEvents.Count(h =>
                    local.PaymentId.Equals(h.OriginalPaymentId) && (h.EventType.Equals("CancelPaymentAuthorized") || h.EventType.Equals("CancelPaymentSubmitted")));

                if (cancelRequests == 2) // we have both, safely say that the payment was successfully cancelled.
                {
                    total++;
                }
            }

            return total;
        }
    }
}