using CppDashboard.DataProvider;

namespace CppDashboard.Models
{
    public interface IInitialiser
    {
        void Init();
    }

    public class Initialiser : IInitialiser
    {
        private readonly DataLoadBase<ErrorSummary> _errorSummary;

        public Initialiser(DataLoadBase<ErrorSummary> errorSummary)
        {
            _errorSummary = errorSummary;
        }

        public void Init()
        {
            _errorSummary.Load(0);
        }


    }
}