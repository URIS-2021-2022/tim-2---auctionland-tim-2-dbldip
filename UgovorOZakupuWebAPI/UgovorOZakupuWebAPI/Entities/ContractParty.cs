using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet ucesnik ugovora
    /// </summary>
    public class ContractParty
    {
        /// <summary>
        /// ID ucesnika ugovora
        /// </summary>
        public Guid ContractPartyId { get; set; }
        //Od komisije celog ministra
    }
}
