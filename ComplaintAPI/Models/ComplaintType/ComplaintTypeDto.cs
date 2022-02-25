using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ComplaintType
{
    /// <summary>
    /// Dto za tip žalbe
    /// </summary>
    public class ComplaintTypeDto
    {
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        public Guid complaintTypeId { get; set; }

        /// <summary>
        /// Tip žalbe
        /// </summary>
        public string complaintType { get; set; }
    }
}
