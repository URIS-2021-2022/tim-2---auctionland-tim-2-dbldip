using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto potvrde ugovora o zakupu
     /// </summary>
    public class LeaseAgreementConfirmationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid LeaseAgreementId { get; set; }
        /// <summary>
        /// serijski broj
        /// </summary>
        public string SerialNumber { get; set; }
    }
}
