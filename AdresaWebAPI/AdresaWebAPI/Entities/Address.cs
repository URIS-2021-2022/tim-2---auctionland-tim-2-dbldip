using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    /// <summary>
    /// Address entity, used as template in the database
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Id value
        /// </summary>
        public Guid addressId { get; set; }
        /// <summary>
        /// Street name
        /// </summary>
        public string addressStreet { get; set; }
        /// <summary>
        /// Street number
        /// </summary>
        public string addressNumber { get; set; }
        /// <summary>
        /// Town name
        /// </summary>
        public string addressTown { get; set; }
        /// <summary>
        /// Municipality name
        /// </summary>
        public string addressMunicipality { get; set; }
        /// <summary>
        /// Town postal code
        /// </summary>
        public string addressPostalCode { get; set; }
        /// <summary>
        /// Country id
        /// </summary>
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
