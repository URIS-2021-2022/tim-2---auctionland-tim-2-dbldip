using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet ličnost
    /// </summary>
    public class Person
    {
        /// <summary>
        /// ID ličnost
        /// </summary>
        [Key]
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
