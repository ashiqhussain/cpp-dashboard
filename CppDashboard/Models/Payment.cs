using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CppDashboard.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int TransactionTypeId { get; set; }

        public int TransactionStatusId { get; set; }

        public string Reference { get; set; }

        public DateTime CreationDateTime { get; set; }

        public int Channel { get; set; }

        public string CurrencyCode { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string Mid { get; set; }

        public string Acquirer { get; set; }
    }
}