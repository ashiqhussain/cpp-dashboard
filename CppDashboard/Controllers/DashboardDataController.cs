using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CppDashboard.DataProvider;
using CppDashboard.Logic;
using CppDashboard.Models;

namespace CppDashboard.Controllers
{
    public class DashboardDataController : ApiController
    {
        private readonly PageModelBuilder _pageModelBuilder;

        public DashboardDataController(PageModelBuilder pageModelBuilder)
        {
            _pageModelBuilder = pageModelBuilder;
        }

        [HttpGet]
        public PageModel Get()
        {
            var model = _pageModelBuilder.Build();
            var data = new PageModel()
            {
                IsSystemOnline = DataLoader.Instance.IsSystemOnline,
                Logs = DataLoader.Instance.Logs.Take(100),
                Throughput = DataLoader.Instance.CurrentThroughput,
                Current = DateTime.Now,
                SuccessPayments = model.SuccessPayments,
                DeclinedPayments = model.DeclinedPayments,
                CancellationsDueToGhosts = model.CancellationsDueToGhosts,
                CommsFaliures = model.CommsFaliures,
                GatewayMkFaliures = model.GatewayMkFaliures,
                AdyenMkFaliures = model.AdyenMkFaliures
            };
            return data;
        }

        [HttpGet]
        public void Update()
        {
            // Reload
            DataLoader.Instance.Reload();
        }
    }
}
