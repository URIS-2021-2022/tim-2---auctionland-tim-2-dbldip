using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet dokument
    /// </summary>
    public class Document
    {
        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// serijski broj
        /// </summary>
        public string FileNumber { get; set; }
        /// <summary>
        /// datum
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// datum zakljucenja ugovora
        /// </summary>
        public DateTime? DocumentAdoptionDate { get; set; }
        /// <summary>
        /// template
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// ID autora dokumenta
        /// </summary>

        [ForeignKey("DocumentAuthor")]
        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// Autor dokumenta
        /// </summary>
        public DocumentAuthor DocumentAuthor { get; set; }

    }
}
