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
        public Guid payerId { get; set; }
        [Required]
        public string payerIdentificationNumber { get; set; }
        [Required]
        public string payerName { get; set; }
        public string payerAdress { get; set; }
        [Required]
        public string PaymentPurpose { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public Guid publicBiddingId { get; set; }
        [Required]
        public DateTime publicBiddingDate { get; set; }
        public int startingPricePerHectare { get; set; }
        public bool exception { get; set; }
        [Required]
        public int licitatedPrice { get; set; }
        [Required]
        public Guid exchangeRateId { get; set; }
        [Required]
        public string currencyName { get; set; }
        public string currencyCode { get; set; }
        [Required]
        public float price { get; set; }
    }
}
