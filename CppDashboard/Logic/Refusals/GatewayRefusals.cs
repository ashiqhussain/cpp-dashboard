using System;
using System.Collections.Generic;
using System.Linq;

namespace CppDashboard.Logic.Refusals
{
    public interface IGatewayRefusals
    {
        /// <summary>
        /// Returns the number of refusals at the Gateway level. No payment record is created at this level
        /// as it is a validation error.
        /// </summary>
        RefuseSummary GetTotal();
    }

    public class RefuseSummary
    {
        public int ServiceLevelRefusals { get; set; }

        public int AdyenRefusals { get; set; }
    }

    public class GatewayRefusals : IGatewayRefusals
    {
        private static string MakePayment = "easyJet.CustomerPayments.Gateway.Commands.MakePayment.MakeCardPaymentCommand";
        private static readonly List<string> CardValidationPrefix = new List<string>()
        {
            "Invalid Card Number",
            "Invalid Expiry Date",
            "Card has expired",
            "Invalid Issue Number",
            "Invalid Card security number",
            "Invalid Start Date",
            "Saved Card not found",
            "Invalid Name on card",
            "Invalid billing address",
            "Invalid payer authentication request",
        };

        private static readonly List<string> AdyenRefusalPrefix = new List<string>()
        {
            "Refused [1000]"
        };

        /// <summary>
        /// Returns the number of refusals at the Gateway level. No payment record is created at this level
        /// as it is a validation error.
        /// </summary>
        public RefuseSummary GetTotal()
        {
            // Validation errors are logged in the logging database.

            var logs = DataLoader.Instance.Logs;

            var gateway = logs.Count(h => h.Level.Equals("INFO", StringComparison.InvariantCultureIgnoreCase)
                            && h.Logger.Equals(MakePayment) && CardValidationPrefix.Any(j => h.Message.StartsWith(j)));

            var adyen = logs.Count(h => h.Level.Equals("INFO", StringComparison.InvariantCultureIgnoreCase)
                            && h.Logger.Equals(MakePayment) && AdyenRefusalPrefix.Any(j => h.Message.StartsWith(j)));

            return new RefuseSummary() { AdyenRefusals = adyen, ServiceLevelRefusals = gateway };
        }
    }
}