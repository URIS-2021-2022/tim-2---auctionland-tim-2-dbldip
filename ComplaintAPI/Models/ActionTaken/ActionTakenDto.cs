using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.ActionTaken
{
    /// <summary>
    /// Dto za radnju na osnovu žalbe
    /// </summary>
    public class ActionTakenDto
    {
        /// <summary>
        /// ID radnje na osnovu žalbe
        /// </summary>
        public Guid actionTakenId { get; set; }

        /// <summary>
        /// Radnja na osnovu žalbe
        /// </summary>
        public string actionTaken { get; set; }
    }
}
