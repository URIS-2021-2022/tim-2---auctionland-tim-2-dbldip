using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class ContractedPublicBiddingConfirmation
    {
        public Guid ContractedPublicBiddingId { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
