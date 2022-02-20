using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    public class ExchangeRate
    {
        public Guid exchangeRateId { get; set; }
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        public double currencyPrice { get; set; }
    }
}
