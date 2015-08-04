using System;
using System.Linq;

namespace CppDashboard.Logic
{
    public class ThroughputCalculator
    {
        public decimal CurrentThroughput(int sourceDataInMinutes)
        {
            var logs = DataLoader.Instance.Logs;
            var monitoringLogs = DataLoader.Instance.MonitoringEvents;

            // Verify card
            var verifyCardCalls = logs.Count(c => c.Message.Contains("VerifyCard:"));

            // Refunds
            var cybersourceRefunds = monitoringLogs.Count(mlog => mlog.EventType.Equals("RefundAuthorized") && mlog.PaymentProvider.Equals("Cybersource"));
            var adyenRefunds = monitoringLogs.Count(mlog => mlog.EventType.Equals("RefundAuthorized") && mlog.PaymentProvider.Equals("Adyen"));

            // Credit payments
            var creditPayments = monitoringLogs.Count(mlog => mlog.EventType.Equals("CreditPaymentAuthorized") || mlog.EventType.Equals("CreditPaymentDeclined"));

            // Cancellations
            var cancellations = monitoringLogs.Count(mlog => mlog.EventType.Equals("CancellationAuthorised") || mlog.EventType.Equals("CancellationDeclined"));

            // offline
            var offlinePayments = monitoringLogs.Count(mlog => mlog.EventType.Equals("OfflinePaymentAuthorized") || mlog.EventType.Equals("OfflinePaymentDeclined"));

            return ((decimal)(verifyCardCalls + cybersourceRefunds + adyenRefunds + creditPayments + cancellations + offlinePayments)) 
                / sourceDataInMinutes;
        }
    }
}