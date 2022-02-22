using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Licitation application creation DTO
    /// </summary>
    public class LicitationApplicationCreationDto
    {
        /// <summary>
        /// Application date
        /// </summary>
        [Required]
        public DateTime applicationDate { get; set; }
        /// <summary>
        /// Applied licitation ID
        /// </summary>
        [Required]
        public Guid appliedLicitationId { get; set; }
        /// <summary>
        /// Number of applied licitation
        /// </summary>
        [Required]
        public int licitationNumber { get; set; }
        /// <summary>
        /// Date of applied licitation
        /// </summary>
        [Required]
        public DateTime licitationDate { get; set; }
        /// <summary>
        /// Applier ID
        /// </summary>
        [Required]
        public Guid applierId { get; set; }
        /// <summary>
        /// Applier name
        /// </summary>
        [Required]
        public string applierName { get; set; }
        /// <summary>
        /// Applier adress
        /// </summary>
        public string applierAdress { get; set; }
        /// <summary>
        /// Priority ID
        /// </summary>
        [Required]
        public Guid priorityId { get; set; }
    }
}
