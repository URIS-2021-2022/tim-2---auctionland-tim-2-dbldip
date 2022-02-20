using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class ExchangeRateUpdateDto
    {
        public Guid exchangeRateId { get; set; }
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
    }
}
