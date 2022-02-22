using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.Lice.PravnoLice
{
    public class PravnoLiceCreateDto
    {
        public string BrojTelefona { get; set; }
        public string BrojTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrojRacuna { get; set; }
        public Guid AdresaId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv!")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti maticni broj!")]
        public string Maticnibroj { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti faks!")]
        public string Faks { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti kontakt osobu!")]
        public Guid KontaktOsobaId { get; set; }
    }
}
