using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Dto Potvrda Komisija
    /// </summary>
    public class CommissionConfirmationDto 
    {
        /// <summary>
        /// ID Komisija
        /// </summary>
        public Guid CommissionId { get; set; }
    }
}
