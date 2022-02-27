using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Entities
{
    /// <summary>
    /// Predstavlja preduzetu radnju na osnovu žalbe
    /// </summary>
    public class ActionTaken
    {
        /// <summary>
        /// ID preduzete radnje
        /// </summary>
        public Guid actionTakenId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Preduzeta radnja na osnovu žalbe
        /// </summary>
        public string actionTaken { get; set; }
    }
}
