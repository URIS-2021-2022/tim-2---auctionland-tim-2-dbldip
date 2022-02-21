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
        //javno nadmetanje
        //lice
        //rokovi dospeca    
        [Key]
        public Guid LeaseAgreementId { get; set; }
        public string PlaceOfSigning { get; set; }
        public DateTime? DateOfSigning { get; set; }
        public DateTime? LandReturnDeadline { get; set; }
        public DateTime? RegistryDate { get; set; }
        public string SerialNumber { get; set; }

        [ForeignKey("GuaranteeType")]
        public Guid GuaranteeTypeId { get; set; }

        [ForeignKey("Document")]
        public Guid DecisionId { get; set; }

        [ForeignKey("Person")]
        public Guid MinisterId { get; set; }
    }
}
