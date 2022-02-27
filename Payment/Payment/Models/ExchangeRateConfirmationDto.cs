using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    /// <summary>
    /// Exchange rate confirmation DTO
    /// </summary>
    public class ExchangeRateConfirmationDto
    {
        /// <summary>
        /// Currency code
        /// </summary>
        public string currencyCode { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public float price { get; set; }
    }
}
