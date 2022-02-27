using AutoMapper;
using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Data
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly PaymentContext context;
        private readonly IMapper mapper;
        public ExchangeRateRepository(PaymentContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ExchangeRateConfirmation CreateExchangeRate(ExchangeRate exchangeRate)
        {
            var createdEntity = context.Add(exchangeRate);
            return mapper.Map<ExchangeRateConfirmation>(createdEntity.Entity);
        }

        public void DeleteExchangeRate(Guid exchangeRateId)
        {
            var exchangeRate = GetExchangeRateById(exchangeRateId);
            context.Remove(exchangeRate);
        }

        public ExchangeRate GetExchangeRateById(Guid exchangeRateId)
        {
            return context.ExchangeRates.FirstOrDefault(e => e.exchangeRateId == exchangeRateId);
        }

        public List<ExchangeRate> GetExchangeRates()
        {
            return context.ExchangeRates.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateExchangeRate(ExchangeRate exchangeRate)
        {
        }
    }
}
