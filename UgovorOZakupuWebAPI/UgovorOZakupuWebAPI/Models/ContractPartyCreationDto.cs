using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto kreacija ucesnika ugovora
    /// </summary>
    public class ContractPartyCreationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ContractPartyId { get; set; }
    }
}
