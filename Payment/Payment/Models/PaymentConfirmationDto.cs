using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class PaymentConfirmationDto
    {
        public string accountNumber { get; set; }
        public int amount { get; set; }
        public Guid buyerId { get; set; }
        public Guid publicBiddingId { get; set; }
        public Guid exchangeRateId { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
    }
}
