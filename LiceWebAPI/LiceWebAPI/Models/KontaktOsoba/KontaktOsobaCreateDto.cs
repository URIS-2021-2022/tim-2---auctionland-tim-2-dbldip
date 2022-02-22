using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.KontaktOsoba
{
    public class KontaktOsobaCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti funkciju!")]
        public string Funkcija { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti telefon!")]
        public string Telefon { get; set; }
    }
}
