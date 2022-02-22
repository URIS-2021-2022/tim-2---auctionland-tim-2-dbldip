using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    /// <summary>
    /// Entitet pravno lice
    /// </summary>
    public class PravnoLice : Lice
    {
        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// Maticni broj pravnog lica
        /// </summary>
        public string Maticnibroj { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string Faks { get; set; }

        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        public Guid KontaktOsobaId { get; set; }

        /// <summary>
        /// Kontakt osoba
        /// </summary>
        public KontaktOsoba KontaktOsoba { get; set; }
    }
}
