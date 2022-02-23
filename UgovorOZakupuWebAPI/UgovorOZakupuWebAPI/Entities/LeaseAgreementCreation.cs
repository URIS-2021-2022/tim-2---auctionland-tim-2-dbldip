using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Data;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet kreacija ugovora o zakupu
    /// </summary>
    public class LeaseAgreementCreation
    {
        /// <summary>
        /// ID ugovora o zakupu
        /// </summary>
        public Guid LeaseAgreementId { get; set; }
        /// <summary>
        /// serijski broj
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Datum
        /// </summary>
        public DateTime? RecordDate { get; set; }
        /// <summary>
        /// Rok za vracanje
        /// </summary>
        public DateTime? LandReturnDeadline { get; set; }
        /// <summary>
        /// Mesto potpisivanja
        /// </summary>
        public string PlaceOfSigning { get; set; }
        /// <summary>
        /// Datum potpisivanja
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
        /// lista rokova
        /// </summary>
        public List<MaturityDeadline> MaturityDeadlines { get; set; }
    }
}
