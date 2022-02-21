using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    public class Members
    {
        [Required]
        public Guid CommissionId { get; set; }
        [Required]
        public Guid PersonId { get; set; }
    }
}
