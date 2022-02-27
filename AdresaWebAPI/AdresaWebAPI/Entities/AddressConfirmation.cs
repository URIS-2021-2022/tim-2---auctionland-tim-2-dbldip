using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    /// <summary>
    /// Confirmation of created address
    /// </summary>
    public class AddressConfirmation
    {
        /// <summary>
        /// ID of created address
        /// </summary>
        public Guid addressID { get; set; }
        /// <summary>
        /// Street of crerated address
        /// </summary>
        public string addressStreet { get; set; }
        /// <summary>
        /// Street number of created address
        /// </summary>
        public string addressNumber { get; set; }
        /// <summary>
        /// Town of created address
        /// </summary>
        public string addressTown { get; set; }
        /// <summary>
        /// Country of created address
        /// </summary>
        public string countryName { get; set; }
    }
}
