using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet Autor dokumenta
    /// </summary>
    public class DocumentAuthor
    {
        /// <summary>
        /// ID autora dokmenta
        /// </summary>
        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// Informacije o agenciji
        /// </summary>
        public string AgencyInfo { get; set; }
        //od korisnika sistema ime prezime
    }
}
