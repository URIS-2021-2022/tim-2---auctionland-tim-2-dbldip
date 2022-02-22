using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Entities
{
    public class Payment
    {
        [Key]
        public Guid paymentId { get; set; }
        public string accountNumber { get; set; }
        public string referenceNumber { get; set; }
        public int amount { get; set; }

        #region buyer
        public Guid buyerId { get; set; }
        #endregion

        #region publicBidding
        public Guid publicBiddingId { get; set; }
        #endregion

        #region excangeRate
        public Guid exchangeRateId { get; set; }
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
        #endregion
    }
}
