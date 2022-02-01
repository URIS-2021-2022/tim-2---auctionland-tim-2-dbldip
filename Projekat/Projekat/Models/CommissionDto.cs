using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projekat.Models
{
    public class CommissionDto
    {
        public Guid CommissionId { get; set; }

        public Person President { get; set; }

        public List<Person> Members { get; set; }
    }
}
