using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CppDashboard.DataProvider.Setup;
using CppDashboard.Models;

namespace CppDashboard.DataProvider
{
    public class OfflineDataFacade : ILoad<Config>
    {
        private readonly ConnectionCreator _customerPaymentsConnection;

        public OfflineDataFacade()
        {
            _customerPaymentsConnection = new ConnectionCreator(Scope.CustomerPayment);
        }

        public IEnumerable<Config> Load(int duration)
        {
            var sql = string.Format("SELECT  * FROM Configuration WITH (NOLOCK) " +
                    "WHERE [Key] = '{0}' OR [Key]= '{1}'", "Offline:Status", "Offline:ManualOverrideEnabled");

            return _customerPaymentsConnection.Exec<Config>(sql);
        }

        public void ReloadFrom(int primaryKey, ref IList<Config> source)
        {
            var sql = string.Format("SELECT  * FROM Configuration WITH (NOLOCK) " +
                  "WHERE [Key] = '{0}' OR [Key]= '{1}'", "Offline:Status", "Offline:ManualOverrideEnabled");

            var data = _customerPaymentsConnection.Exec<Config>(sql);

            lock (((ICollection)source).SyncRoot)
            {
                source.Clear();
                source.ToList().AddRange(data);
            }
        }
    }
}