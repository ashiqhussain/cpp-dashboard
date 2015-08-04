using System;
using System.Collections.Generic;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;
using CppDashboard.Extensions;

namespace CppDashboard.DataProvider
{
    public class NotificationDataFacade
    {
        private readonly ConnectionCreator _connectionCreator;

        public NotificationDataFacade()
        {
            _connectionCreator = new ConnectionCreator(Scope.CustomerPayment);
        }

        public IEnumerable<Notification> GetNotificationsForLast(int duration)
        {
            var sql = string.Format("SELECT  * FROM NotificationMessageStore WITH (NOLOCK) " +
                      "WHERE CreateDateTime BETWEEN '{0}' AND '{1}' " +
                                    "ORDER BY CreateDateTime", DateTime.Now.FormattedMins(-duration), DateTime.Now.Formatted());

            return _connectionCreator.Exec<Notification>(sql);
        }
    }
}