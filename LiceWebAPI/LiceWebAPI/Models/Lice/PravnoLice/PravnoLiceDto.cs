using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.PravnoLice
{
    public class PravnoLiceDto
    {
        public string BrojTelefona { get; set; }
        public string BrojTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrojRacuna { get; set; }
        public Guid AdresaId { get; set; }
        public string Naziv { get; set; }
        public string Maticnibroj { get; set; }
        public string Faks { get; set; }
        public KontaktOsobaDto KontaktOsoba { get; set; }
    }
}
