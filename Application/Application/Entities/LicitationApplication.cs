using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    /// <summary>
    /// Licitation application
    /// </summary>
    public class LicitationApplication
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [Key]
        public Guid applicationId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Application date
        /// </summary>
        public DateTime applicationDate { get; set; }

        #region appliedLicitation
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
        #endregion

        #region applier
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
        #endregion

        #region priority
        /// <summary>
        /// Priority ID
        /// </summary>
        public Guid priorityId { get; set; }
        /// <summary>
        /// Priority name
        /// </summary>
        public string priorityName { get; set; }
        #endregion
    }
}
