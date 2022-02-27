using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet potvrda dokumenta
    /// </summary>
    public class DocumentConfirmation
    {
        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// serijski broj
        /// </summary>
        public string FileNumber { get; set; }
    }
}
