using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Dto sent to server when targeting PUT endpoint
    /// </summary>
    public class AddressUpdateDto
    {
        /// <summary>
        /// address id which is being updated
        /// </summary>
        public Guid addressId { get; set; }
        /// <summary>
        /// new street name
        /// </summary>
        public string addressStreet { get; set; }
        /// <summary>
        /// new street number
        /// </summary>
        public string addressNumber { get; set; }
        /// <summary>
        /// new town name
        /// </summary>
        public string addressTown { get; set; }
        /// <summary>
        /// new municipality name
        /// </summary>
        public string addressMunicipality { get; set; }
        /// <summary>
        /// new postal code
        /// </summary>
        public string addressPostalCode { get; set; }
        /// <summary>
        /// new country id
        /// </summary>
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
