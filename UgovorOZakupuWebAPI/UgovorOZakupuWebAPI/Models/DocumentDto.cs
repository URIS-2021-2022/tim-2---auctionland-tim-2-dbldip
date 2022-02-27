using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto dokument
    /// </summary>
    public class DocumentDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// broj dokumenta
        /// </summary>
        public string FileNumber { get; set; }
        /// <summary>
        /// datum
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// datum zakljucenja
        /// </summary>
        public DateTime? DocumentAdoptionDate { get; set; }
        /// <summary>
        /// sablon
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// ID autora dokumenta
        /// </summary>

        public Guid DocumentAuthorId { get; set; }
        /// <summary>
        /// autor dokumenta
        /// </summary>
        public DocumentAuthor DocumentAuthor { get; set; }
    }
}
