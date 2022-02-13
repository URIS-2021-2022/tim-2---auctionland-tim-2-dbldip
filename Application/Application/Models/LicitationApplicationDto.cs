using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LicitationApplicationDto
    {
        public DateTime applicationDate { get; set; }
        public Guid appliedLicitationId { get; set; }
        public int licitationNumber { get; set; }
        public DateTime licitationDate { get; set; }
        public Guid applierId { get; set; }
        public string applierName { get; set; }
        public string applierAdress { get; set; }
        public Guid priorityId { get; set; }
        public string priorityDescription { get; set; }
    }
}
