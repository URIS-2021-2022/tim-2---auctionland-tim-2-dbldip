using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet kreacija ličnosti
    /// </summary>
    public class PersonConfirmation
    {
        /// <summary>
        /// ID ličnosti
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
