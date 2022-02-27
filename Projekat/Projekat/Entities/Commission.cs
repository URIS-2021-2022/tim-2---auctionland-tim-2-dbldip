using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet komisija
    /// </summary>
    public class Commission
    {
        /// <summary>
        /// ID komisije
        /// </summary>
        public Guid CommissionId { get; set; }

        /// <summary>
        /// ID predsednika
        /// </summary>
        [ForeignKey("President")]
        public Guid PresidentId { get; set; }
        /// <summary>
        /// Entitet predsednik
        /// </summary>
        public Person President { get; set; }

        /// <summary>
        /// Lista članova
        /// </summary>
        [NotMapped]
        public List<Members> Members { get; set; }

    }
}
