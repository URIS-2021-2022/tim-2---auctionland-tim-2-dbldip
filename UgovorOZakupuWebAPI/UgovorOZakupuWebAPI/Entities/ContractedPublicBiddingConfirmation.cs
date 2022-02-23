using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{    /// <summary>
     /// Entitet potvrda ugovoreno javno nadmetanje 
     /// </summary>
    public class ContractedPublicBiddingConfirmation
    {
        /// <summary>
        /// ID ugovorenog javnog nadmetanja
        /// </summary>
        public Guid ContractedPublicBiddingId { get; set; }
        /// <summary>
        /// dodatne informacije
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
