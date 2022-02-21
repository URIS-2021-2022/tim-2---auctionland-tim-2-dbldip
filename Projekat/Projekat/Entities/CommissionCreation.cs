using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    public class CommissionCreation
    {
        public Guid CommissionId { get; set; }
        public Guid PresidentId { get; set; }
        public List<Guid> Members { get; set; }
    }
}
