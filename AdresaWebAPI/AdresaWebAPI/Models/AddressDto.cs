using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    /// <summary>
    /// Dto sent to user when targeting GET endpoint
    /// </summary>
    public class AddressDto
    {
        /// <summary>
        /// Address id
        /// </summary>
        public Guid addressId { get; set; }
        /// <summary>
        /// Street name + number
        /// </summary>
        public string completeAddress { get; set; }
        /// <summary>
        /// Town name, municipality name, postal code
        /// </summary>
        public string townInfo { get; set; }
        /// <summary>
        /// country name
        /// </summary>
        public string country { get; set; }
    }
}
