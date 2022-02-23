using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto azuriranje ugovora o zakupu
    /// </summary>
    public class LeaseAgreementUpdateDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid LeaseAgreementId { get; set; }
        /// <summary>
        /// serijski broj
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// datum zakljucivanja
        /// </summary>
        public DateTime? RecordDate { get; set; }
        /// <summary>
        ///rok za vracanje
        /// </summary>
        public DateTime? LandReturnDeadline { get; set; }
        /// <summary>
        /// mesto zakljucivanja
        /// </summary>
        public string PlaceOfSigning { get; set; }
        /// <summary>
        /// datum zakljucivanja
        /// </summary>
        public DateTime? DateOfSigning { get; set; }
        /// <summary>
        /// logicko brisanje
        /// </summary>
        public bool? IsDelete { get; set; }
        // <summary>
        /// ID ugovoreno javno nadmetanje
        /// </summary>
        public Guid ContractedPublicBiddingId { get; set; }
        /// <summary>
        /// ID ucesnik ugovora
        /// </summary>
        public Guid ContractPartyId { get; set; }
        /// <summary>
        /// ID tip garancije
        /// </summary>
        public Guid GuaranteeTypeId { get; set; }
        /// <summary>
        /// ID odluka
        /// </summary>
        public Guid DecisionId { get; set; }
        
    }
}
