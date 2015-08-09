using CppDashboard.DataProvider;

namespace CppDashboard.Models
{
    public interface IInitialiser
    {
        void Load();
    }

    public class ShortTermDataInitialiser : IInitialiser
    {
        private bool _loaded;
        private readonly DataCanLoadBase<Log> _logsBase;
        private readonly ICanLoad<OfflineConfig> _offlineConfigs;
        private readonly DataCanLoadBase<PaymentEvent> _paymentEventsAll;
        private readonly DataCanLoadBase<Payment> _paymentAll;

        public ShortTermDataInitialiser(DataCanLoadBase<Log> logsBase, ICanLoad<OfflineConfig> offlineConfigs, 
            DataCanLoadBase<PaymentEvent> paymentEventsAll, DataCanLoadBase<Payment> paymentAll)
        {
            _logsBase = logsBase;
            _offlineConfigs = offlineConfigs;
            _paymentEventsAll = paymentEventsAll;
            _paymentAll = paymentAll;
        }

        public void Load()
        {
            if (_loaded) return;

            _logsBase.Load();
            _offlineConfigs.Load();
            _paymentEventsAll.Load();
            _paymentAll.Load();
            _loaded = true;
        }
    }

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