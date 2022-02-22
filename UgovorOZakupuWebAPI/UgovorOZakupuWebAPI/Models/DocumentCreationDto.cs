using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    public class DocumentCreationDto
    {
        public Guid DocumentId { get; set; }
        public string FileNumber { get; set; }

    }
}
