using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    /// <summary>
    /// Confirmation entity 
    /// </summary>
    public class CountryConfirmation
    {
        /// <summary>
        /// Id of created country
        /// </summary>
        public Guid countryId { get; set; }
        /// <summary>
        /// name of created country
        /// </summary>
        public string countryName { get; set; }
    }
}
