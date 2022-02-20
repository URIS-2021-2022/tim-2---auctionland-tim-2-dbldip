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

        #region payer
        public Guid payerId { get; set; }
        public string payerIdentificationNumber { get; set; }
        public string payerName { get; set; }
        public string payerAdress { get; set; }
        #endregion

        public string PaymentPurpose { get; set; }
        public DateTime PaymentDate { get; set; }
        
        #region publicBidding
        public Guid publicBiddingId { get; set; }
        public DateTime publicBiddingDate { get; set; }
        public int startingPricePerHectare { get; set; }
        public bool exception { get; set; }
        public int licitatedPrice { get; set; }
        #endregion

        #region excangeRate
        public Guid exchangeRateId { get; set; }
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
        #endregion
    }
}
