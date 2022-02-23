using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto autor dokumenta
    /// </summary>
    public class DocumentAuthorDto
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
