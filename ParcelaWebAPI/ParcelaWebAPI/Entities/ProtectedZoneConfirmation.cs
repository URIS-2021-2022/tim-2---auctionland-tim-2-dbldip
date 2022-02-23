using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ProtectedZoneConfirmation
    {
        /// <summary>
        /// Protected zone ID
        /// </summary>
        public Guid protectedZoneId { get; set; }
        /// <summary>
        /// Level of protected zone
        /// </summary>
        public int level { get; set; }
    }
}
