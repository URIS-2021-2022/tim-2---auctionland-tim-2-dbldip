using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LicitationApplicationConfirmationDto
    {
        public DateTime applicationDate { get; set; }
        public int licitationNumber { get; set; }
        public string applierName { get; set; }
        public string priorityDescriptionpriorityDescription { get; set; }
    }
}
