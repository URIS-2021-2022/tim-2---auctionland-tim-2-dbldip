using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LicitationApplicationCreationDto
    {
        [Required]
        public DateTime applicationDate { get; set; }
        [Required]
        public Guid appliedLicitationId { get; set; }
        [Required]
        public int licitationNumber { get; set; }
        [Required]
        public DateTime licitationDate { get; set; }
        [Required]
        public Guid applierId { get; set; }
        [Required]
        public string applierName { get; set; }
        public string applierAdress { get; set; }
        [Required]
        public Guid priorityId { get; set; }
        public string priorityDescription { get; set; }
    }
}
