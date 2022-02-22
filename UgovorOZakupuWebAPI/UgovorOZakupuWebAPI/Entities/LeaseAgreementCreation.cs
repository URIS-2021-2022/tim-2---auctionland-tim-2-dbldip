using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;

namespace UgovorOZakupuWebAPI.Entities
{
    public class LeaseAgreementCreation
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? LandReturnDeadline { get; set; }
        public string PlaceOfSigning { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public bool? IsDelete { get; set; }

        public Guid ContractedPublicBiddingId { get; set; }
        public Guid ContractPartyId { get; set; }
        public Guid GuaranteeTypeId { get; set; }
        public Guid DecisionId { get; set; }
        public List<MaturityDeadline> MaturityDeadlines { get; set; }
    }
}
