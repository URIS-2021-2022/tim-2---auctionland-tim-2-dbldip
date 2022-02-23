using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto potvrda autora dokumenta
    /// </summary>
    public class DocumentAuthorConfirmationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// informacije o agenciji
        /// </summary>
        public string AgencyInfo { get; set; }
    }
}
