using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CppDashboard.DataProvider;
using CppDashboard.Logic;
using CppDashboard.Models;
using WebGrease.Css.Extensions;

namespace CppDashboard.Controllers
{
    public class DashboardDataController : ApiController
    {
        private readonly PageModelBuilder _pageModelBuilder;
        private readonly IInitialiser _initialiser;
        private readonly ICanReload[] _reloads;

        public DashboardDataController(PageModelBuilder pageModelBuilder, IInitialiser initialiser, ICanReload[] reloads)
        {
            _initialiser = initialiser;
            _reloads = reloads;
            _initialiser.Load();
            _pageModelBuilder = pageModelBuilder;
            
        }

        [HttpGet]
        public PageModel Get()
        {
            var model = _pageModelBuilder.Build();
            var data = new PageModel()
            {
                IsSystemOnline = DataLoader.Instance.IsSystemOnline,
                Logs = model.Logs.OrderByDescending(d => d.Date),
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
            //DataLoader.Instance.Reload();
            _reloads.ForEach(f => f.Reload());
        }
    }
}
