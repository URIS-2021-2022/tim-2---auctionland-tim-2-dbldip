using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    public class KontaktOsoba
    {
        [Key]
        public Guid KontaktOsobaId { get; set; } = Guid.NewGuid();

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Funkcija { get; set; }

        public string Telefon { get; set; }
    }
}
