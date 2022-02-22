using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    public class LeaseAgreementConfirmationDto
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
    }
}
