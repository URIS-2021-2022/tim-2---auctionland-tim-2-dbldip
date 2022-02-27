using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet potvrda komisije
    /// </summary>
    public class CommissionConfirmation
    {
        /// <summary>
        /// ID komisije
        /// </summary>
        public Guid CommissionId { get; set; }
    }
}
