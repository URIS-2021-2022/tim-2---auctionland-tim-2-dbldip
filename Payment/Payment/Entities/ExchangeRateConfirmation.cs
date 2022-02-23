using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    /// <summary>
    /// Exchange rate confirmation
    /// </summary>
    public class ExchangeRateConfirmation
    {
        /// <summary>
        /// Exchange rate ID
        /// </summary>
        public Guid exchangeRateId { get; set; }
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
