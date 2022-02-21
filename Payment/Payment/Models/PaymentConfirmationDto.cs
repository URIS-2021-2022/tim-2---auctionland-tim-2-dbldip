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
        public string referenceNumber { get; set; }
        public int amount { get; set; }
        public Guid buyerId { get; set; }
        public int realizedArea { get; set; }
        public int banDuration { get; set; }
        public string PaymentPurpose { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime date { get; set; }
        public List<Plot> plots { get; set; }
        public double bestBid { get; set; }
        public Guid bestBidder { get; set; }
        public double leasePeriod { get; set; }
        public string currencyCode { get; set; }
        public float price { get; set; }
    }
}
