using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.Complaint
{
    /// <summary>
    /// Dto za potvrđivanje žalbe
    /// </summary>
    public class ComplaintConfirmationDto
    {
        /// <summary>
        /// Broj rešenja
        /// </summary>
        public string procedureNumber { get; set; }

        /// <summary>
        /// Broj odluke ili nadmetanja
        /// </summary>
        public string decisionNumber { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        public DateTime dateOfComplaint { get; set; }

        /// <summary>
        /// Datum rešenja žalbe
        /// </summary>
        public DateTime dateOfProcedure { get; set; }
    }
}
