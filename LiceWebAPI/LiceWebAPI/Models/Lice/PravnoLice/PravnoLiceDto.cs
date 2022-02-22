using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.PravnoLice
{
    /// <summary>
    /// Dto pravno lica
    /// </summary>
    public class PravnoLiceDto
    {
        /// <summary>
        /// Broj telefona pravnog lica
        /// </summary>
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 pravnog lica
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email pravnog lica
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa pravnog lica
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Naziv pravnog lica
        /// </summary>
        public string Naziv { get; set; }

        /// <summary>
        /// Matični broj pravnog lica
        /// </summary>
        public string Maticnibroj { get; set; }

        /// <summary>
        /// Faks pravnog lica
        /// </summary>
        public string Faks { get; set; }
        public KontaktOsobaDto KontaktOsoba { get; set; }
    }
}
