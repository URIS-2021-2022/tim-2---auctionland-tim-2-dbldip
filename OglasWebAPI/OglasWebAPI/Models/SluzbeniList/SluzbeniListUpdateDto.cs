using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.SluzbeniList
{
    /// <summary>
    /// Dto Update službeni list
    /// </summary>
    public class SluzbeniListUpdateDto
    {
        /// <summary>
        /// Broj službenog lista
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj!")]
        public string Broj { get; set; }

        /// <summary>
        /// Datum službenog lista
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum!")]
        public DateTime Datum { get; set; }

        /// <summary>
        /// Opis službenog lista
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti opis!")]
        public string Opis { get; set; }
    }
}
