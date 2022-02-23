using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    /// <summary>
    /// Popunjena komisija dto
    /// </summary>
    public class CommissionsFilledDto
    {

        public CommissionsFilledDto()
        {
            Members = new List<Person>();
        }
        /// <summary>
        /// ID Komisija
        /// </summary>
        public Guid CommissionId { get; set; }

        /// <summary>
        /// predsednik
        /// </summary>
        public Person President { get; set; }

        /// <summary>
        /// Lista članova
        /// </summary>
        public List<Person> Members { get; set; }
    }
}
