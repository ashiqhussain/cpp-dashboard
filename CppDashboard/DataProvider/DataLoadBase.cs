using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace CppDashboard.DataProvider
{
    public abstract class DataLoadBase<T> : ILoad<T>
    {
        public abstract IEnumerable<T> Load(int duration);
        
        public void ReloadFrom(int primaryKey, ref IList<T> source)
        {
            var result = LoadingFrom(primaryKey);

            lock (((ICollection)source).SyncRoot)
            {
                source.AsList().AddRange(result);
            }

            source = new List<T>(source.Where(AllowedPeriod).ToList());
        }

        protected abstract bool AllowedPeriod(T input);

        protected abstract IEnumerable<T> LoadingFrom(int primaryKey);
    }
}