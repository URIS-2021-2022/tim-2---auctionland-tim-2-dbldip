using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet kreacija komisije
    /// </summary>
    public class CommissionCreation
    {
        /// <summary>
        /// ID komisije
        /// </summary>
        public Guid CommissionId { get; set; }

        /// <summary>
        /// ID predsednika
        /// </summary>
        public Guid PresidentId { get; set; }

        /// <summary>
        /// Lista ID-eva članova
        /// </summary>
        public List<Guid> Members { get; set; }
    }
}
