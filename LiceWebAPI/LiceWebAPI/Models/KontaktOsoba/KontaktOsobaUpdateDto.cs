using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.KontaktOsoba
{
    /// <summary>
    /// Dto Update kontakt osoba
    /// </summary>
    public class KontaktOsobaUpdateDto
    {
        /// <summary>
        /// Ime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string Ime { get; set; }

        /// <summary>
        /// Prezime kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string Prezime { get; set; }

        /// <summary>
        /// Funckija kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti funkciju!")]
        public string Funkcija { get; set; }

        /// <summary>
        /// Telefon kontakt osobe
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti telefon!")]
        public string Telefon { get; set; }
    }
}
