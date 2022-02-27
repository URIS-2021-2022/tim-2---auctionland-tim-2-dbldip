using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Confirmation dto sent to user when creation is successful
    /// </summary>
    public class CountryConfirmationDto
    {
        /// <summary>
        /// Name of the newly created country
        /// </summary>
        public string countryName { get; set; }
    }
}
