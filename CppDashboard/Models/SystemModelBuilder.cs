using CppDashboard.DataProvider;

namespace CppDashboard.Models
{
    public class SystemModelBuilder
    {
        private readonly DataLoadBase<ErrorSummary> _errorSummary;

        public SystemModelBuilder(DataLoadBase<ErrorSummary> errorSummary)
        {
            _errorSummary = errorSummary;
        }

        public void Build()
        {
            _errorSummary.Load(0);
        }
    }
}