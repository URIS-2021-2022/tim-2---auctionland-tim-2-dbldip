using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Entities
{
    /// <summary>
    /// Predstavlja tip žalbe
    /// </summary>
    public class ComplaintType
    {
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [Key]
        public Guid complaintTypeId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Tip žalbe
        /// </summary>
        [Required]
        public string complaintType { get; set; }
    }
}
