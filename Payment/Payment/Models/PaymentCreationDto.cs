using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class PaymentCreationDto
    {
        [Required]
        public string accountNumber { get; set; }
        [Required]
        public string referenceNumber { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public Guid buyerId { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }
        [Required]
        public string PaymentPurpose { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public Guid publicBiddingId { get; set; }
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public List<Plot> plots { get; set; }
        public double bestBid { get; set; }
        public Guid bestBidder { get; set; }
        public double leasePeriod { get; set; }
        [Required]
        public Guid exchangeRateId { get; set; }
        [Required]
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        [Required]
        public float price { get; set; }
    }
}
