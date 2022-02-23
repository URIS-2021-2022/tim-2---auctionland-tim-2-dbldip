using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet ugovoreno javno nadmetanje
    /// </summary>
    public class ContractedPublicBidding
    {
        /// <summary>
        /// Javno nadmetanje id
        /// </summary>
        public Guid ContractedPublicBiddingId { get; set; }
        /// <summary>
        /// dodatne informacijes
        /// </summary>
        public string AdditionalInfo { get; set; }

        //javno nadmetanje servis
    }
}
