using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet članovi
    /// </summary>
    public class Members
    {
        /// <summary>
        /// Deo kompozitnog ključa
        /// </summary>
        [Required]
        public Guid CommissionId { get; set; }

        /// <summary>
        /// Deo kompozitnog ključa
        /// </summary>
        [Required]
        public Guid PersonId { get; set; }
    }
}
