using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Id of the country
        /// </summary>
        [Key]
        public Guid countryID { get; set; }
        /// <summary>
        /// name of the country
        /// </summary>
        public string countryName { get; set; }
    }
}
