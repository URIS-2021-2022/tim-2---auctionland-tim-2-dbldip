using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto kreiranje ugovorenog javnog nadmetanja
    /// </summary>
    public class ContractedPublicBiddingCreationDto
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid ContractedPublicBiddingId { get; set; }
        /// <summary>
        /// dodatne informacije
        /// </summary>

        public string AdditionalInfo { get; set; }
    }
}
