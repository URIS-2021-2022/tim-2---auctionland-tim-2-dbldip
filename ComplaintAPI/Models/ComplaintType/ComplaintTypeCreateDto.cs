using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ComplaintType
{
    /// <summary>
    /// Dto za kreiranje tipa žalbe
    /// </summary>
    public class ComplaintTypeCreateDto
    {
        
        /// <summary>
        /// Tip žalbe
        /// </summary>
        [Required(ErrorMessage = "Tip žalbe je obavezno polje.")]
        public string complaintType { get; set; }
    }
}
