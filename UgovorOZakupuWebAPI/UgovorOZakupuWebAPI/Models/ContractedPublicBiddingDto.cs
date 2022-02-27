using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto ugovoreno javno nadmetanje
    /// </summary>
    public class ContractedPublicBiddingDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ContractedPublicBiddingId { get; set; }
        /// <summary>
        /// dodatne informacije
        /// </summary>
        public string AdditionalInfo { get; set; }
    }
}
