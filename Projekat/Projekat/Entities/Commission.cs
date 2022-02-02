using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Entities
{
    public class Commission
    {
        [Key]
        public Guid CommissionId { get; set; }

        public Person President { get; set; }

        public List<Person> Members { get; set; }

    }
}
