using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.SluzbeniList
{
    /// <summary>
    /// Dto službeni list
    /// </summary>
    public class SluzbeniListDto
    {
        /// <summary>
        /// Broj službenog lista
        /// </summary>
        public string Broj { get; set; }

        /// <summary>
        /// Datum službenog lista
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Opis službenog lista
        /// </summary>
        public string Opis { get; set; }
    }
}
