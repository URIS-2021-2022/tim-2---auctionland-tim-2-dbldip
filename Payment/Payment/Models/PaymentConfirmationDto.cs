using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class PaymentConfirmationDto
    {
        public string accountNumber { get; set; }
        public string referenceNumber { get; set; }
        public int amount { get; set; }
        public string payerIdentificationNumber { get; set; }
        public string payerName { get; set; }
        public string PaymentPurpose { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime publicBiddingDate { get; set; }
        public bool exception { get; set; }
        public int licitatedPrice { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
    }
}
