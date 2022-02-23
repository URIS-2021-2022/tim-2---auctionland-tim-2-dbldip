using ComplaintService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Predstavlja žalbu
/// </summary>
namespace ComplaintAPI.Entities
{
    public class Complaint
    {
        /// <summary>
        /// ID žalbe
        /// </summary>
        [Key]
        public Guid complaintId { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [Required]
        public Guid complaintTypeId { get; set; }

        /// <summary>
        /// Objekat tipa žalbe
        /// </summary>
        public ComplaintType complaintType { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        [Required]
        public DateTime dateOfComplaint { get; set; }

        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid personId { get; set; }

        /// <summary>
        /// Razlog žalbe
        /// </summary>
        [Required]
        public string complaintReaason { get; set; }

        /// <summary>
        /// Obrazloženje žalbe
        /// </summary>
        [Required]
        public string elaboration { get; set; } 

        /// <summary>
        /// Datum rešenja žalbe
        /// </summary>
        [Required]
        public DateTime dateOfProcedure { get; set; }


        /// <summary>
        /// Broj rešenja
        /// </summary>
        [Required]
        public string procedureNumber { get; set; }

        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [Required]
        public Guid complaintStatusId { get; set; }

        /// <summary>
        /// Objekat statusa žalbe
        /// </summary>
        public ComplaintStatus complaintStatus { get; set; }

        /// <summary>
        /// Broj odluke ili broj nadmetanja
        /// </summary>
        public string decisionNumber { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        public Guid actionTakenId { get; set; }

        /// <summary>
        /// Objekat radnje na osnovu žalbe
        /// </summary>
        public ActionTaken actionTaken { get; set; }


    }
}
