using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    /// <summary>
    /// Exchange rate
    /// </summary>
    public class ExchangeRate
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
        /// Currency price
        /// </summary>
        public double currencyPrice { get; set; }
    }
}
