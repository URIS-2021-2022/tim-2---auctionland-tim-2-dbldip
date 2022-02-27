using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Create ličnost dto
    /// </summary>
    public class PersonCreationDto
    {
        /// <summary>
        /// Ime
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Uloga
        /// </summary>
        [Required]
        public string Role { get; set; }
       
    }
}
