using System;
using System.Collections;
using System.Collections.Generic;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;
using CppDashboard.Extensions;
using Dapper;

namespace CppDashboard.DataProvider
{
    public class PaymentEventsDataFacade : DataLoadBase<PaymentEvent>
    {
        private readonly ConnectionCreator _connectionCreator;

        public PaymentEventsDataFacade()
        {
            _connectionCreator = new ConnectionCreator(Scope.Monitoring);
        }

        public override IEnumerable<PaymentEvent> Load(int duration)
        {
            var sql = string.Format("SELECT  * FROM PaymentEvents WITH (NOLOCK) " +
                      "WHERE EventDateTime BETWEEN '{0}' AND '{1}' " +
                                    "ORDER BY EventDateTime", DateTime.Now.FormattedMins(-Constants.TimeoutDuration), DateTime.Now.Formatted());

            return _connectionCreator.Exec<PaymentEvent>(sql);
        }

        protected override bool AllowedPeriod(PaymentEvent input)
        {
            return input.EventDateTime >= DateTime.Now.StartMins(Constants.TimeoutDuration) && input.EventDateTime <= DateTime.Now;
        }

        protected override IEnumerable<PaymentEvent> LoadingFrom(int primaryKey)
        {
            var sql = string.Format("SELECT  * FROM PaymentEvents WITH (NOLOCK) " +
                     "WHERE PaymentEventsId >'{0}'" +
                                   "ORDER BY EventDateTime", primaryKey);

            var data = _connectionCreator.Exec<PaymentEvent>(sql);
            
            return data;
        }
    }
}