using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class DocumentConfirmation
    {
        public Guid DocumentId { get; set; }

        public string FileNumber { get; set; }

        public DateTime Date { get; set; }

        public DateTime DocumentAdoptionDate { get; set; }

        public string Template { get; set; }
    }
}
