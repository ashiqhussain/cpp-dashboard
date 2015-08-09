using System;
using System.Linq;
using CppDashboard.DataProvider;

namespace CppDashboard.Logic
{
    public class ThroughputCalculator
    {
        private readonly ILoggingInfo _loggingInfo;
        private readonly IMonitoringEvents _monitoringEvents;

        public ThroughputCalculator(ILoggingInfo loggingInfo, IMonitoringEvents monitoringEvents)
        {
            _loggingInfo = loggingInfo;
            _monitoringEvents = monitoringEvents;
        }

        public decimal CurrentThroughput(int sourceDataInMinutes)
        {
            var logs = _loggingInfo.Logs;
            var monitoringLogs = _monitoringEvents.PaymentEvents;

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