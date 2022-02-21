using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CommissionWebAPI.Models
{
    public class CommissionDto
    {
        public Guid CommissionId { get; set; }
        public Person President { get; set; }
        public List<Members> Members { get; set; }
    }
}
