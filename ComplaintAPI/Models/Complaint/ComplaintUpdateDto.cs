using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.Complaint
{
    /// <summary>
    /// Dto za izmenu žalbe
    /// </summary>
    public class ComplaintUpdateDto
    {
        /// <summary>
        /// Tip žalbe id
        /// </summary>
        [Required(ErrorMessage = "Tip žalbe je obavezno polje.")]
        public Guid complaintTypeId { get; set; }

        /// <summary>
        /// Datum podnošenja žalbe
        /// </summary>
        [Required(ErrorMessage = "Datum podnošenja žalbe je obavezno polje.")]
        public DateTime dateOfComplaint { get; set; }

        /// <summary>
        /// Podnosilac žalbe - Mikroservis Kupac
        /// </summary>
        public Guid personId { get; set; }

        /// <summary>
        /// Razlog žalbe
        /// </summary>
        [Required(ErrorMessage = "Razlog žalbe je obavezno polje.")]
        public string complaintReason { get; set; }

        /// <summary>
        /// Obrazloženje žalbe
        /// </summary>
        [Required(ErrorMessage = "Obrazloženje žalbe je obavezno polje.")]
        public string elaboration { get; set; }

        /// <summary>
        /// Datum rešenja žalbe
        /// </summary>
        [Required(ErrorMessage = "Datum rešenja je obavezno polje.")]
        public DateTime dateOfProcedure { get; set; }

        /// <summary>
        /// Broj rešenja
        /// </summary>
        [Required(ErrorMessage = "Broj rešenja je obavezno polje.")]
        public string procedureNumber { get; set; }

        /// <summary>
        /// Status žalbe
        /// </summary>
        [Required(ErrorMessage = "Status žalbe je obavezno polje")]
        public Guid complaintStatusId { get; set; }

        /// <summary>
        /// Broj odluke ili broj nadmetanja
        /// </summary>
        public string decisionNumber { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        public Guid actionTakenId { get; set; }

        /// <summary>
        /// Validacija vrednosti za kreiranje žalbe.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (dateOfComplaint > dateOfProcedure)
            {
                yield return new ValidationResult(
                    "Datum žalbe ne može biti nakon datuma rešenja.",
                    new[] { "ComplaintCreateDto" });
            }

            if (dateOfComplaint > DateTime.Now || dateOfProcedure > DateTime.Now)
            {
                yield return new ValidationResult(
                    "Navedeni datumi ne mogu biti u budućnosti",
                    new[] { "ComplaintCreateDto" });
            }
            //Dodati validaciju da proveri da li kupac postoji
        }
    }
}
