using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Ličnost update dto
    /// </summary>
    public class PersonUpdateDto
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
