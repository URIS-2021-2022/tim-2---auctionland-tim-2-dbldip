using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class LeaseAgreementWithLists
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? LandReturnDeadline { get; set; }
        public string PlaceOfSigning { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public bool? IsDelete { get; set; }
        public int[] MaturityDeadlines { get; set; }

        [ForeignKey("ContractedPublicBidding")]
        public Guid ContractedPublicBiddingId { get; set; }
        public ContractedPublicBidding ContractedPublicBidding { get; set; }

        [ForeignKey("ContractParty")]
        public Guid ContractPartyId { get; set; }
        public ContractParty ContractParty { get; set; }

        [ForeignKey("GuaranteeType")]
        public Guid GuaranteeTypeId { get; set; }
        public GuaranteeType GuaranteeType { get; set; }

        [ForeignKey("Decision")]
        public Guid DecisionId { get; set; }
        public Document Decision { get; set; }
    }
}
