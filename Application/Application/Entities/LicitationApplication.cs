using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class LicitationApplication
    {
        [Key]
        public Guid applicationId { get; set; } = Guid.NewGuid();
        public DateTime applicationDate { get; set; }

        #region appliedLicitation
        public Guid appliedLicitationId { get; set; }
        public int licitationNumber { get; set; }

        public DateTime licitationDate { get; set; }
        #endregion

        #region applier
        public Guid applierId { get; set; }
        public string applierName { get; set; }
        public string applierAdress { get; set; }
        #endregion

        #region priority
        public  Guid priorityId { get; set; }

        public string priorityName { get; set; }
        #endregion
    }
}
