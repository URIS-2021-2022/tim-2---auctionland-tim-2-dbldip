using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ProtectedZoneConfirmation
    {
        public Guid protectedZoneId { get; set; }
        public int level { get; set; }
    }
}
