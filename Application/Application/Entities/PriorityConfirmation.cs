using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    /// <summary>
    /// Confirms priority
    /// </summary>
    public class PriorityConfirmation
    {
        /// <summary>
        /// Priority ID
        /// </summary>
        public Guid priorityID { get; set; }
        /// <summary>
        /// Priority description
        /// </summary>
        public string priorityDescription { get; set; }
    }
}
