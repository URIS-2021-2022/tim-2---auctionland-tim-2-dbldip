using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    public class ExchangeRateCreationDto
    {
        [Required]
        public string currencyName { get; set; }
        [Required]
        public string currencyCode { get; set; }
        [Required]
        public float price { get; set; }
    }
}
