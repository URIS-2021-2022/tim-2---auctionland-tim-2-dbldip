using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.SluzbeniList
{
    public class SluzbeniListCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti broj!")]
        public string Broj { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti datum!")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti opis!")]
        public string Opis { get; set; }
    }
}
