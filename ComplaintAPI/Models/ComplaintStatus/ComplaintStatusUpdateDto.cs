using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ComplaintStatus
{
    /// <summary>
    /// Dto za izmenu statusa žalbe
    /// </summary>
    public class ComplaintStatusUpdateDto
    {
        /// <summary>
        /// Status žalbe
        /// </summary>
        [Required(ErrorMessage = "Status žalbe je obavezno polje.")]
        public string complaintStatus { get; set; }
    }
}
