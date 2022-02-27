using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto kreiranje ugovora o zakupu
    /// </summary>
    public class LeaseAgreementCreationDto
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

        /// <summary>
        /// ugovoreno javno nadmetanje
        /// </summary>
        public ContractedPublicBidding ContractedPublicBidding { get; set; }
        /// <summary>
        /// ucesnik ugovora
        /// </summary>
        public ContractParty ContractParty { get; set; }
        /// <summary>
        /// tip garancije
        /// </summary>
        public GuaranteeType GuaranteeType { get; set; }
        /// <summary>
        /// odluka
        /// </summary>
        public Document Decision { get; set; }
        /// <summary>
        /// rokovi za vracanje
        /// </summary>
        public List<MaturityDeadline> MaturityDeadlines { get; set; }

    }
}
