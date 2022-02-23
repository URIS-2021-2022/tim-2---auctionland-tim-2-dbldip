using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet potvrda ucesnika ugovora
    /// </summary>
    public class ContractPartyConfirmation
    {
        /// <summary>
        /// ID ucenika ugovora
        /// </summary>
        public Guid ContractPartyId { get; set; }
    }
}
