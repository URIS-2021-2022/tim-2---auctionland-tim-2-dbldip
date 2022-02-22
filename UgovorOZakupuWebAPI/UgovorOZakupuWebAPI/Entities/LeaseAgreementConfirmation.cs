using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class LeaseAgreementConfirmation
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
    }
}
