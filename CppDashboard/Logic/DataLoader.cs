using System;
using System.Collections.Generic;
using System.Linq;
using CppDashboard.DataProvider;
using CppDashboard.Models;

namespace CppDashboard.Logic
{
    public class DataLoader
    {
        private static readonly int InitialReadTimeDuration = 2;
        private static readonly DataLoader _instance = new DataLoader();
        private static bool _loaded;

        private IList<Log> _logs = new List<Log>();
        private List<Config> _configs = new List<Config>();
        private IList<PaymentEvent> _paymentEvents = new List<PaymentEvent>();
        private IList<Payment> _payments = new List<Payment>(); 

        public IEnumerable<Log> Logs
        {
            get
            {
                _logs = _logs
                    .Where(l => l.Date >= CutoffStartTime)
                    .OrderByDescending(o => o.Date)
                    .ToList();
                return _logs;
            }
        }

        public IEnumerable<PaymentEvent> MonitoringEvents
        {
            get
            {
                return _paymentEvents.OrderByDescending(o => o.EventDateTime);
            }
        }

        public string CurrentThroughput
        {
            get
            {
                return new ThroughputCalculator().CurrentThroughput(InitialReadTimeDuration * 60).ToString("F");
            }
        }

        public IEnumerable<Payment> Payments
        {
            get
            {
                return _payments;
            }
        }

        private DateTime CutoffStartTime
        {
            get
            {
                return DateTime.Now.AddMinutes(-InitialReadTimeDuration*120);
            }
        }

        public bool IsSystemOnline
        {
            get
            {
                var automatic = int.Parse(_configs.First(h => h.Key.Equals("Offline:Status")).Value);
                var manual = int.Parse(_configs.First(h => h.Key.Equals("Offline:ManualOverrideEnabled")).Value);

                if (automatic == 1 || manual == 1)
                {
                    return false;
                }

                return true;
            }
        }

        public static DataLoader Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Load()
        {
            lock (this)
            {
                if (_loaded)
                {
                    throw new InvalidOperationException("Data is already loaded");
                }

                LoadDataForGivenDuration();

                _loaded = true;    
            }
        }

        public void LoadSystemData()
        {
            
        }

        public void Reload()
        {
            new LoggingDataFacade().ReloadFrom(_logs.Max(m => m.Id), ref _logs);
            new PaymentsDataFacade().ReloadFrom(_payments.Max(m => m.PaymentId), ref _payments);
            new PaymentEventsDataFacade().ReloadFrom(_paymentEvents.Max(m => m.PaymentEventsId), ref _paymentEvents);
        }

        private void LoadDataForGivenDuration()
        {
            _logs = new List<Log>(new LoggingDataFacade().Load(InitialReadTimeDuration * 60));
            _configs = new List<Config>(new OfflineDataFacade().Load(InitialReadTimeDuration * 60));
            _paymentEvents = new List<PaymentEvent>(new PaymentEventsDataFacade().Load(InitialReadTimeDuration * 60));
            _payments = new List<Payment>(new PaymentsDataFacade().Load(InitialReadTimeDuration * 60));
        }
    }
}