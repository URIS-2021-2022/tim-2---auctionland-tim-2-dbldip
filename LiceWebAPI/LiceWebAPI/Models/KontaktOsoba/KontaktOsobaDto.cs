using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Models.KontaktOsoba
{
    public class KontaktOsobaDto
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Funkcija { get; set; }

        public string Telefon { get; set; }
    }
}
