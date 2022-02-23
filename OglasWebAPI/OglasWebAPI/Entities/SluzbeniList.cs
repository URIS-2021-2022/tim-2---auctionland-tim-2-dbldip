using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Entities
{
    /// <summary>
    /// Entitet službeni list
    /// </summary>
    public class SluzbeniList
    {
        /// <summary>
        /// Id službenog lista
        /// </summary>
        [Key]
        public Guid SluzbeniListId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Broj službenog lista
        /// </summary>
        public string Broj { get; set; }

        /// <summary>
        /// Datum službenog lista
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Opis službenog lista
        /// </summary>
        public string Opis { get; set; }


    }
}
