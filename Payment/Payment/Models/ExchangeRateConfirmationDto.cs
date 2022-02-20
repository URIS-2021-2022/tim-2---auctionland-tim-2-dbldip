using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class ExchangeRateConfirmationDto
    {
        public string currencyCode { get; set; }
        public float price { get; set; }
    }
}
