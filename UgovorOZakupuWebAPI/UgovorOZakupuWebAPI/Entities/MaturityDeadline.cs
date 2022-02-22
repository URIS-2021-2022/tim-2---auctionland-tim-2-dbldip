using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class MaturityDeadline
    {
        public Guid MaturityDeadlineId { get; set; }

        [ForeignKey("LeaseAgreement")]
        public Guid LeaseAgreementId { get; set; }
//        public LeaseAgreement LeaseAgreement { get; set; }
        public int Deadline { get; set; }
    }
}
