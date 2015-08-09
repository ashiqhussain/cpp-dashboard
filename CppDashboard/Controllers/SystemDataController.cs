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
        private readonly DataCanLoadBase<ErrorSummary> _errorSummary;

        public SystemDataController(IInitialiser systemInitialiser, DataCanLoadBase<ErrorSummary> errorSummary)
        {
            _initialiser = systemInitialiser;
            _initialiser.Load();
            _errorSummary = errorSummary;
        }

        [HttpGet]
        public IEnumerable<ErrorSummary> GetSystemErrors()
        {
            return ((ErrorSummaryWindow)_errorSummary).ErrorSummaries;
        }
    }
}
