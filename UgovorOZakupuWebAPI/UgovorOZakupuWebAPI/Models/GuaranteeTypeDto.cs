using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    /// <summary>
    /// Dto tip garancije
    /// </summary>
    public class GuaranteeTypeDto
    {
        /// <summary>
        /// Tip garancije ID
        /// </summary>
        public Guid GuaranteeTypeId { get; set; }
        /// <summary>
        /// tip
        /// </summary>
        public string Type { get; set; }
    }
}
