using CppDashboard.DataProvider;
using CppDashboard.Models;

namespace CppDashboard.Initialisers
{
    public class SystemDataInitialiser : IInitialiser
    {
        private readonly DataCanLoadBase<ErrorSummary> _errorSummary;

        public SystemDataInitialiser(DataCanLoadBase<ErrorSummary> errorSummary)
        {
            _errorSummary = errorSummary;
        }

        public void Load()
        {
            _errorSummary.Load();
        }
    }
}