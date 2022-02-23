using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    /// <summary>
    /// Payment
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Payment ID
        /// </summary>
        [Key]
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

        #region buyer
        /// <summary>
        /// Buyer ID
        /// </summary>
        public Guid buyerId { get; set; }
        #endregion

        #region publicBidding
        /// <summary>
        /// Public bidding ID
        /// </summary>
        public Guid publicBiddingId { get; set; }
        #endregion

        #region excangeRate
        /// <summary>
        /// Exchange rate ID
        /// </summary>
        public Guid exchangeRateId { get; set; }
        #endregion
    }
}
