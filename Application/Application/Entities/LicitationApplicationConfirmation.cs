using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class LicitationApplicationConfirmation
    {
        public Guid applicationId { get; set; }
        public DateTime applicationDate { get; set; }
        public int licitationNumber { get; set; }
        public string applierName { get; set; }
        public string priorityName { get; set; }
    }
}
