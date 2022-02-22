using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice.FizickoLice
{
    public class FizickoLiceUpdateDto
    {
        public string BrojTelefona { get; set; }
        public string BrojTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrojRacuna { get; set; }
        public Guid AdresaId { get; set; } 

        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti jmbg!")]
        public string Jmbg { get; set; }
    }
}
