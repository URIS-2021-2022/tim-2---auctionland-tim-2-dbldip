using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    /// <summary>
    /// Entitet komisija sa listom
    /// </summary>
    public class CommissionWithLists
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
        /// Predsednik
        /// </summary>
        public Person President { get; set; }

        /// <summary>
        /// Lista članova
        /// </summary>
        public List<Members> Members { get; set; }

    }
}
