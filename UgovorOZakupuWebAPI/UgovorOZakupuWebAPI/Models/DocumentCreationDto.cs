using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto kreiranje dokumenta
    /// </summary>
    public class DocumentCreationDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// broj dokumenta
        /// </summary>
        public string FileNumber { get; set; }

    }
}
