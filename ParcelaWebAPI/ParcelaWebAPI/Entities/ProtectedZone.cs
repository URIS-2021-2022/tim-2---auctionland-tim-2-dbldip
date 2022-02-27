using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ProtectedZone
    {
        /// <summary>
        /// Protected zone ID
        /// </summary>
        [Key]
       public Guid protectedZoneId { get; set; }
        /// <summary>
        /// Level of protected zone
        /// </summary>
        public int level { get; set; }
    }
}
