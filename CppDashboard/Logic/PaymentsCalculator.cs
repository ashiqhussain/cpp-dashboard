using System.Linq;

namespace CppDashboard.Logic
{
    public interface IPaymentsCalculator
    {
        int GetTotalSuccessfulPayments();
        int GetTotalDeclinedPayments();
    }

    public class PaymentsCalculator : IPaymentsCalculator
    {
        public int GetTotalSuccessfulPayments()
        {
            var payments = DataLoader.Instance.Payments;
            return payments.Count(p => p.TransactionTypeId == 1 && p.TransactionStatusId == 5);
        }

        public int GetTotalDeclinedPayments()
        {
            var payments = DataLoader.Instance.Payments;
            return payments.Count(p => p.TransactionTypeId == 1 && p.TransactionStatusId == 2);
        }
    }
}