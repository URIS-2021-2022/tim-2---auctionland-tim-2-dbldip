using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Priority DTO
    /// </summary>
    public class PriorityDto
    {
        /// <summary>
        /// Priority ID
        /// </summary>
        public Guid priorityId { get; set; }
        /// <summary>
        /// Priority description
        /// </summary>
        public string priorityDescription { get; set; }
    }
}
