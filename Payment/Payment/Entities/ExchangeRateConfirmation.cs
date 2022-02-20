using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    public class ExchangeRateConfirmation
    {
        public Guid exchangeRateId { get; set; }
        public string currencyCode { get; set; }
        public double currencyPrice { get; set; }
    }
}
