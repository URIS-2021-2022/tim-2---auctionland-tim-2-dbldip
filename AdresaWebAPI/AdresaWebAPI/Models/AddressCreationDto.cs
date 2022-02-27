using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Dto sent when targeting POST endpoint
    /// </summary>
    public class AddressCreationDto
    {
        /// <summary>
        /// street name
        /// </summary>
        [Required]
        public string addressStreet { get; set; }
        /// <summary>
        /// street number
        /// </summary>
        [Required]
        public string addressNumber { get; set; }
        /// <summary>
        /// town
        /// </summary>
        [Required]
        public string addressTown { get; set; }
        /// <summary>
        /// municipality name
        /// </summary>
        [Required]
        public string addressMunicipality { get; set; }
        /// <summary>
        /// postal code
        /// </summary>
        [Required]
        public string addressPostalCode { get; set; }
        /// <summary>
        /// country id
        /// </summary>
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
