using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ProtectedZone
    {
        [Key]
       public Guid protectedZoneId { get; set; }

        public int level { get; set; }
    }
}
