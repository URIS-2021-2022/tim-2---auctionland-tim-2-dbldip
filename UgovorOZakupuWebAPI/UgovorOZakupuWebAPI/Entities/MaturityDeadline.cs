using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{        /// <summary>
         /// rokovi dospeca
         /// </summary>
    public class MaturityDeadline
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid MaturityDeadlineId { get; set; }
        /// <summary>
        /// ugovoreno javno nadmetanje id
        /// </summary>
        [ForeignKey("LeaseAgreement")]
        public Guid LeaseAgreementId { get; set; }
        /// <summary>
        /// rok
        /// </summary>
        public int Deadline { get; set; }
    }
}
