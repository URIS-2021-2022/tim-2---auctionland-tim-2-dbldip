using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice.PravnoLice
{
    /// <summary>
    /// Dto Create pravno lice
    /// </summary>
    public class PravnoLiceCreateDto
    {
        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 1!")]
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 2!")]
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email!")]
        public string Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj računa!")]
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id adrese!")]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv!")]
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti matični broj!")]
        public string Maticnibroj { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti faks!")]
        public string Faks { get; set; }

        /// <summary>
        /// Kontakt osoba id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id kontakt osobe!")]
        public Guid KontaktOsobaId { get; set; }
    }
}
