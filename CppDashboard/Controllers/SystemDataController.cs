using System.Collections.Generic;
using System.Web.Http;
using CppDashboard.DataProvider;
using CppDashboard.Initialisers;
using CppDashboard.Models;

namespace CppDashboard.Controllers
{
    public class SystemDataController : ApiController
    {
        private readonly IInitialiser _initialiser;
        private readonly IErrorSummaryWindow _errorSummary;

        public SystemDataController(IInitialiser systemInitialiser, IErrorSummaryWindow errorSummary)
        {
            _initialiser = systemInitialiser;
            _initialiser.Load();
            _errorSummary = errorSummary;
        }

        [HttpGet]
        public IEnumerable<ErrorSummary> GetSystemErrors()
        {
            return _errorSummary.ErrorSummaries;
        }
    }
}
