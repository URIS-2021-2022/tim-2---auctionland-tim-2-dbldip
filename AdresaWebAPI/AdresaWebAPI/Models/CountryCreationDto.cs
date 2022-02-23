using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Dto sent to server when targeting POST endpoint
    /// </summary>
    public class CountryCreationDto
    {
        /// <summary>
        /// New country name
        /// </summary>
        [Required]
        public string countryName { get; set; }
    }
}
