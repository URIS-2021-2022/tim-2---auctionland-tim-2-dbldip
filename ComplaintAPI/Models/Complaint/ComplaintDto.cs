using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models
{
    /// <summary>
    /// Dto za žalbu
    /// </summary>
    public class ComplaintDto
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        public Guid complaintId { get; set; }

        /// <summary>
        /// Tip žalbe id
        /// </summary>
        public string complaintType { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        public DateTime dateOfComplaint { get; set; }

        /// <summary>
        /// Podnosilac žalbe - Mikroservis Kupac
        /// </summary>
        public string buyer { get; set; }

        /// <summary>
        /// Razlog žalbe
        /// </summary>
        public string complaintReason { get; set; }

        /// <summary>
        /// Obrazloženje žalbe
        /// </summary>
        public string elaboration { get; set; }

        /// <summary>
        /// Datum rešenja žalbe
        /// </summary>
        public DateTime dateOfProcedure { get; set; }

        /// <summary>
        /// Broj rešenja
        /// </summary>
        public string procedureNumber { get; set; }

        /// <summary>
        /// Status žalbe
        /// </summary>
        public string complaintStatus { get; set; }

        /// <summary>
        /// Broj odluke ili broj nadmetanja
        /// </summary>
        public string decisionNumber { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        public string actionTaken { get; set; }
    }
}
