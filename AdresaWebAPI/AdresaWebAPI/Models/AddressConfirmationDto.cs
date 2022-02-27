using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Dto of address confirmation
    /// </summary>
    public class AddressConfirmationDto
    {
        /// <summary>
        /// Street name
        /// </summary>
        public string addressStreet { get; set; }
        /// <summary>
        /// street number
        /// </summary>
        public string addressNumber { get; set; }
        /// <summary>
        /// town name
        /// </summary>
        public string addressTown { get; set; }
        /// <summary>
        /// country name
        /// </summary>
        public string countryName { get; set; }
    }
}
