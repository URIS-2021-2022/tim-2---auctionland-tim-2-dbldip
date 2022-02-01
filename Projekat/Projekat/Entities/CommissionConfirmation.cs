using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Entities
{
    public class CommissionConfirmation
    {
        public Guid CommissionId { get; set; }

        public Person President { get; set; }

        public List<Person> Members { get; set; }
    }
}
