namespace CppDashboard.Models
{
    public class Notification
    {
        public int NotificationMessageStoreId { get; set; }

        public int PaymentProvider { get; set; }

        public string TransactionId { get; set; }
    }
}