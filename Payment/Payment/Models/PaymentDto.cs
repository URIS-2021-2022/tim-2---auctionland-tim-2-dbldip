using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    /// <summary>
    /// Payment DTO
    /// </summary>
    public class PaymentDto
    {
        /// <summary>
        /// Payment ID
        /// </summary>
        public Guid paymentId { get; set; }
        /// <summary>
        /// Account number
        /// </summary>
        public string accountNumber { get; set; }
        /// <summary>
        /// Reference number
        /// </summary>
        public string referenceNumber { get; set; }
        /// <summary>
        /// Amount
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
        /// Exchange rate ID
        /// </summary>
        public Guid exchangeRateId { get; set; }
    }
}
