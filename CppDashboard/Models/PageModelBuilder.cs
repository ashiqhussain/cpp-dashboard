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

        public PageModelBuilder(ICancellationsDueToOrphan cancellationsDueToOrphan, 
            IPspCommunicationFailures communicationFailures, IPaymentsCalculator paymentsCalculator, IGatewayRefusals gatewayRefusals)
        {
            _cancellationsDueToOrphan = cancellationsDueToOrphan;
            _communicationFailures = communicationFailures;
            _paymentsCalculator = paymentsCalculator;
            _gatewayRefusals = gatewayRefusals;
        }

        public PageModel Build()
        {
            var pageModel = new PageModel()
            {
                CancellationsDueToGhosts = _cancellationsDueToOrphan.GetTotal(),
                CommsFaliures = _communicationFailures.GetTotal(),
                SuccessPayments = _paymentsCalculator.GetTotalSuccessfulPayments(),
                DeclinedPayments = _paymentsCalculator.GetTotalDeclinedPayments(),
                GatewayMkFaliures = _gatewayRefusals.GetTotal()
            };

            return pageModel;
        }
    }
}