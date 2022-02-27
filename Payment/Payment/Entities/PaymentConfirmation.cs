using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    /// <summary>
    /// Payment confirmation
    /// </summary>
    public class PaymentConfirmation
    {
        /// <summary>
        /// Payment ID
        /// </summary>
        public Guid paymentId { get; set; }
        /// <summary>
        /// Payment account number
        /// </summary>
        public string accountNumber { get; set; }
        /// <summary>
        /// Payment reference number
        /// </summary>
        public string referenceNumber { get; set; }
        /// <summary>
        /// Payment amount
        /// </summary>
        public int amount { get; set; }
        /// <summary>
        /// Buyer ID
        /// </summary>
        public Guid buyerId { get; set; }
        /// <summary>
        /// Public bidding ID
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// Payment purpose
        /// </summary>
        public string PaymentPurpose { get; set; }
        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// Exchange rate ID
        /// </summary>
        public Guid exchangeRateId { get; set; }

    }
}
