using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class Document
    {
        public Guid DocumentId { get; set; }
        public string FileNumber { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DocumentAdoptionDate { get; set; }
        public string Template { get; set; }

        [ForeignKey("DocumentAuthor")]
        public Guid DocumentAuthorId { get; set; }
        public DocumentAuthor DocumentAuthor { get; set; }

    }
}
