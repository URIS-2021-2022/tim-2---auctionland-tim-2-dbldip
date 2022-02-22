using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    /// <summary>
    /// Entitet lice
    /// </summary>
    public abstract class Lice
    {
        /// <summary>
        /// Id lica
        /// </summary>
        [Key]
        public Guid LiceId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Broj telefona lica
        /// </summary>
        public string BrojTelefona { get; set; }

        /// <summary>
        /// Broj telefona 2 lica
        /// </summary>
        public string BrojTelefona2 { get; set; }

        /// <summary>
        /// Email kontakt osobe
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Broj racuna kontakt osobe
        /// </summary>
        public string BrojRacuna { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        public Guid? AdresaId { get; set; } 
    }
}
