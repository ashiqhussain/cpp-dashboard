using System.Linq;
using CppDashboard.DataProvider;

namespace CppDashboard.Logic.Payments
{
    public interface IPaymentsCalculator
    {
        int GetTotalSuccessfulPayments();
        int GetTotalDeclinedPayments();
    }

    public class PaymentsCalculator : IPaymentsCalculator
    {
        private readonly IPaymentInfo _paymentInfo;

        public PaymentsCalculator(IPaymentInfo paymentInfo)
        {
            _paymentInfo = paymentInfo;
        }

        public int GetTotalSuccessfulPayments()
        {
            var payments = _paymentInfo.Payments;
            return payments.Count(p => p.TransactionTypeId == 1 && p.TransactionStatusId == 5);
        }

        public int GetTotalDeclinedPayments()
        {
            var payments = _paymentInfo.Payments;
            return payments.Count(p => p.TransactionTypeId == 1 && p.TransactionStatusId == 2);
        }
    }
}