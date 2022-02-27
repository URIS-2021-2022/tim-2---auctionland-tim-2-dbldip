using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto potvrda ucesnika ugovora
    /// </summary>
    public class ContractPartyConfirmationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ContractPartyId { get; set; }
    }
}
