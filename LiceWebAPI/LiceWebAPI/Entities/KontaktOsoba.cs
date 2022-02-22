using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    /// <summary>
    /// Entitet kontakt osobe
    /// </summary>
    public class KontaktOsoba
    {
        /// <summary>
        /// Id kontakt osobe
        /// </summary>
        [Key]
        public Guid KontaktOsobaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Funkcija kontakt osobe
        /// </summary>
        public string Funkcija { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        public string Telefon { get; set; }
    }
}
