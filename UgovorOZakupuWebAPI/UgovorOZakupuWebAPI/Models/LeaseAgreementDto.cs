using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Models
{
    public class LeaseAgreementDto
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? LandReturnDeadline { get; set; }
        public string PlaceOfSigning { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public bool? IsDelete { get; set; }

        public ContractedPublicBidding ContractedPublicBidding { get; set; }
        public ContractParty ContractParty { get; set; }
        public GuaranteeType GuaranteeType { get; set; }
        public Document Decision { get; set; }
        public List<MaturityDeadline> MaturityDeadlines { get; set; }
    }
}
