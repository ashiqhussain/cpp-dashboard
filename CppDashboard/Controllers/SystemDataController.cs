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
        private readonly ISystemEventSummaryWindow _eventSummaryWindow;

        public SystemDataController(IInitialiser systemInitialiser, IErrorSummaryWindow errorSummary, ISystemEventSummaryWindow eventSummaryWindow)
        {
            _initialiser = systemInitialiser;
            _initialiser.Load();
            _errorSummary = errorSummary;
            _eventSummaryWindow = eventSummaryWindow;
        }

        [HttpGet]
        public IEnumerable<ErrorSummary> GetSystemErrors()
        {
            return _errorSummary.ErrorSummaries;
        }

        [HttpGet]
        public IEnumerable<SystemEventSummary> GetSysteEvents()
        {
            return _eventSummaryWindow.EventSummary;
        }
    }
}
