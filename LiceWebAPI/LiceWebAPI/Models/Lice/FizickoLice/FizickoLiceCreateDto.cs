using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice.FizickoLice
{
    /// <summary>
    /// Dto Create fizičko lice
    /// </summary>
    public class FizickoLiceCreateDto
    {
        /// <summary>
        /// Broj telefona fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 1!")]
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 2!")]
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email!")]
        public string Email { get; set; }

        /// <summary>
        /// Broj računa fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj računa!")]
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id adrese!")]
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Ime fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string Ime { get; set; }

        /// <summary>
        /// Prezime fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string Prezime { get; set; }

        /// <summary>
        /// Jmbg fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti jmbg!")]
        public string Jmbg { get; set; }
    }
}
