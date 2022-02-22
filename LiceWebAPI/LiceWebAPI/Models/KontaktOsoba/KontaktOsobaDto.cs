using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.KontaktOsoba
{
    /// <summary>
    /// Dto kontakt osoba
    /// </summary>
    public class KontaktOsobaDto
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Funkcija kontakt osoba
        /// </summary>
        public string Funkcija { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        public string Telefon { get; set; }
    }
}
