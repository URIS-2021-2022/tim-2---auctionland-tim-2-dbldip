using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Entities
{
    /// <summary>
    /// Predstavlja status žalbe
    /// </summary>
    public class ComplaintStatus
    {
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [Key]
        public Guid complaintStatusId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Status žalbe
        /// </summary>
        [Required]
        public string complaintStatus { get; set; }
    }
}
