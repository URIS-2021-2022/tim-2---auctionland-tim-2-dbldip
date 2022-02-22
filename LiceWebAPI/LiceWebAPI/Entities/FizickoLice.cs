using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    /// <summary>
    /// Entitet fizick lice
    /// </summary>
    public class FizickoLice : Lice
    {
        /// <summary>
        /// Ime lica
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime lica
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Jmbg lica
        /// </summary>
        public string Jmbg { get; set; }

    }
}
 