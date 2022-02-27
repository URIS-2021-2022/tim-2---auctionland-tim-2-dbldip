using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public interface IExchangeRateRepository
    {
        List<ExchangeRate> GetExchangeRates();
        ExchangeRate GetExchangeRateById(Guid exchangeRateId);
        ExchangeRateConfirmation CreateExchangeRate(ExchangeRate exchangeRate);
        void UpdateExchangeRate(ExchangeRate exchangeRate);
        void DeleteExchangeRate(Guid exchangeRateId);
        bool SaveChanges();
    }
}
