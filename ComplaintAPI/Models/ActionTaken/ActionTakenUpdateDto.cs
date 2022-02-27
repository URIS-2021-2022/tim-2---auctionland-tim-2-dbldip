using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ActionTaken
{
    /// <summary>
    /// Dto za izmenu radnje na osnovu žalbe
    /// </summary>
    public class ActionTakenUpdateDto
    {
        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        [Required(ErrorMessage = "Radnja na osnovu žalbe je obavezno polje.")]
        public string actionTaken { get; set; }
    }
}
