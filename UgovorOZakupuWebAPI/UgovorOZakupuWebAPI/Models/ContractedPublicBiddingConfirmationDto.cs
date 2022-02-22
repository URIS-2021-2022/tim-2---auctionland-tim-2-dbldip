using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    public class ContractedPublicBiddingConfirmationDto
    {
        public Guid ContractedPublicBiddingId { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
