using System.Collections.Generic;

namespace CppDashboard.DataProvider
{
    public interface ICanLoad<T>
    {
        void Load();

        void Refresh(ref IList<T> source);
        
    }

    public interface ICanReload
    {
        void Reload();
    }
}