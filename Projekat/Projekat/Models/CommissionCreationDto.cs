using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{        
    /// <summary>
    /// Create Komisija
    /// </summary>
    public class CommissionCreationDto 
    {
        /// <summary>
        /// Predsednik
        /// </summary>
        public Person President { get; set; }
        /// <summary>
        /// Lista članova
        /// </summary>
        public List<Members> Members { get; set; }

    }
}
