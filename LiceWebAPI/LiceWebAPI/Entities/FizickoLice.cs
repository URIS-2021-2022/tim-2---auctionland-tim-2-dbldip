using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    /// <summary>
    /// Entitet fizičko lice
    /// </summary>
    public class FizickoLice : Lice
    {
        /// <summary>
        /// Ime fizičkog lica
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime fizičkog lica
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Jmbg fizičkog lica
        /// </summary>
        public string Jmbg { get; set; }

    }
}
 