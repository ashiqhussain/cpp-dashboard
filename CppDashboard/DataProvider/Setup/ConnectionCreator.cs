using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Dapper;

namespace CppDashboard.DataProvider.Setup
{
    public class ConnectionCreator
    {
        private readonly string _connectionString;
        private readonly Tuple<string, string, string> _details;

        public ConnectionCreator(Scope scope)
        {
            switch (scope)
            {
                case Scope.CustomerPayment:
                    _connectionString = ConfigurationManager.ConnectionStrings["ejCustomerPayments"].ConnectionString;
                    break;

                case Scope.Monitoring:
                    _connectionString = ConfigurationManager.ConnectionStrings["ejCustomerPaymentsMonitoring"].ConnectionString;
                    break;

                case Scope.Logging:
                    _connectionString = ConfigurationManager.ConnectionStrings["easyJetFramework"].ConnectionString;
                    break;
            }

            _details = GetCredentials();
        }

        public IEnumerable<T> Exec<T>(string sql)
        {

            using (new Impersonator(_details.Item1, _details.Item2, _details.Item3))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Query<T>(sql);
                }
            }
        }

        private Tuple<string, string, string> GetCredentials()
        {
            var detailsFile = new FileInfo("\\details.txt");
            using (var s = new StreamReader(detailsFile.OpenRead()))
            {
                var username = s.ReadLine().Replace("username:", "");
                var domain = s.ReadLine().Replace("domain:", "");
                var password = s.ReadLine().Replace("password:", "");

                return new Tuple<string, string, string>(username, domain, password);
            }
        }
    }
}