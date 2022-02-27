using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice.FizickoLice
{
    /// <summary>
    /// Dto fizicko lice
    /// </summary>
    public class FizickoLiceDto
    {
        /// <summary>
        /// Broj telefona fizičkog lica
        /// </summary>
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 fizičkog lica
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email fizičkog lica
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj računa fizičkog lica
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid AdresaId { get; set; }

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
