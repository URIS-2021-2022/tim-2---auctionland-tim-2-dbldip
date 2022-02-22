using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    /// <summary>
    /// Priority of application
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// Priority ID
        /// </summary>
        [Key]
        public Guid priorityID { get; set; }
        /// <summary>
        /// Priority description
        /// </summary>
        public string priorityDescription { get; set; }

    }
}
