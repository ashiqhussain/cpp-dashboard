using System;
using System.Collections.Generic;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;
using CppDashboard.Extensions;

namespace CppDashboard.DataProvider
{
    public class PaymentsDataFacade : DataLoadBase<Payment>
    {
        private readonly ConnectionCreator _connectionCreator;

        public PaymentsDataFacade()
        {
            _connectionCreator = new ConnectionCreator(Scope.CustomerPayment);
        }

        public override IEnumerable<Payment> Load(int duration)
        {
            var sql = string.Format("SELECT  * FROM Payment WITH (NOLOCK) " +
                      "WHERE CreationDateTime BETWEEN '{0}' AND '{1}' " +
                                    "ORDER BY CreationDateTime", DateTime.Now.FormattedMins(-duration), DateTime.Now.Formatted());

            return _connectionCreator.Exec<Payment>(sql);
        }

        protected override bool AllowedPeriod(Payment input)
        {
            return input.CreationDateTime >= DateTime.Now.StartMins(Constants.TimeoutDuration) && input.CreationDateTime <= DateTime.Now;
        }

        protected override IEnumerable<Payment> LoadingFrom(int primaryKey)
        {
            var sql = string.Format("SELECT  * FROM Payment WITH (NOLOCK) " +
                    "WHERE PaymentId > '{0}' ", primaryKey);

            var data = _connectionCreator.Exec<Payment>(sql);

            return data;
        }
    }
}