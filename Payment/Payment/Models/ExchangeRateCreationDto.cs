using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Models
{
    /// <summary>
    /// Exchange rate creation DTO
    /// </summary>
    public class ExchangeRateCreationDto
    {
        /// <summary>
        /// Currency name
        /// </summary>
        [Required]
        public string currencyName { get; set; }
        /// <summary>
        /// Currency code
        /// </summary>
        [Required]
        public string currencyCode { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        public float price { get; set; }
    }
}
