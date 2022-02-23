using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    /// <summary>
    /// Entitet tip garancije
    /// </summary>
    public class GuaranteeType
    {
        /// <summary>
        /// ID tipa garancije
        /// </summary>
        public Guid GuaranteeTypeId { get; set; }
        /// <summary>
        /// tip
        /// </summary>
        public string Type { get; set; }
    }
}
