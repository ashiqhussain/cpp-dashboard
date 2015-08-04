using System;
using System.Collections.Generic;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;
using CppDashboard.Extensions;

namespace CppDashboard.DataProvider
{
    public class LoggingDataFacade : DataLoadBase<Log>
    {
        private readonly ConnectionCreator _connectionCreator;

        public LoggingDataFacade()
        {
            _connectionCreator = new ConnectionCreator(Scope.Logging);
        }

        public override IEnumerable<Log> Load(int duration)
        {
            var sql = string.Format("SELECT  * FROM logging.CustomerPayments_log WITH (NOLOCK) " +
                   "WHERE Date BETWEEN '{0}' AND '{1}' " +
                                 "ORDER BY Date", DateTime.Now.FormattedMins(-Constants.TimeoutDuration), DateTime.Now.Formatted());

            return _connectionCreator.Exec<Log>(sql);
        }

        protected override bool AllowedPeriod(Log input)
        {
            return input.Date >= DateTime.Now.StartMins(Constants.TimeoutDuration) && input.Date <= DateTime.Now;
        }

        protected override IEnumerable<Log> LoadingFrom(int primaryKey)
        {
            var sql = string.Format("SELECT  * FROM logging.CustomerPayments_log WITH (NOLOCK) " +
                 "WHERE Id > '{0}'", primaryKey);

            var data = _connectionCreator.Exec<Log>(sql);

            return data;
        }
    }
}