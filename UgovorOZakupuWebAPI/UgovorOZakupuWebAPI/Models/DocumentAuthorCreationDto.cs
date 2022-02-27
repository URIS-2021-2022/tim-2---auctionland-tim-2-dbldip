using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto Create oglas
    /// </summary>
    public class DocumentAuthorCreationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// Dto agencija informacije
        /// </summary>
        public string AgencyInfo { get; set; }
    }
}
