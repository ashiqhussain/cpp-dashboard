using System.Collections.Generic;

namespace CppDashboard.DataProvider
{
    public interface ILoad<T>
    {
        IEnumerable<T> Load(int duration);

        void ReloadFrom(int primaryKey, ref IList<T> source);
        
    }
}