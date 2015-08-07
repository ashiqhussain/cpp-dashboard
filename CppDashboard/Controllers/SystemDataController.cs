using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CppDashboard.DataProvider;
using CppDashboard.Models;

namespace CppDashboard.Controllers
{
    public class SystemDataController : ApiController
    {
        private readonly IInitialiser _initialiser;
        private readonly DataLoadBase<ErrorSummary> _errorSummary;

        public SystemDataController(IInitialiser initialiser, DataLoadBase<ErrorSummary> errorSummary)
        {
            _initialiser = initialiser;
            _initialiser.Init();
            _errorSummary = errorSummary;
        }

        [HttpGet]
        public IEnumerable<ErrorSummary> GetSystemErrors()
        {
            return ((ErrorSummaryWindow)_errorSummary).ErrorSummaries;
        }
    }
}
