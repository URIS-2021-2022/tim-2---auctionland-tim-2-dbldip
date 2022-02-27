using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Komisija update dto
    /// </summary>
    public class CommissionUpdateDto 
    {
        /// <summary>
        /// ID Komisija
        /// </summary>
        public Guid CommissionId { get; set; }
        /// <summary>
        /// Predsednik ID
        /// </summary>
        public Guid PresidentId { get; set; }
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
