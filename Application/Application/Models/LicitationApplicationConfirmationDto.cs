using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Licitation application confirmation DTO
    /// </summary>
    public class LicitationApplicationConfirmationDto
    {
        /// <summary>
        /// Application date
        /// </summary>
        public DateTime applicationDate { get; set; }
        /// <summary>
        /// Number of applied licitation
        /// </summary>
        public int licitationNumber { get; set; }
        /// <summary>
        /// Applier name
        /// </summary>
        public string applierName { get; set; }
        public string priorityDescription { get; set; }
    }
}
