using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    /// <summary>
    /// Confirms licitation application
    /// </summary>
    public class LicitationApplicationConfirmation
    {
        /// <summary>
        /// Application ID
        /// </summary>
        public Guid applicationId { get; set; }
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
        /// <summary>
        /// Priority name
        /// </summary>
        public string priorityName { get; set; }
    }
}
