using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    /// <summary>
    /// Payment creation DTO
    /// </summary>
    public class PaymentCreationDto
    {
        /// <summary>
        /// Acount number
        /// </summary>
        [Required]
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
