using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Licitation application DTO
    /// </summary>
    public class LicitationApplicationDto
    {
        /// <summary>
        /// Application ID
        /// </summary>
        public Guid applicationId { get; set; }
        /// <summary>
        /// Application date
        /// </summary>
        public DateTime applicationDate { get; set; }
        /// <summary>
        /// Applied licitation ID
        /// </summary>
        public Guid appliedLicitationId { get; set; }
        /// <summary>
        /// Number of applied licitation
        /// </summary>
        public int licitationNumber { get; set; }
        /// <summary>
        /// Date of applied licitation
        /// </summary>
        public DateTime licitationDate { get; set; }
        /// <summary>
        /// Applier ID
        /// </summary>
        public Guid applierId { get; set; }
        /// <summary>
        /// Applier name
        /// </summary>
        public string applierName { get; set; }
        /// <summary>
        /// Applier adress
        /// </summary>
        public string applierAdress { get; set; }
        /// <summary>
        /// Priority ID
        /// </summary>
        public Guid priorityId { get; set; }
        /// <summary>
        /// Priority name
        /// </summary>
        public string priorityDescription { get; set; }
    }
}
