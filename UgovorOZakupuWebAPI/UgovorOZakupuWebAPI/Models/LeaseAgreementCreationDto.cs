using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Models
{
    public class LeaseAgreementCreationDto
    {
        public Guid LeaseAgreementId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? LandReturnDeadline { get; set; }
        public string PlaceOfSigning { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public bool? IsDelete { get; set; }

        [Required]
        public Guid ContractedPublicBiddingId { get; set; }
        [Required]
        public Guid ContractPartyId { get; set; }
        [Required]
        public Guid GuaranteeTypeId { get; set; }
        [Required]
        public Guid DecisionId { get; set; }
        public List<MaturityDeadline> MaturityDeadlines { get; set; }

    }
}
