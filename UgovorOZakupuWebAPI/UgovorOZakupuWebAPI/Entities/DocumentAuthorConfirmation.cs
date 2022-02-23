using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet potvrda autora dokumenta
    /// </summary>
    public class DocumentAuthorConfirmation
    {
        /// <summary>
        /// ID autora dokumenta
        /// </summary>
        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// Informacije o agenciji
        /// </summary>
        public string AgencyInfo { get; set; }
    }
}
