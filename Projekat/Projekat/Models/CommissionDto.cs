using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Komisija Dto
    /// </summary>
    public class CommissionDto
    {
        /// <summary>
        /// ID Komisija
        /// </summary>
        public Guid CommissionId { get; set; }

        /// <summary>
        /// Predsednik
        /// </summary>
        public Person President { get; set; }

        /// <summary>
        /// Lista ključeva članova
        /// </summary>
        public List<Members> Members { get; set; }
    }
}
