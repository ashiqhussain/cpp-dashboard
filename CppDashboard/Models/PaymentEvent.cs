using System;

namespace CppDashboard.Models
{
    public class PaymentEvent
    {
        public int PaymentEventsId { get; set; }

        public string EventType { get; set; }

        public int PaymentId { get; set; }

        public int OriginalPaymentId { get; set; }

        public string PaymentProvider { get; set; }

        public string BookingReference { get; set; }

        public string TransactionId { get; set; }

        public DateTime EventDateTime { get; set; }
    }
}