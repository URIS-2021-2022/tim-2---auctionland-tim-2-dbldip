using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// dto sent to user when targeting GET endpoint
    /// </summary>
    public class CountryDto
    {
        /// <summary>
        /// country id
        /// </summary>
        public Guid countryId { get; set; }
        /// <summary>
        /// country name
        /// </summary>
        public string countryName { get; set; }
    }
}
