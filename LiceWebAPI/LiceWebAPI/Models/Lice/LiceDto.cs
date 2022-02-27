using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice
{
    /// <summary>
    /// Dto lice
    /// </summary>
    public class LiceDto
    {
        /// <summary>
        /// Broj telefona lica
        /// </summary>
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 lica
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email lica
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa lica
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Naziv lica
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj lica
        /// </summary>
        public string Maticnibroj { get; set; }

        /// <summary>
        /// Faks lica
        /// </summary>
        public string Faks { get; set; }

        /// <summary>
        /// Kontakt osoba
        /// </summary>
        public KontaktOsobaDto KontaktOsoba { get; set; }

        /// <summary>
        /// Jmbg lica
        /// </summary>
        public string Jmbg { get; set; }
    }
}
