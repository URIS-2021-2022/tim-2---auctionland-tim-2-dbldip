using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    /// <summary>
    /// Exchange rate update DTO
    /// </summary>
    public class ExchangeRateUpdateDto
    {
        /// <summary>
        /// Exchange rate ID
        /// </summary>
        public Guid exchangeRateId { get; set; }
        /// <summary>
        /// Currency name
        /// </summary>
        public string currencyName { get; set; }
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
