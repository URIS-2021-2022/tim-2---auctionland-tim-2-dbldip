using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ComplaintStatus
{
    /// <summary>
    /// Dto za status žalbe
    /// </summary>
    public class ComplaintStatusDto
    {
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        public Guid complaintStatusId { get; set; }

        /// <summary>
        /// Status žalbe
        /// </summary>
        public string complaintStatus { get; set; }
    }
}
