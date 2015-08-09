using System.Linq;
using CppDashboard.DataProvider;
using CppDashboard.Logic;
using CppDashboard.Logic.Refusals;

namespace CppDashboard.Models
{
    public class PageModelBuilder
    {
        private readonly ICancellationsDueToOrphan _cancellationsDueToOrphan;
        private readonly IPspCommunicationFailures _communicationFailures;
        private readonly IPaymentsCalculator _paymentsCalculator;
        private readonly IGatewayRefusals _gatewayRefusals;
        private readonly ILoggingInfo _loggingInfo;

        public PageModelBuilder(ICancellationsDueToOrphan cancellationsDueToOrphan, 
            IPspCommunicationFailures communicationFailures, IPaymentsCalculator paymentsCalculator, 
            IGatewayRefusals gatewayRefusals, ILoggingInfo loggingInfo)
        {
            _cancellationsDueToOrphan = cancellationsDueToOrphan;
            _communicationFailures = communicationFailures;
            _paymentsCalculator = paymentsCalculator;
            _gatewayRefusals = gatewayRefusals;
            _loggingInfo = loggingInfo;
        }

        public PageModel Build()
        {
            var refusals = _gatewayRefusals.GetTotal();
            var pageModel = new PageModel()
            {
                CancellationsDueToGhosts = _cancellationsDueToOrphan.GetTotal(),
                CommsFaliures = _communicationFailures.GetTotal(),
                SuccessPayments = _paymentsCalculator.GetTotalSuccessfulPayments(),
                DeclinedPayments = _paymentsCalculator.GetTotalDeclinedPayments(),
                GatewayMkFaliures = refusals.ServiceLevelRefusals,
                AdyenMkFaliures = refusals.AdyenRefusals,
                Logs = _loggingInfo.Logs.Take(100)
            };

            return pageModel;
        }
    }
}