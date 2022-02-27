using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Ličnost potvrda dto
    /// </summary>
    public class PersonConfirmationDto
    {

        /// <summary>
        /// ID Ličnost
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Ime
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Prezime
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Uloga
        /// </summary>
        public string Role { get; set; }
    }
}
